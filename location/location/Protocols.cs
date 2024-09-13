using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Text.RegularExpressions;

namespace location
{
    #region Protocol Interface + Parent Class

    /// <summary>
    /// Interface: Declares public methods required by 'Protocol' classes.
    /// </summary>
    internal interface IProtocols
    {
        /// <summary>
        /// Main method of class. Routes name, location, GET/SET to correct private methods.
        /// </summary>
        /// <param name="whatToDo"></param>
        /// <param name="name"></param>
        /// <param name="location"></param>
        /// <param name="client"></param>
        /// <param name="stream"></param>
        void Work(string whatToDo, string name, string location, ref TcpClient client, ref NetworkStream stream);
        string GetResponse();
    }
    /// <summary>
    /// Base Class: Parent class for different 'Protocol' type classes.
    /// </summary>
    /// 
    public abstract class Protocols // Parent class
    {

        // String to store response from server.
        private string response; 
        
        // Debugger
        protected Debugger debugger;
      
        /// <summary>
        /// Sends request to referenced server. Request: GET Location.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="client"></param>
        /// <param name="stream"></param>
        protected abstract void GetLocation(string name, ref TcpClient client, ref NetworkStream stream);

        /// <summary>
        /// Sends request to referenced server. Request: SET Location.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="location"></param>
        /// <param name="client"></param>
        /// <param name="stream"></param>
        protected abstract void SetLocation(string name, string location, ref TcpClient client, ref NetworkStream stream);

        /// <summary>
        /// Stores the response from server to "response" string member variable.
        /// </summary>
        /// <param name="rspns"></param>
        protected void SetResponse(string rspns)
        {
            this.response = rspns;
        }

        /// <summary>
        /// Retrieves response from server stored in "response" string member variable.
        /// </summary>
        /// <returns></returns>
        public string GetResponse()
        {
            return response;
        }
    }

    #endregion

    #region Protocol Child Classes

    /// <summary>
    /// Class Whois: Implements the whois type Protocol.
    /// </summary>
    public class Whois : Protocols, IProtocols
    {
        public Whois(bool toggle)
        {
            debugger = new Debugger(toggle);
        }

        /// <summary>
        /// Sends request to referenced server. Request: GET Location.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="client"></param>
        /// <param name="stream"></param>
        protected override void GetLocation(string name, ref TcpClient client, ref NetworkStream stream)
        {
            StreamWriter sw = new StreamWriter(stream, Encoding.ASCII);
            sw.Write(name + "\r\n");
            sw.Flush();

            debugger.Get(name + "\r\n");

            StreamReader sr = new StreamReader(stream, Encoding.ASCII);

            string str = sr.ReadToEnd();
            if (str == "ERROR: no entries found\r\n")
            {
                SetResponse(str);
                Console.WriteLine(str);
            }
            else
            {
                str = name + " is " + str;
                SetResponse(str);
                Console.WriteLine(str);
            }
        }

        /// <summary>
        /// Sends request to referenced server. Request: SET Location.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="location"></param>
        /// <param name="client"></param>
        /// <param name="stream"></param>
        protected override void SetLocation(string name, string location, ref TcpClient client, ref NetworkStream stream)
        {
            StreamWriter sw = new StreamWriter(stream, Encoding.ASCII);
            sw.Write(name + " " + location + "\r\n");
            sw.Flush();

            debugger.Set(name + " " + location + "\r\n");

            StreamReader sr = new StreamReader(stream, Encoding.ASCII);

            string str = sr.ReadToEnd();
            if (str == "OK\r\n")
            {
                str = name + " location changed to be " + location;
                SetResponse(str);
                Console.WriteLine(str);
            }
            else
            {
                str = "SET Location Failed";
                SetResponse(str);
                Console.WriteLine(str);
            }
        }

        /// <summary>
        /// Main method of class. Routes name, location, GET/SET to correct private methods.
        /// </summary>
        /// <param name="whatToDo"></param>
        /// <param name="name"></param>
        /// <param name="location"></param>
        /// <param name="client"></param>
        /// <param name="stream"></param>
        public void Work(string whatToDo, string name, string location, ref TcpClient client, ref NetworkStream stream)
        {
                switch (whatToDo)
                {
                    case "GET":
                        GetLocation(name, ref client, ref stream);
                        break;
                    case "SET":
                        SetLocation(name, location, ref client, ref stream);
                        break;
                }
        }
    }

    /// <summary>
    /// Class H9: Implements the HTTP 0.9 type Protocol.
    /// </summary>
    public class H9 : Protocols, IProtocols
    {
        public H9(bool toggle)
        {
            debugger = new Debugger(toggle);
        }

        /// <summary>
        /// Sends request to referenced server. Request: GET Location.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="client"></param>
        /// <param name="stream"></param>
        protected override void GetLocation(string name, ref TcpClient client, ref NetworkStream stream)
        {
            StreamWriter sw = new StreamWriter(stream, Encoding.ASCII);
            sw.Write("GET /" + name + "\r\n");
            sw.Flush();

            debugger.Get("GET /" + name + "\r\n");

            StreamReader sr = new StreamReader(stream, Encoding.ASCII);

            string str = sr.ReadToEnd();
            if (str == "HTTP/0.9 404 Not Found\r\nContent-Type: text/plain\r\n\r\n")
            {
                SetResponse(str);
                Console.WriteLine(str);
            }
            else
            {
                string[] Arr = Regex.Split(str, "\r\n");
                string resp = name + " is " + Arr[Arr.Length - 2];
                SetResponse(resp);
                Console.WriteLine(resp);
            }
        }

        /// <summary>
        /// Sends request to referenced server. Request: SET Location.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="location"></param>
        /// <param name="client"></param>
        /// <param name="stream"></param>
        protected override void SetLocation(string name, string location, ref TcpClient client, ref NetworkStream stream)
        {
            StreamWriter sw = new StreamWriter(stream, Encoding.ASCII);
            sw.Write("PUT /" + name + "\r\n" +
                "\r\n" + location + "\r\n");
            sw.Flush();

            debugger.Set("PUT /" + name + "\r\n" +
                "\r\n" + location + "\r\n");

            StreamReader sr = new StreamReader(stream, Encoding.ASCII);

            string str = sr.ReadToEnd();
            if (str == "HTTP/0.9 200 OK\r\nContent-Type: text/plain\r\n\r\n")
            {
                str = name + " location changed to be " + location;
                SetResponse(str);
                Console.WriteLine(str);
            }
            else
            {
                str = "SET Location failed";
                SetResponse(str);
                Console.WriteLine(str);
            }
        }

        /// <summary>
        /// Main method of class. Routes name, location, GET/SET to correct private methods.
        /// </summary>
        /// <param name="whatToDo"></param>
        /// <param name="name"></param>
        /// <param name="location"></param>
        /// <param name="client"></param>
        /// <param name="stream"></param>
        public void Work(string whatToDo, string name, string location, ref TcpClient client, ref NetworkStream stream)
        {
            switch (whatToDo)
            {
                case "GET":
                    GetLocation(name, ref client, ref stream);
                    break;
                case "SET":
                    SetLocation(name, location, ref client, ref stream);
                    break;
            }
        }
    }

    /// <summary>
    /// Class H0: Implements the HTTP 1.0 type Protocol.
    /// </summary>
    public class H0 : Protocols, IProtocols
    {
        public H0(bool toggle)
        {
            debugger = new Debugger(toggle);
        }

        /// <summary>
        /// Sends request to referenced server. Request: GET Location.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="client"></param>
        /// <param name="stream"></param>
        protected override void GetLocation(string name, ref TcpClient client, ref NetworkStream stream)
        {
            StreamWriter sw = new StreamWriter(stream, Encoding.ASCII);
            sw.Write("GET /?" + name + " HTTP/1.0\r\n\r\n");
            sw.Flush();

            debugger.Get("GET /?" + name + " HTTP/1.0\r\n\r\n");

            StreamReader sr = new StreamReader(stream, Encoding.ASCII);

            string str = sr.ReadToEnd();
            if (str == "HTTP/1.0 404 Not Found\r\nContent-Type: text/plain\r\n\r\n")
            {
                SetResponse(str);
                Console.WriteLine(str);
            }
            else
            {
                string[] Arr = Regex.Split(str, "\r\n");
                string resp = name + " is " + Arr[Arr.Length - 2];
                SetResponse(resp);
                Console.WriteLine(resp);
            }
        }

        /// <summary>
        /// Sends request to referenced server. Request: SET Location.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="location"></param>
        /// <param name="client"></param>
        /// <param name="stream"></param>
        protected override void SetLocation(string name, string location, ref TcpClient client, ref NetworkStream stream)
        {
            StreamWriter sw = new StreamWriter(stream, Encoding.ASCII);
            sw.Write("POST /" + name + " HTTP/1.0\r\nContent-Length: " + location.Length.ToString() + "\r\n\r\n" + location);
            sw.Flush();

            debugger.Set("POST /" + name + " HTTP/1.0\r\nContent-Length: " + location.Length.ToString() + "\r\n\r\n" + location);

            StreamReader sr = new StreamReader(stream, Encoding.ASCII);

            string str = sr.ReadToEnd();
            if (str == "HTTP/1.0 200 OK\r\nContent-Type: text/plain\r\n\r\n")
            {
                str = name + " location changed to be " + location;
                SetResponse(str);
                Console.WriteLine(str);
            }
            else
            {
                str = "SET Location failed";
                SetResponse(str);
                Console.WriteLine(str);
            }
        }

        /// <summary>
        /// Main method of class. Routes name, location, GET/SET to correct private methods.
        /// </summary>
        /// <param name="whatToDo"></param>
        /// <param name="name"></param>
        /// <param name="location"></param>
        /// <param name="client"></param>
        /// <param name="stream"></param>
        public void Work(string whatToDo, string name, string location, ref TcpClient client, ref NetworkStream stream)
        {
            switch (whatToDo)
            {
                case "GET":
                    GetLocation(name, ref client, ref stream);
                    break;
                case "SET":
                    SetLocation(name, location, ref client, ref stream);
                    break;
            }
        }
    }

    /// <summary>
    /// Class H1: Implements the HTTP 1.1 type Protocol.
    /// </summary>
    public class H1 : Protocols, IProtocols
    {

        private string server = string.Empty;

        /// <summary>
        /// Constructor: Takes in a string for the server address. As it is requires for constructing server request, as per HTTP 1.1 protocol.
        /// </summary>
        /// <param name="server"></param>
        public H1(string server, bool toggle)
        {
            this.server = server;
            debugger = new Debugger(toggle);
        }

        /// <summary>
        /// Sends request to referenced server. Request: GET Location.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="client"></param>
        /// <param name="stream"></param>
        protected override void GetLocation(string name, ref TcpClient client, ref NetworkStream stream)
        {
            StreamWriter sw = new StreamWriter(stream, Encoding.ASCII);
            sw.Write("GET /?name=" + name + " HTTP/1.1\r\nHost: " + server + "\r\n\r\n");
            sw.Flush();

            debugger.Get("GET /?name=" + name + " HTTP/1.1\r\nHost: " + server + "\r\n\r\n");

            StreamReader sr = new StreamReader(stream, Encoding.ASCII);

            string str = sr.ReadToEnd();
            if (str.Contains("HTTP/1.1 404 Not Found\r\nContent-Type: text/plain\r\n"))
            {
                SetResponse(str);
                Console.WriteLine(str);
            }
            else
            {
                string[] Arr = Regex.Split(str, "\r\n");
                string resp = name + " is " + Arr[Arr.Length - 2];
                SetResponse(resp);
                Console.WriteLine(resp);
            }
        }

        /// <summary>
        /// Sends request to referenced server. Request: SET Location.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="location"></param>
        /// <param name="client"></param>
        /// <param name="stream"></param>
        protected override void SetLocation(string name, string location, ref TcpClient client, ref NetworkStream stream)
        {
            StreamWriter sw = new StreamWriter(stream, Encoding.ASCII);
            int length = name.Length + location.Length + 15;
            sw.Write("POST / HTTP/1.1\r\nHost: " + server + "\r\nContent-Length: " + 
                length.ToString() + "\r\n\r\nname=" + name + "&location=" + location);
            sw.Flush();

            debugger.Set("POST / HTTP/1.1\r\nHost: " + server + "\r\nContent-Length: " +
                length.ToString() + "\r\n\r\nname=" + name + "&location=" + location);

            StreamReader sr = new StreamReader(stream, Encoding.ASCII);

            string str = sr.ReadToEnd();
            if (str.Contains("HTTP/1.1 200 OK\r\nContent-Type: text/plain\r\n"))
            {
                str = name + " location changed to be " + location;
                SetResponse(str);
                Console.WriteLine(str);
            }
            else
            {
                str = "SET Location failed";
                SetResponse(str);
                Console.WriteLine(str);
            }
        }

        /// <summary>
        /// Main method of class. Routes name, location, GET/SET to correct private methods.
        /// </summary>
        /// <param name="whatToDo"></param>
        /// <param name="name"></param>
        /// <param name="location"></param>
        /// <param name="client"></param>
        /// <param name="stream"></param>
        public void Work(string whatToDo, string name, string location, ref TcpClient client, ref NetworkStream stream)
        {
            switch (whatToDo)
            {
                case "GET":
                    GetLocation(name, ref client, ref stream);
                    break;
                case "SET":
                    SetLocation(name, location, ref client, ref stream);
                    break;
            }
        }
    }

    #endregion

}
