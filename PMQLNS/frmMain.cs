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
using PMQLNS.NhanVien;
using PMQLNS.PhongBan;
using PMQLNS.ChucVu;
using PMQLNS.BaoCao_ThongKe;

namespace PMQLNS
{
    public partial class frmMain : Form
    {
        string connStr = ConfigurationManager.ConnectionStrings["QLNSConnectionString"].ConnectionString;
        DataTable dtNhanVien;
        public frmMain()
        {
            InitializeComponent();
            LoadNhanVien();
            pnlTongNhanVien.BorderStyle = BorderStyle.FixedSingle;
            pnlTongLuongPhaiTra.BorderStyle = BorderStyle.FixedSingle;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel2.BorderStyle = BorderStyle.FixedSingle;
        }
        private void LoadNhanVien()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM NhanVien";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    dtNhanVien = new DataTable(); // Lưu lại vào biến toàn cục
                    adapter.Fill(dtNhanVien);
                    dtgNhanVien.DataSource = dtNhanVien;

                    // Đặt header và độ rộng như trước
                    dtgNhanVien.Columns["nv_ma"].HeaderText = "Mã nhân viên";
                    dtgNhanVien.Columns["pb_ma"].HeaderText = "Mã phòng ban";
                    dtgNhanVien.Columns["tk_ma"].HeaderText = "Mã tài khoản";
                    dtgNhanVien.Columns["nv_ten"].HeaderText = "Họ tên";
                    dtgNhanVien.Columns["nv_nsinh"].HeaderText = "Ngày sinh";
                    dtgNhanVien.Columns["nv_gioitinh"].HeaderText = "Giới tính";
                    dtgNhanVien.Columns["nv_email"].HeaderText = "Email";
                    dtgNhanVien.Columns["nv_diachi"].HeaderText = "Địa chỉ";
                    dtgNhanVien.Columns["nv_sdt"].HeaderText = "SĐT";
                    dtgNhanVien.Columns["hesoluong"].HeaderText = "Hệ số lương";

                    foreach (DataGridViewColumn col in dtgNhanVien.Columns)
                    {
                        col.Width = 180;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi load dữ liệu nhân viên: " + ex.Message);
                }
            }
        }

        private void LoadThongTinTongQuan()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();

                    // Tổng nhân viên
                    string queryNhanVien = "SELECT COUNT(*) FROM NhanVien";
                    SqlCommand cmdNhanVien = new SqlCommand(queryNhanVien, conn);
                    int countNhanVien = (int)cmdNhanVien.ExecuteScalar();
                    lblTongNhanVien.Text = $"Tổng nhân viên: {countNhanVien}";

                    // Tổng lương
                    string queryLuong = "SELECT SUM(ThucLanh) FROM BangLuong";
                    SqlCommand cmdLuong = new SqlCommand(queryLuong, conn);
                    object resultLuong = cmdLuong.ExecuteScalar();
                    decimal tongLuong = (resultLuong != DBNull.Value) ? Convert.ToDecimal(resultLuong) : 0;
                    lblTongLuongPhaiTra.Text = $"Tổng lương phải trả: {tongLuong:N0} VNĐ";

                    // Tháng và năm hiện tại
                    int thang = DateTime.Now.Month;
                    int nam = DateTime.Now.Year;

                    // Nhân viên được khen thưởng trong tháng
                    string queryKhenThuong = @"
                SELECT COUNT(DISTINCT nv_ma)
                FROM KhenThuong
                WHERE MONTH(NgayKhenThuong) = @Thang AND YEAR(NgayKhenThuong) = @Nam";
                    SqlCommand cmdKhenThuong = new SqlCommand(queryKhenThuong, conn);
                    cmdKhenThuong.Parameters.AddWithValue("@Thang", thang);
                    cmdKhenThuong.Parameters.AddWithValue("@Nam", nam);
                    int soKhenThuong = (int)cmdKhenThuong.ExecuteScalar();
                    lblKhenThuong.Text = $"Khen thưởng tháng này: {soKhenThuong}";

                    // Nhân viên bị kỷ luật trong tháng
                    string queryKyLuat = @"
                SELECT COUNT(DISTINCT nv_ma)
                FROM KyLuat
                WHERE MONTH(NgayKyLuat) = @Thang AND YEAR(NgayKyLuat) = @Nam";
                    SqlCommand cmdKyLuat = new SqlCommand(queryKyLuat, conn);
                    cmdKyLuat.Parameters.AddWithValue("@Thang", thang);
                    cmdKyLuat.Parameters.AddWithValue("@Nam", nam);
                    int soKyLuat = (int)cmdKyLuat.ExecuteScalar();
                    lblKiLuat.Text = $"Kỷ luật tháng này: {soKyLuat}";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void trangChủToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadThongTinTongQuan();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            LoadThongTinTongQuan();
        }
        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNhanVien frm = new frmNhanVien();
            frm.FormClosed += (s, args) => LoadNhanVien(); // Gọi lại khi form bị tắt
            frm.ShowDialog();
        }

        private void phòngBanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPhongBan frm = new frmPhongBan();
            frm.ShowDialog();
        }

        private void chứcVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChucVu frm = new frmChucVu();
            frm.ShowDialog();
        }

        private void côngViệcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCongViec frm = new frmCongViec();
            frm.ShowDialog();
        }

        private void bằngCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBangCap frm = new frmBangCap();
            frm.ShowDialog();
        }

        private void bảoHiểmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBaoHiem frm = new frmBaoHiem();
            frm.ShowDialog();
        }

        private void phụCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPhuCap frm = new frmPhuCap();
            frm.ShowDialog();
        }

        private void kĩLuậtVàKhenThưởngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKhenThuongVaKyLuat frm = new frmKhenThuongVaKyLuat();
            frm.ShowDialog();
        }

        private void lươngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLuong frm = new frmLuong();
            frm.ShowDialog();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();

            if (dtNhanVien != null)
            {
                DataView dv = dtNhanVien.DefaultView;

                // Tìm kiếm theo: tên, ngày sinh, mã nhân viên, số điện thoại, email, mã tài khoản
                dv.RowFilter = string.Format(
                    "nv_ten LIKE '%{0}%' OR " +
                    "CONVERT(nv_nsinh, 'System.String') LIKE '%{0}%' OR " +
                    "nv_ma LIKE '%{0}%' OR " +
                    "nv_sdt LIKE '%{0}%' OR " +
                    "nv_email LIKE '%{0}%' OR " +
                    "tk_ma LIKE '%{0}%'",
                    keyword.Replace("'", "''") 
                );

                dtgNhanVien.DataSource = dv.ToTable();
            }
        }

        private void đăngXuấtToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmDangNhap frm = new frmDangNhap();
            frm.ShowDialog();
            this.Close();
        }

        private void báoCáoNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBaoCaoNV frm = new frmBaoCaoNV();
            frm.ShowDialog();
        }

        private void báoCáoLươngVàPhúcLợiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBaoCaoLuong frm = new frmBaoCaoLuong();
            frm.ShowDialog();
        }

        private void côngViệcVàHiệuSuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBaoCaoHieuSuat frm = new frmBaoCaoHieuSuat();
            frm.ShowDialog();
        }
    }
}
