using NUnit.Framework;
using Moq;
using ExchangeApi.Services;
using ExchangeApi.Models;
using ExchangeApi.Controllers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ExchangeApi.Test
{
    public class CalculateInvoiceTotalControllerTest
    {
        private CalculateInvoiceTotalController controller;
        private Mock<IRateService> rateServiceMock;
        private IDataFormatService dataFormatService;
        private Mock<ICalculateService> calculateService;

        [SetUp]
        public void Setup()
        {
            rateServiceMock = new Mock<IRateService>();
            dataFormatService = new DataFormatService();
            calculateService = new Mock<ICalculateService>();
            calculateService.Setup(x => x.ProcessInvoice(It.IsAny<RequestModel>())).ReturnsAsync(new ResponseModel(0.1m, 123.45m, 0.75386m));

            controller = new CalculateInvoiceTotalController(dataFormatService, calculateService.Object);
        }

        [Test]
        public async Task CalculateInvoiceTotalController_Result_ShouldNotNull()
        {
            var result = await controller.Calculate("2020-08-05", "CAD", "123.45", "USD");
            Assert.IsNotNull(result);
        }

        [Test]
        public async Task CalculateInvoiceTotalController_Result_ShouldBeOkResult()
        {
            var result = await controller.Calculate("2020-08-05", "CAD", "123.45", "USD");
            Assert.IsInstanceOf<OkObjectResult>(result);
        }

        [Test]
        public void CalculateInvoiceTotalController_Result_ShouldBeBadRequestResult()
        {
            Assert.ThrowsAsync<ArgumentException>(() => controller.Calculate("invalidparamter", "CAD", "123.45", "USD"));
        }
    }
}
