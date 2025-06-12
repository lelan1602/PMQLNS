using PMQLNS.NhanVien;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMQLNS
{
    public partial class frmDangNhap : Form
    {
        string connStr = ConfigurationManager.ConnectionStrings["QLNSConnectionString"].ConnectionString;
        public string QuyenHan { get; private set; }
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);

                StringBuilder builder = new StringBuilder();
                foreach (byte b in hash)
                {
                    builder.Append(b.ToString("x2"));
                }

                return builder.ToString();
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string tenDN = txtTenDangNhap.Text.Trim();
            string matKhau = txtMatKhau.Text;

            if (string.IsNullOrEmpty(tenDN) || string.IsNullOrEmpty(matKhau))
            {
                lblThongBao.Visible = true;
                lblThongBao.Text = "Vui lòng nhập đầy đủ thông tin.";
                return;
            }

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                // 1. Kiểm tra xem có tài khoản nào trong bảng chưa
                string checkExistQuery = "SELECT COUNT(*) FROM TaiKhoan";
                SqlCommand checkCmd = new SqlCommand(checkExistQuery, conn);
                int count = (int)checkCmd.ExecuteScalar();

                // 2. Nếu chưa có tài khoản nào => Cho phép dùng tài khoản mặc định 'quyen/quyen'
                if (count == 0)
                {
                    if (tenDN == "quyen" && matKhau == "quyen")
                    {
                        MessageBox.Show("Đăng nhập bằng tài khoản mặc định Admin.", "Thông báo");
                        this.Hide();
                        frmMain frm = new frmMain(); // form quản lý chính
                        frm.ShowDialog();
                        this.Close();
                        return;
                    }
                    else
                    {
                        lblThongBao.Visible = true;
                        lblThongBao.Text = "Sai tài khoản mặc định.";
                        return;
                    }
                }

                // 3. Nếu có tài khoản trong DB rồi => xử lý như cũ
                string hashMK = HashPassword(matKhau);
                string query = @"
SELECT tk_ma, tk_quyenhan, tk_trangthai 
FROM TaiKhoan 
WHERE tk_tendn = @tendn AND tk_matkhau = @matkhau";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@tendn", tenDN);
                    cmd.Parameters.AddWithValue("@matkhau", hashMK);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        string quyenHan = reader["tk_quyenhan"].ToString();
                        string trangThai = reader["tk_trangthai"].ToString();

                        if (trangThai == "Khong Hoat Dong")
                        {
                            lblThongBao.Visible = true;
                            lblThongBao.Text = "Tài khoản không còn hoạt động";
                            return;
                        }

                        this.Hide();
                        if (quyenHan == "Admin")
                        {
                            frmMain frm = new frmMain();
                            frm.ShowDialog();
                            this.Close();
                        }
                        else if (quyenHan == "Nhân viên")
                        {
                            frmTTNhanVien frm = new frmTTNhanVien(tenDN);
                            frm.ShowDialog();
                            this.Close();
                        }
                        else
                        {
                            lblThongBao.Visible = true;
                            MessageBox.Show("Quyền hạn không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Show();
                        }
                    }
                    else
                    {
                        lblThongBao.Visible = true;
                        lblThongBao.Text = "Sai tên đăng nhập hoặc mật khẩu.";
                    }

                    reader.Close();
                }
            }
        }
    }
}
