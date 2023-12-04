using Admin_WebRuou.Models;
using Admin_WebRuou.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Principal;

namespace Admin_WebRuou.Controllers
{
    public class UserController : Controller
    {
        private const string url = "http://localhost:7134/api/";
        private string url_User = url + "User";

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
                var account = JsonConvert.DeserializeObject<User>(httpClient.GetStringAsync(url_User + "/login/" + varEmail + "/" + varPassword).Result);
                if (account != null)
                {
                    HttpContext.Session.SetString("Id_", account.Id.ToString().Trim());
                    HttpContext.Session.SetString("UserName_", account.UserName.Trim());
                    HttpContext.Session.SetString("Email_", account.Email.Trim());
                    HttpContext.Session.SetString("Password_", account.Password.Trim());
                    HttpContext.Session.SetString("Status_", account.Status.ToString().Trim());
                    ViewBag.Id_ = HttpContext.Session.GetString("Id_");
                    ViewBag.UserName_ = HttpContext.Session.GetString("UserName_");
                    ViewBag.Email_ = HttpContext.Session.GetString("Email_");
                    ViewBag.Password_ = HttpContext.Session.GetString("Password_");
                    ViewBag.Status_ = HttpContext.Session.GetString("Status_");
                    return RedirectToAction("Index", "Home");
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
            if (HttpContext.Session.GetString("Status_") != null)
            {
                HttpContext.Session.Remove("Status_");
            }
            HttpContext.Session.Clear();
            ViewBag.Id_ = ViewBag.UserName_ = ViewBag.Email_ = ViewBag.Password_ = ViewBag.Status_ = "";
            return RedirectToAction("Login", "User");
        }
        //-----
        public IActionResult ChangePassword(string varLocal)
        {
            SaveSession();
            if (string.IsNullOrEmpty(ViewBag.UserName_))
            {
                return RedirectToAction("Login", "User");
            }
            var model = JsonConvert.DeserializeObject<User>(httpClient.GetStringAsync(url_User + "/mail/" + varLocal).Result);
            return View(model);
        }
        //-----
        [HttpPost]
        public IActionResult ChangePassword(User varTable, string oldPass, string newPass, string confirmPass)
        {
            SaveSession();
            if (string.IsNullOrEmpty(ViewBag.UserName_))
            {
                return RedirectToAction("Login", "User");
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
            User account = JsonConvert.DeserializeObject<User>(httpClient.GetStringAsync(url_User + "/login/" + varTable.Email + "/" + oldPass).Result);
            if (account != null)
            {
                varTable.Password = newPass.Trim();
                var model = httpClient.PutAsJsonAsync<User>(url_User, varTable).Result;
                if (ModelState.IsValid && model.IsSuccessStatusCode)
                {
                    return RedirectToAction("Logout", "User");
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
                return RedirectToAction("Login", "User");
            }
            var model = JsonConvert.DeserializeObject<User>(httpClient.GetStringAsync(url_User + "/mail/" + varLocal).Result);
            return View(model);
        }
        //-----
        [HttpPost]
        public IActionResult ChangeInfo(User varTable)
        {
            SaveSession();

            if (string.IsNullOrEmpty(ViewBag.UserName_))
            {
                return RedirectToAction("Login", "User");
            }
            var rs = JsonConvert.DeserializeObject<IEnumerable<User>>(httpClient.GetStringAsync(url_User).Result);
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
            //-----
            if (ModelState.IsValid)
            {
                User rse = JsonConvert.DeserializeObject<User>(httpClient.GetStringAsync(url_User + "/mail/" + varTable.Email).Result);
                var kqluu = httpClient.PutAsJsonAsync<User>(url_User, varTable).Result;
                if (rse != null)
                {
                    if (rse.UserName != varTable.UserName || rse.Email.ToLower().Trim() != varTable.Email.ToLower().Trim())
                    {
                        return RedirectToAction("Logout", "User");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    return RedirectToAction("Logout", "User");
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
            var rs = JsonConvert.DeserializeObject<User>(httpClient.GetStringAsync(url_User + "/mail/" + EmailAddress).Result);
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
                    return RedirectToAction("ForgotPassword", "User", new { varLocal = EmailAddress.Trim() });
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
            var model = JsonConvert.DeserializeObject<User>(httpClient.GetStringAsync(url_User + "/mail/" + varLocal).Result);
            return View(model);
        }
        //-----
        [HttpPost]
        public IActionResult ForgotPassword(User varTable, string checkToken, string newPass, string confirmPass)
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
            var model = httpClient.PutAsJsonAsync<User>(url_User, varTable).Result;
            if (ModelState.IsValid && model.IsSuccessStatusCode)
            {
                if (HttpContext.Session.GetString("Password_") != null)
                {
                    HttpContext.Session.Remove("Password_");
                }
                return RedirectToAction("Logout", "User");
            }
            else
            {
                ViewBag.msg = "Unprocessed information!";
            }
            return View();
        }
        //-----
        public IActionResult ListUser(string varLocal)
        {
            SaveSession();
            if (string.IsNullOrEmpty(ViewBag.UserName_))
            {
                return RedirectToAction("Login", "User");
            }
            var model = JsonConvert.DeserializeObject<IEnumerable<User>>(httpClient.GetStringAsync(url_User).Result);
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
        public IActionResult Create(User varTable)
        {
            SaveSession();
            try
            {
                User rs = JsonConvert.DeserializeObject<User>(httpClient.GetStringAsync(url_User + "/mail/" + varTable.Email.Trim()).Result);
                if (rs != null)
                {
                    ViewBag.msg = "Email already has a registered account!!!";
                }
                else
                {
                    varTable.Status = 1;
                    var model = httpClient.PostAsJsonAsync<User>(url_User, varTable).Result;
                    if (model.IsSuccessStatusCode)
                    {
                        return RedirectToAction("ListUser", "User");
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
            var model = JsonConvert.DeserializeObject<User>(httpClient.GetStringAsync(url_User + "/" + varLocal).Result);
            return View(model);
        }
        //-----
        [HttpPost]
        public IActionResult Edit(User varTable, string EditReset)
        {
            SaveSession();
            var rs = JsonConvert.DeserializeObject<IEnumerable<User>>(httpClient.GetStringAsync(url_User).Result);
            rs = rs.Where(u => u.Email.Equals(varTable.Email) && u.Id != varTable.Id).ToList();
            if (rs.Count() > 0)
            {
                ViewBag.msg = "Email already has a registered account!!!";
                return View();
            }
            //-----
            User account = JsonConvert.DeserializeObject<User>(httpClient.GetStringAsync(url_User + "/" + varTable.Id).Result);
            if (account != null)
            {
                if (EditReset.Equals("Password recovery"))
                {
                    varTable.Password = "12345";
                }
                if (varTable.UserName == "Administrator" || varTable.UserName == "ADMINISTRATOR")
                {
                    varTable.Status = 1;
                }
                var model = httpClient.PutAsJsonAsync<User>(url_User, varTable).Result;
                if (ModelState.IsValid && model.IsSuccessStatusCode)
                {
                    return RedirectToAction("ListUser", "User");
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
            var model = JsonConvert.DeserializeObject<User>(httpClient.GetStringAsync(url_User + "/" + varLocal).Result);
            return View(model);
        }
        //-----
        [HttpPost]
        public IActionResult Delete(User varTable)
        {
            SaveSession();
            var model = httpClient.DeleteAsync(url_User + "/" + varTable.Id).Result;
            if (model.IsSuccessStatusCode)
            {
                return RedirectToAction("ListUser", "User");
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
