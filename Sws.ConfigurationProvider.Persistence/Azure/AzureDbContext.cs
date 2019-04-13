using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Sws.ConfigurationProvider.Adapters.System;
using Sws.ConfigurationProvider.Core;
using Sws.ConfigurationProvider.Core.Entities.Azure;
using Sws.ConfigurationProvider.Persistence.Azure.EntityMapping;

namespace Sws.ConfigurationProvider.Persistence.Azure
{
    public class AzureDbContext : DbContextBase
    {
        public AzureDbContext()
        {
            
        }
        private static readonly IEnumerable<IEntityTypeMap> Mappings = new []{new AzureScaleSetMap(), };

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(SystemAdapter.GetMachineEnvVariable(Constants.ConnectionStringName));
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