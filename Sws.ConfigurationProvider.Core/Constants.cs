namespace Sws.ConfigurationProvider.Core
{
    public static class Constants
    {
        public const string SwsConfigProviderName = "Sws.ConfigurationProvider";
        public static string ConnectionStringName => SwsConfigProviderName + ".ConnectionString";
        public static string HangfireConnectionStringName => SwsConfigProviderName + ".HangfireConnectionString";
    }
}