using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Windows.Forms.DataVisualization.Charting;

namespace VentilationBox
{

    public enum Source
    {
        TEMPERATURE,
        HUMIDITY,
        VOC,
        CO2,
        SIMULATION
    }
    public partial class Ventilation : Form
    {
        Source source;
        double temperature = 10;
        double targetTemperature = 10;
        List<DateTime> TimeList = new List<DateTime>();

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

        public Ventilation()
        {
            InitializeComponent();
            //
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            this.chart1.ChartAreas[0].AxisX.LabelStyle.Format = "hh:mm:ss";
            // this sets the type of the X-Axis values
            chart1.Series[0].XValueType = ChartValueType.DateTime;
        }

        private void trackBarCurrentTemperature_Scroll(object sender, EventArgs e)
        {
            lblCurrentTemperature.Text = trackBarCurrentTemperature.Value.ToString();
            temperature = trackBarCurrentTemperature.Value;
        }

        private void trackBarTargetTemperature_Scroll(object sender, EventArgs e)
        {
            lblTargetTemperature.Text = trackBarTargetTemperature.Value.ToString();
            targetTemperature = trackBarTargetTemperature.Value;
        }

        public double Ventilate(ref double temperature, ref double targetTemperature)
        {
            double difference = targetTemperature - temperature;
            temperature = temperature + (difference * 0.05);
            return temperature;
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime start = DateTime.Now.AddSeconds(-5);
            DateTime end = DateTime.Now.AddSeconds(5);
            DateTime now = DateTime.Now;
            double value = 0;
            TimeList.Add(now);
            switch (source)
            {
                case Source.TEMPERATURE:
                    value = Form1.tempValue;
                    chart1.Series[0].LegendText = "Temperature";
                    chart1.ChartAreas[0].AxisY.Minimum = 0;
                    chart1.ChartAreas[0].AxisY.Maximum = 40;
                    chart1.ChartAreas[0].AxisY.Interval = 5;
                    chart1.ChartAreas[0].AxisY.MajorGrid.Interval = 5;

                    break;
                case Source.HUMIDITY:
                    value = Form1.humValue;
                    chart1.Series[0].LegendText = "Humidity";
                    chart1.ChartAreas[0].AxisY.Minimum = 0;
                    chart1.ChartAreas[0].AxisY.Maximum = 100;
                    chart1.ChartAreas[0].AxisY.Interval = 5;
                    chart1.ChartAreas[0].AxisY.MajorGrid.Interval = 5;
                    break;
                case Source.VOC:
                    value = Form1.tvocValue;
                    chart1.Series[0].LegendText = "VOC";
                    chart1.ChartAreas[0].AxisY.Minimum = 0;
                    chart1.ChartAreas[0].AxisY.Maximum = 2000;
                    chart1.ChartAreas[0].AxisY.Interval = 100;
                    chart1.ChartAreas[0].AxisY.MajorGrid.Interval = 100;
                    break;
                case Source.CO2:
                    value = Form1.coValue;
                    chart1.Series[0].LegendText = "CO₂";
                    chart1.ChartAreas[0].AxisY.Minimum = 0;
                    chart1.ChartAreas[0].AxisY.Maximum = 4000;
                    chart1.ChartAreas[0].AxisY.Interval = 200;
                    chart1.ChartAreas[0].AxisY.MajorGrid.Interval = 200;
                    break;
                case Source.SIMULATION:
                    value = Ventilate(ref temperature, ref targetTemperature);
                    chart1.Series[0].LegendText = "Temperature";
                    chart1.ChartAreas[0].AxisY.Minimum = 0;
                    chart1.ChartAreas[0].AxisY.Maximum = 40;
                    chart1.ChartAreas[0].AxisY.Interval = 5;
                    chart1.ChartAreas[0].AxisY.MajorGrid.Interval = 5;
                    break;
                default:
                    break;
            }

            chart1.Series[0].Points.AddXY(now.ToOADate(), value);
            chart1.ChartAreas[0].AxisX.Minimum = start.ToOADate();
            chart1.ChartAreas[0].AxisX.Maximum = end.ToOADate();
            Console.WriteLine(start.ToOADate().ToString());
            Console.WriteLine(now.ToOADate().ToString());
            Console.WriteLine(end.ToOADate().ToString());



            if (chart1.Series[0].Points.Count > 100)
            {
                chart1.Series[0].Points.Remove(chart1.Series[0].Points[0]);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }
            switch (cmbMode.SelectedIndex)
            {
                case 0:
                    source = Source.TEMPERATURE;
                    break;
                case 1:
                    source = Source.HUMIDITY;
                    break;
                case 2:
                    source = Source.VOC;
                    break;
                case 3:
                    source = Source.CO2;
                    break;
                case 4:
                    source = Source.SIMULATION;
                    break;
                default:
                    break;
            }
        }
    }
}
