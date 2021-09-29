using EndpointManager.Enums;
using EndpointManager.Models;
using EndpointManager.Repositories;
using EndpointManager.Services;
using EndpointManager.Tests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace EndpointManager.Tests
{
    [TestClass]
    public class companyServiceTests
    {
        private static CompanyService companyService;

        [TestMethod]
        public void TestInsertValidEndpoint()
        {
            var companyRepository = new Mock<CompanyRepository>();
            companyRepository.Setup(a => a.InsertEndpoint(It.IsAny<Endpoint>()));
            companyRepository.Setup(a => a.HasEndpointWithSerialNumber(It.IsAny<string>())).Returns(false);

            companyService = new CompanyService(companyRepository.Object);

            var result = companyService.InsertEndpoint(TestHelper.ValidEndpoint);

            Assert.IsTrue(result == InsertEndpointResponseEnum.Success);
        }

        [TestMethod]
        public void TestInsertExistingSerialNumber()
        {
            var companyRepository = new Mock<CompanyRepository>();
            companyRepository.Setup(a => a.HasEndpointWithSerialNumber(It.IsAny<string>())).Returns(true);

            companyService = new CompanyService(companyRepository.Object);

            var result = companyService.InsertEndpoint(TestHelper.ValidEndpoint);

            Assert.IsTrue(result == InsertEndpointResponseEnum.SerialNumberAllreadyExists);
        }

        [TestMethod]
        public void TestDeleteExistingEndpoint()
        {
            var companyRepository = new Mock<CompanyRepository>();
            companyRepository.Setup(a => a.DeleteEndpoint(It.IsAny<string>()));
            companyRepository.Setup(a => a.HasEndpointWithSerialNumber(It.IsAny<string>())).Returns(true);

            companyService = new CompanyService(companyRepository.Object);

            var result = companyService.DeleteEndpoint(TestHelper.ValidEndpoint.SerialNumber);

            Assert.IsTrue(result == DeleteEndpointResponseEnum.Success);
        }

        [TestMethod]
        public void TestDeleteUnexistingEndpoint()
        {
            var companyRepository = new Mock<CompanyRepository>();
            companyRepository.Setup(a => a.DeleteEndpoint(It.IsAny<string>()));
            companyRepository.Setup(a => a.HasEndpointWithSerialNumber(It.IsAny<string>())).Returns(false);

            companyService = new CompanyService(companyRepository.Object);

            var result = companyService.DeleteEndpoint(TestHelper.ValidEndpoint.SerialNumber);

            Assert.IsTrue(result == DeleteEndpointResponseEnum.EndpointNotFound);
        }
    }
}
