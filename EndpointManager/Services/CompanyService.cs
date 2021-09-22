using EndpointManager.Abstractions;
using EndpointManager.Enums;
using EndpointManager.Models;
using System;
using System.Collections.Generic;

namespace EndpointManager.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly Company Company;

        public CompanyService(Company company)
        {
            this.Company = company;
        }

        public DeleteEndpointResponseEnum DeleteEndpoint(string serialNumber)
        {
            if (!this.Company.HasEndpointWithSerialNumber(serialNumber))
                return DeleteEndpointResponseEnum.EndpointNotFound;

            try
            {
                this.Company.DeleteEndpoint(serialNumber);
            }
            catch(Exception)
            {
                return DeleteEndpointResponseEnum.UnkownError;
            }

            return DeleteEndpointResponseEnum.Success;
        }

        public EditEndpointResponseEnum EditEndpoint(string serialNumber, SwitchStateEnum state)
        {
            if (!this.Company.HasEndpointWithSerialNumber(serialNumber))
                return EditEndpointResponseEnum.EndpointNotFound;

            try
            {
                this.Company.EditEndpoint(serialNumber, state);
            }
            catch (Exception)
            {
                return EditEndpointResponseEnum.UnkownError;
            }
            return EditEndpointResponseEnum.Success;
        }

        public Endpoint FindEndpointBySerialNumber(string serialNumber)
        {
            return this.Company.FindBySerialNumber(serialNumber);
        }

        public List<Endpoint> GetEndpoints()
        {
            return this.Company.GetEndpoints();
        }

        public bool HasEndpointWithSerialNumber(string serialNumber)
        {
            return this.Company.HasEndpointWithSerialNumber(serialNumber);
        }

        public InsertEndpointResponseEnum InsertEndpoint(Endpoint endpoint)
        {
            if (this.Company.HasEndpointWithSerialNumber(endpoint.SerialNumber))
                return InsertEndpointResponseEnum.SerialNumberAllreadyExists;

            try
            {
                this.Company.InsertEndpoint(endpoint);
            }
            catch (Exception)
            {
                return InsertEndpointResponseEnum.UnkownError;
            }

            return InsertEndpointResponseEnum.Success;
        }
    }
}