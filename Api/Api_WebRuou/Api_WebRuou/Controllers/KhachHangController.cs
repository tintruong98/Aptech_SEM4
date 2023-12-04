using Api_WebRuou.Core.Response;
using Api_WebRuou.Dtos.KhachHang;
using Api_WebRuou.Infrastucture.DBContext;
using Api_WebRuou.Infrastucture.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_WebRuou.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KhachHangController : Controller
    {
        private readonly DBContext _dbContext;

        public KhachHangController(DBContext db)
        {
            _dbContext = db;
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAllKhachHang()
        {
            var result = await _dbContext.KhachHangs.ToListAsync();
            return Ok(ResponseResult.Success(result));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetKhachHang(int id)
        {
            var result = await _dbContext.KhachHangs.FindAsync(id);
            return Ok(ResponseResult.Success(result));
        }

       

        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteKhachHang(int id)
        {
            var khachhang = await _dbContext.KhachHangs.FindAsync(id);      
            _dbContext.Remove(khachhang);
            await _dbContext.SaveChangesAsync();
            return Ok(ResponseResult.Success(""));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> updateKhacHang(int id, KhachHangDto kh)
        {
            var khachhang = await  _dbContext.KhachHangs.FindAsync(id);        
            khachhang.Address = kh.Address;
            khachhang.Email = kh.Email;
            khachhang.Status = kh.Status;
            khachhang.UserName = kh.UserName;

            _dbContext.KhachHangs.Update(khachhang);
            await _dbContext.SaveChangesAsync();
            return Ok(ResponseResult.Success(""));
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> createKhachHang(KhachHangDto kh)
        {
            var khachhang = new KhachHang();
            khachhang.Address = kh.Address;
            khachhang.Email = kh.Email;
            khachhang.Status = kh.Status;
            khachhang.UserName = kh.UserName;
            khachhang.Password = kh.Password;

            _dbContext.KhachHangs.Add(khachhang);
            _dbContext.SaveChanges();
            return Ok(ResponseResult.Success(khachhang));
        }
    }
}
