namespace SensorFormLatestNov
{
    partial class LoginForm
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
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.Login = new System.Windows.Forms.Label();
            this.lblRFIDString = new System.Windows.Forms.Label();
            this.lblRFID = new System.Windows.Forms.Label();
            this.cbCommPorts = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.lbReadings = new System.Windows.Forms.ListBox();
            this.lblRFIDChecking = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.lblRFID1 = new System.Windows.Forms.Label();
            this.lblRFIDText = new System.Windows.Forms.Label();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(496, 280);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(207, 35);
            this.txtPassword.TabIndex = 16;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            // 
            // txtUsername
            // 
            this.txtUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.Location = new System.Drawing.Point(496, 229);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(207, 35);
            this.txtUsername.TabIndex = 15;
            this.txtUsername.TextChanged += new System.EventHandler(this.txtUsername_TextChanged);
            this.txtUsername.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUsername_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(363, 283);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 29);
            this.label2.TabIndex = 14;
            this.label2.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(363, 229);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 29);
            this.label1.TabIndex = 13;
            this.label1.Text = "Username";
            // 
            // btnLogin
            // 
            this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.Location = new System.Drawing.Point(478, 376);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(161, 55);
            this.btnLogin.TabIndex = 12;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // Login
            // 
            this.Login.AutoSize = true;
            this.Login.BackColor = System.Drawing.Color.Transparent;
            this.Login.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Login.Location = new System.Drawing.Point(469, 121);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(188, 72);
            this.Login.TabIndex = 19;
            this.Login.Text = "Login";
            // 
            // lblRFIDString
            // 
            this.lblRFIDString.AutoSize = true;
            this.lblRFIDString.BackColor = System.Drawing.Color.Transparent;
            this.lblRFIDString.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRFIDString.ForeColor = System.Drawing.Color.Black;
            this.lblRFIDString.Location = new System.Drawing.Point(706, 34);
            this.lblRFIDString.Name = "lblRFIDString";
            this.lblRFIDString.Size = new System.Drawing.Size(128, 29);
            this.lblRFIDString.TabIndex = 20;
            this.lblRFIDString.Text = "Scan RFID";
            this.lblRFIDString.Visible = false;
            // 
            // lblRFID
            // 
            this.lblRFID.AutoSize = true;
            this.lblRFID.BackColor = System.Drawing.Color.Transparent;
            this.lblRFID.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRFID.Location = new System.Drawing.Point(108, 504);
            this.lblRFID.Name = "lblRFID";
            this.lblRFID.Size = new System.Drawing.Size(60, 25);
            this.lblRFID.TabIndex = 22;
            this.lblRFID.Text = "RFID";
            this.lblRFID.Visible = false;
            // 
            // cbCommPorts
            // 
            this.cbCommPorts.FormattingEnabled = true;
            this.cbCommPorts.Location = new System.Drawing.Point(412, 57);
            this.cbCommPorts.Name = "cbCommPorts";
            this.cbCommPorts.Size = new System.Drawing.Size(222, 33);
            this.cbCommPorts.TabIndex = 27;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(174, 60);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(223, 25);
            this.label14.TabIndex = 28;
            this.label14.Text = "Available Comm Ports";
            // 
            // lbReadings
            // 
            this.lbReadings.FormattingEnabled = true;
            this.lbReadings.ItemHeight = 25;
            this.lbReadings.Location = new System.Drawing.Point(12, 12);
            this.lbReadings.Name = "lbReadings";
            this.lbReadings.Size = new System.Drawing.Size(119, 29);
            this.lbReadings.TabIndex = 29;
            this.lbReadings.Visible = false;
            // 
            // lblRFIDChecking
            // 
            this.lblRFIDChecking.AutoSize = true;
            this.lblRFIDChecking.BackColor = System.Drawing.Color.Transparent;
            this.lblRFIDChecking.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRFIDChecking.Location = new System.Drawing.Point(108, 603);
            this.lblRFIDChecking.Name = "lblRFIDChecking";
            this.lblRFIDChecking.Size = new System.Drawing.Size(60, 25);
            this.lblRFIDChecking.TabIndex = 30;
            this.lblRFIDChecking.Text = "RFID";
            this.lblRFIDChecking.Visible = false;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(503, 30);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(140, 47);
            this.btnConnect.TabIndex = 31;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // lblRFID1
            // 
            this.lblRFID1.AutoSize = true;
            this.lblRFID1.BackColor = System.Drawing.Color.Transparent;
            this.lblRFID1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRFID1.Location = new System.Drawing.Point(755, 65);
            this.lblRFID1.Name = "lblRFID1";
            this.lblRFID1.Size = new System.Drawing.Size(21, 29);
            this.lblRFID1.TabIndex = 32;
            this.lblRFID1.Text = "-";
            this.lblRFID1.Visible = false;
            this.lblRFID1.TextChanged += new System.EventHandler(this.lblRFID1_TextChanged);
            this.lblRFID1.Click += new System.EventHandler(this.lblRFID1_Click);
            // 
            // lblRFIDText
            // 
            this.lblRFIDText.AutoSize = true;
            this.lblRFIDText.BackColor = System.Drawing.Color.Transparent;
            this.lblRFIDText.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRFIDText.Location = new System.Drawing.Point(787, 603);
            this.lblRFIDText.Name = "lblRFIDText";
            this.lblRFIDText.Size = new System.Drawing.Size(60, 25);
            this.lblRFIDText.TabIndex = 33;
            this.lblRFIDText.Text = "RFID";
            this.lblRFIDText.Visible = false;
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(649, 30);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(148, 47);
            this.btnDisconnect.TabIndex = 34;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(577, 603);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 25);
            this.label4.TabIndex = 35;
            this.label4.Text = "RFID Card:";
            this.label4.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblRFIDString);
            this.groupBox1.Controls.Add(this.lblRFID1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(30, 466);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1062, 220);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "RFID";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnConnect);
            this.groupBox2.Controls.Add(this.btnDisconnect);
            this.groupBox2.Location = new System.Drawing.Point(157, 24);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(933, 94);
            this.groupBox2.TabIndex = 37;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Comm Ports";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1172, 720);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblRFIDText);
            this.Controls.Add(this.lblRFIDChecking);
            this.Controls.Add(this.lbReadings);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.cbCommPorts);
            this.Controls.Add(this.lblRFID);
            this.Controls.Add(this.Login);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPassword;
        public System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label Login;
        private System.Windows.Forms.Label lblRFIDString;
        public System.Windows.Forms.Label lblRFID;
        private System.Windows.Forms.ComboBox cbCommPorts;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ListBox lbReadings;
        private System.Windows.Forms.Label lblRFIDChecking;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label lblRFID1;
        private System.Windows.Forms.Label lblRFIDText;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}