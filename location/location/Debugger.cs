using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace location
{
    /// <summary>
    /// Class Debugger: prints messages or doesn't print based on a single readonly bool. Intialised through constructor.
    /// </summary>
    public class Debugger
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

        public void print(string s)
        {
            toBeOrNotToBe(s);
        }

        public void established()
        {
            toBeOrNotToBe("Connection to server has been established!");
        }

        public void choosingProtocol()
        {
            toBeOrNotToBe("Selecting protocol...");
        }

        public void isChosen(string prtcl)
        {
            toBeOrNotToBe("Protocol selected: {0}" + prtcl);
        }

        public void Get(string s)
        {
            toBeOrNotToBe("Request: GET [" + s + "]");
        }

        public void Set(string s)
        {
            toBeOrNotToBe("Request: SET [" + s + "]");
        }

        #endregion
        
    }
}
