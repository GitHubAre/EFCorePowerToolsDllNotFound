using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sws.ConfigurationProvider.Core.Entities.Azure;

namespace Sws.ConfigurationProvider.Persistence.Azure.EntityMapping
{
    public class AzureScaleSetMap : BaseEntityMap<AzureScaleSet>
    {
        protected override void InternalMap(EntityTypeBuilder<AzureScaleSet> builder)
        {
            builder
                .HasMany<AzureVm>(c => c.AzureVms)
                .WithOne(c => c.AzureScaleSet)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasAlternateKey(e => new { e.Name, e.ResourceGroupName, e.SubscriptionName });
        }
    }
}