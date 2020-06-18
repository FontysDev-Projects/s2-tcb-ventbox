using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Serial_Receiver
{
    class Program
    {
        static bool isConnected = true;
        static int change = 0;
        static string message;
        static int i = 0;
        static void Main(string[] args)
        {
            SerialPort serialPort = new SerialPort();
            serialPort.BaudRate = 19200;
            serialPort.PortName = "COM3";
            serialPort.Open();

            // message = "$te-";
            // message += temp;
            // message += "%";
            while (true)
            {
                message = serialPort.ReadLine();
                StartClient(message);
                Console.WriteLine($"Sending: {message}");
            }
        }

        public static string SetPortName(string defaultPortName)
        {
            string portName;

            Console.WriteLine("Available Ports:");
            foreach (string s in SerialPort.GetPortNames())
            {
                Console.WriteLine("   {0}", s);
            }

            Console.Write("Enter COM port value (Default: {0}): ", defaultPortName);
            portName = Console.ReadLine();

            if (portName == "" || !(portName.ToLower()).StartsWith("com"))
            {
                portName = defaultPortName;
            }
            return portName;
        }

        public static void StartClient(String message)
        {
            TcpClient client = new TcpClient();
            IPAddress server = IPAddress.Parse("172.27.208.139");
            //Connect to the server
            Console.WriteLine("Before connect");
            client.Connect(server, 8888);
            Console.WriteLine("After connect");
            //Get the network stream
            NetworkStream stream = client.GetStream();
            //Converting string to byte array
            byte[] bytesToSend = System.Text.Encoding.ASCII.GetBytes(message);
            //Sending the byte array to the server
            client.Client.Send(bytesToSend);
        }
    }


}
