using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Windows.Forms;


namespace location
{
    class Program
    {      
        static void Main(string[] args)
        {
            // Checking length of args[], if arguments provided then continue with non-GUI Client
            if (args.Length > 0) // Change me
            {

                #region Default Values + Variables

                // Default values for optional flags. Values can be changed via Options.Update(), if relevant Flags present is args[].

                int timeOutLimit = 1000;
                bool timeLimit = true;
                bool debugToggle = false;

                string protocol = "whois";
                string server = "whois.net.dcs.hull.ac.uk";
                int port = 43;

                string whatToDo = string.Empty;
                string name = string.Empty;
                string location = string.Empty;

                #endregion

                #region Class Initialisations

                // Initialisations of various classes required for client funtion

                Options options = new Options(args); // Reads and interprets 
                options.Update(out timeOutLimit, out timeLimit, out debugToggle, out protocol, out server, out port, out whatToDo, out name, out location);
                Debugger debugger = new Debugger(debugToggle);

                #endregion             

                #region Main Client Code

                TcpClient client = null;

                try
                {
                    client = new TcpClient(server, port); // Start Client.

                    if (timeLimit) // Set Timeout if timeLimit set. Default: True. False if timeOutLimit == 0;
                    {
                        client.ReceiveTimeout = timeOutLimit;
                        client.SendTimeout = timeOutLimit;
                    }

                    NetworkStream stream = client.GetStream(); // Open stream.
                    debugger.established();

                    debugger.choosingProtocol();
                    if (name != "")
                    {
                        switch (protocol) // Route based on protocol, to relevant child classes to handle request.
                        {
                            case "whois":
                                debugger.isChosen("whois");

                                Whois whois = new Whois(debugToggle); whois.Work(whatToDo, name, location, ref client, ref stream);

                                break;
                            case "-h0":
                                debugger.isChosen("HTTP 1.0");

                                H0 h0 = new H0(debugToggle); h0.Work(whatToDo, name, location, ref client, ref stream);

                                break;
                            case "-h1":
                                debugger.isChosen("HTTP 1.1");

                                H1 h1 = new H1(server, debugToggle); h1.Work(whatToDo, name, location, ref client, ref stream);

                                break;
                            case "-h9":
                                debugger.isChosen("HTTP 0.9");

                                H9 h9 = new H9(debugToggle); h9.Work(whatToDo, name, location, ref client, ref stream);

                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("No arguments for name provided.");
                    }
                }
                catch (Exception e)
                {
                    if (e.Message == "No such host is known")
                    {
                        Console.WriteLine("Connection to server failed");
                    }
                    else { Console.WriteLine("Exception thrown: " + e.Message); }
                }
                finally
                {
                    if (client != null) // Close TCPClient when request completed.
                    {
                        client.Close();
                    }
                }

                #endregion

            }
            else // If no arguments provided, then launch GUI
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
        }
    }
}
