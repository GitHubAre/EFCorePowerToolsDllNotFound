using System;
using System.IO;
using System.Reflection;

namespace Sws.ConfigurationProvider.Common.Helpers
{
    public static class DotNet
    {
        public static string GetExecutingDirectory()
        {
            return String.IsNullOrEmpty(AppDomain.CurrentDomain.RelativeSearchPath)
                ? AppDomain.CurrentDomain.BaseDirectory
                : AppDomain.CurrentDomain.RelativeSearchPath;
        }

        public static string GetExecutingAssemblyName()
        {
            return GetExecutingAssembly().GetName().Name;
        }

        public static string GetExecutingAssemblyPath()
        {
            var path = GetExecutingAssembly().Location;
            if (path == null)
                throw new ArgumentNullException(nameof(path));

            return new FileInfo(path).DirectoryName;
        }

        private static Assembly GetExecutingAssembly()
        {
            return Assembly.GetEntryAssembly() == null ? Assembly.GetCallingAssembly() :
                Assembly.GetEntryAssembly();
        }

        public static string GetEntryAssemblyName()
        {
            return GetExecutingAssembly().GetName().Name;
        }

    }
}