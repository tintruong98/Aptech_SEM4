using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System;
using Admin_WebRuou.Services;
using Admin_WebRuou.Models;
using System.Linq;
using Admin_WebRuou.Models;

namespace Admin_WebRuou.Controllers
{
    public class KhachHangController : Controller
    {
        private const string url = "http://localhost:7134/api/";
        private string url_KhachHang = url + "KhachHang";

        private HttpClient httpClient = new HttpClient();
        FServices fServices = new FServices();
        //-----
        public void SaveSession()
        {
            if (HttpContext.Session.GetString("Id_") != null)
            {
                ViewBag.Id_ = HttpContext.Session.GetString("Id_");
            }
            if (HttpContext.Session.GetString("UserName_") != null)
            {
                ViewBag.UserName_ = HttpContext.Session.GetString("UserName_");
            }
            if (HttpContext.Session.GetString("Email_") != null)
            {
                ViewBag.Email_ = HttpContext.Session.GetString("Email_");
            }
            if (HttpContext.Session.GetString("Password_") != null)
            {
                ViewBag.Password_ = HttpContext.Session.GetString("Password_");
            }
            if (HttpContext.Session.GetString("Status_") != null)
            {
                ViewBag.Status_ = HttpContext.Session.GetString("Status_");
            }

            //-----
            StreamReader sr = new StreamReader("wwwroot/Visitor.txt");
            int cnt = 0;
            string cnt_ = sr.ReadToEnd().Trim();
            cnt = int.Parse(cnt_);
            sr.Close();
            ViewData["count"] = cnt;
            if (HttpContext.Session.GetString("visitor") == null)
            {
                HttpContext.Session.SetString("visitor", cnt_);
                cnt++;
                StreamWriter sw = new StreamWriter("wwwroot/Visitor.txt");
                sw.Write(cnt);
                sw.Flush();
                sw.Close();
                ViewData["count"] = cnt;
            }
            ViewData["Date"] = fServices.NgayThangNam();
        }
        //-----
        public IActionResult ListKhachHang(string varLocal)
        {
            SaveSession();
            if (string.IsNullOrEmpty(ViewBag.UserName_))
            {
                return RedirectToAction("Login", "User");
            }
            var model = JsonConvert.DeserializeObject<IEnumerable<KhachHang>>(httpClient.GetStringAsync(url_KhachHang).Result);
            if (varLocal != null)
            {
                model = model.Where(u => u.UserName.Contains(varLocal)).ToList();
            }
            return View(model);
        }
        //-----
        [HttpGet]
        public IActionResult Create()
        {
            SaveSession();
            return View();
        }
        [HttpPost]
        public IActionResult Create(KhachHang varTable)
        {
            SaveSession();
            try
            {
                KhachHang rs = JsonConvert.DeserializeObject<KhachHang>(httpClient.GetStringAsync(url_KhachHang + "/" + varTable.Id).Result);
                if (rs != null)
                {
                    ViewBag.msg = "Id already has a registered account!!!";
                }
                else
                {
                    var model = httpClient.PostAsJsonAsync<KhachHang>(url_KhachHang, varTable).Result;
                    if (model.IsSuccessStatusCode)
                    {
                        return RedirectToAction("ListKhachHang", "KhachHang");
                    }
                    else
                    {
                        ViewBag.msg = "Infomation is invalid!";
                    }
                }
            }
            catch (Exception e)
            {
                ViewBag.msg = e.Message;
            }
            return View();
        }
        //-----
        public IActionResult Edit(int varLocal)
        {
            SaveSession();
            var model = JsonConvert.DeserializeObject<KhachHang>(httpClient.GetStringAsync(url_KhachHang + "/" + varLocal).Result);
            return View(model);
        }
        //-----
        [HttpPost]
        public IActionResult Edit(KhachHang varTable, IFormFile file)
        {
            SaveSession();
            KhachHang account = JsonConvert.DeserializeObject<KhachHang>(httpClient.GetStringAsync(url_KhachHang + "/" + varTable.Id).Result);
            if (account != null)
            {
                var model = httpClient.PutAsJsonAsync<KhachHang>(url_KhachHang, varTable).Result;
                if (ModelState.IsValid && model.IsSuccessStatusCode)
                {
                    return RedirectToAction("ListKhachHang", "KhachHang");
                }
                else
                {
                    ViewBag.msg = "Update failed!";
                }
            }
            else
            {
                ViewBag.msg = "Update failed !!!";
            }
            return View();
        }
        //-----
        public IActionResult Delete(int varLocal)
        {
            SaveSession();
            var model = JsonConvert.DeserializeObject<KhachHang>(httpClient.GetStringAsync(url_KhachHang + "/" + varLocal).Result);
            ViewBag.username = model.UserName;
            ViewBag.email = model.Email;
            return View(model);
        }
        //-----
        [HttpPost]
        public IActionResult Delete(KhachHang varTable)
        {
            SaveSession();
            ViewBag.username = varTable.UserName;
            ViewBag.email = varTable.Email;
            var ktsp = JsonConvert.DeserializeObject<IEnumerable<DonHang>>(httpClient.GetStringAsync(url_KhachHang + "/kiemtrakhachhang/" + varTable.Id).Result);
            if (ktsp.Count() > 0)
            {
                ViewBag.msg = "Customers cannot delete !!!";
                return View();
            }
            var model = httpClient.DeleteAsync(url_KhachHang + "/" + varTable.Id).Result;
            if (model.IsSuccessStatusCode)
            {
                return RedirectToAction("ListKhachHang", "KhachHang");
            }
            else
            {
                ViewBag.msg = "Delete failed !!!";
            }
            return View();
        }
        //-----
        [HttpGet]
        public IActionResult XemDonHang(int trangthaiGH, int idkhachhang, string username)
        {
            SaveSession();
            if (string.IsNullOrEmpty(ViewBag.UserName_))
            {
                return RedirectToAction("Login", "User");
            }
            var model = JsonConvert.DeserializeObject<IEnumerable<DonHangImage>>(httpClient.GetStringAsync(url_KhachHang + "/xemdonhangimage/" + idkhachhang.ToString()).Result);
            if (trangthaiGH == null)
            {
                trangthaiGH = 2;
            }
            ViewBag.trangthaiGH = trangthaiGH;
            ViewBag.username = username;
            ViewBag.idkhachhang = idkhachhang;
            var res = model.Where(x => x.TrangThaiGH == trangthaiGH).ToList();
            if (res.Count() == 0)
            {
                ViewBag.msg = "No orders yet!";
            }
            return View(res);
        }
        //-----
        [HttpGet]
        public IActionResult XemChiTieDonHang(int varLocal, int trangthaiGH, int idkhachhang, string username)
        {
            SaveSession();
            if (string.IsNullOrEmpty(ViewBag.UserName_))
            {
                return RedirectToAction("Login", "KhachHang");
            }
            ViewBag.username = username;
            ViewBag.idkhachhang = idkhachhang;
            ViewBag.ttgh = trangthaiGH;
            var model = JsonConvert.DeserializeObject<IEnumerable<DetailsDonHang>>(httpClient.GetStringAsync(url_KhachHang + "/chitietdonhang/" + varLocal).Result);
            int ts = 0;
            foreach (var item in model)
            {
                ts = ts + item.ThanhTien;
            }
            ViewBag.Tonggiatri = ts.ToString("N").Substring(0, ts.ToString("N").Length - 3);

            if (trangthaiGH == 0)
            {
                ViewBag.trangthaiGH = "Goods are being prepared";
            }
            if (trangthaiGH == 1)
            {
                ViewBag.trangthaiGH = "Delivery in progress";
            }
            if (trangthaiGH == 2)
            {
                ViewBag.trangthaiGH = "Delivery successful";
                ViewBag.evaluate = "OK";
            }
            if (trangthaiGH == 3)
            {
                ViewBag.trangthaiGH = "Order has been cancelled";
            }
            return View(model);
        }
        //-----
        [HttpGet]
        public IActionResult XemDanhgia(int iddonhang, int idsanpham, string urlimage, int idkhachhang, string username, string back)
        {
            SaveSession();
            ViewBag.iddonhang = iddonhang;
            ViewBag.idsanpham = idsanpham;
            ViewBag.urlimage = urlimage;
            ViewBag.idkhachhang = idkhachhang;
            ViewBag.username = username;
            if (back!=null)
            {
                ViewBag.back = back;
            }
            var model = JsonConvert.DeserializeObject<FeedBack>(httpClient.GetStringAsync(url_KhachHang + "/getdanhgia/" + idkhachhang.ToString() + "/" + iddonhang.ToString() + "/" + idsanpham.ToString()).Result);
            if (model == null)
            {
                FeedBack rs = new FeedBack()
                {
                    Id = 0,
                    IdKhachHang = idkhachhang,
                    IdDonHang = iddonhang,
                    IdSanPham = idsanpham,
                    Contents = "The order has not been evaluated by the customer",
                    ThoiGianFeed = "",
                    Evaluate = 0
                };
                return View(rs);
            }
            return View(model);
        }
        //-----
        [HttpGet]
        public IActionResult ThongkeSPBanra(DateTime tungay, DateTime denngay)
        {
            SaveSession();
            if (string.IsNullOrEmpty(ViewBag.UserName_))
            {
                return RedirectToAction("Login", "KhachHang");
            }
            //--
            if (tungay.Year == 1)
            {
                ViewBag.tungay = String.Format("{0:MM-dd-yyyy HH:mm:ss}", DateTime.Now);
            }
            else
            {
                ViewBag.tungay = String.Format("{0:MM-dd-yyyy HH:mm:ss}", tungay);
            }
            if (denngay.Year == 1)
            {
                ViewBag.denngay = String.Format("{0:MM-dd-yyyy HH:mm:ss}", DateTime.Now);
            }
            else
            {
                ViewBag.denngay = String.Format("{0:MM-dd-yyyy HH:mm:ss}", denngay);
            }

            string tungay_ = "";
            string denngay_ = "";
            if (tungay.Year == 1 && denngay.Year == 1)
            {
                tungay_ = String.Format("{0:yyyy-MM-dd}", DateTime.Now);
                denngay_ = String.Format("{0:yyyy-MM-dd}", DateTime.Now);
            }
            if (tungay.Year == 1 && denngay.Year > 1)
            {
                tungay_ = String.Format("{0:yyyy-MM-dd}", tungay);
                denngay_ = String.Format("{0:yyyy-MM-dd}", denngay);

            }
            if (tungay.Year > 1 && denngay.Year == 1)
            {
                tungay_ = String.Format("{0:yyyy-MM-dd}", tungay);
                denngay_ = tungay_;
            }
            if (tungay.Year > 1 && denngay.Year > 1)
            {
                tungay_ = String.Format("{0:yyyy-MM-dd}", tungay);
                denngay_ = String.Format("{0:yyyy-MM-dd}", denngay);
            }
            string from_ = tungay_.Substring(0, 4) + tungay_.Substring(5, 2) + tungay_.Substring(8, 2);
            string to_ = denngay_.Substring(0, 4) + denngay_.Substring(5, 2) + denngay_.Substring(8, 2);
            if (int.Parse(from_) > int.Parse(to_))
            {
                denngay_ = tungay_;
                from_ = tungay_.Substring(0, 4) + tungay_.Substring(5, 2) + tungay_.Substring(8, 2);
                to_ = denngay_.Substring(0, 4) + denngay_.Substring(5, 2) + denngay_.Substring(8, 2);
            }
            if (tungay_ == denngay_)
            {
                ViewBag.ngaybc = "As of "+denngay_;
            }
            else
            {
                ViewBag.ngaybc = "From " + tungay_ + " to " + denngay_;
            }
            var model = JsonConvert.DeserializeObject<IEnumerable<DetailsDonHang>>(httpClient.GetStringAsync(url_KhachHang + "/thongkespbanra/" + from_ + "/" + to_).Result);
            int ts = 0;
            foreach (var item in model)
            {
                ts = ts + item.ThanhTien;
            }
            ViewBag.Tonggiatri = ts.ToString("N").Substring(0, ts.ToString("N").Length - 3);
            return View(model);
        }
        //-----
        [HttpGet]
        public IActionResult NhanXetKhachHang(string evaluate, string username, string phone)
        {
            SaveSession();
            if (string.IsNullOrEmpty(ViewBag.UserName_))
            {
                return RedirectToAction("Login", "User");
            }
            var model = JsonConvert.DeserializeObject<IEnumerable<FeedBackDetails>>(httpClient.GetStringAsync(url_KhachHang + "/xemfeedbackdetails").Result);
            if (evaluate !=null)
            {
                model = model.Where(x => x.Evaluate == int.Parse(evaluate));
            }
            if (username != null)
            {
                model = model.Where(x => x.UserName.ToLower().Contains(username.ToLower()));
            }
            if (phone != null)
            {
                model = model.Where(x => x.Phone == phone);
            }
            return View(model);
        }
        //-----

        //-----
    }
}
