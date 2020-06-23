namespace VentilationBox
{
    partial class Form1
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
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.lbl1 = new System.Windows.Forms.Label();
            this.temperatureValuelbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.humiditylbl = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.co2lbl = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tvoclbl = new System.Windows.Forms.Label();
            this.lblReading = new System.Windows.Forms.Label();
            this.checklbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.thresholdcmbx = new System.Windows.Forms.ComboBox();
            this.thresholdtbx = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.thresholdbtn = new System.Windows.Forms.Button();
            this.btnVentilation = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblTopBar = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblCurrentTvocLim = new System.Windows.Forms.Label();
            this.lblCurrentCoLim = new System.Windows.Forms.Label();
            this.lblCurrentHumLim = new System.Windows.Forms.Label();
            this.lblCurrentTempLim = new System.Windows.Forms.Label();
            this.btmCurrentLim = new System.Windows.Forms.Button();
            this.btmModLim = new System.Windows.Forms.Button();
            this.pnlModLim = new System.Windows.Forms.Panel();
            this.pnlCurrentLim = new System.Windows.Forms.Panel();
            this.lbl7 = new System.Windows.Forms.Label();
            this.lbl8 = new System.Windows.Forms.Label();
            this.lbl9 = new System.Windows.Forms.Label();
            this.lbl10 = new System.Windows.Forms.Label();
            this.lblWindow1 = new System.Windows.Forms.Label();
            this.lblWindow2 = new System.Windows.Forms.Label();
            this.lblWindow3 = new System.Windows.Forms.Label();
            this.lblAcOutput = new System.Windows.Forms.Label();
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlModLim.SuspendLayout();
            this.pnlCurrentLim.SuspendLayout();
            this.SuspendLayout();
            // 
            // serialPort1
            // 
            this.serialPort1.PortName = "COM6";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 5000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.BackColor = System.Drawing.Color.White;
            this.lbl1.Font = new System.Drawing.Font("Copperplate Gothic Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.ForeColor = System.Drawing.Color.Black;
            this.lbl1.Location = new System.Drawing.Point(49, 75);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(189, 26);
            this.lbl1.TabIndex = 0;
            this.lbl1.Text = "Temperature";
            // 
            // temperatureValuelbl
            // 
            this.temperatureValuelbl.AutoSize = true;
            this.temperatureValuelbl.BackColor = System.Drawing.Color.White;
            this.temperatureValuelbl.Font = new System.Drawing.Font("Copperplate Gothic Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.temperatureValuelbl.ForeColor = System.Drawing.Color.Black;
            this.temperatureValuelbl.Location = new System.Drawing.Point(279, 75);
            this.temperatureValuelbl.Name = "temperatureValuelbl";
            this.temperatureValuelbl.Size = new System.Drawing.Size(17, 26);
            this.temperatureValuelbl.TabIndex = 1;
            this.temperatureValuelbl.Text = "-";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Copperplate Gothic Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(53, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 26);
            this.label2.TabIndex = 2;
            this.label2.Text = "Humidity";
            // 
            // humiditylbl
            // 
            this.humiditylbl.AutoSize = true;
            this.humiditylbl.BackColor = System.Drawing.Color.White;
            this.humiditylbl.Font = new System.Drawing.Font("Copperplate Gothic Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.humiditylbl.ForeColor = System.Drawing.Color.Black;
            this.humiditylbl.Location = new System.Drawing.Point(279, 121);
            this.humiditylbl.Name = "humiditylbl";
            this.humiditylbl.Size = new System.Drawing.Size(17, 26);
            this.humiditylbl.TabIndex = 3;
            this.humiditylbl.Text = "-";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Copperplate Gothic Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(53, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 26);
            this.label4.TabIndex = 4;
            this.label4.Text = "CO2";
            // 
            // co2lbl
            // 
            this.co2lbl.AutoSize = true;
            this.co2lbl.BackColor = System.Drawing.Color.White;
            this.co2lbl.Font = new System.Drawing.Font("Copperplate Gothic Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.co2lbl.ForeColor = System.Drawing.Color.Black;
            this.co2lbl.Location = new System.Drawing.Point(279, 167);
            this.co2lbl.Name = "co2lbl";
            this.co2lbl.Size = new System.Drawing.Size(17, 26);
            this.co2lbl.TabIndex = 5;
            this.co2lbl.Text = "-";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("Copperplate Gothic Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(53, 213);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 26);
            this.label6.TabIndex = 6;
            this.label6.Text = "VOC";
            // 
            // tvoclbl
            // 
            this.tvoclbl.AutoSize = true;
            this.tvoclbl.BackColor = System.Drawing.Color.White;
            this.tvoclbl.Font = new System.Drawing.Font("Copperplate Gothic Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvoclbl.ForeColor = System.Drawing.Color.Black;
            this.tvoclbl.Location = new System.Drawing.Point(279, 213);
            this.tvoclbl.Name = "tvoclbl";
            this.tvoclbl.Size = new System.Drawing.Size(17, 26);
            this.tvoclbl.TabIndex = 7;
            this.tvoclbl.Text = "-";
            // 
            // lblReading
            // 
            this.lblReading.AutoSize = true;
            this.lblReading.BackColor = System.Drawing.Color.White;
            this.lblReading.Font = new System.Drawing.Font("Copperplate Gothic Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReading.ForeColor = System.Drawing.Color.Black;
            this.lblReading.Location = new System.Drawing.Point(393, 580);
            this.lblReading.Name = "lblReading";
            this.lblReading.Size = new System.Drawing.Size(69, 18);
            this.lblReading.TabIndex = 8;
            this.lblReading.Text = "label1";
            this.lblReading.Visible = false;
            // 
            // checklbl
            // 
            this.checklbl.AutoSize = true;
            this.checklbl.BackColor = System.Drawing.Color.White;
            this.checklbl.Font = new System.Drawing.Font("Copperplate Gothic Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checklbl.ForeColor = System.Drawing.Color.Black;
            this.checklbl.Location = new System.Drawing.Point(393, 536);
            this.checklbl.Name = "checklbl";
            this.checklbl.Size = new System.Drawing.Size(69, 18);
            this.checklbl.TabIndex = 9;
            this.checklbl.Text = "label1";
            this.checklbl.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Copperplate Gothic Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(393, 557);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 18);
            this.label1.TabIndex = 10;
            this.label1.Text = "Sum of the parameters: ";
            this.label1.Visible = false;
            // 
            // thresholdcmbx
            // 
            this.thresholdcmbx.BackColor = System.Drawing.Color.White;
            this.thresholdcmbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.thresholdcmbx.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thresholdcmbx.FormattingEnabled = true;
            this.thresholdcmbx.Items.AddRange(new object[] {
            "Temperature",
            "Humidity",
            "CO2",
            "VOC"});
            this.thresholdcmbx.Location = new System.Drawing.Point(21, 52);
            this.thresholdcmbx.Name = "thresholdcmbx";
            this.thresholdcmbx.Size = new System.Drawing.Size(121, 21);
            this.thresholdcmbx.TabIndex = 11;
            // 
            // thresholdtbx
            // 
            this.thresholdtbx.BackColor = System.Drawing.Color.White;
            this.thresholdtbx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.thresholdtbx.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thresholdtbx.ForeColor = System.Drawing.Color.Black;
            this.thresholdtbx.Location = new System.Drawing.Point(241, 52);
            this.thresholdtbx.Margin = new System.Windows.Forms.Padding(0);
            this.thresholdtbx.Name = "thresholdtbx";
            this.thresholdtbx.Size = new System.Drawing.Size(121, 20);
            this.thresholdtbx.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(18, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 18);
            this.label3.TabIndex = 13;
            this.label3.Text = "Select parameter: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(245, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 18);
            this.label5.TabIndex = 14;
            this.label5.Text = "Set threshold: ";
            // 
            // thresholdbtn
            // 
            this.thresholdbtn.BackColor = System.Drawing.Color.DimGray;
            this.thresholdbtn.FlatAppearance.BorderSize = 0;
            this.thresholdbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.thresholdbtn.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thresholdbtn.ForeColor = System.Drawing.Color.White;
            this.thresholdbtn.Location = new System.Drawing.Point(133, 113);
            this.thresholdbtn.Name = "thresholdbtn";
            this.thresholdbtn.Size = new System.Drawing.Size(132, 31);
            this.thresholdbtn.TabIndex = 15;
            this.thresholdbtn.Text = "Set Limit";
            this.thresholdbtn.UseVisualStyleBackColor = false;
            this.thresholdbtn.Click += new System.EventHandler(this.thresholdbtn_Click);
            // 
            // btnVentilation
            // 
            this.btnVentilation.BackColor = System.Drawing.Color.DimGray;
            this.btnVentilation.FlatAppearance.BorderSize = 0;
            this.btnVentilation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVentilation.Font = new System.Drawing.Font("Copperplate Gothic Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVentilation.ForeColor = System.Drawing.Color.White;
            this.btnVentilation.Location = new System.Drawing.Point(121, 632);
            this.btnVentilation.Name = "btnVentilation";
            this.btnVentilation.Size = new System.Drawing.Size(153, 50);
            this.btnVentilation.TabIndex = 16;
            this.btnVentilation.Text = "Ventilation";
            this.btnVentilation.UseVisualStyleBackColor = false;
            this.btnVentilation.Click += new System.EventHandler(this.btnVentilation_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.DimGray;
            this.pictureBox1.Image = global::VentilationBox.Properties.Resources._5e754338_5820_4033_b84a_60e4cb5b1073_200x200;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(60, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // lblTopBar
            // 
            this.lblTopBar.BackColor = System.Drawing.Color.DimGray;
            this.lblTopBar.Location = new System.Drawing.Point(56, 0);
            this.lblTopBar.Name = "lblTopBar";
            this.lblTopBar.Size = new System.Drawing.Size(1131, 50);
            this.lblTopBar.TabIndex = 19;
            this.lblTopBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label7_MouseDown);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.DimGray;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(358, 0);
            this.btnClose.Margin = new System.Windows.Forms.Padding(0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(50, 50);
            this.btnClose.TabIndex = 20;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(36, 112);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 16);
            this.label8.TabIndex = 25;
            this.label8.Text = "VOC";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(36, 85);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 16);
            this.label9.TabIndex = 24;
            this.label9.Text = "CO2";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.White;
            this.label10.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(36, 57);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(96, 16);
            this.label10.TabIndex = 23;
            this.label10.Text = "Humidity";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.White;
            this.label11.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(32, 28);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(129, 16);
            this.label11.TabIndex = 22;
            this.label11.Text = "Temperature";
            // 
            // lblCurrentTvocLim
            // 
            this.lblCurrentTvocLim.AutoSize = true;
            this.lblCurrentTvocLim.BackColor = System.Drawing.Color.White;
            this.lblCurrentTvocLim.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentTvocLim.ForeColor = System.Drawing.Color.Black;
            this.lblCurrentTvocLim.Location = new System.Drawing.Point(271, 113);
            this.lblCurrentTvocLim.Name = "lblCurrentTvocLim";
            this.lblCurrentTvocLim.Size = new System.Drawing.Size(47, 15);
            this.lblCurrentTvocLim.TabIndex = 25;
            this.lblCurrentTvocLim.Text = "7.95";
            // 
            // lblCurrentCoLim
            // 
            this.lblCurrentCoLim.AutoSize = true;
            this.lblCurrentCoLim.BackColor = System.Drawing.Color.White;
            this.lblCurrentCoLim.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentCoLim.ForeColor = System.Drawing.Color.Black;
            this.lblCurrentCoLim.Location = new System.Drawing.Point(271, 86);
            this.lblCurrentCoLim.Name = "lblCurrentCoLim";
            this.lblCurrentCoLim.Size = new System.Drawing.Size(47, 15);
            this.lblCurrentCoLim.TabIndex = 24;
            this.lblCurrentCoLim.Text = "5.95";
            // 
            // lblCurrentHumLim
            // 
            this.lblCurrentHumLim.AutoSize = true;
            this.lblCurrentHumLim.BackColor = System.Drawing.Color.White;
            this.lblCurrentHumLim.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentHumLim.ForeColor = System.Drawing.Color.Black;
            this.lblCurrentHumLim.Location = new System.Drawing.Point(271, 58);
            this.lblCurrentHumLim.Name = "lblCurrentHumLim";
            this.lblCurrentHumLim.Size = new System.Drawing.Size(47, 15);
            this.lblCurrentHumLim.TabIndex = 23;
            this.lblCurrentHumLim.Text = "3.95";
            // 
            // lblCurrentTempLim
            // 
            this.lblCurrentTempLim.AutoSize = true;
            this.lblCurrentTempLim.BackColor = System.Drawing.Color.White;
            this.lblCurrentTempLim.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentTempLim.ForeColor = System.Drawing.Color.Black;
            this.lblCurrentTempLim.Location = new System.Drawing.Point(271, 29);
            this.lblCurrentTempLim.Name = "lblCurrentTempLim";
            this.lblCurrentTempLim.Size = new System.Drawing.Size(47, 15);
            this.lblCurrentTempLim.TabIndex = 22;
            this.lblCurrentTempLim.Text = "1.95";
            // 
            // btmCurrentLim
            // 
            this.btmCurrentLim.BackColor = System.Drawing.Color.DimGray;
            this.btmCurrentLim.FlatAppearance.BorderSize = 0;
            this.btmCurrentLim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btmCurrentLim.Font = new System.Drawing.Font("Copperplate Gothic Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btmCurrentLim.ForeColor = System.Drawing.Color.White;
            this.btmCurrentLim.Location = new System.Drawing.Point(188, 285);
            this.btmCurrentLim.Name = "btmCurrentLim";
            this.btmCurrentLim.Size = new System.Drawing.Size(229, 50);
            this.btmCurrentLim.TabIndex = 22;
            this.btmCurrentLim.Text = "See Current Limits";
            this.btmCurrentLim.UseVisualStyleBackColor = false;
            this.btmCurrentLim.Click += new System.EventHandler(this.btmCurrentLim_Click);
            // 
            // btmModLim
            // 
            this.btmModLim.BackColor = System.Drawing.Color.DimGray;
            this.btmModLim.FlatAppearance.BorderSize = 0;
            this.btmModLim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btmModLim.Font = new System.Drawing.Font("Copperplate Gothic Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btmModLim.ForeColor = System.Drawing.Color.White;
            this.btmModLim.Location = new System.Drawing.Point(0, 285);
            this.btmModLim.Name = "btmModLim";
            this.btmModLim.Size = new System.Drawing.Size(188, 50);
            this.btmModLim.TabIndex = 23;
            this.btmModLim.Text = "Modify Limits";
            this.btmModLim.UseVisualStyleBackColor = false;
            this.btmModLim.Click += new System.EventHandler(this.btmModLim_Click);
            // 
            // pnlModLim
            // 
            this.pnlModLim.Controls.Add(this.label3);
            this.pnlModLim.Controls.Add(this.label5);
            this.pnlModLim.Controls.Add(this.thresholdcmbx);
            this.pnlModLim.Controls.Add(this.thresholdbtn);
            this.pnlModLim.Controls.Add(this.thresholdtbx);
            this.pnlModLim.Font = new System.Drawing.Font("Copperplate Gothic Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlModLim.Location = new System.Drawing.Point(0, 334);
            this.pnlModLim.Name = "pnlModLim";
            this.pnlModLim.Size = new System.Drawing.Size(417, 164);
            this.pnlModLim.TabIndex = 24;
            // 
            // pnlCurrentLim
            // 
            this.pnlCurrentLim.Controls.Add(this.lblCurrentTvocLim);
            this.pnlCurrentLim.Controls.Add(this.label11);
            this.pnlCurrentLim.Controls.Add(this.label10);
            this.pnlCurrentLim.Controls.Add(this.label8);
            this.pnlCurrentLim.Controls.Add(this.lblCurrentTempLim);
            this.pnlCurrentLim.Controls.Add(this.label9);
            this.pnlCurrentLim.Controls.Add(this.lblCurrentCoLim);
            this.pnlCurrentLim.Controls.Add(this.lblCurrentHumLim);
            this.pnlCurrentLim.Font = new System.Drawing.Font("Copperplate Gothic Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlCurrentLim.Location = new System.Drawing.Point(0, 334);
            this.pnlCurrentLim.Name = "pnlCurrentLim";
            this.pnlCurrentLim.Size = new System.Drawing.Size(375, 164);
            this.pnlCurrentLim.TabIndex = 25;
            // 
            // lbl7
            // 
            this.lbl7.AutoSize = true;
            this.lbl7.BackColor = System.Drawing.Color.White;
            this.lbl7.Font = new System.Drawing.Font("Copperplate Gothic Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl7.ForeColor = System.Drawing.Color.Black;
            this.lbl7.Location = new System.Drawing.Point(13, 516);
            this.lbl7.Name = "lbl7";
            this.lbl7.Size = new System.Drawing.Size(195, 18);
            this.lbl7.TabIndex = 26;
            this.lbl7.Text = "North Window No. 1:";
            // 
            // lbl8
            // 
            this.lbl8.AutoSize = true;
            this.lbl8.BackColor = System.Drawing.Color.White;
            this.lbl8.Font = new System.Drawing.Font("Copperplate Gothic Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl8.ForeColor = System.Drawing.Color.Black;
            this.lbl8.Location = new System.Drawing.Point(9, 568);
            this.lbl8.Name = "lbl8";
            this.lbl8.Size = new System.Drawing.Size(195, 18);
            this.lbl8.TabIndex = 27;
            this.lbl8.Text = "North Window No. 2:";
            // 
            // lbl9
            // 
            this.lbl9.AutoSize = true;
            this.lbl9.BackColor = System.Drawing.Color.White;
            this.lbl9.Font = new System.Drawing.Font("Copperplate Gothic Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl9.ForeColor = System.Drawing.Color.Black;
            this.lbl9.Location = new System.Drawing.Point(214, 516);
            this.lbl9.Name = "lbl9";
            this.lbl9.Size = new System.Drawing.Size(136, 18);
            this.lbl9.TabIndex = 28;
            this.lbl9.Text = "West Window:";
            // 
            // lbl10
            // 
            this.lbl10.AutoSize = true;
            this.lbl10.BackColor = System.Drawing.Color.White;
            this.lbl10.Font = new System.Drawing.Font("Copperplate Gothic Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl10.ForeColor = System.Drawing.Color.Black;
            this.lbl10.Location = new System.Drawing.Point(205, 568);
            this.lbl10.Name = "lbl10";
            this.lbl10.Size = new System.Drawing.Size(170, 18);
            this.lbl10.TabIndex = 29;
            this.lbl10.Text = "AC Power Output:";
            // 
            // lblWindow1
            // 
            this.lblWindow1.AutoSize = true;
            this.lblWindow1.BackColor = System.Drawing.Color.White;
            this.lblWindow1.Font = new System.Drawing.Font("Copperplate Gothic Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWindow1.ForeColor = System.Drawing.Color.Black;
            this.lblWindow1.Location = new System.Drawing.Point(13, 534);
            this.lblWindow1.Name = "lblWindow1";
            this.lblWindow1.Size = new System.Drawing.Size(72, 18);
            this.lblWindow1.TabIndex = 30;
            this.lblWindow1.Text = "Closed";
            // 
            // lblWindow2
            // 
            this.lblWindow2.AutoSize = true;
            this.lblWindow2.BackColor = System.Drawing.Color.White;
            this.lblWindow2.Font = new System.Drawing.Font("Copperplate Gothic Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWindow2.ForeColor = System.Drawing.Color.Black;
            this.lblWindow2.Location = new System.Drawing.Point(9, 586);
            this.lblWindow2.Name = "lblWindow2";
            this.lblWindow2.Size = new System.Drawing.Size(72, 18);
            this.lblWindow2.TabIndex = 31;
            this.lblWindow2.Text = "Closed";
            // 
            // lblWindow3
            // 
            this.lblWindow3.AutoSize = true;
            this.lblWindow3.BackColor = System.Drawing.Color.White;
            this.lblWindow3.Font = new System.Drawing.Font("Copperplate Gothic Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWindow3.ForeColor = System.Drawing.Color.Black;
            this.lblWindow3.Location = new System.Drawing.Point(214, 534);
            this.lblWindow3.Name = "lblWindow3";
            this.lblWindow3.Size = new System.Drawing.Size(72, 18);
            this.lblWindow3.TabIndex = 32;
            this.lblWindow3.Text = "Closed";
            // 
            // lblAcOutput
            // 
            this.lblAcOutput.AutoSize = true;
            this.lblAcOutput.BackColor = System.Drawing.Color.White;
            this.lblAcOutput.Font = new System.Drawing.Font("Copperplate Gothic Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAcOutput.ForeColor = System.Drawing.Color.Black;
            this.lblAcOutput.Location = new System.Drawing.Point(205, 586);
            this.lblAcOutput.Name = "lblAcOutput";
            this.lblAcOutput.Size = new System.Drawing.Size(33, 18);
            this.lblAcOutput.TabIndex = 33;
            this.lblAcOutput.Text = "0%";
            // 
            // timer3
            // 
            this.timer3.Enabled = true;
            this.timer3.Interval = 4000;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(405, 713);
            this.Controls.Add(this.lblAcOutput);
            this.Controls.Add(this.lblWindow3);
            this.Controls.Add(this.lblWindow2);
            this.Controls.Add(this.lblWindow1);
            this.Controls.Add(this.lbl10);
            this.Controls.Add(this.lbl9);
            this.Controls.Add(this.lbl8);
            this.Controls.Add(this.lbl7);
            this.Controls.Add(this.pnlModLim);
            this.Controls.Add(this.btmModLim);
            this.Controls.Add(this.btmCurrentLim);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblTopBar);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnVentilation);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checklbl);
            this.Controls.Add(this.lblReading);
            this.Controls.Add(this.tvoclbl);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.co2lbl);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.humiditylbl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.temperatureValuelbl);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.pnlCurrentLim);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlModLim.ResumeLayout(false);
            this.pnlModLim.PerformLayout();
            this.pnlCurrentLim.ResumeLayout(false);
            this.pnlCurrentLim.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Label temperatureValuelbl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label humiditylbl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label co2lbl;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label tvoclbl;
        private System.Windows.Forms.Label lblReading;
        private System.Windows.Forms.Label checklbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox thresholdcmbx;
        private System.Windows.Forms.TextBox thresholdtbx;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button thresholdbtn;
        private System.Windows.Forms.Button btnVentilation;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblTopBar;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblCurrentTvocLim;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblCurrentCoLim;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblCurrentHumLim;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblCurrentTempLim;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btmCurrentLim;
        private System.Windows.Forms.Button btmModLim;
        private System.Windows.Forms.Panel pnlModLim;
        private System.Windows.Forms.Panel pnlCurrentLim;
        private System.Windows.Forms.Label lbl7;
        private System.Windows.Forms.Label lbl8;
        private System.Windows.Forms.Label lbl9;
        private System.Windows.Forms.Label lbl10;
        private System.Windows.Forms.Label lblWindow1;
        private System.Windows.Forms.Label lblWindow2;
        private System.Windows.Forms.Label lblWindow3;
        private System.Windows.Forms.Label lblAcOutput;
        private System.Windows.Forms.Timer timer3;
    }
}

