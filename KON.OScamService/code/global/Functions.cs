using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Security.Principal;

using Microsoft.Win32;

namespace KON.OScamService {
    [SupportedOSPlatform("windows")]
	internal static class Global {
        [DllImport("user32.dll")]
        internal static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        [DllImport("kernel32.dll")]
        internal static extern IntPtr GetConsoleWindow();

        internal static readonly WindowsEventLogger welCurrentWindowsEventLogger = new();
        internal static readonly RegistrySettings srsLocalRegistrySettings = new(Resources.Program_Name, RegistrySettings.RegistryHive.HKLM);

        static Global() {
            welCurrentWindowsEventLogger.SetEventSource(Resources.Program_Name, Resources.Program_LogName);
        }

        internal static bool IsAdministrator() {
            try {
                return new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
            }
            catch {
                return false;
            }
        }

        private static string GetExecutionPath() {
            return srsLocalRegistrySettings.GetString(Resources.frmConfiguration_srsKeyOScamBinaryFilepath, Resources.frmConfiguration_srsKeyOScamBinaryFilepath_DefaultValue)?.ToLower();
        }

        private static string ReplaceExecutionPathWindowsToUnix()
        {
            return GetExecutionPath()?.Replace(@"\", @"/");
        }

        private static bool DoesOScamBinaryExist(string strLocalFilepath) {
            return File.Exists(strLocalFilepath);
        }

        internal static List<Process> GetAllOScamProcesses() {
            return Process.GetProcesses().Where(process => process.ProcessName.Equals(srsLocalRegistrySettings.GetString(Resources.frmConfiguration_srsKeyOScamBinaryTitle, Resources.frmConfiguration_srsKeyOScamBinaryTitle_DefaultValue))).ToList();
        }

        private static void KillAllOScamProcesses() {
            GetAllOScamProcesses()?.ToList().ForEach(delegate (Process pCurrentProcess) { pCurrentProcess.Kill(); pCurrentProcess.WaitForExit(); pCurrentProcess.Dispose(); });
        }

        internal static void StartOScam() {
            var strOScamFilepath = GetExecutionPath() + @"\" + srsLocalRegistrySettings.GetString(Resources.frmConfiguration_srsKeyOScamBinaryFilename, Resources.frmConfiguration_srsKeyOScamBinaryFilename_DefaultValue);
            var strArguments = "-B" + string.Empty.Space() + "oscam.pid" + string.Empty.Space() + "-w" + string.Empty.Space() + "0" + string.Empty.Space() + "-c" + string.Empty.Space() + "'" + ReplaceExecutionPathWindowsToUnix() + "'" + string.Empty.Space() + "-t" + string.Empty.Space() + "'" + ReplaceExecutionPathWindowsToUnix() + "/temp'" + string.Empty.Space() + "-r" + string.Empty.Space() + "2" + string.Empty.Space() + srsLocalRegistrySettings.GetString(Resources.frmConfiguration_srsKeyOScamAdditionalParameters, Resources.frmConfiguration_srsKeyOScamAdditionalParameters_DefaultValue);

            if (DoesOScamBinaryExist(strOScamFilepath)) {
                welCurrentWindowsEventLogger.WriteEntry(Resources.OScam_StartOScam + string.Empty.Space() + strOScamFilepath + string.Empty.Space() + strArguments, 0, WindowsEventLogger.LogType.Information, false);
                Process.Start(new ProcessStartInfo(strOScamFilepath, strArguments) { UseShellExecute = false, RedirectStandardInput = true, WorkingDirectory = GetExecutionPath() });
            }
            else
                welCurrentWindowsEventLogger.WriteEntry(Resources.OScam_StartOScam_Error + string.Empty.Space() + strOScamFilepath, 0, WindowsEventLogger.LogType.Error, false);

        }

        internal static void StopOScam() {
            if (GetAllOScamProcesses()?.Count <= 0)
                return;

            KillAllOScamProcesses();
            welCurrentWindowsEventLogger.WriteEntry(Resources.OScam_StopOScam, 0, WindowsEventLogger.LogType.Information, false);
        }

        internal static void RestartOScam() {
            StopOScam();
            StartOScam();
            welCurrentWindowsEventLogger.WriteEntry(Resources.OScam_RestartOScam, 0, WindowsEventLogger.LogType.Information, false);
        }
	}

    [SupportedOSPlatform("windows")]
    internal class RegistrySettings(string srsLocalAppName, RegistrySettings.RegistryHive rhLocalRegistryHive) {
        internal enum RegistryHive { HKCU, HKLM }

        private readonly string strRegistryPath = @"SOFTWARE\" + srsLocalAppName;
        private readonly RegistryKey rkRegistryKeyRootHive = rhLocalRegistryHive switch { RegistryHive.HKCU => Registry.CurrentUser, _ => Registry.LocalMachine };

        internal void SetString(string strLocalName, string strLocalValue) {
            using var rkCurrentRegistryKey = rkRegistryKeyRootHive.CreateSubKey(strRegistryPath);

            if (rkCurrentRegistryKey == null)
                return;

            rkCurrentRegistryKey.SetValue(strLocalName, strLocalValue, RegistryValueKind.String);
            rkCurrentRegistryKey.Close();
        }

        internal string GetString(string strLocalName, string strLocalValue) {
            using var rkCurrentRegistryKey = rkRegistryKeyRootHive.OpenSubKey(strRegistryPath);

            try {
                if (rkCurrentRegistryKey == null || rkCurrentRegistryKey.GetValueKind(strLocalName) != RegistryValueKind.String || string.IsNullOrEmpty(Convert.ToString(rkCurrentRegistryKey.GetValue(strLocalName, strLocalValue))))
                    return strLocalValue;

                return Convert.ToString(rkCurrentRegistryKey.GetValue(strLocalName, strLocalValue));
            }
            catch {
                return strLocalValue;
            }
        }

        internal void SetInteger(string strLocalName, int iLocalValue) {
            using var rkCurrentRegistryKey = rkRegistryKeyRootHive.CreateSubKey(strRegistryPath);

            if (rkCurrentRegistryKey == null)
                return;

            rkCurrentRegistryKey.SetValue(strLocalName, iLocalValue, RegistryValueKind.DWord);
            rkCurrentRegistryKey.Close();
        }

        internal int GetInteger(string strLocalName, int iDefaultValue) {
            using var rkCurrentRegistryKey = rkRegistryKeyRootHive.OpenSubKey(strRegistryPath);

            try {
                if (rkCurrentRegistryKey == null || rkCurrentRegistryKey.GetValueKind(strLocalName) != RegistryValueKind.DWord)
                    return iDefaultValue;

                return Convert.ToInt32(rkCurrentRegistryKey.GetValue(strLocalName, iDefaultValue));
            }
            catch {
                return iDefaultValue;
            }
        }

        internal void SetBoolean(string strLocalName, bool bLocalValue) {
            using var rkCurrentRegistryKey = rkRegistryKeyRootHive.CreateSubKey(strRegistryPath);

            if (rkCurrentRegistryKey == null)
                return;

            rkCurrentRegistryKey.SetValue(strLocalName, Convert.ToInt32(bLocalValue), RegistryValueKind.DWord);
            rkCurrentRegistryKey.Close();
        }

        internal bool GetBoolean(string strLocalName, bool bLocalValue) {
            using var rkCurrentRegistryKey = rkRegistryKeyRootHive.OpenSubKey(strRegistryPath);

            try {
                if (rkCurrentRegistryKey == null || rkCurrentRegistryKey.GetValueKind(strLocalName) != RegistryValueKind.DWord)
                    return bLocalValue;

                return Convert.ToBoolean(rkCurrentRegistryKey.GetValue(strLocalName, Convert.ToInt32(bLocalValue)));
            }
            catch {
                return bLocalValue;
            }
        }
    }

    [SupportedOSPlatform("windows")]
    internal class WindowsEventLogger {
        internal enum LogType { Error = 1, Information = 4, Warning = 2 }
        private string strEventSource;

        internal void SetEventSource(string strLocalEventSourceName, string strLocalLogName) {
            if (Global.IsAdministrator()) {
                EstablishEventSource(strLocalEventSourceName, strLocalLogName);
                strEventSource = strLocalEventSourceName;
            }
            else {
                strEventSource = "Application";
            }
        }

        internal void WriteEntry(string strLocalMessage, int intLocalID, LogType ltLocalLogType, bool bLocalMandatory) {
            WriteWindowsEvent(strLocalMessage, intLocalID, ltLocalLogType);
            WriteConsole(strLocalMessage, ltLocalLogType, bLocalMandatory);
        }

        private static void WriteConsole(string strLocalMessage, LogType ltLocalLogType, bool bLocalMandatoryMessage) {
            if (!Convert.ToBoolean(Global.srsLocalRegistrySettings.GetInteger(Resources.frmConfiguration_srsKeyLogToConsole, Convert.ToInt32(Convert.ToBoolean(Resources.frmConfiguration_srsKeyLogToConsole_DefaultValue)))))
                return;

            if (bLocalMandatoryMessage || Convert.ToBoolean(Global.srsLocalRegistrySettings.GetInteger(Resources.frmConfiguration_srsKeyVerboseLogging, Convert.ToInt32(Convert.ToBoolean(Resources.frmConfiguration_srsKeyVerboseLogging_DefaultValue))))) {
                if (bLocalMandatoryMessage)
                    Console.WriteLine(@"[Mandatory]: " + strLocalMessage);
                else
                    Console.WriteLine(@"[Verbose]: " + strLocalMessage);
            }
            else {
                switch (Global.srsLocalRegistrySettings.GetString(Resources.frmConfiguration_srsKeyLogLevel, Resources.frmConfiguration_srsKeyLogLevel_DefaultValue)) {
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
            if (Convert.ToBoolean(Global.srsLocalRegistrySettings.GetInteger(Resources.frmConfiguration_srsKeyVerboseLogging, Convert.ToInt32(Convert.ToBoolean(Resources.frmConfiguration_srsKeyVerboseLogging_DefaultValue)))))
                EventLog.WriteEntry(strEventSource, strLocalMessage, (EventLogEntryType)ltLocalLogType, intLocalID);
            else {
                switch (Global.srsLocalRegistrySettings.GetString(Resources.frmConfiguration_srsKeyLogLevel, Resources.frmConfiguration_srsKeyLogLevel_DefaultValue)) {
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