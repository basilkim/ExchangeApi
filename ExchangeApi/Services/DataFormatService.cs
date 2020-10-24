using ExchangeApi.Models;
using System;
using System.Linq;

namespace ExchangeApi.Services
{
    public class DataFormatService : IDataFormatService
    {
        public RequestModel FormatParameter(string invoiceDate, string invoiceCurrency, string pretaxTotal, string paymentCurrency)
        {
            return new RequestModel()
            {
                InvoicdDate = FormatDateTime(invoiceDate),
                InvoicePreTaxTotal = FormatAmount(pretaxTotal),
                InvoiceCurrency = FindCurrency(invoiceCurrency),
                PaymentCurrency = FindCurrency(paymentCurrency)
            };
        }
        private string FormatDateTime(string dateTime)
        {
            if (!string.IsNullOrEmpty(dateTime))
            {
                DateTime tempDate;
                if (DateTime.TryParse(dateTime, out tempDate))
                {
                    return String.Format("{0:yyyy-MM-dd}", tempDate);
                }
            }
            throw new ArgumentException("cannot parse date (format ex: 2020-08-05)");
        }

        private decimal FormatAmount(string amount)
        {
            if (!string.IsNullOrEmpty(amount))
            {
                decimal tempDate;
                if (Decimal.TryParse(amount, out tempDate))
                {
                    return decimal.Round(tempDate, 2);
                }
            }
            throw new ArgumentException("invalid amount format");
        }

        private string FindCurrency(string currency)
        {
            string[] availableCurrencies = { "USD", "CAD", "MXN" };
            if (availableCurrencies.Contains(currency, StringComparer.OrdinalIgnoreCase))
            {
                return availableCurrencies.Where(x => x == currency.ToUpper()).First();
            }
            throw new ArgumentException("currency not supported");
        }
    }
}
