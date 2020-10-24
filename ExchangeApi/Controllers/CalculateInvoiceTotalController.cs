using System;
using System.Threading.Tasks;
using ExchangeApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace ExchangeApi.Controllers
{
    [Route("api/calculateinvoice")]
    [ApiController]
    public class CalculateInvoiceTotalController : ControllerBase
    {
        private readonly IDataFormatService _dataFormatService;
        private readonly ICalculateService _calculateService;
        private readonly ILogger _logger;
        public CalculateInvoiceTotalController(IDataFormatService dataFormatService, ICalculateService calculateService, ILogger<CalculateInvoiceTotalController> logger)
        {
            _dataFormatService = dataFormatService;
            _calculateService = calculateService;
            _logger = logger;
        }

        [HttpGet]
        [Route("{invoiceDate}/{invoiceCurrency}/{pretaxTotal}/{paymentCurrency}")]
        public async Task<IActionResult> Calculate(string invoiceDate, string invoiceCurrency, string pretaxTotal, string paymentCurrency)
        {
            //try
            //{
                var model = _dataFormatService.FormatParameter(invoiceDate, invoiceCurrency, pretaxTotal, paymentCurrency);
                var response = await _calculateService.ProcessInvoice(model);
                return Ok(response);
            //}
            //catch(ArgumentException ex)
            //{
            //    _logger.LogError(ex.Message);
            //    return BadRequest(ex.Message);
            //}
            //catch(Exception ex)
            //{
            //    _logger.LogError(ex.Message);
            //    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            //}
        }
    }

    
    
}
