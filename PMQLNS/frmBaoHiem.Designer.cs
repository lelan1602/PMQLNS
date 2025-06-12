namespace PMQLNS
{
    partial class frmBaoHiem
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
            this.txtSoTien = new System.Windows.Forms.TextBox();
            this.cbxLoaiBaoHiem = new System.Windows.Forms.ComboBox();
            this.cbxTenNhanVien = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtgBaoHiem = new System.Windows.Forms.DataGridView();
            this.btnSuaBaoHiem = new System.Windows.Forms.Button();
            this.txtTenBaoHiem = new System.Windows.Forms.TextBox();
            this.btnXoaBaoHiem = new System.Windows.Forms.Button();
            this.btnThemBaoHiem = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtMaBaoHiem = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaLoaiBaoHiem = new System.Windows.Forms.TextBox();
            this.txtTenLoaiBaoHiem = new System.Windows.Forms.TextBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.dtgLoaiBaoHiem = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBoQua = new System.Windows.Forms.Button();
            this.btnBoQuaBH = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgBaoHiem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgLoaiBaoHiem)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label7.Location = new System.Drawing.Point(436, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(216, 29);
            this.label7.TabIndex = 44;
            this.label7.Text = "Quản lý bảo hiểm";
            // 
            // txtSoTien
            // 
            this.txtSoTien.Location = new System.Drawing.Point(124, 125);
            this.txtSoTien.Name = "txtSoTien";
            this.txtSoTien.Size = new System.Drawing.Size(165, 26);
            this.txtSoTien.TabIndex = 43;
            // 
            // cbxLoaiBaoHiem
            // 
            this.cbxLoaiBaoHiem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxLoaiBaoHiem.FormattingEnabled = true;
            this.cbxLoaiBaoHiem.Location = new System.Drawing.Point(489, 31);
            this.cbxLoaiBaoHiem.Name = "cbxLoaiBaoHiem";
            this.cbxLoaiBaoHiem.Size = new System.Drawing.Size(215, 28);
            this.cbxLoaiBaoHiem.TabIndex = 42;
            // 
            // cbxTenNhanVien
            // 
            this.cbxTenNhanVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTenNhanVien.FormattingEnabled = true;
            this.cbxTenNhanVien.Location = new System.Drawing.Point(124, 77);
            this.cbxTenNhanVien.Name = "cbxTenNhanVien";
            this.cbxTenNhanVien.Size = new System.Drawing.Size(164, 28);
            this.cbxTenNhanVien.TabIndex = 39;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(349, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 20);
            this.label6.TabIndex = 36;
            this.label6.Text = "Loại bảo hiểm:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(55, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 20);
            this.label5.TabIndex = 35;
            this.label5.Text = "Số tiền:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 20);
            this.label3.TabIndex = 34;
            this.label3.Text = "Tên nhân viên:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnBoQuaBH);
            this.groupBox2.Controls.Add(this.dtgBaoHiem);
            this.groupBox2.Controls.Add(this.btnSuaBaoHiem);
            this.groupBox2.Controls.Add(this.txtTenBaoHiem);
            this.groupBox2.Controls.Add(this.btnXoaBaoHiem);
            this.groupBox2.Controls.Add(this.btnThemBaoHiem);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtMaBaoHiem);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtSoTien);
            this.groupBox2.Controls.Add(this.cbxLoaiBaoHiem);
            this.groupBox2.Controls.Add(this.cbxTenNhanVien);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(533, 81);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(749, 377);
            this.groupBox2.TabIndex = 47;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Bảo hiểm";
            // 
            // dtgBaoHiem
            // 
            this.dtgBaoHiem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgBaoHiem.Location = new System.Drawing.Point(9, 189);
            this.dtgBaoHiem.Name = "dtgBaoHiem";
            this.dtgBaoHiem.Size = new System.Drawing.Size(728, 178);
            this.dtgBaoHiem.TabIndex = 50;
            this.dtgBaoHiem.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgBaoHiem_CellClick);
            // 
            // btnSuaBaoHiem
            // 
            this.btnSuaBaoHiem.Location = new System.Drawing.Point(431, 128);
            this.btnSuaBaoHiem.Name = "btnSuaBaoHiem";
            this.btnSuaBaoHiem.Size = new System.Drawing.Size(88, 44);
            this.btnSuaBaoHiem.TabIndex = 48;
            this.btnSuaBaoHiem.Text = "Sửa";
            this.btnSuaBaoHiem.UseVisualStyleBackColor = true;
            this.btnSuaBaoHiem.Click += new System.EventHandler(this.btnSuaBaoHiem_Click);
            // 
            // txtTenBaoHiem
            // 
            this.txtTenBaoHiem.Location = new System.Drawing.Point(489, 80);
            this.txtTenBaoHiem.Name = "txtTenBaoHiem";
            this.txtTenBaoHiem.Size = new System.Drawing.Size(215, 26);
            this.txtTenBaoHiem.TabIndex = 49;
            // 
            // btnXoaBaoHiem
            // 
            this.btnXoaBaoHiem.Location = new System.Drawing.Point(540, 128);
            this.btnXoaBaoHiem.Name = "btnXoaBaoHiem";
            this.btnXoaBaoHiem.Size = new System.Drawing.Size(88, 44);
            this.btnXoaBaoHiem.TabIndex = 47;
            this.btnXoaBaoHiem.Text = "Xóa";
            this.btnXoaBaoHiem.UseVisualStyleBackColor = true;
            this.btnXoaBaoHiem.Click += new System.EventHandler(this.btnXoaBaoHiem_Click);
            // 
            // btnThemBaoHiem
            // 
            this.btnThemBaoHiem.Location = new System.Drawing.Point(324, 128);
            this.btnThemBaoHiem.Name = "btnThemBaoHiem";
            this.btnThemBaoHiem.Size = new System.Drawing.Size(88, 44);
            this.btnThemBaoHiem.TabIndex = 46;
            this.btnThemBaoHiem.Text = "Thêm";
            this.btnThemBaoHiem.UseVisualStyleBackColor = true;
            this.btnThemBaoHiem.Click += new System.EventHandler(this.btnThemBaoHiem_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(352, 83);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(109, 20);
            this.label8.TabIndex = 48;
            this.label8.Text = "Tên bảo hiểm:";
            // 
            // txtMaBaoHiem
            // 
            this.txtMaBaoHiem.Location = new System.Drawing.Point(124, 27);
            this.txtMaBaoHiem.Name = "txtMaBaoHiem";
            this.txtMaBaoHiem.Size = new System.Drawing.Size(164, 26);
            this.txtMaBaoHiem.TabIndex = 47;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 20);
            this.label4.TabIndex = 46;
            this.label4.Text = "Mã bảo hiểm:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 20);
            this.label1.TabIndex = 32;
            this.label1.Text = "Mã loại bảo hiểm:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 20);
            this.label2.TabIndex = 33;
            this.label2.Text = "Tên loại bảo hiểm:";
            // 
            // txtMaLoaiBaoHiem
            // 
            this.txtMaLoaiBaoHiem.Location = new System.Drawing.Point(208, 33);
            this.txtMaLoaiBaoHiem.Name = "txtMaLoaiBaoHiem";
            this.txtMaLoaiBaoHiem.Size = new System.Drawing.Size(201, 26);
            this.txtMaLoaiBaoHiem.TabIndex = 37;
            // 
            // txtTenLoaiBaoHiem
            // 
            this.txtTenLoaiBaoHiem.Location = new System.Drawing.Point(208, 88);
            this.txtTenLoaiBaoHiem.Name = "txtTenLoaiBaoHiem";
            this.txtTenLoaiBaoHiem.Size = new System.Drawing.Size(201, 26);
            this.txtTenLoaiBaoHiem.TabIndex = 38;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(22, 133);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(88, 44);
            this.btnThem.TabIndex = 31;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(238, 133);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(88, 44);
            this.btnXoa.TabIndex = 40;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(129, 133);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(88, 44);
            this.btnSua.TabIndex = 41;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // dtgLoaiBaoHiem
            // 
            this.dtgLoaiBaoHiem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgLoaiBaoHiem.Location = new System.Drawing.Point(25, 194);
            this.dtgLoaiBaoHiem.Name = "dtgLoaiBaoHiem";
            this.dtgLoaiBaoHiem.Size = new System.Drawing.Size(407, 179);
            this.dtgLoaiBaoHiem.TabIndex = 45;
            this.dtgLoaiBaoHiem.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgLoaiBaoHiem_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBoQua);
            this.groupBox1.Controls.Add(this.dtgLoaiBaoHiem);
            this.groupBox1.Controls.Add(this.btnSua);
            this.groupBox1.Controls.Add(this.btnXoa);
            this.groupBox1.Controls.Add(this.btnThem);
            this.groupBox1.Controls.Add(this.txtTenLoaiBaoHiem);
            this.groupBox1.Controls.Add(this.txtMaLoaiBaoHiem);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(33, 75);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(449, 383);
            this.groupBox1.TabIndex = 46;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Loại bảo hiểm";
            // 
            // btnBoQua
            // 
            this.btnBoQua.Location = new System.Drawing.Point(344, 134);
            this.btnBoQua.Name = "btnBoQua";
            this.btnBoQua.Size = new System.Drawing.Size(88, 44);
            this.btnBoQua.TabIndex = 46;
            this.btnBoQua.Text = "Bỏ qua";
            this.btnBoQua.UseVisualStyleBackColor = true;
            this.btnBoQua.Click += new System.EventHandler(this.btnBoQua_Click);
            // 
            // btnBoQuaBH
            // 
            this.btnBoQuaBH.Location = new System.Drawing.Point(649, 127);
            this.btnBoQuaBH.Name = "btnBoQuaBH";
            this.btnBoQuaBH.Size = new System.Drawing.Size(88, 44);
            this.btnBoQuaBH.TabIndex = 51;
            this.btnBoQuaBH.Text = "Bỏ qua";
            this.btnBoQuaBH.UseVisualStyleBackColor = true;
            this.btnBoQuaBH.Click += new System.EventHandler(this.btnBoQuaBH_Click);
            // 
            // frmBaoHiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1310, 485);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label7);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmBaoHiem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Bảo Hiểm";
            this.Load += new System.EventHandler(this.frmBaoHiem_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgBaoHiem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgLoaiBaoHiem)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSoTien;
        private System.Windows.Forms.ComboBox cbxLoaiBaoHiem;
        private System.Windows.Forms.ComboBox cbxTenNhanVien;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtMaBaoHiem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dtgBaoHiem;
        private System.Windows.Forms.Button btnSuaBaoHiem;
        private System.Windows.Forms.TextBox txtTenBaoHiem;
        private System.Windows.Forms.Button btnXoaBaoHiem;
        private System.Windows.Forms.Button btnThemBaoHiem;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMaLoaiBaoHiem;
        private System.Windows.Forms.TextBox txtTenLoaiBaoHiem;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.DataGridView dtgLoaiBaoHiem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBoQuaBH;
        private System.Windows.Forms.Button btnBoQua;
    }
}