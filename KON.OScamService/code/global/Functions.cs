using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Versioning;
using System.Security.Principal;

using Microsoft.Win32;

using static System.String;

namespace KON.OScamService
{
    [SupportedOSPlatform("windows")]
	public static class Global
    {
        public static readonly WindowsEventLogger welCurrentWindowsEventLogger = new();
        private static RegistrySettings srsLocalRegistrySettings { get; } = new(Resources.OScamService_Service_Name, RegistrySettings.RegistryHive.HKLM);

        static Global() {
            welCurrentWindowsEventLogger.SetEventSource(Resources.OScamService_Service_Name, Resources.OScamService_Service_LogName);
        }

		public static bool IsAdministrator() {
            try {
                var wiCurrentWindowsIdentity = WindowsIdentity.GetCurrent();
                var wpCurrentWindowsPrincipal = new WindowsPrincipal(wiCurrentWindowsIdentity);

                return wpCurrentWindowsPrincipal.IsInRole(WindowsBuiltInRole.Administrator);
            }
            catch {
                return false;
            }
        }
        public static string GetExecutionPath() {
            return Path.GetDirectoryName(Extensions.GetExecutablePath())?.ToLower();
        }
        public static bool DoesOscamBinaryExist() {
            return File.Exists(GetExecutionPath() + @"\" + Resources.OScamService_BinaryFileName_OScam);
        }
        public static Version GetAssemblyVersion() {
            return Assembly.GetExecutingAssembly().GetName().Version;
        }
		public static string ReplaceExecutionPathWindowsToUnix() {
            return GetExecutionPath().Replace(@"\", @"/");
        }
        public static List<Process> GetAllOscam() {
            return Process.GetProcesses().Where(process => process.ProcessName.Equals(Resources.OScamService_BinaryFileTitle_OScam)).ToList();
        }
        public static int KillAllOscam() {
            foreach (var item in GetAllOscam()) {
                item.Kill(true);
            }

            return GetAllOscam().Count;
        }
        public static void StartOscam() {
            var strAdditionalStartupParameters = srsLocalRegistrySettings.GetString(Resources.frmConfiguration_srsKeyAdditionalStartupParameters, Resources.frmConfiguration_srsKeyAdditionalStartupParameters_DefaultValue);

            var strFilename = GetExecutionPath() + @"\" + Resources.OScamService_BinaryFileName_OScam;
            var strArguments = "-B" + Empty.Space() + "oscam.pid" + Empty.Space() + "-w" + Empty.Space() + "0" + Empty.Space() + "-c" + Empty.Space() + "'" + ReplaceExecutionPathWindowsToUnix() + "'" + Empty.Space() + "-t" + Empty.Space() + "'" + ReplaceExecutionPathWindowsToUnix() + "/temp'" + Empty.Space() + "-r" + Empty.Space() + "2" + Empty.Space() + strAdditionalStartupParameters;

            if (DoesOscamBinaryExist()) {
                welCurrentWindowsEventLogger.WriteEntry(Resources.OScamService_Global_Logging_StartOScam + Empty.Space() + strFilename + Empty.Space() + strArguments, 1000, WindowsEventLogger.LogType.Information);
                welCurrentWindowsEventLogger.WriteConsole(Resources.OScamService_Global_Logging_StartOScam + Empty.Space() + strFilename + Empty.Space() + strArguments, WindowsEventLogger.LogType.Information, false);
                Process.Start(new ProcessStartInfo(strFilename, strArguments) { UseShellExecute = false, RedirectStandardInput = true, WorkingDirectory = GetExecutionPath() });
            }
            else {
                welCurrentWindowsEventLogger.WriteEntry(Resources.OScamService_Global_Logging_StartOScam_Error + Empty.Space() + GetExecutionPath() + @"\" + Resources.OScamService_BinaryFileName_OScam, 1001, WindowsEventLogger.LogType.Error);
                welCurrentWindowsEventLogger.WriteConsole(Resources.OScamService_Global_Logging_StartOScam_Error + Empty.Space() + GetExecutionPath() + @"\" + Resources.OScamService_BinaryFileName_OScam, WindowsEventLogger.LogType.Error, false);
            }

        }
        public static int StopOscam() {
            var iOscamProcesses = GetAllOscam().Count;

            if (iOscamProcesses <= 0)
                return iOscamProcesses;

            welCurrentWindowsEventLogger.WriteEntry(iOscamProcesses + Empty.Space() + Resources.OScamService_Global_Logging_StopOScam, 1002, WindowsEventLogger.LogType.Information);
            welCurrentWindowsEventLogger.WriteConsole(iOscamProcesses + Empty.Space() + Resources.OScamService_Global_Logging_StopOScam, WindowsEventLogger.LogType.Information, false);
            iOscamProcesses = KillAllOscam();

            return iOscamProcesses;
        }
        public static void RestartOscam() {
            welCurrentWindowsEventLogger.WriteEntry(Resources.OScamService_Global_Logging_RestartOScam, 1002, WindowsEventLogger.LogType.Information);
            welCurrentWindowsEventLogger.WriteConsole(Resources.OScamService_Global_Logging_RestartOScam, WindowsEventLogger.LogType.Information, false);
            StopOscam();
            StartOscam();
        }
	}

    [SupportedOSPlatform("windows")]
	public class RegistrySettings(string srsLocalAppName, RegistrySettings.RegistryHive rhLocalRegistryHive)
    {
		public enum RegistryHive { HKCU, HKLM }

		private readonly string strRegistryPath = @"SOFTWARE\" + srsLocalAppName;
		private readonly RegistryKey rkRegistryKeyRootHive = rhLocalRegistryHive switch {
            RegistryHive.HKCU => Registry.CurrentUser,
            _ => Registry.LocalMachine
        };

        public void SetString(string strLocalName, string strLocalValue) {
            using var rkCurrentRegistryKey = rkRegistryKeyRootHive.CreateSubKey(strRegistryPath);
            
            if (rkCurrentRegistryKey == null) 
                return;
            
            rkCurrentRegistryKey.SetValue(strLocalName, strLocalValue, RegistryValueKind.String);
            rkCurrentRegistryKey.Close();
        }
		public string GetString(string strLocalName, string strLocalDefaultValue) {
			using var rkCurrentRegistryKey = rkRegistryKeyRootHive.OpenSubKey(strRegistryPath);

			try {
                if (rkCurrentRegistryKey == null || rkCurrentRegistryKey.GetValueKind(strLocalName) != RegistryValueKind.String)
                    return strLocalDefaultValue;

                return IsNullOrEmpty(Convert.ToString(rkCurrentRegistryKey.GetValue(strLocalName, strLocalDefaultValue))) ? strLocalDefaultValue : Convert.ToString(rkCurrentRegistryKey.GetValue(strLocalName, strLocalDefaultValue));
            }
			catch {
				return strLocalDefaultValue;
			}
		}

		public void SetInt(string strLocalName, int iLocalValue) {
			using var rkCurrentRegistryKey = rkRegistryKeyRootHive.CreateSubKey(strRegistryPath);
            
            if (rkCurrentRegistryKey == null)
                return;
            
            rkCurrentRegistryKey.SetValue(strLocalName, iLocalValue, RegistryValueKind.DWord);
            rkCurrentRegistryKey.Close();
        }
		public int GetInt(string strLocalName, int iLocalDefaultValue) {
			using var rkCurrentRegistryKey = rkRegistryKeyRootHive.OpenSubKey(strRegistryPath);

			try {
                if (rkCurrentRegistryKey == null || rkCurrentRegistryKey.GetValueKind(strLocalName) != RegistryValueKind.DWord)
                    return iLocalDefaultValue;

                return Convert.ToInt32(rkCurrentRegistryKey.GetValue(strLocalName, iLocalDefaultValue));
            }
			catch {
				return iLocalDefaultValue;
			}
		}

        public void SetBool(string strLocalName, bool bLocalValue)
        {
            using var rkCurrentRegistryKey = rkRegistryKeyRootHive.CreateSubKey(strRegistryPath);
            
            if (rkCurrentRegistryKey == null)
                return;

            rkCurrentRegistryKey.SetValue(strLocalName, bLocalValue, RegistryValueKind.DWord);
            rkCurrentRegistryKey.Close();
        }
        public bool GetBool(string strLocalName, bool bLocalDefaultValue)
        {
            using var rkCurrentRegistryKey = rkRegistryKeyRootHive.OpenSubKey(strRegistryPath);

            try
            {
                if (rkCurrentRegistryKey == null || rkCurrentRegistryKey.GetValueKind(strLocalName) != RegistryValueKind.DWord)
                    return bLocalDefaultValue;

                return Convert.ToBoolean(rkCurrentRegistryKey.GetValue(strLocalName, bLocalDefaultValue));
            }
            catch
            {
                return bLocalDefaultValue;
            }
        }
    }

    [SupportedOSPlatform("windows")]
	public class WindowsEventLogger
	{
        private RegistrySettings srsLocalRegistrySettings { get; } = new(Resources.OScamService_Service_Name, RegistrySettings.RegistryHive.HKLM);
        public enum LogType { Error = 1, Information = 4, Warning = 2 }
		
        private string strEventSource;
        
        public void SetEventSource(string strLocalEventSourceName, string strLocalLogName) {
            EstablishEventSource(strLocalEventSourceName, strLocalLogName);
            strEventSource = strLocalEventSourceName;
        }

		public void WriteEntry(string strLocalMessage, int intLocalID, LogType ltLocalLogType) {
			WriteWindowsEvent(strLocalMessage, intLocalID, ltLocalLogType);
		}
        public void WriteConsole(string strLocalMessage, LogType ltLocalLogType, bool bLocalMandatoryMessage) {
            var strLogLevel = srsLocalRegistrySettings.GetString(Resources.frmConfiguration_srsKeyLogLevel, Resources.frmConfiguration_srsKeyLogLevel_DefaultValue);
            var bLogToConsole = Convert.ToBoolean(srsLocalRegistrySettings.GetInt(Resources.frmConfiguration_srsKeyLogToConsole, Convert.ToInt32(Convert.ToBoolean(Resources.frmConfiguration_srsKeyLogToConsole_DefaultValue))));
            var bVerboseLogging = Convert.ToBoolean(srsLocalRegistrySettings.GetInt(Resources.frmConfiguration_srsKeyVerboseLogging, Convert.ToInt32(Convert.ToBoolean(Resources.frmConfiguration_srsKeyVerboseLogging_DefaultValue))));

            if (!bLogToConsole)
                return;

            if (bVerboseLogging || bLocalMandatoryMessage) {
                if (bLocalMandatoryMessage)
                    Console.WriteLine(@"[Mandatory]: " + strLocalMessage);
                else
                    Console.WriteLine(@"[Verbose]: " + strLocalMessage);
            }
            else {
                switch (strLogLevel) {
                    case "Information": {
                        Console.WriteLine(@"[" + (EventLogEntryType)ltLocalLogType + @"]: " + strLocalMessage);

                        break;
                    }
                    case "Warning": {
                        if (ltLocalLogType is LogType.Warning or LogType.Error)
                            Console.WriteLine(@"[" + (EventLogEntryType)ltLocalLogType + @"]: " + strLocalMessage);

                        break;
                    }
                    case "Error": {
                        if (ltLocalLogType is LogType.Error)
                            Console.WriteLine(@"[" + (EventLogEntryType)ltLocalLogType + @"]: " + strLocalMessage);

                        break;
                    }
                }
            }
        }

        private void WriteWindowsEvent(string strLocalMessage, int intLocalID, LogType ltLocalLogType) {
            var strLogLevel = srsLocalRegistrySettings.GetString(Resources.frmConfiguration_srsKeyLogLevel, Resources.frmConfiguration_srsKeyLogLevel_DefaultValue);
            var bVerboseLogging = Convert.ToBoolean(srsLocalRegistrySettings.GetInt(Resources.frmConfiguration_srsKeyVerboseLogging, Convert.ToInt32(Convert.ToBoolean(Resources.frmConfiguration_srsKeyVerboseLogging_DefaultValue))));

            if (bVerboseLogging)
                EventLog.WriteEntry(strEventSource, strLocalMessage, (EventLogEntryType)ltLocalLogType, intLocalID);
            else {
                switch (strLogLevel) {
                    case "Information": {
                        EventLog.WriteEntry(strEventSource, strLocalMessage, (EventLogEntryType)ltLocalLogType, intLocalID);

                        break;
                    }
                    case "Warning": {
                        if (ltLocalLogType is LogType.Warning or LogType.Error)
                            EventLog.WriteEntry(strEventSource, strLocalMessage, (EventLogEntryType)ltLocalLogType, intLocalID);

                        break;
                    }
                    case "Error": {
                        if (ltLocalLogType is LogType.Error)
                            EventLog.WriteEntry(strEventSource, strLocalMessage, (EventLogEntryType)ltLocalLogType, intLocalID);

                        break;
                    }
                }
            }
        }

        private static void EstablishEventSource(string strLocalEventSourceName, string strLocalLogName) {
            if (!EventLog.SourceExists(strLocalEventSourceName))
                EventLog.CreateEventSource(strLocalEventSourceName, strLocalLogName);
        }
	}
}