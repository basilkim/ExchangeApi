using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExchangeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "URL: /api/calculateinvoice/ExchangeRateDate/InvoiceCurrency/PreTaxAmount/PaymentCurrency", "Ex: https://localhost:44332/api/calculateinvoice/2020-08-05/CAD/123.45/USD" };
        }
    }
}
