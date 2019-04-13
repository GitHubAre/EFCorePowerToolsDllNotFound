using System;
using System.Threading.Tasks;
using Sws.ConfigurationProvider.Core.Entities.Azure;
using Sws.ConfigurationProvider.Persistence.Azure;

namespace Sws.ConfigurationProvider.Persistence
{
    public class AzureUnitOfWork : IAzureUnitOfWork
    {
        private readonly AzureDbContext _context;

        public AzureUnitOfWork(AzureDbContext context)
        {
            _context = context;
            InitRepositories();
        }

        private void InitRepositories()
        {
            AzureVms            = new AzureDbRepository<AzureVm>(_context, this);
            AzureScaleSets    = new AzureDbRepository<AzureScaleSet>(_context, this);
            AzureVmTags         = new AzureDbRepository<AzureVmTag>(_context, this);
            StartAndStopRecords = new AzureDbRepository<StartAndStopRecord>(_context, this);
        }

        public IRepository<AzureVm> AzureVms { get; private set; }

        public IRepository<AzureScaleSet> AzureScaleSets { get; private set; }

        public IRepository<StartAndStopRecord> StartAndStopRecords { get; private set; }

        public IRepository<AzureVmTag> AzureVmTags { get; private set; }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
        
        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context?.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~AzureUnitOfWork()
        {
            Dispose(false);
        }
    }
}