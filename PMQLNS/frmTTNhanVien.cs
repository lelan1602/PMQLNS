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
using OfficeOpenXml; 
using System.IO;

namespace PMQLNS
{
    public partial class frmTTNhanVien : Form
    {
        string connStr = ConfigurationManager.ConnectionStrings["QLNSConnectionString"].ConnectionString;

        private string tenDangNhap;
        public frmTTNhanVien(string TenDN)
        {
            InitializeComponent();
            tenDangNhap = TenDN;
            LoadThongTinNhanVien();
        }

        private void LoadThongTinNhanVien()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string query = @"
SELECT 
    nv.nv_ma, nv.nv_ten, pb.pb_ten, cv.cv_ten,
    nv.nv_nsinh, nv.nv_gioitinh, nv.nv_email, nv.nv_diachi, nv.nv_sdt, nv.hesoluong, bl.luongcoban, bl.tongkhenthuong,
    bl.tongkyluat, bl.tongphucap, bl.tongbaohiem, bl.thuclanh, bl.trangthai
FROM 
    TaiKhoan tk
JOIN 
    NhanVien nv ON tk.tk_ma = nv.tk_ma
JOIN 
    ChiTietChucVu ct ON nv.nv_ma = ct.nv_ma AND ct.trangthai = N'Dam nhiem'
JOIN 
    ChucVu cv ON ct.cv_ma = cv.cv_ma
JOIN 
    PhongBan pb ON nv.pb_ma = pb.pb_ma
JOIN
    BangLuong bl ON nv.nv_ma = bl.nv_ma
WHERE 
    tk.tk_tendn = @tendn";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@tendn", tenDangNhap);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            lblMaNV.Text = reader["nv_ma"].ToString();
                            lblTenNV.Text = reader["nv_ten"].ToString();
                            lblPhongBan.Text = reader["pb_ten"].ToString();
                            lblChucVu.Text = reader["cv_ten"].ToString();
                            lblNgaySinh.Text = Convert.ToDateTime(reader["nv_nsinh"]).ToString("dd/MM/yyyy");
                            lblGioiTinh.Text = reader["nv_gioitinh"].ToString();
                            lblEmail.Text = reader["nv_email"].ToString();
                            lblDiaChi.Text = reader["nv_diachi"].ToString();
                            lblSDT.Text = reader["nv_sdt"].ToString();
                            lblHeSoLuong.Text = reader["hesoluong"].ToString();
                            lblLuongCoBan.Text = reader["luongcoban"].ToString();
                            lblKhenThuong.Text = reader["tongkhenthuong"].ToString();
                            lblKyLuat.Text = reader["tongkyluat"].ToString();
                            lblPhuCap.Text = reader["tongphucap"].ToString();
                            lblBaoHiem.Text = reader["tongbaohiem"].ToString();
                            lblThucLanh.Text = reader["thuclanh"].ToString();
                            lblTrangThai.Text = reader["trangthai"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy thông tin nhân viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmDangNhap frm = new frmDangNhap();
            frm.ShowDialog();
            this.Close();
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra nếu thông tin nhân viên chưa được tải
                if (string.IsNullOrEmpty(lblMaNV.Text) || lblMaNV.Text == "Mã nhân viên:")
                {
                    MessageBox.Show("Không có thông tin nhân viên để xuất!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Hiển thị dialog để chọn nơi lưu file
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "Excel Files|*.xlsx",
                    Title = "Chọn nơi lưu file Excel",
                    FileName = $"ThongTinNhanVien_{lblMaNV.Text}_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (var package = new ExcelPackage())
                    {
                        // Tạo worksheet
                        var worksheet = package.Workbook.Worksheets.Add("Thông Tin Nhân Viên");

                        // Ghi tiêu đề
                        worksheet.Cells[1, 1].Value = "Thông Tin Nhân Viên";
                        worksheet.Cells[1, 1, 1, 2].Merge = true;
                        worksheet.Cells[1, 1].Style.Font.Size = 16;
                        worksheet.Cells[1, 1].Style.Font.Bold = true;
                        worksheet.Cells[1, 1].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                        // Ghi thông tin nhân viên
                        int row = 3;
                        worksheet.Cells[row, 1].Value = "Mã Nhân Viên";
                        worksheet.Cells[row, 2].Value = lblMaNV.Text;
                        row++;
                        worksheet.Cells[row, 1].Value = "Tên Nhân Viên";
                        worksheet.Cells[row, 2].Value = lblTenNV.Text;
                        row++;
                        worksheet.Cells[row, 1].Value = "Phòng Ban";
                        worksheet.Cells[row, 2].Value = lblPhongBan.Text;
                        row++;
                        worksheet.Cells[row, 1].Value = "Chức Vụ";
                        worksheet.Cells[row, 2].Value = lblChucVu.Text;
                        row++;
                        worksheet.Cells[row, 1].Value = "Ngày Sinh";
                        worksheet.Cells[row, 2].Value = lblNgaySinh.Text;
                        row++;
                        worksheet.Cells[row, 1].Value = "Giới Tính";
                        worksheet.Cells[row, 2].Value = lblGioiTinh.Text;
                        row++;
                        worksheet.Cells[row, 1].Value = "Email";
                        worksheet.Cells[row, 2].Value = lblEmail.Text;
                        row++;
                        worksheet.Cells[row, 1].Value = "Địa Chỉ";
                        worksheet.Cells[row, 2].Value = lblDiaChi.Text;
                        row++;
                        worksheet.Cells[row, 1].Value = "Số Điện Thoại";
                        worksheet.Cells[row, 2].Value = lblSDT.Text;
                        row++;
                        worksheet.Cells[row, 1].Value = "Hệ Số Lương";
                        worksheet.Cells[row, 2].Value = lblHeSoLuong.Text;
                        row++;

                        // Ghi thông tin lương
                        row++;
                        worksheet.Cells[row, 1].Value = "Thông Tin Lương";
                        worksheet.Cells[row, 1, row, 2].Merge = true;
                        worksheet.Cells[row, 1].Style.Font.Size = 14;
                        worksheet.Cells[row, 1].Style.Font.Bold = true;
                        worksheet.Cells[row, 1].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        row++;

                        worksheet.Cells[row, 1].Value = "Lương Cơ Bản";
                        worksheet.Cells[row, 2].Value = lblLuongCoBan.Text;
                        row++;
                        worksheet.Cells[row, 1].Value = "Khen Thưởng";
                        worksheet.Cells[row, 2].Value = lblKhenThuong.Text;
                        row++;
                        worksheet.Cells[row, 1].Value = "Kỷ Luật";
                        worksheet.Cells[row, 2].Value = lblKyLuat.Text;
                        row++;
                        worksheet.Cells[row, 1].Value = "Phụ Cấp";
                        worksheet.Cells[row, 2].Value = lblPhuCap.Text;
                        row++;
                        worksheet.Cells[row, 1].Value = "Bảo Hiểm";
                        worksheet.Cells[row, 2].Value = lblBaoHiem.Text;
                        row++;
                        worksheet.Cells[row, 1].Value = "Thực Lãnh";
                        worksheet.Cells[row, 2].Value = lblThucLanh.Text;
                        row++;
                        worksheet.Cells[row, 1].Value = "Trạng Thái";
                        worksheet.Cells[row, 2].Value = lblTrangThai.Text;

                        // Định dạng cột
                        worksheet.Cells[3, 1, row, 1].Style.Font.Bold = true;
                        worksheet.Cells[3, 1, row, 2].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        worksheet.Cells[3, 1, row, 2].AutoFitColumns();

                        // Lưu file
                        File.WriteAllBytes(saveFileDialog.FileName, package.GetAsByteArray());
                        MessageBox.Show("Xuất thông tin nhân viên ra file Excel thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xuất file Excel: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
