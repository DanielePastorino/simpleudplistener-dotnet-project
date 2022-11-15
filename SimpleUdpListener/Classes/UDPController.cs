using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SimpleUdpListener.Classes
{
    public class UDPController
    {
        private int port;
        private string pathFile;
        private string sourceIp;

        public UDPController(int port, string pathFile, string sourceIp)
        {
            this.port = port;
            this.pathFile = pathFile;
            this.sourceIp = sourceIp;
        }

        public void UDPListener()
        {
            Task.Run(async () =>
            {
                using (var udpClient = new UdpClient(this.port))
                {
                    
                    string msg = "";
                    while (true)
                    {
                        var receivedResults = await udpClient.ReceiveAsync();
                        msg = Encoding.UTF8.GetString(receivedResults.Buffer);

                        if (this.sourceIp != "")
                        {
                            if (this.sourceIp == receivedResults.RemoteEndPoint.Address.ToString()) 
                            {
                                Console.WriteLine($"{DateTime.Today.ToString("d")} {DateTime.Now.ToString("HH:mm:ss")} From: {receivedResults.RemoteEndPoint.Address} - {msg}");
                                await WriteFile(msg);
                            }
                        }
                        else 
                        {
                            Console.WriteLine($"{DateTime.Today.ToString("d")} {DateTime.Now.ToString("HH:mm:ss")} - {msg}");
                            await WriteFile(msg);
                        }
                        
                    }
                }
            });
        }

        private async Task WriteFile(string str)
        {
            try 
            { 
                await File.WriteAllTextAsync(this.pathFile, str); 
            } 
            catch(Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
