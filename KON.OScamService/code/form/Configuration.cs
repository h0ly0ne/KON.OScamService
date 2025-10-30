using System;
using System.Reflection;
using System.Runtime.Versioning;
using System.Windows.Forms;

namespace KON.OScamService {
    [SupportedOSPlatform("windows")]
    public partial class frmConfiguration : Form
    {
        public frmConfiguration()
        {
            InitializeComponent();
        }

        private void Configuration_Load(object sender, EventArgs e)
        {
            configurationLoad();
            configurationUIUpdate();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Text == Resources.frmConfiguration_btnSave_Text)
            {
                configurationSave();
                DialogResult = DialogResult.OK;
            }
            else
                DialogResult = DialogResult.Abort;

            Close();
        }

        private void configurationLoad()
        {
            var iOScamStartDelay = Global.srsLocalRegistrySettings.GetInteger(Resources.frmConfiguration_srsKeyOScamStartDelay, Convert.ToInt32(Resources.frmConfiguration_srsKeyOScamStartDelay_DefaultValue));
            if (iOScamStartDelay > 599)
                iOScamStartDelay = 600;
            if (iOScamStartDelay < 0)
                iOScamStartDelay = 0;
            nudOScamStartDelay.Value = iOScamStartDelay;

            tbOScamBinaryTitle.Text = Global.srsLocalRegistrySettings.GetString(Resources.frmConfiguration_srsKeyOScamBinaryTitle, Resources.frmConfiguration_srsKeyOScamBinaryTitle_DefaultValue);
            tbOScamBinaryFilename.Text = Global.srsLocalRegistrySettings.GetString(Resources.frmConfiguration_srsKeyOScamBinaryFilename, Resources.frmConfiguration_srsKeyOScamBinaryFilename_DefaultValue);
            tbOScamBinaryFilepath.Text = Global.srsLocalRegistrySettings.GetString(Resources.frmConfiguration_srsKeyOScamBinaryFilepath, Resources.frmConfiguration_srsKeyOScamBinaryFilepath_DefaultValue);

            var iCheckInterval = Global.srsLocalRegistrySettings.GetInteger(Resources.frmConfiguration_srsKeyOScamCheckInterval, Convert.ToInt32(Resources.frmConfiguration_srsKeyOScamCheckInterval_DefaultValue));
            if (iCheckInterval > 59)
                iCheckInterval = 60;
            if (iCheckInterval < 1)
                iCheckInterval = 1;
            nudOScamCheckInterval.Value = iCheckInterval;

            tbOScamAdditionalParameters.Text = Global.srsLocalRegistrySettings.GetString(Resources.frmConfiguration_srsKeyOScamAdditionalParameters, Resources.frmConfiguration_srsKeyOScamAdditionalParameters_DefaultValue);
            cbWebServiceEnabled.Checked = Global.srsLocalRegistrySettings.GetBoolean(Resources.frmConfiguration_srsKeyWebServiceCheckEnable, Convert.ToBoolean(Resources.frmConfiguration_srsKeyWebServiceCheckEnable_DefaultValue));
            tbWebServiceUrl.Text = Global.srsLocalRegistrySettings.GetString(Resources.frmConfiguration_srsKeyWebServiceUrl, Resources.frmConfiguration_srsKeyWebServiceUrl_DefaultValue);

            var iWebServiceTimeout = Global.srsLocalRegistrySettings.GetInteger(Resources.frmConfiguration_srsKeyWebServiceTimeout, Convert.ToInt32(Resources.frmConfiguration_srsKeyWebServiceTimeout_DefaultValue));
            if (iWebServiceTimeout > 59)
                iWebServiceTimeout = 60;
            if (iWebServiceTimeout < 1)
                iWebServiceTimeout = 1;
            nudWebServiceTimeout.Value = iWebServiceTimeout;

            cbLogLevel.SelectedItem = Global.srsLocalRegistrySettings.GetString(Resources.frmConfiguration_srsKeyLogLevel, Resources.frmConfiguration_srsKeyLogLevel_DefaultValue);
            cbLogToConsole.Checked = Convert.ToBoolean(Global.srsLocalRegistrySettings.GetInteger(Resources.frmConfiguration_srsKeyLogToConsole, Convert.ToInt32(Convert.ToBoolean(Resources.frmConfiguration_srsKeyLogToConsole_DefaultValue))));
            cbVerboseLogging.Checked = Convert.ToBoolean(Global.srsLocalRegistrySettings.GetInteger(Resources.frmConfiguration_srsKeyVerboseLogging, Convert.ToInt32(Convert.ToBoolean(Resources.frmConfiguration_srsKeyVerboseLogging_DefaultValue))));
        }
        private void configurationSave()
        {
            Global.srsLocalRegistrySettings.SetInteger(Resources.frmConfiguration_srsKeyOScamStartDelay, Convert.ToInt32(nudOScamStartDelay.Value));
            Global.srsLocalRegistrySettings.SetString(Resources.frmConfiguration_srsKeyOScamBinaryTitle, tbOScamBinaryTitle.Text);
            Global.srsLocalRegistrySettings.SetString(Resources.frmConfiguration_srsKeyOScamBinaryFilename, tbOScamBinaryFilename.Text);
            Global.srsLocalRegistrySettings.SetString(Resources.frmConfiguration_srsKeyOScamBinaryFilepath, tbOScamBinaryFilepath.Text);
            Global.srsLocalRegistrySettings.SetInteger(Resources.frmConfiguration_srsKeyOScamCheckInterval, Convert.ToInt32(nudOScamCheckInterval.Value));
            Global.srsLocalRegistrySettings.SetString(Resources.frmConfiguration_srsKeyOScamAdditionalParameters, tbOScamAdditionalParameters.Text);
            Global.srsLocalRegistrySettings.SetBoolean(Resources.frmConfiguration_srsKeyWebServiceCheckEnable, Convert.ToBoolean(cbWebServiceEnabled.Checked));
            Global.srsLocalRegistrySettings.SetString(Resources.frmConfiguration_srsKeyWebServiceUrl, tbWebServiceUrl.Text);
            Global.srsLocalRegistrySettings.SetInteger(Resources.frmConfiguration_srsKeyWebServiceTimeout, Convert.ToInt32(nudWebServiceTimeout.Value));
            Global.srsLocalRegistrySettings.SetString(Resources.frmConfiguration_srsKeyLogLevel, Convert.ToString(cbLogLevel.SelectedItem));
            Global.srsLocalRegistrySettings.SetInteger(Resources.frmConfiguration_srsKeyLogToConsole, Convert.ToInt32(cbLogToConsole.Checked));
            Global.srsLocalRegistrySettings.SetInteger(Resources.frmConfiguration_srsKeyVerboseLogging, Convert.ToInt32(cbVerboseLogging.Checked));
        }
        private void configurationUIUpdate()
        {
            Text = Resources.Program_Name + string.Empty.Space() + Assembly.GetExecutingAssembly().GetName().Version + string.Empty.Space() + Resources.frmConfiguration_BaseTitle;
        }

        private void cbWebServiceEnabled_CheckedChanged(object sender, EventArgs e)
        {
            gbWebService.Enabled = cbWebServiceEnabled.Checked;
        }
    }
}