using ExchangeApi.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ExchangeApi.Services
{
    public class RateService : IRateService
    {
        // API Key to be in persistant data storage / vault and to be retrived from repository layer with domain layer through another service
        const string APIKey = "a678717653d8c3348000ebcbbb9544bc";

        public async Task<decimal> GetRate(string date, string baseCur, string destCur)
        {
            using (var httpClient = new HttpClient())
            {
                // message from fixer: base_currency_access_restricted. 
                // free account subscription only allows base currency = EUR, therefore temporary implementation as blow to work around
                string baseCur1 = "EUR", destCur1 = "USD,CAD,MXN";

                var requestUrl = string.Format("http://data.fixer.io/api/{0}?access_key={1}&base={2}&symbols={3}", date, APIKey, baseCur1, destCur1);

                using (var response = await httpClient.GetAsync(requestUrl))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<RateReponse>(apiResponse);
                    
                    if (result.Success) 
                    {
                        // return result.Rates[destCur];

                        // above code commented out and replaced with below to calculate exchange rate due to restriction with free account subscription
                        var exchangeRate = ConvertExchangeRate(result.Rates[baseCur], result.Rates[destCur]);
                        return exchangeRate;
                    }
                    throw new Exception("unable to retrieve rate");
                }
            }
        }

        // temporary implementation
        private decimal ConvertExchangeRate(decimal baseCurrencyExchageRate, decimal destCurrencyExchangeRate)
        {
            return Decimal.Round(destCurrencyExchangeRate / baseCurrencyExchageRate, 6);
        }
    }
}
