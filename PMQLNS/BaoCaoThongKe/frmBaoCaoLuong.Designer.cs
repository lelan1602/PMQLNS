namespace PMQLNS.BaoCao_ThongKe
{
    partial class frmBaoCaoLuong
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartKhenthuongKiluat = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartChiPhiLuongPB = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.cboMonth = new System.Windows.Forms.ComboBox();
            this.cboYear = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboTimeFrame = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartKhenthuongKiluat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartChiPhiLuongPB)).BeginInit();
            this.SuspendLayout();
            // 
            // chartKhenthuongKiluat
            // 
            chartArea3.Name = "ChartArea1";
            this.chartKhenthuongKiluat.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chartKhenthuongKiluat.Legends.Add(legend3);
            this.chartKhenthuongKiluat.Location = new System.Drawing.Point(530, 120);
            this.chartKhenthuongKiluat.Name = "chartKhenthuongKiluat";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chartKhenthuongKiluat.Series.Add(series3);
            this.chartKhenthuongKiluat.Size = new System.Drawing.Size(473, 358);
            this.chartKhenthuongKiluat.TabIndex = 6;
            this.chartKhenthuongKiluat.Text = "chart1";
            // 
            // chartChiPhiLuongPB
            // 
            chartArea4.Name = "ChartArea1";
            this.chartChiPhiLuongPB.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chartChiPhiLuongPB.Legends.Add(legend4);
            this.chartChiPhiLuongPB.Location = new System.Drawing.Point(29, 120);
            this.chartChiPhiLuongPB.Name = "chartChiPhiLuongPB";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.chartChiPhiLuongPB.Series.Add(series4);
            this.chartChiPhiLuongPB.Size = new System.Drawing.Size(473, 358);
            this.chartChiPhiLuongPB.TabIndex = 5;
            this.chartChiPhiLuongPB.Text = "chart1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(394, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(314, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "BÁO CÁO LƯƠNG VÀ PHÚC LỢI";
            // 
            // cboMonth
            // 
            this.cboMonth.FormattingEnabled = true;
            this.cboMonth.Location = new System.Drawing.Point(619, 65);
            this.cboMonth.Name = "cboMonth";
            this.cboMonth.Size = new System.Drawing.Size(121, 21);
            this.cboMonth.TabIndex = 7;
            // 
            // cboYear
            // 
            this.cboYear.FormattingEnabled = true;
            this.cboYear.Location = new System.Drawing.Point(882, 65);
            this.cboYear.Name = "cboYear";
            this.cboYear.Size = new System.Drawing.Size(121, 21);
            this.cboYear.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(538, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Tháng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(801, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Năm";
            // 
            // cboTimeFrame
            // 
            this.cboTimeFrame.FormattingEnabled = true;
            this.cboTimeFrame.Location = new System.Drawing.Point(345, 65);
            this.cboTimeFrame.Name = "cboTimeFrame";
            this.cboTimeFrame.Size = new System.Drawing.Size(121, 21);
            this.cboTimeFrame.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(267, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "label4";
            // 
            // frmBaoCaoLuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 516);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboTimeFrame);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboYear);
            this.Controls.Add(this.cboMonth);
            this.Controls.Add(this.chartKhenthuongKiluat);
            this.Controls.Add(this.chartChiPhiLuongPB);
            this.Controls.Add(this.label1);
            this.Name = "frmBaoCaoLuong";
            this.Text = "Báo cáo lương và phúc lợi";
            this.Load += new System.EventHandler(this.frmBaoCaoLuong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartKhenthuongKiluat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartChiPhiLuongPB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartKhenthuongKiluat;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartChiPhiLuongPB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboMonth;
        private System.Windows.Forms.ComboBox cboYear;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboTimeFrame;
        private System.Windows.Forms.Label label4;
    }
}