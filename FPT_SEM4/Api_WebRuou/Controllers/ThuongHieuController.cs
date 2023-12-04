using Api_WebRuou.Core.Response;
using Api_WebRuou.Dtos.ThuongHieu;
using Api_WebRuou.Infrastucture.DataBaseContext;
using Api_WebRuou.Infrastucture.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_WebRuou.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ThuongHieuController : Controller
    {
        private readonly ApiDbContext _dbContext;
        public ThuongHieuController(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        //-----
        [HttpGet]
        public async Task<IEnumerable<ThuongHieu>> GetThuongHieuAll()
        {
            return await _dbContext.ThuongHieus.ToListAsync();
        }
        //-----
        [HttpGet("{id}")]
        public async Task<ThuongHieu> GetThuongHieuOne(int id)
        {
            return await _dbContext.ThuongHieus.FindAsync(id);
        }
        //-----
        [HttpPut]
        public async Task<bool> editThuongHieu(ThuongHieu varTable)
        {
            var model = await _dbContext.ThuongHieus.FindAsync(varTable.Id);
            if (model != null)
            {
                model.Id = varTable.Id;
                model.Name = varTable.Name;
                model.Description = varTable.Description;
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
        //-----
        [HttpPost]
        public async Task<bool> addThuongHieu(ThuongHieu varTable)
        {
            var model = await _dbContext.ThuongHieus.FindAsync(varTable.Id);
            if (model == null)
            {
                await _dbContext.ThuongHieus.AddAsync(varTable);
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
        public async Task<bool> DeleteThuongHieu(int varLocal)
        {
            var pList = await _dbContext.ThuongHieus.FindAsync(varLocal);
            if (pList != null)
            {
                _dbContext.ThuongHieus.Remove(pList);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }


        //-------------------------------------------------------------------------
        //-------------------------------------------------------------------------
        //-------------------------------------------------------------------------
        //-------------------------------------------------------------------------



        //[HttpGet]
        //[Route("all")]
        //public async Task<IActionResult> AllThuongHieu()
        //{
        //    try
        //    {
        //        var result = await _dbContext.ThuongHieus.ToListAsync();
        //        return Ok(ResponseResult.Success(result));
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(ResponseResult.Erorr(ex.Message));
        //    }
        //}

        //[HttpGet]
        //[Route("getbyid/{id}")]
        //public async Task<IActionResult> GetThuongHieuById(int id)
        //{
        //    try
        //    {
        //        var result = await _dbContext.ThuongHieus.FindAsync(id);
        //        return Ok(ResponseResult.Success(result));
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(ResponseResult.Erorr(ex.Message));
        //    }
        //}

        //[HttpPost]
        //[Route("create")]
        //public async Task<IActionResult> CreateThuongHieu(ThuongHieuDto dto)
        //{
        //    try
        //    {
        //        var thuongHieu = new ThuongHieu()
        //        {
        //            Name = dto.Name,
        //            Description = dto.Description
        //        };

        //        await _dbContext.ThuongHieus.AddAsync(thuongHieu);
        //        await _dbContext.SaveChangesAsync();
        //        return Ok(ResponseResult.Success(thuongHieu));
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(ResponseResult.Erorr(ex.Message));
        //    }
        //}

        //[HttpPost]
        //[Route("update")]
        //public async Task<IActionResult> EditThuongHieu(int id,ThuongHieuDto dto)
        //{
        //    try
        //    {
        //        var thuongHieu = await _dbContext.ThuongHieus.FindAsync(id);
        //        thuongHieu.Name = dto.Name;
        //        thuongHieu.Description= dto.Description;
        //        _dbContext.ThuongHieus.Update(thuongHieu);
        //        await _dbContext.SaveChangesAsync();
        //        return Ok(ResponseResult.Success(thuongHieu));
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(ResponseResult.Erorr(ex.Message));
        //    }
        //}

        //[HttpGet]
        //[Route("delete/{id}")]
        //public async Task<IActionResult> DeleteThuongHieu(int id)
        //{
        //    try
        //    {
        //        var thuongHieu = await _dbContext.ThuongHieus.FindAsync(id);
        //        _dbContext.ThuongHieus.Remove(thuongHieu);
        //        await _dbContext.SaveChangesAsync();
        //        return Ok(ResponseResult.Success(""));
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(ResponseResult.Erorr(ex.Message));
        //    }
        //}
    }
}
