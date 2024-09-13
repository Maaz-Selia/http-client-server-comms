namespace location
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
            this.components = new System.ComponentModel.Container();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.btnGet = new System.Windows.Forms.Button();
            this.btnSet = new System.Windows.Forms.Button();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnConWin = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblUI = new System.Windows.Forms.Label();
            this.lblResponse = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlServer = new System.Windows.Forms.Panel();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.btnHulluni = new System.Windows.Forms.Button();
            this.btnLocalhost = new System.Windows.Forms.Button();
            this.btnServer = new System.Windows.Forms.Button();
            this.pnlPort = new System.Windows.Forms.Panel();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.btn43 = new System.Windows.Forms.Button();
            this.btnPort = new System.Windows.Forms.Button();
            this.pnlTimeout = new System.Windows.Forms.Panel();
            this.txtTimeout = new System.Windows.Forms.TextBox();
            this.btnTO1000 = new System.Windows.Forms.Button();
            this.btnTOOff = new System.Windows.Forms.Button();
            this.btnTO = new System.Windows.Forms.Button();
            this.pnlPrtcl = new System.Windows.Forms.Panel();
            this.btnH1 = new System.Windows.Forms.Button();
            this.btnH0 = new System.Windows.Forms.Button();
            this.btnH9 = new System.Windows.Forms.Button();
            this.btnWhois = new System.Windows.Forms.Button();
            this.btnPrtcl = new System.Windows.Forms.Button();
            this.tmrServer = new System.Windows.Forms.Timer(this.components);
            this.tmrPort = new System.Windows.Forms.Timer(this.components);
            this.tmrTimeout = new System.Windows.Forms.Timer(this.components);
            this.tmrPrtcl = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblPrtcl = new System.Windows.Forms.Label();
            this.lblPort = new System.Windows.Forms.Label();
            this.lblSrvTag = new System.Windows.Forms.Label();
            this.lblServer = new System.Windows.Forms.Label();
            this.lblPrtclTag = new System.Windows.Forms.Label();
            this.lblPortTag = new System.Windows.Forms.Label();
            this.btnGetUI = new System.Windows.Forms.Button();
            this.pnlGet = new System.Windows.Forms.Panel();
            this.pnlSet = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNameSet = new System.Windows.Forms.TextBox();
            this.btnSetUI = new System.Windows.Forms.Button();
            this.pnlCover = new System.Windows.Forms.Panel();
            this.btnDebugToggle = new System.Windows.Forms.Button();
            this.pnlTop.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.pnlServer.SuspendLayout();
            this.pnlPort.SuspendLayout();
            this.pnlTimeout.SuspendLayout();
            this.pnlPrtcl.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlGet.SuspendLayout();
            this.pnlSet.SuspendLayout();
            this.pnlCover.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.LightSeaGreen;
            this.txtName.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.txtName.Location = new System.Drawing.Point(181, 140);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(200, 40);
            this.txtName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(87, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 59);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Verdana", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(87, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(254, 59);
            this.label2.TabIndex = 2;
            this.label2.Text = "Location";
            // 
            // txtLocation
            // 
            this.txtLocation.BackColor = System.Drawing.Color.LightSeaGreen;
            this.txtLocation.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLocation.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.txtLocation.Location = new System.Drawing.Point(181, 212);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(200, 40);
            this.txtLocation.TabIndex = 3;
            // 
            // btnGet
            // 
            this.btnGet.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnGet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnGet.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnGet.FlatAppearance.BorderSize = 5;
            this.btnGet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGet.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGet.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnGet.Location = new System.Drawing.Point(606, 202);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(140, 61);
            this.btnGet.TabIndex = 4;
            this.btnGet.Text = "Send!";
            this.btnGet.UseVisualStyleBackColor = false;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // btnSet
            // 
            this.btnSet.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnSet.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSet.FlatAppearance.BorderSize = 5;
            this.btnSet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSet.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSet.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnSet.Location = new System.Drawing.Point(606, 202);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(140, 61);
            this.btnSet.TabIndex = 5;
            this.btnSet.Text = "Send!";
            this.btnSet.UseVisualStyleBackColor = false;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.LightSeaGreen;
            this.pnlTop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pnlTop.Controls.Add(this.btnConWin);
            this.pnlTop.Controls.Add(this.btnExit);
            this.pnlTop.Controls.Add(this.lblUI);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1024, 85);
            this.pnlTop.TabIndex = 0;
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
            this.btnConWin.Location = new System.Drawing.Point(611, 12);
            this.btnConWin.Name = "btnConWin";
            this.btnConWin.Size = new System.Drawing.Size(230, 56);
            this.btnConWin.TabIndex = 1;
            this.btnConWin.Text = "Toggle Console";
            this.btnConWin.UseVisualStyleBackColor = false;
            this.btnConWin.Click += new System.EventHandler(this.btnConWin_Click);
            // 
            // btnExit
            // 
            this.btnExit.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnExit.FlatAppearance.BorderSize = 5;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(856, 12);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(138, 56);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblUI
            // 
            this.lblUI.AutoSize = true;
            this.lblUI.BackColor = System.Drawing.Color.Transparent;
            this.lblUI.Font = new System.Drawing.Font("Verdana", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUI.ForeColor = System.Drawing.Color.Black;
            this.lblUI.Location = new System.Drawing.Point(3, 26);
            this.lblUI.Name = "lblUI";
            this.lblUI.Size = new System.Drawing.Size(425, 59);
            this.lblUI.TabIndex = 0;
            this.lblUI.Text = "Location Client";
            // 
            // lblResponse
            // 
            this.lblResponse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblResponse.Font = new System.Drawing.Font("Unispace", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResponse.ForeColor = System.Drawing.Color.White;
            this.lblResponse.Location = new System.Drawing.Point(0, 0);
            this.lblResponse.Name = "lblResponse";
            this.lblResponse.Size = new System.Drawing.Size(772, 284);
            this.lblResponse.TabIndex = 1;
            this.lblResponse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblResponse.UseCompatibleTextRendering = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.LightCyan;
            this.flowLayoutPanel1.Controls.Add(this.pnlServer);
            this.flowLayoutPanel1.Controls.Add(this.pnlPort);
            this.flowLayoutPanel1.Controls.Add(this.pnlTimeout);
            this.flowLayoutPanel1.Controls.Add(this.pnlPrtcl);
            this.flowLayoutPanel1.Controls.Add(this.btnDebugToggle);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 85);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(238, 467);
            this.flowLayoutPanel1.TabIndex = 7;
            // 
            // pnlServer
            // 
            this.pnlServer.Controls.Add(this.txtServer);
            this.pnlServer.Controls.Add(this.btnHulluni);
            this.pnlServer.Controls.Add(this.btnLocalhost);
            this.pnlServer.Controls.Add(this.btnServer);
            this.pnlServer.Location = new System.Drawing.Point(3, 3);
            this.pnlServer.MaximumSize = new System.Drawing.Size(233, 171);
            this.pnlServer.MinimumSize = new System.Drawing.Size(233, 65);
            this.pnlServer.Name = "pnlServer";
            this.pnlServer.Size = new System.Drawing.Size(233, 65);
            this.pnlServer.TabIndex = 8;
            // 
            // txtServer
            // 
            this.txtServer.BackColor = System.Drawing.Color.LightSeaGreen;
            this.txtServer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtServer.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtServer.ForeColor = System.Drawing.Color.White;
            this.txtServer.Location = new System.Drawing.Point(16, 143);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(200, 19);
            this.txtServer.TabIndex = 3;
            this.txtServer.Text = "Manual Entry";
            this.txtServer.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtServer_MouseClick);
            this.txtServer.TextChanged += new System.EventHandler(this.txtServer_TextChanged);
            // 
            // btnHulluni
            // 
            this.btnHulluni.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnHulluni.FlatAppearance.BorderSize = 0;
            this.btnHulluni.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHulluni.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHulluni.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnHulluni.Location = new System.Drawing.Point(16, 104);
            this.btnHulluni.Name = "btnHulluni";
            this.btnHulluni.Size = new System.Drawing.Size(200, 33);
            this.btnHulluni.TabIndex = 2;
            this.btnHulluni.Text = "Hull University";
            this.btnHulluni.UseVisualStyleBackColor = false;
            this.btnHulluni.Click += new System.EventHandler(this.btnHulluni_Click);
            // 
            // btnLocalhost
            // 
            this.btnLocalhost.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnLocalhost.FlatAppearance.BorderSize = 0;
            this.btnLocalhost.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLocalhost.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLocalhost.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnLocalhost.Location = new System.Drawing.Point(16, 65);
            this.btnLocalhost.Name = "btnLocalhost";
            this.btnLocalhost.Size = new System.Drawing.Size(200, 33);
            this.btnLocalhost.TabIndex = 1;
            this.btnLocalhost.Text = "Local Host";
            this.btnLocalhost.UseVisualStyleBackColor = false;
            this.btnLocalhost.Click += new System.EventHandler(this.btnLocalhost_Click);
            // 
            // btnServer
            // 
            this.btnServer.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnServer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnServer.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnServer.FlatAppearance.BorderSize = 3;
            this.btnServer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnServer.Font = new System.Drawing.Font("Verdana", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnServer.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnServer.Location = new System.Drawing.Point(4, 3);
            this.btnServer.Name = "btnServer";
            this.btnServer.Size = new System.Drawing.Size(225, 56);
            this.btnServer.TabIndex = 0;
            this.btnServer.Text = "Server";
            this.btnServer.UseVisualStyleBackColor = false;
            this.btnServer.Click += new System.EventHandler(this.btnServer_Click);
            // 
            // pnlPort
            // 
            this.pnlPort.Controls.Add(this.txtPort);
            this.pnlPort.Controls.Add(this.btn43);
            this.pnlPort.Controls.Add(this.btnPort);
            this.pnlPort.Location = new System.Drawing.Point(3, 74);
            this.pnlPort.MaximumSize = new System.Drawing.Size(233, 135);
            this.pnlPort.MinimumSize = new System.Drawing.Size(233, 65);
            this.pnlPort.Name = "pnlPort";
            this.pnlPort.Size = new System.Drawing.Size(233, 65);
            this.pnlPort.TabIndex = 8;
            // 
            // txtPort
            // 
            this.txtPort.BackColor = System.Drawing.Color.LightSeaGreen;
            this.txtPort.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPort.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPort.ForeColor = System.Drawing.Color.White;
            this.txtPort.Location = new System.Drawing.Point(16, 107);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(200, 20);
            this.txtPort.TabIndex = 3;
            this.txtPort.Text = "Manual Entry";
            this.txtPort.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtPort_MouseClick);
            this.txtPort.TextChanged += new System.EventHandler(this.txtPort_TextChanged);
            // 
            // btn43
            // 
            this.btn43.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btn43.FlatAppearance.BorderSize = 0;
            this.btn43.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn43.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn43.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn43.Location = new System.Drawing.Point(16, 68);
            this.btn43.Name = "btn43";
            this.btn43.Size = new System.Drawing.Size(200, 33);
            this.btn43.TabIndex = 1;
            this.btn43.Text = "Port: 43";
            this.btn43.UseVisualStyleBackColor = false;
            this.btn43.Click += new System.EventHandler(this.btn43_Click);
            // 
            // btnPort
            // 
            this.btnPort.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnPort.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnPort.FlatAppearance.BorderSize = 3;
            this.btnPort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPort.Font = new System.Drawing.Font("Verdana", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPort.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnPort.Location = new System.Drawing.Point(3, 3);
            this.btnPort.Name = "btnPort";
            this.btnPort.Size = new System.Drawing.Size(226, 59);
            this.btnPort.TabIndex = 0;
            this.btnPort.Text = "Port";
            this.btnPort.UseVisualStyleBackColor = false;
            this.btnPort.Click += new System.EventHandler(this.btnPort_Click);
            // 
            // pnlTimeout
            // 
            this.pnlTimeout.Controls.Add(this.txtTimeout);
            this.pnlTimeout.Controls.Add(this.btnTO1000);
            this.pnlTimeout.Controls.Add(this.btnTOOff);
            this.pnlTimeout.Controls.Add(this.btnTO);
            this.pnlTimeout.Location = new System.Drawing.Point(3, 145);
            this.pnlTimeout.MaximumSize = new System.Drawing.Size(233, 176);
            this.pnlTimeout.MinimumSize = new System.Drawing.Size(233, 65);
            this.pnlTimeout.Name = "pnlTimeout";
            this.pnlTimeout.Size = new System.Drawing.Size(233, 65);
            this.pnlTimeout.TabIndex = 8;
            // 
            // txtTimeout
            // 
            this.txtTimeout.BackColor = System.Drawing.Color.LightSeaGreen;
            this.txtTimeout.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTimeout.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimeout.ForeColor = System.Drawing.Color.White;
            this.txtTimeout.Location = new System.Drawing.Point(16, 146);
            this.txtTimeout.Name = "txtTimeout";
            this.txtTimeout.Size = new System.Drawing.Size(200, 20);
            this.txtTimeout.TabIndex = 3;
            this.txtTimeout.Text = "Manual Entry";
            this.txtTimeout.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtTimeout_MouseClick);
            this.txtTimeout.TextChanged += new System.EventHandler(this.txtTimeout_TextChanged);
            // 
            // btnTO1000
            // 
            this.btnTO1000.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnTO1000.FlatAppearance.BorderSize = 0;
            this.btnTO1000.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTO1000.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTO1000.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnTO1000.Location = new System.Drawing.Point(16, 107);
            this.btnTO1000.Name = "btnTO1000";
            this.btnTO1000.Size = new System.Drawing.Size(200, 33);
            this.btnTO1000.TabIndex = 1;
            this.btnTO1000.Text = "1000ms";
            this.btnTO1000.UseVisualStyleBackColor = false;
            this.btnTO1000.Click += new System.EventHandler(this.btnTO1000_Click);
            // 
            // btnTOOff
            // 
            this.btnTOOff.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnTOOff.FlatAppearance.BorderSize = 0;
            this.btnTOOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTOOff.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTOOff.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnTOOff.Location = new System.Drawing.Point(16, 68);
            this.btnTOOff.Name = "btnTOOff";
            this.btnTOOff.Size = new System.Drawing.Size(200, 33);
            this.btnTOOff.TabIndex = 1;
            this.btnTOOff.Text = "Timeout Off";
            this.btnTOOff.UseVisualStyleBackColor = false;
            this.btnTOOff.Click += new System.EventHandler(this.btnTOOff_Click);
            // 
            // btnTO
            // 
            this.btnTO.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnTO.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnTO.FlatAppearance.BorderSize = 3;
            this.btnTO.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTO.Font = new System.Drawing.Font("Verdana", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTO.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnTO.Location = new System.Drawing.Point(3, 3);
            this.btnTO.Name = "btnTO";
            this.btnTO.Size = new System.Drawing.Size(226, 59);
            this.btnTO.TabIndex = 0;
            this.btnTO.Text = "Timeout";
            this.btnTO.UseVisualStyleBackColor = false;
            this.btnTO.Click += new System.EventHandler(this.btnTO_Click);
            // 
            // pnlPrtcl
            // 
            this.pnlPrtcl.Controls.Add(this.btnH1);
            this.pnlPrtcl.Controls.Add(this.btnH0);
            this.pnlPrtcl.Controls.Add(this.btnH9);
            this.pnlPrtcl.Controls.Add(this.btnWhois);
            this.pnlPrtcl.Controls.Add(this.btnPrtcl);
            this.pnlPrtcl.Location = new System.Drawing.Point(3, 216);
            this.pnlPrtcl.MaximumSize = new System.Drawing.Size(233, 228);
            this.pnlPrtcl.MinimumSize = new System.Drawing.Size(233, 65);
            this.pnlPrtcl.Name = "pnlPrtcl";
            this.pnlPrtcl.Size = new System.Drawing.Size(233, 65);
            this.pnlPrtcl.TabIndex = 8;
            // 
            // btnH1
            // 
            this.btnH1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnH1.FlatAppearance.BorderSize = 0;
            this.btnH1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnH1.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnH1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnH1.Location = new System.Drawing.Point(16, 185);
            this.btnH1.Name = "btnH1";
            this.btnH1.Size = new System.Drawing.Size(200, 33);
            this.btnH1.TabIndex = 1;
            this.btnH1.Text = "HTTP 1.1";
            this.btnH1.UseVisualStyleBackColor = false;
            this.btnH1.Click += new System.EventHandler(this.btnH1_Click);
            // 
            // btnH0
            // 
            this.btnH0.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnH0.FlatAppearance.BorderSize = 0;
            this.btnH0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnH0.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnH0.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnH0.Location = new System.Drawing.Point(16, 146);
            this.btnH0.Name = "btnH0";
            this.btnH0.Size = new System.Drawing.Size(200, 33);
            this.btnH0.TabIndex = 1;
            this.btnH0.Text = "HTTP 1.0";
            this.btnH0.UseVisualStyleBackColor = false;
            this.btnH0.Click += new System.EventHandler(this.btnH0_Click);
            // 
            // btnH9
            // 
            this.btnH9.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnH9.FlatAppearance.BorderSize = 0;
            this.btnH9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnH9.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnH9.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnH9.Location = new System.Drawing.Point(16, 107);
            this.btnH9.Name = "btnH9";
            this.btnH9.Size = new System.Drawing.Size(200, 33);
            this.btnH9.TabIndex = 1;
            this.btnH9.Text = "HTTP 0.9";
            this.btnH9.UseVisualStyleBackColor = false;
            this.btnH9.Click += new System.EventHandler(this.btnH9_Click);
            // 
            // btnWhois
            // 
            this.btnWhois.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnWhois.FlatAppearance.BorderSize = 0;
            this.btnWhois.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWhois.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWhois.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnWhois.Location = new System.Drawing.Point(16, 68);
            this.btnWhois.Name = "btnWhois";
            this.btnWhois.Size = new System.Drawing.Size(200, 33);
            this.btnWhois.TabIndex = 1;
            this.btnWhois.Text = "whois";
            this.btnWhois.UseVisualStyleBackColor = false;
            this.btnWhois.Click += new System.EventHandler(this.btnWhois_Click);
            // 
            // btnPrtcl
            // 
            this.btnPrtcl.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnPrtcl.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnPrtcl.FlatAppearance.BorderSize = 3;
            this.btnPrtcl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrtcl.Font = new System.Drawing.Font("Verdana", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrtcl.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnPrtcl.Location = new System.Drawing.Point(2, 3);
            this.btnPrtcl.Name = "btnPrtcl";
            this.btnPrtcl.Size = new System.Drawing.Size(226, 59);
            this.btnPrtcl.TabIndex = 0;
            this.btnPrtcl.Text = "Protocol";
            this.btnPrtcl.UseVisualStyleBackColor = false;
            this.btnPrtcl.Click += new System.EventHandler(this.btnPrtcl_Click);
            // 
            // tmrServer
            // 
            this.tmrServer.Interval = 15;
            this.tmrServer.Tick += new System.EventHandler(this.tmrServer_Tick);
            // 
            // tmrPort
            // 
            this.tmrPort.Interval = 15;
            this.tmrPort.Tick += new System.EventHandler(this.tmrPort_Tick);
            // 
            // tmrTimeout
            // 
            this.tmrTimeout.Interval = 15;
            this.tmrTimeout.Tick += new System.EventHandler(this.tmrTimeout_Tick);
            // 
            // tmrPrtcl
            // 
            this.tmrPrtcl.Interval = 7;
            this.tmrPrtcl.Tick += new System.EventHandler(this.tmrPrtcl_Tick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSeaGreen;
            this.panel1.Controls.Add(this.lblPrtcl);
            this.panel1.Controls.Add(this.lblPort);
            this.panel1.Controls.Add(this.lblSrvTag);
            this.panel1.Controls.Add(this.lblServer);
            this.panel1.Controls.Add(this.lblPrtclTag);
            this.panel1.Controls.Add(this.lblPortTag);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 552);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1024, 24);
            this.panel1.TabIndex = 8;
            // 
            // lblPrtcl
            // 
            this.lblPrtcl.AutoSize = true;
            this.lblPrtcl.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrtcl.ForeColor = System.Drawing.Color.Black;
            this.lblPrtcl.Location = new System.Drawing.Point(346, 3);
            this.lblPrtcl.MaximumSize = new System.Drawing.Size(100, 17);
            this.lblPrtcl.Name = "lblPrtcl";
            this.lblPrtcl.Size = new System.Drawing.Size(50, 16);
            this.lblPrtcl.TabIndex = 2;
            this.lblPrtcl.Text = "whois";
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPort.ForeColor = System.Drawing.Color.Black;
            this.lblPort.Location = new System.Drawing.Point(488, 3);
            this.lblPort.MaximumSize = new System.Drawing.Size(220, 17);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(26, 16);
            this.lblPort.TabIndex = 2;
            this.lblPort.Text = "43";
            // 
            // lblSrvTag
            // 
            this.lblSrvTag.AutoSize = true;
            this.lblSrvTag.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSrvTag.ForeColor = System.Drawing.Color.Black;
            this.lblSrvTag.Location = new System.Drawing.Point(2, 3);
            this.lblSrvTag.Name = "lblSrvTag";
            this.lblSrvTag.Size = new System.Drawing.Size(61, 16);
            this.lblSrvTag.TabIndex = 0;
            this.lblSrvTag.Text = "Server:";
            // 
            // lblServer
            // 
            this.lblServer.AutoSize = true;
            this.lblServer.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServer.ForeColor = System.Drawing.Color.Black;
            this.lblServer.Location = new System.Drawing.Point(61, 3);
            this.lblServer.MaximumSize = new System.Drawing.Size(190, 17);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(184, 16);
            this.lblServer.TabIndex = 1;
            this.lblServer.Text = "whois.net.dcs.hull.ac.uk";
            // 
            // lblPrtclTag
            // 
            this.lblPrtclTag.AutoSize = true;
            this.lblPrtclTag.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrtclTag.ForeColor = System.Drawing.Color.Black;
            this.lblPrtclTag.Location = new System.Drawing.Point(272, 3);
            this.lblPrtclTag.Name = "lblPrtclTag";
            this.lblPrtclTag.Size = new System.Drawing.Size(73, 16);
            this.lblPrtclTag.TabIndex = 0;
            this.lblPrtclTag.Text = "Protocol:";
            // 
            // lblPortTag
            // 
            this.lblPortTag.AutoSize = true;
            this.lblPortTag.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPortTag.ForeColor = System.Drawing.Color.Black;
            this.lblPortTag.Location = new System.Drawing.Point(441, 3);
            this.lblPortTag.Name = "lblPortTag";
            this.lblPortTag.Size = new System.Drawing.Size(43, 16);
            this.lblPortTag.TabIndex = 0;
            this.lblPortTag.Text = "Port:";
            // 
            // btnGetUI
            // 
            this.btnGetUI.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnGetUI.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnGetUI.FlatAppearance.BorderSize = 10;
            this.btnGetUI.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetUI.Font = new System.Drawing.Font("Verdana", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetUI.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnGetUI.Location = new System.Drawing.Point(238, 85);
            this.btnGetUI.Name = "btnGetUI";
            this.btnGetUI.Size = new System.Drawing.Size(392, 101);
            this.btnGetUI.TabIndex = 9;
            this.btnGetUI.Text = "GET";
            this.btnGetUI.UseVisualStyleBackColor = false;
            this.btnGetUI.Click += new System.EventHandler(this.btnGetUI_Click);
            this.btnGetUI.MouseEnter += new System.EventHandler(this.btnGetUI_MouseEnter);
            // 
            // pnlGet
            // 
            this.pnlGet.Controls.Add(this.label1);
            this.pnlGet.Controls.Add(this.txtName);
            this.pnlGet.Controls.Add(this.btnGet);
            this.pnlGet.Location = new System.Drawing.Point(245, 196);
            this.pnlGet.Name = "pnlGet";
            this.pnlGet.Size = new System.Drawing.Size(772, 284);
            this.pnlGet.TabIndex = 10;
            // 
            // pnlSet
            // 
            this.pnlSet.Controls.Add(this.label3);
            this.pnlSet.Controls.Add(this.txtNameSet);
            this.pnlSet.Controls.Add(this.btnSet);
            this.pnlSet.Controls.Add(this.txtLocation);
            this.pnlSet.Controls.Add(this.label2);
            this.pnlSet.Location = new System.Drawing.Point(245, 196);
            this.pnlSet.Name = "pnlSet";
            this.pnlSet.Size = new System.Drawing.Size(772, 284);
            this.pnlSet.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Verdana", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(87, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(181, 59);
            this.label3.TabIndex = 7;
            this.label3.Text = "Name";
            // 
            // txtNameSet
            // 
            this.txtNameSet.BackColor = System.Drawing.Color.LightSeaGreen;
            this.txtNameSet.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNameSet.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.txtNameSet.Location = new System.Drawing.Point(181, 84);
            this.txtNameSet.Name = "txtNameSet";
            this.txtNameSet.Size = new System.Drawing.Size(200, 40);
            this.txtNameSet.TabIndex = 6;
            // 
            // btnSetUI
            // 
            this.btnSetUI.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnSetUI.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSetUI.FlatAppearance.BorderSize = 10;
            this.btnSetUI.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetUI.Font = new System.Drawing.Font("Verdana", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetUI.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnSetUI.Location = new System.Drawing.Point(629, 85);
            this.btnSetUI.Name = "btnSetUI";
            this.btnSetUI.Size = new System.Drawing.Size(392, 101);
            this.btnSetUI.TabIndex = 9;
            this.btnSetUI.Text = "SET";
            this.btnSetUI.UseVisualStyleBackColor = false;
            this.btnSetUI.Click += new System.EventHandler(this.btnSetUI_Click);
            this.btnSetUI.MouseEnter += new System.EventHandler(this.btnSetUI_MouseEnter);
            // 
            // pnlCover
            // 
            this.pnlCover.Controls.Add(this.lblResponse);
            this.pnlCover.Location = new System.Drawing.Point(245, 196);
            this.pnlCover.Name = "pnlCover";
            this.pnlCover.Size = new System.Drawing.Size(772, 284);
            this.pnlCover.TabIndex = 8;
            // 
            // btnDebugToggle
            // 
            this.btnDebugToggle.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnDebugToggle.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnDebugToggle.FlatAppearance.BorderSize = 3;
            this.btnDebugToggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDebugToggle.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDebugToggle.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnDebugToggle.Location = new System.Drawing.Point(3, 287);
            this.btnDebugToggle.Name = "btnDebugToggle";
            this.btnDebugToggle.Size = new System.Drawing.Size(226, 59);
            this.btnDebugToggle.TabIndex = 0;
            this.btnDebugToggle.Text = "Debug Toggle";
            this.btnDebugToggle.UseVisualStyleBackColor = false;
            this.btnDebugToggle.Click += new System.EventHandler(this.btnDebugToggle_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1024, 576);
            this.Controls.Add(this.btnSetUI);
            this.Controls.Add(this.btnGetUI);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlCover);
            this.Controls.Add(this.pnlGet);
            this.Controls.Add(this.pnlSet);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(1024, 576);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.pnlServer.ResumeLayout(false);
            this.pnlServer.PerformLayout();
            this.pnlPort.ResumeLayout(false);
            this.pnlPort.PerformLayout();
            this.pnlTimeout.ResumeLayout(false);
            this.pnlTimeout.PerformLayout();
            this.pnlPrtcl.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlGet.ResumeLayout(false);
            this.pnlGet.PerformLayout();
            this.pnlSet.ResumeLayout(false);
            this.pnlSet.PerformLayout();
            this.pnlCover.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Button btnGet;
        private System.Windows.Forms.Button btnSet;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblUI;
        private System.Windows.Forms.Label lblResponse;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel pnlServer;
        private System.Windows.Forms.Button btnServer;
        private System.Windows.Forms.Timer tmrServer;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.Button btnHulluni;
        private System.Windows.Forms.Button btnLocalhost;
        private System.Windows.Forms.Panel pnlPort;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Button btn43;
        private System.Windows.Forms.Button btnPort;
        private System.Windows.Forms.Timer tmrPort;
        private System.Windows.Forms.Panel pnlTimeout;
        private System.Windows.Forms.TextBox txtTimeout;
        private System.Windows.Forms.Button btnTOOff;
        private System.Windows.Forms.Button btnTO;
        private System.Windows.Forms.Timer tmrTimeout;
        private System.Windows.Forms.Button btnTO1000;
        private System.Windows.Forms.Panel pnlPrtcl;
        private System.Windows.Forms.Button btnH9;
        private System.Windows.Forms.Button btnWhois;
        private System.Windows.Forms.Button btnPrtcl;
        private System.Windows.Forms.Button btnH1;
        private System.Windows.Forms.Button btnH0;
        private System.Windows.Forms.Timer tmrPrtcl;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnGetUI;
        private System.Windows.Forms.Panel pnlGet;
        private System.Windows.Forms.Panel pnlSet;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNameSet;
        private System.Windows.Forms.Button btnSetUI;
        private System.Windows.Forms.Panel pnlCover;
        private System.Windows.Forms.Label lblServer;
        private System.Windows.Forms.Label lblSrvTag;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Label lblPortTag;
        private System.Windows.Forms.Label lblPrtcl;
        private System.Windows.Forms.Label lblPrtclTag;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnConWin;
        private System.Windows.Forms.Button btnDebugToggle;
    }
}