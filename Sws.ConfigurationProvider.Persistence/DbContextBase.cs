using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Sws.ConfigurationProvider.Persistence
{
    public abstract class DbContextBase : DbContext
    {
#if DEBUG
        /// <summary>
        /// Logging to debug console
        /// </summary>
        /// <returns></returns>
        private ILoggerFactory GetLoggerFactory()
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddLogging(builder =>
                builder.AddConsole()
                    .AddFilter(DbLoggerCategory.Database.Command.Name,
                        LogLevel.Information));
            return serviceCollection.BuildServiceProvider()
                .GetService<ILoggerFactory>();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(GetLoggerFactory());
        }
#endif

#if !DEBUG
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }
#endif
    }
}
