using Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace locationserver
{
    public partial class MainForm : Form
    {

        #region Miscellaneous

        #region Allow form to be moveable on screen

        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        private void pnlTop_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void pnlTop_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void pnlTop_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        #endregion

        #region Allow GUI to Show/Hide Console Window

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool AllocConsole();

        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;
        const int SW_SHOW = 5;

        public static void ShowConsoleWindow()
        {
            var handle = GetConsoleWindow();

            if (handle == IntPtr.Zero)
            {
                AllocConsole();
            }
            else
            {
                ShowWindow(handle, SW_SHOW);
            }
        }

        public static void HideConsoleWindow()
        {
            var handle = GetConsoleWindow();
            ShowWindow(handle, SW_HIDE);
        }

        bool isOpen = true;

        #endregion

        #endregion

        #region Default Values + Variables

        int threadCounter = 1; // Unique identifier for each thread
        Dictionary<string, string> records; // Contains all the location information
        Debugger debugger;
        ServerFiles sf;
        bool debugToggle = false;    

        // Default values that can be changed through command line flags
        int timeOutLimit = 1000;
        bool timeLimit = true;
        bool saveRecords = false;
        string logFile = "log.txt";
        string dbFile = "records.txt";

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
        private string httpHandler(string[] strArr, string str, ref Socket socket)
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
        private string whoisHandler(string[] strArr, ref Socket socket) // Handler for whois protocol
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
        private string GETHandler(string[] strArr, string str, string result, ref Socket socket) // All GET requests sent here
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
        private string PUTHandler(string[] strArr, string str, string result, ref Socket socket) // PUT keyword used by only HTTP 0.9 
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
        private string POSTHandler(string[] strArr, string str, string result, ref Socket socket) // POST used by HTTP 1.0 and 1.1
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
        private bool getLocation(string name, out string location, ref Socket socket)
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
        private void setLocation(string name, string location, ref Socket socket)
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
        private void doWork(ref Socket socket, ref NetworkStream stream, ref Debugger debugger, ref ServerFiles sf, int tCount)
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

        #region Form Intialisation

        public MainForm(string[] args)
        {
            #region Class Initialisations

            // Intialise Classes with Form initialisation
            Options options = new Options(args);
            options.Update(out timeOutLimit, out timeLimit, out debugToggle, out saveRecords, out logFile, out dbFile);
            debugger = new Debugger(debugToggle);
            sf = new ServerFiles(saveRecords, logFile, dbFile);

            sf.initialise(out records);

            #endregion

            InitializeComponent();

            // Hide Console when GUI launched
            HideConsoleWindow();
            isOpen = false;

            // Set text, and colour of some Form elements
            txtLogsPath.Text = logFile;
            txtRecordsPath.Text = dbFile;
            lblDebuggToggle.Text = debugToggle ? "Debugging: Enabled" : "Debugging: Disabled";
            lblFiles.Text = saveRecords ? "File Saving: Enabled" : "File Saving: Disabled";
            btnDebugg.BackColor = debugToggle ? Color.Green : Color.Red;
            btnFiles.BackColor = saveRecords ? Color.Green : Color.Red;
        }

        #endregion

        #region Main Server Code from non-GUI Server

        bool forever = false;
        int inactiveLimit = 5;
        int counter = 0;
        bool timerSelected = false;
        Thread t;

        private void updateInactiveTimer()
        {
            float timeLeft = ((inactiveLimit * 2) - counter) / 2;
            lblServerInactive.Invoke((MethodInvoker)(() => {
                lblServerInactive.Text = "Server Sleep in: " + timeLeft + " seconds";
                lblServerInactive.Refresh();
            }));
            
        }

        Socket socket;
        NetworkStream stream;
        TcpListener listener;

        /// <summary>
        /// Runs server on separate thread. And handles non-UI thread, control changes.
        /// </summary>
        private void runServer()
        {

            #region Main

            listener = null;

            try
            {
                // Server starts listening
                listener = new TcpListener(IPAddress.Any, 43);
                listener.Start();
                debugger.listening();

                counter = 0;
                bool operation = true;

                while (operation)
                {
                    lblServerStatus.Invoke((MethodInvoker)(() => {
                        lblServerStatus.Text = "Server Status: Listening";
                        lblServerStatus.ForeColor = Color.Green;
                        lblServerStatus.BackColor = Color.White;
                        lblServerStatus.Refresh();
                    }));
                    if (forever)
                    {
                        lblServerInactive.Invoke((MethodInvoker)(() => {
                            lblServerInactive.Text = "Server Sleep in: Until Stop.";
                            lblServerInactive.Refresh();
                        }));
                    }
                    if (!listener.Pending() && !forever)
                    {
                        Thread.Sleep(500);
                        counter++;
                        updateInactiveTimer();
                        if (counter == inactiveLimit * 2)
                        {
                            operation = false;
                        }
                        continue;
                    }
                    else if (!listener.Pending() && forever)
                    {
                        Thread.Sleep(200);
                        continue;
                    }
                    // waiting for connections
                    socket = listener.AcceptSocket();

                    if (timeLimit) // timeout function, disabled if "-t 0" flag used, default 1000ms
                    {
                        socket.SendTimeout = timeOutLimit;
                        socket.ReceiveTimeout = timeOutLimit;
                    }

                    stream = new NetworkStream(socket);
                    debugger.established(threadCounter.ToString());

                    // New thread created to take care of client request
                    Thread tt = new Thread(() => doWork(ref socket, ref stream, ref debugger, ref sf, threadCounter)); // doWork() takes care of the request and 
                    tt.Start();                                                                                        // routes it to the relevant methods
                    counter = 0;
                    Thread.Sleep(20); // Thread slept to allow time for previous thread to recieve its correct queue number
                    threadCounter++; // static variable incremeneted to give unique identifiers to each thread
                }
                lblServerStatus.Invoke((MethodInvoker)(() => {
                    lblServerStatus.Text = "Server Status: Standby";
                    lblServerStatus.ForeColor = Color.Black;
                    lblServerStatus.BackColor = Color.Transparent;
                    lblServerStatus.Refresh();
                }));
                
            }
            catch (Exception exc) { Console.WriteLine(exc); }
            finally
            {
                if (listener != null)
                {
                    btnStartServer.Invoke((MethodInvoker) ( () => { btnStartServer.Enabled = true; }));
                    listener.Stop();
                    debugger.finished();
                }
                else { btnStartServer.Invoke((MethodInvoker)(() => { btnStartServer.Enabled = true; })); }
            }

            #endregion

        }

        /// <summary>
        /// Blocks certain buttons when server is operating
        /// </summary>
        private void blockButtons()
        {
            btnStartServer.Enabled = false;
            btnFiles.Enabled = false;
            btnRecordsLaunch.Enabled = false;
            btnLogLaunch.Enabled = false;
            txtLogsPath.Enabled = false;
            txtRecordsPath.Enabled = false;
        }
        /// <summary>
        /// Unblocks certain buttons when server is stopped
        /// </summary>
        private void unblockButtons()
        {
            btnStartServer.Enabled = true;
            btnFiles.Enabled = true;
            btnRecordsLaunch.Enabled = true;
            btnLogLaunch.Enabled = true;
            txtLogsPath.Enabled = true;
            txtRecordsPath.Enabled = true;
        }
        private void btnStartServer_Click(object sender, EventArgs e)
        {
            blockButtons();

            if (timerSelected)
            {
                t = new Thread(() => runServer());
                t.Start();
            }    
            else
            {
                MessageBox.Show("Select Inactivity Timeout.", "Message", MessageBoxButtons.OK);
                unblockButtons();
            }          
        }

        private void btnStopServer_Click(object sender, EventArgs e)
        {
            if (socket != null)
                socket.Close();
            if (stream != null)
                stream.Close();

            lblServerInactive.Text = "Server Sleep in:";
            lblServerStatus.Text = "Server Status: Standby";
            lblServerStatus.BackColor = Color.LightSeaGreen;
            lblServerStatus.ForeColor = Color.Black;

            sf.shutdown(records);
            
            t.Abort();

            unblockButtons();
        }

        #endregion

        #region Buttons

        #region Toggle Buttons

        /// <summary>
        /// Toggles debugging in Console Window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDebugg_Click(object sender, EventArgs e)
        {
            if (debugToggle == true)
            {
                //btnDebugg.BackColor = Color.Red;
                debugToggle = false;
                debugger = new Debugger(debugToggle);
            }
            else if (debugToggle == false)
            {
                //btnDebugg.BackColor = Color.Green;
                debugToggle = true;
                debugger = new Debugger(debugToggle);
            }

            lblDebuggToggle.Text = debugToggle ? "Debugging: Enabled" : "Debugging: Disabled";
            btnDebugg.BackColor = debugToggle ? Color.Green : Color.Red;
            btnDebugg.ForeColor = debugToggle ? Color.Black : Color.White;
        }

        /// <summary>
        /// Toggles File saving
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFiles_Click(object sender, EventArgs e)
        {
            if (saveRecords == true)
            {
                saveRecords = false;
                sf = new ServerFiles(saveRecords, logFile, dbFile, records);
            }
            else if (saveRecords == false)
            {
                saveRecords = true;
                sf = new ServerFiles(saveRecords, logFile, dbFile, records);
            }

            lblFiles.Text = saveRecords ? "File Saving: Enabled" : "File Saving: Disabled";
            btnFiles.BackColor = saveRecords ? Color.Green : Color.Red;
            btnFiles.ForeColor = saveRecords ? Color.Black : Color.White;
        }

        #endregion

        #region Inactivity Timeout Buttons

        /// <summary>
        /// Sets server inactivity timeout to forever
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnForever_Click(object sender, EventArgs e)
        {
            forever = true; timerSelected = true;


            btnForever.BackColor = Color.Green;
            btnFive.BackColor = Color.LightSeaGreen;
            btnFifteen.BackColor = Color.LightSeaGreen;
            btnThirty.BackColor = Color.LightSeaGreen;
            txtInactivity.BackColor = Color.LightSeaGreen;
            pnlMain.Refresh();
        }

        /// <summary>
        /// Sets server inactivity timeout to 5 seconds
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFive_Click(object sender, EventArgs e)
        {
            forever = false; timerSelected = true;

            inactiveLimit = 5;
            btnForever.BackColor = Color.LightSeaGreen;
            btnFive.BackColor = Color.Green;
            btnFifteen.BackColor = Color.LightSeaGreen;
            btnThirty.BackColor = Color.LightSeaGreen;
            txtInactivity.BackColor = Color.LightSeaGreen;
        }

        /// <summary>
        /// Sets server inactivity timeout to 15 seconds
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFifteen_Click(object sender, EventArgs e)
        {
            forever = false; timerSelected = true;

            inactiveLimit = 15;
            btnForever.BackColor = Color.LightSeaGreen;
            btnFive.BackColor = Color.LightSeaGreen;
            btnFifteen.BackColor = Color.Green;
            btnThirty.BackColor = Color.LightSeaGreen;
            txtInactivity.BackColor = Color.LightSeaGreen;
        }

        /// <summary>
        /// Sets server inactivity timeout to 30 seconds
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnThirty_Click(object sender, EventArgs e)
        {
            forever = false; timerSelected = true;

            inactiveLimit = 30;
            btnForever.BackColor = Color.LightSeaGreen;
            btnFive.BackColor = Color.LightSeaGreen;
            btnFifteen.BackColor = Color.LightSeaGreen;
            btnThirty.BackColor = Color.Green;
            txtInactivity.BackColor = Color.LightSeaGreen;
        }

        #endregion

        #region Launch Files Buttons

        /// <summary>
        /// Launches Logs file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogLaunch_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("notepad.exe", logFile);
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.ToString());
            }
        }

        /// <summary>
        /// Launches Records file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRecordsLaunch_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("notepad.exe", dbFile);
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.ToString());
            }
        }
        #endregion
      
        #region Utitlity Buttons

        /// <summary>
        /// Exits Application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
            Environment.Exit(0);
        }

        /// <summary>
        /// Button to Show/Hide Console Window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConWin_Click(object sender, EventArgs e)
        {
            if (isOpen)
            {
                // Hide
                HideConsoleWindow();
                btnConWin.BackColor = Color.Red;
                isOpen = false;
            }
            else
            {
                // Show
                ShowConsoleWindow();
                btnConWin.BackColor = Color.Green;
                isOpen = true;
            }
        }

        #endregion

        #endregion

        #region TextBoxes

        #region File Paths

        /// <summary>
        /// If value of textbox is valid. Saves Logs at new path.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtLogsPath_Leave(object sender, EventArgs e)
        {
            string str = txtLogsPath.Text;

            if (str != "")
            {
                if (File.Exists(txtLogsPath.Text))
                {
                    logFile = txtLogsPath.Text;
                    sf = new ServerFiles(saveRecords, logFile, dbFile, records);
                }
                else if (Regex.IsMatch(txtLogsPath.Text, @"^[a-zA-Z0-9]{1,30}\.txt$"))
                {
                    logFile = txtLogsPath.Text;
                    sf = new ServerFiles(saveRecords, logFile, dbFile, records);
                }
                else { txtLogsPath.Text = "Cannot access file."; }
            }
        }

        /// <summary>
        /// If value of textbox is valid. Saves Records at new path.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtRecordsPath_Leave(object sender, EventArgs e)
        {
            string str = txtRecordsPath.Text;

            if (str != "")
            {
                if (File.Exists(txtRecordsPath.Text))
                {
                    dbFile = txtRecordsPath.Text;
                    sf = new ServerFiles(saveRecords, logFile, dbFile, records);
                }
                else if (Regex.IsMatch(txtRecordsPath.Text, @"^[a-zA-Z0-9]{1,30}\.txt$"))
                {
                    dbFile = txtRecordsPath.Text;
                    sf = new ServerFiles(saveRecords, logFile, dbFile, records);
                }
                else { txtRecordsPath.Text = "Cannot access file."; }
            }
        }

        #endregion

        #region Server Inactivity
        
        private void txtInactivity_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtInactivity.Text == "Manual Entry (s)" || txtInactivity.Text == "Invalid input")
            {
                txtInactivity.Text = "";
            }
        }

        /// <summary>
        /// If value of textbox is valid. Inactivity timeout duration set to value.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtInactivity_TextChanged(object sender, EventArgs e)
        {
            string str = txtInactivity.Text;

            if (str != "")
            {
                if (str.All(Char.IsDigit) && str.Length < 11)
                {
                    inactiveLimit = int.Parse(str);
                    timerSelected = true;
                    btnForever.BackColor = Color.LightSeaGreen;
                    btnFive.BackColor = Color.LightSeaGreen;
                    btnFifteen.BackColor = Color.LightSeaGreen;
                    btnThirty.BackColor = Color.LightSeaGreen;
                    txtInactivity.BackColor = Color.Green;
                }
                else
                {
                    txtInactivity.Text = "Invalid input";
                    MessageBox.Show("Enter digits only, in seconds.", "Invalid", MessageBoxButtons.OK);
                }
            }
        }

        #endregion

        #endregion

    }
}
