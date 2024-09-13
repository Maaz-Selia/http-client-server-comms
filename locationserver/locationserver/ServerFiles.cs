using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    /// <summary>
    /// Class: Takes care of all file I/O needs for Server.
    /// </summary>
    class ServerFiles
    {

        #region Class Variables

        readonly bool saveRecords;
        readonly string logFile;
        readonly string dbFile;
        Dictionary<string, string> dict = new Dictionary<string, string>();

        // Locks to allow multiple threads to write to same file
        static ReaderWriterLockSlim lock1 = new ReaderWriterLockSlim();
        static ReaderWriterLockSlim lock2 = new ReaderWriterLockSlim();

        //string logMsg = string.Empty;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor: Takes file paths and bool to save or not save files.
        /// </summary>
        /// <param name="saveRecords"></param>
        /// <param name="logFile"></param>
        /// <param name="dbFile"></param>
        public ServerFiles(bool saveRecords, string logFile, string dbFile)
        {
            this.saveRecords = saveRecords;
            this.logFile = logFile;
            this.dbFile = dbFile;
        }

        /// <summary>
        /// Constructor: Takes file paths and bool to save or not save files and a Dictionary. Used when new instance of class called multiple times during operation. GUI only.
        /// </summary>
        /// <param name="saveRecords"></param>
        /// <param name="logFile"></param>
        /// <param name="dbFile"></param>
        /// <param name="dict"></param>
        public ServerFiles(bool saveRecords, string logFile, string dbFile, Dictionary<string, string> dict)
        {
            this.saveRecords = saveRecords;
            this.logFile = logFile;
            this.dbFile = dbFile;
            this.dict = dict;
        }

        #endregion

        #region Class Methods

        /// <summary>
        /// Public Method: Loads Records file into a dictionary.
        /// </summary>
        /// <param name="outDict"></param>
        public void initialise(out Dictionary<string, string> outDict)
        {
            if (File.Exists(dbFile))
            {
                StreamReader sr = new StreamReader(dbFile);
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] split = line.Split('|');
                    dict.Add(split[0], split[1]);
                }
                sr.Close();
            }

            outDict = dict;
        } 

        /// <summary>
        /// Public Method: Saves state of dictionary into Records file.
        /// </summary>
        /// <param name="dict"></param>
        public void shutdown(Dictionary<string, string> dict)
        {
            if (saveRecords)
            {
                lock1.EnterWriteLock();

                try
                {
                    File.WriteAllText(dbFile, String.Empty);

                    StreamWriter sw = new StreamWriter(dbFile);

                    foreach (var item in dict)
                    {
                        sw.WriteLine(item.Key + "|" + item.Value);
                        sw.Flush();
                    }
                    sw.Close();
                }
                finally
                {
                    lock1.ExitWriteLock();
                }
            }
        }

        /// <summary>
        /// Appends log entry onto log file.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="debugToggle"></param>
        public void logger(string s, bool debugToggle)
        {

            if (saveRecords)
            {
                lock2.EnterWriteLock();

                try
                {
                    File.AppendAllText(logFile, s + "\n");
                    if (debugToggle)
                    {
                        Console.WriteLine("Logged: " + s);
                    }
                }
                finally
                {
                    lock2.ExitWriteLock();
                }
            }
        }

        #endregion

    }
}
