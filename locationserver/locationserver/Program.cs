using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using locationserver;

namespace Server
{
    class Program
    {

        #region Declarations and Variables that require wider scope

        static int threadCounter = 1; // Unique identifier for each thread
        static Dictionary<string, string> records; // Contains all the location information
        static Debugger debugger;
        static ServerFiles sf;
        static bool debugToggle = false;

        #endregion

        #region Request Handlers

        #region Main Handlers

        /// <summary>
        /// Handles Client Request of HTTP protocol.
        /// </summary>
        /// <param name="strArr"></param>
        /// <param name="str"></param>
        /// <param name="socket"></param>
        /// <returns></returns>
        static string httpHandler(string[] strArr, string str, ref Socket socket)
        {
            string result = string.Empty;

            // HTTPHandler simply routes request based on first word of request, differentiation between HTTP versions is made later
            switch (strArr[0])
            {
                case "GET":
                    result = GETHandler(strArr, str, result, ref socket);
                    break;
                case "PUT":
                    result = PUTHandler(strArr, str, result, ref socket);
                    break;
                case "POST":
                    result = POSTHandler(strArr, str, result, ref socket);
                    break;
            }

            return result;
        }

        /// <summary>
        /// Handles Client Requests of whois protocol.
        /// </summary>
        /// <param name="strArr"></param>
        /// <param name="socket"></param>
        /// <returns></returns>
        static string whoisHandler(string[] strArr, ref Socket socket) // Handler for whois protocol
        {

            string name = string.Empty;
            string location = string.Empty;
            bool nameExists = false;
            string result = string.Empty;
            // Simple GET method for location, based on whois protocol
            if (strArr.Length == 1)
            {
                name = strArr[0].Replace("\r\n", string.Empty);
                nameExists = getLocation(name, out location, ref socket);
                if (nameExists)
                {
                    result = location + "\r\n";
                }
                else if (!nameExists)
                {
                    result = "ERROR: no entries found\r\n";
                }
                else
                {
                    Console.WriteLine("whoishandler Failed");
                }
                debugger.request("whois", "GET", name, location);
            }
            else if (strArr.Length > 1) // Simple SET method for location, based on whois protocol
            {
                name = strArr[0];
                location = string.Empty;
                for (int i = 1; i < strArr.Length; i++)
                {
                    if (i == strArr.Length - 1)
                    {
                        location += strArr[i].Replace("\r\n", string.Empty);
                    }
                    else
                    {
                        location += strArr[i] + " ";
                    }
                }
                setLocation(name, location, ref socket);
                result = "OK\r\n";
                debugger.request("whois", "SET", name, location);
            }
            else { Console.WriteLine("whoishandler Failed"); }

            return result;
        }

        #endregion

        #region Sub-Handlers for HTTP Protocol

        /// <summary>
        /// Handler for Client Requests of HTTP protocol and GET keyword.
        /// </summary>
        /// <param name="strArr"></param>
        /// <param name="str"></param>
        /// <param name="result"></param>
        /// <param name="socket"></param>
        /// <returns></returns>
        static string GETHandler(string[] strArr, string str, string result, ref Socket socket) // All GET requests sent here
        {
            string location;
            bool nameExists;
            
            string secondEle = strArr[1];

            // Distinguishing between HTTP protocols versions, this is done by the difference in their name tags
            // 1.1 contains ? and =
            // 1.0 contains only ?
            // 0.9 contains neither

            if (secondEle.Contains('?') && !secondEle.Contains('=')) // HTTP 1.0 GET Handler
            {
                string name = strArr[1].Substring(2);
                nameExists = getLocation(name, out location, ref socket);
                if (nameExists)
                {
                    result = "HTTP/1.0 200 OK\r\n" +
                        "Content-Type: text/plain\r\n" +
                        "\r\n" + location + "\r\n";
                }
                else if (!nameExists)
                {
                    result = "HTTP/1.0 404 Not Found\r\n" +
                        "Content-Type: text/plain\r\n" +
                        "\r\n";
                }
                else
                {
                    Console.WriteLine("GETHandler Failed");
                }
                debugger.request("HTTP/1.0", "GET", name, location);
            }
            else if (secondEle.Contains('?') && secondEle.Contains('=')) // HTTP 1.1 GET Handler
            {
                string name = strArr[1].Substring(7);
                string optionalHeaders = string.Empty;
                
                string[] crlfSplit = Regex.Split(str, "\r\n");
                if (crlfSplit.Length > 3)
                {
                    for (int i = 2; i < crlfSplit.Length - 1; i++)
                    {
                        optionalHeaders += crlfSplit[i];
                    }
                }

                nameExists = getLocation(name, out location, ref socket);
                if (nameExists)
                {
                    result = "HTTP/1.1 200 OK\r\n" +
                        "Content-Type: text/plain\r\n" +
                        optionalHeaders + "\r\n" + 
                        location + "\r\n";
                }
                else if (!nameExists)
                {
                    result = "HTTP/1.1 404 Not Found\r\n" +
                        "Content-Type: text/plain\r\n" +
                        optionalHeaders + "\r\n";
                }
                else
                {
                    Console.WriteLine("GETHandler Failed");
                }
                debugger.request("HTTP/1.1", "GET", name, location);
            }
            else if (!secondEle.Contains('?') && !secondEle.Contains('=')) // HTTP 0.9 GET Handler
            {
                string name = strArr[1].Substring(1).Replace("\r\n", string.Empty);
                nameExists = getLocation(name, out location, ref socket);
                if (nameExists)
                {
                    result = "HTTP/0.9 200 OK\r\n" +
                        "Content-Type: text/plain\r\n" +
                        "\r\n" +
                        location + "\r\n";
                }
                else if (!nameExists)
                {
                    result = "HTTP/0.9 404 Not Found\r\n" +
                        "Content-Type: text/plain\r\n" +
                        "\r\n";
                }
                else
                {
                    Console.WriteLine("GETHandler Failed");
                }
                debugger.request("HTTP/0.9", "GET", name, location);

            }
            else { Console.WriteLine("GETHandler Failed"); }

            
            return result;
        }

        /// <summary>
        /// Handler for Client Requests of HTTP protocol and PUT keyword.
        /// </summary>
        /// <param name="strArr"></param>
        /// <param name="str"></param>
        /// <param name="result"></param>
        /// <param name="socket"></param>
        /// <returns></returns>
        static string PUTHandler(string[] strArr, string str, string result, ref Socket socket) // PUT keyword used by only HTTP 0.9 
        {
            string body = str;
            

            string[] crlfSplit = Regex.Split(body, "\r\n");

            string name = crlfSplit[0].Split(' ').Last().Replace("/", string.Empty);
            string location = crlfSplit[2];

            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(location)) /* && !string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(location) && name.All(Char.IsLetterOrDigit) && (location.Replace(" ", string.Empty).All(Char.IsLetterOrDigit))*/
            {
                setLocation(name, location, ref socket);
            }
            else { Console.WriteLine("A field was null or empty."); }

            result = "HTTP/0.9 200 OK\r\n" +
                "Content-Type: text/plain\r\n" +
                "\r\n";

            debugger.request("HTTP/0.9", "SET", name, location);
            return result;


        }

        /// <summary>
        /// Handler for Client Requests of HTTP protocol and POST keyword.
        /// </summary>
        /// <param name="strArr"></param>
        /// <param name="str"></param>
        /// <param name="result"></param>
        /// <param name="socket"></param>
        /// <returns></returns>
        static string POSTHandler(string[] strArr, string str, string result, ref Socket socket) // POST used by HTTP 1.0 and 1.1
        {
            string body = str;

            string[] crlfSplit = Regex.Split(body, "\r\n");
            string protocol = crlfSplit[0].Substring(crlfSplit[0].Length - 3); // Decipher first line of client request to find out HTTP version

            if (protocol == "1.0")
            {
                
                string[] firstEle = crlfSplit[0].Split(' ');
                string name = firstEle[1].Substring(1);      

                string location = crlfSplit[crlfSplit.Length - 1];

                if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(location)) /* && !string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(location) && name.All(Char.IsLetterOrDigit) && (location.Replace(" ", string.Empty).All(Char.IsLetterOrDigit))*/
                {
                    setLocation(name, location, ref socket);
                }
                else { Console.WriteLine("A field was null or empty."); }

                debugger.request("HTTP/1.0", "SET", name, location);
                result = "HTTP/1.0 200 OK\r\n" +
                    "Content-Type: text/plain\r\n" +
                    "\r\n";
            }
            else if (protocol == "1.1")
            {
                string name;
                string location;
                string optionalHeaders = string.Empty;

                string[] bodyArr = Regex.Split(str, "&location=");

                location = bodyArr.Last();
                name = Regex.Split(bodyArr.First(), "\r\nname=").Last();

                string[] crlfSplit2 = Regex.Split(str, "\r\n");
                if (crlfSplit2.Length > 4)
                {
                    for (int i = 3; i < crlfSplit2.Length - 1; i++)
                    {
                        optionalHeaders += crlfSplit2[i];
                    }
                }


                if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(location)) /* && !string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(location) && name.All(Char.IsLetterOrDigit) && (location.Replace(" ", string.Empty).All(Char.IsLetterOrDigit))*/
                {
                    setLocation(name, location, ref socket);
                }
                else { Console.WriteLine("A field was null or empty."); }

                debugger.request("HTTP/1.1", "SET", name, location);
                result = "HTTP/1.1 200 OK\r\n" +
                    "Content-Type: text/plain\r\n" +
                    optionalHeaders +
                    "\r\n";
            }
            else { Console.WriteLine("POSTHandler Failed"); }


            return result;
        }

        #endregion
        
        #endregion

        #region Server Methods

        /// <summary>
        /// Retrieves location of 'name'.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="location"></param>
        /// <param name="socket"></param>
        /// <returns></returns>
        static bool getLocation(string name, out string location, ref Socket socket)
        {
            string ip = socket.RemoteEndPoint.ToString();
            string loc;
            bool nameExists = records.TryGetValue(name, out loc);
            DateTime date = DateTime.Now;


            if (nameExists)
            {
                location = loc;

                string log = ip + " [" + date.ToString("G") + "] GET '" + name + "' => '" + location + "'";
                sf.logger(log, debugToggle);
                return true;
            }
            else if (!nameExists)
            {
                location = loc;
                string log = ip + " [" + date.ToString("G") + "] GET '" + name + "' => User not found";
                sf.logger(log, debugToggle);
                return false;
            }
            else
            {
                location = loc;
                Console.WriteLine("getLocation Failed");
                string log = ip + " [" + date.ToString("G") + "] GET '" + name + "' => GET method failed";
                sf.logger(log, debugToggle);
                return false;
            }

        }

        /// <summary>
        /// Updates location of 'name'.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="location"></param>
        /// <param name="socket"></param>
        static void setLocation(string name, string location, ref Socket socket)
        {
            string ip = socket.RemoteEndPoint.ToString();
            string loc;
            bool nameExists = records.TryGetValue(name, out loc);
            DateTime date = DateTime.Now;
            if (nameExists)
            {
                records[name] = location;
                string log = ip + " [" + date.ToString("G") + "] SET '" + name + "' '" + location + "' => User updated";
                sf.logger(log, debugToggle);
            }
            else if (!nameExists)
            {
                records.Add(name, location);
                string log = ip + " [" + date.ToString("G") + "] SET '" + name + "' '" + location + "' => User created";
                sf.logger(log, debugToggle);
            }
            else
            {
                string log = ip + " [" + date.ToString("G") + "] SET '" + name + "' '" + location + "' => SET method failed";
                sf.logger(log, debugToggle);
                Console.WriteLine("setLocation Failed");
            }
        }

        /// <summary>
        /// Primary Handler for Client request. Calls relevant specialised handlers as required by Client request.
        /// </summary>
        /// <param name="socket"></param>
        /// <param name="stream"></param>
        /// <param name="debugger"></param>
        /// <param name="sf"></param>
        /// <param name="tCount"></param>
        static void doWork(ref Socket socket, ref NetworkStream stream, ref Debugger debugger, ref ServerFiles sf, int tCount)
        {

            debugger.threadStarted((threadCounter).ToString());

            StreamReader sr = new StreamReader(stream, Encoding.ASCII); // Reader started to read clients request
            // Reading apparatus
            char[] inputArr = new char[1000]; 
            int lengthOfBuffer = sr.Read(inputArr, 0, 1000);
            string str = string.Empty;
            if (lengthOfBuffer > 0)
            {
                str = new string(inputArr, 0, lengthOfBuffer);
            }
            // Reading apparatus


            string[] strArr = str.Split(' '); // Client request split(' ') to isolate first word of string. Allows for easier routing based on protocol
            string output;

            if ((strArr[0] == "GET") || (strArr[0] == "POST") || (strArr[0] == "PUT"))
            {
                output = httpHandler(strArr, str, ref socket); // HTTP protocol identified, hence, client request sent to HTTPHandler()
                // method return a string, which is the response to clients request
            }
            else
            {
                output = whoisHandler(strArr, ref socket); // whois protocol identified, hence, client request sent to whoisHandler()
                // method return a string, which is the response to clients request
            }

            StreamWriter sw = new StreamWriter(stream, Encoding.ASCII); // Writer opened to send the response to client for their request
            sw.Write(output);
            sw.Flush();

            socket.Close(); // Connection closed once response has been sent
            stream.Close();
            sf.shutdown(records); // File is updated based on changes that might have occured from clients request
            debugger.threadFinished(tCount);
        }

        #endregion

        static void Main(string[] args)
        {
            if (args.Contains("-w")) // GUI Flag. If present, then launch GUI.
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm(args));
            }
            else
            {
                #region Default Values + Variables

                // Default values for optional flags. Values can be changed via Options.Update(), if relevant Flags present is args[].

                int timeOutLimit = 1000;
                bool timeLimit = true;

                bool saveRecords = false;
                string logFile = "log.txt";
                string dbFile = "records.txt";

                #endregion

                #region Class Initialisations

                Options options = new Options(args);
                options.Update(out timeOutLimit, out timeLimit, out debugToggle, out saveRecords, out logFile, out dbFile);
                debugger = new Debugger(debugToggle);
                sf = new ServerFiles(saveRecords, logFile, dbFile);

                sf.initialise(out records);

                #endregion

                #region Main Server Code

                TcpListener listener = null;

                try
                {
                    // Server starts listening
                    listener = new TcpListener(IPAddress.Any, 43);
                    listener.Start();
                    debugger.listening();

                    while (true)
                    {
                        // waiting for connections
                        Socket socket = listener.AcceptSocket();

                        if (timeLimit) // timeout function, disabled if "-t 0" flag used, default 1000ms
                        {
                            socket.SendTimeout = timeOutLimit;
                            socket.ReceiveTimeout = timeOutLimit;
                        }

                        NetworkStream stream = new NetworkStream(socket);
                        debugger.established(threadCounter.ToString());

                        // New thread created to take care of client request
                        Thread t = new Thread(() => doWork(ref socket, ref stream, ref debugger, ref sf, threadCounter)); // doWork() takes care of the request and 
                        t.Start();                                                                                        // routes it to the relevant methods
                        Thread.Sleep(20); // Thread slept to allow time for previous thread to recieve its correct queue number
                        threadCounter++; // static variable incremeneted to give unique identifiers to each thread
                    }

                }
                catch (Exception e) { Console.WriteLine(e); }
                finally
                {
                    if (listener != null) // Close TCPListener when finished.
                    {
                        listener.Stop();
                    }
                }

                #endregion
              
            }
        }       
    }
}
