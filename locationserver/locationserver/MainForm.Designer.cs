namespace locationserver
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnStartServer = new System.Windows.Forms.Button();
            this.btnFiles = new System.Windows.Forms.Button();
            this.btnDebugg = new System.Windows.Forms.Button();
            this.txtRecordsPath = new System.Windows.Forms.TextBox();
            this.txtLogsPath = new System.Windows.Forms.TextBox();
            this.btnForever = new System.Windows.Forms.Button();
            this.btnFive = new System.Windows.Forms.Button();
            this.btnFifteen = new System.Windows.Forms.Button();
            this.btnThirty = new System.Windows.Forms.Button();
            this.lblServerStatus = new System.Windows.Forms.Label();
            this.btnRecordsLaunch = new System.Windows.Forms.Button();
            this.btnLogLaunch = new System.Windows.Forms.Button();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnConWin = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblServerInactive = new System.Windows.Forms.Label();
            this.lblFiles = new System.Windows.Forms.Label();
            this.lblDebuggToggle = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.btnStopServer = new System.Windows.Forms.Button();
            this.txtInactivity = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.pnlTop.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStartServer
            // 
            this.btnStartServer.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnStartServer.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnStartServer.FlatAppearance.BorderSize = 5;
            this.btnStartServer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartServer.Font = new System.Drawing.Font("Verdana", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartServer.ForeColor = System.Drawing.Color.White;
            this.btnStartServer.Location = new System.Drawing.Point(19, 281);
            this.btnStartServer.Name = "btnStartServer";
            this.btnStartServer.Size = new System.Drawing.Size(309, 84);
            this.btnStartServer.TabIndex = 0;
            this.btnStartServer.Text = "Start Server";
            this.btnStartServer.UseVisualStyleBackColor = false;
            this.btnStartServer.Click += new System.EventHandler(this.btnStartServer_Click);
            // 
            // btnFiles
            // 
            this.btnFiles.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnFiles.FlatAppearance.BorderSize = 5;
            this.btnFiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiles.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiles.Location = new System.Drawing.Point(107, 174);
            this.btnFiles.Name = "btnFiles";
            this.btnFiles.Size = new System.Drawing.Size(204, 55);
            this.btnFiles.TabIndex = 0;
            this.btnFiles.Text = "Save Files";
            this.btnFiles.UseVisualStyleBackColor = true;
            this.btnFiles.Click += new System.EventHandler(this.btnFiles_Click);
            // 
            // btnDebugg
            // 
            this.btnDebugg.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnDebugg.FlatAppearance.BorderSize = 5;
            this.btnDebugg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDebugg.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDebugg.Location = new System.Drawing.Point(107, 108);
            this.btnDebugg.Name = "btnDebugg";
            this.btnDebugg.Size = new System.Drawing.Size(204, 55);
            this.btnDebugg.TabIndex = 0;
            this.btnDebugg.Text = "Debugging";
            this.btnDebugg.UseVisualStyleBackColor = true;
            this.btnDebugg.Click += new System.EventHandler(this.btnDebugg_Click);
            // 
            // txtRecordsPath
            // 
            this.txtRecordsPath.BackColor = System.Drawing.Color.LightSeaGreen;
            this.txtRecordsPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRecordsPath.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRecordsPath.ForeColor = System.Drawing.Color.White;
            this.txtRecordsPath.Location = new System.Drawing.Point(95, 385);
            this.txtRecordsPath.Name = "txtRecordsPath";
            this.txtRecordsPath.Size = new System.Drawing.Size(200, 31);
            this.txtRecordsPath.TabIndex = 1;
            this.txtRecordsPath.Text = "path to Records";
            this.txtRecordsPath.Leave += new System.EventHandler(this.txtRecordsPath_Leave);
            // 
            // txtLogsPath
            // 
            this.txtLogsPath.BackColor = System.Drawing.Color.LightSeaGreen;
            this.txtLogsPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLogsPath.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLogsPath.ForeColor = System.Drawing.Color.White;
            this.txtLogsPath.Location = new System.Drawing.Point(95, 431);
            this.txtLogsPath.Name = "txtLogsPath";
            this.txtLogsPath.Size = new System.Drawing.Size(200, 31);
            this.txtLogsPath.TabIndex = 1;
            this.txtLogsPath.Text = "path to Logs";
            this.txtLogsPath.Leave += new System.EventHandler(this.txtLogsPath_Leave);
            // 
            // btnForever
            // 
            this.btnForever.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnForever.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnForever.FlatAppearance.BorderSize = 5;
            this.btnForever.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnForever.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnForever.ForeColor = System.Drawing.Color.White;
            this.btnForever.Location = new System.Drawing.Point(366, 75);
            this.btnForever.Name = "btnForever";
            this.btnForever.Size = new System.Drawing.Size(198, 51);
            this.btnForever.TabIndex = 2;
            this.btnForever.Text = "Run Forever";
            this.btnForever.UseVisualStyleBackColor = false;
            this.btnForever.Click += new System.EventHandler(this.btnForever_Click);
            // 
            // btnFive
            // 
            this.btnFive.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnFive.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnFive.FlatAppearance.BorderSize = 5;
            this.btnFive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFive.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFive.ForeColor = System.Drawing.Color.White;
            this.btnFive.Location = new System.Drawing.Point(130, 75);
            this.btnFive.Name = "btnFive";
            this.btnFive.Size = new System.Drawing.Size(198, 51);
            this.btnFive.TabIndex = 2;
            this.btnFive.Text = "5 Seconds";
            this.btnFive.UseVisualStyleBackColor = false;
            this.btnFive.Click += new System.EventHandler(this.btnFive_Click);
            // 
            // btnFifteen
            // 
            this.btnFifteen.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnFifteen.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnFifteen.FlatAppearance.BorderSize = 5;
            this.btnFifteen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFifteen.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFifteen.ForeColor = System.Drawing.Color.White;
            this.btnFifteen.Location = new System.Drawing.Point(130, 132);
            this.btnFifteen.Name = "btnFifteen";
            this.btnFifteen.Size = new System.Drawing.Size(198, 51);
            this.btnFifteen.TabIndex = 2;
            this.btnFifteen.Text = "15 Seconds";
            this.btnFifteen.UseVisualStyleBackColor = false;
            this.btnFifteen.Click += new System.EventHandler(this.btnFifteen_Click);
            // 
            // btnThirty
            // 
            this.btnThirty.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnThirty.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnThirty.FlatAppearance.BorderSize = 5;
            this.btnThirty.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThirty.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThirty.ForeColor = System.Drawing.Color.White;
            this.btnThirty.Location = new System.Drawing.Point(130, 189);
            this.btnThirty.Name = "btnThirty";
            this.btnThirty.Size = new System.Drawing.Size(198, 51);
            this.btnThirty.TabIndex = 2;
            this.btnThirty.Text = "30 Seconds";
            this.btnThirty.UseVisualStyleBackColor = false;
            this.btnThirty.Click += new System.EventHandler(this.btnThirty_Click);
            // 
            // lblServerStatus
            // 
            this.lblServerStatus.AutoSize = true;
            this.lblServerStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblServerStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblServerStatus.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServerStatus.ForeColor = System.Drawing.Color.Black;
            this.lblServerStatus.Location = new System.Drawing.Point(3, 3);
            this.lblServerStatus.Name = "lblServerStatus";
            this.lblServerStatus.Size = new System.Drawing.Size(176, 16);
            this.lblServerStatus.TabIndex = 3;
            this.lblServerStatus.Text = "Server Status: Standby";
            // 
            // btnRecordsLaunch
            // 
            this.btnRecordsLaunch.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnRecordsLaunch.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnRecordsLaunch.FlatAppearance.BorderSize = 5;
            this.btnRecordsLaunch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecordsLaunch.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecordsLaunch.ForeColor = System.Drawing.Color.White;
            this.btnRecordsLaunch.Location = new System.Drawing.Point(22, 280);
            this.btnRecordsLaunch.Name = "btnRecordsLaunch";
            this.btnRecordsLaunch.Size = new System.Drawing.Size(138, 56);
            this.btnRecordsLaunch.TabIndex = 2;
            this.btnRecordsLaunch.Text = "Records";
            this.btnRecordsLaunch.UseVisualStyleBackColor = false;
            this.btnRecordsLaunch.Click += new System.EventHandler(this.btnRecordsLaunch_Click);
            // 
            // btnLogLaunch
            // 
            this.btnLogLaunch.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnLogLaunch.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnLogLaunch.FlatAppearance.BorderSize = 5;
            this.btnLogLaunch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogLaunch.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogLaunch.ForeColor = System.Drawing.Color.White;
            this.btnLogLaunch.Location = new System.Drawing.Point(166, 280);
            this.btnLogLaunch.Name = "btnLogLaunch";
            this.btnLogLaunch.Size = new System.Drawing.Size(138, 56);
            this.btnLogLaunch.TabIndex = 2;
            this.btnLogLaunch.Text = "Log";
            this.btnLogLaunch.UseVisualStyleBackColor = false;
            this.btnLogLaunch.Click += new System.EventHandler(this.btnLogLaunch_Click);
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.LightSeaGreen;
            this.pnlTop.Controls.Add(this.btnConWin);
            this.pnlTop.Controls.Add(this.label1);
            this.pnlTop.Controls.Add(this.btnExit);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1024, 85);
            this.pnlTop.TabIndex = 4;
            this.pnlTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTop_MouseDown);
            this.pnlTop.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlTop_MouseMove);
            this.pnlTop.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlTop_MouseUp);
            // 
            // btnConWin
            // 
            this.btnConWin.BackColor = System.Drawing.Color.Red;
            this.btnConWin.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnConWin.FlatAppearance.BorderSize = 5;
            this.btnConWin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConWin.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConWin.ForeColor = System.Drawing.Color.White;
            this.btnConWin.Location = new System.Drawing.Point(629, 12);
            this.btnConWin.Name = "btnConWin";
            this.btnConWin.Size = new System.Drawing.Size(230, 56);
            this.btnConWin.TabIndex = 3;
            this.btnConWin.Text = "Toggle Console";
            this.btnConWin.UseVisualStyleBackColor = false;
            this.btnConWin.Click += new System.EventHandler(this.btnConWin_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(447, 59);
            this.label1.TabIndex = 0;
            this.label1.Text = "Location Server";
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnExit.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnExit.FlatAppearance.BorderSize = 5;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(865, 12);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(138, 56);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightSeaGreen;
            this.panel2.Controls.Add(this.lblServerInactive);
            this.panel2.Controls.Add(this.lblFiles);
            this.panel2.Controls.Add(this.lblDebuggToggle);
            this.panel2.Controls.Add(this.lblServerStatus);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 503);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1024, 24);
            this.panel2.TabIndex = 5;
            // 
            // lblServerInactive
            // 
            this.lblServerInactive.AutoSize = true;
            this.lblServerInactive.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServerInactive.Location = new System.Drawing.Point(550, 3);
            this.lblServerInactive.Name = "lblServerInactive";
            this.lblServerInactive.Size = new System.Drawing.Size(122, 16);
            this.lblServerInactive.TabIndex = 3;
            this.lblServerInactive.Text = "Server Sleep in:";
            // 
            // lblFiles
            // 
            this.lblFiles.AutoSize = true;
            this.lblFiles.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiles.Location = new System.Drawing.Point(376, 3);
            this.lblFiles.Name = "lblFiles";
            this.lblFiles.Size = new System.Drawing.Size(158, 16);
            this.lblFiles.TabIndex = 3;
            this.lblFiles.Text = "File Saving: Disabled";
            // 
            // lblDebuggToggle
            // 
            this.lblDebuggToggle.AutoSize = true;
            this.lblDebuggToggle.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDebuggToggle.Location = new System.Drawing.Point(205, 3);
            this.lblDebuggToggle.Name = "lblDebuggToggle";
            this.lblDebuggToggle.Size = new System.Drawing.Size(156, 16);
            this.lblDebuggToggle.TabIndex = 3;
            this.lblDebuggToggle.Text = "Debugging: Disabled";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 245);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "Launch Files:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 349);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(230, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "Change File Paths:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 390);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 18);
            this.label4.TabIndex = 7;
            this.label4.Text = "Records";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(14, 434);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 18);
            this.label5.TabIndex = 7;
            this.label5.Text = "Logs";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(171, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(367, 25);
            this.label6.TabIndex = 6;
            this.label6.Text = "Set Server Inactivity Timeout:";
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.White;
            this.pnlMain.Controls.Add(this.btnFifteen);
            this.pnlMain.Controls.Add(this.btnThirty);
            this.pnlMain.Controls.Add(this.btnFive);
            this.pnlMain.Controls.Add(this.label6);
            this.pnlMain.Controls.Add(this.btnForever);
            this.pnlMain.Controls.Add(this.btnStopServer);
            this.pnlMain.Controls.Add(this.btnStartServer);
            this.pnlMain.Controls.Add(this.txtInactivity);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlMain.Location = new System.Drawing.Point(326, 85);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(698, 418);
            this.pnlMain.TabIndex = 8;
            // 
            // btnStopServer
            // 
            this.btnStopServer.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnStopServer.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnStopServer.FlatAppearance.BorderSize = 5;
            this.btnStopServer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStopServer.Font = new System.Drawing.Font("Verdana", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStopServer.ForeColor = System.Drawing.Color.White;
            this.btnStopServer.Location = new System.Drawing.Point(366, 281);
            this.btnStopServer.Name = "btnStopServer";
            this.btnStopServer.Size = new System.Drawing.Size(309, 84);
            this.btnStopServer.TabIndex = 0;
            this.btnStopServer.Text = "Stop Server";
            this.btnStopServer.UseVisualStyleBackColor = false;
            this.btnStopServer.Click += new System.EventHandler(this.btnStopServer_Click);
            // 
            // txtInactivity
            // 
            this.txtInactivity.BackColor = System.Drawing.Color.LightSeaGreen;
            this.txtInactivity.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtInactivity.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInactivity.ForeColor = System.Drawing.Color.White;
            this.txtInactivity.Location = new System.Drawing.Point(370, 144);
            this.txtInactivity.Name = "txtInactivity";
            this.txtInactivity.Size = new System.Drawing.Size(188, 24);
            this.txtInactivity.TabIndex = 1;
            this.txtInactivity.Text = "Manual Entry (s)";
            this.txtInactivity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtInactivity.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtInactivity_MouseClick);
            this.txtInactivity.TextChanged += new System.EventHandler(this.txtInactivity_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 123);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 25);
            this.label7.TabIndex = 6;
            this.label7.Text = "Toggle:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(1024, 527);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnLogLaunch);
            this.Controls.Add(this.btnRecordsLaunch);
            this.Controls.Add(this.txtLogsPath);
            this.Controls.Add(this.txtRecordsPath);
            this.Controls.Add(this.btnDebugg);
            this.Controls.Add(this.btnFiles);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximumSize = new System.Drawing.Size(1024, 527);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStartServer;
        private System.Windows.Forms.Button btnFiles;
        private System.Windows.Forms.Button btnDebugg;
        private System.Windows.Forms.TextBox txtRecordsPath;
        private System.Windows.Forms.TextBox txtLogsPath;
        private System.Windows.Forms.Button btnForever;
        private System.Windows.Forms.Button btnFive;
        private System.Windows.Forms.Button btnFifteen;
        private System.Windows.Forms.Button btnThirty;
        private System.Windows.Forms.Label lblServerStatus;
        private System.Windows.Forms.Button btnRecordsLaunch;
        private System.Windows.Forms.Button btnLogLaunch;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblServerInactive;
        private System.Windows.Forms.Label lblFiles;
        private System.Windows.Forms.Label lblDebuggToggle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtInactivity;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnConWin;
        private System.Windows.Forms.Button btnStopServer;
    }
}