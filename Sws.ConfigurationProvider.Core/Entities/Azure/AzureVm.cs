using System.Collections.Generic;

namespace Sws.ConfigurationProvider.Core.Entities.Azure
{
    public class AzureVm : AzureResourceIdentification
    {
        public AzureVm()
        {
            AzureVmTags         = new List<AzureVmTag>();
            StartAndStopRecords = new List<StartAndStopRecord>();
        }

        public AzureVm(string name, string resourceGroupName, string subscriptionName, string computerName, OsType osType, string privateIp, VmStatus status, List<AzureVmTag> azureVmTags)
        {
            Name = name;
            SubscriptionName = subscriptionName;
            ResourceGroupName = resourceGroupName;
            ComputerName = computerName;
            OsType = osType;
            PrivateIp = privateIp;
            Status = status;
            AzureVmTags = azureVmTags;
        }

        public string ComputerName { get; set; }
        public OsType OsType { get; set; }
        public string PrivateIp { get; set; }
        public VmStatus Status { get; set; }
        public List<AzureVmTag> AzureVmTags { get; set; }
        public List<StartAndStopRecord> StartAndStopRecords { get; set; }
        public AzureScaleSet AzureScaleSet { get; set; }
    }

    public enum OsType
    {
        Linux = 0,
        Windows = 1
    }
    public enum VmStatus
    {
        Unknown = 0,
        Stopped = 1,
        Running = 2,
        Deallocated = 3
    }
}