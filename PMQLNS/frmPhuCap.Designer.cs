namespace PMQLNS
{
    partial class frmPhuCap
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBoQua = new System.Windows.Forms.Button();
            this.txtSoTien = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtgLoaiPhuCap = new System.Windows.Forms.DataGridView();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.txtTenLoaiPhuCap = new System.Windows.Forms.TextBox();
            this.txtMaLoaiPhuCap = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnBoQuaPC = new System.Windows.Forms.Button();
            this.dtpThoiGian = new System.Windows.Forms.DateTimePicker();
            this.cbxTenNhanVien = new System.Windows.Forms.ComboBox();
            this.cbxTenLoaiPhuCap = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtgChiTietPhuCap = new System.Windows.Forms.DataGridView();
            this.btnSuaPhuCap = new System.Windows.Forms.Button();
            this.btnXoaPhuCap = new System.Windows.Forms.Button();
            this.btn_ThemPhuCap = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgLoaiPhuCap)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgChiTietPhuCap)).BeginInit();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label7.Location = new System.Drawing.Point(353, 22);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(200, 29);
            this.label7.TabIndex = 31;
            this.label7.Text = "Quản lý phụ cấp";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBoQua);
            this.groupBox1.Controls.Add(this.txtSoTien);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dtgLoaiPhuCap);
            this.groupBox1.Controls.Add(this.btnSua);
            this.groupBox1.Controls.Add(this.btnXoa);
            this.groupBox1.Controls.Add(this.btnThem);
            this.groupBox1.Controls.Add(this.txtTenLoaiPhuCap);
            this.groupBox1.Controls.Add(this.txtMaLoaiPhuCap);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(21, 82);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(433, 422);
            this.groupBox1.TabIndex = 47;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Loại phụ cấp";
            // 
            // btnBoQua
            // 
            this.btnBoQua.Location = new System.Drawing.Point(326, 177);
            this.btnBoQua.Name = "btnBoQua";
            this.btnBoQua.Size = new System.Drawing.Size(88, 44);
            this.btnBoQua.TabIndex = 48;
            this.btnBoQua.Text = "Bỏ qua";
            this.btnBoQua.UseVisualStyleBackColor = true;
            this.btnBoQua.Click += new System.EventHandler(this.btnBoQua_Click);
            // 
            // txtSoTien
            // 
            this.txtSoTien.Location = new System.Drawing.Point(159, 135);
            this.txtSoTien.Name = "txtSoTien";
            this.txtSoTien.Size = new System.Drawing.Size(124, 26);
            this.txtSoTien.TabIndex = 47;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 20);
            this.label3.TabIndex = 46;
            this.label3.Text = "Số tiền:";
            // 
            // dtgLoaiPhuCap
            // 
            this.dtgLoaiPhuCap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgLoaiPhuCap.Location = new System.Drawing.Point(7, 237);
            this.dtgLoaiPhuCap.Name = "dtgLoaiPhuCap";
            this.dtgLoaiPhuCap.Size = new System.Drawing.Size(408, 179);
            this.dtgLoaiPhuCap.TabIndex = 45;
            this.dtgLoaiPhuCap.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgLoaiPhuCap_CellClick);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(114, 177);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(88, 44);
            this.btnSua.TabIndex = 41;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(223, 177);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(88, 44);
            this.btnXoa.TabIndex = 40;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(7, 177);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(88, 44);
            this.btnThem.TabIndex = 31;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // txtTenLoaiPhuCap
            // 
            this.txtTenLoaiPhuCap.Location = new System.Drawing.Point(159, 87);
            this.txtTenLoaiPhuCap.Name = "txtTenLoaiPhuCap";
            this.txtTenLoaiPhuCap.Size = new System.Drawing.Size(214, 26);
            this.txtTenLoaiPhuCap.TabIndex = 38;
            // 
            // txtMaLoaiPhuCap
            // 
            this.txtMaLoaiPhuCap.Location = new System.Drawing.Point(159, 32);
            this.txtMaLoaiPhuCap.Name = "txtMaLoaiPhuCap";
            this.txtMaLoaiPhuCap.Size = new System.Drawing.Size(214, 26);
            this.txtMaLoaiPhuCap.TabIndex = 37;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 20);
            this.label2.TabIndex = 33;
            this.label2.Text = "Tên loại phụ cấp:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 20);
            this.label1.TabIndex = 32;
            this.label1.Text = "Mã loại phụ cấp:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnBoQuaPC);
            this.groupBox2.Controls.Add(this.dtpThoiGian);
            this.groupBox2.Controls.Add(this.cbxTenNhanVien);
            this.groupBox2.Controls.Add(this.cbxTenLoaiPhuCap);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.dtgChiTietPhuCap);
            this.groupBox2.Controls.Add(this.btnSuaPhuCap);
            this.groupBox2.Controls.Add(this.btnXoaPhuCap);
            this.groupBox2.Controls.Add(this.btn_ThemPhuCap);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(475, 82);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(425, 422);
            this.groupBox2.TabIndex = 48;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chi tiết phụ cấp";
            // 
            // btnBoQuaPC
            // 
            this.btnBoQuaPC.Location = new System.Drawing.Point(326, 177);
            this.btnBoQuaPC.Name = "btnBoQuaPC";
            this.btnBoQuaPC.Size = new System.Drawing.Size(88, 44);
            this.btnBoQuaPC.TabIndex = 51;
            this.btnBoQuaPC.Text = "Bỏ qua";
            this.btnBoQuaPC.UseVisualStyleBackColor = true;
            this.btnBoQuaPC.Click += new System.EventHandler(this.btnBoQuaPC_Click);
            // 
            // dtpThoiGian
            // 
            this.dtpThoiGian.Location = new System.Drawing.Point(144, 135);
            this.dtpThoiGian.Name = "dtpThoiGian";
            this.dtpThoiGian.Size = new System.Drawing.Size(216, 26);
            this.dtpThoiGian.TabIndex = 50;
            // 
            // cbxTenNhanVien
            // 
            this.cbxTenNhanVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTenNhanVien.FormattingEnabled = true;
            this.cbxTenNhanVien.Location = new System.Drawing.Point(144, 85);
            this.cbxTenNhanVien.Name = "cbxTenNhanVien";
            this.cbxTenNhanVien.Size = new System.Drawing.Size(216, 28);
            this.cbxTenNhanVien.TabIndex = 49;
            // 
            // cbxTenLoaiPhuCap
            // 
            this.cbxTenLoaiPhuCap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTenLoaiPhuCap.FormattingEnabled = true;
            this.cbxTenLoaiPhuCap.Location = new System.Drawing.Point(144, 32);
            this.cbxTenLoaiPhuCap.Name = "cbxTenLoaiPhuCap";
            this.cbxTenLoaiPhuCap.Size = new System.Drawing.Size(216, 28);
            this.cbxTenLoaiPhuCap.TabIndex = 48;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 20);
            this.label4.TabIndex = 46;
            this.label4.Text = "Thời gian:";
            // 
            // dtgChiTietPhuCap
            // 
            this.dtgChiTietPhuCap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgChiTietPhuCap.Location = new System.Drawing.Point(6, 237);
            this.dtgChiTietPhuCap.Name = "dtgChiTietPhuCap";
            this.dtgChiTietPhuCap.Size = new System.Drawing.Size(408, 179);
            this.dtgChiTietPhuCap.TabIndex = 45;
            this.dtgChiTietPhuCap.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgChiTietPhuCap_CellClick);
            // 
            // btnSuaPhuCap
            // 
            this.btnSuaPhuCap.Location = new System.Drawing.Point(115, 177);
            this.btnSuaPhuCap.Name = "btnSuaPhuCap";
            this.btnSuaPhuCap.Size = new System.Drawing.Size(88, 44);
            this.btnSuaPhuCap.TabIndex = 41;
            this.btnSuaPhuCap.Text = "Sửa";
            this.btnSuaPhuCap.UseVisualStyleBackColor = true;
            this.btnSuaPhuCap.Click += new System.EventHandler(this.btnSuaPhuCap_Click);
            // 
            // btnXoaPhuCap
            // 
            this.btnXoaPhuCap.Location = new System.Drawing.Point(224, 177);
            this.btnXoaPhuCap.Name = "btnXoaPhuCap";
            this.btnXoaPhuCap.Size = new System.Drawing.Size(88, 44);
            this.btnXoaPhuCap.TabIndex = 40;
            this.btnXoaPhuCap.Text = "Xóa";
            this.btnXoaPhuCap.UseVisualStyleBackColor = true;
            this.btnXoaPhuCap.Click += new System.EventHandler(this.btnXoaPhuCap_Click);
            // 
            // btn_ThemPhuCap
            // 
            this.btn_ThemPhuCap.Location = new System.Drawing.Point(8, 177);
            this.btn_ThemPhuCap.Name = "btn_ThemPhuCap";
            this.btn_ThemPhuCap.Size = new System.Drawing.Size(88, 44);
            this.btn_ThemPhuCap.TabIndex = 31;
            this.btn_ThemPhuCap.Text = "Thêm";
            this.btn_ThemPhuCap.UseVisualStyleBackColor = true;
            this.btn_ThemPhuCap.Click += new System.EventHandler(this.btn_ThemPhuCap_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 20);
            this.label5.TabIndex = 33;
            this.label5.Text = "Tên nhân viên:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 20);
            this.label6.TabIndex = 32;
            this.label6.Text = "Loại phụ cấp:";
            // 
            // frmPhuCap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 520);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label7);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmPhuCap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý phụ cấp";
            this.Load += new System.EventHandler(this.frmPhuCap_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgLoaiPhuCap)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgChiTietPhuCap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dtgLoaiPhuCap;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.TextBox txtTenLoaiPhuCap;
        private System.Windows.Forms.TextBox txtMaLoaiPhuCap;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSoTien;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbxTenLoaiPhuCap;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dtgChiTietPhuCap;
        private System.Windows.Forms.Button btnSuaPhuCap;
        private System.Windows.Forms.Button btnXoaPhuCap;
        private System.Windows.Forms.Button btn_ThemPhuCap;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbxTenNhanVien;
        private System.Windows.Forms.DateTimePicker dtpThoiGian;
        private System.Windows.Forms.Button btnBoQua;
        private System.Windows.Forms.Button btnBoQuaPC;
    }
}