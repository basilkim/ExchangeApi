using System.Threading.Tasks;

namespace ExchangeApi.Services
{
    public interface IRateService
    {
        Task<decimal> GetRate(string date, string baseCur, string destCur);
    }
}
