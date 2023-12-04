using Api_WebRuou.Core.Response;
using Api_WebRuou.Dtos.LienHe;
using Api_WebRuou.Infrastucture.DBContext;
using Api_WebRuou.Infrastucture.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api_WebRuou.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LienHeController : Controller
    {
        private readonly DBContext _dbContext;
        public LienHeController(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> AllLienHe()
        {
            try
            {
                var result = _dbContext.LienHes.ToList();
                return Ok(ResponseResult.Success(result));
            }
            catch (Exception ex)
            {
                return Ok(ResponseResult.Erorr(ex.Message));
            }
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateLienHe(LienHeDto dto)
        {
            try
            {
                var lienHe = new LienHe()
                {
                    KhachHangId = dto.KhachHangId,
                    Name = dto.Name,
                    Description = dto.Description,
                    Phone = dto.Phone,
                };
                await _dbContext.LienHes.AddAsync(lienHe);
                await _dbContext.SaveChangesAsync();
                return Ok(ResponseResult.Success(lienHe));
            }
            catch (Exception ex)
            {
                return Ok(ResponseResult.Erorr(ex.Message));
            }
        }
    }
}
