namespace SensorFormLatestNov
{
    partial class GasForm
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
            this.GasGridView = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtavgconc = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.GasGridView)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Location = new System.Drawing.Point(608, 609);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(311, 94);
            this.btnExportExcel.TabIndex = 41;
            this.btnExportExcel.Text = "Export Data To Excel";
            this.btnExportExcel.UseVisualStyleBackColor = true;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // GasGridView
            // 
            this.GasGridView.BackgroundColor = System.Drawing.Color.GhostWhite;
            this.GasGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.GasGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GasGridView.Location = new System.Drawing.Point(32, 16);
            this.GasGridView.Name = "GasGridView";
            this.GasGridView.RowTemplate.Height = 33;
            this.GasGridView.Size = new System.Drawing.Size(887, 579);
            this.GasGridView.TabIndex = 40;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtavgconc);
            this.groupBox4.Location = new System.Drawing.Point(925, 16);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(544, 244);
            this.groupBox4.TabIndex = 42;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "GAS SENSOR ANALYSIS";
            // 
            // txtavgconc
            // 
            this.txtavgconc.AutoSize = true;
            this.txtavgconc.BackColor = System.Drawing.Color.Transparent;
            this.txtavgconc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.txtavgconc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtavgconc.ForeColor = System.Drawing.Color.OrangeRed;
            this.txtavgconc.Location = new System.Drawing.Point(19, 49);
            this.txtavgconc.Name = "txtavgconc";
            this.txtavgconc.Size = new System.Drawing.Size(35, 37);
            this.txtavgconc.TabIndex = 5;
            this.txtavgconc.Text = "0";
            this.txtavgconc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(281, 609);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(311, 94);
            this.btnClose.TabIndex = 43;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // GasForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1481, 715);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btnExportExcel);
            this.Controls.Add(this.GasGridView);
            this.Name = "GasForm";
            this.Text = "Gas";
            this.Load += new System.EventHandler(this.GasForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GasGridView)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExportExcel;
        private System.Windows.Forms.DataGridView GasGridView;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label txtavgconc;
        private System.Windows.Forms.Button btnClose;
    }
}