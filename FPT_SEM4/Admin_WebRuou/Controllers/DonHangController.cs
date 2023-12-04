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

namespace Admin_WebRuou.Controllers
{
    public class DonHangController : Controller
    {
        private const string url = "http://localhost:7134/api/";
        private string url_DonHang = url + "DonHang";
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
        public IActionResult ListDonHang(string iddonhang,string trangthaigh, string dathanhtoan,string username, string phone)
        {
            SaveSession();
            if (string.IsNullOrEmpty(ViewBag.UserName_))
            {
                return RedirectToAction("Login", "User");
            }
            var model = JsonConvert.DeserializeObject<IEnumerable<DonHangDetails>>(httpClient.GetStringAsync(url_KhachHang+ "/xemdonhangdetails").Result);
            if (iddonhang != null)
            {
                model = model.Where(u => u.Id == int.Parse(iddonhang)).ToList();
            }
            if (trangthaigh != null)
            {
                model = model.Where(u => u.TrangThaiGH == int.Parse(trangthaigh)).ToList();
            }
            if (dathanhtoan != null)
            {
                model = model.Where(u => u.DaThanhToan.ToString() == dathanhtoan).ToList();
            }
            if (username != null)
            {
                model = model.Where(u => u.UserName.ToLower().Contains(username.ToLower())).ToList();
            }
            if (phone != null)
            {
                model = model.Where(u => u.Phone == phone).ToList();
            }
            return View(model);
        }
        //-----
        public IActionResult Edit(int varLocal, string username, string email, string address, string phone)
        {
            SaveSession();
            ViewBag.username = username;
            ViewBag.email = email;
            ViewBag.address = address;
            ViewBag.phone = phone;
            var model = JsonConvert.DeserializeObject<DonHang>(httpClient.GetStringAsync(url_DonHang + "/" + varLocal).Result);
            return View(model);
        }
        //-----
        [HttpPost]
        public IActionResult Edit(DonHang varTable, string username, string email, string address, string phone)
        {
            SaveSession();
            ViewBag.username = username;
            ViewBag.email = email;
            ViewBag.address = address;
            ViewBag.phone = phone;
            DonHang account = JsonConvert.DeserializeObject<DonHang>(httpClient.GetStringAsync(url_DonHang + "/" + varTable.Id).Result);
            if (account != null)
            {
                if (varTable.TrangThaiGH==2)
                {
                    varTable.DaThanhToan = true;
                }
                var model = httpClient.PutAsJsonAsync<DonHang>(url_DonHang, varTable).Result;
                if (ModelState.IsValid && model.IsSuccessStatusCode)
                {
                    return RedirectToAction("ListDonHang", "DonHang");
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
            var model = JsonConvert.DeserializeObject<DonHang>(httpClient.GetStringAsync(url_DonHang + "/" + varLocal).Result);
            return View(model);
        }
        //-----
        [HttpPost]
        public IActionResult Delete(DonHang varTable)
        {
            SaveSession();
            var model = httpClient.DeleteAsync(url_DonHang + "/" + varTable.Id).Result;
            if (model.IsSuccessStatusCode)
            {
                return RedirectToAction("ListDonHang", "DonHang");
            }
            else
            {
                ViewBag.msg = "Delete failed !!!";
            }
            return View();
        }
        //-----
        public IActionResult CapnhatTrangthaiGH()
        {
            SaveSession();
            var model = JsonConvert.DeserializeObject<DonHang>(httpClient.GetStringAsync(url_DonHang).Result);
            return View(model);
        }
        //-----
        [HttpPost]
        public IActionResult CapnhatTrangthaiGH(DonHang varTable, IFormFile file)
        {
            SaveSession();
            DonHang account = JsonConvert.DeserializeObject<DonHang>(httpClient.GetStringAsync(url_DonHang + "/" + varTable.Id).Result);
            if (account != null)
            {
                var model = httpClient.PutAsJsonAsync<DonHang>(url_DonHang, varTable).Result;
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
    }
}
