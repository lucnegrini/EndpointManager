using EndpointManager.Enums;
using EndpointManager.Models;

namespace EndpointManager.Tests.Helpers
{
    public static class TestHelper
    {
        public static Endpoint ValidEndpoint = new Endpoint("ABCD", MeterModelEnum.NSX1P2W, 1234, "EFGH", SwitchStateEnum.Disconnected);
    }
}
