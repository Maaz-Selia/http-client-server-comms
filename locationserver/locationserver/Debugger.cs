using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    /// <summary>
    /// Class Debugger: Simple class which prints messages or doesn't print based on a single bool. Bool attained via constructor.
    /// </summary>
    class Debugger
    {

        #region Class Variables

        readonly bool toggle; // Bool which decides whether to print or not to print;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor: Takes in a bool, prints or doesn't print messages based on value of bool toggle.
        /// </summary>
        /// <param name="toggle"></param>
        public Debugger(bool toggle)
        {
            this.toggle = toggle;
        }

        #endregion

        #region Class Methods

        /// <summary>
        /// Private Method: Takes in a string and print or doesn't print said string based on bool toggle.
        /// </summary>
        /// <param name="s"></param>
        private void toBeOrNotToBe(string s)
        {
            if (toggle)
            {
                Console.WriteLine(s);
            }
        }

        public void finished()
        {
            toBeOrNotToBe("Server sleeping...\r\n");
        }
        public void listening()
        {
            toBeOrNotToBe("Server ready...\r\n");
        }

        public void established(string name)
        {
            toBeOrNotToBe("Client No. " + name + ": Conn. established");
        }

        public void threadStarted(string name)
        {
            toBeOrNotToBe("Client No. " + name + ": Request recieved");
        }

        public void threadFinished(int name)
        {
            toBeOrNotToBe("Client No. " + name.ToString() + ": Request completed.");
        }

        public void request(string prtcl, string work, string name, string location)
        {
            if (work == "GET")
            {
                toBeOrNotToBe("Request:[Prtcl:" + prtcl + "] [Mthd:" + work + "] [Name:" + name + "]");
            }
            else if (work == "SET")
            {
                toBeOrNotToBe("Request: [Prtcl:" + prtcl + "] [Mthd:" + work + "] [Name:" + name + "] [Location:" + location + "]");
            }
        }

        #endregion

    }
}
