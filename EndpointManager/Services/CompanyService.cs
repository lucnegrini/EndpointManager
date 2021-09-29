using EndpointManager.Abstractions;
using EndpointManager.Enums;
using EndpointManager.Models;
using System;
using System.Collections.Generic;

namespace EndpointManager.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            this.companyRepository = companyRepository;
        }

        public DeleteEndpointResponseEnum DeleteEndpoint(string serialNumber)
        {
            if (!this.companyRepository.HasEndpointWithSerialNumber(serialNumber))
                return DeleteEndpointResponseEnum.EndpointNotFound;

            try
            {
                this.companyRepository.DeleteEndpoint(serialNumber);
            }
            catch(Exception)
            {
                return DeleteEndpointResponseEnum.UnkownError;
            }

            return DeleteEndpointResponseEnum.Success;
        }

        public EditEndpointResponseEnum EditEndpoint(string serialNumber, SwitchStateEnum state)
        {
            if (!this.companyRepository.HasEndpointWithSerialNumber(serialNumber))
                return EditEndpointResponseEnum.EndpointNotFound;

            try
            {
                this.companyRepository.EditEndpoint(serialNumber, state);
            }
            catch (Exception)
            {
                return EditEndpointResponseEnum.UnkownError;
            }
            return EditEndpointResponseEnum.Success;
        }

        public Endpoint FindEndpointBySerialNumber(string serialNumber)
        {
            return this.companyRepository.FindBySerialNumber(serialNumber);
        }

        public List<Endpoint> GetEndpoints()
        {
            return this.companyRepository.GetEndpoints();
        }

        public bool HasEndpointWithSerialNumber(string serialNumber)
        {
            return this.companyRepository.HasEndpointWithSerialNumber(serialNumber);
        }

        public InsertEndpointResponseEnum InsertEndpoint(Endpoint endpoint)
        {
            if (this.companyRepository.HasEndpointWithSerialNumber(endpoint.SerialNumber))
                return InsertEndpointResponseEnum.SerialNumberAllreadyExists;

            try
            {
                this.companyRepository.InsertEndpoint(endpoint);
            }
            catch (Exception)
            {
                return InsertEndpointResponseEnum.UnkownError;
            }

            return InsertEndpointResponseEnum.Success;
        }
    }
}