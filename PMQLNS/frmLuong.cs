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
    public partial class frmLuong : Form
    {
        string connStr = ConfigurationManager.ConnectionStrings["QLNSConnectionString"].ConnectionString;

        public frmLuong()
        {
            InitializeComponent();
            LoadDanhSachNhanVien();
        }

        private void frmLuong_Load(object sender, EventArgs e)
        {
            LoadDanhSachNhanVien();
        }
        private void LoadDanhSachNhanVien()
        {
            string query = @"
SELECT 
    nv.nv_ma AS [Mã nhân viên],
    nv.nv_ten AS [Tên nhân viên],
    nv.nv_gioitinh AS [Giới tính],
    nv.nv_nsinh AS [Ngày sinh],
    nv.nv_sdt AS [SĐT],
    nv.nv_diachi AS [Địa chỉ],
    nv.hesoluong AS [Hệ số lương],
    cv.cv_luongcoban AS [Lương cơ bản],

    -- Tổng khen thưởng
    ISNULL((
        SELECT SUM(kt.kt_sotien) 
        FROM KhenThuong kt 
        WHERE kt.nv_ma = nv.nv_ma
    ), 0) AS [Tổng khen thưởng],

    -- Tổng kỹ luật
    ISNULL((
        SELECT SUM(kl.kl_sotien) 
        FROM KyLuat kl 
        WHERE kl.nv_ma = nv.nv_ma
    ), 0) AS [Tổng kỹ luật],

    -- Tổng phụ cấp
    ISNULL((
        SELECT SUM(lp.lpc_sotien)
        FROM ChiTietPhuCap pc
        JOIN LoaiPhuCap lp ON pc.lpc_ma = lp.lpc_ma
        WHERE pc.nv_ma = nv.nv_ma
    ), 0) AS [Tổng phụ cấp],

    -- Tổng bảo hiểm
    ISNULL((
        SELECT SUM(bh.bh_sotien)
        FROM BaoHiem bh
        WHERE bh.nv_ma = nv.nv_ma
    ), 0) AS [Tổng bảo hiểm],

    -- Thực lãnh
    (
        cv.cv_luongcoban * nv.hesoluong
        + ISNULL((SELECT SUM(kt.kt_sotien) FROM KhenThuong kt WHERE kt.nv_ma = nv.nv_ma), 0)
        - ISNULL((SELECT SUM(kl.kl_sotien) FROM KyLuat kl WHERE kl.nv_ma = nv.nv_ma), 0)
        + ISNULL((SELECT SUM(lp.lpc_sotien) FROM ChiTietPhuCap pc JOIN LoaiPhuCap lp ON pc.lpc_ma = lp.lpc_ma WHERE pc.nv_ma = nv.nv_ma), 0)
        - ISNULL((SELECT SUM(bh.bh_sotien) FROM BaoHiem bh WHERE bh.nv_ma = nv.nv_ma), 0)
    ) AS [Thực lãnh],
    bl.trangthai as [Trạng thái]

FROM 
    NhanVien nv
    LEFT JOIN BangLuong as bl ON nv.nv_ma = bl.nv_ma AND bl.thang = MONTH(GETDATE()) AND bl.nam = YEAR(GETDATE())
JOIN 
    ChiTietChucVu ctcv ON nv.nv_ma = ctcv.nv_ma
JOIN 
    ChucVu cv ON ctcv.cv_ma = cv.cv_ma
WHERE 
    ctcv.trangthai = N'Dam nhiem'";

            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                dtgBangLuong.DataSource = dt;
                foreach (DataGridViewColumn col in dtgBangLuong.Columns)
                {
                    col.Width = 1617/14 - 2;
                }

            }
        }

        private void btnTraLuong_Click(object sender, EventArgs e)
        {
            int thang = DateTime.Now.Month;
            int nam = DateTime.Now.Year;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                foreach (DataGridViewRow row in dtgBangLuong.Rows)
                {
                    if (row.IsNewRow) continue;

                    string nv_ma = row.Cells["Mã nhân viên"].Value.ToString();

                    // ✅ Kiểm tra nhân viên đã nhận lương chưa
                    string checkQuery = @"
SELECT COUNT(*) FROM BangLuong 
WHERE nv_ma = @nv_ma AND thang = @thang AND nam = @nam";

                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@nv_ma", nv_ma);
                        checkCmd.Parameters.AddWithValue("@thang", thang);
                        checkCmd.Parameters.AddWithValue("@nam", nam);

                        int count = (int)checkCmd.ExecuteScalar();
                        if (count > 0)
                        {
                            // Đã nhận lương => bỏ qua
                            continue;
                        }
                    }

                    // Nếu chưa nhận lương, thì tiến hành lưu
                    string bl_ma = $"BL{nv_ma}{thang:00}{nam}";

                    decimal luongcoban = Convert.ToDecimal(row.Cells["Lương cơ bản"].Value);
                    decimal hesoluong = Convert.ToDecimal(row.Cells["Hệ số lương"].Value);
                    decimal tongkt = Convert.ToDecimal(row.Cells["Tổng khen thưởng"].Value);
                    decimal tongkl = Convert.ToDecimal(row.Cells["Tổng kỹ luật"].Value);
                    decimal tongpc = Convert.ToDecimal(row.Cells["Tổng phụ cấp"].Value);
                    decimal tongbh = Convert.ToDecimal(row.Cells["Tổng bảo hiểm"].Value);
                    decimal thuclanh = Convert.ToDecimal(row.Cells["Thực lãnh"].Value);

                    string insertQuery = @"
INSERT INTO BangLuong 
(bl_ma, nv_ma, thang, nam, luongcoban, hesoluong, tongkhenthuong, tongkyluat, tongphucap, tongbaohiem, thuclanh, trangthai)
VALUES 
(@bl_ma, @nv_ma, @thang, @nam, @luongcoban, @hesoluong, @tongkt, @tongkl, @tongpc, @tongbh, @thuclanh, N'Đã nhận lương')";

                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@bl_ma", bl_ma);
                        cmd.Parameters.AddWithValue("@nv_ma", nv_ma);
                        cmd.Parameters.AddWithValue("@thang", thang);
                        cmd.Parameters.AddWithValue("@nam", nam);
                        cmd.Parameters.AddWithValue("@luongcoban", luongcoban);
                        cmd.Parameters.AddWithValue("@hesoluong", hesoluong);
                        cmd.Parameters.AddWithValue("@tongkt", tongkt);
                        cmd.Parameters.AddWithValue("@tongkl", tongkl);
                        cmd.Parameters.AddWithValue("@tongpc", tongpc);
                        cmd.Parameters.AddWithValue("@tongbh", tongbh);
                        cmd.Parameters.AddWithValue("@thuclanh", thuclanh);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Đã lưu bảng lương cho các nhân viên chưa nhận!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDanhSachNhanVien();
            }
        }
    }
}
