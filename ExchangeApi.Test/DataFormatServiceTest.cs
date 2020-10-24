using NUnit.Framework;
using Moq;
using ExchangeApi.Services;
using ExchangeApi.Models;
using System;

namespace ExchangeApi.Test
{
    public class DataFormatServiceTest
    {
        private DataFormatService dataFormatService;

        [SetUp]
        public void Setup()
        {
            dataFormatService = new DataFormatService();
        }


        [Test]
        public void DataFormatService_FormatDateTime_ShouldReturnCorrectFormat()
        {
            var response = dataFormatService.FormatParameter("08-05-2020", "CAD", "123.45", "USD");
            var expected = "2020-08-05";

            Assert.AreEqual(expected, response.InvoicdDate);
        }

        [Test]
        public void DataFormatService_FormatDateTime_ThrowExpection_WrongDataFormat()
        {
            Assert.Throws<ArgumentException>(() => dataFormatService.FormatParameter("invalid date format", "CAD", "123.45", "USD")).Message.Equals("cannot parse date (format ex: 2020-08-05)");
            Assert.Throws<ArgumentException>(() => dataFormatService.FormatParameter("08-05-2020", "CAD", "invalid format", "USD")).Message.Equals("invalid amount format");
            Assert.Throws<ArgumentException>(() => dataFormatService.FormatParameter("08-05-2020", "CAD", "123.45", "EUR")).Message.Equals("currency not supported");
        }
    }
}
