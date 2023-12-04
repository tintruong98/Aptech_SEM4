using App_WebRuou.Models;
using App_WebRuou.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace App_WebRuou.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        //-----
        private const string url = "http://localhost:7134/api/";
        private string url_KhachHang = url + "KhachHang";
        private HttpClient httpClient = new HttpClient();
        //-----
        public void SaveSession()
        {
            FServices fServices = new FServices();
            //-----
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
            if (HttpContext.Session.GetString("Address_") != null)
            {
                ViewBag.Address_ = HttpContext.Session.GetString("Address_");
            }
            if (HttpContext.Session.GetString("Phone_") != null)
            {
                ViewBag.Phone_ = HttpContext.Session.GetString("Phone_");
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

            if (string.IsNullOrEmpty(ViewBag.Id_))
            {
                ViewBag.slgiohang = 0;
            }
            else
            {
                int idkhachhangc = int.Parse(ViewBag.Id_);
                var ktcart = JsonConvert.DeserializeObject<Cart>(httpClient.GetStringAsync(url_KhachHang + "/demgiohang/" + idkhachhangc.ToString()).Result);
                if (ktcart != null)
                {
                    ViewBag.slgiohang = ktcart.SoLuong;
                }
                else
                {
                    ViewBag.slgiohang = 0;
                }
            }
        }

        public IActionResult Index()
        {
            SaveSession();
            int idkhachhang;
            if (string.IsNullOrEmpty(ViewBag.Id_))
            {
                idkhachhang = 0;
            }
            else
            {
                idkhachhang = int.Parse(ViewBag.Id_);
            }
            PartialView1 partialView= new PartialView1();
            var donhang = JsonConvert.DeserializeObject<IEnumerable<DonHangImage>>(httpClient.GetStringAsync(url_KhachHang + "/xemdonhangimage/" + idkhachhang.ToString()).Result);
            var sanpham = JsonConvert.DeserializeObject<IEnumerable<SanPhamFavourite>>(httpClient.GetStringAsync(url_KhachHang + "/sanphamlike").Result);
            partialView.pv1 = donhang;
            partialView.pv2 = sanpham;
            return View(partialView);
        }
        public IActionResult Profile()
        {
            SaveSession();
            if (string.IsNullOrEmpty(ViewBag.UserName_))
            {
                return RedirectToAction("Login", "KhachHang");
            }
            int idkhachhang;
            if (string.IsNullOrEmpty(ViewBag.Id_))
            {
                idkhachhang = 0;
            }
            else
            {
                idkhachhang = int.Parse(ViewBag.Id_);
            }
            PartialView1 partialView = new PartialView1();
            var donhang = JsonConvert.DeserializeObject<IEnumerable<DonHangImage>>(httpClient.GetStringAsync(url_KhachHang + "/xemdonhangimage/" + idkhachhang.ToString()).Result);
            var sanpham = JsonConvert.DeserializeObject<IEnumerable<SanPhamFavourite>>(httpClient.GetStringAsync(url_KhachHang + "/sanphamlike").Result);
            partialView.pv1 = donhang;
            partialView.pv2 = sanpham;
            return View(partialView);
        }
        public IActionResult Xemdonmuanhieu()
        {
            SaveSession();
            return View();
        }
        
        public IActionResult Privacy()
        {
            SaveSession();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
