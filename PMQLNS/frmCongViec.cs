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

namespace PMQLNS
{
    public partial class frmCongViec : Form
    {
        string connStr = ConfigurationManager.ConnectionStrings["QLNSConnectionString"].ConnectionString;
        public frmCongViec()
        {
            InitializeComponent();
            LoadData();
            LoadNhanVien();
            LoadTrangThai();
        }

        private void LoadData()
        {
            string query = "SELECT * FROM congviec";

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dtgCongViec.DataSource = dt;
                // Đặt tên tiếng Việt cho các cột
                dtgCongViec.Columns["cviec_ma"].HeaderText = "Mã Công Việc";
                dtgCongViec.Columns["nv_ma"].HeaderText = "Mã Nhân Viên";
                dtgCongViec.Columns["cviec_ten"].HeaderText = "Tên Công Việc";
                dtgCongViec.Columns["cviec_noidung"].HeaderText = "Nội Dung";
                dtgCongViec.Columns["cv_ngaygiao"].HeaderText = "Ngày Giao";
                dtgCongViec.Columns["cv_trangthai"].HeaderText = "Trạng Thái";
                dtgCongViec.Columns["danhgia"].HeaderText = "Đánh Giá";
                dtgCongViec.Columns["danhgia"].Visible = false;
                foreach (DataGridViewColumn col in dtgCongViec.Columns)
                {
                    col.Width = 797/6 - 5;
                }
            }
        }
        private void LoadNhanVien()
        {
            string query = "SELECT nv_ma, nv_ten FROM nhanvien";

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cbxTenNhanVien.DataSource = dt;
                cbxTenNhanVien.DisplayMember = "nv_ten";
                cbxTenNhanVien.ValueMember = "nv_ma";
            }
        }
        private void LoadTrangThai()
        {
            cbxTrangThai.Items.Clear();
            cbxTrangThai.Items.Add("Hoàn thành");
            cbxTrangThai.Items.Add("Chưa hoàn thành");
            cbxTrangThai.SelectedIndex = 0; // chọn mặc định
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO congviec (cviec_ma, nv_ma, cviec_ten, cviec_noidung, cv_ngaygiao, cv_trangthai) " +
                           "VALUES (@cviec_ma, @nv_ma, @ten, @noidung, @ngaygiao, @trangthai)";

            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@cviec_ma", txtMaCongViec.Text);
                cmd.Parameters.AddWithValue("@ten", txtTenCongViec.Text.Trim());
                cmd.Parameters.AddWithValue("@nv_ma", cbxTenNhanVien.SelectedValue);
                cmd.Parameters.AddWithValue("@noidung", txtNoiDung.Text.Trim());
                cmd.Parameters.AddWithValue("@ngaygiao", dtpNgayGiao.Value);
                cmd.Parameters.AddWithValue("@trangthai", cbxTrangThai.SelectedItem.ToString());

                conn.Open();
                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show("Thêm công việc thành công!");
                    LoadData(); // refresh lại DataGridView
                }
                else
                {
                    MessageBox.Show("Thêm thất bại!");
                }
            }
        }

        private void dtgCongViec_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // tránh header
            {
                DataGridViewRow row = dtgCongViec.Rows[e.RowIndex];

                // Gán dữ liệu từ dòng đã chọn lên các control
                txtMaCongViec.Text = row.Cells["cviec_ma"].Value?.ToString();
                txtTenCongViec.Text = row.Cells["cviec_ten"].Value?.ToString();
                txtNoiDung.Text = row.Cells["cviec_noidung"].Value?.ToString();

                if (row.Cells["cv_ngaygiao"].Value != DBNull.Value)
                    dtpNgayGiao.Value = Convert.ToDateTime(row.Cells["cv_ngaygiao"].Value);

                // Gán giá trị cho ComboBox nhân viên (giá trị là mã)
                cbxTenNhanVien.SelectedValue = row.Cells["nv_ma"].Value?.ToString();

                // Gán giá trị cho trạng thái (hiển thị chuỗi)
                cbxTrangThai.SelectedItem = row.Cells["cv_trangthai"].Value?.ToString();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dtgCongViec.CurrentRow != null)
            {
                // Lấy mã công việc từ dòng đang chọn
                int maCongViec = Convert.ToInt32(dtgCongViec.CurrentRow.Cells["cviec_ma"].Value);

                string query = "UPDATE congviec SET " +
                               "nv_ma = @nv_ma, " +
                               "cviec_ten = @ten, " +
                               "cviec_noidung = @noidung, " +
                               "cv_ngaygiao = @ngaygiao, " +
                               "cv_trangthai = @trangthai " +
                               "WHERE cviec_ma = @macv";

                using (SqlConnection conn = new SqlConnection(connStr))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nv_ma", cbxTenNhanVien.SelectedValue);
                    cmd.Parameters.AddWithValue("@ten", txtTenCongViec.Text.Trim());
                    cmd.Parameters.AddWithValue("@noidung", txtNoiDung.Text.Trim());
                    cmd.Parameters.AddWithValue("@ngaygiao", dtpNgayGiao.Value);
                    cmd.Parameters.AddWithValue("@trangthai", cbxTrangThai.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@macv", maCongViec);

                    conn.Open();
                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Cập nhật công việc thành công!");
                        LoadData(); // refresh lại bảng
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thất bại!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn công việc cần sửa.");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dtgCongViec.CurrentRow != null)
            {
                // Xác nhận trước khi xóa
                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa công việc này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    int maCongViec = Convert.ToInt32(dtgCongViec.CurrentRow.Cells["cviec_ma"].Value);

                    string query = "DELETE FROM congviec WHERE cviec_ma = @macv";

                    using (SqlConnection conn = new SqlConnection(connStr))
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@macv", maCongViec);

                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Xóa công việc thành công!");
                            LoadData(); // refresh lại DataGridView
                        }
                        else
                        {
                            MessageBox.Show("Xóa thất bại!");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn công việc cần xóa.");
            }
        }

        private void frmCongViec_Load(object sender, EventArgs e)
        {

        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            txtMaCongViec.Text = "";
            txtNoiDung.Text = "";
            txtTenCongViec.Text = "";
            cbxTenNhanVien.Text = "";
            cbxTrangThai.Text = "";
        }
    }
}
