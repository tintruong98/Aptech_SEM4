using Api_WebRuou.Core.Response;
using Api_WebRuou.Dtos.SanPham;
using Api_WebRuou.Infrastucture.DBContext;
using Api_WebRuou.Infrastucture.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_WebRuou.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SanPhamController : Controller
    {
        private readonly DBContext _dbContext;
        public SanPhamController(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> AllSanPham()
        {
            try
            {
                var result = await _dbContext.SanPhams.ToListAsync();
                return Ok(ResponseResult.Success(result));
            }
            catch(Exception ex) 
            {
                return Ok(ResponseResult.Erorr(ex.Message));
            }
        }

        [HttpGet]
        [Route("getbyid")]
        public async Task<IActionResult> GetSanPhamById(string id)
        {
            try
            {
                var result = await _dbContext.SanPhams.FindAsync(id);
                return Ok(ResponseResult.Success(result));
            }
            catch (Exception ex)
            {
                return Ok(ResponseResult.Erorr(ex.Message));
            }
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateSanPham(SanPhamDto dto)
        {
            try
            {
                var sanpham = new SanPham()
                {
                    Name = dto.Name,
                    Description = dto.Description,
                    UrlImage = dto.UrlImage,
                    Promotion = dto.Promotion,
                };

                await _dbContext.SanPhams.AddAsync(sanpham);
                await _dbContext.SaveChangesAsync();
                return Ok(ResponseResult.Success(sanpham));
            }
            catch (Exception ex)
            {
                return Ok(ResponseResult.Erorr(ex.Message));
            }
        }

        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> EditSanPham(SanPham dto)
        {
            try
            {
                var sanpham = await _dbContext.SanPhams.FindAsync(dto.Id);
                sanpham.Name = dto.Name;
                sanpham.Description = dto.Description;
                sanpham.UrlImage = dto.UrlImage;
                sanpham.Promotion = dto.Promotion;

                _dbContext.SanPhams.Update(sanpham);
                await _dbContext.SaveChangesAsync();
                return Ok(ResponseResult.Success(sanpham));
            }
            catch (Exception ex)
            {
                return Ok(ResponseResult.Erorr(ex.Message));
            }
        }

        [HttpPost]
        [Route("delete")]
        public async Task<IActionResult> DeleteSanPham(int id)
        {
            try
            {
                var sanpham = await _dbContext.SanPhams.FindAsync(id);              
                _dbContext.SanPhams.Remove(sanpham);
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
