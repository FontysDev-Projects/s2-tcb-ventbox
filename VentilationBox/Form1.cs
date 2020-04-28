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

namespace VentilationBox
{
    public partial class Form1 : Form
    { 
        int position;
        string logTemp = "";
        string logHum = "";
        string logCO = "";
        string logVOC = "";
        public Form1()
        {
            InitializeComponent();
            serialPort1.Open();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // t15h14c205v5f
            lblReading.Text = serialPort1.ReadExisting();
            string command = lblReading.Text;
            lblReading.Text = command;
          
            if (command != "")
            {
                string value = "";
                if (command[0] == 't')
                {
                    for (int i = 1; i < command.Length; i++)
                    {

                        if (command[i] == 'h')
                        {

                            temperatureValuelbl.Text = value;
                            logTemp = value;
                            position = i;
                            break;
                        }
                        else
                        {
                            value += command[i];
                            
                        }
                    }


                    value = "";
                    for (int i = position + 1; i < command.Length; i++)
                    {
                        if (command[i] == 'c')
                        {

                            humiditylbl.Text = value;
                            logHum = value;
                            position = i;
                            break;
                        }
                        else
                        {
                            value += command[i];
                            
                        }
                    }
                    value = "";
                    for (int i = position + 1; i < command.Length; i++)
                    {
                        if (command[i] == 'v')
                        {

                            co2lbl.Text = value;
                            logCO = value;
                            position = i;
                            break;
                        }
                        else
                        {
                            value += command[i];
                            
                        }
                    }
                    value = "";
                    for (int i = position + 1; i < command.Length; i++)
                    {
                        if (command[i] == 'f')
                        {
                            tvoclbl.Text = value;
                            logVOC = value;
                            position = i;
                            break;
                        }
                        else
                        {
                            value += command[i];
                        }
                    }
                }
            }
            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            string filePath = @"C:\Users\Victor\source\repos\VentilationBox\ventilationBoxLogs.txt";
            File.AppendAllText(filePath, DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss") + Environment.NewLine);
            File.AppendAllText(filePath, "Temperature: " + logTemp + " ");
            File.AppendAllText(filePath, "Humidity: " + logHum + " ");
            File.AppendAllText(filePath, "CO2: " + logCO + " ");
            File.AppendAllText(filePath, "VOC: " + logVOC + Environment.NewLine);
        }
    }
}
