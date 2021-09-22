using EndpointManager.Abstractions;
using EndpointManager.Enums;
using EndpointManager.Helpers;
using EndpointManager.Models;
using System;

namespace EndpointManager.Services
{
    public class EndpointService : IEndpointService
    {
        //Ran out of time to try and make this generic
        public Endpoint CreateEndpoint()
        {
            Console.WriteLine("Please enter value for Serial Number");
            var serialNumber = Console.ReadLine();

            MenuHelper.WriteOptions<MeterModelEnum>("Please select the Meter Model");
            var meterModel = MenuHelper.GetResponse<MeterModelEnum>();

            Console.WriteLine("Please enter value for Meter Number");
            var meterNumberResponse = Console.ReadLine();
            int meterNumber;

            while (!int.TryParse(meterNumberResponse, out meterNumber))
            {
                Console.WriteLine("Invlaid value. Please try again.");
                meterNumberResponse = Console.ReadLine();
            }

            Console.WriteLine("Please enter value for Meter Firmware Version");
            var firmwareVersion = Console.ReadLine();

            MenuHelper.WriteOptions<SwitchStateEnum>("Please select the switch state");
            var switchState = MenuHelper.GetResponse<SwitchStateEnum>();

            return new Endpoint(serialNumber, meterModel, meterNumber, firmwareVersion, switchState);
        }
    }
}
