using System;
using System.Diagnostics;
using System.Runtime.Versioning;
using System.Windows.Forms;

using Topshelf;

using static System.String;

namespace KON.OScamService
{
    [SupportedOSPlatform("windows")]
    internal static class Program
	{
        public static string strServiceName = Resources.OScamService_Service_Name;

        private static void Main(string[] args) {
            if (Environment.UserInteractive) {
                var strArguments = Concat(args);

                if (!Global.IsAdministrator())
                    MessageBox.Show(Resources.OScamService_Service_AdministratorRequired, strServiceName, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                switch (strArguments) {
            	    case "install": {
                        InstallService();
            		    break;
            		}
                    case "uninstall": {
                        UnInstallService();
                        break;
                    }
                    case "console": {
                        var osCurrentOscamSVC = new Service();
                        osCurrentOscamSVC.RunAsConsole(args);
                        break;
                    }
                    default: {
                        var oscCurrentOscamSVCConfig = new frmConfiguration();
                        oscCurrentOscamSVCConfig.ShowDialog();
                        break;
                    }
                }
            }
            else
                Environment.ExitCode = ServiceFactory();
        }

        public static void InstallService() {
            try {
                Global.welCurrentWindowsEventLogger.WriteEntry(Resources.OScamService_Console_UnInstalling + Empty.Space() + Process.GetCurrentProcess().MainModule.FileName, 2000, WindowsEventLogger.LogType.Information);
                Global.welCurrentWindowsEventLogger.WriteConsole(Resources.OScamService_Console_UnInstalling + Empty.Space() + Process.GetCurrentProcess().MainModule.FileName, WindowsEventLogger.LogType.Information, true);
                Environment.ExitCode = ServiceFactory();
            }
            catch (Exception excCurrentException) {
                Global.welCurrentWindowsEventLogger.WriteEntry(Resources.OScamService_Console_UnInstalling_Error + Empty.Space() + excCurrentException.Message, 2000, WindowsEventLogger.LogType.Error);
                Global.welCurrentWindowsEventLogger.WriteConsole(Resources.OScamService_Console_UnInstalling_Error + Empty.Space() + excCurrentException.Message, WindowsEventLogger.LogType.Error, true);
            }
        }
		public static void UnInstallService() {
            try {
                Global.welCurrentWindowsEventLogger.WriteEntry(Resources.OScamService_Console_UnInstalling + Empty.Space() + Process.GetCurrentProcess().MainModule.FileName, 2001, WindowsEventLogger.LogType.Information);
                Global.welCurrentWindowsEventLogger.WriteConsole(Resources.OScamService_Console_UnInstalling + Empty.Space() + Process.GetCurrentProcess().MainModule.FileName, WindowsEventLogger.LogType.Information, true);
                Environment.ExitCode = ServiceFactory();
            }
            catch (Exception excCurrentException) {
                Global.welCurrentWindowsEventLogger.WriteEntry(Resources.OScamService_Console_UnInstalling_Error + Empty.Space() + excCurrentException.Message, 2000, WindowsEventLogger.LogType.Error);
                Global.welCurrentWindowsEventLogger.WriteConsole(Resources.OScamService_Console_UnInstalling_Error + Empty.Space() + excCurrentException.Message, WindowsEventLogger.LogType.Error, true);
            }
        }

        public static int ServiceFactory() {
            var tecCurrentTopshelfExitCode = HostFactory.Run(hcCurrentHostConfigurator => {
                hcCurrentHostConfigurator.Service<Service>(scCurrentServiceConfigurator => { scCurrentServiceConfigurator.ConstructUsing(_ => new Service()); scCurrentServiceConfigurator.WhenStarted(sfCurrentServiceFactory => sfCurrentServiceFactory.Start()); scCurrentServiceConfigurator.WhenStopped(sfCurrentServiceFactory => sfCurrentServiceFactory.Stop()); });
                hcCurrentHostConfigurator.RunAsLocalSystem();
                hcCurrentHostConfigurator.StartAutomatically();
                hcCurrentHostConfigurator.EnableServiceRecovery(srcCurrentServiceRecoveryConfiguration => { srcCurrentServiceRecoveryConfiguration.RestartService(1); });
                hcCurrentHostConfigurator.SetServiceName(strServiceName);
                hcCurrentHostConfigurator.SetDisplayName(strServiceName);
                hcCurrentHostConfigurator.SetDescription(strServiceName);
            });

            return (int)Convert.ChangeType(tecCurrentTopshelfExitCode, tecCurrentTopshelfExitCode.GetTypeCode());
        }
    }
}