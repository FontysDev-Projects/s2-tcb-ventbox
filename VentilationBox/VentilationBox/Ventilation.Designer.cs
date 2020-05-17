namespace VentilationBox
{
    partial class Ventilation
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.trackBarCurrentTemperature = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCurrentTemperature = new System.Windows.Forms.Label();
            this.lblTargetTemperature = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.trackBarTargetTemperature = new System.Windows.Forms.TrackBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblTemperature = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarCurrentTemperature)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTargetTemperature)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // trackBarCurrentTemperature
            // 
            this.trackBarCurrentTemperature.Location = new System.Drawing.Point(16, 55);
            this.trackBarCurrentTemperature.Maximum = 30;
            this.trackBarCurrentTemperature.Minimum = 10;
            this.trackBarCurrentTemperature.Name = "trackBarCurrentTemperature";
            this.trackBarCurrentTemperature.Size = new System.Drawing.Size(155, 45);
            this.trackBarCurrentTemperature.TabIndex = 0;
            this.trackBarCurrentTemperature.Value = 10;
            this.trackBarCurrentTemperature.Scroll += new System.EventHandler(this.trackBarCurrentTemperature_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Current temperature:";
            // 
            // lblCurrentTemperature
            // 
            this.lblCurrentTemperature.AutoSize = true;
            this.lblCurrentTemperature.Location = new System.Drawing.Point(76, 39);
            this.lblCurrentTemperature.Name = "lblCurrentTemperature";
            this.lblCurrentTemperature.Size = new System.Drawing.Size(19, 13);
            this.lblCurrentTemperature.TabIndex = 2;
            this.lblCurrentTemperature.Text = "10";
            // 
            // lblTargetTemperature
            // 
            this.lblTargetTemperature.AutoSize = true;
            this.lblTargetTemperature.Location = new System.Drawing.Point(76, 151);
            this.lblTargetTemperature.Name = "lblTargetTemperature";
            this.lblTargetTemperature.Size = new System.Drawing.Size(19, 13);
            this.lblTargetTemperature.TabIndex = 5;
            this.lblTargetTemperature.Text = "10";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(175, 24);
            this.label3.TabIndex = 4;
            this.label3.Text = "Target temperature:";
            // 
            // trackBarTargetTemperature
            // 
            this.trackBarTargetTemperature.Location = new System.Drawing.Point(16, 167);
            this.trackBarTargetTemperature.Maximum = 30;
            this.trackBarTargetTemperature.Minimum = 10;
            this.trackBarTargetTemperature.Name = "trackBarTargetTemperature";
            this.trackBarTargetTemperature.Size = new System.Drawing.Size(155, 45);
            this.trackBarTargetTemperature.TabIndex = 3;
            this.trackBarTargetTemperature.Value = 10;
            this.trackBarTargetTemperature.Scroll += new System.EventHandler(this.trackBarTargetTemperature_Scroll);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblTemperature
            // 
            this.lblTemperature.AutoSize = true;
            this.lblTemperature.Location = new System.Drawing.Point(13, 245);
            this.lblTemperature.Name = "lblTemperature";
            this.lblTemperature.Size = new System.Drawing.Size(35, 13);
            this.lblTemperature.TabIndex = 6;
            this.lblTemperature.Text = "label2";
            // 
            // chart1
            // 
            chartArea1.AxisY.MajorGrid.Interval = 5D;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(239, 9);
            this.chart1.Name = "chart1";
            series1.BorderWidth = 5;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            series1.Legend = "Legend1";
            series1.Name = "Temperature";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(549, 426);
            this.chart1.TabIndex = 7;
            this.chart1.Text = "chart1";
            // 
            // Ventilation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.lblTemperature);
            this.Controls.Add(this.lblTargetTemperature);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.trackBarTargetTemperature);
            this.Controls.Add(this.lblCurrentTemperature);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackBarCurrentTemperature);
            this.Name = "Ventilation";
            this.Text = "Ventilation";
            ((System.ComponentModel.ISupportInitialize)(this.trackBarCurrentTemperature)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTargetTemperature)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar trackBarCurrentTemperature;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCurrentTemperature;
        private System.Windows.Forms.Label lblTargetTemperature;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar trackBarTargetTemperature;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblTemperature;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}