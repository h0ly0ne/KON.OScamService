using System;
using System.Runtime.Versioning;
using System.Windows.Forms;

using static System.String;

namespace KON.OScamService
{
    [SupportedOSPlatform("windows")]
    public partial class frmConfiguration : Form
    {
        private RegistrySettings srsLocalRegistrySettings { get; } = new(Resources.OScamService_Service_Name, RegistrySettings.RegistryHive.HKLM);

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
            var iDelayStart = srsLocalRegistrySettings.GetInt(Resources.frmConfiguration_srsKeyDelayStart, Convert.ToInt32(Resources.frmConfiguration_srsKeyDelayStart_DefaultValue));
            if (iDelayStart > 599)
                iDelayStart = 600;
            if (iDelayStart < 0)
                iDelayStart = 0;
            nudDelayStart.Value = iDelayStart;

            cbCheckEnable.Checked = srsLocalRegistrySettings.GetBool(Resources.frmConfiguration_srsKeyCheckEnable, Convert.ToBoolean(Resources.frmConfiguration_srsKeyCheckEnable_DefaultValue));

            var iCheckInterval = srsLocalRegistrySettings.GetInt(Resources.frmConfiguration_srsKeyCheckInterval, Convert.ToInt32(Resources.frmConfiguration_srsKeyCheckInterval_DefaultValue));
            if (iCheckInterval > 60)
                iCheckInterval = 60;
            if (iCheckInterval < 1)
                iCheckInterval = 1;
            nudCheckInterval.Value = iCheckInterval;

            txtWebServiceUrl.Text = srsLocalRegistrySettings.GetString(Resources.frmConfiguration_srsKeyWebServiceUrl, Resources.frmConfiguration_srsKeyWebServiceUrl_DefaultValue);

            var iWebServiceTimeout = srsLocalRegistrySettings.GetInt(Resources.frmConfiguration_srsKeyWebServiceTimeout, Convert.ToInt32(Resources.frmConfiguration_srsKeyWebServiceTimeout_DefaultValue));
            if (iWebServiceTimeout > 60)
                iWebServiceTimeout = 60;
            if (iWebServiceTimeout < 1)
                iWebServiceTimeout = 1;
            nudWebServiceTimeout.Value = iWebServiceTimeout;

            cbLogLevel.SelectedItem = srsLocalRegistrySettings.GetString(Resources.frmConfiguration_srsKeyLogLevel, Resources.frmConfiguration_srsKeyLogLevel_DefaultValue);
            txtAdditionalStartupParameters.Text = srsLocalRegistrySettings.GetString(Resources.frmConfiguration_srsKeyAdditionalStartupParameters, Resources.frmConfiguration_srsKeyAdditionalStartupParameters_DefaultValue);
            cbLogToConsole.Checked = Convert.ToBoolean(srsLocalRegistrySettings.GetInt(Resources.frmConfiguration_srsKeyLogToConsole, Convert.ToInt32(Convert.ToBoolean(Resources.frmConfiguration_srsKeyLogToConsole_DefaultValue))));
            cbVerboseLogging.Checked = Convert.ToBoolean(srsLocalRegistrySettings.GetInt(Resources.frmConfiguration_srsKeyVerboseLogging, Convert.ToInt32(Convert.ToBoolean(Resources.frmConfiguration_srsKeyVerboseLogging_DefaultValue))));
        }
        private void configurationSave() {
            srsLocalRegistrySettings.SetInt(Resources.frmConfiguration_srsKeyDelayStart, Convert.ToInt32(nudDelayStart.Value));
            srsLocalRegistrySettings.SetBool(Resources.frmConfiguration_srsKeyCheckEnable, Convert.ToBoolean(cbCheckEnable.Checked));
            srsLocalRegistrySettings.SetInt(Resources.frmConfiguration_srsKeyCheckInterval, Convert.ToInt32(nudCheckInterval.Value));
            srsLocalRegistrySettings.SetString(Resources.frmConfiguration_srsKeyWebServiceUrl, txtWebServiceUrl.Text);
            srsLocalRegistrySettings.SetInt(Resources.frmConfiguration_srsKeyWebServiceTimeout, Convert.ToInt32(nudWebServiceTimeout.Value));
            srsLocalRegistrySettings.SetString(Resources.frmConfiguration_srsKeyLogLevel, Convert.ToString(cbLogLevel.SelectedItem));
            srsLocalRegistrySettings.SetString(Resources.frmConfiguration_srsKeyAdditionalStartupParameters, txtAdditionalStartupParameters.Text);
            srsLocalRegistrySettings.SetInt(Resources.frmConfiguration_srsKeyLogToConsole, Convert.ToInt32(cbLogToConsole.Checked));
            srsLocalRegistrySettings.SetInt(Resources.frmConfiguration_srsKeyVerboseLogging, Convert.ToInt32(cbVerboseLogging.Checked));
        }
        private void configurationUIUpdate() {
            Text = Resources.OScamService_Service_Name + Empty.Space() + Global.GetAssemblyVersion() + Empty.Space() + Resources.frmConfiguration_BaseTitle;
        }
    }
}