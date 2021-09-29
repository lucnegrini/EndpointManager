using EndpointManager.Enums;
using EndpointManager.Models;
using System.Collections.Generic;

namespace EndpointManager.Abstractions
{
    public interface ICompanyRepository
    {
        void InsertEndpoint(Endpoint endpoint);
        void DeleteEndpoint(string serialNumber);
        void EditEndpoint(string serialNumber, SwitchStateEnum state);
        bool HasEndpointWithSerialNumber(string serialNumber);
        Endpoint FindBySerialNumber(string serialNumber);
        List<Endpoint> GetEndpoints();
    }
}
