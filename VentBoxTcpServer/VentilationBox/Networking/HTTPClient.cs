using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace VentilationBox
{
    public class HTTPClient
    {
        readonly HttpClient client;
        readonly string ID;
        static string msgPrototype = "#t;c;h;v;i$";
        StringBuilder Prefix;
        //string URI;


        public HTTPClient(string URI = "87.120.74.138:42069")
        {
            //this.IPAddress = Dns.GetHostEntry(Dns.GetHostName()).AddressList[0].ToString();
            this.client = new HttpClient();
            this.ID = "House1";
            this.Prefix = new StringBuilder("http://");
            this.Prefix.Append(URI);
        }


        private async Task<string> SendData(string Data)
        {
            string responseBody = String.Empty;
            try
            {
                var content = new StringContent(Data, Encoding.UTF8, "text/plain");
                //HttpResponseMessage response = await client.PostAsync("http://87.120.74.138:42069", content);
                HttpResponseMessage response = await client.PostAsync(this.Prefix.ToString(), content);
                response.EnsureSuccessStatusCode();
                responseBody = await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

            Console.WriteLine(responseBody);
            return responseBody;
        }


        private string ConvertProtocols(string Tepm, string Humd, string Voc, string Co2)
        {
            string msgToSend = "";

            foreach (var c in msgPrototype)
            {
                switch (c)
                {
                    case 't':
                        msgToSend += Tepm;
                        break;
                    case 'c':
                        msgToSend += Co2;
                        break;
                    case 'h':
                        msgToSend += Humd;
                        break;
                    case 'v':
                        msgToSend += Voc;
                        break;
                    case 'i':
                        msgToSend += ID;
                        break;
                    default:
                        msgToSend += c;
                        break;
                }
            }
            return msgToSend;
        }


        public async Task<string> Send(string Tepm, string Humd, string Voc, string Co2)
        {
            return await SendData(ConvertProtocols(Tepm, Humd, Voc, Co2));
        }

        public void Close()
        {
            this.client.Dispose();
        }
    }
}
