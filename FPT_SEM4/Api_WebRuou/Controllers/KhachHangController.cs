using Api_WebRuou.Core.Response;
using Api_WebRuou.Dtos.Admin;
using Api_WebRuou.Dtos.KhachHang;
using Api_WebRuou.Infrastucture;
using Api_WebRuou.Infrastucture.DataBaseContext;
using Api_WebRuou.Infrastucture.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using Microsoft.VisualBasic;
using System.Diagnostics.Metrics;
using System.Linq;
using static Api_WebRuou.Core.Enums.Enums;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Api_WebRuou.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KhachHangController : Controller
    {
        private readonly ApiDbContext _dbContext;

        public KhachHangController(ApiDbContext db)
        {
            _dbContext = db;
        }
        //-----
        [HttpGet]
        public async Task<IEnumerable<KhachHang>> GetKhachHangAll()
        {
            return await _dbContext.KhachHangs.ToListAsync();
        }
        //-----
        [HttpGet("{id}")]
        public async Task<KhachHang> GetKhachHangOne(int id)
        {
            return await _dbContext.KhachHangs.FindAsync(id);
        }
        //-----
        [HttpGet]
        [Route("login/{varLocal1}/{varLocal2}")]
        public async Task<KhachHang> checkLogin(string varLocal1, string varLocal2)
        {
            var result = await _dbContext.KhachHangs.Where(x => x.Email.Equals(varLocal1) && x.Password.Equals(varLocal2)).FirstOrDefaultAsync();
            return result;
        }
        //-----
        [HttpGet]
        [Route("mail/{varLocal}")]
        public async Task<KhachHang> GetEmail(string varLocal)
        {
            var result = await _dbContext.KhachHangs.Where(x => x.Email.Equals(varLocal)).FirstOrDefaultAsync();
            return result;
        }
        //-----
        [HttpPut]
        public async Task<bool> editKhachHang(KhachHang varTable)
        {
            var model = await _dbContext.KhachHangs.FindAsync(varTable.Id);
            if (model != null)
            {
                model.Id = varTable.Id;
                model.UserName = varTable.UserName;
                model.Email = varTable.Email;
                model.Password = varTable.Password;
                model.Address = varTable.Address;
                model.Phone = varTable.Phone;
                model.Status = varTable.Status;
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
        //-----
        [HttpPost]
        public async Task<bool> addKhachHang(KhachHang varTable)
        {
            var model = await _dbContext.KhachHangs.FindAsync(varTable.Id);
            if (model == null)
            {
                await _dbContext.KhachHangs.AddAsync(varTable);
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
        public async Task<bool> DeleteKhachHang(int varLocal)
        {
            var pList = await _dbContext.KhachHangs.FindAsync(varLocal);
            if (pList != null)
            {
                _dbContext.KhachHangs.Remove(pList);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
        //-----
        [HttpGet]
        [Route("kiemtrakhachhang/{idkhachhang}")]
        public async Task<IEnumerable<DonHang>> KiemtraKhachHang(int idkhachhang)
        {
            var model = await (from dh in _dbContext.DonHangs
                               where dh.IdKhachHang == idkhachhang
                               select dh
                       ).ToListAsync();

            return model;
        }






        //-----
        [HttpPost("themdonhang")]
        public async Task<bool> addDonHang(DonHang varTable)
        {
            var model = await _dbContext.DonHangs.FindAsync(varTable.Id);
            if (model == null)
            {
                await _dbContext.DonHangs.AddAsync(varTable);
                await _dbContext.SaveChangesAsync();
                //---
                int idKhachhang_ = varTable.IdKhachHang;
                var maxId = _dbContext.DonHangs.Where(w => w.IdKhachHang == idKhachhang_).Max(x => x.Id);
                var res = await _dbContext.DonHangs.FindAsync(maxId);
                int idDonHang_ = res.Id;
                var res2 = await _dbContext.Carts.Where(k => k.IdKhachHang == idKhachhang_).ToListAsync();

                foreach (var item in res2)
                {
                    var ds = new ChiTietDonHang()
                    {
                        IdDonHang = idDonHang_,
                        IdSanPham = item.IdSanPham,
                        SoLuong = item.SoLuong,
                        GiaTien = item.DonGia
                    };
                    await _dbContext.ChiTietDonHangs.AddAsync(ds);
                    await _dbContext.SaveChangesAsync();
                }
                //-----
                var modelxoa = await _dbContext.Carts.Where(x => x.IdKhachHang == idKhachhang_).ToListAsync();
                if (modelxoa != null)
                {
                    foreach (var item in modelxoa)
                    {
                        var modelsp = await _dbContext.SanPhams.FindAsync(item.IdSanPham);
                        modelsp.Soluong = modelsp.Soluong - item.SoLuong;
                        await _dbContext.SaveChangesAsync();
                    }
                    //
                    _dbContext.Carts.RemoveRange(modelxoa);
                    await _dbContext.SaveChangesAsync();
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        //-----
        [HttpGet]
        [Route("getdonhang/{id}")]
        public async Task<DonHang> GetDonHang(int id)
        {
            return await _dbContext.DonHangs.FindAsync(id);
        }
        //-----
        [HttpGet]
        [Route("gethuydonhang/{id}")]
        public async Task<IEnumerable<DonHang>> GetHuyDonHang(int id)
        {
            var result = await (from tb
             in _dbContext.DonHangs
                                where tb.IdKhachHang == id && tb.TrangThaiGH == 0
                                orderby tb.NgayDat descending
                                select tb).ToListAsync();
            return result;
        }
        //-----
        [HttpGet]
        [Route("gethuydonhangimage/{id}")]
        public async Task<IEnumerable<DonHangImage>> GetHuyDonHangImage(int id)
        {
            var result = await (from tb
             in _dbContext.DonHangs
                                where tb.IdKhachHang == id && tb.TrangThaiGH == 0
                                orderby tb.NgayDat descending
                                select tb).ToListAsync();

            List<DonHangImage> donhangs = new List<DonHangImage>();
            foreach (var item in result)
            {
                int iddonhang = item.Id;
                var res = await (from dh in _dbContext.ChiTietDonHangs
                                 join sp in _dbContext.SanPhams
                                 on dh.IdSanPham equals sp.Id
                                 where dh.IdDonHang == iddonhang
                                 orderby dh.IdSanPham
                                 select new
                                 {
                                     IdDonHang = dh.IdDonHang,
                                     IdSanPham = dh.IdSanPham,
                                     SoLuong = dh.SoLuong,
                                     GiaTien = dh.GiaTien,
                                     Name = sp.Name,
                                     Description = sp.Description,
                                     UrlImage = sp.UrlImage,
                                     Promotion = sp.Promotion
                                 }
                                  ).ToListAsync();

                var result3 = res.FirstOrDefault();
                var ds = new DonHangImage()
                {
                    Id = item.Id,
                    IdKhachHang = item.IdKhachHang,
                    DaThanhToan = item.DaThanhToan,
                    NgayDat = item.NgayDat,
                    NgayGiao = item.NgayGiao,
                    SoLuong = item.SoLuong,
                    TongTien = item.TongTien,
                    TrangThaiGH = item.TrangThaiGH,
                    Url = result3.UrlImage
                };
                donhangs.Add(ds);
            }
            return donhangs;
        }
        //-----
        [HttpGet]
        [Route("xemdonhang/{id}")]
        public async Task<IEnumerable<DonHang>> XemDonHang(int id)
        {
            var result = await (from tb
             in _dbContext.DonHangs
                                where tb.IdKhachHang == id
                                orderby tb.NgayDat descending
                                select tb).ToListAsync();
            return result;
        }
        //-----
        [HttpGet]
        [Route("xemdonhangimage/{id}")]
        public async Task<IEnumerable<DonHangImage>> XemDonHangImage(int id)
        {
            var result = await (from tb
             in _dbContext.DonHangs
                                where tb.IdKhachHang == id
                                orderby tb.NgayDat descending
                                select tb).ToListAsync();

            List<DonHangImage> donhangs = new List<DonHangImage>();
            foreach (var item in result)
            {
                int iddonhang = item.Id;
                var res = await (from dh in _dbContext.ChiTietDonHangs
                                 join sp in _dbContext.SanPhams
                                 on dh.IdSanPham equals sp.Id
                                 where dh.IdDonHang == iddonhang
                                 orderby dh.IdSanPham
                                 select new
                                 {
                                     IdDonHang = dh.IdDonHang,
                                     IdSanPham = dh.IdSanPham,
                                     SoLuong = dh.SoLuong,
                                     GiaTien = dh.GiaTien,
                                     Name = sp.Name,
                                     Description = sp.Description,
                                     UrlImage = sp.UrlImage,
                                     Promotion = sp.Promotion
                                 }
                                  ).ToListAsync();

                var result3 = res.FirstOrDefault();
                var ds = new DonHangImage()
                {
                    Id = item.Id,
                    IdKhachHang = item.IdKhachHang,
                    DaThanhToan = item.DaThanhToan,
                    NgayDat = item.NgayDat,
                    NgayGiao = item.NgayGiao,
                    SoLuong = item.SoLuong,
                    TongTien = item.TongTien,
                    TrangThaiGH = item.TrangThaiGH,
                    Url = result3.UrlImage
                };
                donhangs.Add(ds);
            }
            return donhangs;
        }
        //-----
        [HttpGet]
        [Route("xemdonhangdetails")]
        public async Task<IEnumerable<DonHangDetails>> XemDonHangDetails()
        {
            var result = await (from dh in _dbContext.DonHangs
                                join kh in _dbContext.KhachHangs
                                on dh.IdKhachHang equals kh.Id
                                orderby dh.NgayDat descending
                                select new
                                {
                                    Id = dh.Id,
                                    IdKhachHang = dh.IdKhachHang,
                                    DaThanhToan = dh.DaThanhToan,
                                    NgayDat = dh.NgayDat,
                                    NgayGiao = dh.NgayGiao,
                                    SoLuong = dh.SoLuong,
                                    TongTien = dh.TongTien,
                                    TrangThaiGH = dh.TrangThaiGH,
                                    UserName = kh.UserName,
                                    Email = kh.Email,
                                    Address = kh.Address,
                                    Phone = kh.Phone
                                }
                              ).ToListAsync();
            List<DonHangDetails> donhangs = new List<DonHangDetails>();
            foreach (var item in result)
            {
                var ds = new DonHangDetails()
                {
                    Id = item.Id,
                    IdKhachHang = item.IdKhachHang,
                    DaThanhToan = item.DaThanhToan,
                    NgayDat = item.NgayDat,
                    NgayGiao = item.NgayGiao,
                    SoLuong = item.SoLuong,
                    TongTien = item.TongTien,
                    TrangThaiGH = item.TrangThaiGH,
                    UserName = item.UserName,
                    Email = item.Email,
                    Address = item.Address,
                    Phone = item.Phone
                };
                donhangs.Add(ds);
            }
            return donhangs;
        }
        //-----
        [HttpGet]
        [Route("chitietdonhang/{id}")]
        public async Task<IEnumerable<DetailsDonHang>> ChiTietDonHang(int id)
        {
            var res = await (from dh in _dbContext.ChiTietDonHangs
                             join sp in _dbContext.SanPhams
                             on dh.IdSanPham equals sp.Id
                             where dh.IdDonHang == id
                             orderby dh.IdSanPham
                             select new
                             {
                                 IdDonHang = dh.IdDonHang,
                                 IdSanPham = dh.IdSanPham,
                                 SoLuong = dh.SoLuong,
                                 GiaTien = dh.GiaTien,
                                 Name = sp.Name,
                                 Description = sp.Description,
                                 UrlImage = sp.UrlImage,
                                 Promotion = sp.Promotion
                             }
                       ).ToListAsync();

            List<DetailsDonHang> model = new List<DetailsDonHang>();
            foreach (var item in res)
            {
                var ds = new DetailsDonHang()
                {
                    IdDonHang = item.IdDonHang,
                    IdSanPham = item.IdSanPham,
                    SoLuong = item.SoLuong,
                    GiaTien = item.GiaTien,
                    ThanhTien = item.SoLuong * item.GiaTien,
                    Name = item.Name,
                    Description = item.Description,
                    UrlImage = item.UrlImage,
                    Promotion = item.Promotion
                };
                model.Add(ds);
            }
            return model;
        }
        //-----
        [HttpGet]
        [Route("thongkespbanra/{tungay}/{denngay}")]
        public async Task<IEnumerable<DetailsDonHang>> ThongkeSPBanra(string tungay, string denngay)
        {
            int tungay_ = int.Parse(tungay);
            int denngay_ = int.Parse(denngay);

            var res = await (from dh in _dbContext.ChiTietDonHangs
                             join sp in _dbContext.DonHangs
                             on dh.IdDonHang equals sp.Id
                             where sp.TrangThaiGH == 2 && sp.DaThanhToan == true
                             orderby dh.IdSanPham
                             select new
                             {
                                 Id = dh.Id,
                                 IdDonhang = dh.IdDonHang,
                                 IdSanPham = dh.IdSanPham,
                                 SoLuong = dh.SoLuong,
                                 GiaTien = dh.GiaTien,
                                 NgayBan = int.Parse(sp.NgayGiao.Substring(0, 4) + sp.NgayGiao.Substring(5, 2) + sp.NgayGiao.Substring(8, 2))
                             }
                       ).ToListAsync();

            var res1 = (from dh in res
                        join sp in _dbContext.SanPhams
                        on dh.IdSanPham equals sp.Id
                        where dh.NgayBan >= tungay_ && dh.NgayBan <= denngay_
                        orderby dh.IdSanPham
                        select new
                        {
                            IdDonhang = dh.IdDonhang,
                            IdSanPham = dh.IdSanPham,
                            Name = sp.Name,
                            SoLuong = dh.SoLuong,
                            GiaTien = dh.GiaTien,
                            NgayBan = dh.NgayBan
                        }
                       ).ToList();

            var res2 = (from tb in res1
                        group tb by new { tb.IdSanPham, tb.Name, tb.GiaTien } into tg
                        select new
                        {
                            IdSanPham = tg.Key.IdSanPham,
                            Name = tg.Key.Name,
                            GiaTien = tg.Key.GiaTien,
                            SoLuong = tg.Sum(tu => tu.SoLuong)
                        }
                    ).ToList();

            List<DetailsDonHang> model = new List<DetailsDonHang>();
            foreach (var item in res2)
            {
                var ds = new DetailsDonHang()
                {
                    IdDonHang = 0,
                    IdSanPham = item.IdSanPham,
                    SoLuong = item.SoLuong,
                    GiaTien = item.GiaTien,
                    ThanhTien = item.SoLuong * item.GiaTien,
                    Name = item.Name,
                    Description = "",
                    UrlImage = "",
                    Promotion = 0
                };
                model.Add(ds);
            }
            return model;



            //&& int.Parse(sp.NgayGiao.Substring(0, 4) + sp.NgayGiao.Substring(5, 2) + sp.NgayGiao.Substring(8, 2)) >= tungay_
            //&& int.Parse(sp.NgayGiao.Substring(0, 4) + sp.NgayGiao.Substring(5, 2) + sp.NgayGiao.Substring(8, 2)) <= denngay_

            //var res = await (from dh in _dbContext.ChiTietDonHangs
            //                  join sp in _dbContext.DonHangs
            //                  on dh.IdDonHang equals sp.Id
            //                 where sp.TrangThaiGH==2 && sp.DaThanhToan == true
            //                 orderby dh.IdSanPham
            //                  select new
            //                  {
            //                      Id = dh.Id,
            //                      IdDonhang = dh.IdDonHang,
            //                      IdSanPham = dh.IdSanPham,
            //                      SoLuong = dh.SoLuong,
            //                      GiaTien = dh.GiaTien
            //                  }
            //           ).ToListAsync();

            //var res1 = (from dh in res
            //                  join sp in _dbContext.SanPhams
            //                  on dh.IdSanPham equals sp.Id
            //                  orderby dh.IdSanPham
            //                  select new
            //                  {
            //                      IdSanPham = dh.IdSanPham,
            //                      Name = sp.Name,
            //                      SoLuong = dh.SoLuong,
            //                      GiaTien = dh.GiaTien
            //                  }
            //           ).ToList();

            //var res2 = (from tb in res1
            //            group tb by new { tb.IdSanPham, tb.Name, tb.GiaTien } into tg
            //            select new
            //            {
            //                IdSanPham = tg.Key.IdSanPham,
            //                Name = tg.Key.Name,
            //                GiaTien = tg.Key.GiaTien,
            //                SoLuong = tg.Sum(tu => tu.SoLuong)
            //            }
            //        ).ToList();

            //List<DetailsDonHang> model = new List<DetailsDonHang>();
            //foreach (var item in res2)
            //{
            //    var ds = new DetailsDonHang()
            //    {
            //        IdDonHang = 0,
            //        IdSanPham = item.IdSanPham,
            //        SoLuong = item.SoLuong,
            //        GiaTien = item.GiaTien,
            //        ThanhTien = item.SoLuong * item.GiaTien,
            //        Name = item.Name,
            //        Description = "",
            //        UrlImage = "",
            //        Promotion = 0
            //    };
            //    model.Add(ds);
            //}
            //return model;
        }
        //-----
        [HttpGet("sanpham")]
        public async Task<IEnumerable<SanPham>> GetSanPhamAll()
        {
            return await _dbContext.SanPhams.ToListAsync();
        }
        //-----
        [HttpGet("sanphamlike")]
        public async Task<IEnumerable<SanPhamFavourite>> SanPhamLike()
        {
            var contents = await (from tb in _dbContext.FeedBacks
                                  where tb.Contents.Trim().Length> 0
                                  orderby tb.Contents.Trim().Length descending 
                                 select tb).ToListAsync();

            var sanpham = await _dbContext.SanPhams.ToListAsync();
            var tongmua = await (from tb
             in _dbContext.ChiTietDonHangs
                                 group tb by new { tb.IdSanPham } into tg
                                 select new
                                 {
                                     IdSanPham = tg.Key.IdSanPham,
                                     SoLuong = tg.Sum(tu => tu.SoLuong)
                                 }
                                ).ToListAsync();


            var evaluate = await (from tb
             in _dbContext.FeedBacks
                                  group tb by new { tb.IdSanPham } into tg
                                  select new
                                  {
                                      IdSanPham = tg.Key.IdSanPham,
                                      Evaluate = tg.Average(tu => tu.Evaluate)
                                  }
                               ).ToListAsync();
            List<SanPhamFavourite> sanPhamFavourite = new List<SanPhamFavourite>();
            foreach (var item in sanpham)
            {
                var ds = new SanPhamFavourite()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    UrlImage = item.UrlImage,
                    Price = item.Price,
                    Promotion = item.Promotion,
                    Soluong = item.Soluong
                };
                foreach (var tm in tongmua)
                {
                    if (tm.IdSanPham.Equals(item.Id))
                    {
                        ds.Tongmua = tm.SoLuong;
                        break;
                    }
                    else
                    {
                        ds.Tongmua = 0;
                    }
                }
                foreach (var ev in evaluate)
                {
                    if (ev.IdSanPham.Equals(item.Id))
                    {
                        ds.Evaluate = (int)ev.Evaluate;
                        break;
                    }
                    else
                    {
                        ds.Evaluate = 0;
                    }
                }
                foreach (var ev in contents)
                {
                    if (ev.IdSanPham.Equals(item.Id))
                    {
                        ds.Contents = ev.Contents;
                        break;
                    }
                    else
                    {
                        ds.Contents = "";
                    }
                }
                sanPhamFavourite.Add(ds);
            }
            var model = (from tb in sanPhamFavourite
                         orderby tb.Tongmua descending
                         select tb).ToList();

            return model;
        }
        //-----
        [HttpGet("searchsanpham/{varLocal}")]
        public async Task<IEnumerable<SanPham>> SearchSanPham(string varLocal)
        {
            var result = await (from tb
             in _dbContext.SanPhams
                                where tb.Name.ToLower().Trim().Contains(varLocal.ToLower().Trim())
                                select tb).ToListAsync();
            return result;
        }
        //-----
        [HttpGet("sanpham/{varLocal}")]
        public async Task<SanPham> GetSanPhamOne(int varLocal)
        {
            return await _dbContext.SanPhams.FindAsync(varLocal);
        }
        //-----
        [HttpGet]
        [Route("xemgiohang/{varLocal}")]
        public async Task<IEnumerable<Cart>> XemGioHang(int varLocal)
        {
            var result = await (from tb
             in _dbContext.Carts
                                where tb.IdKhachHang == varLocal
                                select tb).ToListAsync();
            return result;
        }
        //-----
        [HttpGet]
        [Route("demgiohang/{varLocal}")]
        public async Task<Cart> DemGioHang(int varLocal)
        {

            var res = await (from tb
             in _dbContext.Carts
                             where tb.IdKhachHang == varLocal
                             group tb by new { tb.IdKhachHang } into tg
                             select new
                             {
                                 IdKhachHang = tg.Key.IdKhachHang,
                                 SoLuong = tg.Sum(tu => tu.SoLuong),
                                 Tongtien = tg.Sum(tu => tu.Tongtien)
                             }
                                ).FirstOrDefaultAsync();
            Cart model = new Cart();
            if (res != null)
            {
                model.Id = varLocal;
                model.IdKhachHang = varLocal;
                model.IdSanPham = 1;
                model.Ten = "";
                model.Url = "";
                model.SoLuong = res.SoLuong;
                model.DonGia = 0;
                model.Tongtien = res.Tongtien;
            }
            return model;
        }
        //-----
        [HttpGet]
        [Route("demsanpham/{varLocal1}/{varLocal2}")]
        public async Task<Cart> DemSanPham(int varLocal1, int varLocal2)
        {
            var res = await (from tb
             in _dbContext.Carts
                             where tb.IdKhachHang == varLocal1 && tb.IdSanPham == varLocal2
                             select tb).FirstOrDefaultAsync();

            return res;
        }
        //-----
        [HttpPost("themgiohang")]
        public async Task<bool> addCart(Cart varTable)
        {
            var model = await _dbContext.Carts.FindAsync(varTable.Id);
            if (model == null)
            {
                await _dbContext.Carts.AddAsync(varTable);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }
        //-----
        [HttpPut("luugiohang")]
        public async Task<bool> editCart(Cart varTable)
        {
            var model = await _dbContext.Carts.FindAsync(varTable.Id);
            if (model != null)
            {
                model.Id = varTable.Id;
                model.IdKhachHang = varTable.IdKhachHang;
                model.IdSanPham = varTable.IdSanPham;
                model.Ten = varTable.Ten;
                model.Url = varTable.Url;
                model.SoLuong = varTable.SoLuong;
                model.DonGia = varTable.DonGia;
                model.Tongtien = varTable.SoLuong * varTable.DonGia;
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
        //-----
        [HttpDelete("xoagiohang/{varLocal}")]
        public async Task<bool> deleteCart(int varLocal)
        {
            var model = await _dbContext.Carts.FindAsync(varLocal);
            if (model != null)
            {
                _dbContext.Carts.Remove(model);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
        //-----
        [HttpPut]
        [Route("huydonhang")]
        public async Task<bool> HuyDonHang(DonHang varTable)
        {
            var donhang = await _dbContext.DonHangs.FindAsync(varTable.Id);
            if (donhang != null)
            {
                donhang.Id = varTable.Id;
                donhang.IdKhachHang = varTable.IdKhachHang;
                donhang.DaThanhToan = varTable.DaThanhToan;
                donhang.NgayDat = varTable.NgayDat;
                donhang.NgayGiao = varTable.NgayGiao;
                donhang.SoLuong = varTable.SoLuong;
                donhang.TongTien = varTable.TongTien;
                donhang.TrangThaiGH = 3;
                await _dbContext.SaveChangesAsync();
                //-----
                var chitietdonhang = await (from dh in _dbContext.ChiTietDonHangs
                                            join sp in _dbContext.SanPhams
                                            on dh.IdSanPham equals sp.Id
                                            where dh.IdDonHang == donhang.Id
                                            orderby dh.IdSanPham
                                            select new
                                            {
                                                IdDonHang = dh.IdDonHang,
                                                IdSanPham = dh.IdSanPham,
                                                SoLuong = dh.SoLuong,
                                                GiaTien = dh.GiaTien,
                                                Name = sp.Name,
                                                Description = sp.Description,
                                                UrlImage = sp.UrlImage,
                                                Promotion = sp.Promotion
                                            }
                           ).ToListAsync();

                foreach (var item in chitietdonhang)
                {
                    var modelsp = await _dbContext.SanPhams.FindAsync(item.IdSanPham);
                    modelsp.Soluong = modelsp.Soluong + item.SoLuong;
                    await _dbContext.SaveChangesAsync();
                }
                return true;
            }
            return false;
        }
        //-----
        [HttpGet]
        [Route("getdanhgia/{idkhachhang}/{iddonhang}/{idsanpham}")]
        public async Task<FeedBack> GetDanhgia(int idkhachhang, int iddonhang, int idsanpham)
        {
            var res = await (from tb
             in _dbContext.FeedBacks
                             where tb.IdKhachHang == idkhachhang && tb.IdDonHang == iddonhang && tb.IdSanPham == idsanpham
                             select tb).FirstOrDefaultAsync();

            return res;
        }
        //-----
        [HttpPost("setdanhgia")]
        public async Task<bool> addFeedBack(FeedBack varTable)
        {
            var model = await _dbContext.FeedBacks.FindAsync(varTable.Id);
            if (model == null)
            {
                await _dbContext.FeedBacks.AddAsync(varTable);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }
        //-----
        [HttpGet]
        [Route("xemfeedbackdetails")]
        public async Task<IEnumerable<FeedBackDetails>> XemFeedBackDetails()
        {
            var result1 = await (from dh in _dbContext.FeedBacks
                                 join kh in _dbContext.KhachHangs
                                 on dh.IdKhachHang equals kh.Id
                                 orderby dh.ThoiGianFeed descending
                                 select new
                                 {
                                     Id = dh.Id,
                                     IdKhachHang = dh.IdKhachHang,
                                     IdDonHang = dh.IdDonHang,
                                     IdSanPham = dh.IdSanPham,
                                     Contents = dh.Contents,
                                     ThoiGianFeed = dh.ThoiGianFeed,
                                     Evaluate = dh.Evaluate,
                                     UserName = kh.UserName,
                                     Email = kh.Email,
                                     Address = kh.Address,
                                     Phone = kh.Phone
                                 }
                              ).ToListAsync();

            var result = (from dh in result1
                          join kh in _dbContext.SanPhams
                          on dh.IdSanPham equals kh.Id
                          select new
                          {
                              Id = dh.Id,
                              IdKhachHang = dh.IdKhachHang,
                              IdDonHang = dh.IdDonHang,
                              IdSanPham = dh.IdSanPham,
                              Contents = dh.Contents,
                              ThoiGianFeed = dh.ThoiGianFeed,
                              Evaluate = dh.Evaluate,
                              UserName = dh.UserName,
                              Email = dh.Email,
                              Address = dh.Address,
                              Phone = dh.Phone,
                              Url = kh.UrlImage
                          }
                              ).ToList();


            List<FeedBackDetails> donhangs = new List<FeedBackDetails>();
            foreach (var item in result)
            {
                var ds = new FeedBackDetails()
                {
                    Id = item.Id,
                    IdKhachHang = item.IdKhachHang,
                    IdDonHang = item.IdDonHang,
                    IdSanPham = item.IdSanPham,
                    Contents = item.Contents,
                    ThoiGianFeed = item.ThoiGianFeed,
                    Evaluate = item.Evaluate,
                    UserName = item.UserName,
                    Email = item.Email,
                    Address = item.Address,
                    Phone = item.Phone,
                    Url = item.Url
                };
                donhangs.Add(ds);
            }
            return donhangs;
        }




        //-----------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------

        //[HttpGet]
        //[Route("all")]
        //public async Task<IActionResult> GetAllKhachHang()
        //{
        //    try
        //    {
        //        var result = await _dbContext.KhachHangs.ToListAsync();
        //        return Ok(ResponseResult.Success(result));
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(ResponseResult.Erorr(ex.Message));
        //    }
        //}

        //[HttpGet("getbyid/{id}")]
        //public async Task<IActionResult> GetKhachHang(int id)
        //{
        //    try
        //    {
        //        var result = await _dbContext.KhachHangs.FindAsync(id);
        //        return Ok(ResponseResult.Success(result));
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(ResponseResult.Erorr(ex.Message));
        //    }
        //}

        //[HttpGet("delete/{id}")]
        //public async Task<IActionResult> deleteKhachHang(int id)
        //{
        //    try
        //    {
        //        var khachhang = await _dbContext.KhachHangs.FindAsync(id);
        //        _dbContext.Remove(khachhang);
        //        await _dbContext.SaveChangesAsync();
        //        return Ok(ResponseResult.Success(""));
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(ResponseResult.Erorr(ex.Message));
        //    }
        //}

        //[HttpPost("update")]
        //public async Task<IActionResult> updateKhacHang(int id, KhachHangDto kh)
        //{
        //    try
        //    {
        //        var khachhang = await _dbContext.KhachHangs.FindAsync(id);
        //        khachhang.Address = kh.Address;
        //        khachhang.Email = kh.Email;
        //        khachhang.Status = Status.IsActive;
        //        khachhang.UserName = kh.UserName;
        //        khachhang.Password = kh.Password;
        //        _dbContext.KhachHangs.Update(khachhang);
        //        await _dbContext.SaveChangesAsync();
        //        return Ok(ResponseResult.Success(""));
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(ResponseResult.Erorr(ex.Message));
        //    }
        //}

        //[HttpPost]
        //[Route("create")]
        //public async Task<IActionResult> createKhachHang(KhachHangDto kh)
        //{
        //    try
        //    {
        //        var khachhang = new KhachHang();
        //        khachhang.Address = kh.Address;
        //        khachhang.Email = kh.Email;
        //        khachhang.Status = Status.IsActive;
        //        khachhang.UserName = kh.UserName;
        //        khachhang.Password = kh.Password;

        //        _dbContext.KhachHangs.Add(khachhang);
        //        _dbContext.SaveChanges();
        //        return Ok(ResponseResult.Success(khachhang));
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(ResponseResult.Erorr(ex.Message));
        //    }
        //}


        //[HttpPost]
        //[Route("lock_open")]
        //public async Task<IActionResult> KhoaMoKhachHang(int id,Status status)
        //{
        //    try
        //    {
        //        var kh = await _dbContext.KhachHangs.FindAsync(id);
        //        if (status == Status.IsActive)
        //        {                   
        //            kh.Status = Status.IsActive;
        //        }
        //        else
        //        {
        //            kh.Status = Status.IsInactive;
        //        }
        //        _dbContext.KhachHangs.Update(kh);
        //        _dbContext.SaveChanges();
        //        return Ok(ResponseResult.Success(""));
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(ResponseResult.Erorr(ex.Message));
        //    }
        //}

        //[HttpGet]
        //[Route("rejectdonhang/{id}")]
        //public async Task<IActionResult> HuyDonHang(int id)
        //{
        //    try
        //    {
        //        var donHang = await _dbContext.DonHangs.FirstOrDefaultAsync(x => x.IdKhachHang == id);
        //        donHang.TrangThaiGH = TrangThaiDH.Reject;
        //        _dbContext.DonHangs.Update(donHang);
        //        await _dbContext.SaveChangesAsync();
        //        return Ok(ResponseResult.Success(""));
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(ResponseResult.Erorr(ex.Message));
        //    }
        //}

        //[HttpGet]
        //[Route("lichsuamua/{id}")]
        //public async Task<IActionResult> LichSuMuaHang(int id)
        //{
        //    try
        //    {
        //        var donHang = await _dbContext.DonHangs.FirstOrDefaultAsync(x => x.IdKhachHang == id);
        //        return Ok(ResponseResult.Success(donHang));
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(ResponseResult.Erorr(ex.Message));
        //    }
        //}

        //[HttpGet]
        //[Route("xemchitiet/{id}")]
        //public async Task<IActionResult> XemChiTiet(int id)
        //{
        //    try
        //    {
        //        var chitietdh = await _dbContext.ChiTietDonHangs.Where(x => x.IdDonHang == id).ToListAsync();
        //        return Ok(ResponseResult.Success(chitietdh));
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(ResponseResult.Erorr(ex.Message));
        //    }
        //}
        //-----
    }
}
