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
        public Form1()
        {
            InitializeComponent();
            serialPort1.Open();
        }
        string getParameterName(string command, int position)
        {
            
            string parameterName = "";
            parameterName += command[position + 1];
            parameterName += command[position + 2];
            return parameterName;
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
        void showParameter(string parameterName,string parameterValue)
        {
            if (parameterName == "te")
            {
                temperatureValuelbl.Text = parameterValue;
            }
            else if (parameterName == "hu")
            {
                humiditylbl.Text = parameterValue;
            }
            else if (parameterName == "co")
            {
                co2lbl.Text = parameterValue;
            }
            else if (parameterName == "vo")
            {
                tvoclbl.Text = parameterValue;
            }
        }

        void getData(string command)
        {
            for (int i = 0; i < command.Length; i++)
            {
                if(command[i] == '#')
                {
                    showParameter(getParameterName(command, i), getParameterValue(command, i + 4));
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
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            string filePath = @"C:\Users\Victor\source\repos\VentilationBox\ventilationBoxLogs.txt";
            File.AppendAllText(filePath, DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss") + Environment.NewLine);
            File.AppendAllText(filePath, "Temperature: " + temperatureValuelbl.Text + " ");
            File.AppendAllText(filePath, "Humidity: " + humiditylbl.Text + " ");
            File.AppendAllText(filePath, "CO2: " + co2lbl.Text + " ");
            File.AppendAllText(filePath, "VOC: " + tvoclbl.Text + Environment.NewLine);
        }
    }
}
