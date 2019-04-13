using Microsoft.EntityFrameworkCore;
using Sws.ConfigurationProvider.Core.Entities;
using Sws.ConfigurationProvider.Persistence.Azure;

namespace Sws.ConfigurationProvider.Persistence
{
    public class AzureDbRepository<T> : IRepository<T> where T : PersistentObject
    {
        protected readonly AzureDbContext Context;
        protected readonly IAzureUnitOfWork Uow;
        protected DbSet<T> DbSet;

        public AzureDbRepository(AzureDbContext context, IAzureUnitOfWork uow)
        {
            Context = context;
            Uow = uow;
            DbSet = context.Set<T>();
        }

        public void Add(T newEntity)
        {
            DbSet.Add(newEntity);
        }

        public void Remove(int id)
        {
            var entity = DbSet.Find(id);
            DbSet.Remove(entity);
        }

        public void Remove(T entity)
        {
            DbSet.Remove(entity);
        }
    }
}