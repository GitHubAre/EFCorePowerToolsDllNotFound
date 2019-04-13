using Sws.ConfigurationProvider.Core.Entities;

namespace Sws.ConfigurationProvider.Persistence
{
    public interface IRepository<T> where T : PersistentObject
    {
        void Add(T newEntity);
        void Remove(int id);
        void Remove(T entity);
    }
}