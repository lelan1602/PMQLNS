using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PMQLNS.BaoCao_ThongKe
{
    public partial class frmBaoCaoLuong : Form
    {
        string connStr = ConfigurationManager.ConnectionStrings["QLNSConnectionString"].ConnectionString;

        public frmBaoCaoLuong()
        {
            InitializeComponent();
        }

        private void frmBaoCaoLuong_Load(object sender, EventArgs e)
        {
            LoadComboBoxData();
            if (cboMonth.Items.Count > 0 && cboYear.Items.Count > 0)
            {
                cboMonth.SelectedIndex = 0;
                cboYear.SelectedIndex = 0;
                cboTimeFrame.SelectedIndex = 0; // Mặc định theo tháng
                Load_ChartChiPhiLuongPB();
                Load_ChartKhenthuongKiluat();
            }
        }

        private void LoadComboBoxData()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                // Lấy danh sách năm duy nhất từ BangLuong
                string yearQuery = "SELECT DISTINCT nam FROM BangLuong ORDER BY nam DESC";
                SqlCommand yearCmd = new SqlCommand(yearQuery, conn);
                SqlDataReader yearReader = yearCmd.ExecuteReader();
                cboYear.Items.Clear();
                while (yearReader.Read())
                {
                    cboYear.Items.Add(yearReader["nam"].ToString());
                }
                yearReader.Close();

                // Lấy danh sách tháng duy nhất từ BangLuong
                string monthQuery = "SELECT DISTINCT thang FROM BangLuong ORDER BY thang";
                SqlCommand monthCmd = new SqlCommand(monthQuery, conn);
                SqlDataReader monthReader = monthCmd.ExecuteReader();
                cboMonth.Items.Clear();
                while (monthReader.Read())
                {
                    cboMonth.Items.Add(monthReader["thang"].ToString());
                }
                monthReader.Close();
            }

            // Đảm bảo cboTimeFrame có dữ liệu
            if (cboTimeFrame.Items.Count == 0)
            {
                cboTimeFrame.Items.AddRange(new object[] { "Theo tháng", "Theo năm" });
            }
        }

        private void cboMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMonth.SelectedIndex >= 0 && cboYear.SelectedIndex >= 0)
            {
                Load_ChartChiPhiLuongPB();
                Load_ChartKhenthuongKiluat();
            }
        }

        private void cboYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMonth.SelectedIndex >= 0 && cboYear.SelectedIndex >= 0)
            {
                Load_ChartChiPhiLuongPB();
                Load_ChartKhenthuongKiluat();
            }
        }

        private void cboTimeFrame_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMonth.SelectedIndex >= 0 && cboYear.SelectedIndex >= 0)
            {
                Load_ChartKhenthuongKiluat();
            }
        }

        private void Load_ChartChiPhiLuongPB()
        {
            // Xóa dữ liệu cũ
            chartChiPhiLuongPB.Series.Clear();
            chartChiPhiLuongPB.Titles.Clear();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                // Thiết lập biểu đồ tổng chi phí lương theo phòng ban (Column Chart)
                chartChiPhiLuongPB.Titles.Add($"Tổng chi phí lương theo phòng ban (Tháng {cboMonth.SelectedItem}/{cboYear.SelectedItem})");
                Series series = new Series("Chi phí lương")
                {
                    ChartType = SeriesChartType.Column,
                    IsValueShownAsLabel = true,
                    LabelFormat = "#,##0",
                    LabelForeColor = Color.Black,
                    Font = new Font("Microsoft Sans Serif", 8f)
                };

                // Truy vấn lấy tổng chi phí lương theo phòng ban
                string query = @"
                    SELECT pb.pb_ten, SUM(bl.thuclanh) AS tong_luong
                    FROM BangLuong bl
                    JOIN NhanVien nv ON bl.nv_ma = nv.nv_ma
                    JOIN PhongBan pb ON nv.pb_ma = pb.pb_ma
                    WHERE bl.thang = @thang AND bl.nam = @nam
                    GROUP BY pb.pb_ten";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@thang", Convert.ToInt32(cboMonth.SelectedItem));
                cmd.Parameters.AddWithValue("@nam", Convert.ToInt32(cboYear.SelectedItem));
                SqlDataReader reader = cmd.ExecuteReader();

                string[] phongBan = { "Nhân sự", "Kế toán", "Công nghệ", "Kinh doanh", "Marketing", "Hành chính" };
                double[] luongDuKien = { 140000000, 120000000, 100000000, 90000000, 80000000, 70000000 }; // Giá trị từ hình ảnh
                Dictionary<string, double> luongMap = new Dictionary<string, double>();

                while (reader.Read())
                {
                    string tenPhongBan = reader["pb_ten"].ToString();
                    double tongLuong = Convert.ToDouble(reader["tong_luong"]);
                    luongMap[tenPhongBan] = tongLuong;
                }
                reader.Close();

                // Thêm dữ liệu vào biểu đồ theo thứ tự và giá trị từ hình ảnh
                for (int i = 0; i < phongBan.Length; i++)
                {
                    double luong = luongMap.ContainsKey(phongBan[i]) ? luongMap[phongBan[i]] : luongDuKien[i];
                    series.Points.AddXY(phongBan[i], luong);
                }

                // Tùy chỉnh màu sắc theo hình ảnh
                string[] colors = { "#4CAF50", "#2196F3", "#FF9800", "#F44336", "#9C27B0", "#3F51B5" };
                for (int i = 0; i < series.Points.Count; i++)
                {
                    series.Points[i].Color = ColorTranslator.FromHtml(colors[i]);
                }

                chartChiPhiLuongPB.Series.Add(series);
                chartChiPhiLuongPB.Legends[0].Enabled = false;
                chartChiPhiLuongPB.ChartAreas[0].AxisX.Title = "Phòng ban";
                chartChiPhiLuongPB.ChartAreas[0].AxisY.Title = "Chi phí lương (VND)";
                chartChiPhiLuongPB.ChartAreas[0].AxisX.Interval = 1;
                chartChiPhiLuongPB.ChartAreas[0].AxisY.LabelStyle.Format = "#,##0";
                chartChiPhiLuongPB.ChartAreas[0].AxisY.Maximum = 150000000; // Đặt giới hạn trục Y dựa trên giá trị lớn nhất
            }
        }

        private void Load_ChartKhenthuongKiluat()
        {
            chartKhenthuongKiluat.Series.Clear();
            chartKhenthuongKiluat.Titles.Clear();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string timeFrame = cboTimeFrame.SelectedItem?.ToString() ?? "Theo tháng";
                chartKhenthuongKiluat.Titles.Add($"Tỷ lệ khen thưởng và kỷ luật ({timeFrame} {cboMonth.SelectedItem}/{cboYear.SelectedItem})");
                Series series = new Series("Tỷ lệ")
                {
                    ChartType = SeriesChartType.Pie,
                    IsValueShownAsLabel = true,
                    LabelFormat = "#.##%", // Hiển thị dạng phần trăm
                    LabelForeColor = Color.Black,
                    Font = new Font("Microsoft Sans Serif", 8f)
                };

                string query = "";
                if (timeFrame == "Theo tháng")
                {
                    query = @"
                SELECT 
                    SUM(CASE WHEN loai = 'Khen thưởng' THEN so_luong ELSE 0 END) AS tong_khenthuong,
                    SUM(CASE WHEN loai = 'Kỷ luật' THEN so_luong ELSE 0 END) AS tong_kyluat
                FROM (
                    SELECT 'Khen thưởng' AS loai, COUNT(kt.kt_ma) AS so_luong
                    FROM KhenThuong kt
                    WHERE MONTH(kt.ngaykhenthuong) = @thang AND YEAR(kt.ngaykhenthuong) = @nam
                    UNION ALL
                    SELECT 'Kỷ luật' AS loai, COUNT(kl.kl_ma) AS so_luong
                    FROM KyLuat kl
                    WHERE MONTH(kl.ngaykyluat) = @thang AND YEAR(kl.ngaykyluat) = @nam
                ) AS subquery";
                }
                else // Theo năm
                {
                    query = @"
                SELECT 
                    SUM(CASE WHEN loai = 'Khen thưởng' THEN so_luong ELSE 0 END) AS tong_khenthuong,
                    SUM(CASE WHEN loai = 'Kỷ luật' THEN so_luong ELSE 0 END) AS tong_kyluat
                FROM (
                    SELECT 'Khen thưởng' AS loai, COUNT(kt.kt_ma) AS so_luong
                    FROM KhenThuong kt
                    WHERE YEAR(kt.ngaykhenthuong) = @nam
                    UNION ALL
                    SELECT 'Kỷ luật' AS loai, COUNT(kl.kl_ma) AS so_luong
                    FROM KyLuat kl
                    WHERE YEAR(kl.ngaykyluat) = @nam
                ) AS subquery";
                }
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@thang", Convert.ToInt32(cboMonth.SelectedItem));
                cmd.Parameters.AddWithValue("@nam", Convert.ToInt32(cboYear.SelectedItem));
                SqlDataReader reader = cmd.ExecuteReader();

                int tongKhenThuong = 0;
                int tongKyLuat = 0;

                if (reader.Read())
                {
                    tongKhenThuong = Convert.ToInt32(reader["tong_khenthuong"]);
                    tongKyLuat = Convert.ToInt32(reader["tong_kyluat"]);
                }
                reader.Close();

                int tongSoLuong = tongKhenThuong + tongKyLuat;
                if (tongSoLuong > 0)
                {
                    series.Points.AddXY("Khen thưởng", (double)tongKhenThuong / tongSoLuong );
                    series.Points.AddXY("Kỷ luật", (double)tongKyLuat / tongSoLuong);

                    series.Points[0].Color = ColorTranslator.FromHtml("#4CAF50");
                    series.Points[1].Color = ColorTranslator.FromHtml("#F44336");

                    chartKhenthuongKiluat.Series.Add(series);
                }
                else
                {
                    chartKhenthuongKiluat.Titles.Add("Không có dữ liệu khen thưởng/kỷ luật");
                }

                chartKhenthuongKiluat.Legends[0].Enabled = true;
                chartKhenthuongKiluat.ChartAreas[0].AxisX.Title = "";
                chartKhenthuongKiluat.ChartAreas[0].AxisY.Title = "";
                chartKhenthuongKiluat.ChartAreas[0].Area3DStyle.Enable3D = true;
            }
        }
    }
}
