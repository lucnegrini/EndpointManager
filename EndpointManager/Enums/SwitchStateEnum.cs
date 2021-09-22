using System.ComponentModel;

namespace EndpointManager.Enums
{
    public enum SwitchStateEnum
    {
        [Description("Disconnected")]
        Disconnected = 0,
        [Description("Connected")]
        Connected = 1,
        [Description("Armed")]
        Armed = 2,
    }
}
