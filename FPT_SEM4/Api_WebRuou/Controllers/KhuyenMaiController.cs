using Api_WebRuou.Core.Response;
using Api_WebRuou.Dtos.KhuyenMai;
using Api_WebRuou.Dtos.ThuongHieu;
using Api_WebRuou.Infrastucture.DataBaseContext;
using Api_WebRuou.Infrastucture.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_WebRuou.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class KhuyenMaiController : Controller
    {
        private readonly ApiDbContext _dbContext;
        public KhuyenMaiController(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAllKM()
        {
            try
            {
                var result = await _dbContext.KhuyenMais.ToListAsync();
                return Ok(ResponseResult.Success(result));
            }
            catch (Exception ex) 
            {
                return Ok(ResponseResult.Erorr(ex.Message));
            }
          
        }

        [HttpGet]
        [Route("getbyid/{id}")]
        public async Task<IActionResult> GetKMById(int id)
        {
            try
            {
                var result = await _dbContext.KhuyenMais.FindAsync(id);
                return Ok(ResponseResult.Success(result));
            }
            catch (Exception ex)
            {
                return Ok(ResponseResult.Erorr(ex.Message));
            }
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateKM(KhuyenMaiDto dto)
        {
            try
            {
                var km = new KhuyenMai()
                {
                    Name = dto.Name,
                    Description = dto.Description,
                    FromDate = dto.FromDate,
                    ToDate = dto.ToDate
                };
                await _dbContext.KhuyenMais.AddAsync(km);
                await _dbContext.SaveChangesAsync();
                return Ok(ResponseResult.Success(km));
            }
            catch (Exception ex)
            {
                return Ok(ResponseResult.Erorr(ex.Message));
            }

        }

        [HttpGet]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteKMById(int id)
        {
            try
            {
                var result = await _dbContext.KhuyenMais.FindAsync(id);
                _dbContext.KhuyenMais.Remove(result);
                await _dbContext.SaveChangesAsync();
                return Ok(ResponseResult.Success(""));
            }
            catch (Exception ex)
            {
                return Ok(ResponseResult.Erorr(ex.Message));
            }
        }
    }
}
