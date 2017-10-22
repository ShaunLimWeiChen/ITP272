namespace SensorFormLatestNov
{
    partial class UltrasonicForm
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
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtAvg = new System.Windows.Forms.Label();
            this.UltraGridView = new System.Windows.Forms.DataGridView();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.grpDateRange = new System.Windows.Forms.GroupBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.FromDateTime = new System.Windows.Forms.DateTimePicker();
            this.ToDateTime = new System.Windows.Forms.DateTimePicker();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGridView)).BeginInit();
            this.grpDateRange.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Location = new System.Drawing.Point(597, 644);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(311, 94);
            this.btnExportExcel.TabIndex = 42;
            this.btnExportExcel.Text = "Export Data To Excel";
            this.btnExportExcel.UseVisualStyleBackColor = true;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtAvg);
            this.groupBox1.Location = new System.Drawing.Point(21, 636);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(535, 209);
            this.groupBox1.TabIndex = 41;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ULTRASONIC DATA ANALYSIS";
            // 
            // txtAvg
            // 
            this.txtAvg.AutoSize = true;
            this.txtAvg.BackColor = System.Drawing.Color.Transparent;
            this.txtAvg.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAvg.ForeColor = System.Drawing.Color.Tomato;
            this.txtAvg.Location = new System.Drawing.Point(19, 34);
            this.txtAvg.Name = "txtAvg";
            this.txtAvg.Size = new System.Drawing.Size(35, 37);
            this.txtAvg.TabIndex = 1;
            this.txtAvg.Text = "0";
            // 
            // UltraGridView
            // 
            this.UltraGridView.AllowUserToAddRows = false;
            this.UltraGridView.BackgroundColor = System.Drawing.Color.GhostWhite;
            this.UltraGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.UltraGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UltraGridView.Location = new System.Drawing.Point(21, 52);
            this.UltraGridView.Name = "UltraGridView";
            this.UltraGridView.RowTemplate.Height = 33;
            this.UltraGridView.Size = new System.Drawing.Size(887, 565);
            this.UltraGridView.TabIndex = 40;
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(597, 751);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(311, 94);
            this.btnDel.TabIndex = 43;
            this.btnDel.Text = "Delete ultrasonic data";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(597, 861);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(311, 75);
            this.btnClose.TabIndex = 44;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // grpDateRange
            // 
            this.grpDateRange.Controls.Add(this.label22);
            this.grpDateRange.Controls.Add(this.label23);
            this.grpDateRange.Controls.Add(this.FromDateTime);
            this.grpDateRange.Controls.Add(this.ToDateTime);
            this.grpDateRange.Location = new System.Drawing.Point(22, 861);
            this.grpDateRange.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpDateRange.Name = "grpDateRange";
            this.grpDateRange.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpDateRange.Size = new System.Drawing.Size(534, 216);
            this.grpDateRange.TabIndex = 45;
            this.grpDateRange.TabStop = false;
            this.grpDateRange.Text = "Select Range";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(153, 38);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(74, 25);
            this.label22.TabIndex = 37;
            this.label22.Text = "FROM";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(170, 125);
            this.label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(41, 25);
            this.label23.TabIndex = 36;
            this.label23.Text = "TO";
            // 
            // FromDateTime
            // 
            this.FromDateTime.Location = new System.Drawing.Point(8, 74);
            this.FromDateTime.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.FromDateTime.Name = "FromDateTime";
            this.FromDateTime.Size = new System.Drawing.Size(518, 31);
            this.FromDateTime.TabIndex = 34;
            this.FromDateTime.ValueChanged += new System.EventHandler(this.FromDateTime_ValueChanged);
            // 
            // ToDateTime
            // 
            this.ToDateTime.CalendarMonthBackground = System.Drawing.SystemColors.MenuHighlight;
            this.ToDateTime.Cursor = System.Windows.Forms.Cursors.Default;
            this.ToDateTime.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ToDateTime.Location = new System.Drawing.Point(8, 161);
            this.ToDateTime.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ToDateTime.Name = "ToDateTime";
            this.ToDateTime.Size = new System.Drawing.Size(518, 31);
            this.ToDateTime.TabIndex = 35;
            this.ToDateTime.ValueChanged += new System.EventHandler(this.ToDateTime_ValueChanged);
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(255, 12);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(112, 31);
            this.txtID.TabIndex = 49;
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(21, 12);
            this.txtUser.Name = "txtUser";
            this.txtUser.ReadOnly = true;
            this.txtUser.Size = new System.Drawing.Size(177, 31);
            this.txtUser.TabIndex = 48;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(217, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 25);
            this.label2.TabIndex = 47;
            this.label2.Text = "ID";
            // 
            // UltrasonicForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 1095);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.grpDateRange);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnExportExcel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.UltraGridView);
            this.Name = "UltrasonicForm";
            this.Text = "UltrasonicForm";
            this.Load += new System.EventHandler(this.UltrasonicForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGridView)).EndInit();
            this.grpDateRange.ResumeLayout(false);
            this.grpDateRange.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExportExcel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label txtAvg;
        private System.Windows.Forms.DataGridView UltraGridView;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox grpDateRange;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.DateTimePicker FromDateTime;
        private System.Windows.Forms.DateTimePicker ToDateTime;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label label2;
    }
}