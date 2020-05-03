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
            this.lbl1 = new System.Windows.Forms.Label();
            this.temperatureValuelbl = new System.Windows.Forms.Label();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.humiditylbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.co2lbl = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tvoclbl = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblReading = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.checklbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.Location = new System.Drawing.Point(39, 31);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(119, 24);
            this.lbl1.TabIndex = 0;
            this.lbl1.Text = "Temperature";
            // 
            // temperatureValuelbl
            // 
            this.temperatureValuelbl.AutoSize = true;
            this.temperatureValuelbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.temperatureValuelbl.Location = new System.Drawing.Point(48, 100);
            this.temperatureValuelbl.Name = "temperatureValuelbl";
            this.temperatureValuelbl.Size = new System.Drawing.Size(14, 20);
            this.temperatureValuelbl.TabIndex = 1;
            this.temperatureValuelbl.Text = "-";
            // 
            // serialPort1
            // 
            this.serialPort1.PortName = "COM13";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // humiditylbl
            // 
            this.humiditylbl.AutoSize = true;
            this.humiditylbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.humiditylbl.Location = new System.Drawing.Point(173, 100);
            this.humiditylbl.Name = "humiditylbl";
            this.humiditylbl.Size = new System.Drawing.Size(14, 20);
            this.humiditylbl.TabIndex = 3;
            this.humiditylbl.Text = "-";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(164, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Humidity";
            // 
            // co2lbl
            // 
            this.co2lbl.AutoSize = true;
            this.co2lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.co2lbl.Location = new System.Drawing.Point(273, 100);
            this.co2lbl.Name = "co2lbl";
            this.co2lbl.Size = new System.Drawing.Size(14, 20);
            this.co2lbl.TabIndex = 5;
            this.co2lbl.Text = "-";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(273, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 24);
            this.label4.TabIndex = 4;
            this.label4.Text = "CO2";
            // 
            // tvoclbl
            // 
            this.tvoclbl.AutoSize = true;
            this.tvoclbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvoclbl.Location = new System.Drawing.Point(367, 100);
            this.tvoclbl.Name = "tvoclbl";
            this.tvoclbl.Size = new System.Drawing.Size(14, 20);
            this.tvoclbl.TabIndex = 7;
            this.tvoclbl.Text = "-";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(367, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 24);
            this.label6.TabIndex = 6;
            this.label6.Text = "VOC";
            // 
            // lblReading
            // 
            this.lblReading.AutoSize = true;
            this.lblReading.Location = new System.Drawing.Point(49, 179);
            this.lblReading.Name = "lblReading";
            this.lblReading.Size = new System.Drawing.Size(35, 13);
            this.lblReading.TabIndex = 8;
            this.lblReading.Text = "label1";
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 5000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // checklbl
            // 
            this.checklbl.AutoSize = true;
            this.checklbl.Location = new System.Drawing.Point(174, 149);
            this.checklbl.Name = "checklbl";
            this.checklbl.Size = new System.Drawing.Size(35, 13);
            this.checklbl.TabIndex = 9;
            this.checklbl.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 149);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Sum of the parameters: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 216);
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
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Label temperatureValuelbl;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label humiditylbl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label co2lbl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label tvoclbl;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblReading;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label checklbl;
        private System.Windows.Forms.Label label1;
    }
}

