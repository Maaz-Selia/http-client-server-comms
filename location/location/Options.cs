using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace location
{
    /// <summary>
    /// Class Options: reads the args[] and deciphers its content. i.e. Flags, name, and location etc.
    /// </summary>
    public class Options
    {

        #region Class Variables

        private string[] inputs; // Copies args[] into another array, to not make accidental changes to args[].
      
        #region Optional Values: Flags, name, location, and GET/SET

        private int timeOutLimit = 1000; // timeOutLimit for Client-Server. Default: 1000ms.
        private bool timeLimit = true; // If timeOutLimit == 0, timeLimit set to false.
        private bool debugToggle = false; // Enable or Disable debugging. Default: false.

        private string protocol = "whois"; // Protocol. Default: whois.
        private string server = "whois.net.dcs.hull.ac.uk"; // Server. Default: Hull University
        private int port = 43; // Port. Default: 43.

        private string whatToDo = string.Empty; // GET or SET
        private string name = string.Empty;
        private string location = null;

        #endregion

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor: To be used for args[]. Takes in a string[], and deciphers its contents. i.e. Flags, name, and location.
        /// </summary>
        /// <param name="inputs"></param>
        public Options(string[] inputs)
        {
            this.inputs = inputs; // Make a copy of array recieved through parameter
            bool gotProtocol = false;

            // Finds if a non-default protocol flag has been set. If more than one present, then takes the first one as protocol.
            foreach (string s in inputs) 
            {
                if ((s == "-h0") && !gotProtocol) { this.protocol = "-h0"; gotProtocol = true; }
                if ((s == "-h1") && !gotProtocol) { this.protocol = "-h1"; gotProtocol = true; }
                if ((s == "-h9") && !gotProtocol) { this.protocol = "-h9"; gotProtocol = true; }
            }
            doWorkOptions();
            
            // Search through string[] for relevant flags, and set corresponding values
            for(int i = 0; i < this.inputs.Length; i++)
            {
                if (this.inputs[i] == "-h") // Non-default Server address
                {
                    if ((i + 1) < inputs.Length && (inputs[i + 1] != "-p") && (inputs[i + 1] != "-t") && (inputs[i + 1] != "-d"))
                    {
                        this.server = this.inputs[i + 1];
                    }
                }
                if (this.inputs[i] == "-p") // Non-default Port
                {
                    if ((i + 1) < inputs.Length && inputs[i + 1].All(char.IsDigit) && (inputs[i + 1] != "-p") && (inputs[i + 1] != "-t") && (inputs[i + 1] != "-d"))
                    {
                        this.port = int.Parse(this.inputs[i + 1]);
                    }
                }
                if (this.inputs[i] == "-t") // Non-default Timeout duration
                {
                    if ((i + 1) < inputs.Length && inputs[i + 1].All(char.IsDigit) && (inputs[i + 1] != "-p") && (inputs[i + 1] != "-t") && (inputs[i + 1] != "-d"))
                    {
                        this.timeOutLimit = int.Parse(this.inputs[i + 1]);
                    }

                    if (this.timeOutLimit == 0)
                    {
                        this.timeLimit = false;
                    }
                }
                if (this.inputs[i] == "-d") // Enable debugging. Disbaled by default.
                {
                    this.debugToggle = true;
                }
            }
        }

        #endregion

        #region Class Methods

        /// <summary>
        /// Public Method: Updates relevant fields in calling function, based on values derived from args[].
        /// </summary>
        /// <param name="timeOutLimit"></param>
        /// <param name="timeLimit"></param>
        /// <param name="debugToggle"></param>
        /// <param name="protocol"></param>
        /// <param name="server"></param>
        /// <param name="port"></param>
        /// <param name="whatToDo"></param>
        /// <param name="name"></param>
        /// <param name="location"></param>
        public void Update(out int timeOutLimit, out bool timeLimit, out bool debugToggle, out string protocol, out string server, out int port, out string whatToDo, out string name, out string location)
        {
            timeOutLimit = this.timeOutLimit;
            debugToggle = this.debugToggle;
            protocol = this.protocol;
            server = this.server;
            port = this.port;
            whatToDo = this.whatToDo;
            name = this.name;
            location = this.location;           
            timeLimit = this.timeLimit;
        }

        /// <summary>
        /// Private Method: Called within class constructor only. Code for deriving name and location from args[].
        /// </summary>
        private void doWorkOptions()
        {
            try
            {
                string pre = string.Empty;
                bool needName = true;
                bool needLocation = true;
                for (int i = 0; i < inputs.Length; i++)
                {
                    if ((inputs[i] != "-p") && (inputs[i] != "-h0") && (inputs[i] != "-h1") && (inputs[i] != "-h9") && (inputs[i] != "-t") && (inputs[i] != "-d") && (inputs[i] != "-h"))
                    {
                        if ((pre != "-p") && (pre != "-t") && (pre != "-h") && needName) // If current and previous value in args[] != a flag and needName. Then current value must = name.
                        {
                            this.name = inputs[i];
                            needName = false;
                        }
                        else if ((pre != "-p") && (pre != "-t") && (pre != "-h") && needLocation)// If current and previous value in args[] != a flag. And needLocation but !needName. Then current value must = location.
                        {
                            this.location = inputs[i];
                            needLocation = false;
                        }
                    }
                    pre = inputs[i];
                }

                if (!needName && needLocation) // If !needName but needLocation. Then must be GET method as location argument missing.
                {
                    this.whatToDo = "GET";
                }
                else if (!needName && !needLocation) // If !needName and !needLocation. Then must be SET method as have both name and location arguments.
                {
                    this.whatToDo = "SET";
                }
                

            }
            catch
            {
                Console.WriteLine("Incorrect format");
            }
            
        }

        #endregion

    }
}
