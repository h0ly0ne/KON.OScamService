using System;
using System.Reflection;
using System.Runtime.Versioning;
using System.Windows.Forms;

namespace KON.OScamService {
    [SupportedOSPlatform("windows")]
    public partial class frmConfiguration : Form
    {
        public frmConfiguration() {
            InitializeComponent();
        }
        private void Configuration_Load(object sender, EventArgs e) {
            configurationLoad();
            configurationUIUpdate();
        }
        private void btnSave_Click(object sender, EventArgs e) {
            if (btnSave.Text == Resources.frmConfiguration_btnSave_Text) {
                configurationSave();
                DialogResult = DialogResult.OK;
            }
            else
                DialogResult = DialogResult.Abort;

            Close();
        }

        private void configurationLoad() {
            var iDelayStart = Global.srsLocalRegistrySettings.GetInteger(Resources.frmConfiguration_srsKeyStartDelay, Convert.ToInt32(Resources.frmConfiguration_srsKeyStartDelay_DefaultValue));
            if (iDelayStart > 599)
                iDelayStart = 600;
            if (iDelayStart < 0)
                iDelayStart = 0;
            nudDelayStart.Value = iDelayStart;

            cbWebServiceCheckEnable.Checked = Global.srsLocalRegistrySettings.GetBoolean(Resources.frmConfiguration_srsKeyWebServiceCheckEnable, Convert.ToBoolean(Resources.frmConfiguration_srsKeyWebServiceCheckEnable_DefaultValue));

            var iCheckInterval = Global.srsLocalRegistrySettings.GetInteger(Resources.frmConfiguration_srsKeyCheckInterval, Convert.ToInt32(Resources.frmConfiguration_srsKeyCheckInterval_DefaultValue));
            if (iCheckInterval > 59)
                iCheckInterval = 60;
            if (iCheckInterval < 1)
                iCheckInterval = 1;
            nudCheckInterval.Value = iCheckInterval;

            tbOScamBinaryTitle.Text = Global.srsLocalRegistrySettings.GetString(Resources.frmConfiguration_srsKeyOScam_BinaryTitle, Resources.frmConfiguration_srsKeyOScam_BinaryTitle_DefaultValue);
            tbOScamBinaryFilename.Text = Global.srsLocalRegistrySettings.GetString(Resources.frmConfiguration_srsKeyOScam_BinaryFilename, Resources.frmConfiguration_srsKeyOScam_BinaryFilename_DefaultValue);
            tbOScamBinaryFilepath.Text = Global.srsLocalRegistrySettings.GetString(Resources.frmConfiguration_srsKeyOScam_BinaryFilepath, Resources.frmConfiguration_srsKeyOScam_BinaryFilepath_DefaultValue);
            tbWebServiceUrl.Text = Global.srsLocalRegistrySettings.GetString(Resources.frmConfiguration_srsKeyWebServiceUrl, Resources.frmConfiguration_srsKeyWebServiceUrl_DefaultValue);

            var iWebServiceTimeout = Global.srsLocalRegistrySettings.GetInteger(Resources.frmConfiguration_srsKeyWebServiceTimeout, Convert.ToInt32(Resources.frmConfiguration_srsKeyWebServiceTimeout_DefaultValue));
            if (iWebServiceTimeout > 59)
                iWebServiceTimeout = 60;
            if (iWebServiceTimeout < 1)
                iWebServiceTimeout = 1;
            nudWebServiceTimeout.Value = iWebServiceTimeout;

            cbLogLevel.SelectedItem = Global.srsLocalRegistrySettings.GetString(Resources.frmConfiguration_srsKeyLogLevel, Resources.frmConfiguration_srsKeyLogLevel_DefaultValue);
            tbAdditionalStartupParameters.Text = Global.srsLocalRegistrySettings.GetString(Resources.frmConfiguration_srsKeyAdditionalStartupParameters, Resources.frmConfiguration_srsKeyAdditionalStartupParameters_DefaultValue);
            cbLogToConsole.Checked = Convert.ToBoolean(Global.srsLocalRegistrySettings.GetInteger(Resources.frmConfiguration_srsKeyLogToConsole, Convert.ToInt32(Convert.ToBoolean(Resources.frmConfiguration_srsKeyLogToConsole_DefaultValue))));
            cbVerboseLogging.Checked = Convert.ToBoolean(Global.srsLocalRegistrySettings.GetInteger(Resources.frmConfiguration_srsKeyVerboseLogging, Convert.ToInt32(Convert.ToBoolean(Resources.frmConfiguration_srsKeyVerboseLogging_DefaultValue))));
        }
        private void configurationSave() {
            Global.srsLocalRegistrySettings.SetInteger(Resources.frmConfiguration_srsKeyStartDelay, Convert.ToInt32(nudDelayStart.Value));
            Global.srsLocalRegistrySettings.SetBoolean(Resources.frmConfiguration_srsKeyWebServiceCheckEnable, Convert.ToBoolean(cbWebServiceCheckEnable.Checked));
            Global.srsLocalRegistrySettings.SetInteger(Resources.frmConfiguration_srsKeyCheckInterval, Convert.ToInt32(nudCheckInterval.Value));
            Global.srsLocalRegistrySettings.SetString(Resources.frmConfiguration_srsKeyOScam_BinaryTitle, tbOScamBinaryTitle.Text);
            Global.srsLocalRegistrySettings.SetString(Resources.frmConfiguration_srsKeyOScam_BinaryFilename, tbOScamBinaryFilename.Text);
            Global.srsLocalRegistrySettings.SetString(Resources.frmConfiguration_srsKeyOScam_BinaryFilepath, tbOScamBinaryFilepath.Text);
            Global.srsLocalRegistrySettings.SetString(Resources.frmConfiguration_srsKeyWebServiceUrl, tbWebServiceUrl.Text);
            Global.srsLocalRegistrySettings.SetInteger(Resources.frmConfiguration_srsKeyWebServiceTimeout, Convert.ToInt32(nudWebServiceTimeout.Value));
            Global.srsLocalRegistrySettings.SetString(Resources.frmConfiguration_srsKeyLogLevel, Convert.ToString(cbLogLevel.SelectedItem));
            Global.srsLocalRegistrySettings.SetString(Resources.frmConfiguration_srsKeyAdditionalStartupParameters, tbAdditionalStartupParameters.Text);
            Global.srsLocalRegistrySettings.SetInteger(Resources.frmConfiguration_srsKeyLogToConsole, Convert.ToInt32(cbLogToConsole.Checked));
            Global.srsLocalRegistrySettings.SetInteger(Resources.frmConfiguration_srsKeyVerboseLogging, Convert.ToInt32(cbVerboseLogging.Checked));
        }
        private void configurationUIUpdate() {
            Text = Resources.Program_Name + string.Empty.Space() + Assembly.GetExecutingAssembly().GetName().Version + string.Empty.Space() + Resources.frmConfiguration_BaseTitle;
        }
    }
}