using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeApi.Models
{
    public class ResponseModel
    {
        private decimal _taxRate, _preTaxAmt; 

        public ResponseModel(decimal taxRate, decimal preTaxAmt, decimal exchangeRate)
        {
            _taxRate = taxRate;
            _preTaxAmt = preTaxAmt;
            ExchangeRate = exchangeRate;
        }
        public decimal Tax { get { return CalculateTax(); } }
        public decimal GrandTotal { get { return CalculatTotal(); } }
        public decimal ExchangeRate { get; private set; }
        public decimal ConvertedTotal { get { return ApplyCurrency(); } }

        private decimal CalculateTax()
        {
            return Decimal.Round(_preTaxAmt * _taxRate, 2);
        }

        private decimal CalculatTotal()
        {
            return _preTaxAmt + Tax;
        }

        private decimal ApplyCurrency()
        {
            return Decimal.Round(GrandTotal * ExchangeRate, 2);
        }
    }
}
