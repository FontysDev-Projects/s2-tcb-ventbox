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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.trackBarCurrentTemperature = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCurrentTemperature = new System.Windows.Forms.Label();
            this.lblTargetTemperature = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.trackBarTargetTemperature = new System.Windows.Forms.TrackBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTopBar = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarCurrentTemperature)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTargetTemperature)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // trackBarCurrentTemperature
            // 
            this.trackBarCurrentTemperature.Location = new System.Drawing.Point(16, 116);
            this.trackBarCurrentTemperature.Maximum = 30;
            this.trackBarCurrentTemperature.Minimum = 10;
            this.trackBarCurrentTemperature.Name = "trackBarCurrentTemperature";
            this.trackBarCurrentTemperature.Size = new System.Drawing.Size(155, 45);
            this.trackBarCurrentTemperature.TabIndex = 0;
            this.trackBarCurrentTemperature.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarCurrentTemperature.Value = 10;
            this.trackBarCurrentTemperature.Scroll += new System.EventHandler(this.trackBarCurrentTemperature_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Current temperature:";
            // 
            // lblCurrentTemperature
            // 
            this.lblCurrentTemperature.AutoSize = true;
            this.lblCurrentTemperature.Location = new System.Drawing.Point(76, 100);
            this.lblCurrentTemperature.Name = "lblCurrentTemperature";
            this.lblCurrentTemperature.Size = new System.Drawing.Size(19, 13);
            this.lblCurrentTemperature.TabIndex = 2;
            this.lblCurrentTemperature.Text = "10";
            // 
            // lblTargetTemperature
            // 
            this.lblTargetTemperature.AutoSize = true;
            this.lblTargetTemperature.Location = new System.Drawing.Point(76, 212);
            this.lblTargetTemperature.Name = "lblTargetTemperature";
            this.lblTargetTemperature.Size = new System.Drawing.Size(19, 13);
            this.lblTargetTemperature.TabIndex = 5;
            this.lblTargetTemperature.Text = "10";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 182);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(175, 24);
            this.label3.TabIndex = 4;
            this.label3.Text = "Target temperature:";
            // 
            // trackBarTargetTemperature
            // 
            this.trackBarTargetTemperature.Location = new System.Drawing.Point(16, 228);
            this.trackBarTargetTemperature.Maximum = 30;
            this.trackBarTargetTemperature.Minimum = 10;
            this.trackBarTargetTemperature.Name = "trackBarTargetTemperature";
            this.trackBarTargetTemperature.Size = new System.Drawing.Size(155, 45);
            this.trackBarTargetTemperature.TabIndex = 3;
            this.trackBarTargetTemperature.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarTargetTemperature.Value = 10;
            this.trackBarTargetTemperature.Scroll += new System.EventHandler(this.trackBarTargetTemperature_Scroll);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // chart1
            // 
            chartArea3.AxisY.MajorGrid.Interval = 5D;
            chartArea3.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chart1.Legends.Add(legend3);
            this.chart1.Location = new System.Drawing.Point(201, 70);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel;
            series3.BorderWidth = 5;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series3.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            series3.Legend = "Legend1";
            series3.Name = "Temperature";
            this.chart1.Series.Add(series3);
            this.chart1.Size = new System.Drawing.Size(471, 336);
            this.chart1.TabIndex = 7;
            this.chart1.Text = "chart1";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.DimGray;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(46, 328);
            this.btnClose.Margin = new System.Windows.Forms.Padding(0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(107, 41);
            this.btnClose.TabIndex = 23;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblTopBar
            // 
            this.lblTopBar.BackColor = System.Drawing.Color.DimGray;
            this.lblTopBar.Location = new System.Drawing.Point(55, 0);
            this.lblTopBar.Name = "lblTopBar";
            this.lblTopBar.Size = new System.Drawing.Size(1131, 50);
            this.lblTopBar.TabIndex = 22;
            this.lblTopBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblTopBar_MouseDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.DimGray;
            this.pictureBox1.Image = global::VentilationBox.Properties.Resources._5e754338_5820_4033_b84a_60e4cb5b1073_200x200;
            this.pictureBox1.Location = new System.Drawing.Point(-1, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(60, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // Ventilation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(694, 429);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblTopBar);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.lblTargetTemperature);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.trackBarTargetTemperature);
            this.Controls.Add(this.lblCurrentTemperature);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackBarCurrentTemperature);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Ventilation";
            this.Text = "Ventilation";
            ((System.ComponentModel.ISupportInitialize)(this.trackBarCurrentTemperature)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTargetTemperature)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTopBar;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}