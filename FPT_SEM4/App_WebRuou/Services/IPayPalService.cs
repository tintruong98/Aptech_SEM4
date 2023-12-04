using App_WebRuou.Models;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace App_WebRuou.Services
{
    public interface IPayPalService
    {
        Task<string> CreatePaymentUrl(PaymentInformationModel model, HttpContext context);
        PaymentResponseModel PaymentExecute(IQueryCollection collections);
    }
}
