using System;
using System.Threading.Tasks;
using Sws.ConfigurationProvider.Core.Entities.Azure;

namespace Sws.ConfigurationProvider.Persistence
{
    public interface IAzureUnitOfWork : IDisposable
    {
        IRepository<AzureVm> AzureVms { get; }
        IRepository<AzureScaleSet> AzureScaleSets { get; }
        IRepository<StartAndStopRecord> StartAndStopRecords { get; }
        IRepository<AzureVmTag> AzureVmTags { get; }
        Task<bool> SaveChangesAsync();
    }
}