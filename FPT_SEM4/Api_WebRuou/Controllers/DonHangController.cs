using Api_WebRuou.Core.Response;
using Api_WebRuou.Infrastucture;
using Api_WebRuou.Infrastucture.DataBaseContext;
using Api_WebRuou.Infrastucture.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using static Api_WebRuou.Core.Enums.Enums;

namespace Api_WebRuou.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DonHangController : Controller
    {

        private readonly ApiDbContext _dbContext;
        private static List<GioHang> giohang = new List<GioHang>();
        public DonHangController(ApiDbContext db)
        {
            _dbContext = db;
        }
        //-----
        [HttpGet]
        public async Task<IEnumerable<DonHang>> GetDonHangAll()
        {
            var result = await (from tb in _dbContext.DonHangs
                                orderby tb.NgayDat descending
                                select tb).ToListAsync();
            return result;
            //return await _dbContext.DonHangs.ToListAsync();
        }
        //-----
        [HttpGet("{id}")]
        public async Task<DonHang> GetDonHangOne(int id)
        {
            return await _dbContext.DonHangs.FindAsync(id);
        }
        //-----
        [HttpPut]
        public async Task<bool> editDonHang(DonHang varTable)
        {
            var model = await _dbContext.DonHangs.FindAsync(varTable.Id);
            if (model != null)
            {
                model.Id = varTable.Id;
                model.IdKhachHang = varTable.IdKhachHang;
                model.DaThanhToan = varTable.DaThanhToan;
                model.NgayDat = varTable.NgayDat;
                model.NgayGiao = varTable.NgayGiao;
                model.SoLuong = varTable.SoLuong;
                model.TongTien = varTable.TongTien;
                model.TrangThaiGH = varTable.TrangThaiGH;

                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
        //-----
        [HttpPost]
        public async Task<bool> addDonHang(DonHang varTable)
        {
            var model = await _dbContext.DonHangs.FindAsync(varTable.Id);
            if (model == null)
            {
                await _dbContext.DonHangs.AddAsync(varTable);
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
        public async Task<bool> DeleteDonHang(int varLocal)
        {
            var pList = await _dbContext.DonHangs.FindAsync(varLocal);
            if (pList != null)
            {
                _dbContext.DonHangs.Remove(pList);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        //[HttpGet]
        //[Route("all")]
        //public async Task<IActionResult> AllDonHang()
        //{
        //    try
        //    {
        //        var result = await _dbContext.DonHangs.ToListAsync();
        //        return Ok(ResponseResult.Success(result));
        //    }
        //    catch(Exception ex)
        //    {
        //        return Ok(ResponseResult.Erorr(ex.Message));
        //    }
        //}

        //[HttpGet]
        //[Route("getbyid/{id}")]
        //public async Task<IActionResult> ChiTietDH(int id)
        //{
        //    try
        //    {
        //        var result = await _dbContext.ChiTietDonHangs.Where(x=> x.IdDonHang == id).ToListAsync();
        //        return Ok(ResponseResult.Success(result));
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(ResponseResult.Erorr(ex.Message));
        //    }
        //}

        //[HttpPost]
        //[Route("create")]      
        //public async Task<IActionResult> ThemGioHang(int Ma)
        //{
        //    try
        //    {
        //        if (giohang.Count == 0)
        //        {
        //            var sanPham =  InitGioHang(Ma);          
        //            giohang.Add(sanPham);
        //        }
        //        else
        //        {
        //            var existSp = giohang.FirstOrDefault(x => x.IdSanPham == Ma);
        //            if (existSp != null)
        //            {
        //                existSp.SoLuong = existSp.SoLuong + 1;
        //            }
        //            else
        //            {
        //                var sanPham =  InitGioHang(Ma);
        //                giohang.Add(sanPham);
        //            }
        //        }
        //        return Ok(ResponseResult.Success(giohang));
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(ResponseResult.Erorr(ex.Message));
        //    }
        //}

        //private GioHang InitGioHang(int Masp)
        //{
        //    GioHang gio = new GioHang();
        //    gio.IdSanPham = Masp;
        //    var sp =  _dbContext.SanPhams.Where(x => x.Id == Masp).FirstOrDefault();
        //    gio.Ten = sp.Name;
        //    gio.Url = sp.UrlImage;
        //    gio.DonGia = sp.Price;
        //    gio.SoLuong = 1;
        //    return gio;
        //}

        //[HttpPost]
        //[Route("dathang")]
        //public async Task<IActionResult> DatHang(int IdKh)
        //{
        //    var donHang = new DonHang();
        //    donHang.IdKhachHang = IdKh;
        //    donHang.NgayDat = DateTime.UtcNow.ToString();
        //    donHang.NgayGiao = DateTime.UtcNow.AddHours(72).ToString();
        //    donHang.DaThanhToan = false;
        //    donHang.TrangThaiGH = 1;
        //    donHang.SoLuong = giohang.Sum(x => x.SoLuong);
        //    donHang.TongTien = giohang.Sum(x => x.Tongtien);
        //    await _dbContext.DonHangs.AddAsync(donHang);
        //    await _dbContext.SaveChangesAsync();

        //    foreach(var item in giohang)
        //    {
        //        var ctdh = new ChiTietDonHang();
        //        ctdh.IdDonHang = donHang.Id;
        //        ctdh.IdSanPham = item.IdSanPham;
        //        ctdh.SoLuong = item.SoLuong;
        //        ctdh.GiaTien = item.DonGia;
        //        await _dbContext.ChiTietDonHangs.AddAsync(ctdh);
        //        await _dbContext.SaveChangesAsync();
        //    }
        //    giohang.Clear();
        //    return Ok(ResponseResult.Success(""));
        //}

        //[HttpGet]
        //[Route("xoagiohang")]
        //public async Task<IActionResult> XoaGioHang( )
        //{
        //    giohang.Clear();
        //    return Ok(ResponseResult.Success(""));
        //}

        //[HttpGet]
        //[Route("thanhatoan")]
        //public async Task<IActionResult> ThanhToanDonHang(int idDh)
        //{
        //    try
        //    {
        //        var donhang = await _dbContext.DonHangs.FindAsync(idDh);
        //        donhang.DaThanhToan = true;
        //        _dbContext.DonHangs.Update(donhang);
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
