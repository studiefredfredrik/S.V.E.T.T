namespace MainForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.grBoxSettings = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cboPeriod = new System.Windows.Forms.ComboBox();
            this.btnDefaults = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtMin = new System.Windows.Forms.TextBox();
            this.txtMax = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnContacts = new System.Windows.Forms.Button();
            this.checkSMS = new System.Windows.Forms.CheckBox();
            this.checkMail = new System.Windows.Forms.CheckBox();
            this.MainTimer = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbllow = new System.Windows.Forms.Label();
            this.lblAver = new System.Windows.Forms.Label();
            this.lblHigh = new System.Windows.Forms.Label();
            this.lblCT = new System.Windows.Forms.Label();
            this.lblCurrent = new System.Windows.Forms.Label();
            this.txtLowest = new System.Windows.Forms.Label();
            this.txtAvar = new System.Windows.Forms.Label();
            this.txtHigh = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.grBoxSettings.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(13, 13);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(445, 205);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            this.chart1.Click += new System.EventHandler(this.chart1_Click);
            // 
            // grBoxSettings
            // 
            this.grBoxSettings.Controls.Add(this.groupBox2);
            this.grBoxSettings.Controls.Add(this.btnDefaults);
            this.grBoxSettings.Controls.Add(this.btnSave);
            this.grBoxSettings.Controls.Add(this.groupBox3);
            this.grBoxSettings.Controls.Add(this.groupBox1);
            this.grBoxSettings.Location = new System.Drawing.Point(13, 224);
            this.grBoxSettings.Name = "grBoxSettings";
            this.grBoxSettings.Size = new System.Drawing.Size(445, 158);
            this.grBoxSettings.TabIndex = 2;
            this.grBoxSettings.TabStop = false;
            this.grBoxSettings.Text = "Settings";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cboPeriod);
            this.groupBox2.Location = new System.Drawing.Point(310, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(120, 65);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Show last:";
            // 
            // cboPeriod
            // 
            this.cboPeriod.FormattingEnabled = true;
            this.cboPeriod.Items.AddRange(new object[] {
            "10 min",
            "Hour",
            "Day"});
            this.cboPeriod.Location = new System.Drawing.Point(8, 18);
            this.cboPeriod.Name = "cboPeriod";
            this.cboPeriod.Size = new System.Drawing.Size(78, 21);
            this.cboPeriod.TabIndex = 19;
            this.cboPeriod.Text = "10 min";
            this.cboPeriod.SelectedIndexChanged += new System.EventHandler(this.cboPeriod_SelectedIndexChanged_1);
            // 
            // btnDefaults
            // 
            this.btnDefaults.Location = new System.Drawing.Point(318, 121);
            this.btnDefaults.Name = "btnDefaults";
            this.btnDefaults.Size = new System.Drawing.Size(102, 23);
            this.btnDefaults.TabIndex = 18;
            this.btnDefaults.Text = "Reset to defaults";
            this.btnDefaults.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(318, 92);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(102, 23);
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "Save settings";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click_1);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtMin);
            this.groupBox3.Controls.Add(this.txtMax);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(176, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(128, 125);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Temperature limits:";
            // 
            // txtMin
            // 
            this.txtMin.Location = new System.Drawing.Point(52, 45);
            this.txtMin.Name = "txtMin";
            this.txtMin.Size = new System.Drawing.Size(59, 20);
            this.txtMin.TabIndex = 2;
            // 
            // txtMax
            // 
            this.txtMax.Location = new System.Drawing.Point(52, 19);
            this.txtMax.Name = "txtMax";
            this.txtMax.Size = new System.Drawing.Size(59, 20);
            this.txtMax.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Min:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Max:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnContacts);
            this.groupBox1.Controls.Add(this.checkSMS);
            this.groupBox1.Controls.Add(this.checkMail);
            this.groupBox1.Location = new System.Drawing.Point(6, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(164, 125);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Messages to clients using:";
            // 
            // btnContacts
            // 
            this.btnContacts.Location = new System.Drawing.Point(6, 73);
            this.btnContacts.Name = "btnContacts";
            this.btnContacts.Size = new System.Drawing.Size(91, 23);
            this.btnContacts.TabIndex = 14;
            this.btnContacts.Text = "Edit contact list";
            this.btnContacts.UseVisualStyleBackColor = true;
            this.btnContacts.Click += new System.EventHandler(this.btnContacts_Click);
            // 
            // checkSMS
            // 
            this.checkSMS.AutoSize = true;
            this.checkSMS.Location = new System.Drawing.Point(6, 43);
            this.checkSMS.Name = "checkSMS";
            this.checkSMS.Size = new System.Drawing.Size(49, 17);
            this.checkSMS.TabIndex = 3;
            this.checkSMS.Text = "SMS";
            this.checkSMS.UseVisualStyleBackColor = true;
            // 
            // checkMail
            // 
            this.checkMail.AutoSize = true;
            this.checkMail.Location = new System.Drawing.Point(6, 19);
            this.checkMail.Name = "checkMail";
            this.checkMail.Size = new System.Drawing.Size(45, 17);
            this.checkMail.TabIndex = 2;
            this.checkMail.Text = "Mail";
            this.checkMail.UseVisualStyleBackColor = true;
            // 
            // MainTimer
            // 
            this.MainTimer.Tick += new System.EventHandler(this.MainTimer_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(466, 260);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 98);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click_1);
            // 
            // lbllow
            // 
            this.lbllow.AutoSize = true;
            this.lbllow.Location = new System.Drawing.Point(490, 175);
            this.lbllow.Name = "lbllow";
            this.lbllow.Size = new System.Drawing.Size(41, 13);
            this.lbllow.TabIndex = 9;
            this.lbllow.Text = "Lowest";
            // 
            // lblAver
            // 
            this.lblAver.AutoSize = true;
            this.lblAver.Location = new System.Drawing.Point(490, 134);
            this.lblAver.Name = "lblAver";
            this.lblAver.Size = new System.Drawing.Size(47, 13);
            this.lblAver.TabIndex = 10;
            this.lblAver.Text = "Average";
            // 
            // lblHigh
            // 
            this.lblHigh.AutoSize = true;
            this.lblHigh.Location = new System.Drawing.Point(490, 94);
            this.lblHigh.Name = "lblHigh";
            this.lblHigh.Size = new System.Drawing.Size(43, 13);
            this.lblHigh.TabIndex = 11;
            this.lblHigh.Text = "Highest";
            // 
            // lblCT
            // 
            this.lblCT.AutoSize = true;
            this.lblCT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCT.Location = new System.Drawing.Point(469, 13);
            this.lblCT.Name = "lblCT";
            this.lblCT.Size = new System.Drawing.Size(96, 40);
            this.lblCT.TabIndex = 18;
            this.lblCT.Text = "Current\r\ntemperature";
            // 
            // lblCurrent
            // 
            this.lblCurrent.AutoSize = true;
            this.lblCurrent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrent.Location = new System.Drawing.Point(473, 57);
            this.lblCurrent.Name = "lblCurrent";
            this.lblCurrent.Size = new System.Drawing.Size(31, 20);
            this.lblCurrent.TabIndex = 19;
            this.lblCurrent.Text = "n/a";
            // 
            // txtLowest
            // 
            this.txtLowest.AutoSize = true;
            this.txtLowest.Location = new System.Drawing.Point(490, 188);
            this.txtLowest.Name = "txtLowest";
            this.txtLowest.Size = new System.Drawing.Size(52, 13);
            this.txtLowest.TabIndex = 20;
            this.txtLowest.Text = "txtLowest";
            // 
            // txtAvar
            // 
            this.txtAvar.AutoSize = true;
            this.txtAvar.Location = new System.Drawing.Point(490, 147);
            this.txtAvar.Name = "txtAvar";
            this.txtAvar.Size = new System.Drawing.Size(40, 13);
            this.txtAvar.TabIndex = 20;
            this.txtAvar.Text = "txtAvar";
            // 
            // txtHigh
            // 
            this.txtHigh.AutoSize = true;
            this.txtHigh.Location = new System.Drawing.Point(490, 107);
            this.txtHigh.Name = "txtHigh";
            this.txtHigh.Size = new System.Drawing.Size(40, 13);
            this.txtHigh.TabIndex = 20;
            this.txtHigh.Text = "txtHigh";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 381);
            this.Controls.Add(this.txtHigh);
            this.Controls.Add(this.txtAvar);
            this.Controls.Add(this.txtLowest);
            this.Controls.Add(this.lblCurrent);
            this.Controls.Add(this.lblCT);
            this.Controls.Add(this.lblHigh);
            this.Controls.Add(this.lblAver);
            this.Controls.Add(this.lbllow);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.grBoxSettings);
            this.Controls.Add(this.chart1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "S.V.E.T.T.";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.grBoxSettings.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.GroupBox grBoxSettings;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtMin;
        private System.Windows.Forms.TextBox txtMax;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkSMS;
        private System.Windows.Forms.CheckBox checkMail;
        private System.Windows.Forms.Timer MainTimer;
        private System.Windows.Forms.Button btnContacts;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbllow;
        private System.Windows.Forms.Label lblAver;
        private System.Windows.Forms.Label lblHigh;
        private System.Windows.Forms.Label lblCT;
        private System.Windows.Forms.Label lblCurrent;
        private System.Windows.Forms.Label txtLowest;
        private System.Windows.Forms.Label txtAvar;
        private System.Windows.Forms.Label txtHigh;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cboPeriod;
        private System.Windows.Forms.Button btnDefaults;
        private System.Windows.Forms.Button btnSave;
    }
}

