using System;
using System.IO;

namespace Sws.ConfigurationProvider.Adapters.System
{
    public class SystemAdapter
    {
        public static string GetMachineEnvVariable(string variableName)
        {
            return Environment.GetEnvironmentVariable(variableName, EnvironmentVariableTarget.Machine);
        }

        public string JoinPaths(params string[] pathSegments)
        {
            return Path.Combine(pathSegments);
        }
    }
}