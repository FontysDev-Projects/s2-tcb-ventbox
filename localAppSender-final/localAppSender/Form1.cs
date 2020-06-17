using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace localAppSender
{
    public partial class Form1 : Form
    {
        private static IPAddress server = IPAddress.Parse("172.27.208.139");
        TcpClient client;
        NetworkStream stream;

        private void startClient()
        {
            client = new TcpClient();
            client.Connect(server, 8888);
            stream = client.GetStream();

            //FORMAT
        }

        //
        public string convertString(string incomingString)
        {
            string toReturn = "$voc-";
            int index = incomingString.IndexOf('v') + 3;
            int[] value = new int[3];
            for (int i = index; i < index+3; i++)
            {
                toReturn += incomingString[i];
            }
            toReturn += "%";
            return toReturn;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            startClient();
            timer1.Start();
            serialPort1.Open();
        }

        private void BtnSendMessage_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] toSend = Encoding.ASCII.GetBytes(tbMessage.Text);
                stream.Write(toSend, 0, toSend.Length);
                lbMessages.Items.Add("Message sent: " + tbMessage.Text);
                lbMessages.Items.Add("Outgoing data: " + convertString(tbMessage.Text));
            }
            catch (Exception ex)
            {
                lbMessages.Items.Add(ex.Message);
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                timer1.Interval = 500;
                byte[] incomingData = new byte[1024];
                if (serialPort1.BytesToRead > 0)
                {
                    serialPort1.Read(incomingData, 0, incomingData.Length);
                    string data = Encoding.ASCII.GetString(incomingData);
                    string outGoing = convertString(data);
                    lbMessages.Items.Add("Received data: " + data);
                    lbMessages.Items.Add("Outgoing data: " + outGoing);
                    stream.Write(Encoding.ASCII.GetBytes(outGoing), 0, Encoding.ASCII.GetBytes(outGoing).Length);
                }
            }
            catch (Exception ex)
            {
                lbMessages.Items.Add(ex.Message);
            }
        }
    }
}
