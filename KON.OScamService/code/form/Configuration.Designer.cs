namespace KON.OScamService
{
    partial class frmConfiguration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfiguration));
            lbDelayStart = new System.Windows.Forms.Label();
            nudDelayStart = new System.Windows.Forms.NumericUpDown();
            btnSave = new System.Windows.Forms.Button();
            lbWebServiceUrl = new System.Windows.Forms.Label();
            lbWebServiceTimeout = new System.Windows.Forms.Label();
            tbWebServiceUrl = new System.Windows.Forms.TextBox();
            nudWebServiceTimeout = new System.Windows.Forms.NumericUpDown();
            lbLogLevel = new System.Windows.Forms.Label();
            cbLogLevel = new System.Windows.Forms.ComboBox();
            cbLogToConsole = new System.Windows.Forms.CheckBox();
            cbVerboseLogging = new System.Windows.Forms.CheckBox();
            nudCheckInterval = new System.Windows.Forms.NumericUpDown();
            lbCheckInterval = new System.Windows.Forms.Label();
            lbWebServiceCheckEnable = new System.Windows.Forms.Label();
            cbWebServiceCheckEnable = new System.Windows.Forms.CheckBox();
            lbAdditionalStartupParameters = new System.Windows.Forms.Label();
            tbAdditionalStartupParameters = new System.Windows.Forms.TextBox();
            tbOScamBinaryTitle = new System.Windows.Forms.TextBox();
            lbOScamBinaryTitle = new System.Windows.Forms.Label();
            tbOScamBinaryFilename = new System.Windows.Forms.TextBox();
            lbOScamBinaryFilename = new System.Windows.Forms.Label();
            tbOScamBinaryFilepath = new System.Windows.Forms.TextBox();
            lbOScamBinaryFilepath = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)nudDelayStart).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudWebServiceTimeout).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudCheckInterval).BeginInit();
            SuspendLayout();
            // 
            // lbDelayStart
            // 
            lbDelayStart.AutoSize = true;
            lbDelayStart.Location = new System.Drawing.Point(12, 14);
            lbDelayStart.Name = "lbDelayStart";
            lbDelayStart.Size = new System.Drawing.Size(107, 15);
            lbDelayStart.TabIndex = 1;
            lbDelayStart.Text = "Autostart Delay (s):";
            // 
            // nudDelayStart
            // 
            nudDelayStart.Location = new System.Drawing.Point(189, 12);
            nudDelayStart.Maximum = new decimal(new int[] { 600, 0, 0, 0 });
            nudDelayStart.Name = "nudDelayStart";
            nudDelayStart.Size = new System.Drawing.Size(55, 23);
            nudDelayStart.TabIndex = 2;
            // 
            // btnSave
            // 
            btnSave.Location = new System.Drawing.Point(522, 339);
            btnSave.Name = "btnSave";
            btnSave.Size = new System.Drawing.Size(75, 23);
            btnSave.TabIndex = 4;
            btnSave.Text = "&Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // lbWebServiceUrl
            // 
            lbWebServiceUrl.AutoSize = true;
            lbWebServiceUrl.Location = new System.Drawing.Point(12, 190);
            lbWebServiceUrl.Name = "lbWebServiceUrl";
            lbWebServiceUrl.Size = new System.Drawing.Size(92, 15);
            lbWebServiceUrl.TabIndex = 5;
            lbWebServiceUrl.Text = "Web Service Url:";
            // 
            // lbWebServiceTimeout
            // 
            lbWebServiceTimeout.AutoSize = true;
            lbWebServiceTimeout.Location = new System.Drawing.Point(12, 219);
            lbWebServiceTimeout.Name = "lbWebServiceTimeout";
            lbWebServiceTimeout.Size = new System.Drawing.Size(138, 15);
            lbWebServiceTimeout.TabIndex = 6;
            lbWebServiceTimeout.Text = "Web Service Timeout (s):";
            // 
            // tbWebServiceUrl
            // 
            tbWebServiceUrl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            tbWebServiceUrl.Location = new System.Drawing.Point(189, 188);
            tbWebServiceUrl.Name = "tbWebServiceUrl";
            tbWebServiceUrl.Size = new System.Drawing.Size(408, 23);
            tbWebServiceUrl.TabIndex = 7;
            tbWebServiceUrl.Text = "http://localhost/oscamapi.html?part=status";
            // 
            // nudWebServiceTimeout
            // 
            nudWebServiceTimeout.Location = new System.Drawing.Point(189, 217);
            nudWebServiceTimeout.Maximum = new decimal(new int[] { 60, 0, 0, 0 });
            nudWebServiceTimeout.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudWebServiceTimeout.Name = "nudWebServiceTimeout";
            nudWebServiceTimeout.Size = new System.Drawing.Size(55, 23);
            nudWebServiceTimeout.TabIndex = 8;
            nudWebServiceTimeout.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // lbLogLevel
            // 
            lbLogLevel.AutoSize = true;
            lbLogLevel.Location = new System.Drawing.Point(12, 249);
            lbLogLevel.Name = "lbLogLevel";
            lbLogLevel.Size = new System.Drawing.Size(60, 15);
            lbLogLevel.TabIndex = 9;
            lbLogLevel.Text = "Log Level:";
            // 
            // cbLogLevel
            // 
            cbLogLevel.FormattingEnabled = true;
            cbLogLevel.Items.AddRange(new object[] { "Error", "Warning", "Information" });
            cbLogLevel.Location = new System.Drawing.Point(189, 246);
            cbLogLevel.Name = "cbLogLevel";
            cbLogLevel.Size = new System.Drawing.Size(408, 23);
            cbLogLevel.TabIndex = 10;
            cbLogLevel.Text = "Warning";
            // 
            // cbLogToConsole
            // 
            cbLogToConsole.AutoSize = true;
            cbLogToConsole.Location = new System.Drawing.Point(189, 304);
            cbLogToConsole.Name = "cbLogToConsole";
            cbLogToConsole.Size = new System.Drawing.Size(104, 19);
            cbLogToConsole.TabIndex = 11;
            cbLogToConsole.Text = "Log to console";
            cbLogToConsole.UseVisualStyleBackColor = true;
            // 
            // cbVerboseLogging
            // 
            cbVerboseLogging.AutoSize = true;
            cbVerboseLogging.Location = new System.Drawing.Point(483, 304);
            cbVerboseLogging.Name = "cbVerboseLogging";
            cbVerboseLogging.Size = new System.Drawing.Size(114, 19);
            cbVerboseLogging.TabIndex = 19;
            cbVerboseLogging.Text = "Verbose Logging";
            cbVerboseLogging.UseVisualStyleBackColor = true;
            // 
            // nudCheckInterval
            // 
            nudCheckInterval.Location = new System.Drawing.Point(189, 72);
            nudCheckInterval.Maximum = new decimal(new int[] { 60, 0, 0, 0 });
            nudCheckInterval.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudCheckInterval.Name = "nudCheckInterval";
            nudCheckInterval.Size = new System.Drawing.Size(55, 23);
            nudCheckInterval.TabIndex = 21;
            nudCheckInterval.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // lbCheckInterval
            // 
            lbCheckInterval.AutoSize = true;
            lbCheckInterval.Location = new System.Drawing.Point(12, 74);
            lbCheckInterval.Name = "lbCheckInterval";
            lbCheckInterval.Size = new System.Drawing.Size(101, 15);
            lbCheckInterval.TabIndex = 20;
            lbCheckInterval.Text = "Check Interval (s):";
            // 
            // lbWebServiceCheckEnable
            // 
            lbWebServiceCheckEnable.AutoSize = true;
            lbWebServiceCheckEnable.Location = new System.Drawing.Point(12, 44);
            lbWebServiceCheckEnable.Name = "lbWebServiceCheckEnable";
            lbWebServiceCheckEnable.Size = new System.Drawing.Size(147, 15);
            lbWebServiceCheckEnable.TabIndex = 22;
            lbWebServiceCheckEnable.Text = "Enable WebService-Check:";
            // 
            // cbWebServiceCheckEnable
            // 
            cbWebServiceCheckEnable.AutoSize = true;
            cbWebServiceCheckEnable.Checked = true;
            cbWebServiceCheckEnable.CheckState = System.Windows.Forms.CheckState.Checked;
            cbWebServiceCheckEnable.Location = new System.Drawing.Point(189, 45);
            cbWebServiceCheckEnable.Name = "cbWebServiceCheckEnable";
            cbWebServiceCheckEnable.Size = new System.Drawing.Size(15, 14);
            cbWebServiceCheckEnable.TabIndex = 23;
            cbWebServiceCheckEnable.UseVisualStyleBackColor = true;
            // 
            // lbAdditionalStartupParameters
            // 
            lbAdditionalStartupParameters.AutoSize = true;
            lbAdditionalStartupParameters.Location = new System.Drawing.Point(12, 277);
            lbAdditionalStartupParameters.Name = "lbAdditionalStartupParameters";
            lbAdditionalStartupParameters.Size = new System.Drawing.Size(138, 15);
            lbAdditionalStartupParameters.TabIndex = 24;
            lbAdditionalStartupParameters.Text = "Add. Startup Parameters:";
            // 
            // tbAdditionalStartupParameters
            // 
            tbAdditionalStartupParameters.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            tbAdditionalStartupParameters.Location = new System.Drawing.Point(189, 275);
            tbAdditionalStartupParameters.Name = "tbAdditionalStartupParameters";
            tbAdditionalStartupParameters.Size = new System.Drawing.Size(408, 23);
            tbAdditionalStartupParameters.TabIndex = 25;
            tbAdditionalStartupParameters.Text = "-d 0";
            // 
            // tbOScamBinaryTitle
            // 
            tbOScamBinaryTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            tbOScamBinaryTitle.Location = new System.Drawing.Point(189, 101);
            tbOScamBinaryTitle.Name = "tbOScamBinaryTitle";
            tbOScamBinaryTitle.Size = new System.Drawing.Size(408, 23);
            tbOScamBinaryTitle.TabIndex = 27;
            tbOScamBinaryTitle.Text = "oscam";
            // 
            // lbOScamBinaryTitle
            // 
            lbOScamBinaryTitle.AutoSize = true;
            lbOScamBinaryTitle.Location = new System.Drawing.Point(12, 104);
            lbOScamBinaryTitle.Name = "lbOScamBinaryTitle";
            lbOScamBinaryTitle.Size = new System.Drawing.Size(110, 15);
            lbOScamBinaryTitle.TabIndex = 26;
            lbOScamBinaryTitle.Text = "OScam Binary Title:";
            // 
            // tbOScamBinaryFilename
            // 
            tbOScamBinaryFilename.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            tbOScamBinaryFilename.Location = new System.Drawing.Point(189, 130);
            tbOScamBinaryFilename.Name = "tbOScamBinaryFilename";
            tbOScamBinaryFilename.Size = new System.Drawing.Size(408, 23);
            tbOScamBinaryFilename.TabIndex = 29;
            tbOScamBinaryFilename.Text = "oscam.exe";
            // 
            // lbOScamBinaryFilename
            // 
            lbOScamBinaryFilename.AutoSize = true;
            lbOScamBinaryFilename.Location = new System.Drawing.Point(12, 133);
            lbOScamBinaryFilename.Name = "lbOScamBinaryFilename";
            lbOScamBinaryFilename.Size = new System.Drawing.Size(135, 15);
            lbOScamBinaryFilename.TabIndex = 28;
            lbOScamBinaryFilename.Text = "OScam Binary Filename:";
            // 
            // tbOScamBinaryFilepath
            // 
            tbOScamBinaryFilepath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            tbOScamBinaryFilepath.Location = new System.Drawing.Point(189, 159);
            tbOScamBinaryFilepath.Name = "tbOScamBinaryFilepath";
            tbOScamBinaryFilepath.Size = new System.Drawing.Size(408, 23);
            tbOScamBinaryFilepath.TabIndex = 31;
            tbOScamBinaryFilepath.Text = "C:\\Program Files\\KON.OScamService\\3rdparty\\oscam";
            // 
            // lbOScamBinaryFilepath
            // 
            lbOScamBinaryFilepath.AutoSize = true;
            lbOScamBinaryFilepath.Location = new System.Drawing.Point(12, 162);
            lbOScamBinaryFilepath.Name = "lbOScamBinaryFilepath";
            lbOScamBinaryFilepath.Size = new System.Drawing.Size(129, 15);
            lbOScamBinaryFilepath.TabIndex = 30;
            lbOScamBinaryFilepath.Text = "OScam Binary Filepath:";
            // 
            // frmConfiguration
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(611, 375);
            Controls.Add(tbOScamBinaryFilepath);
            Controls.Add(lbOScamBinaryFilepath);
            Controls.Add(tbOScamBinaryFilename);
            Controls.Add(lbOScamBinaryFilename);
            Controls.Add(tbOScamBinaryTitle);
            Controls.Add(lbOScamBinaryTitle);
            Controls.Add(tbAdditionalStartupParameters);
            Controls.Add(lbAdditionalStartupParameters);
            Controls.Add(cbWebServiceCheckEnable);
            Controls.Add(lbWebServiceCheckEnable);
            Controls.Add(nudCheckInterval);
            Controls.Add(lbCheckInterval);
            Controls.Add(cbVerboseLogging);
            Controls.Add(cbLogToConsole);
            Controls.Add(cbLogLevel);
            Controls.Add(lbLogLevel);
            Controls.Add(nudWebServiceTimeout);
            Controls.Add(tbWebServiceUrl);
            Controls.Add(lbWebServiceTimeout);
            Controls.Add(lbWebServiceUrl);
            Controls.Add(btnSave);
            Controls.Add(nudDelayStart);
            Controls.Add(lbDelayStart);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmConfiguration";
            Text = "KON.OScamService Configuration    ";
            Load += Configuration_Load;
            ((System.ComponentModel.ISupportInitialize)nudDelayStart).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudWebServiceTimeout).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudCheckInterval).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label lbDelayStart;
        private System.Windows.Forms.NumericUpDown nudDelayStart;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lbWebServiceUrl;
        private System.Windows.Forms.Label lbWebServiceTimeout;
        private System.Windows.Forms.TextBox tbWebServiceUrl;
        private System.Windows.Forms.NumericUpDown nudWebServiceTimeout;
        private System.Windows.Forms.Label lbLogLevel;
        private System.Windows.Forms.ComboBox cbLogLevel;
        private System.Windows.Forms.CheckBox cbLogToConsole;
        private System.Windows.Forms.CheckBox cbVerboseLogging;
        private System.Windows.Forms.NumericUpDown nudCheckInterval;
        private System.Windows.Forms.Label lbCheckInterval;
        private System.Windows.Forms.Label lbWebServiceCheckEnable;
        private System.Windows.Forms.CheckBox cbWebServiceCheckEnable;
        private System.Windows.Forms.Label lbAdditionalStartupParameters;
        private System.Windows.Forms.TextBox tbAdditionalStartupParameters;
        private System.Windows.Forms.TextBox tbOScamBinaryTitle;
        private System.Windows.Forms.Label lbOScamBinaryTitle;
        private System.Windows.Forms.TextBox tbOScamBinaryFilename;
        private System.Windows.Forms.Label lbOScamBinaryFilename;
        private System.Windows.Forms.TextBox tbOScamBinaryFilepath;
        private System.Windows.Forms.Label lbOScamBinaryFilepath;
    }
}