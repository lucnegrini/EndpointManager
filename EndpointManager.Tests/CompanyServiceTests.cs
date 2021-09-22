using EndpointManager.Enums;
using EndpointManager.Models;
using EndpointManager.Services;
using EndpointManager.Tests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace EndpointManager.Tests
{
    [TestClass]
    public class CompanyServiceTests
    {
        private static CompanyService CompanyService;

        [TestMethod]
        public void TestInsertValidEndpoint()
        {
            var Company = new Mock<Company>();
            Company.Setup(a => a.InsertEndpoint(It.IsAny<Endpoint>()));
            Company.Setup(a => a.HasEndpointWithSerialNumber(It.IsAny<string>())).Returns(false);

            CompanyService = new CompanyService(Company.Object);

            var result = CompanyService.InsertEndpoint(TestHelper.ValidEndpoint);

            Assert.IsTrue(result == InsertEndpointResponseEnum.Success);
        }

        [TestMethod]
        public void TestInsertExistingSerialNumber()
        {
            var Company = new Mock<Company>();
            Company.Setup(a => a.HasEndpointWithSerialNumber(It.IsAny<string>())).Returns(true);

            CompanyService = new CompanyService(Company.Object);

            var result = CompanyService.InsertEndpoint(TestHelper.ValidEndpoint);

            Assert.IsTrue(result == InsertEndpointResponseEnum.SerialNumberAllreadyExists);
        }

        [TestMethod]
        public void TestDeleteExistingEndpoint()
        {
            var Company = new Mock<Company>();
            Company.Setup(a => a.DeleteEndpoint(It.IsAny<string>()));
            Company.Setup(a => a.HasEndpointWithSerialNumber(It.IsAny<string>())).Returns(true);

            CompanyService = new CompanyService(Company.Object);

            var result = CompanyService.DeleteEndpoint(TestHelper.ValidEndpoint.SerialNumber);

            Assert.IsTrue(result == DeleteEndpointResponseEnum.Success);
        }

        [TestMethod]
        public void TestDeleteUnexistingEndpoint()
        {
            var Company = new Mock<Company>();
            Company.Setup(a => a.DeleteEndpoint(It.IsAny<string>()));
            Company.Setup(a => a.HasEndpointWithSerialNumber(It.IsAny<string>())).Returns(false);

            CompanyService = new CompanyService(Company.Object);

            var result = CompanyService.DeleteEndpoint(TestHelper.ValidEndpoint.SerialNumber);

            Assert.IsTrue(result == DeleteEndpointResponseEnum.EndpointNotFound);
        }
    }
}
