using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using SimpleUdpListener.Classes;

namespace SimpleUdpListener
{
    public class Main
    {
        private static int port;
        private static string pathFile;
        private static string sourceIp;

        public Main(string[] args) 
        {
            // Default 
            port = 5000;
            pathFile = "log.txt";
            sourceIp = "";

            var res = Parser.Default.ParseArguments<Options>(args).MapResult((opts) =>
            RunOptionsAndReturnExitCode(opts), //in case parser sucess
            errs => HandleParseError(errs)); //in  case parser fail

            if (res)
            {
                try
                {
                    UDPController udpl = new UDPController(port, pathFile, sourceIp);
                    udpl.UDPListener();
                    if (sourceIp != "")
                        Console.WriteLine($"Listening on port {port} - only from: {sourceIp} - logging on {pathFile}");
                    else
                        Console.WriteLine($"Listening on port {port} - from any IP - logging on {pathFile}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                while (true) { }
            }
            else
            {
                //Exit
            }
        }

        private static bool RunOptionsAndReturnExitCode(Options o)
        {
            if (o.Port > 0 && o.Port <= 65535)
                port = o.Port;

            if (!string.IsNullOrEmpty(o.FileName))
                pathFile = o.FileName;

            if (!string.IsNullOrEmpty(o.SourceIp))
                sourceIp = o.SourceIp;

            return true;
        }

        private static bool HandleParseError(IEnumerable<Error> errs)
        {
            return false;
        }
    }
}
