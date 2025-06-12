namespace PMQLNS
{
    partial class frmBangCap
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
            this.dtgBangCap = new System.Windows.Forms.DataGridView();
            this.cbxLoaiBangCap = new System.Windows.Forms.ComboBox();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.cbxTenNhanVien = new System.Windows.Forms.ComboBox();
            this.txtTenBangCap = new System.Windows.Forms.TextBox();
            this.txtMaBangCap = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNoiCap = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnBoQua = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgBangCap)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgBangCap
            // 
            this.dtgBangCap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgBangCap.Location = new System.Drawing.Point(31, 243);
            this.dtgBangCap.Name = "dtgBangCap";
            this.dtgBangCap.Size = new System.Drawing.Size(769, 247);
            this.dtgBangCap.TabIndex = 0;
            this.dtgBangCap.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgBangCap_CellClick);
            // 
            // cbxLoaiBangCap
            // 
            this.cbxLoaiBangCap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxLoaiBangCap.FormattingEnabled = true;
            this.cbxLoaiBangCap.Location = new System.Drawing.Point(614, 126);
            this.cbxLoaiBangCap.Name = "cbxLoaiBangCap";
            this.cbxLoaiBangCap.Size = new System.Drawing.Size(186, 28);
            this.cbxLoaiBangCap.TabIndex = 28;
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(495, 170);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(88, 44);
            this.btnSua.TabIndex = 26;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(604, 170);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(88, 44);
            this.btnXoa.TabIndex = 25;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(388, 170);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(88, 44);
            this.btnThem.TabIndex = 15;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // cbxTenNhanVien
            // 
            this.cbxTenNhanVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTenNhanVien.FormattingEnabled = true;
            this.cbxTenNhanVien.Location = new System.Drawing.Point(154, 179);
            this.cbxTenNhanVien.Name = "cbxTenNhanVien";
            this.cbxTenNhanVien.Size = new System.Drawing.Size(189, 28);
            this.cbxTenNhanVien.TabIndex = 24;
            // 
            // txtTenBangCap
            // 
            this.txtTenBangCap.Location = new System.Drawing.Point(154, 128);
            this.txtTenBangCap.Name = "txtTenBangCap";
            this.txtTenBangCap.Size = new System.Drawing.Size(189, 26);
            this.txtTenBangCap.TabIndex = 23;
            // 
            // txtMaBangCap
            // 
            this.txtMaBangCap.Location = new System.Drawing.Point(154, 73);
            this.txtMaBangCap.Name = "txtMaBangCap";
            this.txtMaBangCap.Size = new System.Drawing.Size(189, 26);
            this.txtMaBangCap.TabIndex = 22;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(440, 129);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 20);
            this.label6.TabIndex = 21;
            this.label6.Text = "Loại bằng cấp:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(440, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 20);
            this.label5.TabIndex = 20;
            this.label5.Text = "Nơi cấp:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 181);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 20);
            this.label3.TabIndex = 18;
            this.label3.Text = "Tên nhân viên:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 20);
            this.label2.TabIndex = 17;
            this.label2.Text = "Tên bằng cấp:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 20);
            this.label1.TabIndex = 16;
            this.label1.Text = "Mã bằng cấp:";
            // 
            // txtNoiCap
            // 
            this.txtNoiCap.Location = new System.Drawing.Point(560, 76);
            this.txtNoiCap.Name = "txtNoiCap";
            this.txtNoiCap.Size = new System.Drawing.Size(240, 26);
            this.txtNoiCap.TabIndex = 29;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label7.Location = new System.Drawing.Point(271, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(215, 29);
            this.label7.TabIndex = 30;
            this.label7.Text = "Quản lý bằng cấp";
            // 
            // btnBoQua
            // 
            this.btnBoQua.Location = new System.Drawing.Point(712, 170);
            this.btnBoQua.Name = "btnBoQua";
            this.btnBoQua.Size = new System.Drawing.Size(88, 44);
            this.btnBoQua.TabIndex = 31;
            this.btnBoQua.Text = "Bỏ qua";
            this.btnBoQua.UseVisualStyleBackColor = true;
            this.btnBoQua.Click += new System.EventHandler(this.btnBoQua_Click);
            // 
            // frmBangCap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 502);
            this.Controls.Add(this.btnBoQua);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtNoiCap);
            this.Controls.Add(this.cbxLoaiBangCap);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.cbxTenNhanVien);
            this.Controls.Add(this.txtTenBangCap);
            this.Controls.Add(this.txtMaBangCap);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtgBangCap);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmBangCap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Bằng Cấp";
            ((System.ComponentModel.ISupportInitialize)(this.dtgBangCap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgBangCap;
        private System.Windows.Forms.ComboBox cbxLoaiBangCap;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.ComboBox cbxTenNhanVien;
        private System.Windows.Forms.TextBox txtTenBangCap;
        private System.Windows.Forms.TextBox txtMaBangCap;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNoiCap;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnBoQua;
    }
}