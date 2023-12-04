using Api_WebRuou.Core.Response;
using Api_WebRuou.Dtos.SanPham;
using Api_WebRuou.Infrastucture.DataBaseContext;
using Api_WebRuou.Infrastucture.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_WebRuou.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SanPhamController : Controller
    {
        private readonly ApiDbContext _dbContext;
        public SanPhamController(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        //-----
        [HttpGet]
        public async Task<IEnumerable<SanPham>> GetSanPhamAll()
        {
            return await _dbContext.SanPhams.ToListAsync();
        }
        //-----
        [HttpGet("{id}")]
        public async Task<SanPham> GetSanPhamOne(int id)
        {
            return await _dbContext.SanPhams.FindAsync(id);
        }
        //-----
        [HttpPut]
        public async Task<bool> editSanPham(SanPham varTable)
        {
            var model = await _dbContext.SanPhams.FindAsync(varTable.Id);
            if (model != null)
            {
                model.Id = varTable.Id;
                model.Name = varTable.Name;
                model.Description = varTable.Description;
                model.UrlImage = varTable.UrlImage;
                model.Price = varTable.Price;
                model.Promotion = varTable.Promotion;
                model.Soluong = varTable.Soluong;
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
        //-----
        [HttpPost]
        public async Task<bool> addSanPham(SanPham varTable)
        {
            var model = await _dbContext.SanPhams.FindAsync(varTable.Id);
            if (model == null)
            {
                await _dbContext.SanPhams.AddAsync(varTable);
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
        public async Task<bool> DeleteSanPham(int varLocal)
        {
            var pList = await _dbContext.SanPhams.FindAsync(varLocal);
            if (pList != null)
            {
                _dbContext.SanPhams.Remove(pList);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
        //-----
        [HttpGet]
        [Route("kiemtrasanpham/{idsanpham}")]
        public async Task<IEnumerable<ChiTietDonHang>> KiemtraSanPham(int idsanpham)
        {
            var model = await (from dh in _dbContext.ChiTietDonHangs
                             where dh.IdSanPham == idsanpham
                             select dh
                       ).ToListAsync();

            return model;
        }




        //-------------------------------------------------------------------------
        //-------------------------------------------------------------------------
        //-------------------------------------------------------------------------
        //-------------------------------------------------------------------------

        //[HttpGet]
        //[Route("all")]
        //public async Task<IActionResult> AllSanPham()
        //{
        //    try
        //    {
        //        var result = await _dbContext.SanPhams.ToListAsync();
        //        return Ok(ResponseResult.Success(result));
        //    }
        //    catch(Exception ex) 
        //    {
        //        return Ok(ResponseResult.Erorr(ex.Message));
        //    }
        //}

        //[HttpGet]
        //[Route("getbyid/{id}")]
        //public async Task<IActionResult> GetSanPhamById(int id)
        //{
        //    try
        //    {
        //        var result = await _dbContext.SanPhams.FindAsync(id);
        //        return Ok(ResponseResult.Success(result));
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(ResponseResult.Erorr(ex.Message));
        //    }
        //}

        //[HttpPost]
        //[Route("create")]
        //public async Task<IActionResult> CreateSanPham(SanPhamDto dto)
        //{
        //    try
        //    {
        //        var sanpham = new SanPham()
        //        {
        //            Name = dto.Name,
        //            Description = dto.Description,
        //            UrlImage = dto.UrlImage,
        //            Price = dto.Price,
        //            Promotion = dto.Promotion,
        //            Soluong= dto.Soluong
        //        };

        //        await _dbContext.SanPhams.AddAsync(sanpham);
        //        await _dbContext.SaveChangesAsync();
        //        return Ok(ResponseResult.Success(sanpham));
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(ResponseResult.Erorr(ex.Message));
        //    }
        //}

        //[HttpPost]
        //[Route("update")]
        //public async Task<IActionResult> EditSanPham(int id,SanPhamDto dto)
        //{
        //    try
        //    {
        //        var sanpham = await _dbContext.SanPhams.FindAsync(id);
        //        sanpham.Name = dto.Name;
        //        sanpham.Description = dto.Description;
        //        sanpham.UrlImage = dto.UrlImage;
        //        sanpham.Price = dto.Price;
        //        sanpham.Promotion = dto.Promotion;
        //        sanpham.Soluong = dto.Soluong;

        //        _dbContext.SanPhams.Update(sanpham);
        //        await _dbContext.SaveChangesAsync();
        //        return Ok(ResponseResult.Success(sanpham));
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(ResponseResult.Erorr(ex.Message));
        //    }
        //}

        //[HttpGet]
        //[Route("delete/{id}")]
        //public async Task<IActionResult> DeleteSanPham(int id)
        //{
        //    try
        //    {
        //        var sanpham = await _dbContext.SanPhams.FindAsync(id);              
        //        _dbContext.SanPhams.Remove(sanpham);
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
