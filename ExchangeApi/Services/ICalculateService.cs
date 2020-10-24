using ExchangeApi.Models;
using System.Threading.Tasks;

namespace ExchangeApi.Services
{
    public interface ICalculateService
    {
        Task<ResponseModel> ProcessInvoice(RequestModel request);
    }
}
