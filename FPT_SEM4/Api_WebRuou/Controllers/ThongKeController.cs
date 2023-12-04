using Api_WebRuou.Core.Response;
using Api_WebRuou.Dtos.ThongKe;
using Api_WebRuou.Infrastucture.DataBaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_WebRuou.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ThongKeController : Controller
    {
        private readonly ApiDbContext _dbContext;

        public ThongKeController(ApiDbContext db)
        {
            _dbContext = db;
        }

        [HttpGet]
        [Route("thongke")]
        public async Task<IActionResult> ThongKe()
        {
            try
            {
                var doanhthu = await _dbContext.DonHangs.Where(x=> x.DaThanhToan == true).SumAsync(x => x.TongTien);
                var soluongSp = await _dbContext.DonHangs.Where(x => x.DaThanhToan == true).SumAsync(x => x.SoLuong);
                var soluongDh = await _dbContext.DonHangs.Where(x => x.DaThanhToan == true).CountAsync();
                var result = new ThongKeDto()
                {
                    DoanhThu = doanhthu,
                    SoDonHang = soluongDh,
                    SoluongSPBan = soluongSp
                };
                return Ok(ResponseResult.Success(result));
            }                 
             catch (Exception ex)
            {
                return Ok(ResponseResult.Erorr(ex.Message));
            }
        }

    }
}
