namespace PMQLNS
{
    partial class frmLuong
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
            this.dtgBangLuong = new System.Windows.Forms.DataGridView();
            this.btnTraLuong = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgBangLuong)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgBangLuong
            // 
            this.dtgBangLuong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgBangLuong.Location = new System.Drawing.Point(27, 149);
            this.dtgBangLuong.Name = "dtgBangLuong";
            this.dtgBangLuong.Size = new System.Drawing.Size(1319, 511);
            this.dtgBangLuong.TabIndex = 0;
            // 
            // btnTraLuong
            // 
            this.btnTraLuong.Location = new System.Drawing.Point(27, 75);
            this.btnTraLuong.Name = "btnTraLuong";
            this.btnTraLuong.Size = new System.Drawing.Size(116, 43);
            this.btnTraLuong.TabIndex = 1;
            this.btnTraLuong.Text = "Trả lương";
            this.btnTraLuong.UseVisualStyleBackColor = true;
            this.btnTraLuong.Click += new System.EventHandler(this.btnTraLuong_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label7.Location = new System.Drawing.Point(548, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(304, 29);
            this.label7.TabIndex = 45;
            this.label7.Text = "Tính lương cho nhân viên";
            // 
            // frmLuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnTraLuong);
            this.Controls.Add(this.dtgBangLuong);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmLuong";
            this.Text = "Tính lương nhân viên";
            this.Load += new System.EventHandler(this.frmLuong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgBangLuong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgBangLuong;
        private System.Windows.Forms.Button btnTraLuong;
        private System.Windows.Forms.Label label7;
    }
}