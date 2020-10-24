using ExchangeApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExchangeApi.Services
{
    public class CalculateService : ICalculateService
    {
        private readonly IRateService _rateService;

        // Tax rate to be in persistant data storage and to be retrived from repository layer with domain layer through another service
        private static readonly Dictionary<string, decimal> taxRate = new Dictionary<string, decimal>() { { "CAD", 0.11m }, { "USD", 0.1m }, { "MXN", 0.09m } };
        public CalculateService(IRateService rateService)
        {
            _rateService = rateService;
        }
        public async Task<ResponseModel> ProcessInvoice(RequestModel request)
        {
            var exchangeRate = request.InvoiceCurrency != request.PaymentCurrency ? await  _rateService.GetRate(request.InvoicdDate, request.InvoiceCurrency, request.PaymentCurrency) : 1.00m;

            var response = new ResponseModel(taxRate[request.InvoiceCurrency], request.InvoicePreTaxTotal, exchangeRate);

            return response;
        }

    }
}
