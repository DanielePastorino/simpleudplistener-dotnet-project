using SimpleUdpListener;

Main main = new Main(args);


//using CommandLine;
//using SimpleUdpListener.Classes;

//var result = Parser.Default.ParseArguments<Options>(args).MapResult((opts) => 
//    RunOptionsAndReturnExitCode(opts), //in case parser sucess
//    errs => HandleParseError(errs)); //in  case parser fail

//if (result.result)
//{
//    try
//    {
//        UDPController udpl = new UDPController(result.Port, result.FileName);

//        udpl.UDPListener();
        
//        Console.WriteLine("Ready!");
//    }
//    catch (Exception ex)
//    {
//        Console.WriteLine(ex.Message);
//    }

//    while (true) { }
//}
//else 
//{
//    //Exit
//}

//static ArgData RunOptionsAndReturnExitCode(Options o) 
//{
//    int port;
//    string pathFile;

//    if (o.Port > 0 && o.Port <= 65535)
//    {
//        port = o.Port;
//    }
//    else 
//    {
//        port = 5000;
//    }

//    if (!string.IsNullOrEmpty(o.FileName)) 
//    {
//        pathFile = o.FileName;
//    } 
//    else 
//    {
//        pathFile = "log.txt";
//    }

//    return new ArgData(port, pathFile, true);
//}

//static ArgData HandleParseError(IEnumerable<Error> errs) 
//{
//    return new ArgData(0, "", false);
//}




