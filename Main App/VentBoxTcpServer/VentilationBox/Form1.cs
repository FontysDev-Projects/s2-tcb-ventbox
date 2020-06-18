using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.Linq;

namespace VentilationBox
{
    public partial class Form1 : Form
    {
        //The window for the ventilation and the algorithm.
        Ventilation ventilation;
        // HTTPClient is an interface class used to connect to obshtiq server 
        HTTPClient HTTPClient = new HTTPClient();
        //String where the message received by the ESP will be stored
        public static String message = "";
        //filepath, boolean and doubles for values and valLimits
        string filePath = @"..\..\..\..\VentBoxTcpServer\ventilationBoxLogs.txt";
        public static double tempValue, humValue, coValue, tvocValue, tempLim = 1.95, humLim = 3.95, coLim = 5.95, tvocLim = 750, sumReadings = 0;
        bool alert = false;
        //TEMPORARY DOUBLES
        double tempOutside = 0, humOutside = 1;

        public static int test = 0;

        //Rounded corners for rectangle(UI)
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

        //Move window
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


        //Initialization Phase (ports, dataFile, etc.)
        public Form1()
        {
            InitializeComponent();
            //serialPort1.Open();
            checklbl.Text = sumReadings.ToString();
            File.AppendAllText(filePath, $"0 < Temperature < {tempLim}" + Environment.NewLine);
            File.AppendAllText(filePath, $"2 < Humidity < {humLim}" + Environment.NewLine);
            File.AppendAllText(filePath, $"4 < CO2 < {coLim}" + Environment.NewLine);
            File.AppendAllText(filePath, $"6 < TVOC < {tvocLim}" + Environment.NewLine);
            File.AppendAllText(filePath, $"Start time: {DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss")}" + Environment.NewLine + Environment.NewLine);

            this.FormBorderStyle = FormBorderStyle.None;
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

            //Starting the server for the wireless communication
            Thread t = new Thread(delegate ()
            {
                // replace the IP with your system IP Address...
                Server myserver = new Server("172.27.208.139", 8888, message);
            });
            t.Start();

            // Starts the HttpClient
            this.HTTPClient = new HTTPClient();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.HTTPClient.Close();
            this.ventilation.Close();
        }

        /// <summary>
        /// Updates the sum of all sensor-read values
        /// </summary>
        void updateSum()
        {
            sumReadings = tempValue + humValue + coValue + tvocValue;
            checklbl.Text = sumReadings.ToString();
        }

        /// <summary>
        /// Resets timer
        /// </summary>
        /// <param name="timer"></param>
        void resetLogTimer(System.Windows.Forms.Timer timer)
        {
            timer.Stop(); timer.Start();
        }

        /// <summary>
        /// Logs data to external file
        /// </summary>
        void logData()
        {
            File.AppendAllText(filePath, "~~~~~~~~~~ " + Environment.NewLine);
            File.AppendAllText(filePath, DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss") + Environment.NewLine);
            File.AppendAllText(filePath, "Temperature: " + temperatureValuelbl.Text + " ");
            File.AppendAllText(filePath, "Humidity: " + humiditylbl.Text + " ");
            File.AppendAllText(filePath, "CO2: " + co2lbl.Text + " ");
            File.AppendAllText(filePath, "VOC: " + tvoclbl.Text + Environment.NewLine + Environment.NewLine);
        }

        /// <summary>
        /// Logs data in case of alerts
        /// </summary>
        void logAlertData()
        {
            File.AppendAllText(filePath, "!!!!!!!!!!!!!! " + Environment.NewLine);
            File.AppendAllText(filePath, DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss") + Environment.NewLine);
            File.AppendAllText(filePath, "Temperature: " + temperatureValuelbl.Text + " ");
            File.AppendAllText(filePath, "Humidity: " + humiditylbl.Text + " ");
            File.AppendAllText(filePath, "CO2: " + co2lbl.Text + " ");
            File.AppendAllText(filePath, "VOC: " + tvoclbl.Text + Environment.NewLine + Environment.NewLine);
        }

        /// <summary>
        /// Checks if value has passed its parameters
        /// </summary>
        /// <param name="value"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        bool checkAlarm(double value, double limit)
        {
            if (value > limit)
                return true;
            return false;
        }

        /// <summary>
        /// Actions taken depending on temperature(window, ac-output, etc.)
        /// </summary>
        /// <param name="value"></param>
        /// <param name="limit"></param>
        void takeActionTemp(double roomTemp, double limit)
        {
            double percent = 100 - ((100 * limit) / roomTemp);
            if (roomTemp > tempOutside)
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
                if (percent > 25)
                {
                    lblAcOutput.Text = "90%";
                }
                else if (percent > 10)
                {
                    lblAcOutput.Text = "60%";
                }
                else if (percent > 1)
                {
                    lblAcOutput.Text = "30%";
                }
            }
        }

        /// <summary>
        /// Actions taken depending on humidity
        /// </summary>
        /// <param name="value"></param>
        /// <param name="limit"></param>
        void takeActionHum(double roomHum, double limit)
        {
            double percent = 100 - ((100 * limit) / roomHum);
            if (roomHum > humOutside)
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

        /// <summary>
        /// Actions taken depending on CO2 and TVOC
        /// </summary>
        /// <param name="value"></param>
        /// <param name="limit"></param>
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
        string getParameterName(string command, int index)
        {
            int start = 0;
            if (index == 0)
            {
                string parameterName = "";
                int end = command.IndexOf('-');
                parameterName = command.Substring(1, end - 1);
                return parameterName;
            }
            else
            {
                do
                {
                    start = command.IndexOf('&');
                    if (start == -1)
                    {
                        throw new Exception("Couldn't find that index measurement");
                    }
                    start++;
                    index--;
                } while (index > 0);
                int end = command.IndexOf('-', start);
                return command.Substring(start, end - start);
            }
        }

        String getParameterValue(string command, int index)
        {
            int start = 0;
            if (index == 0)
            {
                String parameterValue = "";
                start = command.IndexOf('-');
                start++;
                int end = command.IndexOf('&');
                if (end == -1)
                {
                    end = command.Length - 1;
                }
                parameterValue = command.Substring(start, end - start);
                return parameterValue;
            }
            else
            {
                start = command.IndexOf('-');
                start++;
                do
                {
                    start = command.IndexOf('-', start);
                    if (start == -1)
                    {
                        throw new Exception("Couldn't find that index measurement");
                    }
                    start++;
                    index--;
                } while (index > 0);
                int end = command.IndexOf('&', start);
                if (end == -1)
                {
                    end = command.Length - 1;
                }
                return command.Substring(start, end - start );
            }
        }

        double setParameter(string parameterValue, double parameterLimit, Label parameterLabel, string parameterAlert)
        {
            double parameterDoubleValue = Convert.ToDouble(parameterValue);
            if (parameterDoubleValue > parameterLimit)
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
            switch (parameterAlert)
            {
                case "Temperature alert! ":
                    parameterLabel.Text += " °C";
                    break;
                case "Humidity alert! ":
                    parameterLabel.Text += " %";
                    break;
                case "CO2 alert! ":
                    parameterLabel.Text += " ppm";
                    break;
                case "TVOC alert! ":
                    parameterLabel.Text += " ppm";
                    break;
                default:
                    break;
            }


            return parameterDoubleValue;
        }

        void showParameter(string parameterName, string parameterValue)
        {
            if (parameterName == "te")
            {
                tempValue = setParameter(parameterValue, tempLim, temperatureValuelbl, "Temperature alert! ");
                if (checkAlarm(tempValue, tempLim))
                {
                    takeActionTemp(tempValue, tempLim);
                }

            }
            else if (parameterName == "hu")
            {
                humValue = setParameter(parameterValue, humLim, humiditylbl, "Humidity alert! ");
                if (checkAlarm(humValue, humLim))
                {
                    takeActionHum(humValue, humLim);
                }

            }
            else if (parameterName == "co")
            {
                coValue = setParameter(parameterValue, coLim, co2lbl, "CO2 alert! ");
                if (checkAlarm(coValue, coLim))
                {
                    takeActionCoTvoc(coValue, coLim);
                }

            }
            else if (parameterName == "voc")
            {
                tvocValue = setParameter(parameterValue, tvocLim, tvoclbl, "TVOC alert! ");
                if (checkAlarm(tvocValue, tvocLim))
                {
                    takeActionCoTvoc(tvocValue, tvocLim);
                }

            }
        }

        void getData(string command)
        {
            if (command.Contains('&'))
            {
                showParameter(getParameterName(command, 0), getParameterValue(command, 0));
                showParameter(getParameterName(command, 1), getParameterValue(command, 1));
                Console.WriteLine(getParameterName(command, 0));
                Console.WriteLine(getParameterValue(command, 0));
                Console.WriteLine(getParameterName(command, 1));
                Console.WriteLine(getParameterValue(command, 1));
            }
            else
            {
                showParameter(getParameterName(command, 0), getParameterValue(command, 0));
            }
        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            // $#te-data-#hu-data-#co-data-#vo-data-%
            // te-data-
            // hu-data-
            // and so on...
            string commandSent = message;
            string commandToDo = "";
            for (int i = 0; i < commandSent.Length; i++)
            {
                if (commandSent[i] == '%')
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
            if (alert)
            {
                logAlertData();
                alert = false;
                updateSum();
                resetLogTimer(timer2);
            }
            await HTTPClient.Send(tempValue.ToString(), humValue.ToString(), tvocValue.ToString(), coValue.ToString());
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            logData(); updateSum();
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
            switch (thresholdcmbx.SelectedIndex)
            {
                case 0:
                    tempLim = Convert.ToDouble(thresholdtbx.Text);
                    lblCurrentTempLim.Text = tempLim.ToString();
                    break;
                case 1:
                    humLim = Convert.ToDouble(thresholdtbx.Text);
                    lblCurrentHumLim.Text = humLim.ToString();
                    break;
                case 2:
                    coLim = Convert.ToDouble(thresholdtbx.Text);
                    lblCurrentCoLim.Text = coLim.ToString();
                    break;
                case 3:
                    tvocLim = Convert.ToDouble(thresholdtbx.Text);
                    lblCurrentTvocLim.Text = tvocLim.ToString();
                    break;
                default:
                    break;
            }
        }

        private void btnVentilation_Click(object sender, EventArgs e)
        {
            ventilation = new Ventilation();
            ventilation.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
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