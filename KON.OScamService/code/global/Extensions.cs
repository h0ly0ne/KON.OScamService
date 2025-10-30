using System;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Text;

namespace KON.OScamService {
    [SupportedOSPlatform("windows")]
    internal static class Extensions {
        internal static string Space(this string s) {
            return @" ";
        }
	}
}