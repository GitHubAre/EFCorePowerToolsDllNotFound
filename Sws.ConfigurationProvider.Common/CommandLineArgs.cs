using System;
using CommandLine;

namespace Sws.ConfigurationProvider.Common
{
    public class CommandLineArgs
    {
        [Option(longName: "service", Required = false, HelpText = "Flag to set when running as service e.g. Windows Service on windows.", Default = false)]
        public bool IsService { get; set; }

        public static CommandLineArgs ParseCmdArgs(string[] args)
        {
            CommandLineArgs cmdArgs = new CommandLineArgs();
            var parser = new Parser(settings => settings.CaseInsensitiveEnumValues = true);
            parser.ParseArguments<CommandLineArgs>(args)
                .WithParsed(parsed => cmdArgs = parsed)
                .WithNotParsed(errors => throw new ArgumentException("Failed to parse command line arguments, please examine the error output!"));
            return cmdArgs;
        }
    }
}