using Microsoft.EntityFrameworkCore;
using Sws.ConfigurationProvider.Core.Entities.Azure;
using Sws.ConfigurationProvider.Persistence.Azure.EntityMapping;
using System.Collections.Generic;

namespace Sws.ConfigurationProvider.Persistence.Azure
{
    public class AzureDbContext : DbContextBase
    {
        public AzureDbContext()
        {

        }
        private static readonly IEnumerable<IEntityTypeMap> Mappings = new[] { new AzureScaleSetMap(), };

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //optionsBuilder.UseSqlServer(SystemAdapter.GetMachineEnvVariable(Constants.ConnectionStringName));
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Database=AzureData;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trusted_Connection = True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var mapping in Mappings)
            {
                mapping.Map(modelBuilder);
            }
        }

        public DbSet<AzureScaleSet> AzureScaleSets { get; set; }
        public DbSet<AzureVm> AzureVms { get; set; }
        public DbSet<StartAndStopRecord> StartAndStopRecords { get; set; }
        public DbSet<AzureVmTag> AzureVmTags { get; set; }
    }
}