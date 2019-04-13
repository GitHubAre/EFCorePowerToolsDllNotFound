using System.Collections.Generic;

namespace Sws.ConfigurationProvider.Core.Entities.Azure
{
    public class AzureScaleSet : AzureResourceIdentification
    {
        private AzureScaleSet() { }
        public AzureScaleSet(List<AzureVm> azureVms, string name, string resourceGroupName, string subscriptionName)
        {
            AzureVms = azureVms;
            Name = name;
            ResourceGroupName = resourceGroupName;
            SubscriptionName = subscriptionName;
        }
        public List<AzureVm> AzureVms { get; set; }
    }
}