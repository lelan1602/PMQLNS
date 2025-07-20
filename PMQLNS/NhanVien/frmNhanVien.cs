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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMQLNS.NhanVien
{
    public partial class frmNhanVien : Form
    {
        string connStr = ConfigurationManager.ConnectionStrings["QLNSConnectionString"].ConnectionString;
        public frmNhanVien()
        {
            InitializeComponent();
            LoadNhanVien();
        }
        private void LoadNhanVien()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();

                    string query = @"
                SELECT 
                    nv.nv_ma,
                    nv.nv_ten,
                    nv.nv_email,
                    nv.nv_diachi,
                    nv.nv_sdt,
                    nv.nv_gioitinh,
                    nv.nv_nsinh,
                    nv.hesoluong,
                    nv.pb_ma,
                    nv.tk_ma,
                    tk.tk_quyenhan,
                    tk.tk_trangthai,
                    ct.trangthai,
                    cv.cv_ma,
                    ct.ngayapdung, ct.ngayhethan
                FROM NhanVien nv
                LEFT JOIN TaiKhoan tk ON nv.tk_ma = tk.tk_ma
                Left join ChiTietChucVu ct ON nv.nv_ma = ct.nv_ma
                Left join ChucVu cv On ct.cv_ma = cv.cv_ma where nv.pb_ma = 'PB001'
            ";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dtgNhanVien.DataSource = dt;

                    // Gán lại tiêu đề cột và chỉnh độ rộng
                    dtgNhanVien.Columns["nv_ma"].HeaderText = "Mã nhân viên";
                    dtgNhanVien.Columns["nv_ten"].HeaderText = "Họ tên";
                    dtgNhanVien.Columns["nv_email"].HeaderText = "Email";
                    dtgNhanVien.Columns["nv_diachi"].HeaderText = "Địa chỉ";
                    dtgNhanVien.Columns["nv_sdt"].HeaderText = "SĐT";
                    dtgNhanVien.Columns["nv_gioitinh"].HeaderText = "Giới tính";
                    dtgNhanVien.Columns["nv_nsinh"].HeaderText = "Ngày sinh";
                    dtgNhanVien.Columns["hesoluong"].HeaderText = "Hệ số lương";
                    dtgNhanVien.Columns["pb_ma"].HeaderText = "Mã phòng ban";
                    dtgNhanVien.Columns["tk_ma"].HeaderText = "Mã tài khoản";
                    dtgNhanVien.Columns["tk_quyenhan"].HeaderText = "Quyền hạn";
                    dtgNhanVien.Columns["tk_trangthai"].HeaderText = "Trạng thái";
                    dtgNhanVien.Columns["trangthai"].HeaderText = "Trạng thái chức vụ";
                    dtgNhanVien.Columns["cv_ma"].HeaderText = "Mã chức vụ";
                    dtgNhanVien.Columns["ngayapdung"].HeaderText = "Ngày áp dụng";
                    dtgNhanVien.Columns["ngayhethan"].HeaderText = "Ngày hết hạn";

                    foreach (DataGridViewColumn col in dtgNhanVien.Columns)
                    {
                        col.Width = 148;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi load dữ liệu nhân viên: " + ex.Message);
                }
            }
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            LoadPhongBan();
            LoadQuyenHan();
            LoadTrangThai();
            LoadChucVu();
        }

        private void LoadChucVu()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT cv_ma, cv_ten FROM ChucVu";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cboChucVu.DataSource = dt;
                cboChucVu.DisplayMember = "cv_ten";
                cboChucVu.ValueMember = "cv_ma";
            }

            cbxTrangThaiCV.Items.Clear();
            cbxTrangThaiCV.Items.Add("Dam nhiem");
            cbxTrangThaiCV.Items.Add("Khong dam nhiem");
            cbxTrangThaiCV.SelectedIndex = 0; 
        }


        private void LoadPhongBan()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT pb_ma, pb_ten FROM PhongBan";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cbxPhongBan.DataSource = dt;
                cbxPhongBan.DisplayMember = "pb_ten";
                cbxPhongBan.ValueMember = "pb_ma";
            }
        }
        private void LoadQuyenHan()
        {
            cbxQuyenHan.Items.Clear();
            cbxQuyenHan.Items.Add("Admin");
            cbxQuyenHan.Items.Add("Nhân viên");
            cbxQuyenHan.SelectedIndex = 0;
        }

        private void LoadTrangThai()
        {
            cbxTrangThai.Items.Clear();
            cbxTrangThai.Items.Add("Hoat Dong");
            cbxTrangThai.Items.Add("Khong Hoat Dong");
            cbxTrangThai.SelectedIndex = 0;
        }
        private void dtgNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtgNhanVien.Rows[e.RowIndex];

                txtMaNhanVien.Text = row.Cells["nv_ma"].Value?.ToString() ?? "";
                txtTenNhanVien.Text = row.Cells["nv_ten"].Value?.ToString() ?? "";
                txtEmail.Text = row.Cells["nv_email"].Value?.ToString() ?? "";
                txtDiaChi.Text = row.Cells["nv_diachi"].Value?.ToString() ?? "";
                txtSDT.Text = row.Cells["nv_sdt"].Value?.ToString() ?? "";
                txtHeSoLuong.Text = row.Cells["hesoluong"].Value?.ToString() ?? "";

                if (DateTime.TryParse(row.Cells["nv_nsinh"].Value?.ToString(), out DateTime ns))
                {
                    dtpNgaySinh.Value = ns;
                }
                else
                {
                    dtpNgaySinh.Value = DateTime.Now; // Giá trị mặc định nếu NULL
                }

                string gioitinh = row.Cells["nv_gioitinh"].Value?.ToString() ?? "";
                if (gioitinh == "Nam") radNam.Checked = true;
                else if (gioitinh == "Nữ") radNu.Checked = true;
                else radKhac.Checked = true;

                string maPB = row.Cells["pb_ma"].Value?.ToString() ?? "";
                if (!string.IsNullOrEmpty(maPB))
                {
                    cbxPhongBan.SelectedValue = maPB;
                }

                cbxTrangThai.SelectedItem = row.Cells["tk_trangthai"].Value?.ToString() ?? "";
                cbxQuyenHan.SelectedItem = row.Cells["tk_quyenhan"].Value?.ToString() ?? "";
                cbxTrangThaiCV.SelectedItem = row.Cells["trangthai"].Value?.ToString() ?? "";

                // Kiểm tra và xử lý giá trị NULL cho ngày áp dụng và ngày hết hạn
                if (row.Cells["ngayapdung"].Value != DBNull.Value && DateTime.TryParse(row.Cells["ngayapdung"].Value?.ToString(), out DateTime ngayApDung))
                {
                    dtpNgayApDung.Value = ngayApDung;
                }
                else
                {
                    dtpNgayApDung.Value = DateTime.Now; // Giá trị mặc định nếu NULL
                }

                if (row.Cells["ngayhethan"].Value != DBNull.Value && DateTime.TryParse(row.Cells["ngayhethan"].Value?.ToString(), out DateTime ngayHetHan))
                {
                    dtpNgayHetHan.Value = ngayHetHan;
                }
                else
                {
                    dtpNgayHetHan.Value = DateTime.Now; // Giá trị mặc định nếu NULL
                }

                string maCV = row.Cells["cv_ma"].Value?.ToString() ?? "";
                if (!string.IsNullOrEmpty(maCV))
                {
                    cboChucVu.SelectedValue = maCV;
                }
            }
        }


        private string GenerateRandomMaTK()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();
            return new string(Enumerable.Repeat(chars, 10)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string manv = txtMaNhanVien.Text.Trim();
            string tennv = txtTenNhanVien.Text.Trim();
            string email = txtEmail.Text.Trim();
            string diachi = txtDiaChi.Text.Trim();
            string sdt = txtSDT.Text.Trim();
            string hesoluongStr = txtHeSoLuong.Text.Trim();
            string tendn = txtTenDangNhap.Text.Trim();
            string matkhau = txtMatKhau.Text.Trim();
            string gioitinh = radNam.Checked ? "Nam" : radNu.Checked ? "Nữ" : "Khác";
            DateTime ngaysinh = dtpNgaySinh.Value;
            string trangthai = cbxTrangThai.SelectedItem?.ToString();
            string quyenhan = cbxQuyenHan.SelectedItem?.ToString();
            string mapb = cbxPhongBan.SelectedValue?.ToString();
            string chucvu = Convert.ToString(cboChucVu.SelectedValue);
            string trangthaiCV = cbxTrangThaiCV.SelectedItem?.ToString();
            DateTime ngayApDung = dtpNgayApDung.Value;
            DateTime ngayHetHan = dtpNgayHetHan.Value;


            Regex regexMa = new Regex(@"^[a-zA-Z0-9]{1,10}$");
            Regex regexTen = new Regex(@"^[a-zA-ZÀ-ỹ\s]{1,100}$");
            Regex regexSDT = new Regex(@"^\d+$");

            if (!regexMa.IsMatch(manv))
            {
                MessageBox.Show("Mã nhân viên không hợp lệ!");
                return;
            }

            if (!regexTen.IsMatch(tennv))
            {
                MessageBox.Show("Tên nhân viên không hợp lệ!");
                return;
            }

            if (!float.TryParse(hesoluongStr, out float hesoluong) || hesoluong <= 0)
            {
                MessageBox.Show("Hệ số lương phải là số dương!");
                return;
            }

            if (!regexSDT.IsMatch(sdt))
            {
                MessageBox.Show("Số điện thoại không hợp lệ!");
                return;
            }

            string matk = GenerateRandomMaTK();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    // Kiểm tra mã nhân viên đã tồn tại chưa
                    string checkMaNV = "SELECT COUNT(*) FROM NhanVien WHERE nv_ma = @ma";
                    SqlCommand cmdCheck = new SqlCommand(checkMaNV, conn);
                    cmdCheck.Parameters.AddWithValue("@ma", manv);
                    int countNV = (int)cmdCheck.ExecuteScalar();
                    if (countNV > 0)
                    {
                        MessageBox.Show("Mã nhân viên đã tồn tại. Vui lòng nhập mã khác!");
                        return;
                    }

                    // Kiểm tra email đã tồn tại chưa
                    string checkEmail = "SELECT COUNT(*) FROM NhanVien WHERE nv_email = @email";
                    SqlCommand cmdCheckEmail = new SqlCommand(checkEmail, conn);
                    cmdCheckEmail.Parameters.AddWithValue("@email", email);
                    int countEmail = (int)cmdCheckEmail.ExecuteScalar();
                    if (countEmail > 0)
                    {
                        MessageBox.Show("Email đã tồn tại. Vui lòng nhập email khác!");
                        return;
                    }

                    // Kiểm tra số điện thoại đã tồn tại chưa
                    string checkSDT = "SELECT COUNT(*) FROM NhanVien WHERE nv_sdt = @sdt";
                    SqlCommand cmdCheckSDT = new SqlCommand(checkSDT, conn);
                    cmdCheckSDT.Parameters.AddWithValue("@sdt", sdt);
                    int countSDT = (int)cmdCheckSDT.ExecuteScalar();
                    if (countSDT > 0)
                    {
                        MessageBox.Show("Số điện thoại đã tồn tại. Vui lòng nhập số khác!");
                        return;
                    }

                    // Kiểm tra tên đăng nhập đã tồn tại chưa (nếu cần)
                    string checkTenDN = "SELECT COUNT(*) FROM TaiKhoan WHERE tk_tendn = @tendn";
                    SqlCommand cmdCheckTenDN = new SqlCommand(checkTenDN, conn);
                    cmdCheckTenDN.Parameters.AddWithValue("@tendn", tendn);
                    int countDN = (int)cmdCheckTenDN.ExecuteScalar();
                    if (countDN > 0)
                    {
                        MessageBox.Show("Tên đăng nhập đã tồn tại. Vui lòng chọn tên khác!");
                        return;
                    }


                    // 1. Thêm tài khoản
                    matkhau = HashPassword(matkhau);
                    string insertTK = @"INSERT INTO TaiKhoan (tk_ma, tk_tendn, tk_matkhau, tk_quyenhan, tk_trangthai)
                                VALUES (@tk_ma, @tendn, @matkhau, @quyenhan, @trangthai)";
                    SqlCommand cmdTK = new SqlCommand(insertTK, conn);
                    cmdTK.Parameters.AddWithValue("@tk_ma", matk);
                    cmdTK.Parameters.AddWithValue("@tendn", tendn);
                    cmdTK.Parameters.AddWithValue("@matkhau", matkhau);
                    cmdTK.Parameters.AddWithValue("@quyenhan", quyenhan);
                    cmdTK.Parameters.AddWithValue("@trangthai", trangthai);
                    cmdTK.ExecuteNonQuery();

                    // 2. Thêm nhân viên
                    string insertNV = @"INSERT INTO NhanVien (nv_ma, pb_ma, tk_ma, nv_ten, nv_nsinh, nv_gioitinh, nv_email, nv_diachi, nv_sdt, hesoluong)
                                VALUES (@nv_ma, @pb_ma, @tk_ma, @nv_ten, @nv_nsinh, @nv_gioitinh, @nv_email, @nv_diachi, @nv_sdt, @hesoluong)";
                    SqlCommand cmdNV = new SqlCommand(insertNV, conn);
                    cmdNV.Parameters.AddWithValue("@nv_ma", manv);
                    cmdNV.Parameters.AddWithValue("@pb_ma", mapb);
                    cmdNV.Parameters.AddWithValue("@tk_ma", matk);
                    cmdNV.Parameters.AddWithValue("@nv_ten", tennv);
                    cmdNV.Parameters.AddWithValue("@nv_nsinh", ngaysinh);
                    cmdNV.Parameters.AddWithValue("@nv_gioitinh", gioitinh);
                    cmdNV.Parameters.AddWithValue("@nv_email", email);
                    cmdNV.Parameters.AddWithValue("@nv_diachi", diachi);
                    cmdNV.Parameters.AddWithValue("@nv_sdt", sdt);
                    cmdNV.Parameters.AddWithValue("@hesoluong", hesoluong);
                    cmdNV.ExecuteNonQuery();

                    // 3. Thêm chi tiết chức vụ
                    string insertCTCV = @"INSERT INTO ChiTietChucVu (cv_ma, nv_ma, ngayapdung, ngayhethan, trangthai)
                                  VALUES (@cv_ma, @nv_ma, @ngayapdung, @ngayhethan, @trangthai)";
                    SqlCommand cmdCTCV = new SqlCommand(insertCTCV, conn);
                    cmdCTCV.Parameters.AddWithValue("@cv_ma", chucvu);
                    cmdCTCV.Parameters.AddWithValue("@nv_ma", manv);
                    cmdCTCV.Parameters.AddWithValue("@ngayapdung", ngayApDung);
                    cmdCTCV.Parameters.AddWithValue("@ngayhethan", ngayHetHan);
                    cmdCTCV.Parameters.AddWithValue("@trangthai", trangthaiCV);
                    cmdCTCV.ExecuteNonQuery();

                    MessageBox.Show("Thêm nhân viên thành công!");
                    LoadNhanVien();
                    ClearTextboxes();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi thêm nhân viên: " + ex.Message);
                }
            }
        }

        private void ClearTextboxes()
        {
            txtMaNhanVien.Clear();
            txtTenNhanVien.Clear();
            txtEmail.Clear();
            txtDiaChi.Clear();
            txtSDT.Clear();
            txtHeSoLuong.Clear();
            txtTenDangNhap.Clear();
            txtMatKhau.Clear();

            radNam.Checked = true; // Mặc định giới tính Nam
            dtpNgaySinh.Value = DateTime.Now;

            cbxTrangThai.SelectedIndex = 0;
            cbxQuyenHan.SelectedIndex = 0;
            if (cbxPhongBan.Items.Count > 0)
                cbxPhongBan.SelectedIndex = 0;
        }
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);

                StringBuilder builder = new StringBuilder();
                foreach (byte b in hash)
                {
                    builder.Append(b.ToString("x2")); // chuyển sang dạng hex
                }

                return builder.ToString();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string manv = txtMaNhanVien.Text.Trim();
            string tennv = txtTenNhanVien.Text.Trim();
            string email = txtEmail.Text.Trim();
            string diachi = txtDiaChi.Text.Trim();
            string sdt = txtSDT.Text.Trim();
            string hesoluongStr = txtHeSoLuong.Text.Trim();
            string tendn = txtTenDangNhap.Text.Trim();
            string matkhauGoc = txtMatKhau.Text.Trim(); // mật khẩu gốc chưa mã hóa
            string gioitinh = radNam.Checked ? "Nam" : radNu.Checked ? "Nữ" : "Khác";
            DateTime ngaysinh = dtpNgaySinh.Value;
            string trangthai = cbxTrangThai.SelectedItem?.ToString();
            string quyenhan = cbxQuyenHan.SelectedItem?.ToString();
            string mapb = cbxPhongBan.SelectedValue?.ToString();
            string macv = cboChucVu.SelectedValue?.ToString();

            // Validate
            Regex regexTen = new Regex(@"^[a-zA-ZÀ-ỹ\s]{1,100}$");
            Regex regexSDT = new Regex(@"^\d+$");

            if (!regexTen.IsMatch(tennv))
            {
                MessageBox.Show("Tên nhân viên không hợp lệ!");
                return;
            }

            if (!float.TryParse(hesoluongStr, out float hesoluong) || hesoluong <= 0)
            {
                MessageBox.Show("Hệ số lương phải là số dương!");
                return;
            }

            if (!regexSDT.IsMatch(sdt))
            {
                MessageBox.Show("Số điện thoại không hợp lệ!");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();

                    // 1. Cập nhật bảng NhanVien
                    string updateNV = @"UPDATE NhanVien SET 
                                    pb_ma = @pb_ma, 
                                    nv_ten = @nv_ten, 
                                    nv_nsinh = @nv_nsinh, 
                                    nv_gioitinh = @nv_gioitinh, 
                                    nv_email = @nv_email, 
                                    nv_diachi = @nv_diachi, 
                                    nv_sdt = @nv_sdt, 
                                    hesoluong = @hesoluong
                                WHERE nv_ma = @nv_ma";

                    SqlCommand cmdNV = new SqlCommand(updateNV, conn);
                    cmdNV.Parameters.AddWithValue("@pb_ma", mapb);
                    cmdNV.Parameters.AddWithValue("@nv_ten", tennv);
                    cmdNV.Parameters.AddWithValue("@nv_nsinh", ngaysinh);
                    cmdNV.Parameters.AddWithValue("@nv_gioitinh", gioitinh);
                    cmdNV.Parameters.AddWithValue("@nv_email", email);
                    cmdNV.Parameters.AddWithValue("@nv_diachi", diachi);
                    cmdNV.Parameters.AddWithValue("@nv_sdt", sdt);
                    cmdNV.Parameters.AddWithValue("@hesoluong", hesoluong);
                    cmdNV.Parameters.AddWithValue("@nv_ma", manv);
                    cmdNV.ExecuteNonQuery();

                    // 2. Lấy mã tài khoản từ nhân viên
                    string matk = "";
                    string query = "SELECT tk_ma FROM NhanVien WHERE nv_ma = @nv_ma";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nv_ma", manv);
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            matk = result.ToString();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy mã tài khoản tương ứng!");
                            return;
                        }
                    }

                    // 3. Nếu tên đăng nhập và mật khẩu KHÔNG rỗng thì cập nhật tài khoản
                    if (!string.IsNullOrEmpty(tendn) && !string.IsNullOrEmpty(matkhauGoc))
                    {
                        string matkhau = HashPassword(matkhauGoc);
                        string updateTK = @"UPDATE TaiKhoan SET 
                                        tk_tendn = @tendn, 
                                        tk_matkhau = @matkhau, 
                                        tk_quyenhan = @quyenhan, 
                                        tk_trangthai = @trangthai 
                                    WHERE tk_ma = @tk_ma";
                        SqlCommand cmdTK = new SqlCommand(updateTK, conn);
                        cmdTK.Parameters.AddWithValue("@tendn", tendn);
                        cmdTK.Parameters.AddWithValue("@matkhau", matkhau);
                        cmdTK.Parameters.AddWithValue("@quyenhan", quyenhan);
                        cmdTK.Parameters.AddWithValue("@trangthai", trangthai);
                        cmdTK.Parameters.AddWithValue("@tk_ma", matk);
                        cmdTK.ExecuteNonQuery();
                    }
                    else
                    {
                        // Chỉ update quyền hạn và trạng thái nếu không sửa tên đăng nhập và mật khẩu
                        string updateTK = @"UPDATE TaiKhoan SET 
                                        tk_quyenhan = @quyenhan, 
                                        tk_trangthai = @trangthai 
                                    WHERE tk_ma = @tk_ma";
                        SqlCommand cmdTK = new SqlCommand(updateTK, conn);
                        cmdTK.Parameters.AddWithValue("@quyenhan", quyenhan);
                        cmdTK.Parameters.AddWithValue("@trangthai", trangthai);
                        cmdTK.Parameters.AddWithValue("@tk_ma", matk);
                        cmdTK.ExecuteNonQuery();
                    }

                    DateTime ngayApDung = dtpNgayApDung.Value;
                    DateTime ngayHetHan = dtpNgayHetHan.Value;
                    string trangthaiCV = cbxTrangThaiCV.SelectedItem?.ToString();

                    string updateCV = @"UPDATE ChiTietChucVu SET 
                        cv_ma = @cv_ma,
                        ngayapdung = @ngayapdung,
                        ngayhethan = @ngayhethan,
                        trangthai = @trangthai
                   WHERE nv_ma = @nv_ma";

                    SqlCommand cmdCV = new SqlCommand(updateCV, conn);
                    cmdCV.Parameters.AddWithValue("@cv_ma", macv);
                    cmdCV.Parameters.AddWithValue("@ngayapdung", ngayApDung);
                    cmdCV.Parameters.AddWithValue("@ngayhethan", ngayHetHan);
                    cmdCV.Parameters.AddWithValue("@trangthai", trangthaiCV);
                    cmdCV.Parameters.AddWithValue("@nv_ma", manv);
                    cmdCV.ExecuteNonQuery();


                    MessageBox.Show("Cập nhật nhân viên thành công!");
                    LoadNhanVien();
                    ClearTextboxes();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi cập nhật nhân viên: " + ex.Message);
                }
            }
        }

        private void btnXoaNhanVien_Click(object sender, EventArgs e)
        {
            string manv = txtMaNhanVien.Text.Trim();

            if (string.IsNullOrEmpty(manv))
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa.");
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    try
                    {
                        conn.Open();

                        // 1. Xoá tất cả các bảng liên kết với nhân viên
                        List<string> relatedDeleteQueries = new List<string>
                {
                    "DELETE FROM CongViec WHERE nv_ma = @nv_ma",
                    "DELETE FROM KhenThuong WHERE nv_ma = @nv_ma",
                    "DELETE FROM ChiTietChucVu WHERE nv_ma = @nv_ma",
                    "DELETE FROM KyLuat WHERE nv_ma = @nv_ma",
                    "DELETE FROM BangLuong WHERE nv_ma = @nv_ma",
                    "DELETE FROM ChiTietPhuCap WHERE nv_ma = @nv_ma",
                    "DELETE FROM BaoHiem WHERE nv_ma = @nv_ma",
                    "DELETE FROM BangCap WHERE nv_ma = @nv_ma"
                };

                        foreach (var query in relatedDeleteQueries)
                        {
                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@nv_ma", manv);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        // 2. Xoá nhân viên
                        string deleteNhanVienQuery = "DELETE FROM NhanVien WHERE nv_ma = @nv_ma";
                        using (SqlCommand cmdNhanVien = new SqlCommand(deleteNhanVienQuery, conn))
                        {
                            cmdNhanVien.Parameters.AddWithValue("@nv_ma", manv);
                            cmdNhanVien.ExecuteNonQuery();
                        }

                        // 3. Xoá tài khoản (sau khi nhân viên đã xoá)
                        string deleteTaiKhoanQuery = @"
                    DELETE FROM TaiKhoan 
                    WHERE tk_ma NOT IN (SELECT tk_ma FROM NhanVien WHERE tk_ma IS NOT NULL)";
                        using (SqlCommand cmdTaiKhoan = new SqlCommand(deleteTaiKhoanQuery, conn))
                        {
                            cmdTaiKhoan.ExecuteNonQuery();
                        }

                        MessageBox.Show("Xóa nhân viên thành công!");
                        LoadNhanVien();
                        ClearNhanVienInputs();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa nhân viên: " + ex.Message);
                    }
                }
            }
        }


        private void ClearNhanVienInputs()
        {
            txtMaNhanVien.Clear();
            txtTenNhanVien.Clear();
            txtEmail.Clear();
            txtDiaChi.Clear();
            txtSDT.Clear();
            txtHeSoLuong.Clear();
            dtpNgaySinh.Value = DateTime.Now;
            radNam.Checked = true;
            cbxPhongBan.SelectedIndex = -1;
            cbxTrangThai.SelectedIndex = -1;
        }

    }
}
