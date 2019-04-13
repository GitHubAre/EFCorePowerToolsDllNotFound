using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Sws.ConfigurationProvider.Persistence
{
    public interface IEntityTypeMap
    {
        void Map(ModelBuilder builder);
    }

    public abstract class BaseEntityMap<TEntityType> : IEntityTypeMap
        where TEntityType : class
    {
        public void Map(ModelBuilder builder)
        {
            InternalMap(builder.Entity<TEntityType>());
        }

        protected abstract void InternalMap(EntityTypeBuilder<TEntityType> builder);
    }
}