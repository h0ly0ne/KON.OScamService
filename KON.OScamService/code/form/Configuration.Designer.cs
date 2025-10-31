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
            lbOScamStartDelay = new System.Windows.Forms.Label();
            nudOScamStartDelay = new System.Windows.Forms.NumericUpDown();
            btnSave = new System.Windows.Forms.Button();
            lbLogLevel = new System.Windows.Forms.Label();
            cbLogLevel = new System.Windows.Forms.ComboBox();
            cbLogToConsole = new System.Windows.Forms.CheckBox();
            cbVerboseLogging = new System.Windows.Forms.CheckBox();
            nudOScamCheckInterval = new System.Windows.Forms.NumericUpDown();
            lbOScamCheckInterval = new System.Windows.Forms.Label();
            lbOScamAdditionalParameters = new System.Windows.Forms.Label();
            tbOScamAdditionalParameters = new System.Windows.Forms.TextBox();
            tbOScamBinaryTitle = new System.Windows.Forms.TextBox();
            lbOScamBinaryTitle = new System.Windows.Forms.Label();
            tbOScamBinaryFilename = new System.Windows.Forms.TextBox();
            lbOScamBinaryFilename = new System.Windows.Forms.Label();
            tbOScamBinaryFilepath = new System.Windows.Forms.TextBox();
            lbOScamBinaryFilepath = new System.Windows.Forms.Label();
            gbWebService = new System.Windows.Forms.GroupBox();
            nudWebServiceTimeout = new System.Windows.Forms.NumericUpDown();
            tbWebServiceUrl = new System.Windows.Forms.TextBox();
            lbWebServiceTimeout = new System.Windows.Forms.Label();
            lbWebServiceUrl = new System.Windows.Forms.Label();
            cbWebServiceEnabled = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)nudOScamStartDelay).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudOScamCheckInterval).BeginInit();
            gbWebService.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudWebServiceTimeout).BeginInit();
            SuspendLayout();
            // 
            // lbOScamStartDelay
            // 
            lbOScamStartDelay.AutoSize = true;
            lbOScamStartDelay.Location = new System.Drawing.Point(12, 14);
            lbOScamStartDelay.Name = "lbOScamStartDelay";
            lbOScamStartDelay.Size = new System.Drawing.Size(120, 15);
            lbOScamStartDelay.TabIndex = 1;
            lbOScamStartDelay.Text = "OScam StartDelay (s):";
            // 
            // nudOScamStartDelay
            // 
            nudOScamStartDelay.Location = new System.Drawing.Point(189, 12);
            nudOScamStartDelay.Maximum = new decimal(new int[] { 600, 0, 0, 0 });
            nudOScamStartDelay.Name = "nudOScamStartDelay";
            nudOScamStartDelay.Size = new System.Drawing.Size(55, 23);
            nudOScamStartDelay.TabIndex = 2;
            // 
            // btnSave
            // 
            btnSave.Location = new System.Drawing.Point(413, 351);
            btnSave.Name = "btnSave";
            btnSave.Size = new System.Drawing.Size(75, 23);
            btnSave.TabIndex = 4;
            btnSave.Text = "&Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // lbLogLevel
            // 
            lbLogLevel.AutoSize = true;
            lbLogLevel.Location = new System.Drawing.Point(18, 291);
            lbLogLevel.Name = "lbLogLevel";
            lbLogLevel.Size = new System.Drawing.Size(60, 15);
            lbLogLevel.TabIndex = 9;
            lbLogLevel.Text = "Log Level:";
            // 
            // cbLogLevel
            // 
            cbLogLevel.FormattingEnabled = true;
            cbLogLevel.Items.AddRange(new object[] { "Error", "Warning", "Information" });
            cbLogLevel.Location = new System.Drawing.Point(189, 288);
            cbLogLevel.Name = "cbLogLevel";
            cbLogLevel.Size = new System.Drawing.Size(299, 23);
            cbLogLevel.TabIndex = 10;
            cbLogLevel.Text = "Warning";
            // 
            // cbLogToConsole
            // 
            cbLogToConsole.AutoSize = true;
            cbLogToConsole.Location = new System.Drawing.Point(189, 317);
            cbLogToConsole.Name = "cbLogToConsole";
            cbLogToConsole.Size = new System.Drawing.Size(104, 19);
            cbLogToConsole.TabIndex = 11;
            cbLogToConsole.Text = "Log to console";
            cbLogToConsole.UseVisualStyleBackColor = true;
            // 
            // cbVerboseLogging
            // 
            cbVerboseLogging.AutoSize = true;
            cbVerboseLogging.Location = new System.Drawing.Point(374, 317);
            cbVerboseLogging.Name = "cbVerboseLogging";
            cbVerboseLogging.Size = new System.Drawing.Size(114, 19);
            cbVerboseLogging.TabIndex = 19;
            cbVerboseLogging.Text = "Verbose Logging";
            cbVerboseLogging.UseVisualStyleBackColor = true;
            // 
            // nudOScamCheckInterval
            // 
            nudOScamCheckInterval.Location = new System.Drawing.Point(189, 128);
            nudOScamCheckInterval.Maximum = new decimal(new int[] { 60, 0, 0, 0 });
            nudOScamCheckInterval.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudOScamCheckInterval.Name = "nudOScamCheckInterval";
            nudOScamCheckInterval.Size = new System.Drawing.Size(55, 23);
            nudOScamCheckInterval.TabIndex = 21;
            nudOScamCheckInterval.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // lbOScamCheckInterval
            // 
            lbOScamCheckInterval.AutoSize = true;
            lbOScamCheckInterval.Location = new System.Drawing.Point(12, 130);
            lbOScamCheckInterval.Name = "lbOScamCheckInterval";
            lbOScamCheckInterval.Size = new System.Drawing.Size(139, 15);
            lbOScamCheckInterval.TabIndex = 20;
            lbOScamCheckInterval.Text = "OScam CheckInterval (s):";
            // 
            // lbOScamAdditionalParameters
            // 
            lbOScamAdditionalParameters.AutoSize = true;
            lbOScamAdditionalParameters.Location = new System.Drawing.Point(12, 159);
            lbOScamAdditionalParameters.Name = "lbOScamAdditionalParameters";
            lbOScamAdditionalParameters.Size = new System.Drawing.Size(138, 15);
            lbOScamAdditionalParameters.TabIndex = 24;
            lbOScamAdditionalParameters.Text = "OScam Add. Parameters:";
            // 
            // tbOScamAdditionalParameters
            // 
            tbOScamAdditionalParameters.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            tbOScamAdditionalParameters.Location = new System.Drawing.Point(189, 157);
            tbOScamAdditionalParameters.Name = "tbOScamAdditionalParameters";
            tbOScamAdditionalParameters.Size = new System.Drawing.Size(305, 23);
            tbOScamAdditionalParameters.TabIndex = 25;
            tbOScamAdditionalParameters.Text = "-d 0";
            // 
            // tbOScamBinaryTitle
            // 
            tbOScamBinaryTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            tbOScamBinaryTitle.Location = new System.Drawing.Point(189, 41);
            tbOScamBinaryTitle.Name = "tbOScamBinaryTitle";
            tbOScamBinaryTitle.Size = new System.Drawing.Size(305, 23);
            tbOScamBinaryTitle.TabIndex = 27;
            tbOScamBinaryTitle.Text = "oscam";
            // 
            // lbOScamBinaryTitle
            // 
            lbOScamBinaryTitle.AutoSize = true;
            lbOScamBinaryTitle.Location = new System.Drawing.Point(12, 43);
            lbOScamBinaryTitle.Name = "lbOScamBinaryTitle";
            lbOScamBinaryTitle.Size = new System.Drawing.Size(110, 15);
            lbOScamBinaryTitle.TabIndex = 26;
            lbOScamBinaryTitle.Text = "OScam Binary Title:";
            // 
            // tbOScamBinaryFilename
            // 
            tbOScamBinaryFilename.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            tbOScamBinaryFilename.Location = new System.Drawing.Point(189, 70);
            tbOScamBinaryFilename.Name = "tbOScamBinaryFilename";
            tbOScamBinaryFilename.Size = new System.Drawing.Size(305, 23);
            tbOScamBinaryFilename.TabIndex = 29;
            tbOScamBinaryFilename.Text = "oscam.exe";
            // 
            // lbOScamBinaryFilename
            // 
            lbOScamBinaryFilename.AutoSize = true;
            lbOScamBinaryFilename.Location = new System.Drawing.Point(12, 72);
            lbOScamBinaryFilename.Name = "lbOScamBinaryFilename";
            lbOScamBinaryFilename.Size = new System.Drawing.Size(135, 15);
            lbOScamBinaryFilename.TabIndex = 28;
            lbOScamBinaryFilename.Text = "OScam Binary Filename:";
            // 
            // tbOScamBinaryFilepath
            // 
            tbOScamBinaryFilepath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            tbOScamBinaryFilepath.Location = new System.Drawing.Point(189, 99);
            tbOScamBinaryFilepath.Name = "tbOScamBinaryFilepath";
            tbOScamBinaryFilepath.Size = new System.Drawing.Size(305, 23);
            tbOScamBinaryFilepath.TabIndex = 31;
            tbOScamBinaryFilepath.Text = "C:\\Program Files\\KON.OScamService\\3rdparty\\oscam";
            // 
            // lbOScamBinaryFilepath
            // 
            lbOScamBinaryFilepath.AutoSize = true;
            lbOScamBinaryFilepath.Location = new System.Drawing.Point(12, 101);
            lbOScamBinaryFilepath.Name = "lbOScamBinaryFilepath";
            lbOScamBinaryFilepath.Size = new System.Drawing.Size(129, 15);
            lbOScamBinaryFilepath.TabIndex = 30;
            lbOScamBinaryFilepath.Text = "OScam Binary Filepath:";
            // 
            // gbWebService
            // 
            gbWebService.Controls.Add(nudWebServiceTimeout);
            gbWebService.Controls.Add(tbWebServiceUrl);
            gbWebService.Controls.Add(lbWebServiceTimeout);
            gbWebService.Controls.Add(lbWebServiceUrl);
            gbWebService.Location = new System.Drawing.Point(12, 195);
            gbWebService.Name = "gbWebService";
            gbWebService.Size = new System.Drawing.Size(482, 87);
            gbWebService.TabIndex = 34;
            gbWebService.TabStop = false;
            gbWebService.Text = "WebService Check";
            // 
            // nudWebServiceTimeout
            // 
            nudWebServiceTimeout.Location = new System.Drawing.Point(177, 55);
            nudWebServiceTimeout.Maximum = new decimal(new int[] { 60, 0, 0, 0 });
            nudWebServiceTimeout.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudWebServiceTimeout.Name = "nudWebServiceTimeout";
            nudWebServiceTimeout.Size = new System.Drawing.Size(55, 23);
            nudWebServiceTimeout.TabIndex = 29;
            nudWebServiceTimeout.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // tbWebServiceUrl
            // 
            tbWebServiceUrl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            tbWebServiceUrl.Location = new System.Drawing.Point(177, 26);
            tbWebServiceUrl.Name = "tbWebServiceUrl";
            tbWebServiceUrl.Size = new System.Drawing.Size(299, 23);
            tbWebServiceUrl.TabIndex = 28;
            tbWebServiceUrl.Text = "http://localhost/oscamapi.html?part=status";
            // 
            // lbWebServiceTimeout
            // 
            lbWebServiceTimeout.AutoSize = true;
            lbWebServiceTimeout.Location = new System.Drawing.Point(6, 57);
            lbWebServiceTimeout.Name = "lbWebServiceTimeout";
            lbWebServiceTimeout.Size = new System.Drawing.Size(138, 15);
            lbWebServiceTimeout.TabIndex = 25;
            lbWebServiceTimeout.Text = "Web Service Timeout (s):";
            // 
            // lbWebServiceUrl
            // 
            lbWebServiceUrl.AutoSize = true;
            lbWebServiceUrl.Location = new System.Drawing.Point(6, 28);
            lbWebServiceUrl.Name = "lbWebServiceUrl";
            lbWebServiceUrl.Size = new System.Drawing.Size(92, 15);
            lbWebServiceUrl.TabIndex = 24;
            lbWebServiceUrl.Text = "Web Service Url:";
            // 
            // cbWebServiceEnabled
            // 
            cbWebServiceEnabled.AutoSize = true;
            cbWebServiceEnabled.Checked = true;
            cbWebServiceEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            cbWebServiceEnabled.Location = new System.Drawing.Point(423, 193);
            cbWebServiceEnabled.Name = "cbWebServiceEnabled";
            cbWebServiceEnabled.Size = new System.Drawing.Size(68, 19);
            cbWebServiceEnabled.TabIndex = 35;
            cbWebServiceEnabled.Text = "Enabled";
            cbWebServiceEnabled.UseVisualStyleBackColor = true;
            cbWebServiceEnabled.CheckedChanged += cbWebServiceEnabled_CheckedChanged;
            // 
            // frmConfiguration
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(512, 387);
            Controls.Add(cbWebServiceEnabled);
            Controls.Add(gbWebService);
            Controls.Add(tbOScamBinaryFilepath);
            Controls.Add(lbOScamBinaryFilepath);
            Controls.Add(tbOScamBinaryFilename);
            Controls.Add(lbOScamBinaryFilename);
            Controls.Add(tbOScamBinaryTitle);
            Controls.Add(lbOScamBinaryTitle);
            Controls.Add(tbOScamAdditionalParameters);
            Controls.Add(lbOScamAdditionalParameters);
            Controls.Add(nudOScamCheckInterval);
            Controls.Add(lbOScamCheckInterval);
            Controls.Add(cbVerboseLogging);
            Controls.Add(cbLogToConsole);
            Controls.Add(cbLogLevel);
            Controls.Add(lbLogLevel);
            Controls.Add(btnSave);
            Controls.Add(nudOScamStartDelay);
            Controls.Add(lbOScamStartDelay);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmConfiguration";
            Text = "KON.OScamService Configuration    ";
            Load += Configuration_Load;
            ((System.ComponentModel.ISupportInitialize)nudOScamStartDelay).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudOScamCheckInterval).EndInit();
            gbWebService.ResumeLayout(false);
            gbWebService.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudWebServiceTimeout).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label lbOScamStartDelay;
        private System.Windows.Forms.NumericUpDown nudOScamStartDelay;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lbLogLevel;
        private System.Windows.Forms.ComboBox cbLogLevel;
        private System.Windows.Forms.CheckBox cbLogToConsole;
        private System.Windows.Forms.CheckBox cbVerboseLogging;
        private System.Windows.Forms.NumericUpDown nudOScamCheckInterval;
        private System.Windows.Forms.Label lbOScamCheckInterval;
        private System.Windows.Forms.Label lbOScamAdditionalParameters;
        private System.Windows.Forms.TextBox tbOScamAdditionalParameters;
        private System.Windows.Forms.TextBox tbOScamBinaryTitle;
        private System.Windows.Forms.Label lbOScamBinaryTitle;
        private System.Windows.Forms.TextBox tbOScamBinaryFilename;
        private System.Windows.Forms.Label lbOScamBinaryFilename;
        private System.Windows.Forms.TextBox tbOScamBinaryFilepath;
        private System.Windows.Forms.Label lbOScamBinaryFilepath;
        private System.Windows.Forms.GroupBox gbWebService;
        private System.Windows.Forms.NumericUpDown nudWebServiceTimeout;
        private System.Windows.Forms.TextBox tbWebServiceUrl;
        private System.Windows.Forms.Label lbWebServiceTimeout;
        private System.Windows.Forms.Label lbWebServiceUrl;
        private System.Windows.Forms.CheckBox cbWebServiceEnabled;
    }
}