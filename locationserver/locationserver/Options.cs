using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    /// <summary>
    /// Class Options: reads the args[] and deciphers its content. i.e. Flags, file paths, and file permissions etc.
    /// </summary>
    class Options
    {

        #region Class Variables

        string[] inputs;

        #region Optional Values: Flags, file paths, and default values

        private int timeOutLimit = 1000;
        private bool timeLimit = true;

        private bool debugToggle = false;

        private bool saveRecords = false;
        private string logFile = "log.txt";
        private string dbFile = "records.txt";

        #endregion

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor: To be used for args[]. Takes in a string[], and deciphers its contents. i.e. Flags, and file paths.
        /// </summary>
        /// <param name="inputs"></param>
        public Options(string[] inputs)
        {
            this.inputs = inputs; // Make a copy of array recieved through parameter

            for (int i = 0; i < this.inputs.Length; i++)
            {
                try
                {
                    // Search through string[] for relevant flags, and set corresponding values
                    if (this.inputs[i] == "-l") // Save Logs
                    {
                        if ((i + 1) < inputs.Length && (inputs[i + 1] != "-f") && (inputs[i + 1] != "-l") && (inputs[i + 1] != "-t") && (inputs[i + 1] != "-d") && (inputs[i + 1] != "-w"))
                        {
                            this.logFile = this.inputs[i + 1]; // Non-default Logs path
                        }
                        this.saveRecords = true;
                    }
                    else if (this.inputs[i] == "-f") // Save Records
                    {
                        if ((i + 1) < inputs.Length && (inputs[i + 1] != "-f") && (inputs[i + 1] != "-l") && (inputs[i + 1] != "-t") && (inputs[i + 1] != "-d") && (inputs[i + 1] != "-w"))
                        {
                            this.dbFile = this.inputs[i + 1]; // Non-default Records path
                        }
                        this.saveRecords = true;
                    }
                    else if (this.inputs[i] == "-t") // Non-default Timeout duration
                    {
                        if ((i + 1) < inputs.Length && inputs[i + 1].All(char.IsDigit) && (inputs[i + 1] != "-f") && (inputs[i + 1] != "-l") && (inputs[i + 1] != "-t") && (inputs[i + 1] != "-d") && (inputs[i + 1] != "-w"))
                        {
                            this.timeOutLimit = int.Parse(this.inputs[i + 1]);
                        }

                        if (this.timeOutLimit == 0)
                        {
                            this.timeLimit = false;
                        }
                    }
                    else if (this.inputs[i] == "-d") // Enable debugging. Disbaled by default.
                    {
                        this.debugToggle = true;
                    }
                }
                catch (Exception e) { Console.WriteLine(e); }
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
        /// <param name="saveRecords"></param>
        /// <param name="logFile"></param>
        /// <param name="dbFile"></param>
        public void Update(out int timeOutLimit, out bool timeLimit, out bool debugToggle, out bool saveRecords, out string logFile, out string dbFile)
        {
            timeOutLimit = this.timeOutLimit;
            timeLimit = this.timeLimit;
            debugToggle = this.debugToggle;
            saveRecords = this.saveRecords;
            logFile = this.logFile;
            dbFile = this.dbFile;
        }

        #endregion

    }
}
