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

namespace VentilationBox
{
    public partial class Form1 : Form
    {
        bool alert = false;
        string filePath = @"C:\Users\Victor\source\repos\VentilationBox\ventilationBoxLogs.txt";
        float tempValue;
        float humValue;
        float coValue;
        float tvocValue;
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

        }

        float check = 0;

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
            while (command[position] != '-');
            while (command[position] != '-');
            return parameterValue;
        }

        float setParameter(string parameterValue, bool parameterState, Label parameterLabel, string parameterAlert)
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
            return (float)Convert.ToDouble(parameterValue);
        }

        void showParameter(string parameterName,string parameterValue, bool parameterState)
        {
            if (parameterName == "te")
            {
                tempValue = setParameter(parameterValue, parameterState, temperatureValuelbl, "Temperature alert! ");
            }
            else if (parameterName == "hu")
            {
                humValue = setParameter(parameterValue, parameterState, humiditylbl, "Humidity alert! ");
            }
            else if (parameterName == "co")
            {
                coValue = setParameter(parameterValue, parameterState, co2lbl, "CO2 alert! ");
            }
            else if (parameterName == "vo")
            {
                tvocValue = setParameter(parameterValue, parameterState, tvoclbl, "TVOC alert! ");
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
    }
}
