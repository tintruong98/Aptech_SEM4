using Api_WebRuou.Dtos.Admin;
using Api_WebRuou.Core.Response;
using Api_WebRuou.Infrastucture.DBContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api_WebRuou.Infrastucture.Entities;

namespace Api_WebRuou.Controllers
{
    public class UserController : Controller
    {
        private readonly DBContext _dbContext;
        public UserController(DBContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var result = await _dbContext.Users.Where(x => x.UserName == dto.Username && x.Password == dto.Password).FirstOrDefaultAsync();
            if(result == null)
            {
                throw new Exception("Tài khoản or mật khẩu không đúng.");
            }
            else
            {
                return Ok(ResponseResult.Success(result));
            }    
        }

        [HttpGet]
        [Route("all_khachhang")]
        public async Task<IActionResult> AllKhachHang()
        {
            try
            {
                var result = await _dbContext.KhachHangs.ToListAsync();
                return Ok(ResponseResult.Success(result));
            }
            catch(Exception ex) 
            {
                return Ok(ResponseResult.Erorr(ex.Message));
            }
        }

        [HttpPost]
        [Route("get_khachhangbyid")]
        public async Task<IActionResult> GetKhachHangById(string id)
        {
            try
            {
                var result = await _dbContext.KhachHangs.Where(x=> x.Id == id).FirstOrDefaultAsync();
                return Ok(ResponseResult.Success(result));
            }
            catch (Exception ex)
            {
                return Ok(ResponseResult.Erorr(ex.Message));
            }
        }

       
    }
}
