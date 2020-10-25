using NUnit.Framework;
using Moq;
using ExchangeApi.Services;
using ExchangeApi.Models;

namespace ExchangeApi.Test
{
    public class CalculateServiceTest
    {
        private Mock<IRateService> rateServiceMock;
        private IDataFormatService dataFormatService;
        [SetUp]
        public void Setup()
        {
            dataFormatService = new DataFormatService();
            
            rateServiceMock = new Mock<IRateService>();
            rateServiceMock.Setup(x => x.GetRate("2020-08-05", "CAD", "USD")).ReturnsAsync(0.753855m);
        }

        [Test]
        public void CalculateService_ProcessInvoice_ShouldExchangeRate_1()
        {
            var request = dataFormatService.FormatParameter("2020-08-05", "CAD", "123.45", "CAD");
            var calculateService = new CalculateService(rateServiceMock.Object);
            var response = calculateService.ProcessInvoice(request).Result;

            Assert.AreEqual(1m, response.ExchangeRate);
        }

        [Test]
        public void CalculateService_ProcessInvoice_ShouldBeSameAmount()
        {
            var request = dataFormatService.FormatParameter("2020-08-05", "CAD", "123.45", "USD");
            var expected = new ResponseModel(0.11m, 123.45m, 0.753855m);

            var calculateService = new CalculateService(rateServiceMock.Object);
            var response = calculateService.ProcessInvoice(request).Result;

            Assert.AreEqual(expected.ConvertedTotal, response.ConvertedTotal);
        }
    }
}
