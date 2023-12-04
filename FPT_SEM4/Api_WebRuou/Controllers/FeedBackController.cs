using Api_WebRuou.Core.Response;
using Api_WebRuou.Dtos.FeedBack;
using Api_WebRuou.Infrastucture.DataBaseContext;
using Api_WebRuou.Infrastucture.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_WebRuou.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FeedBackController : Controller
    {
        private readonly ApiDbContext _dbContext;
        public FeedBackController(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAllFeedBack()
        {
            try
            {
                var result = await _dbContext.FeedBacks.Take(10).ToListAsync();
                return Ok(ResponseResult.Success(result));
            }
            catch (Exception ex)
            {
                return Ok(ResponseResult.Erorr(ex.Message));
            }

        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateFeebBack(FeedBackDto dto)
        {
            try
            {
                var feedBack = new FeedBack()
                {
                    IdKhachHang = dto.IdKhachHang,
                    IdDonHang = dto.IdDonHang,
                    IdSanPham = dto.IdSanPham,
                    Contents = dto.Contents,
                    ThoiGianFeed = dto.ThoiGianFeed,
                    Evaluate = dto.Evaluate
                };
                await _dbContext.FeedBacks.AddAsync(feedBack);
                await _dbContext.SaveChangesAsync();
                return Ok(ResponseResult.Success(feedBack));
            }
            catch (Exception ex)
            {
                return Ok(ResponseResult.Erorr(ex.Message));
            }

        }
    }
}
