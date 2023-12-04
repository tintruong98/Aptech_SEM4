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
using System.Reflection;

namespace Admin_WebRuou.Controllers
{
    public class SanPhamController : Controller
    {
        private const string url = "http://localhost:7134/api/";
        private string url_SanPham = url + "SanPham";
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
        public IActionResult ListSanPham(string varLocal, string idsanpham)
        {
            SaveSession();
            if (string.IsNullOrEmpty(ViewBag.UserName_))
            {
                return RedirectToAction("Login", "User");
            }
            var model = JsonConvert.DeserializeObject<IEnumerable<SanPham>>(httpClient.GetStringAsync(url_SanPham).Result);
            if (idsanpham != null)
            {
                model = model.Where(u => u.Id == int.Parse(idsanpham)).ToList();
            }
            if (varLocal != null)
            {
                model = model.Where(u => u.Name.ToLower().Contains(varLocal.ToLower())).ToList();
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
        public IActionResult Create(SanPham varTable, IFormFile file)
        {
            SaveSession();
            try
            {
                SanPham rs = JsonConvert.DeserializeObject<SanPham>(httpClient.GetStringAsync(url_SanPham + "/" + varTable.Id).Result);
                if (rs != null)
                {
                    ViewBag.msg = "Id already has a registered account!!!";
                }
                else
                {
                    //Truong hop co load hinh anh
                    if (file != null)
                    {
                        string filePath = Path.Combine("wwwroot/Images", file.FileName);
                        var stream = new FileStream(filePath, FileMode.Create);
                        file.CopyTo(stream);
                        stream.Close();
                        varTable.UrlImage = "Images/" + file.FileName;
                    }
                    else
                    {
                        varTable.UrlImage = "Images/search.png";
                    }
                    //Ket thuc Truong hop co load hinh anh

                    var model = httpClient.PostAsJsonAsync<SanPham>(url_SanPham, varTable).Result;
                    if (model.IsSuccessStatusCode)
                    {
                        return RedirectToAction("ListSanPham", "SanPham");
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
            var model = JsonConvert.DeserializeObject<SanPham>(httpClient.GetStringAsync(url_SanPham + "/" + varLocal).Result);
            return View(model);
        }
        //-----
        [HttpPost]
        public IActionResult Edit(SanPham varTable, IFormFile file)
        {
            SaveSession();
            SanPham account = JsonConvert.DeserializeObject<SanPham>(httpClient.GetStringAsync(url_SanPham + "/" + varTable.Id).Result);
            if (account != null)
            {
                // Truong hop co load hinh anh
                if (file != null)
                {
                    string filePath = Path.Combine("wwwroot/Images", file.FileName);
                    var stream = new FileStream(filePath, FileMode.Create);
                    file.CopyTo(stream);
                    stream.Close();
                    varTable.UrlImage = "Images/" + file.FileName;
                }
                // Ket thuc Truong hop co load hinh anh

                var model = httpClient.PutAsJsonAsync<SanPham>(url_SanPham, varTable).Result;
                if (ModelState.IsValid && model.IsSuccessStatusCode)
                {
                    return RedirectToAction("ListSanPham", "SanPham");
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
            var model = JsonConvert.DeserializeObject<SanPham>(httpClient.GetStringAsync(url_SanPham + "/" + varLocal).Result);
            ViewBag.name = model.Name;
            ViewBag.urlimage = model.UrlImage;
            return View(model);
        }
        //-----
        [HttpPost]
        public IActionResult Delete(SanPham varTable)
        {
            SaveSession();
            ViewBag.name = varTable.Name;
            ViewBag.urlimage = varTable.UrlImage;
            var ktsp = JsonConvert.DeserializeObject<IEnumerable<ChiTietDonHang>>(httpClient.GetStringAsync(url_SanPham + "/kiemtrasanpham/" + varTable.Id).Result);
            if (ktsp.Count()>0)
            {
                ViewBag.msg = "The product cannot be deleted !!!";
                return View();
            }
            var model = httpClient.DeleteAsync(url_SanPham + "/" + varTable.Id).Result;
            if (model.IsSuccessStatusCode)
            {
                return RedirectToAction("ListSanPham", "SanPham");
            }
            else
            {
                ViewBag.msg = "Delete failed !!!";
            }
            return View();
        }
        //-----
        public IActionResult ThongkeSanPham()
        {
            SaveSession();
            if (string.IsNullOrEmpty(ViewBag.UserName_))
            {
                return RedirectToAction("Login", "User");
            }
            var model = JsonConvert.DeserializeObject<IEnumerable<SanPham>>(httpClient.GetStringAsync(url_SanPham).Result);
            return View(model);
        }
        //-----
        public IActionResult SanPhamBanNhieu()
        {
            SaveSession();
            if (string.IsNullOrEmpty(ViewBag.UserName_))
            {
                return RedirectToAction("Login", "User");
            }
            var model = JsonConvert.DeserializeObject<IEnumerable<SanPhamFavourite>>(httpClient.GetStringAsync(url_KhachHang + "/sanphamlike").Result);
            model = model.Where(x=>x.Tongmua>1).ToList();
            return View(model);
        }
        //-----
        public IActionResult SanPhamYeuThich()
        {
            SaveSession();
            if (string.IsNullOrEmpty(ViewBag.UserName_))
            {
                return RedirectToAction("Login", "User");
            }
            var model = JsonConvert.DeserializeObject<IEnumerable<SanPhamFavourite>>(httpClient.GetStringAsync(url_KhachHang + "/sanphamlike").Result);
            model = model.Where(x => x.Evaluate==5).ToList();
            return View(model);
        }

        //-----






    }
}
