namespace Sws.ConfigurationProvider.Core.Entities.Azure
{
    public class AzureResourceIdentification : PersistentObject
    {
        public string Name { get; set; }
        public string ResourceGroupName { get; set; }
        public string SubscriptionName { get; set; }
    }
}