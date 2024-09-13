using System;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;

namespace location
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

        #region Form Variables + Declarations

        private int timeOutLimit = 1000;
        private string protocol = "whois";
        private string server = "whois.net.dcs.hull.ac.uk";
        private int port = 43;
        private bool debugToggle = false;

        private string whatToDo = string.Empty;
        private string name = string.Empty;
        private string location = string.Empty;

        Debugger debugger;

        #endregion

        #region Main body of Code

        #region Form Intialisation

        public MainForm()
        {
            // Intialise Debugger class with Form initialisation
            debugger = new Debugger(debugToggle); 

            InitializeComponent();

            // Set Colour of toggle buttons
            btnDebugToggle.BackColor = debugToggle ? Color.Green : Color.Red; 

            // Hide Console when GUI launched
            HideConsoleWindow();
            isOpen = false;
        }

        #endregion

        #region Main Client Code from non-GUI Client

        /// <summary>
        /// Handles Client request. Main method from non-GUI Client.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="location"></param>
        /// <param name="whatToDo"></param>
        private void oldClientMain(string name, string location, string whatToDo)
        {
            TcpClient client = null;

            try
            {
                client = new TcpClient(server, port); // Start Client

                if (timeOutLimit != 0) // Set Timeout if timeOutLimit > 0. Default: 1000. False if timeOutLimit == 0;
                {
                    client.ReceiveTimeout = timeOutLimit;
                    client.SendTimeout = timeOutLimit;
                }

                NetworkStream stream = client.GetStream(); // Open Stream
                debugger.established();

                debugger.choosingProtocol();
                string response = string.Empty;

                switch (protocol) // Route based on protocol, to relevant child classes to handle request.
                {
                    case "whois":
                        debugger.isChosen("whois");

                        Whois whois = new Whois(debugToggle); whois.Work(whatToDo, name, location, ref client, ref stream);
                        response = whois.GetResponse();

                        break;
                    case "-h0":
                        debugger.isChosen("HTTP 1.0");

                        H0 h0 = new H0(debugToggle); h0.Work(whatToDo, name, location, ref client, ref stream);
                        response = h0.GetResponse();

                        break;
                    case "-h1":
                        debugger.isChosen("HTTP 1.1");

                        H1 h1 = new H1(server, debugToggle); h1.Work(whatToDo, name, location, ref client, ref stream);
                        response = h1.GetResponse();

                        break;
                    case "-h9":
                        debugger.isChosen("HTTP 0.9");

                        H9 h9 = new H9(debugToggle); h9.Work(whatToDo, name, location, ref client, ref stream);
                        response = h9.GetResponse();

                        break;
                }

                // Print Response from server to GUI
                lblResponse.Invoke((MethodInvoker)(() => { lblResponse.Text = response; }));                
                pnlCover.Invoke((MethodInvoker)(() => { pnlCover.BackColor = Color.LightSeaGreen; }));

            }
            catch (Exception e)
            {
                if (e.Message == "No such host is known")
                {
                    lblResponse.Invoke((MethodInvoker)(() => { lblResponse.Text = "Connection to server failed"; }));
                }
                else
                {
                    Console.WriteLine(e.Message);
                }
            }
            finally
            {
                if (client != null) // Close TCPClient when request completed.
                {
                    client.Close();
                }
            }
        }

        #endregion

        #endregion

        #region Buttons

        #region GET SET Buttons

        Thread t;

        /// <summary>
        /// Handle GET request from GUI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGet_Click(object sender, EventArgs e)
        {
            if(t != null)
                t.Abort();

            // Get values from form
            whatToDo = "GET";
            name = txtName.Text;
            location = txtLocation.Text;

            // If given name is valid, call Client method
            if (name != "" && !name.Contains(' '))
            {
                t = new Thread(() => oldClientMain(name, location, whatToDo));
                t.Start();

                pnlSet.Visible = false;
                pnlGet.Visible = false;
                pnlCover.Visible = true;
            }
        }

        /// <summary>
        /// Handles SET request from GUI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSet_Click(object sender, EventArgs e)
        {
            if (t != null)
                t.Abort();

            // Get values from form
            whatToDo = "SET";
            name = txtNameSet.Text;
            location = txtLocation.Text;

            // If given name and location are valid, call Client method
            if (name != "" && !name.Contains(' ') && location != "")
            {
                t = new Thread(() => oldClientMain(name, location, whatToDo));
                t.Start();

                pnlSet.Visible = false;
                pnlGet.Visible = false;
                pnlCover.Visible = true;
            }
        }

        #endregion

        #region Side Options Menu

        #region Menu Variables

        private bool isServerCollapsed = true;
        private bool isPortCollapsed = true;
        private bool isPrtclCollapsed = true;
        private bool isTOCollapsed = true;

        #endregion

        #region Menu Methods

        /// <summary>
        /// Control opening and closing of panels
        /// </summary>
        /// <param name="pnl"></param>
        /// <param name="coll"></param>
        /// <param name="tmr"></param>
        private void workMenu(Panel pnl, ref bool coll, ref System.Windows.Forms.Timer tmr)
        {
            if (coll) // Close, so open
            {
                pnl.Height += 10;
                if (pnl.Size == pnl.MaximumSize)
                {
                    tmr.Stop();
                    coll = false;
                }
            }
            else // Open, so close
            {
                pnl.Height -= 10;
                if (pnl.Size == pnl.MinimumSize)
                {
                    tmr.Stop();
                    coll = true;
                }
            }
        }

        /// <summary>
        /// Ensure only one panel open at a given time
        /// </summary>
        /// <param name="coll"></param>
        /// <param name="s"></param>
        /// <param name="e"></param>
        private void closeMenu(ref bool coll, ref Object s, ref EventArgs e)
        {
            if(coll != isServerCollapsed && isServerCollapsed == false)
            {
                btnServer_Click(s, e);
            }
            if (coll != isPortCollapsed && isPortCollapsed == false)
            {
                btnPort_Click(s, e);
            }
            if (coll != isTOCollapsed && isTOCollapsed == false)
            {
                btnTO_Click(s, e);
            }
            if (coll != isPrtclCollapsed && isPrtclCollapsed == false)
            {
                btnPrtcl_Click(s, e);
            }
        }

        #endregion

        #region Server Panel

        private void tmrServer_Tick(object sender, EventArgs e)
        {
            workMenu(pnlServer, ref isServerCollapsed, ref tmrServer);
        }

        private void btnServer_Click(object sender, EventArgs e)
        {
            closeMenu(ref isServerCollapsed, ref sender, ref e);
            tmrServer.Start();
        }

        private void btnLocalhost_Click(object sender, EventArgs e)
        {
            server = "127.0.0.1";
            lblServer.Text = "127.0.0.1";
        }

        private void btnHulluni_Click(object sender, EventArgs e)
        {
            server = "whois.net.dcs.hull.ac.uk";
            lblServer.Text = "whois.net.dcs.hull.ac.uk";
        }

        private void txtServer_MouseClick(object sender, MouseEventArgs e)
        {
            if(txtServer.Text == "Manual Entry")
            {
                txtServer.Text = "";
            }
        }
        private void txtServer_TextChanged(object sender, EventArgs e)
        {
            server = txtServer.Text;
            lblServer.Text = server;
        }

        #endregion

        #region Port Panel

        private void tmrPort_Tick(object sender, EventArgs e)
        {
            workMenu(pnlPort, ref isPortCollapsed, ref tmrPort);
        }
        private void btnPort_Click(object sender, EventArgs e)
        {
            closeMenu(ref isPortCollapsed, ref sender, ref e);
            tmrPort.Start();
        }

        private void btn43_Click(object sender, EventArgs e)
        {
            port = 43;
            lblPort.Text = "43";
        }

        private void txtPort_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtPort.Text == "Manual Entry" || txtPort.Text == "Invalid Port Number")
            {
                txtPort.Text = "";
            }
        }
        private void txtPort_TextChanged(object sender, EventArgs e)
        {
            string str = txtPort.Text;

            if (str != "")
            {
                if (str.All(Char.IsDigit) && str.Length < 11)
                {
                    port = int.Parse(str);
                    lblPort.Text = str;
                }
                else
                {
                    txtPort.Text = "Invalid Port Number";
                }
            }
        }

        #endregion

        #region Timeout Panel

        private void tmrTimeout_Tick(object sender, EventArgs e)
        {
            workMenu(pnlTimeout, ref isTOCollapsed, ref tmrTimeout);
        }
        private void btnTO_Click(object sender, EventArgs e)
        {
            closeMenu(ref isTOCollapsed, ref sender, ref e);
            tmrTimeout.Start();
        }
        private void btnTOOff_Click(object sender, EventArgs e)
        {
            timeOutLimit = 0;
            txtTimeout.Text = "0";
        }

        private void btnTO1000_Click(object sender, EventArgs e)
        {
            timeOutLimit = 1000;
            txtTimeout.Text = "1000";
        }

        private void txtTimeout_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtTimeout.Text == "Manual Entry" || txtTimeout.Text == "Invalid Timeout Value")
            {
                txtTimeout.Text = "";
            }
        }
        private void txtTimeout_TextChanged(object sender, EventArgs e)
        {
            string str = txtTimeout.Text;

            if (str != "")
            {
                if (str.All(Char.IsDigit) && str.Length < 11)
                {
                    timeOutLimit = int.Parse(str);
                }
                else
                {
                    txtTimeout.Text = "Invalid Timeout Value";
                }
            }
        }

        #endregion

        #region Protocol Panel

        private void tmrPrtcl_Tick(object sender, EventArgs e)
        {
            workMenu(pnlPrtcl, ref isPrtclCollapsed, ref tmrPrtcl);
        }

        private void btnPrtcl_Click(object sender, EventArgs e)
        {
            closeMenu(ref isPrtclCollapsed, ref sender, ref e);
            tmrPrtcl.Start();
        }

        private void btnWhois_Click(object sender, EventArgs e)
        {
            protocol = "whois";
            lblPrtcl.Text = "whois";
        }

        private void btnH9_Click(object sender, EventArgs e)
        {
            protocol = "-h9";
            lblPrtcl.Text = "HTTP 0.9";
        }

        private void btnH0_Click(object sender, EventArgs e)
        {
            protocol = "-h0";
            lblPrtcl.Text = "HTTP 1.0";
        }

        private void btnH1_Click(object sender, EventArgs e)
        {
            protocol = "-h1";
            lblPrtcl.Text = "HTTP 1.1";
        }

        #endregion

        #endregion

        #region Main Panel

        /// <summary>
        /// Open GET Panel, when mouse hovers over GET Button. If no server response currently being shown.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetUI_MouseEnter(object sender, EventArgs e)
        {
            if (lblResponse.Text == "")
            {
                btnGetUI.BackColor = Color.Green;
                btnSetUI.BackColor = Color.LightSeaGreen;
                pnlCover.Visible = false;
                pnlSet.Visible = false;
                pnlGet.Visible = true;
            }
        }

        /// <summary>
        /// Open SET Panel, when mouse hovers over SET Button. If no server response currently being shown.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetUI_MouseEnter(object sender, EventArgs e)
        {
            if (lblResponse.Text == "")
            {
                btnSetUI.BackColor = Color.Green;
                btnGetUI.BackColor = Color.LightSeaGreen;
                pnlCover.Visible = false;
                pnlGet.Visible = false;
                pnlSet.Visible = true;
            }
        }

        /// <summary>
        /// Open GET Panel, when mouse clicks GET Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetUI_Click(object sender, EventArgs e)
        {
            btnGetUI.BackColor = Color.Green;
            btnSetUI.BackColor = Color.LightSeaGreen;
            lblResponse.Text = "";
            pnlCover.Visible = false;
            pnlSet.Visible = false;
            pnlGet.Visible = true;
        }

        /// <summary>
        /// Open SET Panel, when mouse clicks GET Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetUI_Click(object sender, EventArgs e)
        {
            btnSetUI.BackColor = Color.Green;
            btnGetUI.BackColor = Color.LightSeaGreen;
            lblResponse.Text = "";
            pnlCover.Visible = false;
            pnlGet.Visible = false;
            pnlSet.Visible = true;
        }

        #endregion

        #region Utility Buttons

        /// <summary>
        /// Exit Application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
            Environment.Exit(0);
        }

        /// <summary>
        /// Toggle Console Window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConWin_Click(object sender, EventArgs e)
        {
            if (isOpen)
            { 
                // Hide
                HideConsoleWindow();
                isOpen = false;              
            }
            else
            {
                // Show
                ShowConsoleWindow();
                isOpen = true;
            }
            btnConWin.BackColor = isOpen ? Color.Green : Color.Red;
        }

        /// <summary>
        /// Toggle Debugging in Console Window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDebugToggle_Click(object sender, EventArgs e)
        {
            if (debugToggle)
            {
                debugToggle = false;
                debugger = new Debugger(debugToggle);
            }
            else
            {
                debugToggle = true;
                debugger = new Debugger(debugToggle);
            }
            btnDebugToggle.BackColor = debugToggle ? Color.Green : Color.Red;
        }

        #endregion

        #endregion
    }

}
