using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeApi.Models
{
    public class RequestModel
    {
        public string InvoicdDate { get; set; }
        public decimal InvoicePreTaxTotal { get; set; }
        public string InvoiceCurrency { get; set; }
        public string PaymentCurrency { get; set; }
    }
}
