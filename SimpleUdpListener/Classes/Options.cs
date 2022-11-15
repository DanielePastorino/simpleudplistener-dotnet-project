using CommandLine.Text;
using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleUdpListener.Classes
{
    public class Options
    {
        [Option('p', "port", Required = false, HelpText = "Set udp listener port")]
        public int Port { get; set; }

        [Option('o', "outputFile", Required = false, HelpText = "Set output file name")]
        public string FileName { get; set; }
    }
}
