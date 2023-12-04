using App_WebRuou.Models;
using App_WebRuou.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Mail;
using System.Security.Principal;

namespace App_WebRuou.Controllers
{
    public class KhachHangController : Controller
    {
        //------------------------------------------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------------------------------
        private static string link = "http://localhost:6337/";
        //------------------------------------------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------------------------------

        private const string url = "http://localhost:7134/api/";
        private string url_KhachHang = url + "KhachHang";
        private string url_DonHang = url + "DonHang";
        private string url_SanPham = url + "SanPham";

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
        //-----
        [HttpGet]
        public IActionResult Login()
        {
            SaveSession();
            return View();
        }
        //-----
        [HttpPost]
        public IActionResult Login(string varEmail, string varPassword)
        {
            SaveSession();
            try
            {
                if (varEmail == null)
                {
                    ViewBag.msg = "Email cannot be left blank!";
                    return View();
                }
                if (varPassword == null)
                {
                    ViewBag.msg = "Password cannot be left blank!";
                    return View();
                }
                var account = JsonConvert.DeserializeObject<KhachHang>(httpClient.GetStringAsync(url_KhachHang + "/login/" + varEmail + "/" + varPassword).Result);
                if (account != null)
                {
                    if (account.Status==1)
                    {
                        HttpContext.Session.SetString("Id_", account.Id.ToString().Trim());
                        HttpContext.Session.SetString("UserName_", account.UserName.Trim());
                        HttpContext.Session.SetString("Email_", account.Email.Trim());
                        HttpContext.Session.SetString("Password_", account.Password.Trim());
                        HttpContext.Session.SetString("Address_", account.Address.Trim());
                        HttpContext.Session.SetString("Phone_", account.Phone.Trim());
                        HttpContext.Session.SetString("Status_", account.Status.ToString().Trim());
                        ViewBag.Id_ = HttpContext.Session.GetString("Id_");
                        ViewBag.UserName_ = HttpContext.Session.GetString("UserName_");
                        ViewBag.Email_ = HttpContext.Session.GetString("Email_");
                        ViewBag.Password_ = HttpContext.Session.GetString("Password_");
                        ViewBag.Address_ = HttpContext.Session.GetString("Address_");
                        ViewBag.Phone_ = HttpContext.Session.GetString("Phone_");
                        ViewBag.Status_ = HttpContext.Session.GetString("Status_");
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ViewBag.msg = "This account has been locked. Please contact your system administrator to restore!";
                    }
                }
                else
                {
                    ViewBag.msg = "Account not found on system...";
                }
            }
            catch (Exception e)
            {
                ViewBag.msg = e.Message;
            }
            return View();
        }
        //-----
        public IActionResult Logout()
        {
            HttpContext.Session.SetString("Id_", "");
            HttpContext.Session.SetString("UserName_", "");
            HttpContext.Session.SetString("Email_", "");
            HttpContext.Session.SetString("Password_", "");
            HttpContext.Session.SetString("Address_", "");
            HttpContext.Session.SetString("Phone_", "");
            HttpContext.Session.SetString("Status_", "");

            if (HttpContext.Session.GetString("Id_") != null)
            {
                HttpContext.Session.Remove("Id_");
            }
            if (HttpContext.Session.GetString("UserName_") != null)
            {
                HttpContext.Session.Remove("UserName_");
            }
            if (HttpContext.Session.GetString("Email_") != null)
            {
                HttpContext.Session.Remove("Email_");
            }
            if (HttpContext.Session.GetString("Password_") != null)
            {
                HttpContext.Session.Remove("Password_");
            }
            if (HttpContext.Session.GetString("Address_") != null)
            {
                HttpContext.Session.Remove("Address_");
            }
            if (HttpContext.Session.GetString("Phone_") != null)
            {
                HttpContext.Session.Remove("Phone_");
            }
            if (HttpContext.Session.GetString("Status_") != null)
            {
                HttpContext.Session.Remove("Status_");
            }
            HttpContext.Session.Clear();
            ViewBag.Id_ = ViewBag.UserName_ = ViewBag.Email_ = ViewBag.Password_ = ViewBag.Address_ = ViewBag.Phone_ = ViewBag.Status_ = "";
            return RedirectToAction("Login", "KhachHang");
        }
        //-----
        public IActionResult ChangePassword(string varLocal)
        {
            SaveSession();
            if (string.IsNullOrEmpty(ViewBag.UserName_))
            {
                return RedirectToAction("Login", "KhachHang");
            }
            var model = JsonConvert.DeserializeObject<KhachHang>(httpClient.GetStringAsync(url_KhachHang + "/mail/" + varLocal).Result);
            return View(model);
        }
        //-----
        [HttpPost]
        public IActionResult ChangePassword(KhachHang varTable, string oldPass, string newPass, string confirmPass)
        {
            SaveSession();
            if (string.IsNullOrEmpty(ViewBag.UserName_))
            {
                return RedirectToAction("Login", "KhachHang");
            }
            if (string.IsNullOrEmpty(oldPass))
            {
                ViewBag.msg = "oldPass can not be blank !!!";
                return View();
            }
            if (string.IsNullOrEmpty(newPass))
            {
                ViewBag.msg = "newPass can not be blank !!!";
                return View();
            }
            if (newPass != confirmPass)
            {
                ViewBag.msg = "New password and confirm password do not match !!!";
                return View();
            }
            KhachHang account = JsonConvert.DeserializeObject<KhachHang>(httpClient.GetStringAsync(url_KhachHang + "/login/" + varTable.Email + "/" + oldPass).Result);
            if (account != null)
            {
                varTable.Password = newPass.Trim();
                var model = httpClient.PutAsJsonAsync<KhachHang>(url_KhachHang, varTable).Result;
                if (ModelState.IsValid && model.IsSuccessStatusCode)
                {
                    return RedirectToAction("Logout", "KhachHang");
                }
                else
                {
                    ViewBag.msg = "Change password failed!";
                }
            }
            else
            {
                ViewBag.msg = "oldPass invalid!";
            }
            return View();
        }
        //-----
        public IActionResult ChangeInfo(string varLocal)
        {
            SaveSession();
            if (string.IsNullOrEmpty(ViewBag.UserName_))
            {
                return RedirectToAction("Login", "KhachHang");
            }
            var model = JsonConvert.DeserializeObject<KhachHang>(httpClient.GetStringAsync(url_KhachHang + "/mail/" + varLocal).Result);
            return View(model);
        }
        //-----
        [HttpPost]
        public IActionResult ChangeInfo(KhachHang varTable)
        {
            SaveSession();

            if (string.IsNullOrEmpty(ViewBag.UserName_))
            {
                return RedirectToAction("Login", "KhachHang");
            }
            var rs = JsonConvert.DeserializeObject<IEnumerable<KhachHang>>(httpClient.GetStringAsync(url_KhachHang).Result);
            rs = rs.Where(u => u.Email.Equals(varTable.Email) && u.Id != varTable.Id).ToList();
            if (rs.Count() > 0)
            {
                ViewBag.msg = "Email already has a registered account!!!";
                return View();
            }
            if (varTable.UserName == null)
            {
                ViewBag.msg = "UserName can not be blank !!!";
                return View();
            }
            if (varTable.Email == null)
            {
                ViewBag.msg = "Email can not be blank !!!";
                return View();
            }
            if (varTable.Address == null)
            {
                ViewBag.msg = "Address can not be blank !!!";
                return View();
            }
            if (varTable.Phone == null)
            {
                ViewBag.msg = "Phone can not be blank !!!";
                return View();
            }
            //-----
            if (ModelState.IsValid)
            {
                KhachHang rse = JsonConvert.DeserializeObject<KhachHang>(httpClient.GetStringAsync(url_KhachHang + "/mail/" + varTable.Email).Result);
                var kqluu = httpClient.PutAsJsonAsync<KhachHang>(url_KhachHang, varTable).Result;
                if (rse !=null)
                {
                    if (rse.UserName != varTable.UserName || rse.Address != varTable.Address || rse.Email.ToLower().Trim() != varTable.Email.ToLower().Trim() || rse.Phone != varTable.Phone)
                    {
                        return RedirectToAction("Logout", "KhachHang");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    return RedirectToAction("Logout", "KhachHang");
                }
            }
            else
            {
                ViewBag.msg = "Change infomation failed!";
            }
            return View();
        }
        //-----
        [HttpGet]
        public IActionResult Registration()
        {
            SaveSession();
            return View();
        }
        [HttpPost]
        public IActionResult Registration(KhachHang varTable, string newPass, string confirmPass)
        {
            SaveSession();
            try
            {
                if (varTable.UserName==null)
                {
                    ViewBag.msg = "UserName can not be blank !!!";
                    return View();
                }
                if (varTable.Email == null)
                {
                    ViewBag.msg = "Email can not be blank !!!";
                    return View();
                }
                if (string.IsNullOrEmpty(newPass))
                {
                    ViewBag.msg = "newPass can not be blank !!!";
                    return View();
                }
                if (newPass != confirmPass)
                {
                    ViewBag.msg = "New password and confirm password do not match !!!";
                    return View();
                }
                if (varTable.Address == null)
                {
                    ViewBag.msg = "Address can not be blank !!!";
                    return View();
                }
                if (varTable.Phone == null)
                {
                    ViewBag.msg = "Phone can not be blank !!!";
                    return View();
                }
                KhachHang rs = JsonConvert.DeserializeObject<KhachHang>(httpClient.GetStringAsync(url_KhachHang + "/mail/" + varTable.Email).Result);
                if (rs != null)
                {
                    ViewBag.msg = "Email already has a registered account!!!";
                    return View();
                }
                else
                {
                    varTable.Password = newPass;
                    varTable.Status = 1;
                    var model = httpClient.PostAsJsonAsync<KhachHang>(url_KhachHang, varTable).Result;
                    if (model.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Login", "KhachHang");
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
        [HttpGet]
        public IActionResult ResetPassword()
        {
            SaveSession();
            return View();
        }
        //-----
        [HttpPost]
        public IActionResult ResetPassword(string EmailAddress)
        {
            SaveSession();
            if (string.IsNullOrEmpty(EmailAddress))
            {
                ViewBag.msg = "Email can not be blank !!!";
                return View();
            }
            var rs = JsonConvert.DeserializeObject<KhachHang>(httpClient.GetStringAsync(url_KhachHang + "/mail/" + EmailAddress).Result);
            if (rs == null)
            {
                ViewBag.msg = "Email not found on system!!!";
                return View();
            }
            else
            {
                string checkToken = fServices.RandomNumber(6);
                string body = string.Format("Hello <b>" + rs.UserName.Trim() + "!</b><br/>" +
                                "You have sent a password reset request to the system.<br/>" +
                                "Please enter the code <b>" + checkToken + "</b> on the ForgotPassword page to recover your password");

                var kq = fServices.SendMailGoogleSmtp(EmailAddress, "Password recovery", body);
                if (kq != null)
                {
                    HttpContext.Session.SetString("checkToken", checkToken);
                    return RedirectToAction("ForgotPassword", "KhachHang", new { varLocal = EmailAddress.Trim() });
                }
                else
                {
                    ViewBag.msg = "Unprocessed information!";
                }
            }
            //-----
            return View();
        }
        //-----
        [HttpGet]
        public IActionResult ForgotPassword(string varLocal)
        {
            SaveSession();
            var model = JsonConvert.DeserializeObject<KhachHang>(httpClient.GetStringAsync(url_KhachHang + "/mail/" + varLocal).Result);
            return View(model);
        }
        //-----
        [HttpPost]
        public IActionResult ForgotPassword(KhachHang varTable, string checkToken, string newPass, string confirmPass)
        {
            SaveSession();
            ViewBag.checkEmail = varTable.Email.Trim();
            string n_Token = HttpContext.Session.GetString("checkToken");
            if (!checkToken.Equals(n_Token))
            {
                ViewBag.msg = "Invalid Code Token...";
                return View();
            }
            if (string.IsNullOrEmpty(newPass))
            {
                ViewBag.msg = "Password can not be blank !!!";
                return View();
            }
            if (newPass != confirmPass)
            {
                ViewBag.msg = "New password and confirm password do not match !";
                return View();
            }
            varTable.Password = newPass;
            var model = httpClient.PutAsJsonAsync<KhachHang>(url_KhachHang, varTable).Result;
            if (ModelState.IsValid && model.IsSuccessStatusCode)
            {
                if (HttpContext.Session.GetString("Password_") != null)
                {
                    HttpContext.Session.Remove("Password_");
                }
                return RedirectToAction("Logout", "KhachHang");
            }
            else
            {
                ViewBag.msg = "Unprocessed information!";
            }
            return View();
        }
        //-----
        [HttpGet]
        public IActionResult XemDonHang(int trangthaiGH)
        {
            SaveSession();
            if (string.IsNullOrEmpty(ViewBag.UserName_))
            {
                return RedirectToAction("Login", "KhachHang");
            }
            int idkhachhang = int.Parse(ViewBag.Id_);
            var model = JsonConvert.DeserializeObject<IEnumerable<DonHangImage>>(httpClient.GetStringAsync(url_KhachHang + "/xemdonhangimage/" + idkhachhang.ToString()).Result);
            if (trangthaiGH == null)
            {
                trangthaiGH = 2;
            }
            ViewBag.trangthaiGH = trangthaiGH;
            var res = model.Where(x=>x.TrangThaiGH==trangthaiGH).ToList();
            if (res.Count() == 0)
            {
                ViewBag.msg = "No orders yet!";
            }
            return View(res);
        }
        //-----
        [HttpGet]
        public IActionResult XemChiTieDonHang(int varLocal, int trangthaiGH, string mahuy)
        {
            SaveSession();
            if (string.IsNullOrEmpty(ViewBag.UserName_))
            {
                return RedirectToAction("Login", "KhachHang");
            }
            var model = JsonConvert.DeserializeObject<IEnumerable<DetailsDonHang>>(httpClient.GetStringAsync(url_KhachHang + "/chitietdonhang/" + varLocal).Result);
            int ts = 0;
            foreach (var item in model)
            {
                ts = ts + item.ThanhTien;
            }
            if (mahuy != null)
            {
                ViewBag.mahuy = mahuy;
            }
            ViewBag.Tonggiatri = ts.ToString("N").Substring(0, ts.ToString("N").Length - 3);
            ViewBag.ttgh = trangthaiGH;
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
        public IActionResult ListSanPham(string varLocal, string Min, string Max)
        {
            SaveSession();
            int gtMin = 0;
            int gtMax = 0;
            if (Min != null && Max == null)
            {
                gtMax = int.Parse(Min);
            }
            if (Min == null && Max != null)
            {
                gtMin = 0;
                gtMax = int.Parse(Max);
            }
            if (Min != null && Max != null)
            {
                gtMin = int.Parse(Min);
                gtMax = int.Parse(Max);
                if (gtMin > gtMax)
                {
                    gtMin = gtMax;
                }
            }
            var model = JsonConvert.DeserializeObject<IEnumerable<SanPhamFavourite>>(httpClient.GetStringAsync(url_KhachHang + "/sanphamlike").Result);
            //var model = JsonConvert.DeserializeObject<IEnumerable<SanPham>>(httpClient.GetStringAsync(url_KhachHang + "/sanpham").Result);
            if (varLocal == null && gtMin == 0 && gtMax == 0)
            {
                return View(model);
            }
            if (varLocal != null && gtMin == 0 && gtMax == 0)
            {
                var model1 = model.Where(x => x.Name.ToLower().Trim().Contains(varLocal.ToLower().Trim())).ToList();
                return View(model1);
            }
            if (varLocal != null && (gtMin > 0 || gtMax > 0))
            {
                var model1 = model.Where(x => x.Name.ToLower().Trim().Contains(varLocal.ToLower().Trim()) && (x.Price >= gtMin && x.Price <= gtMax)).ToList();
                return View(model1);
            }
            if (varLocal == null && (gtMin > 0 || gtMax > 0))
            {
                var model1 = model.Where(x => x.Price >= gtMin && x.Price <= gtMax).ToList();
                return View(model1);
            }
            return View(model);
        }
        //-----
        [HttpGet]
        public IActionResult DetailsSanPham(int idsanpham)
        {
            SaveSession();
            var res = JsonConvert.DeserializeObject<IEnumerable<SanPhamFavourite>>(httpClient.GetStringAsync(url_KhachHang + "/sanphamlike").Result);
            var sanphamfavourite = res.Where(x => x.Id == idsanpham).FirstOrDefault();

            var res2 = JsonConvert.DeserializeObject<IEnumerable<FeedBackDetails>>(httpClient.GetStringAsync(url_KhachHang + "/xemfeedbackdetails").Result);
            var feedbackdetails = res2.Where(x => x.IdSanPham == idsanpham).ToList();

            PartialView2 partialView = new PartialView2();
            partialView.pv1 = sanphamfavourite;
            partialView.pv2 = feedbackdetails;
            return View(partialView);
        }
        //-----
        [HttpGet]
        public IActionResult AddToCart(int varLocal)
        {
            SaveSession();
            if (string.IsNullOrEmpty(ViewBag.UserName_))
            {
                return RedirectToAction("Login", "KhachHang");
            }
            var ressp = JsonConvert.DeserializeObject<SanPham>(httpClient.GetStringAsync(url_KhachHang + "/sanpham/" + varLocal.ToString()).Result);
            int idkh = int.Parse(ViewBag.Id_);
            var countsp = JsonConvert.DeserializeObject<Cart>(httpClient.GetStringAsync(url_KhachHang + "/demsanpham/" + idkh.ToString() + "/" + varLocal.ToString()).Result);
            int slhang = 1;
            Cart giohang = new Cart();
            if (countsp == null)
            {
                slhang = 1;
            }
            else
            {
                slhang = countsp.SoLuong + 1;
                giohang.Id = countsp.Id;
            }

            if (ressp.Soluong >= slhang)
            {
                giohang.IdKhachHang = idkh;
                giohang.IdSanPham = varLocal;
                giohang.Ten = ressp.Name;
                giohang.Url = ressp.UrlImage;
                giohang.SoLuong = slhang;
                giohang.DonGia = ressp.Price;
                giohang.Tongtien = ressp.Price * slhang;
                if (slhang == 1)
                {
                    var model = httpClient.PostAsJsonAsync<Cart>(url_KhachHang + "/themgiohang", giohang).Result;
                }
                else
                {
                    var model = httpClient.PutAsJsonAsync<Cart>(url_KhachHang + "/luugiohang", giohang).Result;
                }
            }
            else
            {
                ViewBag.msg = "Product is out of stock!";
                return View();
            }
            return RedirectToAction("ViewCart", "KhachHang", new { idkhachhang = giohang.IdKhachHang, idsanpham = giohang.IdSanPham });
        }
        //-----
        [HttpGet]
        public IActionResult ViewCart(int idkhachhang, int idsanpham, string gtMinMax)
        {
            SaveSession();
            var ressp = JsonConvert.DeserializeObject<SanPham>(httpClient.GetStringAsync(url_KhachHang + "/sanpham/" + idsanpham.ToString()).Result);
            var rescart = JsonConvert.DeserializeObject<Cart>(httpClient.GetStringAsync(url_KhachHang + "/demsanpham/" + idkhachhang.ToString() + "/" + idsanpham.ToString()).Result);
            int slhang = 0;
            if (gtMinMax == "Min")
            {
                if (rescart.SoLuong > 1)
                {
                    slhang = rescart.SoLuong - 1;
                    rescart.SoLuong = slhang;
                    var luucart = httpClient.PutAsJsonAsync<Cart>(url_KhachHang + "/luugiohang", rescart).Result;
                }
            }
            if (gtMinMax == "Max")
            {
                if (rescart.SoLuong < 10)
                {
                    slhang = rescart.SoLuong + 1;
                    if (ressp.Soluong >= slhang)
                    {
                        rescart.SoLuong = slhang;
                        var luucart = httpClient.PutAsJsonAsync<Cart>(url_KhachHang + "/luugiohang", rescart).Result;
                    }
                }
            }
            if (gtMinMax == "Del")
            {
                var xoa = httpClient.DeleteAsync(url_KhachHang + "/xoagiohang/" + rescart.Id.ToString()).Result;
            }
            SaveSession();
            //-----
            var model = JsonConvert.DeserializeObject<IEnumerable<Cart>>(httpClient.GetStringAsync(url_KhachHang + "/xemgiohang/" + idkhachhang.ToString()).Result);
            int ts = 0;
            foreach (var item in model)
            {
                ts = ts + item.Tongtien;
            }
            ViewBag.Tonggiatri = ts.ToString("N").Substring(0, ts.ToString("N").Length - 3);
            return View(model);
        }
        //-----
        [HttpGet]
        public IActionResult HuyDonHang()
        {
            SaveSession();
            if (string.IsNullOrEmpty(ViewBag.UserName_))
            {
                return RedirectToAction("Login", "KhachHang");
            }
            int idkhachhang = int.Parse(ViewBag.Id_);
            var res = JsonConvert.DeserializeObject<IEnumerable<DonHangImage>>(httpClient.GetStringAsync(url_KhachHang + "/xemdonhangimage/" + idkhachhang.ToString()).Result);
            var model = res.Where(x => x.TrangThaiGH == 0);
            return View(model);
        }
        //-----
        [HttpGet]
        public IActionResult CancelOrder(int iddonhang)
        {
            SaveSession();
            if (string.IsNullOrEmpty(ViewBag.UserName_))
            {
                return RedirectToAction("Login", "KhachHang");
            }
            var donhang = JsonConvert.DeserializeObject<DonHang>(httpClient.GetStringAsync(url_KhachHang + "/getdonhang/" + iddonhang.ToString()).Result);
            var huydonhang = httpClient.PutAsJsonAsync<DonHang>(url_KhachHang + "/huydonhang", donhang).Result;
            return RedirectToAction("XemDonHang", "KhachHang",new {trangthaiGH=3});
        }
        //-----
        [HttpGet]
        public IActionResult Danhgia(int iddonhang, int idsanpham, string urlimage, string evaluate1, string evaluate2, string evaluate3, string evaluate4, string evaluate5)
        {
            SaveSession();
            int idkhachhang = int.Parse(ViewBag.Id_);
            var model = JsonConvert.DeserializeObject<FeedBack>(httpClient.GetStringAsync(url_KhachHang + "/getdanhgia/" + idkhachhang.ToString() + "/" + iddonhang.ToString() + "/" + idsanpham.ToString()).Result);
            if (model == null)
            {
                ViewBag.iddonhang = iddonhang;
                ViewBag.idsanpham = idsanpham;
                ViewBag.urlimage = urlimage;
                if (evaluate1==null)
                {
                    evaluate1 = "1";
                }
                else
                {
                    ViewBag.evaluate1 = evaluate1;
                }
                if (evaluate2 == null)
                {
                    evaluate2 = "1";
                }
                else
                {
                    ViewBag.evaluate2 = evaluate2;
                }
                if (evaluate3 == null)
                {
                    evaluate3 = "1";
                }
                else
                {
                    ViewBag.evaluate3 = evaluate3;
                }
                if (evaluate4 == null)
                {
                    evaluate4 = "1";
                }
                else
                {
                    ViewBag.evaluate4 = evaluate4;
                }
                if (evaluate5 == null)
                {
                    evaluate5 = "1";
                }
                else
                {
                    ViewBag.evaluate5 = evaluate5;
                }
                //-----
                if (evaluate5 == "1")
                {
                    ViewBag.evaluate1 = "1";
                    ViewBag.evaluate2 = "1";
                    ViewBag.evaluate3 = "1";
                    ViewBag.evaluate4 = "1";
                    ViewBag.evaluate5 = "1";
                }
                else
                {

                    if (evaluate4 == "1")
                    {
                        ViewBag.evaluate1 = "1";
                        ViewBag.evaluate2 = "1";
                        ViewBag.evaluate3 = "1";
                        ViewBag.evaluate4 = "1";
                        ViewBag.evaluate5 = "0";
                    }
                    else
                    {
                        if (evaluate3 == "1")
                        {
                            ViewBag.evaluate1 = "1";
                            ViewBag.evaluate2 = "1";
                            ViewBag.evaluate3 = "1";
                            ViewBag.evaluate4 = "0";
                            ViewBag.evaluate5 = "0";
                        }
                        else
                        {
                            if (evaluate2 == "1")
                            {
                                ViewBag.evaluate1 = "1";
                                ViewBag.evaluate2 = "1";
                                ViewBag.evaluate3 = "0";
                                ViewBag.evaluate4 = "0";
                                ViewBag.evaluate5 = "0";
                            }
                            else
                            {
                                if (evaluate1 == "1")
                                {
                                    ViewBag.evaluate1 = "1";
                                    ViewBag.evaluate2 = "0";
                                    ViewBag.evaluate3 = "0";
                                    ViewBag.evaluate4 = "0";
                                    ViewBag.evaluate5 = "0";
                                }
                                else
                                {
                                    ViewBag.evaluate1 = "0";
                                    ViewBag.evaluate2 = "0";
                                    ViewBag.evaluate3 = "0";
                                    ViewBag.evaluate4 = "0";
                                    ViewBag.evaluate5 = "0";
                                }
                            }
                        }
                    }
                }
                if (evaluate5=="1")
                {
                    ViewBag.evaluate = "5";
                }
                else
                {
                    if (evaluate4=="1")
                    {
                        ViewBag.evaluate = "4";
                    }
                    else
                    {
                        if (evaluate3 == "1")
                        {
                            ViewBag.evaluate = "3";
                        }
                        else
                        {
                            if (evaluate2 == "1")
                            {
                                ViewBag.evaluate = "2";
                            }
                            else
                            {
                                if (evaluate1 == "1")
                                {
                                    ViewBag.evaluate = "1";
                                }
                                else
                                {
                                    ViewBag.evaluate = "0";
                                }
                            }
                        }
                    }
                }
                return View();
            }
            else
            {
                return RedirectToAction("XemDanhgia", "KhachHang", new { iddonhang = iddonhang, idsanpham = idsanpham, urlimage = urlimage });
            }
            return View();
        }
        //-----
        [HttpPost]
        public IActionResult Danhgia(FeedBack varTable, string urlimage, string evaluate1, string evaluate2, string evaluate3, string evaluate4, string evaluate5)
        {
            ViewBag.iddonhang = varTable.IdDonHang;
            ViewBag.idsanpham = varTable.IdSanPham;
            ViewBag.urlimage = urlimage;
            @ViewBag.contents = varTable.Contents;
            FeedBack rs = JsonConvert.DeserializeObject<FeedBack>(httpClient.GetStringAsync(url_KhachHang + "/getdanhgia/" + varTable.IdKhachHang.ToString() + "/" + varTable.IdDonHang.ToString() + "/" + varTable.IdSanPham.ToString()).Result);
            if (rs == null)
            {
                DateTime date = DateTime.Now;
                string ngayfeed = String.Format("{0:yyyy-MM-dd HH:mm:ss}", date);
                varTable.ThoiGianFeed = ngayfeed;
                if (varTable.Contents == null)
                {
                    varTable.Contents = "";
                }
                if (evaluate5 == "1")
                {
                    varTable.Evaluate = 5;
                    ViewBag.evaluate1 = "1";
                    ViewBag.evaluate2 = "1";
                    ViewBag.evaluate3 = "1";
                    ViewBag.evaluate4 = "1";
                    ViewBag.evaluate5 = "1";
                }
                else
                {
                    if (evaluate4 == "1")
                    {
                        varTable.Evaluate = 4;
                        ViewBag.evaluate1 = "1";
                        ViewBag.evaluate2 = "1";
                        ViewBag.evaluate3 = "1";
                        ViewBag.evaluate4 = "1";
                        ViewBag.evaluate5 = "0";
                    }
                    else
                    {
                        if (evaluate3 == "1")
                        {
                            varTable.Evaluate = 3;
                            ViewBag.evaluate1 = "1";
                            ViewBag.evaluate2 = "1";
                            ViewBag.evaluate3 = "1";
                            ViewBag.evaluate4 = "0";
                            ViewBag.evaluate5 = "0";
                        }
                        else
                        {
                            if (evaluate2 == "1")
                            {
                                varTable.Evaluate = 2;
                                ViewBag.evaluate1 = "1";
                                ViewBag.evaluate2 = "1";
                                ViewBag.evaluate3 = "0";
                                ViewBag.evaluate4 = "0";
                                ViewBag.evaluate5 = "0";
                            }
                            else
                            {
                                if (evaluate1 == "1")
                                {
                                    varTable.Evaluate = 1;
                                    ViewBag.evaluate1 = "1";
                                    ViewBag.evaluate2 = "0";
                                    ViewBag.evaluate3 = "0";
                                    ViewBag.evaluate4 = "0";
                                    ViewBag.evaluate5 = "0";
                                }
                                else
                                {
                                    varTable.Evaluate = 0;
                                    ViewBag.evaluate1 = "0";
                                    ViewBag.evaluate2 = "0";
                                    ViewBag.evaluate3 = "0";
                                    ViewBag.evaluate4 = "0";
                                    ViewBag.evaluate5 = "0";
                                }
                            }
                        }
                    }
                }
                if (varTable.Evaluate == 0)
                {
                    ViewBag.msg = "Rates choose from 1 star to 5 stars!";
                    return View();
                }
                var model = httpClient.PostAsJsonAsync<FeedBack>(url_KhachHang + "/setdanhgia", varTable).Result;
                if (model.IsSuccessStatusCode)
                {
                    return RedirectToAction("XemChiTieDonHang", "KhachHang", new { varLocal = varTable.IdDonHang, trangthaiGH = 2 });
                }
                else
                {
                    ViewBag.msg = "Infomation is invalid!";
                }
            }
            return View();
        }
        //-----
        [HttpGet]
        public IActionResult XemDanhgia(int iddonhang, int idsanpham, string urlimage)
        {
            SaveSession();
            int idkhachhang = int.Parse(ViewBag.Id_);
            ViewBag.iddonhang = iddonhang;
            ViewBag.idsanpham = idsanpham;
            ViewBag.urlimage = urlimage;
            var model = JsonConvert.DeserializeObject<FeedBack>(httpClient.GetStringAsync(url_KhachHang + "/getdanhgia/" + idkhachhang.ToString() + "/" + iddonhang.ToString() + "/" + idsanpham.ToString()).Result);
            return View(model);
        }
        //-----
        [HttpGet]
        public IActionResult PhuongThucThanhToan()
        {
            SaveSession();
            return View();
        }
        //-----
        [HttpPost]
        public IActionResult KiemTraPTTT(string flexRadioDefault)
        {
            SaveSession();
            if (flexRadioDefault == "PayPal")
            {
                return RedirectToAction("PayPal", "KhachHang");
            }
            if (flexRadioDefault == "Momo")
            {
                return RedirectToAction("Momo", "KhachHang");
            }
            if (flexRadioDefault == "Zalo")
            {
                return RedirectToAction("Zalo", "KhachHang");
            }
            if (flexRadioDefault == "COD")
            {
                return RedirectToAction("COD", "KhachHang");
            }
            return View();
        }
        //-----
        [HttpGet]
        public IActionResult PayPal()
        {
            SaveSession();
            int idkhachhang = int.Parse(ViewBag.Id_);
            var model = JsonConvert.DeserializeObject<Cart>(httpClient.GetStringAsync(url_KhachHang + "/demgiohang/" + idkhachhang.ToString()).Result);
            ViewBag.TongTien = model.Tongtien.ToString("N").Substring(0, model.Tongtien.ToString("N").Length - 3);
            ViewBag.Total = model.Tongtien.ToString();
            ViewBag.SoLuong = model.SoLuong.ToString();
            return View();
        }
        //-----
        [HttpGet]
        public IActionResult Momo()
        {
            SaveSession();
            int idkhachhang = int.Parse(ViewBag.Id_);
            var model = JsonConvert.DeserializeObject<Cart>(httpClient.GetStringAsync(url_KhachHang + "/demgiohang/" + idkhachhang.ToString()).Result);
            ViewBag.TongTien = model.Tongtien.ToString("N").Substring(0, model.Tongtien.ToString("N").Length - 3);
            ViewBag.Total = model.Tongtien.ToString();
            ViewBag.SoLuong = model.SoLuong.ToString();
            return View();
        }
        //-----
        [HttpGet]
        public IActionResult Zalo()
        {
            SaveSession();
            int idkhachhang = int.Parse(ViewBag.Id_);
            var model = JsonConvert.DeserializeObject<Cart>(httpClient.GetStringAsync(url_KhachHang + "/demgiohang/" + idkhachhang.ToString()).Result);
            ViewBag.TongTien = model.Tongtien.ToString("N").Substring(0, model.Tongtien.ToString("N").Length - 3);
            ViewBag.Total = model.Tongtien.ToString();
            ViewBag.SoLuong = model.SoLuong.ToString();
            return View();
        }
        //-----
        [HttpGet]
        public IActionResult COD()
        {
            SaveSession();
            int idkhachhang = int.Parse(ViewBag.Id_);
            var model = JsonConvert.DeserializeObject<Cart>(httpClient.GetStringAsync(url_KhachHang + "/demgiohang/" + idkhachhang.ToString()).Result);
            ViewBag.TongTien = model.Tongtien.ToString("N").Substring(0, model.Tongtien.ToString("N").Length - 3);
            ViewBag.Total = model.Tongtien.ToString();
            ViewBag.SoLuong = model.SoLuong.ToString();
            return View();
        }
        //-----
        [HttpGet]
        public IActionResult ThanhToan(string pttt)
        {
            SaveSession();
            int idkhachhang = int.Parse(ViewBag.Id_);
            var model = JsonConvert.DeserializeObject<Cart>(httpClient.GetStringAsync(url_KhachHang + "/demgiohang/" + idkhachhang.ToString()).Result);
            int TongTien = model.Tongtien;
            int SoLuong = model.SoLuong;

            DateTime date1 = DateTime.Now;
            DateTime date2 = date1.AddDays(7);
            string ngaydat = String.Format("{0:yyyy-MM-dd HH:mm:ss}", date1);
            string ngaygiao = String.Format("{0:yyyy-MM-dd HH:mm:ss}", date2);

            DonHang donHang = new DonHang();
            donHang.IdKhachHang = idkhachhang;
            donHang.DaThanhToan = true;
            if (pttt == "COD")
            {
                donHang.DaThanhToan = false;
            }
            donHang.NgayDat = ngaydat;
            donHang.NgayGiao = ngaygiao;
            donHang.SoLuong = SoLuong;
            donHang.TongTien = TongTien;
            donHang.TrangThaiGH = 0;
            if (pttt!="Huy")
            {
                var them = httpClient.PostAsJsonAsync<DonHang>(url_KhachHang + "/themdonhang", donHang).Result;
            }
            return RedirectToAction("XemDonHang", "KhachHang", new { trangthaiGH = 0 });
        }
        //-----
    }
}
