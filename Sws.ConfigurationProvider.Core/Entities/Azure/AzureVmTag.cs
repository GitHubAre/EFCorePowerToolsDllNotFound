namespace Sws.ConfigurationProvider.Core.Entities.Azure
{
    public class AzureVmTag : PersistentObject
    {
        public AzureVmTag()
        {
            
        }
        public AzureVmTag(string key, string value)
        {
            Key = key;
            Value = value;
        }
        public string Key { get; set; }
        public string Value { get; set; }
        public int AzureVmId { get; set; }
        public AzureVm AzureVm { get; set; }
    }
}