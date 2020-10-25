using System.Threading.Tasks;
using ExchangeApi.Services;
using Microsoft.AspNetCore.Mvc;


namespace ExchangeApi.Controllers
{
    [Route("api/calculateinvoice")]
    [ApiController]
    public class CalculateInvoiceTotalController : ControllerBase
    {
        private readonly IDataFormatService _dataFormatService;
        private readonly ICalculateService _calculateService;

        public CalculateInvoiceTotalController(IDataFormatService dataFormatService, ICalculateService calculateService)
        {
            _dataFormatService = dataFormatService;
            _calculateService = calculateService;
        }

        [HttpGet]
        [Route("{invoiceDate}/{invoiceCurrency}/{pretaxTotal}/{paymentCurrency}")]
        public async Task<IActionResult> Calculate(string invoiceDate, string invoiceCurrency, string pretaxTotal, string paymentCurrency)
        {
            var model = _dataFormatService.FormatParameter(invoiceDate, invoiceCurrency, pretaxTotal, paymentCurrency);
            var response = await _calculateService.ProcessInvoice(model);
            return Ok(response);
        }
    }

    
    
}
