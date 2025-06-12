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

namespace PMQLNS.ChucVu
{
    public partial class frmChucVu : Form
    {
        string connStr = ConfigurationManager.ConnectionStrings["QLNSConnectionString"].ConnectionString;

        public frmChucVu()
        {
            InitializeComponent();
            LoadChucVu();
        }
        private void LoadChucVu()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT cv_ma AS [Mã chức vụ], cv_ten AS [Tên chức vụ], cv_luongcoban AS [Lương cơ bản] FROM ChucVu";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dtgChucVu.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi load dữ liệu chức vụ: " + ex.Message);
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string maCV = txtMaChucVu.Text.Trim();
            string tenCV = txtTenChucVu.Text.Trim();
            string luongCBStr = txtLuongCoBan.Text.Trim();

            // Ràng buộc dữ liệu
            if (string.IsNullOrEmpty(maCV) || string.IsNullOrEmpty(tenCV) || string.IsNullOrEmpty(luongCBStr))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            if (!float.TryParse(luongCBStr, out float luongCB) || luongCB <= 0)
            {
                MessageBox.Show("Lương cơ bản phải là số dương!");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();

                    // ✅ Kiểm tra mã chức vụ đã tồn tại chưa
                    string checkQuery = "SELECT COUNT(*) FROM ChucVu WHERE cv_ma = @ma";
                    SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@ma", maCV);
                    int count = (int)checkCmd.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Mã chức vụ đã tồn tại, vui lòng nhập mã khác!");
                        return;
                    }

                    // Nếu chưa có, thì thêm mới
                    string query = @"INSERT INTO ChucVu (cv_ma, cv_ten, cv_luongcoban)
                             VALUES (@ma, @ten, @luong)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ma", maCV);
                    cmd.Parameters.AddWithValue("@ten", tenCV);
                    cmd.Parameters.AddWithValue("@luong", luongCB);

                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        MessageBox.Show("Thêm chức vụ thành công!");
                        LoadChucVu(); // Load lại DataGridView
                        ClearChucVuInputs(); // Xóa nội dung textbox
                    }
                    else
                    {
                        MessageBox.Show("Không thể thêm chức vụ!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi thêm chức vụ: " + ex.Message);
                }
            }
        }

        private void ClearChucVuInputs()
        {
            txtMaChucVu.Clear();
            txtTenChucVu.Clear();
            txtLuongCoBan.Clear();
        }

        private void dtgChucVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Đảm bảo không click header
            {
                DataGridViewRow row = dtgChucVu.Rows[e.RowIndex];

                txtMaChucVu.Text = row.Cells["Mã chức vụ"].Value?.ToString();
                txtTenChucVu.Text = row.Cells["Tên chức vụ"].Value?.ToString();
                txtLuongCoBan.Text = row.Cells["Lương cơ bản"].Value?.ToString();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string maCV = txtMaChucVu.Text.Trim();
            string tenCV = txtTenChucVu.Text.Trim();
            string luongCoBanStr = txtLuongCoBan.Text.Trim();

            if (string.IsNullOrEmpty(maCV))
            {
                MessageBox.Show("Vui lòng chọn chức vụ cần sửa.");
                return;
            }

            if (string.IsNullOrEmpty(tenCV))
            {
                MessageBox.Show("Tên chức vụ không được để trống.");
                return;
            }

            if (!decimal.TryParse(luongCoBanStr, out decimal luongCoBan) || luongCoBan <= 0)
            {
                MessageBox.Show("Lương cơ bản phải là số dương.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string updateQuery = @"UPDATE ChucVu
                                   SET cv_ten = @tenCV, cv_luongcoban = @luong
                                   WHERE cv_ma = @maCV";

                    SqlCommand cmd = new SqlCommand(updateQuery, conn);
                    cmd.Parameters.AddWithValue("@maCV", maCV);
                    cmd.Parameters.AddWithValue("@tenCV", tenCV);
                    cmd.Parameters.AddWithValue("@luong", luongCoBan);

                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        MessageBox.Show("Cập nhật chức vụ thành công.");
                        LoadChucVu(); // Reload lại DataGridView
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy chức vụ để cập nhật.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật chức vụ: " + ex.Message);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maCV = txtMaChucVu.Text.Trim();

            if (string.IsNullOrEmpty(maCV))
            {
                MessageBox.Show("Vui lòng chọn chức vụ để xóa!");
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa chức vụ này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
                return;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string deleteQuery = "DELETE FROM ChucVu WHERE cv_ma = @ma";
                    SqlCommand deleteCmd = new SqlCommand(deleteQuery, conn);
                    deleteCmd.Parameters.AddWithValue("@ma", maCV);

                    int rows = deleteCmd.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        MessageBox.Show("Xóa chức vụ thành công!");
                        LoadChucVu(); // Load lại DataGridView
                        ClearChucVuInputs(); // Xóa textbox
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa chức vụ!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa chức vụ: " + ex.Message);
                }
            }
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            txtMaChucVu.Text = "";
            txtTenChucVu.Text = "";
            txtLuongCoBan.Text = "";
        }
    }
}
