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
    public class ThuongHieuController : Controller
    {
        private const string url = "http://localhost:7134/api/";
        private string url_ThuongHieu = url + "ThuongHieu";
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
        public IActionResult ListThuongHieu(string varLocal)
        {
            SaveSession();
            if (string.IsNullOrEmpty(ViewBag.UserName_))
            {
                return RedirectToAction("Login", "User");
            }
            var model = JsonConvert.DeserializeObject<IEnumerable<ThuongHieu>>(httpClient.GetStringAsync(url_ThuongHieu).Result);
            if (varLocal != null)
            {
                model = model.Where(u => u.Name.Contains(varLocal)).ToList();
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
        public IActionResult Create(ThuongHieu varTable)
        {
            SaveSession();
            try
            {
                ThuongHieu rs = JsonConvert.DeserializeObject<ThuongHieu>(httpClient.GetStringAsync(url_ThuongHieu + "/" + varTable.Id).Result);
                if (rs != null)
                {
                    ViewBag.msg = "Id already has a registered account!!!";
                }
                else
                {
                    var model = httpClient.PostAsJsonAsync<ThuongHieu>(url_ThuongHieu, varTable).Result;
                    if (model.IsSuccessStatusCode)
                    {
                        return RedirectToAction("ListThuongHieu", "ThuongHieu");
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
            var model = JsonConvert.DeserializeObject<ThuongHieu>(httpClient.GetStringAsync(url_ThuongHieu + "/" + varLocal).Result);
            return View(model);
        }
        //-----
        [HttpPost]
        public IActionResult Edit(ThuongHieu varTable)
        {
            SaveSession();
            ThuongHieu account = JsonConvert.DeserializeObject<ThuongHieu>(httpClient.GetStringAsync(url_ThuongHieu + "/" + varTable.Id).Result);
            if (account != null)
            {
                var model = httpClient.PutAsJsonAsync<ThuongHieu>(url_ThuongHieu, varTable).Result;
                if (ModelState.IsValid && model.IsSuccessStatusCode)
                {
                    return RedirectToAction("ListThuongHieu", "ThuongHieu");
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
            var model = JsonConvert.DeserializeObject<ThuongHieu>(httpClient.GetStringAsync(url_ThuongHieu + "/" + varLocal).Result);
            ViewBag.name = model.Name;
            return View(model);
        }
        //-----
        [HttpPost]
        public IActionResult Delete(ThuongHieu varTable)
        {
            SaveSession();
            ViewBag.name = varTable.Name;
            var model = httpClient.DeleteAsync(url_ThuongHieu + "/" + varTable.Id).Result;
            if (model.IsSuccessStatusCode)
            {
                return RedirectToAction("ListThuongHieu", "ThuongHieu");
            }
            else
            {
                ViewBag.msg = "Delete failed !!!";
            }
            return View();
        }
        //-----
    }
}
