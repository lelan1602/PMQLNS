namespace PMQLNS.BaoCao_ThongKe
{
    partial class frmBaoCaoHieuSuat
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
            this.chartTiLeHoanThanhCV = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewCongViec = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.chartTiLeHoanThanhCV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCongViec)).BeginInit();
            this.SuspendLayout();
            // 
            // chartTiLeHoanThanhCV
            // 
            chartArea1.Name = "ChartArea1";
            this.chartTiLeHoanThanhCV.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartTiLeHoanThanhCV.Legends.Add(legend1);
            this.chartTiLeHoanThanhCV.Location = new System.Drawing.Point(45, 131);
            this.chartTiLeHoanThanhCV.Name = "chartTiLeHoanThanhCV";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartTiLeHoanThanhCV.Series.Add(series1);
            this.chartTiLeHoanThanhCV.Size = new System.Drawing.Size(421, 308);
            this.chartTiLeHoanThanhCV.TabIndex = 14;
            this.chartTiLeHoanThanhCV.Text = "chart1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(352, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(370, 24);
            this.label1.TabIndex = 13;
            this.label1.Text = "BÁO CÁO CÔNG VIỆC VÀ HIỆU SUẤT";
            // 
            // dataGridViewCongViec
            // 
            this.dataGridViewCongViec.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCongViec.Location = new System.Drawing.Point(510, 131);
            this.dataGridViewCongViec.Name = "dataGridViewCongViec";
            this.dataGridViewCongViec.Size = new System.Drawing.Size(475, 308);
            this.dataGridViewCongViec.TabIndex = 15;
            // 
            // frmBaoCaoHieuSuat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 516);
            this.Controls.Add(this.dataGridViewCongViec);
            this.Controls.Add(this.chartTiLeHoanThanhCV);
            this.Controls.Add(this.label1);
            this.Name = "frmBaoCaoHieuSuat";
            this.Text = "Báo cáo công việc và hiệu suất";
            this.Load += new System.EventHandler(this.frmBaoCaoHieuSuat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartTiLeHoanThanhCV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCongViec)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartTiLeHoanThanhCV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewCongViec;
    }
}