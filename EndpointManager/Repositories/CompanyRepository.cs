using EndpointManager.Abstractions;
using EndpointManager.Enums;
using EndpointManager.Models;
using System.Collections.Generic;
using System.Linq;

namespace EndpointManager.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private static Company Company;

        public CompanyRepository()
        {
            Company = new Company();
        }

        public virtual void InsertEndpoint(Endpoint endpoint)
        {
            Company.Endpoints.Add(endpoint);
            return;
        }

        public virtual void DeleteEndpoint(string serialNumber)
        {
            Company.Endpoints.RemoveAll(a => a.SerialNumber.ToLower() == serialNumber.ToLower());
            return;
        }

        public virtual void EditEndpoint(string serialNumber, SwitchStateEnum state)
        {
            var endpoint = Company.Endpoints.FirstOrDefault(a => a.SerialNumber.ToLower() == serialNumber.ToLower());
            endpoint.SwitchState = state;
            return;
        }

        public virtual bool HasEndpointWithSerialNumber(string serialNumber)
        {
            return Company.Endpoints.Any(a => a.SerialNumber.ToLower() == serialNumber.ToLower());
        }

        public virtual Endpoint FindBySerialNumber(string serialNumber)
        {
            return Company.Endpoints.FirstOrDefault(a => a.SerialNumber.ToLower() == serialNumber.ToLower());
        }

        public virtual List<Endpoint> GetEndpoints()
        {
            return Company.Endpoints;
        }
    }
}
