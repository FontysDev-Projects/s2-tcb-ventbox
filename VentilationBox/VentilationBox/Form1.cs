using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Runtime.InteropServices;

namespace VentilationBox
{
    public partial class Form1 : Form
    {
        bool alert = false;
        string filePath = @"C:\Users\Victor\source\repos\VentilationBox\ventilationBoxLogs.txt";
        double tempValue;
        double humValue;
        double coValue;
        double tvocValue;
        double tempLim = 1.95;
        double humLim = 3.95;
        double coLim = 5.95;
        double tvocLim = 7.95;

        //rounded corners
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );

        //
       
        //move window
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        private void label7_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        //

        Ventilation ventilation; //The window for the ventilation and the algorithm.
        public Form1()
        {
            InitializeComponent();
            
            serialPort1.Open();
            checklbl.Text = check.ToString();
            File.AppendAllText(filePath, "0 < Temperature < 1.95" + Environment.NewLine);
            File.AppendAllText(filePath, "2 < Humidity < 3.95" + Environment.NewLine);
            File.AppendAllText(filePath, "4 < CO2 < 5.95" + Environment.NewLine);
            File.AppendAllText(filePath, "6 < TVOC < 7.95" + Environment.NewLine);
            File.AppendAllText(filePath, "Start time: ");
            File.AppendAllText(filePath, DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss") + Environment.NewLine);
            File.AppendAllText(filePath, Environment.NewLine);

            //

            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            //
            
        }

        double check = 0;

        void updateSum()
        {
            check = tempValue + humValue + coValue + tvocValue;
            checklbl.Text = check.ToString();
        }

        void resetLogTimer(Timer timer)
        {
            timer.Stop();
            timer.Start();
        }

        void logData()
        {            
            File.AppendAllText(filePath, "~~~~~~~~~~ " + Environment.NewLine);
            File.AppendAllText(filePath, DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss") + Environment.NewLine);
            File.AppendAllText(filePath, "Temperature: " + temperatureValuelbl.Text + " ");
            File.AppendAllText(filePath, "Humidity: " + humiditylbl.Text + " ");
            File.AppendAllText(filePath, "CO2: " + co2lbl.Text + " ");
            File.AppendAllText(filePath, "VOC: " + tvoclbl.Text + Environment.NewLine);
            File.AppendAllText(filePath, Environment.NewLine);
        }
        void logAlertData()
        {
            File.AppendAllText(filePath, "!!!!!!!!!!!!!! " + Environment.NewLine);
            File.AppendAllText(filePath, DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss") + Environment.NewLine);
            File.AppendAllText(filePath, "Temperature: " + temperatureValuelbl.Text + " ");
            File.AppendAllText(filePath, "Humidity: " + humiditylbl.Text + " ");
            File.AppendAllText(filePath, "CO2: " + co2lbl.Text + " ");
            File.AppendAllText(filePath, "VOC: " + tvoclbl.Text + Environment.NewLine);
            File.AppendAllText(filePath, Environment.NewLine);
        }

        bool checkAlarm(double value, double limit)
        {
            if(value > limit)
            {
                return true;
            }
            else
            {
                
                return false;
            }
              
        }

        double tempOutside()
        {
            return 0;
        }
        double humOutside()
        {
            return 1;
        }
        

        void takeActionTemp(double value, double limit)
        {
            double percent = 100 - ((100 * limit) / value);
            if(value > tempOutside())
            {
                if(percent > 1)
                {
                    lblWindow1.Text = "Open";
                }
                if(percent > 10)
                {
                    lblWindow2.Text = "Open";
                }
                if(percent > 25)
                {
                    lblWindow3.Text = "Open";
                }
            }
            else
            {
                if (percent < 25)
                {
                    lblAcOutput.Text = "90%";
                }
                else if (percent < 10)
                {
                    lblAcOutput.Text = "60%";
                }
                else if (percent < 1)
                {
                    lblAcOutput.Text = "30%";
                }
            }
        }
        void takeActionHum(double value, double limit)
        {
            double percent = 100 - ((100 * limit) / value);
            if (value > humOutside())
            {
                if (percent > 1)
                {
                    lblWindow1.Text = "Open";
                }
                if (percent > 10)
                {
                    lblWindow2.Text = "Open";
                }
                if (percent > 25)
                {
                    lblWindow3.Text = "Open";
                }
            }
            else
            {
                if (percent > 1)
                {
                    lblAcOutput.Text = "30%";
                }
                else if (percent > 10)
                {
                    lblAcOutput.Text = "60%";
                }
                else if (percent > 25)
                {
                    lblAcOutput.Text = "90%";
                }
            }
        }
        void takeActionCoTvoc(double value, double limit)
        {
            double percent = 100 - ((100 * limit) / value);
            if (percent > 1)
            {
                lblAcOutput.Text = "30%";
            }
            else if (percent > 10)
            {
                lblAcOutput.Text = "60%";
            }
            else if (percent > 25)
            {
                lblAcOutput.Text = "90%";
            }
        }  
        

        string getParameterName(string command, int position)
        {
            
            string parameterName = "";
            parameterName += command[position + 1];
            parameterName += command[position + 2];
            // command[position + 3]
            return parameterName;
        }
        bool getParameterState(string command, int position)
        {
            if(command[position] == '!')
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        string getParameterValue(string command, int position)
        {
            string parameterValue = "";
            do
            {
                parameterValue += command[position];
                position++;
            }
            while (command[position] != '-');
            return parameterValue;
        }

        double setParameter(string parameterValue, bool parameterState, Label parameterLabel, string parameterAlert)
        {
            if (parameterState)
            {
                File.AppendAllText(filePath, parameterAlert + Environment.NewLine);
                parameterLabel.ForeColor = Color.Red;
                alert = true;
            }
            else
            {
                parameterLabel.ForeColor = Color.Black;
            }
            parameterLabel.Text = parameterValue;
           
            return Convert.ToDouble(parameterValue);
        }

        void showParameter(string parameterName,string parameterValue, bool parameterState)
        {
            if (parameterName == "te")
            {
                tempValue = setParameter(parameterValue, parameterState, temperatureValuelbl, "Temperature alert! ");
                if(checkAlarm(tempValue, tempLim))
                {
                    takeActionTemp(tempValue, tempLim);
                }
                
            }
            else if (parameterName == "hu")
            {
                humValue = setParameter(parameterValue, parameterState, humiditylbl, "Humidity alert! ");
                if (checkAlarm(humValue, humLim))
                {
                    takeActionHum(humValue, humLim);
                }
            }
            else if (parameterName == "co")
            {
                coValue = setParameter(parameterValue, parameterState, co2lbl, "CO2 alert! ");
                if (checkAlarm(coValue, coLim))
                {
                    takeActionCoTvoc(coValue, coLim);
                }
            }
            else if (parameterName == "vo")
            {
                tvocValue = setParameter(parameterValue, parameterState, tvoclbl, "TVOC alert! ");
                if (checkAlarm(tvocValue, tvocLim))
                {
                    takeActionCoTvoc(tvocValue, tvocLim);
                }
            }
        }

        void getData(string command)
        {
            for (int i = 0; i < command.Length; i++)
            {
                if(command[i] == '#')
                {
                    showParameter(getParameterName(command, i), getParameterValue(command, i + 4), getParameterState(command, i + 3));
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // $#te-data-#hu-data-#co-data-#vo-data-%
            // te-data-
            // hu-data-
            // and so on...
            string commandSent = serialPort1.ReadExisting().Trim();
            string commandToDo = "";
            for(int i = 0; i < commandSent.Length; i++)
            {
                if(commandSent[i] == '%')
                {
                    commandToDo += commandSent[i];
                    break;
                }
                commandToDo += commandSent[i];
            }
            if (commandToDo != "")
            {
                lblReading.Text = commandToDo;
                if (commandToDo[0] == '$')
                {
                    
                    getData(commandToDo);
                }  
            }
            if(alert)
            {
                logAlertData();
                alert = false;
                updateSum();
                resetLogTimer(timer2);
            }
            
            
        }

        
        
        private void timer2_Tick(object sender, EventArgs e)
        {
            logData();
            updateSum();
            
        }

        String parameterThresholdName()
        {
            String paramThreshold = "";
            switch (thresholdcmbx.SelectedIndex)
            {
                case 0:
                    paramThreshold += "te";
                    break;
                case 1:
                    paramThreshold += "hu";
                    break;
                case 2:
                    paramThreshold += "co";
                    break;
                case 3:
                    paramThreshold += "vo";
                    break;
                default:
                    break;
            }
            return "(" + paramThreshold + "-";
        }

        String parameterThresholdValue()
        {
            return thresholdtbx.Text + ")";
        }

        String thresholdToSend()
        {
            return parameterThresholdName() + parameterThresholdValue();
        }

        private void thresholdbtn_Click(object sender, EventArgs e)
        {
            serialPort1.Write(thresholdToSend());
            switch (thresholdcmbx.SelectedIndex)
            {
                case 0:
                    lblCurrentTempLim.Text = thresholdtbx.Text;
                    tempLim = Convert.ToDouble(lblCurrentTempLim.Text);
                    break;
                case 1:
                    lblCurrentHumLim.Text = thresholdtbx.Text;
                    humLim = Convert.ToDouble(lblCurrentTempLim.Text);
                    break;
                case 2:
                    lblCurrentCoLim.Text = thresholdtbx.Text;
                    coLim = Convert.ToDouble(lblCurrentTempLim.Text);
                    break;
                case 3:
                    lblCurrentTvocLim.Text = thresholdtbx.Text;
                    tvocLim = Convert.ToDouble(lblCurrentTempLim.Text);
                    break;
                default:
                    break;
            }
        }

        private void btnVentilation_Click(object sender, EventArgs e)
        {
            ventilation = new Ventilation();

            if (ventilation.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Success.");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btmModLim_Click(object sender, EventArgs e)
        {
            pnlCurrentLim.Visible = false;
            pnlModLim.Visible = true;
        }

        private void btmCurrentLim_Click(object sender, EventArgs e)
        {
            pnlCurrentLim.Visible = true;
            pnlModLim.Visible = false;
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (alert == false)
            {
                lblWindow1.Text = "Closed";
                lblWindow2.Text = "Closed";
                lblWindow3.Text = "Closed";
                lblAcOutput.Text = "0%";
            }
        }
    }
}
