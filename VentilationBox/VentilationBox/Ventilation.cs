using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VentilationBox
{
    public partial class Ventilation : Form
    {
        double temperature = 10;
        double targetTemperature = 10;
        double time = 0.1;
        Random random;
        public Ventilation()
        {
            InitializeComponent();
            random = new Random();
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

        private void TurnOnHeating()
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            Ventilate(ref temperature, ref targetTemperature); 
            time = Math.Round(time, 1);
            lblTemperature.Text = time.ToString();
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
    }
}
