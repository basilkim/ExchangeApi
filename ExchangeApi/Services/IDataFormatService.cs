using ExchangeApi.Models;

namespace ExchangeApi.Services
{
    public interface IDataFormatService
    {
        public RequestModel FormatParameter(string invoiceDate, string invoiceCurrency, string pretaxTotal, string paymentCurrency);

    }
}
