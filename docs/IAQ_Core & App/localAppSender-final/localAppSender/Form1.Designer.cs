namespace localAppSender
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
            this.btnSendMessage = new System.Windows.Forms.Button();
            this.tbMessage = new System.Windows.Forms.TextBox();
            this.lbMessages = new System.Windows.Forms.ListBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.SuspendLayout();
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.Location = new System.Drawing.Point(753, 28);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(140, 65);
            this.btnSendMessage.TabIndex = 1;
            this.btnSendMessage.Text = "Send";
            this.btnSendMessage.UseVisualStyleBackColor = true;
            this.btnSendMessage.Click += new System.EventHandler(this.BtnSendMessage_Click);
            // 
            // tbMessage
            // 
            this.tbMessage.Location = new System.Drawing.Point(495, 28);
            this.tbMessage.Name = "tbMessage";
            this.tbMessage.Size = new System.Drawing.Size(252, 26);
            this.tbMessage.TabIndex = 2;
            // 
            // lbMessages
            // 
            this.lbMessages.FormattingEnabled = true;
            this.lbMessages.ItemHeight = 20;
            this.lbMessages.Location = new System.Drawing.Point(12, 121);
            this.lbMessages.Name = "lbMessages";
            this.lbMessages.Size = new System.Drawing.Size(735, 364);
            this.lbMessages.TabIndex = 3;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // serialPort1
            // 
            this.serialPort1.PortName = "COM6";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(927, 606);
            this.Controls.Add(this.lbMessages);
            this.Controls.Add(this.tbMessage);
            this.Controls.Add(this.btnSendMessage);
            this.Name = "Form1";
            this.Text = "Local App";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSendMessage;
        private System.Windows.Forms.TextBox tbMessage;
        private System.Windows.Forms.ListBox lbMessages;
        private System.Windows.Forms.Timer timer1;
        private System.IO.Ports.SerialPort serialPort1;
    }
}

