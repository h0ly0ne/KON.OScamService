using System;
using System.Net;
using System.Net.Http;
using System.Runtime.Versioning;
using System.Threading;

namespace KON.OScamService
{
    [SupportedOSPlatform("windows")]
    public class Service
    {
        private RegistrySettings srsLocalRegistrySettings { get; } = new(Resources.OScamService_Service_Name, RegistrySettings.RegistryHive.HKLM);
        private Timer tLocalCheckTimer;
        private static HttpClientHandler hcLocalHttpClientHandler = new() { ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator };
        private HttpClient hcLocalHttpClient = new(hcLocalHttpClientHandler);

        public void RunAsConsole(string[] args) {
            Start();
            Global.welCurrentWindowsEventLogger.WriteConsole(Resources.OScamService_Service_RunAsConsole, WindowsEventLogger.LogType.Information, true);
            Console.ReadLine();
            Stop();
        }

        public void Start() {
            var iDelayStart = srsLocalRegistrySettings.GetInt(Resources.frmConfiguration_srsKeyDelayStart, Convert.ToInt32(Resources.frmConfiguration_srsKeyDelayStart_DefaultValue));
            var iWebServiceTimeout = srsLocalRegistrySettings.GetInt(Resources.frmConfiguration_srsKeyWebServiceTimeout, Convert.ToInt32(Resources.frmConfiguration_srsKeyWebServiceTimeout_DefaultValue));

            if (iDelayStart > 0) {
                Global.welCurrentWindowsEventLogger.WriteEntry(Resources.OScamService_Service_StartDelayed, 3000, WindowsEventLogger.LogType.Information);
                Global.welCurrentWindowsEventLogger.WriteConsole(Resources.OScamService_Service_StartDelayed, WindowsEventLogger.LogType.Information, false);

                Thread.Sleep(iDelayStart * 1000);
            }

            Global.StartOscam();
            hcLocalHttpClient.Timeout = TimeSpan.FromSeconds(Convert.ToInt32(iWebServiceTimeout));

            try {
                tLocalCheckTimer = new Timer(TimerCallback, null, TimeSpan.Zero, TimeSpan.FromSeconds(Convert.ToInt32(srsLocalRegistrySettings.GetInt(Resources.frmConfiguration_srsKeyCheckInterval, Convert.ToInt32(Resources.frmConfiguration_srsKeyCheckInterval_DefaultValue)))));
            }
            catch {
                Global.welCurrentWindowsEventLogger.WriteEntry(Resources.OScamService_Service_StartFailed, 3001, WindowsEventLogger.LogType.Error);
                Global.welCurrentWindowsEventLogger.WriteConsole(Resources.OScamService_Service_StartFailed, WindowsEventLogger.LogType.Error, false);
                Stop();
            }
        }
        public void Stop() {
            tLocalCheckTimer?.Dispose();

            Global.StopOscam();
        }

        private void TimerCallback(object oLocalState) {
            var bCheckEnable = srsLocalRegistrySettings.GetBool(Resources.frmConfiguration_srsKeyCheckEnable, Convert.ToBoolean(Resources.frmConfiguration_srsKeyCheckEnable_DefaultValue));

            if (bCheckEnable) {
                CheckOscam();
            }
        }

        private void CheckOscam() {
            if (Global.GetAllOscam().Count < 1) {
                Global.welCurrentWindowsEventLogger.WriteEntry(Resources.OScamService_OScam_Restart_Required, 3006, WindowsEventLogger.LogType.Warning);
                Global.welCurrentWindowsEventLogger.WriteConsole(Resources.OScamService_OScam_Restart_Required, WindowsEventLogger.LogType.Warning, false);

                Global.RestartOscam();
            }
            else {
                var strWebServiceUrl = srsLocalRegistrySettings.GetString(Resources.frmConfiguration_srsKeyWebServiceUrl, Resources.frmConfiguration_srsKeyWebServiceUrl_DefaultValue);

                try {
                    using var hrmCurrentHttpResponseMessage = hcLocalHttpClient.GetAsync(strWebServiceUrl, HttpCompletionOption.ResponseHeadersRead).Result;

                    Global.welCurrentWindowsEventLogger.WriteEntry(Convert.ToString(hrmCurrentHttpResponseMessage.StatusCode), 3007, WindowsEventLogger.LogType.Information);
                    Global.welCurrentWindowsEventLogger.WriteConsole(Convert.ToString(hrmCurrentHttpResponseMessage.StatusCode), WindowsEventLogger.LogType.Information, false);

                    if (hrmCurrentHttpResponseMessage.StatusCode != HttpStatusCode.OK) {
                        Global.welCurrentWindowsEventLogger.WriteEntry(Resources.OScamService_OScam_Restart_Required, 3008, WindowsEventLogger.LogType.Warning);
                        Global.welCurrentWindowsEventLogger.WriteConsole(Resources.OScamService_OScam_Restart_Required, WindowsEventLogger.LogType.Warning, false);

                        Global.RestartOscam();
                    }
                    else {
                        Global.welCurrentWindowsEventLogger.WriteEntry(Resources.OScamService_OScam_Restart_NotRequired, 3009, WindowsEventLogger.LogType.Information);
                        Global.welCurrentWindowsEventLogger.WriteConsole(Resources.OScamService_OScam_Restart_NotRequired, WindowsEventLogger.LogType.Information, false);
                    }
                }
                catch (Exception excCurrentException) {
                    Global.welCurrentWindowsEventLogger.WriteEntry(excCurrentException.Message, 3010, WindowsEventLogger.LogType.Error);
                    Global.welCurrentWindowsEventLogger.WriteConsole(excCurrentException.Message, WindowsEventLogger.LogType.Error, false);

                    Global.welCurrentWindowsEventLogger.WriteEntry(Resources.OScamService_OScam_Restart_Required, 3011, WindowsEventLogger.LogType.Warning);
                    Global.welCurrentWindowsEventLogger.WriteConsole(Resources.OScamService_OScam_Restart_Required, WindowsEventLogger.LogType.Warning, false);

                    Global.RestartOscam();
                }
            }
        }
    }
}