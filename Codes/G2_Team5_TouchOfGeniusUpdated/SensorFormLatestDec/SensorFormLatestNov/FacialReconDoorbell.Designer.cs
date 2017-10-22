namespace SensorFormLatestNov
{
    partial class FacialReconDoorbell
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
            this.btnstart = new System.Windows.Forms.Button();
            this.camImage = new Emgu.CV.UI.ImageBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnsavedata = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbname = new System.Windows.Forms.TextBox();
            this.trainingimage = new Emgu.CV.UI.ImageBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblnumface = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblfacedetected = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.camImage)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trainingimage)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnstart
            // 
            this.btnstart.Location = new System.Drawing.Point(644, 367);
            this.btnstart.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnstart.Name = "btnstart";
            this.btnstart.Size = new System.Drawing.Size(268, 63);
            this.btnstart.TabIndex = 1;
            this.btnstart.Text = "Start";
            this.btnstart.UseVisualStyleBackColor = true;
            this.btnstart.Click += new System.EventHandler(this.btnstart_Click);
            // 
            // camImage
            // 
            this.camImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.camImage.Location = new System.Drawing.Point(22, 38);
            this.camImage.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.camImage.Name = "camImage";
            this.camImage.Size = new System.Drawing.Size(486, 392);
            this.camImage.TabIndex = 2;
            this.camImage.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.camImage);
            this.groupBox1.Controls.Add(this.btnstart);
            this.groupBox1.Location = new System.Drawing.Point(66, 104);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox1.Size = new System.Drawing.Size(952, 465);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Main Camera";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(42, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(708, 55);
            this.label1.TabIndex = 4;
            this.label1.Text = "Double Vision Security System";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnsavedata);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.tbname);
            this.groupBox2.Controls.Add(this.trainingimage);
            this.groupBox2.Location = new System.Drawing.Point(54, 581);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox2.Size = new System.Drawing.Size(964, 365);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Training Set";
            // 
            // btnsavedata
            // 
            this.btnsavedata.Location = new System.Drawing.Point(656, 262);
            this.btnsavedata.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnsavedata.Name = "btnsavedata";
            this.btnsavedata.Size = new System.Drawing.Size(268, 56);
            this.btnsavedata.TabIndex = 6;
            this.btnsavedata.Text = "Save Record";
            this.btnsavedata.UseVisualStyleBackColor = true;
            this.btnsavedata.Click += new System.EventHandler(this.btnsavedata_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(324, 144);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Name:";
            // 
            // tbname
            // 
            this.tbname.Location = new System.Drawing.Point(436, 138);
            this.tbname.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tbname.Name = "tbname";
            this.tbname.Size = new System.Drawing.Size(184, 31);
            this.tbname.TabIndex = 4;
            this.tbname.Text = "Joshua";
            // 
            // trainingimage
            // 
            this.trainingimage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.trainingimage.Location = new System.Drawing.Point(34, 37);
            this.trainingimage.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.trainingimage.Name = "trainingimage";
            this.trainingimage.Size = new System.Drawing.Size(276, 279);
            this.trainingimage.TabIndex = 3;
            this.trainingimage.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblnumface);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.lblfacedetected);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(1094, 104);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox3.Size = new System.Drawing.Size(656, 337);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Data Output";
            // 
            // lblnumface
            // 
            this.lblnumface.AutoSize = true;
            this.lblnumface.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnumface.ForeColor = System.Drawing.Color.Red;
            this.lblnumface.Location = new System.Drawing.Point(278, 158);
            this.lblnumface.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblnumface.Name = "lblnumface";
            this.lblnumface.Size = new System.Drawing.Size(37, 38);
            this.lblnumface.TabIndex = 3;
            this.lblnumface.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 169);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(236, 25);
            this.label5.TabIndex = 2;
            this.label5.Text = "No. Of Faces Detected:";
            // 
            // lblfacedetected
            // 
            this.lblfacedetected.AutoSize = true;
            this.lblfacedetected.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblfacedetected.ForeColor = System.Drawing.Color.Red;
            this.lblfacedetected.Location = new System.Drawing.Point(278, 75);
            this.lblfacedetected.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblfacedetected.Name = "lblfacedetected";
            this.lblfacedetected.Size = new System.Drawing.Size(329, 38);
            this.lblfacedetected.TabIndex = 1;
            this.lblfacedetected.Text = "No Faces Detected.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 87);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(169, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "Faces Detected:";
            // 
            // FacialReconDoorbell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1790, 969);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "FacialReconDoorbell";
            this.Text = "KnockKnock";
            this.Load += new System.EventHandler(this.FacialReconDoorbell_Load);
            ((System.ComponentModel.ISupportInitialize)(this.camImage)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trainingimage)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnstart;
        private Emgu.CV.UI.ImageBox camImage;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnsavedata;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbname;
        private Emgu.CV.UI.ImageBox trainingimage;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblnumface;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblfacedetected;
        private System.Windows.Forms.Label label3;
    }
}