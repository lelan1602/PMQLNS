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
    public partial class frmBaoHiem : Form
    {
        string connStr = ConfigurationManager.ConnectionStrings["QLNSConnectionString"].ConnectionString;

        public frmBaoHiem()
        {
            InitializeComponent();
            LoadLoaiBaoHiem();
            LoadBaoHiem();
            LoadLoaiBaoHiemToComboBox();
            LoadNhanVienToComboBox();
        }
        private void LoadNhanVienToComboBox()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT nv_ma, nv_ten FROM NhanVien";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cbxTenNhanVien.DataSource = dt;
                cbxTenNhanVien.DisplayMember = "nv_ten";
                cbxTenNhanVien.ValueMember = "nv_ma";
            }
        }
        private void LoadLoaiBaoHiemToComboBox()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT lbh_ma, lbh_ten FROM LoaiBaoHiem";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cbxLoaiBaoHiem.DataSource = dt;
                cbxLoaiBaoHiem.DisplayMember = "lbh_ten";
                cbxLoaiBaoHiem.ValueMember = "lbh_ma";
            }
        }

        private void LoadBaoHiem()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = @"SELECT bh.bh_ma, lb.lbh_ten, nv.nv_ten, bh.bh_ten, bh.bh_sotien
                         FROM BaoHiem bh
                         JOIN LoaiBaoHiem lb ON bh.lbh_ma = lb.lbh_ma
                         JOIN NhanVien nv ON bh.nv_ma = nv.nv_ma";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dtgBaoHiem.DataSource = dt;

                // Tùy chỉnh header tiếng Việt
                dtgBaoHiem.Columns[0].HeaderText = "Mã BH";
                dtgBaoHiem.Columns[1].HeaderText = "Loại bảo hiểm";
                dtgBaoHiem.Columns[2].HeaderText = "Nhân viên";
                dtgBaoHiem.Columns[3].HeaderText = "Tên bảo hiểm";
                dtgBaoHiem.Columns[4].HeaderText = "Số tiền";
                foreach (DataGridViewColumn col in dtgBaoHiem.Columns)
                {
                    col.Width = 728/5 - 5;
                }
            }
        }

        private void LoadLoaiBaoHiem()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT * FROM LoaiBaoHiem";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dtgLoaiBaoHiem.DataSource = dt;
                foreach (DataGridViewColumn col in dtgLoaiBaoHiem.Columns)
                {
                    col.Width = 407/2 - 5;
                }
            }
        }

        private void dtgLoaiBaoHiem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtgLoaiBaoHiem.Rows[e.RowIndex];
                txtMaLoaiBaoHiem.Text = row.Cells["lbh_ma"].Value.ToString();
                txtTenLoaiBaoHiem.Text = row.Cells["lbh_ten"].Value.ToString();
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaLoaiBaoHiem.Text) || string.IsNullOrWhiteSpace(txtTenLoaiBaoHiem.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            string query = "INSERT INTO LoaiBaoHiem (lbh_ma, lbh_ten) VALUES (@ma, @ten)";

            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@ma", txtMaLoaiBaoHiem.Text);
                cmd.Parameters.AddWithValue("@ten", txtTenLoaiBaoHiem.Text.Trim());

                conn.Open();
                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show("Thêm thành công!");
                    LoadLoaiBaoHiem();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại!");
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaLoaiBaoHiem.Text) || string.IsNullOrWhiteSpace(txtTenLoaiBaoHiem.Text))
            {
                MessageBox.Show("Vui lòng chọn dòng để sửa!");
                return;
            }

            string query = "UPDATE LoaiBaoHiem SET lbh_ten = @ten WHERE lbh_ma = @ma";

            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@ma", txtMaLoaiBaoHiem.Text);
                cmd.Parameters.AddWithValue("@ten", txtTenLoaiBaoHiem.Text.Trim());

                conn.Open();
                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show("Cập nhật thành công!");
                    LoadLoaiBaoHiem();
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại!");
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaLoaiBaoHiem.Text))
            {
                MessageBox.Show("Vui lòng chọn dòng để xóa!");
                return;
            }

            DialogResult confirm = MessageBox.Show("Bạn có chắc muốn xóa loại bảo hiểm này?", "Xác nhận", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                string query = "DELETE FROM LoaiBaoHiem WHERE lbh_ma = @ma";

                using (SqlConnection conn = new SqlConnection(connStr))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ma", txtMaLoaiBaoHiem.Text);

                    conn.Open();
                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Xóa thành công!");
                        LoadLoaiBaoHiem();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại!");
                    }
                }
            }
        }

        private void dtgBaoHiem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtgBaoHiem.Rows[e.RowIndex];
                txtMaBaoHiem.Text = row.Cells[0].Value.ToString();
                cbxLoaiBaoHiem.Text = row.Cells[1].Value.ToString();
                cbxTenNhanVien.Text = row.Cells[2].Value.ToString();
                txtTenBaoHiem.Text = row.Cells[3].Value.ToString();
                txtSoTien.Text = row.Cells[4].Value.ToString();
            }
        }

        private void btnThemBaoHiem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenBaoHiem.Text) || string.IsNullOrWhiteSpace(txtSoTien.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            string query = "INSERT INTO BaoHiem (bh_ma, lbh_ma, nv_ma, bh_ten, bh_sotien) " +
                           "VALUES (@ma, @lbh, @nv, @ten, @sotien)";

            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@ma", txtMaBaoHiem.Text.Trim());
                cmd.Parameters.AddWithValue("@lbh", cbxLoaiBaoHiem.SelectedValue);
                cmd.Parameters.AddWithValue("@nv", cbxTenNhanVien.SelectedValue);
                cmd.Parameters.AddWithValue("@ten", txtTenBaoHiem.Text.Trim());
                cmd.Parameters.AddWithValue("@sotien", txtSoTien.Text.Trim());

                conn.Open();
                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show("Thêm bảo hiểm thành công!");
                    LoadBaoHiem();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại!");
                }
            }
        }

        private void btnSuaBaoHiem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaBaoHiem.Text))
            {
                MessageBox.Show("Vui lòng chọn một bảo hiểm để sửa!");
                return;
            }

            string query = "UPDATE BaoHiem SET lbh_ma = @lbh_ma, nv_ma = @nv_ma, bh_ten = @bh_ten, bh_sotien = @bh_sotien WHERE bh_ma = @bh_ma";

            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@bh_ma", txtMaBaoHiem.Text.Trim());
                cmd.Parameters.AddWithValue("@lbh_ma", cbxLoaiBaoHiem.SelectedValue);
                cmd.Parameters.AddWithValue("@nv_ma", cbxTenNhanVien.SelectedValue);
                cmd.Parameters.AddWithValue("@bh_ten", txtTenBaoHiem.Text.Trim());
                cmd.Parameters.AddWithValue("@bh_sotien", txtSoTien.Text.Trim());

                conn.Open();
                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show("Cập nhật bảo hiểm thành công!");
                    LoadBaoHiem(); // Gọi lại hàm load bảng
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại!");
                }
            }
        }

        private void btnXoaBaoHiem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaBaoHiem.Text))
            {
                MessageBox.Show("Vui lòng chọn bảo hiểm cần xóa!");
                return;
            }

            DialogResult dialog = MessageBox.Show("Bạn có chắc muốn xóa bảo hiểm này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialog != DialogResult.Yes)
                return;

            string query = "DELETE FROM BaoHiem WHERE bh_ma = @bh_ma";

            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@bh_ma", txtMaBaoHiem.Text.Trim());

                conn.Open();
                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show("Xóa bảo hiểm thành công!");
                    LoadBaoHiem(); // Gọi lại hàm load bảng
                }
                else
                {
                    MessageBox.Show("Xóa thất bại!");
                }
            }
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            txtMaLoaiBaoHiem.Text = "";
            txtTenLoaiBaoHiem.Text = "";
        }

        private void btnBoQuaBH_Click(object sender, EventArgs e)
        {
            txtMaBaoHiem.Text = "";
            cbxLoaiBaoHiem.Text = "";
            cbxTenNhanVien.Text = "";
            txtTenBaoHiem.Text = "";
            txtSoTien.Text = "";
        }

        private void frmBaoHiem_Load(object sender, EventArgs e)
        {

        }
    }
}
