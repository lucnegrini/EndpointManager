using EndpointManager.Enums;
using System.Collections.Generic;
using System.Linq;

namespace EndpointManager.Models
{
    public class Company
    {
        private List<Endpoint> Endpoints { get; set; }

        public Company()
        {
            this.Endpoints = new List<Endpoint>();
        }

        public virtual void InsertEndpoint(Endpoint endpoint)
        {
            this.Endpoints.Add(endpoint);
            return;
        }

        public virtual void DeleteEndpoint(string serialNumber)
        {
            this.Endpoints.RemoveAll(a => a.SerialNumber.ToLower() == serialNumber.ToLower());
            return;
        }

        public virtual void EditEndpoint(string serialNumber, SwitchStateEnum state)
        {
            var endpoint = this.Endpoints.FirstOrDefault(a => a.SerialNumber.ToLower() == serialNumber.ToLower());
            endpoint.SwitchState = state;
            return;
        }

        public virtual bool HasEndpointWithSerialNumber(string serialNumber)
        {
            return this.Endpoints.Any(a => a.SerialNumber.ToLower() == serialNumber.ToLower());
        }

        public virtual Endpoint FindBySerialNumber(string serialNumber)
        {
            return this.Endpoints.FirstOrDefault(a => a.SerialNumber.ToLower() == serialNumber.ToLower());
        }

        public virtual List<Endpoint> GetEndpoints()
        {
            return Endpoints;
        }
    }
}