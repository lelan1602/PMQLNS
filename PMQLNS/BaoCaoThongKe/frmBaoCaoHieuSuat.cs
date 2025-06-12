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
    public partial class frmBaoCaoHieuSuat : Form
    {
        string connStr = ConfigurationManager.ConnectionStrings["QLNSConnectionString"].ConnectionString;

        public frmBaoCaoHieuSuat()
        {
            InitializeComponent();
        }

        private void frmBaoCaoHieuSuat_Load(object sender, EventArgs e)
        {
            Load_ChartTiLeHoanThanhCV();
            Load_DataGridView();
        }

        private void Load_ChartTiLeHoanThanhCV()
        {
            chartTiLeHoanThanhCV.Series.Clear();
            chartTiLeHoanThanhCV.Titles.Clear();
            chartTiLeHoanThanhCV.ChartAreas[0].BackColor = Color.FromArgb(240, 248, 255); // Màu nền nhẹ (AliceBlue)

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();

                    // Tiêu đề biểu đồ
                    Title chartTitle = new Title("Tỷ lệ hoàn thành công việc theo phòng ban", Docking.Top, new Font("Microsoft Sans Serif", 12f, FontStyle.Bold), Color.DarkBlue);
                    chartTiLeHoanThanhCV.Titles.Add(chartTitle);

                    Series series = new Series("Tỷ lệ hoàn thành")
                    {
                        ChartType = SeriesChartType.Column,
                        IsValueShownAsLabel = true,
                        LabelFormat = "{0:F1}%", // Định dạng nhãn dữ liệu (1 chữ số thập phân)
                        LabelForeColor = Color.DarkGreen,
                        Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Bold),
                        LabelAngle = 0, // Nhãn nằm ngang để dễ đọc
                        LabelBackColor = Color.WhiteSmoke, // Nền nhãn
                        LabelBorderColor = Color.Black,
                        LabelBorderWidth = 1
                    };

                    // Truy vấn lấy tỷ lệ hoàn thành công việc theo phòng ban
                    string query = @"
                        SELECT pb.pb_ten, 
                               COUNT(CASE WHEN cv.cv_trangthai IN ('Hoàn thành') THEN 1 END) AS hoanthanh,
                               COUNT(*) AS tong_congviec,
                               CASE 
                                   WHEN COUNT(*) > 0 
                                   THEN CASE 
                                            WHEN (COUNT(CASE WHEN cv.cv_trangthai IN ('Hoàn thành') THEN 1 END) * 100.0 / COUNT(*)) > 100 
                                            THEN 100 
                                            ELSE (COUNT(CASE WHEN cv.cv_trangthai IN ('Hoàn thành') THEN 1 END) * 100.0 / COUNT(*)) 
                                        END
                                   ELSE 0 
                               END AS ty_le
                        FROM PhongBan pb
                        LEFT JOIN NhanVien nv ON pb.pb_ma = nv.pb_ma
                        LEFT JOIN CongViec cv ON nv.nv_ma = cv.nv_ma
                        GROUP BY pb.pb_ten";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    bool hasData = false;
                    while (reader.Read())
                    {
                        string tenPhongBan = reader["pb_ten"] != DBNull.Value ? reader["pb_ten"].ToString() : "Không xác định";
                        double tyLe = Convert.ToDouble(reader["ty_le"]);
                        int hoanThanh = Convert.ToInt32(reader["hoanthanh"]);
                        int tongCongViec = Convert.ToInt32(reader["tong_congviec"]);
                        if (tongCongViec > 0) // Chỉ hiển thị nếu có công việc
                        {
                            int index = series.Points.AddXY(tenPhongBan, tyLe);
                            series.Points[index].ToolTip = $"{tenPhongBan}: {hoanThanh}/{tongCongViec} công việc hoàn thành ({tyLe:F2}%)";
                            hasData = true;
                        }
                    }
                    reader.Close();

                    if (hasData)
                    {
                        string[] colors = { "#4CAF50", "#2196F3", "#FF9800", "#F44336", "#9C27B0", "#3F51B5" };
                        for (int i = 0; i < series.Points.Count; i++)
                        {
                            series.Points[i].Color = ColorTranslator.FromHtml(colors[i % colors.Length]);
                        }

                        chartTiLeHoanThanhCV.Series.Add(series);
                    }
                    else
                    {
                        chartTiLeHoanThanhCV.Titles.Add("Không có dữ liệu công việc");
                    }

                    // Tùy chỉnh trục và giao diện
                    chartTiLeHoanThanhCV.Legends[0].Enabled = false;
                    chartTiLeHoanThanhCV.ChartAreas[0].AxisX.Title = "Phòng ban";
                    chartTiLeHoanThanhCV.ChartAreas[0].AxisX.TitleFont = new Font("Microsoft Sans Serif", 10f, FontStyle.Bold);
                    chartTiLeHoanThanhCV.ChartAreas[0].AxisY.Title = "Tỷ lệ hoàn thành (%)";
                    chartTiLeHoanThanhCV.ChartAreas[0].AxisY.TitleFont = new Font("Microsoft Sans Serif", 10f, FontStyle.Bold);
                    chartTiLeHoanThanhCV.ChartAreas[0].AxisX.Interval = 1;
                    chartTiLeHoanThanhCV.ChartAreas[0].AxisY.Maximum = 100;
                    chartTiLeHoanThanhCV.ChartAreas[0].AxisY.LabelStyle.Format = "{0:F1}";
                    chartTiLeHoanThanhCV.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Microsoft Sans Serif", 9f);
                    chartTiLeHoanThanhCV.ChartAreas[0].AxisY.LabelStyle.Font = new Font("Microsoft Sans Serif", 9f);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Lỗi cơ sở dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Load_DataGridView()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();

                    // Truy vấn lấy danh sách công việc chi tiết
                    string query = @"
                        SELECT 
                            pb.pb_ten AS PhongBan, 
                            cv.cviec_ma AS MaCongViec, 
                            cv.cviec_ten AS TenCongViec, 
                            cv.cv_ngaygiao AS NgayGiao, 
                            ISNULL(cv.cv_trangthai, 'Chưa hoàn thành') AS TrangThai
                        FROM PhongBan pb
                        LEFT JOIN NhanVien nv ON pb.pb_ma = nv.pb_ma
                        LEFT JOIN CongViec cv ON nv.nv_ma = cv.nv_ma
                        ORDER BY pb.pb_ten, cv.cv_ngaygiao";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGridViewCongViec.DataSource = dt;

                    // Định dạng DataGridView
                    dataGridViewCongViec.AutoResizeColumns();
                    dataGridViewCongViec.Columns["PhongBan"].HeaderText = "Phòng Ban";
                    dataGridViewCongViec.Columns["MaCongViec"].HeaderText = "Mã Công Việc";
                    dataGridViewCongViec.Columns["TenCongViec"].HeaderText = "Tên Công Việc";
                    dataGridViewCongViec.Columns["NgayGiao"].HeaderText = "Ngày Giao";
                    dataGridViewCongViec.Columns["TrangThai"].HeaderText = "Trạng Thái";

                    // Tùy chỉnh kích thước cột nếu cần
                    dataGridViewCongViec.Columns["PhongBan"].Width = 120;
                    dataGridViewCongViec.Columns["MaCongViec"].Width = 100;
                    dataGridViewCongViec.Columns["TenCongViec"].Width = 200;
                    dataGridViewCongViec.Columns["NgayGiao"].Width = 100;
                    dataGridViewCongViec.Columns["TrangThai"].Width = 120;

                    // Tùy chỉnh giao diện DataGridView
                    dataGridViewCongViec.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold);
                    dataGridViewCongViec.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 9f);
                    dataGridViewCongViec.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 248, 255); // Màu nền xen kẽ
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Lỗi cơ sở dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
