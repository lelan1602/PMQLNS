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
    public partial class frmKhenThuongVaKyLuat : Form
    {
        string connStr = ConfigurationManager.ConnectionStrings["QLNSConnectionString"].ConnectionString;

        public frmKhenThuongVaKyLuat()
        {
            InitializeComponent();
            LoadKhenThuong();
            LoadNhanVien();
            LoadKyLuat();
            LoadNhanVienKL();
        }

        private void LoadKyLuat()
        {
            string query = @"
        SELECT kl.kl_ma AS [Mã KL], nv.nv_ten AS [Tên nhân viên], 
               kl.kl_ten AS [Tên kỷ luật], kl.ngaykyluat AS [Ngày kỷ luật],
               kl.kl_lydo AS [Lý do], kl.kl_sotien AS [Số tiền]
        FROM KyLuat kl
        JOIN NhanVien nv ON kl.nv_ma = nv.nv_ma";

            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                dtgKyLuat.DataSource = dt;
            }
        }

        private void LoadNhanVienKL()
        {
            string query = "SELECT nv_ma, nv_ten FROM NhanVien";
            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                cbxTenNhanVienKL.DataSource = dt;
                cbxTenNhanVienKL.DisplayMember = "nv_ten";
                cbxTenNhanVienKL.ValueMember = "nv_ma";
            }
        }


        private void LoadKhenThuong()
        {
            string query = @"
        SELECT kt.kt_ma AS [Mã KT], nv.nv_ten AS [Tên nhân viên], 
               kt.kt_ten AS [Tên khen thưởng], kt.ngaykhenthuong AS [Ngày khen thưởng], 
               kt.kt_lydo AS [Lý do], kt.kt_sotien AS [Số tiền]
        FROM KhenThuong kt
        JOIN NhanVien nv ON kt.nv_ma = nv.nv_ma";

            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                dtgKhenThuong.DataSource = dt;
            }
        }

        private void LoadNhanVien()
        {
            string query = "SELECT nv_ma, nv_ten FROM NhanVien";
            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                cbxTenNhanVien.DataSource = dt;
                cbxTenNhanVien.DisplayMember = "nv_ten";
                cbxTenNhanVien.ValueMember = "nv_ma";
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (cbxTenNhanVien.SelectedValue == null || string.IsNullOrWhiteSpace(txtTenKhenThuong.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            string query = "INSERT INTO KhenThuong (kt_ma, nv_ma, kt_ten, ngaykhenthuong, kt_lydo, kt_sotien) " +
                           "VALUES (@ma, @nv, @ten, @ngay, @lydo, @sotien)";

            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@ma", txtMaKhenThuong.Text);
                cmd.Parameters.AddWithValue("@nv", cbxTenNhanVien.SelectedValue);
                cmd.Parameters.AddWithValue("@ten", txtTenKhenThuong.Text);
                cmd.Parameters.AddWithValue("@ngay", dtpNgayKhenThuong.Value);
                cmd.Parameters.AddWithValue("@lydo", txtLyDo.Text);
                cmd.Parameters.AddWithValue("@sotien", txtSoTien.Text);

                conn.Open();
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Thêm khen thưởng thành công!");
                    LoadKhenThuong();
                }
                else MessageBox.Show("Thêm thất bại!");
            }
        }

        private void dtgKhenThuong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtgKhenThuong.Rows[e.RowIndex];
                txtMaKhenThuong.Text = row.Cells[0].Value.ToString();
                cbxTenNhanVien.Text = row.Cells[1].Value.ToString();
                txtTenKhenThuong.Text = row.Cells[2].Value.ToString();
                dtpNgayKhenThuong.Value = Convert.ToDateTime(row.Cells[3].Value);
                txtLyDo.Text = row.Cells[4].Value.ToString();
                txtSoTien.Text = row.Cells[5].Value.ToString();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string query = "UPDATE KhenThuong SET nv_ma = @nv, kt_ten = @ten, ngaykhenthuong = @ngay, kt_lydo = @lydo, kt_sotien = @sotien WHERE kt_ma = @ma";

            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@ma", txtMaKhenThuong.Text);
                cmd.Parameters.AddWithValue("@nv", cbxTenNhanVien.SelectedValue);
                cmd.Parameters.AddWithValue("@ten", txtTenKhenThuong.Text);
                cmd.Parameters.AddWithValue("@ngay", dtpNgayKhenThuong.Value);
                cmd.Parameters.AddWithValue("@lydo", txtLyDo.Text);
                cmd.Parameters.AddWithValue("@sotien", txtSoTien.Text);

                conn.Open();
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Sửa thông tin khen thưởng thành công!");
                    LoadKhenThuong();
                }
                else MessageBox.Show("Sửa thất bại!");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Bạn có chắc muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                string query = "DELETE FROM KhenThuong WHERE kt_ma = @ma";

                using (SqlConnection conn = new SqlConnection(connStr))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ma", txtMaKhenThuong.Text);
                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Xóa thành công!");
                        LoadKhenThuong();
                    }
                    else MessageBox.Show("Xóa thất bại!");
                }
            }
        }

        private void btnThemKyLuat_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO KyLuat (kl_ma, nv_ma, kl_ten, ngaykyluat, kl_lydo, kl_sotien) " +
                           "VALUES (@ma, @nv, @ten, @ngay, @lydo, @sotien)";

            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@ma", txtMaKyLuat.Text);
                cmd.Parameters.AddWithValue("@nv", cbxTenNhanVienKL.SelectedValue);
                cmd.Parameters.AddWithValue("@ten", txtTenKyLuat.Text);
                cmd.Parameters.AddWithValue("@ngay", dtpNgayKyLuat.Value);
                cmd.Parameters.AddWithValue("@lydo", txtLyDoKyLuat.Text);
                cmd.Parameters.AddWithValue("@sotien", txtSoTienKyLuat.Text);

                conn.Open();
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Thêm kỷ luật thành công!");
                    LoadKyLuat();
                }
                else MessageBox.Show("Thêm thất bại!");
            }
        }

        private void dtgKyLuat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtgKyLuat.Rows[e.RowIndex];
                txtMaKyLuat.Text = row.Cells[0].Value.ToString();
                cbxTenNhanVienKL.Text = row.Cells[1].Value.ToString();
                txtTenKyLuat.Text = row.Cells[2].Value.ToString();
                dtpNgayKyLuat.Value = Convert.ToDateTime(row.Cells[3].Value);
                txtLyDoKyLuat.Text = row.Cells[4].Value.ToString();
                txtSoTienKyLuat.Text = row.Cells[5].Value.ToString();
            }
        }

        private void btnSuaKyLuat_Click(object sender, EventArgs e)
        {
            string query = "UPDATE KyLuat SET nv_ma = @nv, kl_ten = @ten, ngaykyluat = @ngay, kl_lydo = @lydo, kl_sotien = @sotien WHERE kl_ma = @ma";

            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@ma", txtMaKyLuat.Text);
                cmd.Parameters.AddWithValue("@nv", cbxTenNhanVienKL.SelectedValue);
                cmd.Parameters.AddWithValue("@ten", txtTenKyLuat.Text);
                cmd.Parameters.AddWithValue("@ngay", dtpNgayKyLuat.Value);
                cmd.Parameters.AddWithValue("@lydo", txtLyDoKyLuat.Text);
                cmd.Parameters.AddWithValue("@sotien", txtSoTienKyLuat.Text);

                conn.Open();
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Sửa kỷ luật thành công!");
                    LoadKyLuat();
                }
                else MessageBox.Show("Sửa thất bại!");
            }
        }

        private void btnXoaKyLuat_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Xác nhận", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                string query = "DELETE FROM KyLuat WHERE kl_ma = @ma";

                using (SqlConnection conn = new SqlConnection(connStr))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ma", txtMaKyLuat.Text);
                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Xóa thành công!");
                        LoadKyLuat();
                    }
                    else MessageBox.Show("Xóa thất bại!");
                }
            }
        }

        private void ResetValues()
        {
            txtMaKhenThuong.Text = "";
            txtTenKhenThuong.Text = "";
            cbxTenNhanVien.Text = "";
            txtLyDo.Text = "";
            txtSoTien.Text = "";
            txtMaKyLuat.Text = "";
            txtTenKyLuat.Text = "";
            cbxTenNhanVienKL.Text = "";
            txtLyDoKyLuat.Text = "";
            txtSoTienKyLuat.Text = "";
        }


        private void frmKhenThuongVaKyLuat_Load(object sender, EventArgs e)
        {
            ResetValues();
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            txtMaKhenThuong.Text = "";
            txtTenKhenThuong.Text = "";
            cbxTenNhanVien.Text = "";
            txtLyDo.Text = "";
            txtSoTien.Text = "";
        }

        private void btnBoQuaKL_Click(object sender, EventArgs e)
        {
            txtMaKyLuat.Text = "";
            txtTenKyLuat.Text = "";
            cbxTenNhanVienKL.Text = "";
            txtLyDoKyLuat.Text = "";
            txtSoTienKyLuat.Text = "";
        }
    }
}
