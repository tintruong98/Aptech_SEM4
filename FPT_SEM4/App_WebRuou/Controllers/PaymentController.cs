using App_WebRuou.Models;
using App_WebRuou.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace App_WebRuou.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IPayPalService _payPalService;

        public PaymentController(IPayPalService payPalService)
        {
            _payPalService = payPalService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> CreatePaymentUrl(PaymentInformationModel model)
        {
            var url = await _payPalService.CreatePaymentUrl(model, HttpContext);

            return Redirect(url);
        }

        public IActionResult PaymentCallback()
        {
            var response = _payPalService.PaymentExecute(Request.Query);
            if (response.Success == true)
            {
                return RedirectToAction("ThanhToan", "KhachHang", new { pttt = "PayPal" });
            }
            else
            {
                return RedirectToAction("ThanhToan", "KhachHang", new { pttt = "Huy" });
            }
        }

    }
}
