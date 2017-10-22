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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label14 = new System.Windows.Forms.Label();
            this.lblSessionID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tabControlForm = new System.Windows.Forms.TabControl();
            this.tpNetduinoComms = new System.Windows.Forms.TabPage();
            this.btnDel = new System.Windows.Forms.Button();
            this.tbUltrasonicReading = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.tbTemp = new System.Windows.Forms.TextBox();
            this.tbPortStatus = new System.Windows.Forms.TextBox();
            this.cbCommPorts = new System.Windows.Forms.ComboBox();
            this.lbReadings = new System.Windows.Forms.ListBox();
            this.tpOtherFunctions = new System.Windows.Forms.TabPage();
            this.groupBoxMotion = new System.Windows.Forms.GroupBox();
            this.btnGoSecurityCamera = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbMotionSensor = new System.Windows.Forms.TextBox();
            this.groupBoxUltrasonic = new System.Windows.Forms.GroupBox();
            this.txtUltrasonic = new System.Windows.Forms.TextBox();
            this.btnUltrasonic = new System.Windows.Forms.Button();
            this.txtTemperatureManual = new System.Windows.Forms.TextBox();
            this.btnInsertTemp = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.chartUltrasonic = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lbSmoke = new System.Windows.Forms.ListBox();
            this.tbUltraSonic = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbUltraSonicStatus = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblDetected = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.chartSmoke = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.rtbSmoke = new System.Windows.Forms.RichTextBox();
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
            this.tabPages2 = new System.Windows.Forms.TabPage();
            this.btnSnapshot = new System.Windows.Forms.Button();
            this.lblSecurityCamera = new System.Windows.Forms.Label();
            this.btnGoback = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnStartCamera = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            label13 = new System.Windows.Forms.Label();
            this.tabControlForm.SuspendLayout();
            this.tpNetduinoComms.SuspendLayout();
            this.tpOtherFunctions.SuspendLayout();
            this.groupBoxMotion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.groupBoxUltrasonic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartUltrasonic)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartSmoke)).BeginInit();
            this.groupBoxTemperature.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTemp)).BeginInit();
            this.tabPages2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
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
            // tabControlForm
            // 
            this.tabControlForm.Controls.Add(this.tpNetduinoComms);
            this.tabControlForm.Controls.Add(this.tpOtherFunctions);
            this.tabControlForm.Controls.Add(this.tabPages2);
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
            this.tpNetduinoComms.Controls.Add(this.btnDel);
            this.tpNetduinoComms.Controls.Add(this.tbUltrasonicReading);
            this.tpNetduinoComms.Controls.Add(this.label7);
            this.tpNetduinoComms.Controls.Add(this.label4);
            this.tpNetduinoComms.Controls.Add(this.btnDisconnect);
            this.tpNetduinoComms.Controls.Add(this.btnConnect);
            this.tpNetduinoComms.Controls.Add(this.tbTemp);
            this.tpNetduinoComms.Controls.Add(this.tbPortStatus);
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
            // cbCommPorts
            // 
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
            this.lbReadings.ItemHeight = 31;
            this.lbReadings.Location = new System.Drawing.Point(50, 355);
            this.lbReadings.Margin = new System.Windows.Forms.Padding(2);
            this.lbReadings.Name = "lbReadings";
            this.lbReadings.ScrollAlwaysVisible = true;
            this.lbReadings.Size = new System.Drawing.Size(2311, 810);
            this.lbReadings.TabIndex = 4;
            this.lbReadings.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lbReadings_DrawItem);
            // 
            // tpOtherFunctions
            // 
            this.tpOtherFunctions.AutoScroll = true;
            this.tpOtherFunctions.Controls.Add(this.groupBoxMotion);
            this.tpOtherFunctions.Controls.Add(this.groupBoxUltrasonic);
            this.tpOtherFunctions.Controls.Add(this.groupBox2);
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
            this.groupBoxMotion.Controls.Add(this.btnGoSecurityCamera);
            this.groupBoxMotion.Controls.Add(this.pictureBox);
            this.groupBoxMotion.Controls.Add(this.label2);
            this.groupBoxMotion.Controls.Add(this.tbMotionSensor);
            this.groupBoxMotion.Location = new System.Drawing.Point(1029, 659);
            this.groupBoxMotion.Name = "groupBoxMotion";
            this.groupBoxMotion.Size = new System.Drawing.Size(1366, 527);
            this.groupBoxMotion.TabIndex = 35;
            this.groupBoxMotion.TabStop = false;
            this.groupBoxMotion.Text = "4";
            // 
            // btnGoSecurityCamera
            // 
            this.btnGoSecurityCamera.Location = new System.Drawing.Point(1205, 376);
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
            this.pictureBox.Location = new System.Drawing.Point(661, 51);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(689, 415);
            this.pictureBox.TabIndex = 24;
            this.pictureBox.TabStop = false;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(188, 73);
            this.label2.TabIndex = 23;
            this.label2.Text = "Motion Sensor Status";
            // 
            // tbMotionSensor
            // 
            this.tbMotionSensor.Location = new System.Drawing.Point(200, 37);
            this.tbMotionSensor.Multiline = true;
            this.tbMotionSensor.Name = "tbMotionSensor";
            this.tbMotionSensor.ReadOnly = true;
            this.tbMotionSensor.Size = new System.Drawing.Size(371, 148);
            this.tbMotionSensor.TabIndex = 22;
            // 
            // groupBoxUltrasonic
            // 
            this.groupBoxUltrasonic.Controls.Add(this.txtUltrasonic);
            this.groupBoxUltrasonic.Controls.Add(this.btnUltrasonic);
            this.groupBoxUltrasonic.Controls.Add(this.txtTemperatureManual);
            this.groupBoxUltrasonic.Controls.Add(this.btnInsertTemp);
            this.groupBoxUltrasonic.Controls.Add(this.label8);
            this.groupBoxUltrasonic.Controls.Add(this.chartUltrasonic);
            this.groupBoxUltrasonic.Controls.Add(this.lbSmoke);
            this.groupBoxUltrasonic.Controls.Add(this.tbUltraSonic);
            this.groupBoxUltrasonic.Controls.Add(this.label3);
            this.groupBoxUltrasonic.Controls.Add(this.tbUltraSonicStatus);
            this.groupBoxUltrasonic.Location = new System.Drawing.Point(1029, 6);
            this.groupBoxUltrasonic.Name = "groupBoxUltrasonic";
            this.groupBoxUltrasonic.Size = new System.Drawing.Size(1366, 670);
            this.groupBoxUltrasonic.TabIndex = 34;
            this.groupBoxUltrasonic.TabStop = false;
            this.groupBoxUltrasonic.Text = "2";
            // 
            // txtUltrasonic
            // 
            this.txtUltrasonic.Location = new System.Drawing.Point(707, 165);
            this.txtUltrasonic.Name = "txtUltrasonic";
            this.txtUltrasonic.Size = new System.Drawing.Size(152, 38);
            this.txtUltrasonic.TabIndex = 38;
            // 
            // btnUltrasonic
            // 
            this.btnUltrasonic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnUltrasonic.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnUltrasonic.Location = new System.Drawing.Point(889, 141);
            this.btnUltrasonic.Name = "btnUltrasonic";
            this.btnUltrasonic.Size = new System.Drawing.Size(392, 85);
            this.btnUltrasonic.TabIndex = 39;
            this.btnUltrasonic.Text = "Insert distance manually (in cm)";
            this.btnUltrasonic.UseVisualStyleBackColor = false;
            this.btnUltrasonic.Click += new System.EventHandler(this.btnUltrasonic_Click);
            // 
            // txtTemperatureManual
            // 
            this.txtTemperatureManual.Location = new System.Drawing.Point(707, 74);
            this.txtTemperatureManual.Name = "txtTemperatureManual";
            this.txtTemperatureManual.Size = new System.Drawing.Size(152, 38);
            this.txtTemperatureManual.TabIndex = 36;
            // 
            // btnInsertTemp
            // 
            this.btnInsertTemp.BackColor = System.Drawing.Color.Red;
            this.btnInsertTemp.Location = new System.Drawing.Point(889, 50);
            this.btnInsertTemp.Name = "btnInsertTemp";
            this.btnInsertTemp.Size = new System.Drawing.Size(392, 85);
            this.btnInsertTemp.TabIndex = 37;
            this.btnInsertTemp.Text = "Insert temperature manually (In celcius)";
            this.btnInsertTemp.UseVisualStyleBackColor = false;
            this.btnInsertTemp.Click += new System.EventHandler(this.button1_Click);
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
            chartArea1.Area3DStyle.Inclination = 50;
            chartArea1.Area3DStyle.IsClustered = true;
            chartArea1.Area3DStyle.LightStyle = System.Windows.Forms.DataVisualization.Charting.LightStyle.Realistic;
            chartArea1.Area3DStyle.WallWidth = 0;
            chartArea1.Name = "Distance";
            this.chartUltrasonic.ChartAreas.Add(chartArea1);
            legend1.Name = "\"\"";
            this.chartUltrasonic.Legends.Add(legend1);
            this.chartUltrasonic.Location = new System.Drawing.Point(12, 75);
            this.chartUltrasonic.Name = "chartUltrasonic";
            this.chartUltrasonic.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.EarthTones;
            series1.ChartArea = "Distance";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedArea;
            series1.Legend = "\"\"";
            series1.Name = "Distance";
            series1.YValuesPerPoint = 4;
            this.chartUltrasonic.Series.Add(series1);
            this.chartUltrasonic.Size = new System.Drawing.Size(689, 441);
            this.chartUltrasonic.TabIndex = 29;
            this.chartUltrasonic.Text = "chartUltrasonic";
            this.chartUltrasonic.MouseLeave += new System.EventHandler(this.chartUltrasonic_MouseLeave);
            this.chartUltrasonic.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chartUltrasonic_MouseMove_1);
            // 
            // lbSmoke
            // 
            this.lbSmoke.FormattingEnabled = true;
            this.lbSmoke.ItemHeight = 31;
            this.lbSmoke.Items.AddRange(new object[] {
            "LPG",
            "Butane",
            "Propane",
            "Methane",
            "Alcohol",
            "Hydrogen",
            "Carbon Monoxide",
            "Arsine",
            "",
            "Show temperature database",
            "Show ultrasonic database",
            "Show motion database",
            "Show gas database",
            "Save temperature chart",
            "Save ultrasonic chart",
            "Save gas chart"});
            this.lbSmoke.Location = new System.Drawing.Point(747, 240);
            this.lbSmoke.Name = "lbSmoke";
            this.lbSmoke.Size = new System.Drawing.Size(534, 407);
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.btnClear);
            this.groupBox2.Controls.Add(this.lblDetected);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.chartSmoke);
            this.groupBox2.Controls.Add(this.rtbSmoke);
            this.groupBox2.Location = new System.Drawing.Point(6, 659);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1033, 527);
            this.groupBox2.TabIndex = 33;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "3";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(325, 454);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(193, 29);
            this.label12.TabIndex = 46;
            this.label12.Text = "Gas composition";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(853, 104);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(142, 83);
            this.btnClear.TabIndex = 45;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click_2);
            // 
            // lblDetected
            // 
            this.lblDetected.AutoSize = true;
            this.lblDetected.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetected.Location = new System.Drawing.Point(32, 34);
            this.lblDetected.Name = "lblDetected";
            this.lblDetected.Size = new System.Drawing.Size(136, 29);
            this.lblDetected.TabIndex = 20;
            this.lblDetected.Text = "lblDetected";
            this.lblDetected.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(539, 51);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(207, 25);
            this.label9.TabIndex = 19;
            this.label9.Text = "Concentration (ppm)";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(829, 57);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(187, 31);
            this.label10.TabIndex = 16;
            this.label10.Text = "Smoke sensor";
            // 
            // chartSmoke
            // 
            this.chartSmoke.BackColor = System.Drawing.Color.Transparent;
            this.chartSmoke.BackImageTransparentColor = System.Drawing.Color.Transparent;
            this.chartSmoke.BackSecondaryColor = System.Drawing.Color.Transparent;
            this.chartSmoke.BorderlineColor = System.Drawing.Color.Transparent;
            chartArea2.Area3DStyle.Enable3D = true;
            chartArea2.Area3DStyle.Inclination = 50;
            chartArea2.Area3DStyle.LightStyle = System.Windows.Forms.DataVisualization.Charting.LightStyle.Realistic;
            chartArea2.Area3DStyle.WallWidth = 0;
            chartArea2.Name = "Smoke";
            this.chartSmoke.ChartAreas.Add(chartArea2);
            legend2.Name = "\"\"";
            this.chartSmoke.Legends.Add(legend2);
            this.chartSmoke.Location = new System.Drawing.Point(6, 79);
            this.chartSmoke.Name = "chartSmoke";
            series2.ChartArea = "Smoke";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series2.Legend = "\"\"";
            series2.Name = "Smoke";
            series2.YValuesPerPoint = 4;
            this.chartSmoke.Series.Add(series2);
            this.chartSmoke.Size = new System.Drawing.Size(817, 391);
            this.chartSmoke.TabIndex = 18;
            this.chartSmoke.Text = "chartSmoke";
            this.chartSmoke.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chartSmoke_MouseMove_1);
            // 
            // rtbSmoke
            // 
            this.rtbSmoke.Location = new System.Drawing.Point(6, 149);
            this.rtbSmoke.Name = "rtbSmoke";
            this.rtbSmoke.ReadOnly = true;
            this.rtbSmoke.Size = new System.Drawing.Size(646, 321);
            this.rtbSmoke.TabIndex = 17;
            this.rtbSmoke.Text = "";
            this.rtbSmoke.Visible = false;
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
            this.groupBoxTemperature.Location = new System.Drawing.Point(6, 6);
            this.groupBoxTemperature.Name = "groupBoxTemperature";
            this.groupBoxTemperature.Size = new System.Drawing.Size(1023, 670);
            this.groupBoxTemperature.TabIndex = 32;
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
            this.tbTempF.Location = new System.Drawing.Point(581, 31);
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
            this.chartTemp.BackColor = System.Drawing.Color.Transparent;
            this.chartTemp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chartTemp.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.BottomRight;
            this.chartTemp.BackImageTransparentColor = System.Drawing.Color.Transparent;
            chartArea3.Area3DStyle.Inclination = 50;
            chartArea3.Area3DStyle.LightStyle = System.Windows.Forms.DataVisualization.Charting.LightStyle.Realistic;
            chartArea3.Area3DStyle.Rotation = 10;
            chartArea3.Area3DStyle.WallWidth = 0;
            chartArea3.CursorX.IsUserEnabled = true;
            chartArea3.CursorX.IsUserSelectionEnabled = true;
            chartArea3.Name = "Temperature";
            this.chartTemp.ChartAreas.Add(chartArea3);
            legend3.Name = "\"\"";
            this.chartTemp.Legends.Add(legend3);
            this.chartTemp.Location = new System.Drawing.Point(6, 73);
            this.chartTemp.Name = "chartTemp";
            this.chartTemp.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SemiTransparent;
            series3.ChartArea = "Temperature";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedArea;
            series3.Legend = "\"\"";
            series3.Name = "Temperature";
            series3.YValuesPerPoint = 4;
            this.chartTemp.Series.Add(series3);
            this.chartTemp.Size = new System.Drawing.Size(1011, 443);
            this.chartTemp.TabIndex = 28;
            this.chartTemp.Text = "chartTemp";
            this.chartTemp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.chartTemp_MouseDown);
            this.chartTemp.MouseEnter += new System.EventHandler(this.chartTemp_MouseEnter);
            this.chartTemp.MouseLeave += new System.EventHandler(this.chartTemp_MouseLeave);
            this.chartTemp.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chartTemp_MouseMove);
            // 
            // tbTempStatus
            // 
            this.tbTempStatus.Location = new System.Drawing.Point(169, 537);
            this.tbTempStatus.Multiline = true;
            this.tbTempStatus.Name = "tbTempStatus";
            this.tbTempStatus.ReadOnly = true;
            this.tbTempStatus.Size = new System.Drawing.Size(463, 82);
            this.tbTempStatus.TabIndex = 5;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(31, 567);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(92, 31);
            this.label15.TabIndex = 2;
            this.label15.Text = "Status";
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
            // 
            // label6
            // 
            this.label6.AutoSize = true;
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
            this.lblLocal.BackColor = System.Drawing.Color.Transparent;
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
            // SensorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2453, 1315);
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
            this.Name = "SensorForm";
            this.Text = "SensorInterface";
            this.Load += new System.EventHandler(this.SensorForm_Load_1);
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
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartSmoke)).EndInit();
            this.groupBoxTemperature.ResumeLayout(false);
            this.groupBoxTemperature.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTemp)).EndInit();
            this.tabPages2.ResumeLayout(false);
            this.tabPages2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblSessionID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TabControl tabControlForm;
        private System.Windows.Forms.TabPage tpNetduinoComms;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox tbPortStatus;
        private System.Windows.Forms.ComboBox cbCommPorts;
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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblLocal;
        private System.Windows.Forms.TabPage tpOtherFunctions;
        private System.Windows.Forms.GroupBox groupBoxMotion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbMotionSensor;
        private System.Windows.Forms.GroupBox groupBoxUltrasonic;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartUltrasonic;
        private System.Windows.Forms.TextBox tbUltraSonic;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbUltraSonicStatus;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbTempStatus;
        private System.Windows.Forms.GroupBox groupBoxTemperature;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox tbRoomTemp;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTemp;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbCmdStr;
        private System.Windows.Forms.Button btnSendCmd;
        private System.Windows.Forms.Button btnInsertTemp;
        private System.Windows.Forms.TextBox txtTemperatureManual;
        private System.Windows.Forms.Timer timerTemperature;
        private System.Windows.Forms.Timer timerUltrasonic;
        private System.Windows.Forms.TextBox txtUltrasonic;
        private System.Windows.Forms.Button btnUltrasonic;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TabPage tabPages2;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStartCamera;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnGoback;
        private System.Windows.Forms.Button btnGoSecurityCamera;
        private System.Windows.Forms.Label lblSecurityCamera;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnSnapshot;
        private System.Windows.Forms.TextBox tbTemp;
        private System.Windows.Forms.TextBox tbUltrasonicReading;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox lbReadings;
        private System.Windows.Forms.ListBox lbSmoke;
        private System.Windows.Forms.RichTextBox rtbSmoke;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSmoke;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblDetected;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.TextBox tbTempK;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox tbTempF;
        private System.Windows.Forms.Button btnDel;
    }
}