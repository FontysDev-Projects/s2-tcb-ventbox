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

namespace VentilationBox
{
    public partial class Ventilation : Form
    {
        double temperature = 10;
        double targetTemperature = 10;
        double time = 0.1;

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
            //
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

        public void Ventilate(ref double temperature, ref double targetTemperature)
        {
            double difference = targetTemperature - temperature;
            temperature = temperature + (difference * 0.05);
        }

       

        private void timer1_Tick(object sender, EventArgs e)
        {

            Ventilate(ref temperature, ref targetTemperature); 
            time = Math.Round(time, 1);
            
            chart1.Series[0].Points.AddXY(time, temperature);
            chart1.ChartAreas[0].AxisX.Minimum = chart1.Series[0].Points[0].XValue;
            chart1.ChartAreas[0].AxisX.Maximum = time;
            chart1.ChartAreas[0].AxisY.Minimum = 0;
            chart1.ChartAreas[0].AxisY.Maximum = 40;
            chart1.ChartAreas[0].AxisY.Interval = 5;


            if (chart1.Series[0].Points.Count > 10)
            {
                chart1.Series[0].Points.Remove(chart1.Series[0].Points[0]);
            }
            time += 0.10;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblTopBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}
