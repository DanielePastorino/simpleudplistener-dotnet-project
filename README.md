SimpleUdpListener
-----
```
Copyright (C) 2022 SimpleUdpListener

  -p, --port          Set udp listener port

  -o, --outputFile    Set output file name

  --help              Display this help screen.

  --version           Display version information.
```

Examples
----
Write on "log.txt" file (same folder of executable), listen on port 5000
```
SimpleUdpListener
```
Write on "c:\temp\logtest.txt" file, listen on port 5001 
```
SimpleUdpListener -p 5001 -o c:\temp\logtest.txt
```
