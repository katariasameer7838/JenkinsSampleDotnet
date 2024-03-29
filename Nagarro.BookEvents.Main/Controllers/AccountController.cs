using Nagarro.BookEvents.Main.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nagarro.BookEvents.Shared;
using Nagarro.BookEvents.BLL;

namespace Nagarro.BookEvents.Main.Controllers
{
    public class AccountController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel loginModel)
        {
            var loginDTO = new LoginDTO();
            loginDTO.Email = loginModel.Email;
            loginDTO.Password = loginModel.Password;
            AccountBLL accountBLL = new AccountBLL();
            LoginDTO resultLoginDTO = accountBLL.Login(loginDTO);
            if(resultLoginDTO.IsPasswordMatches == true)
            {
                var userCookie = new HttpCookie("userInfo");
                userCookie["email"] = resultLoginDTO.Email;
                if (resultLoginDTO.Email == "myadmin@bookevents.com")
                {
                    userCookie["isAdmin"] = true.ToString();
                }
                else
                {
                    userCookie["isAdmin"] = false.ToString();
                }
                userCookie["id"] = resultLoginDTO.UserID.ToString();
                userCookie["isLogin"] = true.ToString();
                userCookie.Expires.AddDays(365);
                HttpContext.Response.Cookies.Add(userCookie);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel registerModel)
        {
            if(ModelState.IsValid)
            {
                var registerDTO = new RegisterDTO();
                registerDTO.FullName = registerModel.FullName;
                registerDTO.Email = registerModel.Email;
                registerDTO.Password = registerModel.Password;
                var accountBLL = new AccountBLL();
                RegisterDTO resultRegisterDTO = accountBLL.Register(registerDTO);
                if(resultRegisterDTO.IsAccountAlreadyExists == true)
                {
                    
                }
                if(resultRegisterDTO.IsDetailsSaved == true)
                {
                    var userCookie = new HttpCookie("userInfo");
                    userCookie["email"] = resultRegisterDTO.Email;
                    userCookie["id"] = resultRegisterDTO.UserID.ToString();
                    userCookie["isAdmin"] = false.ToString();
                    userCookie["isLogin"] = true.ToString();
                    userCookie.Expires.AddDays(365);
                    HttpContext.Response.Cookies.Add(userCookie);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }
    }
}