using EndpointManager.Enums;
using System.Collections.Generic;
using System.Linq;

namespace EndpointManager.Models
{
    public class Company
    {
        public List<Endpoint> Endpoints { get; set; }

        public Company()
        {
            this.Endpoints = new List<Endpoint>();
        }

        
    }
}