namespace Sws.ConfigurationProvider.Core.Entities.Azure
{
    public class StartAndStopRecord : PersistentObject
    {
        public VmActivityType VmActivityType { get; set; }
    }

    public enum VmActivityType
    {
        None = 0,
        Start = 1,
        Stop = 2,
        Restart = 3,
        ExecuteFunction = 4,
    }
}