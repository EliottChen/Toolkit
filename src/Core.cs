using System;
using System.Reflection;

namespace EliottChen.Toolkit
{
    /// <summary>
    /// Static class to store Toolkit's versions
    /// </summary>
    public static class Core
    {
        public static string Version => GetVersion();
        public const string PackageName = "EliottChen.Toolkit";


        /// <summary>
        /// Change version settings in csproj directly
        /// </summary>
        /// <returns> the versions</returns>
        private static string GetVersion()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Version ver = assembly.GetName().Version;

            return $"{ver.Major}.{ver.Minor}.{ver.Build}";
        }
    }
}
