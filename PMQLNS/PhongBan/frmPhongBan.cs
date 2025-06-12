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

namespace PMQLNS.PhongBan
{
    public partial class frmPhongBan : Form
    {
        string connStr = ConfigurationManager.ConnectionStrings["QLNSConnectionString"].ConnectionString;

        public frmPhongBan()
        {
            InitializeComponent(); 
            LoadPhongBan();
        }

        private void LoadPhongBan()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT pb_ma, pb_ten, pb_soluongnv FROM PhongBan";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dtgPhongBan.DataSource = dt;

                    // Nếu muốn chỉnh tên cột hiển thị tiếng Việt
                    dtgPhongBan.Columns["pb_ma"].HeaderText = "Mã phòng ban";
                    dtgPhongBan.Columns["pb_ten"].HeaderText = "Tên phòng ban";
                    dtgPhongBan.Columns["pb_soluongnv"].HeaderText = "Số lượng nhân viên";

                    // Set độ rộng 180px cho đẹp
                    foreach (DataGridViewColumn col in dtgPhongBan.Columns)
                    {
                        col.Width = 202;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi load phòng ban: " + ex.Message);
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string ma = txtMaPhongBan.Text.Trim();
            string ten = txtTenPhongBan.Text.Trim();
            string slStr = txtSLNV.Text.Trim();

            // Kiểm tra rỗng
            if (string.IsNullOrEmpty(ma) || string.IsNullOrEmpty(ten) || string.IsNullOrEmpty(slStr))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return;
            }

            // Regex: mã phòng ban phải là chữ + số, không ký tự đặc biệt, <= 10 ký tự
            if (!System.Text.RegularExpressions.Regex.IsMatch(ma, @"^[a-zA-Z0-9]{1,10}$"))
            {
                MessageBox.Show("Mã phòng ban chỉ được chứa chữ và số, tối đa 10 ký tự.");
                return;
            }

            // Regex: tên phòng ban là chữ (có thể có dấu cách), không số hoặc ký tự đặc biệt, <= 100 ký tự
            if (!System.Text.RegularExpressions.Regex.IsMatch(ten, @"^[a-zA-ZÀ-ỹ\s]{1,100}$"))
            {
                MessageBox.Show("Tên phòng ban chỉ chứa ký tự chữ, không có số hay ký tự đặc biệt, tối đa 100 ký tự.");
                return;
            }

            // Kiểm tra số lượng là số nguyên dương
            if (!int.TryParse(slStr, out int sl) || sl <= 0)
            {
                MessageBox.Show("Số lượng nhân viên phải là số nguyên dương.");
                return;
            }

            // Thêm vào CSDL
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string insert = "INSERT INTO PhongBan(pb_ma, pb_ten, pb_soluongnv) VALUES (@ma, @ten, @sl)";
                    SqlCommand cmd = new SqlCommand(insert, conn);
                    cmd.Parameters.AddWithValue("@ma", ma);
                    cmd.Parameters.AddWithValue("@ten", ten);
                    cmd.Parameters.AddWithValue("@sl", sl);

                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Thêm phòng ban thành công!");
                        LoadPhongBan();
                        txtMaPhongBan.Clear();
                        txtTenPhongBan.Clear();
                        txtSLNV.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Không thể thêm phòng ban.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm phòng ban: " + ex.Message);
                }
            }
        }

        private void dtgPhongBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtgPhongBan.Rows[e.RowIndex];

                txtMaPhongBan.Text = row.Cells["pb_ma"].Value.ToString();
                txtTenPhongBan.Text = row.Cells["pb_ten"].Value.ToString();
                txtSLNV.Text = row.Cells["pb_soluongnv"].Value.ToString();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string ma = txtMaPhongBan.Text.Trim();
            string ten = txtTenPhongBan.Text.Trim();
            string slStr = txtSLNV.Text.Trim();

            if (string.IsNullOrEmpty(ma) || string.IsNullOrEmpty(ten) || string.IsNullOrEmpty(slStr))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return;
            }

            // Validation y chang phần thêm
            if (!System.Text.RegularExpressions.Regex.IsMatch(ma, @"^[a-zA-Z0-9]{1,10}$"))
            {
                MessageBox.Show("Mã phòng ban không hợp lệ.");
                return;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(ten, @"^[a-zA-ZÀ-ỹ\s]{1,100}$"))
            {
                MessageBox.Show("Tên phòng ban không hợp lệ.");
                return;
            }

            if (!int.TryParse(slStr, out int sl) || sl <= 0)
            {
                MessageBox.Show("Số lượng phải là số nguyên dương.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string update = "UPDATE PhongBan SET pb_ten = @ten, pb_soluongnv = @sl WHERE pb_ma = @ma";
                    SqlCommand cmd = new SqlCommand(update, conn);
                    cmd.Parameters.AddWithValue("@ma", ma);
                    cmd.Parameters.AddWithValue("@ten", ten);
                    cmd.Parameters.AddWithValue("@sl", sl);

                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Cập nhật thành công!");
                        LoadPhongBan();
                    }
                    else
                    {
                        MessageBox.Show("Không thể cập nhật.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi cập nhật: " + ex.Message);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string ma = txtMaPhongBan.Text.Trim();

            if (string.IsNullOrEmpty(ma))
            {
                MessageBox.Show("Vui lòng chọn phòng ban cần xóa.");
                return;
            }

            // Hộp thoại xác nhận
            DialogResult result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa phòng ban có mã \"{ma}\" không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    try
                    {
                        conn.Open();
                        string delete = "DELETE FROM PhongBan WHERE pb_ma = @ma";
                        SqlCommand cmd = new SqlCommand(delete, conn);
                        cmd.Parameters.AddWithValue("@ma", ma);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Xóa phòng ban thành công.");
                            LoadPhongBan(); // Load lại danh sách
                            ClearTextBoxes(); // Xóa nội dung textbox
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy phòng ban cần xóa.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi xóa: " + ex.Message);
                    }
                }
            }
        }
        private void ClearTextBoxes()
        {
            txtMaPhongBan.Clear();
            txtTenPhongBan.Clear();
            txtSLNV.Clear();
        }

        private void frmPhongBan_Load(object sender, EventArgs e)
        {

        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            txtMaPhongBan.Text = "";
            txtSLNV.Text = "";
            txtTenPhongBan.Text = "";
        }
    }
}
