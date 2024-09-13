# This is a demo project learning about and practice creating client-server applications utilising HTTP communication protocol.
**C#, .NET, Windows Forms, HTTP, Client-Server**

Executables
	Contained in debug folders of respective solutions.
	
.cs Files

	location
		Program.cs // Main
		MainForm.cs // Main GUI
		Protocols.cs // Contains Protocol related classes and interface. Handles sending Client request to Server
		Options.cs // Contains Options class. <summary> Reads the args[] and deciphers its content. i.e. Flags, name, and location. </summary>
		Debugger.cs // Contains Debugger class. <summary> Prints messages or doesn't print based on a single readonly bool. Intialised through constructor. </summary>
		
	locationserver
		Program.cs // Main
		MainForm.cs // Main GUI		
		Options.cs // Contains Options class. <summary> Reads the args[] and deciphers its content. i.e. Flags, file paths, and file permissions etc. </summary>
		Debugger.cs // Contains Debugger class. <summary> Prints messages or doesn't print based on a single readonly bool. Intialised through constructor. </summary>
		ServerFiles.cs // Contains ServerFiles class. <summary> Takes care of all file I/O needs for Server. </summary>
