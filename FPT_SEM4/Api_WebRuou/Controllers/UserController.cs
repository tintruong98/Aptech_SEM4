using Api_WebRuou.Dtos.Admin;
using Api_WebRuou.Core.Response;
using Api_WebRuou.Infrastucture.DataBaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api_WebRuou.Infrastucture.Entities;

namespace Api_WebRuou.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly ApiDbContext _dbContext;
        public UserController(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        //-----
        [HttpGet]
        public async Task<IEnumerable<User>> GetUserAll()
        {
            return await _dbContext.Users.ToListAsync();
        }
        //-----
        [HttpGet("{id}")]
        public async Task<User> GetUserOne(int id)
        {
            return await _dbContext.Users.FindAsync(id);
        }
        //-----
        [HttpGet]
        [Route("login/{varLocal1}/{varLocal2}")]
        public async Task<User> checkLogin(string varLocal1, string varLocal2)
        {
            var result = await _dbContext.Users.Where(x => x.Email.Equals(varLocal1) && x.Password.Equals(varLocal2)).FirstOrDefaultAsync();
            return result;
        }
        //-----
        [HttpGet]
        [Route("mail/{varLocal}")]
        public async Task<User> GetEmail(string varLocal)
        {
            var result = await _dbContext.Users.Where(x => x.Email.Equals(varLocal)).FirstOrDefaultAsync();
            return result;
        }
        //-----
        [HttpPut]
        public async Task<bool> editUser(User varTable)
        {
            var model = await _dbContext.Users.FindAsync(varTable.Id);
            if (model != null)
            {
                model.Id = varTable.Id;
                model.UserName = varTable.UserName;
                model.Email = varTable.Email;
                model.Password = varTable.Password;
                model.Status = varTable.Status;
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
        //-----
        [HttpPost]
        public async Task<bool> addUser(User varTable)
        {
            var model = await _dbContext.Users.FindAsync(varTable.Id);
            if (model == null)
            {
                await _dbContext.Users.AddAsync(varTable);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }
        //-----
        [HttpDelete("{varLocal}")]
        public async Task<bool> DeleteUser(int varLocal)
        {
            var pList = await _dbContext.Users.FindAsync(varLocal);
            if (pList != null)
            {
                _dbContext.Users.Remove(pList);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }





        //[HttpPost]
        //[Route("login")]
        //public async Task<IActionResult> Login(LoginDto dto)
        //{
        //    var result = await _dbContext.Users.Where(x => x.Email == dto.Email && x.Password == dto.Password).FirstOrDefaultAsync();
        //    if(result == null)
        //    {
        //        throw new Exception("Tài khoản or mật khẩu không đúng.");
        //    }
        //    else
        //    {
        //        return Ok(ResponseResult.Success(result));
        //    }    
        //}

        //[HttpGet]
        //[Route("all_User")]
        //public async Task<IActionResult> AllUser()
        //{
        //    try
        //    {
        //        var result = await _dbContext.Users.ToListAsync();
        //        return Ok(ResponseResult.Success(result));
        //    }
        //    catch(Exception ex) 
        //    {
        //        return Ok(ResponseResult.Erorr(ex.Message));
        //    }
        //}

        //[HttpPost]
        //[Route("get_Userbyid")]
        //public async Task<IActionResult> GetUserById(int id)
        //{
        //    try
        //    {
        //        var result = await _dbContext.Users.Where(x=> x.Id == id).FirstOrDefaultAsync();
        //        return Ok(ResponseResult.Success(result));
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(ResponseResult.Erorr(ex.Message));
        //    }
        //}


    }
}
