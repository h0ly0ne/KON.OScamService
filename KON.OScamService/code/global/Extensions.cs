using System;
using System.Runtime.Versioning;

namespace KON.OScamService
{
    [SupportedOSPlatform("windows")]
    public static class Extensions
    {
        public static string Space(this string s) {
            return @" ";
        }

        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern uint GetModuleFileName(IntPtr hModule, System.Text.StringBuilder lpFilename, int nSize);
        private const int MAX_PATH = 255;

        public static string GetExecutablePath() {
            if (!System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(System.Runtime.InteropServices
                    .OSPlatform.Windows)) return System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;

            var sb = new System.Text.StringBuilder(MAX_PATH);
            
            GetModuleFileName(IntPtr.Zero, sb, MAX_PATH);
            
            return sb.ToString();
        }
	}
}