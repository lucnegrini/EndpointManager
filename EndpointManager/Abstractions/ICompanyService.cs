using EndpointManager.Enums;
using EndpointManager.Models;
using System.Collections.Generic;

namespace EndpointManager.Abstractions
{
    public interface ICompanyService
    {
        InsertEndpointResponseEnum InsertEndpoint(Endpoint endpoint);
        DeleteEndpointResponseEnum DeleteEndpoint(string serialNumber);
        EditEndpointResponseEnum EditEndpoint(string serialNumber, SwitchStateEnum state);
        Endpoint FindEndpointBySerialNumber(string serialNumber);
        List<Endpoint> GetEndpoints();
        bool HasEndpointWithSerialNumber(string serialNumber);
    }
}
