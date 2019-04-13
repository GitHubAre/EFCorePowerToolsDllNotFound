using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sws.ConfigurationProvider.Core.Entities.Azure;

namespace Sws.ConfigurationProvider.Persistence.Azure.EntityMapping
{
    public class AzureVmMap : BaseEntityMap<AzureVm>
    {
        protected override void InternalMap(EntityTypeBuilder<AzureVm> builder)
        {
            builder
                .HasMany<AzureVmTag>(c => c.AzureVmTags)
                .WithOne(c => c.AzureVm)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade).HasForeignKey(c => c.AzureVmId);
            builder.HasAlternateKey(e => new {e.Name, e.ResourceGroupName, e.SubscriptionName});
        }
    }
}