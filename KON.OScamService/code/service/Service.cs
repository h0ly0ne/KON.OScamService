using System;
using System.Net;
using System.Net.Http;
using System.Runtime.Versioning;
using System.Threading;

namespace KON.OScamService {
    [SupportedOSPlatform("windows")]
    internal class Service {
        private Timer tLocalCheckTimer;

        private static readonly HttpClientHandler hcLocalHttpClientHandler = new() { ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator, UseCookies = false };
        private static HttpClient hcLocalHttpClient = new(hcLocalHttpClientHandler);

        internal void RunAsConsole(string[] args) {
            Start();
            Global.welCurrentWindowsEventLogger.WriteEntry(Resources.Program_RunAsConsole, 0, WindowsEventLogger.LogType.Information, true);
            Console.ReadLine();
            Stop();
        }

        internal void Start() {
            var iStartDelay = Global.srsLocalRegistrySettings.GetInteger(Resources.frmConfiguration_srsKeyOScamStartDelay, Convert.ToInt32(Resources.frmConfiguration_srsKeyOScamStartDelay_DefaultValue));

            if (iStartDelay > 0) {
                Global.welCurrentWindowsEventLogger.WriteEntry(Resources.OScam_StartDelayed, 0, WindowsEventLogger.LogType.Information, false);
                Thread.Sleep(iStartDelay * 1000);
            }

            Global.StopOScam();
            Global.StartOScam();

            try {
                hcLocalHttpClient.Timeout = TimeSpan.FromSeconds(Convert.ToInt32(Global.srsLocalRegistrySettings.GetInteger(Resources.frmConfiguration_srsKeyWebServiceTimeout, Convert.ToInt32(Resources.frmConfiguration_srsKeyWebServiceTimeout_DefaultValue))));
                tLocalCheckTimer = new Timer(TimerCallback, null, TimeSpan.Zero, TimeSpan.FromSeconds(Convert.ToInt32(Global.srsLocalRegistrySettings.GetInteger(Resources.frmConfiguration_srsKeyOScamCheckInterval, Convert.ToInt32(Resources.frmConfiguration_srsKeyOScamCheckInterval_DefaultValue)))));
            }
            catch {
                Stop();
            }
        }
        internal void Stop() {
            tLocalCheckTimer?.Dispose();
            Global.StopOScam();
        }

        private static void TimerCallback(object oLocalState) {
            CheckOScam();
        }

        private static void CheckOScam() {
            if (Global.srsLocalRegistrySettings.GetBoolean(Resources.frmConfiguration_srsKeyWebServiceCheckEnable, Convert.ToBoolean(Resources.frmConfiguration_srsKeyWebServiceCheckEnable_DefaultValue))) {
                var strWebServiceUrl = Global.srsLocalRegistrySettings.GetString(Resources.frmConfiguration_srsKeyWebServiceUrl, Resources.frmConfiguration_srsKeyWebServiceUrl_DefaultValue);

                try {
                    using var hrmCurrentHttpResponseMessage = hcLocalHttpClient.GetAsync(strWebServiceUrl, HttpCompletionOption.ResponseHeadersRead).Result;
                    Global.welCurrentWindowsEventLogger.WriteEntry(Convert.ToString(hrmCurrentHttpResponseMessage.StatusCode), 0, WindowsEventLogger.LogType.Information, false);

                    if (hrmCurrentHttpResponseMessage.StatusCode != HttpStatusCode.OK) {
                        Global.welCurrentWindowsEventLogger.WriteEntry(Resources.OScam_Restart_Required, 0, WindowsEventLogger.LogType.Warning, false);
                        Global.welCurrentWindowsEventLogger.WriteEntry(Convert.ToString(hrmCurrentHttpResponseMessage.StatusCode), 0, WindowsEventLogger.LogType.Warning, false);
                        Global.RestartOScam();
                    }
                    else
                        Global.welCurrentWindowsEventLogger.WriteEntry(Resources.OScam_Restart_NotRequired, 0, WindowsEventLogger.LogType.Information, false);

                    Global.welCurrentWindowsEventLogger.WriteEntry(Resources.OScam_ResponseDisposed, 0, WindowsEventLogger.LogType.Information, false);
                }
                catch (Exception excCurrentException) {
                    Global.welCurrentWindowsEventLogger.WriteEntry(Resources.OScam_RequestTimedOut, 0, WindowsEventLogger.LogType.Warning, false);
                    Global.welCurrentWindowsEventLogger.WriteEntry(excCurrentException.Message, 0, WindowsEventLogger.LogType.Error, false);
                    Global.welCurrentWindowsEventLogger.WriteEntry(Resources.OScam_Restart_Required, 0, WindowsEventLogger.LogType.Warning, false);
                    Global.RestartOScam();
                }

                Global.welCurrentWindowsEventLogger.WriteEntry(Resources.OScam_RequestDisposed, 0, WindowsEventLogger.LogType.Information, false);
            }

            if (Global.GetAllOScamProcesses().Count == 2)
                return;
                
            Thread.Sleep(1000);
            if (Global.GetAllOScamProcesses().Count == 2)
                return;

            Global.welCurrentWindowsEventLogger.WriteEntry(Resources.OScam_Restart_Required, 0, WindowsEventLogger.LogType.Warning, false);
            Global.RestartOScam();
        }
    }
}