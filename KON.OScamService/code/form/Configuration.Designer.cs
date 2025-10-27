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
            lblDelayStart = new System.Windows.Forms.Label();
            nudDelayStart = new System.Windows.Forms.NumericUpDown();
            btnSave = new System.Windows.Forms.Button();
            lblWebServiceUrl = new System.Windows.Forms.Label();
            lblWebServiceTimeout = new System.Windows.Forms.Label();
            txtWebServiceUrl = new System.Windows.Forms.TextBox();
            nudWebServiceTimeout = new System.Windows.Forms.NumericUpDown();
            lblLogLevel = new System.Windows.Forms.Label();
            cbLogLevel = new System.Windows.Forms.ComboBox();
            cbLogToConsole = new System.Windows.Forms.CheckBox();
            cbVerboseLogging = new System.Windows.Forms.CheckBox();
            nudCheckInterval = new System.Windows.Forms.NumericUpDown();
            lblCheckInterval = new System.Windows.Forms.Label();
            lblCheckEnable = new System.Windows.Forms.Label();
            cbCheckEnable = new System.Windows.Forms.CheckBox();
            lblAdditionalStartupParameters = new System.Windows.Forms.Label();
            txtAdditionalStartupParameters = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)nudDelayStart).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudWebServiceTimeout).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudCheckInterval).BeginInit();
            SuspendLayout();
            // 
            // lblDelayStart
            // 
            lblDelayStart.AutoSize = true;
            lblDelayStart.Location = new System.Drawing.Point(12, 14);
            lblDelayStart.Name = "lblDelayStart";
            lblDelayStart.Size = new System.Drawing.Size(107, 15);
            lblDelayStart.TabIndex = 1;
            lblDelayStart.Text = "Autostart Delay (s):";
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
            btnSave.Location = new System.Drawing.Point(382, 254);
            btnSave.Name = "btnSave";
            btnSave.Size = new System.Drawing.Size(75, 23);
            btnSave.TabIndex = 4;
            btnSave.Text = "&Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // lblWebServiceUrl
            // 
            lblWebServiceUrl.AutoSize = true;
            lblWebServiceUrl.Location = new System.Drawing.Point(12, 104);
            lblWebServiceUrl.Name = "lblWebServiceUrl";
            lblWebServiceUrl.Size = new System.Drawing.Size(92, 15);
            lblWebServiceUrl.TabIndex = 5;
            lblWebServiceUrl.Text = "Web Service Url:";
            // 
            // lblWebServiceTimeout
            // 
            lblWebServiceTimeout.AutoSize = true;
            lblWebServiceTimeout.Location = new System.Drawing.Point(12, 134);
            lblWebServiceTimeout.Name = "lblWebServiceTimeout";
            lblWebServiceTimeout.Size = new System.Drawing.Size(138, 15);
            lblWebServiceTimeout.TabIndex = 6;
            lblWebServiceTimeout.Text = "Web Service Timeout (s):";
            // 
            // txtWebServiceUrl
            // 
            txtWebServiceUrl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtWebServiceUrl.Location = new System.Drawing.Point(189, 101);
            txtWebServiceUrl.Name = "txtWebServiceUrl";
            txtWebServiceUrl.Size = new System.Drawing.Size(268, 23);
            txtWebServiceUrl.TabIndex = 7;
            txtWebServiceUrl.Text = "http://localhost/oscamapi.html?part=status";
            // 
            // nudWebServiceTimeout
            // 
            nudWebServiceTimeout.Location = new System.Drawing.Point(189, 132);
            nudWebServiceTimeout.Maximum = new decimal(new int[] { 60, 0, 0, 0 });
            nudWebServiceTimeout.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudWebServiceTimeout.Name = "nudWebServiceTimeout";
            nudWebServiceTimeout.Size = new System.Drawing.Size(55, 23);
            nudWebServiceTimeout.TabIndex = 8;
            nudWebServiceTimeout.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // lblLogLevel
            // 
            lblLogLevel.AutoSize = true;
            lblLogLevel.Location = new System.Drawing.Point(12, 164);
            lblLogLevel.Name = "lblLogLevel";
            lblLogLevel.Size = new System.Drawing.Size(60, 15);
            lblLogLevel.TabIndex = 9;
            lblLogLevel.Text = "Log Level:";
            // 
            // cbLogLevel
            // 
            cbLogLevel.FormattingEnabled = true;
            cbLogLevel.Items.AddRange(new object[] { "Error", "Warning", "Information" });
            cbLogLevel.Location = new System.Drawing.Point(189, 161);
            cbLogLevel.Name = "cbLogLevel";
            cbLogLevel.Size = new System.Drawing.Size(268, 23);
            cbLogLevel.TabIndex = 10;
            cbLogLevel.Text = "Warning";
            // 
            // cbLogToConsole
            // 
            cbLogToConsole.AutoSize = true;
            cbLogToConsole.Location = new System.Drawing.Point(189, 219);
            cbLogToConsole.Name = "cbLogToConsole";
            cbLogToConsole.Size = new System.Drawing.Size(104, 19);
            cbLogToConsole.TabIndex = 11;
            cbLogToConsole.Text = "Log to console";
            cbLogToConsole.UseVisualStyleBackColor = true;
            // 
            // cbVerboseLogging
            // 
            cbVerboseLogging.AutoSize = true;
            cbVerboseLogging.Location = new System.Drawing.Point(344, 219);
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
            // lblCheckInterval
            // 
            lblCheckInterval.AutoSize = true;
            lblCheckInterval.Location = new System.Drawing.Point(12, 74);
            lblCheckInterval.Name = "lblCheckInterval";
            lblCheckInterval.Size = new System.Drawing.Size(101, 15);
            lblCheckInterval.TabIndex = 20;
            lblCheckInterval.Text = "Check Interval (s):";
            // 
            // lblCheckEnable
            // 
            lblCheckEnable.AutoSize = true;
            lblCheckEnable.Location = new System.Drawing.Point(12, 44);
            lblCheckEnable.Name = "lblCheckEnable";
            lblCheckEnable.Size = new System.Drawing.Size(147, 15);
            lblCheckEnable.TabIndex = 22;
            lblCheckEnable.Text = "Enable WebService-Check:";
            // 
            // cbCheckEnable
            // 
            cbCheckEnable.AutoSize = true;
            cbCheckEnable.Checked = true;
            cbCheckEnable.CheckState = System.Windows.Forms.CheckState.Checked;
            cbCheckEnable.Location = new System.Drawing.Point(189, 45);
            cbCheckEnable.Name = "cbCheckEnable";
            cbCheckEnable.Size = new System.Drawing.Size(15, 14);
            cbCheckEnable.TabIndex = 23;
            cbCheckEnable.UseVisualStyleBackColor = true;
            // 
            // lblAdditionalStartupParameters
            // 
            lblAdditionalStartupParameters.AutoSize = true;
            lblAdditionalStartupParameters.Location = new System.Drawing.Point(12, 194);
            lblAdditionalStartupParameters.Name = "lblAdditionalStartupParameters";
            lblAdditionalStartupParameters.Size = new System.Drawing.Size(138, 15);
            lblAdditionalStartupParameters.TabIndex = 24;
            lblAdditionalStartupParameters.Text = "Add. Startup Parameters:";
            // 
            // txtAdditionalStartupParameters
            // 
            txtAdditionalStartupParameters.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtAdditionalStartupParameters.Location = new System.Drawing.Point(189, 190);
            txtAdditionalStartupParameters.Name = "txtAdditionalStartupParameters";
            txtAdditionalStartupParameters.Size = new System.Drawing.Size(268, 23);
            txtAdditionalStartupParameters.TabIndex = 25;
            txtAdditionalStartupParameters.Text = "-d 0";
            // 
            // frmConfiguration
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(470, 288);
            Controls.Add(txtAdditionalStartupParameters);
            Controls.Add(lblAdditionalStartupParameters);
            Controls.Add(cbCheckEnable);
            Controls.Add(lblCheckEnable);
            Controls.Add(nudCheckInterval);
            Controls.Add(lblCheckInterval);
            Controls.Add(cbVerboseLogging);
            Controls.Add(cbLogToConsole);
            Controls.Add(cbLogLevel);
            Controls.Add(lblLogLevel);
            Controls.Add(nudWebServiceTimeout);
            Controls.Add(txtWebServiceUrl);
            Controls.Add(lblWebServiceTimeout);
            Controls.Add(lblWebServiceUrl);
            Controls.Add(btnSave);
            Controls.Add(nudDelayStart);
            Controls.Add(lblDelayStart);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmConfiguration";
            Text = "                    ";
            Load += Configuration_Load;
            ((System.ComponentModel.ISupportInitialize)nudDelayStart).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudWebServiceTimeout).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudCheckInterval).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label lblDelayStart;
        private System.Windows.Forms.NumericUpDown nudDelayStart;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblWebServiceUrl;
        private System.Windows.Forms.Label lblWebServiceTimeout;
        private System.Windows.Forms.TextBox txtWebServiceUrl;
        private System.Windows.Forms.NumericUpDown nudWebServiceTimeout;
        private System.Windows.Forms.Label lblLogLevel;
        private System.Windows.Forms.ComboBox cbLogLevel;
        private System.Windows.Forms.CheckBox cbLogToConsole;
        private System.Windows.Forms.CheckBox cbVerboseLogging;
        private System.Windows.Forms.NumericUpDown nudCheckInterval;
        private System.Windows.Forms.Label lblCheckInterval;
        private System.Windows.Forms.Label lblCheckEnable;
        private System.Windows.Forms.CheckBox cbCheckEnable;
        private System.Windows.Forms.Label lblAdditionalStartupParameters;
        private System.Windows.Forms.TextBox txtAdditionalStartupParameters;
    }
}