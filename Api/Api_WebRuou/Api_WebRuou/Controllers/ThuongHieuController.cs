using Api_WebRuou.Core.Response;
using Api_WebRuou.Dtos.SanPham;
using Api_WebRuou.Dtos.ThuongHieu;
using Api_WebRuou.Infrastucture.DBContext;
using Api_WebRuou.Infrastucture.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_WebRuou.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ThuongHieuController : Controller
    {
        private readonly DBContext _dbContext;
        public ThuongHieuController(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> AllThuongHieu()
        {
            try
            {
                var result = await _dbContext.ThuongHieus.ToListAsync();
                return Ok(ResponseResult.Success(result));
            }
            catch (Exception ex)
            {
                return Ok(ResponseResult.Erorr(ex.Message));
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetThuongHieuById(string id)
        {
            try
            {
                var result = await _dbContext.ThuongHieus.FindAsync(id);
                return Ok(ResponseResult.Success(result));
            }
            catch (Exception ex)
            {
                return Ok(ResponseResult.Erorr(ex.Message));
            }
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateThuongHieu(ThuongHieuDto dto)
        {
            try
            {
                var thuongHieu = new ThuongHieu()
                {
                    Name = dto.Name,
                    Description = dto.Description
                };

                await _dbContext.ThuongHieus.AddAsync(thuongHieu);
                await _dbContext.SaveChangesAsync();
                return Ok(ResponseResult.Success(thuongHieu));
            }
            catch (Exception ex)
            {
                return Ok(ResponseResult.Erorr(ex.Message));
            }
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> EditThuongHieu(string id,ThuongHieuDto dto)
        {
            try
            {
                var thuongHieu = await _dbContext.ThuongHieus.FindAsync(id);
                thuongHieu.Name = dto.Name;
                _dbContext.ThuongHieus.Update(thuongHieu);
                await _dbContext.SaveChangesAsync();
                return Ok(ResponseResult.Success(thuongHieu));
            }
            catch (Exception ex)
            {
                return Ok(ResponseResult.Erorr(ex.Message));
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteThuongHieu(int id)
        {
            try
            {
                var thuongHieu = await _dbContext.SanPhams.FindAsync(id);
                _dbContext.SanPhams.Remove(thuongHieu);
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
