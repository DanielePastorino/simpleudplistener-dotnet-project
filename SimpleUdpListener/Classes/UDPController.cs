using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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

        public UDPController(int port, string pathFile)
        {
            this.port = port;
            this.pathFile = pathFile;
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

                        Console.WriteLine($"{DateTime.Today.ToString("d")} {DateTime.Now.ToString("HH:mm:ss")} - {msg}");

                        await WriteFile(msg);
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
