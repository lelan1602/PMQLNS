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
    public partial class frmBangCap : Form
    {
        string connStr = ConfigurationManager.ConnectionStrings["QLNSConnectionString"].ConnectionString;

        public frmBangCap()
        {
            InitializeComponent();
            LoadBangCap();
            LoadNhanVien(); 
            LoadLoaiBangCap();
        }
        private void LoadLoaiBangCap()
        {
            cbxLoaiBangCap.Items.Clear();
            cbxLoaiBangCap.Items.Add("Dai Hoc");
            cbxLoaiBangCap.Items.Add("Cao Dang");
            cbxLoaiBangCap.SelectedIndex = 0; // chọn mặc định
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
        private void LoadBangCap()
        {
            string query = "SELECT bc_ma, nv_ma, bc_ten, bc_noicap, bc_loai FROM BangCap";

            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dtgBangCap.DataSource = dt;

                // Đặt tên tiếng Việt cho các cột
                dtgBangCap.Columns["bc_ma"].HeaderText = "Mã Bằng Cấp";
                dtgBangCap.Columns["nv_ma"].HeaderText = "Mã Nhân Viên";
                dtgBangCap.Columns["bc_ten"].HeaderText = "Tên Bằng Cấp";
                dtgBangCap.Columns["bc_noicap"].HeaderText = "Nơi Cấp";
                dtgBangCap.Columns["bc_loai"].HeaderText = "Loại Bằng Cấp";
                foreach (DataGridViewColumn col in dtgBangCap.Columns)
                {
                    col.Width = 717/5 - 5;
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (cbxTenNhanVien.SelectedValue == null || string.IsNullOrWhiteSpace(txtTenBangCap.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            string query = "INSERT INTO BangCap (bc_ma, nv_ma, bc_ten, bc_noicap, bc_loai) " +
                           "VALUES (@bc_ma, @nv_ma, @ten, @noicap, @loai)";

            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@bc_ma", txtMaBangCap.Text);
                cmd.Parameters.AddWithValue("@nv_ma", cbxTenNhanVien.SelectedValue);
                cmd.Parameters.AddWithValue("@ten", txtTenBangCap.Text.Trim());
                cmd.Parameters.AddWithValue("@noicap", txtNoiCap.Text.Trim());
                cmd.Parameters.AddWithValue("@loai", cbxLoaiBangCap.SelectedItem);

                conn.Open();
                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show("Thêm bằng cấp thành công!");
                    LoadBangCap(); // reload DataGridView
                }
                else
                {
                    MessageBox.Show("Thêm thất bại!");
                }
            }
        }

        private void dtgBangCap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtgBangCap.Rows[e.RowIndex];

                txtMaBangCap.Text = row.Cells["bc_ma"].Value.ToString();
                cbxTenNhanVien.SelectedValue = row.Cells["nv_ma"].Value;
                txtTenBangCap.Text = row.Cells["bc_ten"].Value.ToString();
                txtNoiCap.Text = row.Cells["bc_noicap"].Value.ToString();
                cbxLoaiBangCap.SelectedItem = row.Cells["bc_loai"].Value.ToString();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaBangCap.Text))
            {
                MessageBox.Show("Vui lòng chọn một bằng cấp để sửa!");
                return;
            }

            string query = "UPDATE BangCap SET nv_ma = @nv_ma, bc_ten = @ten, bc_noicap = @noicap, bc_loai = @loai " +
                           "WHERE bc_ma = @bc_ma";

            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@bc_ma", txtMaBangCap.Text);
                cmd.Parameters.AddWithValue("@nv_ma", cbxTenNhanVien.SelectedValue);
                cmd.Parameters.AddWithValue("@ten", txtTenBangCap.Text.Trim());
                cmd.Parameters.AddWithValue("@noicap", txtNoiCap.Text.Trim());
                cmd.Parameters.AddWithValue("@loai", cbxLoaiBangCap.SelectedItem);

                conn.Open();
                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show("Cập nhật bằng cấp thành công!");
                    LoadBangCap(); // Reload lại lưới
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại!");
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaBangCap.Text))
            {
                MessageBox.Show("Vui lòng chọn bằng cấp để xóa!");
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa bằng cấp này không?",
                                                  "Xác nhận",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                string query = "DELETE FROM BangCap WHERE bc_ma = @bc_ma";

                using (SqlConnection conn = new SqlConnection(connStr))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@bc_ma", txtMaBangCap.Text);

                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        MessageBox.Show("Xóa bằng cấp thành công!");
                        LoadBangCap(); // Reload lại DataGridView
                        ClearBangCapControls(); // Xóa dữ liệu trên các control
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại!");
                    }
                }
            }
        }
        private void ClearBangCapControls()
        {
            txtMaBangCap.Clear();
            txtTenBangCap.Clear();
            txtNoiCap.Clear();
            cbxLoaiBangCap.SelectedIndex = -1;
            cbxTenNhanVien.SelectedIndex = -1;
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            txtMaBangCap.Text = "";
            txtNoiCap.Text = "";
            txtTenBangCap.Text = "";
            cbxLoaiBangCap.Text = "";
            cbxTenNhanVien.Text = "";
        }
    }
}
