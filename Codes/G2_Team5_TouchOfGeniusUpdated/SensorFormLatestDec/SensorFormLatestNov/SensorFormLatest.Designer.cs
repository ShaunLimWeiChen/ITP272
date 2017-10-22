namespace SensorFormLatestNov
{
    partial class SensorForm
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
            System.Windows.Forms.Label label13;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SensorForm));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.lblSessionID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbCmdStr = new System.Windows.Forms.TextBox();
            this.btnSendCmd = new System.Windows.Forms.Button();
            this.rdbOnLED = new System.Windows.Forms.RadioButton();
            this.rdbOffLED = new System.Windows.Forms.RadioButton();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lblLocalTime = new System.Windows.Forms.Label();
            this.TimeNow = new System.Windows.Forms.Timer(this.components);
            this.lblSession = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblLocal = new System.Windows.Forms.Label();
            this.InsertTime = new System.Windows.Forms.Timer(this.components);
            this.btnLoggingOut = new System.Windows.Forms.Button();
            this.timerTemperature = new System.Windows.Forms.Timer(this.components);
            this.timerUltrasonic = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.tabPages2 = new System.Windows.Forms.TabPage();
            this.btnSnapshot = new System.Windows.Forms.Button();
            this.lblSecurityCamera = new System.Windows.Forms.Label();
            this.btnGoback = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnStartCamera = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.tabControlForm = new System.Windows.Forms.TabControl();
            this.tpNetduinoComms = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.RFIDID = new System.Windows.Forms.Label();
            this.btnDel = new System.Windows.Forms.Button();
            this.tbUltrasonicReading = new System.Windows.Forms.TextBox();
            this.tbTemp = new System.Windows.Forms.TextBox();
            this.tbPortStatus = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.cbCommPorts = new System.Windows.Forms.ComboBox();
            this.lbReadings = new System.Windows.Forms.ListBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.tpOtherFunctions = new System.Windows.Forms.TabPage();
            this.groupBoxMotion = new System.Windows.Forms.GroupBox();
            this.btnOutside = new System.Windows.Forms.Button();
            this.btnAthome = new System.Windows.Forms.Button();
            this.btnGoSecurityCamera = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbMotionSensor = new System.Windows.Forms.TextBox();
            this.groupBoxUltrasonic = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.chartUltrasonic = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lbSmoke = new System.Windows.Forms.ListBox();
            this.tbUltraSonic = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbUltraSonicStatus = new System.Windows.Forms.TextBox();
            this.groupBoxTemperature = new System.Windows.Forms.GroupBox();
            this.tbTempK = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.tbTempF = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.tbRoomTemp = new System.Windows.Forms.TextBox();
            this.chartTemp = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tbTempStatus = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tabPageRFID1 = new System.Windows.Forms.TabPage();
            this.Lights = new System.Windows.Forms.GroupBox();
            this.label23 = new System.Windows.Forms.Label();
            this.txtLightDuration = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbFanSpeed = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.cbAircon = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cbUltrasonicSensitivity = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.gpPreset = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblSuggestion = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.lblTmp = new System.Windows.Forms.Label();
            this.lblConfigurations = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.Doorbell = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblnumface = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.lblfacedetected = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnsavedata = new System.Windows.Forms.Button();
            this.label28 = new System.Windows.Forms.Label();
            this.tbname = new System.Windows.Forms.TextBox();
            this.trainingimage = new Emgu.CV.UI.ImageBox();
            this.label29 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.camImage = new Emgu.CV.UI.ImageBox();
            this.btnstart = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            label13 = new System.Windows.Forms.Label();
            this.tabPages2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tabControlForm.SuspendLayout();
            this.tpNetduinoComms.SuspendLayout();
            this.tpOtherFunctions.SuspendLayout();
            this.groupBoxMotion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.groupBoxUltrasonic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartUltrasonic)).BeginInit();
            this.groupBoxTemperature.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTemp)).BeginInit();
            this.tabPageRFID1.SuspendLayout();
            this.Lights.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gpPreset.SuspendLayout();
            this.Doorbell.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trainingimage)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.camImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.ForeColor = System.Drawing.Color.Cornsilk;
            label13.Location = new System.Drawing.Point(40, 112);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(149, 31);
            label13.TabIndex = 1;
            label13.Text = "Port Status";
            // 
            // lblSessionID
            // 
            this.lblSessionID.AutoSize = true;
            this.lblSessionID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSessionID.Location = new System.Drawing.Point(156, -69);
            this.lblSessionID.Name = "lblSessionID";
            this.lblSessionID.Size = new System.Drawing.Size(137, 29);
            this.lblSessionID.TabIndex = 26;
            this.lblSessionID.Text = "[SessionID]";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, -69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 29);
            this.label1.TabIndex = 25;
            this.label1.Text = "Session ID:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(578, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 25);
            this.label6.TabIndex = 31;
            this.label6.Text = "Commands";
            // 
            // tbCmdStr
            // 
            this.tbCmdStr.Location = new System.Drawing.Point(713, 10);
            this.tbCmdStr.Name = "tbCmdStr";
            this.tbCmdStr.Size = new System.Drawing.Size(204, 31);
            this.tbCmdStr.TabIndex = 9;
            // 
            // btnSendCmd
            // 
            this.btnSendCmd.Location = new System.Drawing.Point(923, 5);
            this.btnSendCmd.Name = "btnSendCmd";
            this.btnSendCmd.Size = new System.Drawing.Size(152, 61);
            this.btnSendCmd.TabIndex = 8;
            this.btnSendCmd.Text = "Send Cmd";
            this.btnSendCmd.UseVisualStyleBackColor = true;
            this.btnSendCmd.Click += new System.EventHandler(this.btnSendCmd_Click);
            // 
            // rdbOnLED
            // 
            this.rdbOnLED.AutoSize = true;
            this.rdbOnLED.Location = new System.Drawing.Point(1100, 11);
            this.rdbOnLED.Name = "rdbOnLED";
            this.rdbOnLED.Size = new System.Drawing.Size(164, 29);
            this.rdbOnLED.TabIndex = 24;
            this.rdbOnLED.Text = "Turn on LED";
            this.rdbOnLED.UseVisualStyleBackColor = true;
            // 
            // rdbOffLED
            // 
            this.rdbOffLED.AutoSize = true;
            this.rdbOffLED.Checked = true;
            this.rdbOffLED.Location = new System.Drawing.Point(1270, 11);
            this.rdbOffLED.Name = "rdbOffLED";
            this.rdbOffLED.Size = new System.Drawing.Size(164, 29);
            this.rdbOffLED.TabIndex = 23;
            this.rdbOffLED.TabStop = true;
            this.rdbOffLED.Text = "Turn off LED";
            this.rdbOffLED.UseVisualStyleBackColor = true;
            // 
            // btnLogout
            // 
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.Location = new System.Drawing.Point(1355, -66);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(168, 55);
            this.btnLogout.TabIndex = 24;
            this.btnLogout.Text = "Log out";
            this.btnLogout.UseVisualStyleBackColor = true;
            // 
            // lblLocalTime
            // 
            this.lblLocalTime.AutoSize = true;
            this.lblLocalTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocalTime.Location = new System.Drawing.Point(456, -69);
            this.lblLocalTime.Name = "lblLocalTime";
            this.lblLocalTime.Size = new System.Drawing.Size(26, 29);
            this.lblLocalTime.TabIndex = 27;
            this.lblLocalTime.Text = "0";
            // 
            // TimeNow
            // 
            this.TimeNow.Enabled = true;
            this.TimeNow.Tick += new System.EventHandler(this.TimeNow_Tick);
            // 
            // lblSession
            // 
            this.lblSession.AutoSize = true;
            this.lblSession.BackColor = System.Drawing.Color.White;
            this.lblSession.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSession.Location = new System.Drawing.Point(162, 11);
            this.lblSession.Name = "lblSession";
            this.lblSession.Size = new System.Drawing.Size(137, 29);
            this.lblSession.TabIndex = 30;
            this.lblSession.Text = "[SessionID]";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(21, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 29);
            this.label5.TabIndex = 29;
            this.label5.Text = "Session ID:";
            // 
            // lblLocal
            // 
            this.lblLocal.AutoSize = true;
            this.lblLocal.BackColor = System.Drawing.Color.White;
            this.lblLocal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblLocal.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblLocal.Location = new System.Drawing.Point(384, 9);
            this.lblLocal.Name = "lblLocal";
            this.lblLocal.Size = new System.Drawing.Size(35, 37);
            this.lblLocal.TabIndex = 31;
            this.lblLocal.Text = "0";
            // 
            // btnLoggingOut
            // 
            this.btnLoggingOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoggingOut.Location = new System.Drawing.Point(2288, 6);
            this.btnLoggingOut.Name = "btnLoggingOut";
            this.btnLoggingOut.Size = new System.Drawing.Size(153, 53);
            this.btnLoggingOut.TabIndex = 32;
            this.btnLoggingOut.Text = "Logout";
            this.btnLoggingOut.UseVisualStyleBackColor = true;
            this.btnLoggingOut.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // timerTemperature
            // 
            this.timerTemperature.Enabled = true;
            this.timerTemperature.Tick += new System.EventHandler(this.timerTemperature_Tick);
            // 
            // timerUltrasonic
            // 
            this.timerUltrasonic.Enabled = true;
            this.timerUltrasonic.Tick += new System.EventHandler(this.timerUltrasonic_Tick);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // tabPages2
            // 
            this.tabPages2.Controls.Add(this.btnSnapshot);
            this.tabPages2.Controls.Add(this.lblSecurityCamera);
            this.tabPages2.Controls.Add(this.btnGoback);
            this.tabPages2.Controls.Add(this.lblStatus);
            this.tabPages2.Controls.Add(this.btnStartCamera);
            this.tabPages2.Controls.Add(this.btnStop);
            this.tabPages2.Controls.Add(this.pictureBox2);
            this.tabPages2.Location = new System.Drawing.Point(8, 45);
            this.tabPages2.Name = "tabPages2";
            this.tabPages2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPages2.Size = new System.Drawing.Size(2413, 1433);
            this.tabPages2.TabIndex = 3;
            this.tabPages2.Text = "Security Camera Footage";
            this.tabPages2.UseVisualStyleBackColor = true;
            // 
            // btnSnapshot
            // 
            this.btnSnapshot.Location = new System.Drawing.Point(945, 1051);
            this.btnSnapshot.Name = "btnSnapshot";
            this.btnSnapshot.Size = new System.Drawing.Size(289, 71);
            this.btnSnapshot.TabIndex = 35;
            this.btnSnapshot.Text = "Snapshot";
            this.btnSnapshot.UseVisualStyleBackColor = true;
            this.btnSnapshot.Click += new System.EventHandler(this.btnSnapshot_Click);
            // 
            // lblSecurityCamera
            // 
            this.lblSecurityCamera.AutoSize = true;
            this.lblSecurityCamera.BackColor = System.Drawing.Color.Black;
            this.lblSecurityCamera.Font = new System.Drawing.Font("Lucida Sans", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSecurityCamera.ForeColor = System.Drawing.Color.Red;
            this.lblSecurityCamera.Location = new System.Drawing.Point(7, 955);
            this.lblSecurityCamera.Name = "lblSecurityCamera";
            this.lblSecurityCamera.Size = new System.Drawing.Size(54, 55);
            this.lblSecurityCamera.TabIndex = 34;
            this.lblSecurityCamera.Text = "0";
            this.lblSecurityCamera.Visible = false;
            // 
            // btnGoback
            // 
            this.btnGoback.Location = new System.Drawing.Point(1867, 869);
            this.btnGoback.Name = "btnGoback";
            this.btnGoback.Size = new System.Drawing.Size(206, 152);
            this.btnGoback.TabIndex = 29;
            this.btnGoback.Text = "Go back";
            this.btnGoback.UseVisualStyleBackColor = true;
            this.btnGoback.Click += new System.EventHandler(this.btnGoback_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(11, 1071);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(119, 31);
            this.lblStatus.TabIndex = 28;
            this.lblStatus.Text = "lblStatus";
            this.lblStatus.Visible = false;
            // 
            // btnStartCamera
            // 
            this.btnStartCamera.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartCamera.ForeColor = System.Drawing.Color.ForestGreen;
            this.btnStartCamera.Location = new System.Drawing.Point(1797, 1051);
            this.btnStartCamera.Name = "btnStartCamera";
            this.btnStartCamera.Size = new System.Drawing.Size(210, 71);
            this.btnStartCamera.TabIndex = 27;
            this.btnStartCamera.Text = "Play ⏯";
            this.btnStartCamera.UseVisualStyleBackColor = true;
            this.btnStartCamera.Visible = false;
            this.btnStartCamera.Click += new System.EventHandler(this.btnStartCamera_Click);
            // 
            // btnStop
            // 
            this.btnStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.ForeColor = System.Drawing.Color.Red;
            this.btnStop.Location = new System.Drawing.Point(1767, 1051);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(240, 71);
            this.btnStop.TabIndex = 26;
            this.btnStop.Text = "Stop camera ⏯";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Visible = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Black;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(2073, 1021);
            this.pictureBox2.TabIndex = 25;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // tabControlForm
            // 
            this.tabControlForm.Controls.Add(this.tpNetduinoComms);
            this.tabControlForm.Controls.Add(this.tpOtherFunctions);
            this.tabControlForm.Controls.Add(this.tabPages2);
            this.tabControlForm.Controls.Add(this.tabPageRFID1);
            this.tabControlForm.Controls.Add(this.Doorbell);
            this.tabControlForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlForm.Location = new System.Drawing.Point(12, 72);
            this.tabControlForm.Name = "tabControlForm";
            this.tabControlForm.SelectedIndex = 0;
            this.tabControlForm.Size = new System.Drawing.Size(2429, 1486);
            this.tabControlForm.TabIndex = 28;
            // 
            // tpNetduinoComms
            // 
            this.tpNetduinoComms.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tpNetduinoComms.BackgroundImage")));
            this.tpNetduinoComms.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tpNetduinoComms.Controls.Add(this.label9);
            this.tpNetduinoComms.Controls.Add(this.RFIDID);
            this.tpNetduinoComms.Controls.Add(this.btnDel);
            this.tpNetduinoComms.Controls.Add(this.tbUltrasonicReading);
            this.tpNetduinoComms.Controls.Add(this.tbTemp);
            this.tpNetduinoComms.Controls.Add(this.tbPortStatus);
            this.tpNetduinoComms.Controls.Add(this.label7);
            this.tpNetduinoComms.Controls.Add(this.label4);
            this.tpNetduinoComms.Controls.Add(this.btnDisconnect);
            this.tpNetduinoComms.Controls.Add(this.btnConnect);
            this.tpNetduinoComms.Controls.Add(this.cbCommPorts);
            this.tpNetduinoComms.Controls.Add(this.lbReadings);
            this.tpNetduinoComms.Controls.Add(this.label11);
            this.tpNetduinoComms.Controls.Add(label13);
            this.tpNetduinoComms.Controls.Add(this.label14);
            this.tpNetduinoComms.Location = new System.Drawing.Point(8, 45);
            this.tpNetduinoComms.Name = "tpNetduinoComms";
            this.tpNetduinoComms.Padding = new System.Windows.Forms.Padding(3);
            this.tpNetduinoComms.Size = new System.Drawing.Size(2413, 1433);
            this.tpNetduinoComms.TabIndex = 0;
            this.tpNetduinoComms.Text = "Comms";
            this.tpNetduinoComms.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Cornsilk;
            this.label9.Location = new System.Drawing.Point(804, 242);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 31);
            this.label9.TabIndex = 18;
            this.label9.Text = "RFID";
            // 
            // RFIDID
            // 
            this.RFIDID.AutoSize = true;
            this.RFIDID.BackColor = System.Drawing.Color.Transparent;
            this.RFIDID.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RFIDID.ForeColor = System.Drawing.Color.White;
            this.RFIDID.Location = new System.Drawing.Point(928, 236);
            this.RFIDID.Name = "RFIDID";
            this.RFIDID.Size = new System.Drawing.Size(39, 42);
            this.RFIDID.TabIndex = 17;
            this.RFIDID.Text = "0";
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(2120, 279);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(241, 71);
            this.btnDel.TabIndex = 16;
            this.btnDel.Text = "Clear";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // tbUltrasonicReading
            // 
            this.tbUltrasonicReading.Location = new System.Drawing.Point(336, 172);
            this.tbUltrasonicReading.Name = "tbUltrasonicReading";
            this.tbUltrasonicReading.ReadOnly = true;
            this.tbUltrasonicReading.Size = new System.Drawing.Size(402, 38);
            this.tbUltrasonicReading.TabIndex = 14;
            this.tbUltrasonicReading.Text = "Not Active";
            // 
            // tbTemp
            // 
            this.tbTemp.Location = new System.Drawing.Point(336, 235);
            this.tbTemp.Name = "tbTemp";
            this.tbTemp.ReadOnly = true;
            this.tbTemp.Size = new System.Drawing.Size(402, 38);
            this.tbTemp.TabIndex = 8;
            this.tbTemp.Text = "Not Active";
            // 
            // tbPortStatus
            // 
            this.tbPortStatus.Location = new System.Drawing.Point(336, 109);
            this.tbPortStatus.Name = "tbPortStatus";
            this.tbPortStatus.ReadOnly = true;
            this.tbPortStatus.Size = new System.Drawing.Size(402, 38);
            this.tbPortStatus.TabIndex = 6;
            this.tbPortStatus.Text = "CLOSED";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Cornsilk;
            this.label7.Location = new System.Drawing.Point(40, 175);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(229, 31);
            this.label7.TabIndex = 13;
            this.label7.Text = "Ultrasonic Sensor";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Cornsilk;
            this.label4.Location = new System.Drawing.Point(41, 301);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(422, 51);
            this.label4.TabIndex = 11;
            this.label4.Text = "Readings and Status";
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(1042, 48);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(229, 58);
            this.btnDisconnect.TabIndex = 10;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(838, 48);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(181, 58);
            this.btnConnect.TabIndex = 9;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // cbCommPorts
            // 
            this.cbCommPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCommPorts.FormattingEnabled = true;
            this.cbCommPorts.Location = new System.Drawing.Point(336, 48);
            this.cbCommPorts.Name = "cbCommPorts";
            this.cbCommPorts.Size = new System.Drawing.Size(402, 39);
            this.cbCommPorts.TabIndex = 5;
            // 
            // lbReadings
            // 
            this.lbReadings.BackColor = System.Drawing.Color.White;
            this.lbReadings.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lbReadings.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbReadings.FormattingEnabled = true;
            this.lbReadings.HorizontalScrollbar = true;
            this.lbReadings.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbReadings.IntegralHeight = false;
            this.lbReadings.ItemHeight = 31;
            this.lbReadings.Location = new System.Drawing.Point(50, 355);
            this.lbReadings.Margin = new System.Windows.Forms.Padding(2);
            this.lbReadings.Name = "lbReadings";
            this.lbReadings.ScrollAlwaysVisible = true;
            this.lbReadings.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbReadings.Size = new System.Drawing.Size(2311, 810);
            this.lbReadings.TabIndex = 4;
            this.lbReadings.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lbReadings_DrawItem);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Cornsilk;
            this.label11.Location = new System.Drawing.Point(40, 238);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(169, 31);
            this.label11.TabIndex = 3;
            this.label11.Text = "Temperature";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.Cornsilk;
            this.label14.Location = new System.Drawing.Point(40, 51);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(281, 31);
            this.label14.TabIndex = 0;
            this.label14.Text = "Available Comm Ports";
            // 
            // tpOtherFunctions
            // 
            this.tpOtherFunctions.AutoScroll = true;
            this.tpOtherFunctions.Controls.Add(this.groupBoxMotion);
            this.tpOtherFunctions.Controls.Add(this.groupBoxUltrasonic);
            this.tpOtherFunctions.Controls.Add(this.groupBoxTemperature);
            this.tpOtherFunctions.Location = new System.Drawing.Point(8, 45);
            this.tpOtherFunctions.Name = "tpOtherFunctions";
            this.tpOtherFunctions.Padding = new System.Windows.Forms.Padding(3);
            this.tpOtherFunctions.Size = new System.Drawing.Size(2413, 1433);
            this.tpOtherFunctions.TabIndex = 1;
            this.tpOtherFunctions.Text = "Functions";
            this.tpOtherFunctions.UseVisualStyleBackColor = true;
            // 
            // groupBoxMotion
            // 
            this.groupBoxMotion.Controls.Add(this.btnOutside);
            this.groupBoxMotion.Controls.Add(this.btnAthome);
            this.groupBoxMotion.Controls.Add(this.btnGoSecurityCamera);
            this.groupBoxMotion.Controls.Add(this.pictureBox);
            this.groupBoxMotion.Controls.Add(this.label2);
            this.groupBoxMotion.Controls.Add(this.tbMotionSensor);
            this.groupBoxMotion.Location = new System.Drawing.Point(1096, 678);
            this.groupBoxMotion.Name = "groupBoxMotion";
            this.groupBoxMotion.Size = new System.Drawing.Size(1303, 504);
            this.groupBoxMotion.TabIndex = 38;
            this.groupBoxMotion.TabStop = false;
            this.groupBoxMotion.Text = "4";
            // 
            // btnOutside
            // 
            this.btnOutside.Location = new System.Drawing.Point(321, 368);
            this.btnOutside.Name = "btnOutside";
            this.btnOutside.Size = new System.Drawing.Size(136, 70);
            this.btnOutside.TabIndex = 27;
            this.btnOutside.Text = "Outside";
            this.btnOutside.UseVisualStyleBackColor = true;
            this.btnOutside.Click += new System.EventHandler(this.btnOutside_Click);
            // 
            // btnAthome
            // 
            this.btnAthome.Location = new System.Drawing.Point(86, 368);
            this.btnAthome.Name = "btnAthome";
            this.btnAthome.Size = new System.Drawing.Size(143, 70);
            this.btnAthome.TabIndex = 26;
            this.btnAthome.Text = "At home";
            this.btnAthome.UseVisualStyleBackColor = true;
            this.btnAthome.Click += new System.EventHandler(this.btnAthome_Click);
            // 
            // btnGoSecurityCamera
            // 
            this.btnGoSecurityCamera.Location = new System.Drawing.Point(1125, 397);
            this.btnGoSecurityCamera.Name = "btnGoSecurityCamera";
            this.btnGoSecurityCamera.Size = new System.Drawing.Size(145, 90);
            this.btnGoSecurityCamera.TabIndex = 25;
            this.btnGoSecurityCamera.Text = "Security camera";
            this.btnGoSecurityCamera.UseVisualStyleBackColor = true;
            this.btnGoSecurityCamera.Click += new System.EventHandler(this.btnGoSecurityCamera_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.Black;
            this.pictureBox.Location = new System.Drawing.Point(542, 37);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(728, 450);
            this.pictureBox.TabIndex = 24;
            this.pictureBox.TabStop = false;
            this.pictureBox.Click += new System.EventHandler(this.pictureBox_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(80, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(188, 73);
            this.label2.TabIndex = 23;
            this.label2.Text = "Motion Sensor Status";
            // 
            // tbMotionSensor
            // 
            this.tbMotionSensor.Location = new System.Drawing.Point(86, 183);
            this.tbMotionSensor.Multiline = true;
            this.tbMotionSensor.Name = "tbMotionSensor";
            this.tbMotionSensor.ReadOnly = true;
            this.tbMotionSensor.Size = new System.Drawing.Size(371, 148);
            this.tbMotionSensor.TabIndex = 22;
            // 
            // groupBoxUltrasonic
            // 
            this.groupBoxUltrasonic.Controls.Add(this.label8);
            this.groupBoxUltrasonic.Controls.Add(this.chartUltrasonic);
            this.groupBoxUltrasonic.Controls.Add(this.lbSmoke);
            this.groupBoxUltrasonic.Controls.Add(this.tbUltraSonic);
            this.groupBoxUltrasonic.Controls.Add(this.label3);
            this.groupBoxUltrasonic.Controls.Add(this.tbUltraSonicStatus);
            this.groupBoxUltrasonic.Location = new System.Drawing.Point(1096, 2);
            this.groupBoxUltrasonic.Name = "groupBoxUltrasonic";
            this.groupBoxUltrasonic.Size = new System.Drawing.Size(1303, 693);
            this.groupBoxUltrasonic.TabIndex = 37;
            this.groupBoxUltrasonic.TabStop = false;
            this.groupBoxUltrasonic.Text = "2";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 34);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(232, 31);
            this.label8.TabIndex = 13;
            this.label8.Text = "Ultrasonic sensor ";
            // 
            // chartUltrasonic
            // 
            this.chartUltrasonic.BackColor = System.Drawing.Color.Transparent;
            this.chartUltrasonic.BackImageTransparentColor = System.Drawing.Color.Transparent;
            chartArea1.Area3DStyle.Inclination = 50;
            chartArea1.Area3DStyle.IsClustered = true;
            chartArea1.Area3DStyle.LightStyle = System.Windows.Forms.DataVisualization.Charting.LightStyle.Realistic;
            chartArea1.Area3DStyle.WallWidth = 0;
            chartArea1.Name = "Distance";
            this.chartUltrasonic.ChartAreas.Add(chartArea1);
            legend1.Name = "\"\"";
            this.chartUltrasonic.Legends.Add(legend1);
            this.chartUltrasonic.Location = new System.Drawing.Point(26, 88);
            this.chartUltrasonic.Name = "chartUltrasonic";
            this.chartUltrasonic.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.EarthTones;
            series1.ChartArea = "Distance";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedArea;
            series1.Legend = "\"\"";
            series1.Name = "Distance";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series1.YValuesPerPoint = 4;
            this.chartUltrasonic.Series.Add(series1);
            this.chartUltrasonic.Size = new System.Drawing.Size(689, 441);
            this.chartUltrasonic.TabIndex = 29;
            this.chartUltrasonic.Text = "chartUltrasonic";
            this.chartUltrasonic.MouseEnter += new System.EventHandler(this.chartUltrasonic_MouseEnter);
            this.chartUltrasonic.MouseLeave += new System.EventHandler(this.chartUltrasonic_MouseLeave);
            this.chartUltrasonic.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chartUltrasonic_MouseMove_1);
            // 
            // lbSmoke
            // 
            this.lbSmoke.FormattingEnabled = true;
            this.lbSmoke.ItemHeight = 31;
            this.lbSmoke.Items.AddRange(new object[] {
            "Show temperature database",
            "Show ultrasonic database",
            "Show motion database",
            "Save temperature chart",
            "Save ultrasonic chart"});
            this.lbSmoke.Location = new System.Drawing.Point(736, 52);
            this.lbSmoke.Name = "lbSmoke";
            this.lbSmoke.Size = new System.Drawing.Size(534, 593);
            this.lbSmoke.TabIndex = 40;
            this.lbSmoke.SelectedIndexChanged += new System.EventHandler(this.lbSmoke_SelectedIndexChanged);
            // 
            // tbUltraSonic
            // 
            this.tbUltraSonic.Location = new System.Drawing.Point(272, 31);
            this.tbUltraSonic.Name = "tbUltraSonic";
            this.tbUltraSonic.ReadOnly = true;
            this.tbUltraSonic.Size = new System.Drawing.Size(175, 38);
            this.tbUltraSonic.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 567);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 31);
            this.label3.TabIndex = 26;
            this.label3.Text = "Status";
            // 
            // tbUltraSonicStatus
            // 
            this.tbUltraSonicStatus.Location = new System.Drawing.Point(129, 537);
            this.tbUltraSonicStatus.Multiline = true;
            this.tbUltraSonicStatus.Name = "tbUltraSonicStatus";
            this.tbUltraSonicStatus.ReadOnly = true;
            this.tbUltraSonicStatus.Size = new System.Drawing.Size(554, 82);
            this.tbUltraSonicStatus.TabIndex = 27;
            // 
            // groupBoxTemperature
            // 
            this.groupBoxTemperature.Controls.Add(this.tbTempK);
            this.groupBoxTemperature.Controls.Add(this.label20);
            this.groupBoxTemperature.Controls.Add(this.label19);
            this.groupBoxTemperature.Controls.Add(this.tbTempF);
            this.groupBoxTemperature.Controls.Add(this.label16);
            this.groupBoxTemperature.Controls.Add(this.tbRoomTemp);
            this.groupBoxTemperature.Controls.Add(this.chartTemp);
            this.groupBoxTemperature.Controls.Add(this.tbTempStatus);
            this.groupBoxTemperature.Controls.Add(this.label15);
            this.groupBoxTemperature.Location = new System.Drawing.Point(16, 2);
            this.groupBoxTemperature.Name = "groupBoxTemperature";
            this.groupBoxTemperature.Size = new System.Drawing.Size(1080, 1180);
            this.groupBoxTemperature.TabIndex = 36;
            this.groupBoxTemperature.TabStop = false;
            this.groupBoxTemperature.Text = "1";
            // 
            // tbTempK
            // 
            this.tbTempK.Location = new System.Drawing.Point(869, 29);
            this.tbTempK.Name = "tbTempK";
            this.tbTempK.ReadOnly = true;
            this.tbTempK.Size = new System.Drawing.Size(115, 38);
            this.tbTempK.TabIndex = 32;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(713, 34);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(136, 31);
            this.label20.TabIndex = 31;
            this.label20.Text = "Temp in K";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(427, 34);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(135, 31);
            this.label19.TabIndex = 30;
            this.label19.Text = "Temp in F";
            // 
            // tbTempF
            // 
            this.tbTempF.Location = new System.Drawing.Point(581, 29);
            this.tbTempF.Name = "tbTempF";
            this.tbTempF.ReadOnly = true;
            this.tbTempF.Size = new System.Drawing.Size(115, 38);
            this.tbTempF.TabIndex = 29;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(19, 34);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(255, 31);
            this.label16.TabIndex = 1;
            this.label16.Text = "Room Temperature ";
            // 
            // tbRoomTemp
            // 
            this.tbRoomTemp.Location = new System.Drawing.Point(292, 29);
            this.tbRoomTemp.Name = "tbRoomTemp";
            this.tbRoomTemp.ReadOnly = true;
            this.tbRoomTemp.Size = new System.Drawing.Size(111, 38);
            this.tbRoomTemp.TabIndex = 4;
            // 
            // chartTemp
            // 
            this.chartTemp.AllowDrop = true;
            this.chartTemp.BackColor = System.Drawing.Color.Transparent;
            this.chartTemp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chartTemp.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.BottomRight;
            this.chartTemp.BackImageTransparentColor = System.Drawing.Color.Transparent;
            this.chartTemp.BorderSkin.BackColor = System.Drawing.Color.Transparent;
            this.chartTemp.BorderSkin.BackSecondaryColor = System.Drawing.Color.White;
            this.chartTemp.BorderSkin.BorderColor = System.Drawing.Color.Transparent;
            chartArea2.Area3DStyle.Inclination = 50;
            chartArea2.Area3DStyle.LightStyle = System.Windows.Forms.DataVisualization.Charting.LightStyle.Realistic;
            chartArea2.Area3DStyle.Rotation = 10;
            chartArea2.Area3DStyle.WallWidth = 0;
            chartArea2.CursorX.IsUserEnabled = true;
            chartArea2.CursorX.IsUserSelectionEnabled = true;
            chartArea2.Name = "Temperature";
            this.chartTemp.ChartAreas.Add(chartArea2);
            legend2.Name = "\"\"";
            this.chartTemp.Legends.Add(legend2);
            this.chartTemp.Location = new System.Drawing.Point(6, 109);
            this.chartTemp.Name = "chartTemp";
            this.chartTemp.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SemiTransparent;
            series2.ChartArea = "Temperature";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedArea;
            series2.Legend = "\"\"";
            series2.Name = "Temperature";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series2.YValuesPerPoint = 4;
            this.chartTemp.Series.Add(series2);
            this.chartTemp.Size = new System.Drawing.Size(1058, 931);
            this.chartTemp.TabIndex = 28;
            this.chartTemp.Text = "chartTemp";
            this.chartTemp.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chartTemp_MouseClick);
            this.chartTemp.MouseEnter += new System.EventHandler(this.chartTemp_MouseEnter);
            this.chartTemp.MouseLeave += new System.EventHandler(this.chartTemp_MouseLeave);
            this.chartTemp.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chartTemp_MouseMove);
            // 
            // tbTempStatus
            // 
            this.tbTempStatus.Location = new System.Drawing.Point(233, 1061);
            this.tbTempStatus.Multiline = true;
            this.tbTempStatus.Name = "tbTempStatus";
            this.tbTempStatus.ReadOnly = true;
            this.tbTempStatus.Size = new System.Drawing.Size(463, 82);
            this.tbTempStatus.TabIndex = 5;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(95, 1091);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(92, 31);
            this.label15.TabIndex = 2;
            this.label15.Text = "Status";
            // 
            // tabPageRFID1
            // 
            this.tabPageRFID1.Controls.Add(this.Lights);
            this.tabPageRFID1.Controls.Add(this.groupBox1);
            this.tabPageRFID1.Controls.Add(this.label12);
            this.tabPageRFID1.Controls.Add(this.cbUltrasonicSensitivity);
            this.tabPageRFID1.Controls.Add(this.label10);
            this.tabPageRFID1.Controls.Add(this.gpPreset);
            this.tabPageRFID1.Location = new System.Drawing.Point(8, 45);
            this.tabPageRFID1.Name = "tabPageRFID1";
            this.tabPageRFID1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRFID1.Size = new System.Drawing.Size(2413, 1433);
            this.tabPageRFID1.TabIndex = 4;
            this.tabPageRFID1.Text = "RFID";
            this.tabPageRFID1.UseVisualStyleBackColor = true;
            // 
            // Lights
            // 
            this.Lights.Controls.Add(this.label23);
            this.Lights.Controls.Add(this.txtLightDuration);
            this.Lights.Controls.Add(this.label22);
            this.Lights.Location = new System.Drawing.Point(91, 684);
            this.Lights.Name = "Lights";
            this.Lights.Size = new System.Drawing.Size(803, 159);
            this.Lights.TabIndex = 5;
            this.Lights.TabStop = false;
            this.Lights.Text = "Lights";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(522, 96);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(71, 31);
            this.label23.TabIndex = 2;
            this.label23.Text = "mins";
            // 
            // txtLightDuration
            // 
            this.txtLightDuration.Location = new System.Drawing.Point(319, 93);
            this.txtLightDuration.Name = "txtLightDuration";
            this.txtLightDuration.Size = new System.Drawing.Size(173, 38);
            this.txtLightDuration.TabIndex = 1;
            this.txtLightDuration.Text = "60";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(27, 96);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(186, 31);
            this.label22.TabIndex = 0;
            this.label22.Text = "Light duration:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbFanSpeed);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.cbAircon);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Location = new System.Drawing.Point(91, 396);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(803, 237);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Temperature";
            // 
            // cbFanSpeed
            // 
            this.cbFanSpeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFanSpeed.FormattingEnabled = true;
            this.cbFanSpeed.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.cbFanSpeed.Location = new System.Drawing.Point(319, 147);
            this.cbFanSpeed.Name = "cbFanSpeed";
            this.cbFanSpeed.Size = new System.Drawing.Size(173, 39);
            this.cbFanSpeed.TabIndex = 4;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(522, 80);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(45, 31);
            this.label21.TabIndex = 3;
            this.label21.Text = "°C";
            // 
            // cbAircon
            // 
            this.cbAircon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAircon.FormattingEnabled = true;
            this.cbAircon.Items.AddRange(new object[] {
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30"});
            this.cbAircon.Location = new System.Drawing.Point(319, 77);
            this.cbAircon.Name = "cbAircon";
            this.cbAircon.Size = new System.Drawing.Size(173, 39);
            this.cbAircon.TabIndex = 2;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(21, 150);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(150, 31);
            this.label18.TabIndex = 1;
            this.label18.Text = "Fan speed:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(21, 80);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(270, 31);
            this.label17.TabIndex = 0;
            this.label17.Text = "Set air conditioner at:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(684, 349);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(50, 31);
            this.label12.TabIndex = 2;
            this.label12.Text = "cm";
            // 
            // cbUltrasonicSensitivity
            // 
            this.cbUltrasonicSensitivity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUltrasonicSensitivity.FormattingEnabled = true;
            this.cbUltrasonicSensitivity.Items.AddRange(new object[] {
            "10",
            "20",
            "30",
            "40",
            "50",
            "60",
            "70",
            "80",
            "90",
            "100"});
            this.cbUltrasonicSensitivity.Location = new System.Drawing.Point(474, 346);
            this.cbUltrasonicSensitivity.Name = "cbUltrasonicSensitivity";
            this.cbUltrasonicSensitivity.Size = new System.Drawing.Size(172, 39);
            this.cbUltrasonicSensitivity.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(85, 349);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(368, 31);
            this.label10.TabIndex = 0;
            this.label10.Text = "Ultrasonic Sensor Sensitivity:";
            // 
            // gpPreset
            // 
            this.gpPreset.Controls.Add(this.btnSave);
            this.gpPreset.Controls.Add(this.lblSuggestion);
            this.gpPreset.Controls.Add(this.label25);
            this.gpPreset.Controls.Add(this.lblTmp);
            this.gpPreset.Controls.Add(this.lblConfigurations);
            this.gpPreset.Controls.Add(this.label24);
            this.gpPreset.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpPreset.Location = new System.Drawing.Point(42, 21);
            this.gpPreset.Name = "gpPreset";
            this.gpPreset.Size = new System.Drawing.Size(1382, 1128);
            this.gpPreset.TabIndex = 7;
            this.gpPreset.TabStop = false;
            this.gpPreset.Text = "Your Presets";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(920, 756);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(177, 66);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblSuggestion
            // 
            this.lblSuggestion.AutoSize = true;
            this.lblSuggestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSuggestion.Location = new System.Drawing.Point(264, 147);
            this.lblSuggestion.Name = "lblSuggestion";
            this.lblSuggestion.Size = new System.Drawing.Size(30, 42);
            this.lblSuggestion.TabIndex = 11;
            this.lblSuggestion.Text = "-";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(42, 147);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(216, 42);
            this.label25.TabIndex = 10;
            this.label25.Text = "Suggestion:";
            // 
            // lblTmp
            // 
            this.lblTmp.AutoSize = true;
            this.lblTmp.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTmp.ForeColor = System.Drawing.Color.Red;
            this.lblTmp.Location = new System.Drawing.Point(442, 71);
            this.lblTmp.Name = "lblTmp";
            this.lblTmp.Size = new System.Drawing.Size(46, 51);
            this.lblTmp.TabIndex = 9;
            this.lblTmp.Text = "0";
            // 
            // lblConfigurations
            // 
            this.lblConfigurations.AutoSize = true;
            this.lblConfigurations.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfigurations.Location = new System.Drawing.Point(39, 228);
            this.lblConfigurations.Name = "lblConfigurations";
            this.lblConfigurations.Size = new System.Drawing.Size(334, 55);
            this.lblConfigurations.TabIndex = 6;
            this.lblConfigurations.Text = "Configurations";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(42, 77);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(375, 42);
            this.label24.TabIndex = 8;
            this.label24.Text = "Current Temperature:";
            // 
            // Doorbell
            // 
            this.Doorbell.Controls.Add(this.groupBox3);
            this.Doorbell.Controls.Add(this.groupBox2);
            this.Doorbell.Controls.Add(this.label29);
            this.Doorbell.Controls.Add(this.groupBox4);
            this.Doorbell.Location = new System.Drawing.Point(8, 45);
            this.Doorbell.Name = "Doorbell";
            this.Doorbell.Padding = new System.Windows.Forms.Padding(3);
            this.Doorbell.Size = new System.Drawing.Size(2413, 1433);
            this.Doorbell.TabIndex = 5;
            this.Doorbell.Text = "Doorbell";
            this.Doorbell.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblnumface);
            this.groupBox3.Controls.Add(this.label26);
            this.groupBox3.Controls.Add(this.lblfacedetected);
            this.groupBox3.Controls.Add(this.label27);
            this.groupBox3.Location = new System.Drawing.Point(1087, 105);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox3.Size = new System.Drawing.Size(656, 337);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Data Output";
            // 
            // lblnumface
            // 
            this.lblnumface.AutoSize = true;
            this.lblnumface.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnumface.ForeColor = System.Drawing.Color.Red;
            this.lblnumface.Location = new System.Drawing.Point(346, 164);
            this.lblnumface.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblnumface.Name = "lblnumface";
            this.lblnumface.Size = new System.Drawing.Size(37, 38);
            this.lblnumface.TabIndex = 3;
            this.lblnumface.Text = "0";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(34, 169);
            this.label26.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(300, 31);
            this.label26.TabIndex = 2;
            this.label26.Text = "No. Of Faces Detected:";
            // 
            // lblfacedetected
            // 
            this.lblfacedetected.AutoSize = true;
            this.lblfacedetected.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblfacedetected.ForeColor = System.Drawing.Color.Red;
            this.lblfacedetected.Location = new System.Drawing.Point(301, 82);
            this.lblfacedetected.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblfacedetected.Name = "lblfacedetected";
            this.lblfacedetected.Size = new System.Drawing.Size(329, 38);
            this.lblfacedetected.TabIndex = 1;
            this.lblfacedetected.Text = "No Faces Detected.";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(34, 87);
            this.label27.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(214, 31);
            this.label27.TabIndex = 0;
            this.label27.Text = "Faces Detected:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnsavedata);
            this.groupBox2.Controls.Add(this.label28);
            this.groupBox2.Controls.Add(this.tbname);
            this.groupBox2.Controls.Add(this.trainingimage);
            this.groupBox2.Location = new System.Drawing.Point(47, 582);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox2.Size = new System.Drawing.Size(964, 365);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Training Set";
            // 
            // btnsavedata
            // 
            this.btnsavedata.Location = new System.Drawing.Point(646, 260);
            this.btnsavedata.Margin = new System.Windows.Forms.Padding(6);
            this.btnsavedata.Name = "btnsavedata";
            this.btnsavedata.Size = new System.Drawing.Size(268, 56);
            this.btnsavedata.TabIndex = 6;
            this.btnsavedata.Text = "Save Record";
            this.btnsavedata.UseVisualStyleBackColor = true;
            this.btnsavedata.Click += new System.EventHandler(this.btnsavedata_Click);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(324, 144);
            this.label28.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(94, 31);
            this.label28.TabIndex = 5;
            this.label28.Text = "Name:";
            // 
            // tbname
            // 
            this.tbname.Location = new System.Drawing.Point(436, 138);
            this.tbname.Margin = new System.Windows.Forms.Padding(6);
            this.tbname.Name = "tbname";
            this.tbname.Size = new System.Drawing.Size(184, 38);
            this.tbname.TabIndex = 4;
            this.tbname.Text = "Joshua";
            // 
            // trainingimage
            // 
            this.trainingimage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.trainingimage.Location = new System.Drawing.Point(34, 37);
            this.trainingimage.Margin = new System.Windows.Forms.Padding(6);
            this.trainingimage.Name = "trainingimage";
            this.trainingimage.Size = new System.Drawing.Size(276, 279);
            this.trainingimage.TabIndex = 3;
            this.trainingimage.TabStop = false;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(35, 24);
            this.label29.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(708, 55);
            this.label29.TabIndex = 8;
            this.label29.Text = "Double Vision Security System";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.camImage);
            this.groupBox4.Controls.Add(this.btnstart);
            this.groupBox4.Location = new System.Drawing.Point(59, 105);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox4.Size = new System.Drawing.Size(952, 465);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Main Camera";
            // 
            // camImage
            // 
            this.camImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.camImage.Location = new System.Drawing.Point(22, 38);
            this.camImage.Margin = new System.Windows.Forms.Padding(6);
            this.camImage.Name = "camImage";
            this.camImage.Size = new System.Drawing.Size(486, 392);
            this.camImage.TabIndex = 2;
            this.camImage.TabStop = false;
            // 
            // btnstart
            // 
            this.btnstart.Location = new System.Drawing.Point(634, 367);
            this.btnstart.Margin = new System.Windows.Forms.Padding(6);
            this.btnstart.Name = "btnstart";
            this.btnstart.Size = new System.Drawing.Size(268, 63);
            this.btnstart.TabIndex = 1;
            this.btnstart.Text = "Start";
            this.btnstart.UseVisualStyleBackColor = true;
            this.btnstart.Click += new System.EventHandler(this.btnstart_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(-27, -30);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(2504, 1296);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 33;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.BackColor = System.Drawing.Color.White;
            this.lblUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.Location = new System.Drawing.Point(1704, 13);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(0, 37);
            this.lblUsername.TabIndex = 34;
            // 
            // txtUsername
            // 
            this.txtUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.Location = new System.Drawing.Point(1658, 9);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.ReadOnly = true;
            this.txtUsername.Size = new System.Drawing.Size(280, 40);
            this.txtUsername.TabIndex = 35;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(1972, 18);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(77, 25);
            this.label30.TabIndex = 36;
            this.label30.Text = "UserID";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(2065, 16);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(100, 31);
            this.txtID.TabIndex = 37;
            // 
            // SensorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2453, 1298);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.tabControlForm);
            this.Controls.Add(this.btnLoggingOut);
            this.Controls.Add(this.lblSession);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblLocal);
            this.Controls.Add(this.lblSessionID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.rdbOnLED);
            this.Controls.Add(this.lblLocalTime);
            this.Controls.Add(this.rdbOffLED);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbCmdStr);
            this.Controls.Add(this.btnSendCmd);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.Name = "SensorForm";
            this.Text = "SensorInterface";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SensorForm_FormClosed_1);
            this.Load += new System.EventHandler(this.SensorForm_Load_1);
            this.tabPages2.ResumeLayout(false);
            this.tabPages2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tabControlForm.ResumeLayout(false);
            this.tpNetduinoComms.ResumeLayout(false);
            this.tpNetduinoComms.PerformLayout();
            this.tpOtherFunctions.ResumeLayout(false);
            this.groupBoxMotion.ResumeLayout(false);
            this.groupBoxMotion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.groupBoxUltrasonic.ResumeLayout(false);
            this.groupBoxUltrasonic.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartUltrasonic)).EndInit();
            this.groupBoxTemperature.ResumeLayout(false);
            this.groupBoxTemperature.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTemp)).EndInit();
            this.tabPageRFID1.ResumeLayout(false);
            this.tabPageRFID1.PerformLayout();
            this.Lights.ResumeLayout(false);
            this.Lights.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gpPreset.ResumeLayout(false);
            this.gpPreset.PerformLayout();
            this.Doorbell.ResumeLayout(false);
            this.Doorbell.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trainingimage)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.camImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSessionID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdbOnLED;
        private System.Windows.Forms.RadioButton rdbOffLED;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lblLocalTime;
        private System.Windows.Forms.Timer TimeNow;
        private System.Windows.Forms.Label lblSession;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Timer InsertTime;
        private System.Windows.Forms.Button btnLoggingOut;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblLocal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbCmdStr;
        private System.Windows.Forms.Button btnSendCmd;
        private System.Windows.Forms.Timer timerTemperature;
        private System.Windows.Forms.Timer timerUltrasonic;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.TabPage tabPages2;
        private System.Windows.Forms.Button btnSnapshot;
        private System.Windows.Forms.Label lblSecurityCamera;
        private System.Windows.Forms.Button btnGoback;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnStartCamera;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TabPage tpNetduinoComms;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.TextBox tbUltrasonicReading;
        private System.Windows.Forms.TextBox tbTemp;
        private System.Windows.Forms.TextBox tbPortStatus;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.ComboBox cbCommPorts;
        private System.Windows.Forms.ListBox lbReadings;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TabControl tabControlForm;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TabPage tpOtherFunctions;
        private System.Windows.Forms.GroupBox groupBoxMotion;
        private System.Windows.Forms.Button btnGoSecurityCamera;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbMotionSensor;
        private System.Windows.Forms.GroupBox groupBoxUltrasonic;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartUltrasonic;
        private System.Windows.Forms.ListBox lbSmoke;
        private System.Windows.Forms.TextBox tbUltraSonic;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbUltraSonicStatus;
        private System.Windows.Forms.GroupBox groupBoxTemperature;
        private System.Windows.Forms.TextBox tbTempK;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox tbTempF;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox tbRoomTemp;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTemp;
        private System.Windows.Forms.TextBox tbTempStatus;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label RFIDID;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TabPage tabPageRFID1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cbUltrasonicSensitivity;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbFanSpeed;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox cbAircon;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.GroupBox Lights;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtLightDuration;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label lblConfigurations;
        private System.Windows.Forms.GroupBox gpPreset;
        private System.Windows.Forms.Label lblTmp;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label lblSuggestion;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnOutside;
        private System.Windows.Forms.Button btnAthome;
        private System.Windows.Forms.TabPage Doorbell;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblnumface;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label lblfacedetected;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnsavedata;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox tbname;
        private Emgu.CV.UI.ImageBox trainingimage;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.GroupBox groupBox4;
        private Emgu.CV.UI.ImageBox camImage;
        private System.Windows.Forms.Button btnstart;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox txtID;
    }
}