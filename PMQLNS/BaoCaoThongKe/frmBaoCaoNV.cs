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
    public partial class frmBaoCaoNV : Form
    {

        string connStr = ConfigurationManager.ConnectionStrings["QLNSConnectionString"].ConnectionString;

        public frmBaoCaoNV()
        {
            InitializeComponent();
        }

        private void frmBaoCaoNV_Load(object sender, EventArgs e)
        {
            Load_ChartBangCap();
            Load_ChartSLNVPhongBan();
        }

        private void Load_ChartBangCap()
        {
            // Xóa dữ liệu cũ
            chartBangCap.Series.Clear();
            chartBangCap.Titles.Clear();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                // Thiết lập biểu đồ phân bố nhân viên theo bằng cấp (Pie Chart)
                chartBangCap.Titles.Add("Phân bố nhân viên theo bằng cấp");
                Series series = new Series("Bằng cấp")
                {
                    ChartType = SeriesChartType.Pie,
                    IsValueShownAsLabel = true, // Hiển thị giá trị trên từng phần
                    LabelForeColor = Color.Black, // Màu chữ nhãn
                    Font = new Font("Microsoft Sans Serif", 8f)
                };

                // Truy vấn lấy số lượng nhân viên theo loại bằng cấp
                string query = @"
                    SELECT bc.bc_loai, COUNT(*) AS so_luong
                    FROM BangCap bc
                    GROUP BY bc.bc_loai";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                // Thêm dữ liệu vào biểu đồ
                while (reader.Read())
                {
                    string loaiBang = reader["bc_loai"].ToString();
                    int soLuong = Convert.ToInt32(reader["so_luong"]);
                    series.Points.AddXY(loaiBang, soLuong);
                }
                reader.Close();

                // Tùy chỉnh màu sắc cho các phần của biểu đồ
                string[] colors = { "#FF6384", "#36A2EB", "#FFCE56", "#4CAF50", "#E91E63" };
                for (int i = 0; i < series.Points.Count && i < colors.Length; i++)
                {
                    series.Points[i].Color = ColorTranslator.FromHtml(colors[i]);
                }

                chartBangCap.Series.Add(series);
                chartBangCap.Legends[0].Enabled = true;
                chartBangCap.ChartAreas[0].Area3DStyle.Enable3D = true; // Hiệu ứng 3D
                chartBangCap.ChartAreas[0].AxisX.Title = "Loại bằng cấp";
                chartBangCap.ChartAreas[0].AxisY.Title = "Số lượng nhân viên";
            }
        }

        private void Load_ChartSLNVPhongBan()
        {
            // Xóa dữ liệu cũ
            chartSLNVPhongBan.Series.Clear();
            chartSLNVPhongBan.Titles.Clear();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                // Thiết lập biểu đồ số lượng nhân viên theo phòng ban (Column Chart)
                chartSLNVPhongBan.Titles.Add("Số lượng nhân viên theo phòng ban");
                Series series = new Series("Nhân viên")
                {
                    ChartType = SeriesChartType.Column,
                    IsValueShownAsLabel = true, // Hiển thị giá trị trên cột
                    LabelForeColor = Color.Black,
                    Font = new Font("Microsoft Sans Serif", 8f)
                };

                // Truy vấn lấy số lượng nhân viên theo phòng ban
                string query = @"
                    SELECT pb.pb_ten, pb.pb_soluongnv
                    FROM PhongBan pb
                    ORDER BY pb.pb_ten";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                // Thêm dữ liệu vào biểu đồ
                while (reader.Read())
                {
                    string tenPhongBan = reader["pb_ten"].ToString();
                    int soLuong = Convert.ToInt32(reader["pb_soluongnv"]);
                    series.Points.AddXY(tenPhongBan, soLuong);
                }
                reader.Close();

                // Tùy chỉnh màu sắc cho các cột
                string[] colors = { "#4CAF50", "#2196F3", "#FF9800", "#F44336", "#9C27B0", "#3F51B5" };
                for (int i = 0; i < series.Points.Count && i < colors.Length; i++)
                {
                    series.Points[i].Color = ColorTranslator.FromHtml(colors[i]);
                }

                chartSLNVPhongBan.Series.Add(series);
                chartSLNVPhongBan.Legends[0].Enabled = false; // Không cần legend cho biểu đồ cột
                chartSLNVPhongBan.ChartAreas[0].AxisX.Title = "Phòng ban";
                chartSLNVPhongBan.ChartAreas[0].AxisY.Title = "Số lượng nhân viên";
                chartSLNVPhongBan.ChartAreas[0].AxisX.Interval = 1; // Đảm bảo hiển thị tất cả nhãn phòng ban
            }
        }
    }
}
