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
    public partial class frmPhuCap : Form
    {
        string connStr = ConfigurationManager.ConnectionStrings["QLNSConnectionString"].ConnectionString;

        public frmPhuCap()
        {
            InitializeComponent();
            LoadLoaiPhuCap();
            LoadPhuCap();
            LoadNhanVien();
            LoadChiTietPhuCap();
        }
        private void LoadChiTietPhuCap()
        {
            string query = @"
        SELECT lp.lpc_ten AS [Tên loại phụ cấp], nv.nv_ten AS [Tên nhân viên], pc_thoigian AS [Thời gian]
        FROM ChiTietPhuCap ct
        JOIN NhanVien nv ON ct.nv_ma = nv.nv_ma
        JOIN LoaiPhuCap lp ON ct.lpc_ma = lp.lpc_ma";

            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                dtgChiTietPhuCap.DataSource = dt;
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

        private void LoadPhuCap()
        {
            string query = "SELECT lpc_ma, lpc_ten FROM LoaiPhuCap";
            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                cbxTenLoaiPhuCap.DataSource = dt;
                cbxTenLoaiPhuCap.DisplayMember = "lpc_ten";
                cbxTenLoaiPhuCap.ValueMember = "lpc_ma";
            }
        }


        private void LoadLoaiPhuCap()
        {
            string query = "SELECT lpc_ma AS [Mã loại], lpc_ten AS [Tên loại phụ cấp], lpc_sotien AS [Số tiền] FROM LoaiPhuCap";

            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                dtgLoaiPhuCap.DataSource = dt;
                foreach (DataGridViewColumn col in dtgLoaiPhuCap.Columns)
                {
                    col.Width = 408/3 - 5;
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaLoaiPhuCap.Text) || string.IsNullOrWhiteSpace(txtTenLoaiPhuCap.Text) || string.IsNullOrWhiteSpace(txtSoTien.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            string query = "INSERT INTO LoaiPhuCap (lpc_ma, lpc_ten, lpc_sotien) VALUES (@ma, @ten, @sotien)";

            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@ma", txtMaLoaiPhuCap.Text.Trim());
                cmd.Parameters.AddWithValue("@ten", txtTenLoaiPhuCap.Text.Trim());
                cmd.Parameters.AddWithValue("@sotien", txtSoTien.Text.Trim());

                conn.Open();
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Thêm thành công!");
                    LoadLoaiPhuCap();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại!");
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaLoaiPhuCap.Text))
            {
                MessageBox.Show("Vui lòng chọn loại phụ cấp để sửa!");
                return;
            }

            string query = "UPDATE LoaiPhuCap SET lpc_ten = @ten, lpc_sotien = @sotien WHERE lpc_ma = @ma";

            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@ma", txtMaLoaiPhuCap.Text.Trim());
                cmd.Parameters.AddWithValue("@ten", txtTenLoaiPhuCap.Text.Trim());
                cmd.Parameters.AddWithValue("@sotien", txtSoTien.Text.Trim());

                conn.Open();
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Cập nhật thành công!");
                    LoadLoaiPhuCap();
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại!");
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaLoaiPhuCap.Text))
            {
                MessageBox.Show("Vui lòng chọn loại phụ cấp để xóa!");
                return;
            }

            DialogResult dialog = MessageBox.Show("Bạn chắc chắn muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialog != DialogResult.Yes) return;

            string query = "DELETE FROM LoaiPhuCap WHERE lpc_ma = @ma";

            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@ma", txtMaLoaiPhuCap.Text.Trim());

                conn.Open();
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Xóa thành công!");
                    LoadLoaiPhuCap();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại!");
                }
            }
        }

        private void dtgLoaiPhuCap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtgLoaiPhuCap.Rows[e.RowIndex];
                txtMaLoaiPhuCap.Text = row.Cells[0].Value.ToString();
                txtTenLoaiPhuCap.Text = row.Cells[1].Value.ToString();
                txtSoTien.Text = row.Cells[2].Value.ToString();
            }
        }

        private void btn_ThemPhuCap_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO ChiTietPhuCap (lpc_ma, nv_ma, pc_thoigian) VALUES (@lpc_ma, @nv_ma, @thoigian)";

            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@lpc_ma", cbxTenLoaiPhuCap.SelectedValue);
                cmd.Parameters.AddWithValue("@nv_ma", cbxTenNhanVien.SelectedValue);
                cmd.Parameters.AddWithValue("@thoigian", dtpThoiGian.Value);

                conn.Open();
                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show("Thêm thành công!");
                    LoadChiTietPhuCap();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại!");
                }
            }
        }

        private void btnSuaPhuCap_Click(object sender, EventArgs e)
        {
            string query = @"UPDATE ChiTietPhuCap 
                     SET pc_thoigian = @thoigian 
                     WHERE lpc_ma = @lpc_ma AND nv_ma = @nv_ma";

            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@lpc_ma", cbxTenLoaiPhuCap.SelectedValue);
                cmd.Parameters.AddWithValue("@nv_ma", cbxTenNhanVien.SelectedValue);
                cmd.Parameters.AddWithValue("@thoigian", dtpThoiGian.Value);

                conn.Open();
                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show("Sửa thành công!");
                    LoadChiTietPhuCap();
                }
                else
                {
                    MessageBox.Show("Sửa thất bại!");
                }
            }
        }

        private void btnXoaPhuCap_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Bạn chắc chắn muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialog != DialogResult.Yes) return;

            string query = "DELETE FROM ChiTietPhuCap WHERE lpc_ma = @lpc_ma AND nv_ma = @nv_ma";

            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@lpc_ma", cbxTenLoaiPhuCap.SelectedValue);
                cmd.Parameters.AddWithValue("@nv_ma", cbxTenNhanVien.SelectedValue);

                conn.Open();
                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show("Xóa thành công!");
                    LoadChiTietPhuCap();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại!");
                }
            }
        }

        private void dtgChiTietPhuCap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtgChiTietPhuCap.Rows[e.RowIndex];

                cbxTenLoaiPhuCap.Text = row.Cells[0].Value.ToString();
                cbxTenNhanVien.Text = row.Cells[1].Value.ToString();
                dtpThoiGian.Value = Convert.ToDateTime(row.Cells[2].Value);
            }
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            txtMaLoaiPhuCap.Text = "";
            txtTenLoaiPhuCap.Text = "";
            txtSoTien.Text = "";
        }

        private void btnBoQuaPC_Click(object sender, EventArgs e)
        {
            cbxTenLoaiPhuCap.Text = "";
            cbxTenNhanVien.Text = "";
        }

        private void frmPhuCap_Load(object sender, EventArgs e)
        {

        }
    }
}
