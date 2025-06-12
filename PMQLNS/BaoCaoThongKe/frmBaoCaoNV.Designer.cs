namespace PMQLNS.BaoCao_ThongKe
{
    partial class frmBaoCaoNV
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label1 = new System.Windows.Forms.Label();
            this.chartBangCap = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartSLNVPhongBan = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartBangCap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSLNVPhongBan)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(422, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(222, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "BÁO CÁO NHÂN VIÊN";
            // 
            // chartBangCap
            // 
            chartArea1.Name = "ChartArea1";
            this.chartBangCap.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartBangCap.Legends.Add(legend1);
            this.chartBangCap.Location = new System.Drawing.Point(27, 59);
            this.chartBangCap.Name = "chartBangCap";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartBangCap.Series.Add(series1);
            this.chartBangCap.Size = new System.Drawing.Size(473, 358);
            this.chartBangCap.TabIndex = 2;
            this.chartBangCap.Text = "chart1";
            // 
            // chartSLNVPhongBan
            // 
            chartArea2.Name = "ChartArea1";
            this.chartSLNVPhongBan.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartSLNVPhongBan.Legends.Add(legend2);
            this.chartSLNVPhongBan.Location = new System.Drawing.Point(527, 59);
            this.chartSLNVPhongBan.Name = "chartSLNVPhongBan";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartSLNVPhongBan.Series.Add(series2);
            this.chartSLNVPhongBan.Size = new System.Drawing.Size(473, 358);
            this.chartSLNVPhongBan.TabIndex = 3;
            this.chartSLNVPhongBan.Text = "chart1";
            // 
            // frmBaoCaoNV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 516);
            this.Controls.Add(this.chartSLNVPhongBan);
            this.Controls.Add(this.chartBangCap);
            this.Controls.Add(this.label1);
            this.Name = "frmBaoCaoNV";
            this.Text = "Báo cáo nhân viên";
            this.Load += new System.EventHandler(this.frmBaoCaoNV_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartBangCap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSLNVPhongBan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartBangCap;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSLNVPhongBan;
    }
}