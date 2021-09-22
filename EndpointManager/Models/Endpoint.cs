using EndpointManager.Enums;

namespace EndpointManager.Models
{
    public class Endpoint
    {
        public string SerialNumber { get; set; }
        public MeterModelEnum MeterModelId { get; set; }
        public int MeterNumber { get; set; }
        public string MeterFirmwareVersion { get; set; }
        public SwitchStateEnum SwitchState { get; set; }

        public Endpoint(string serialNumber, MeterModelEnum meterModelId, int meterNumber, string firmwareVersion, SwitchStateEnum state)
        {
            this.SerialNumber = serialNumber;
            this.MeterModelId = meterModelId;
            this.MeterNumber = meterNumber;
            this.MeterFirmwareVersion = firmwareVersion;
            this.SwitchState = state;
        }
    }
}
