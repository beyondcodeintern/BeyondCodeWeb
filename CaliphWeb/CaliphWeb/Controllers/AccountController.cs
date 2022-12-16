using Caliph.Library.Helper;
using CaliphWeb.Core;
using CaliphWeb.Core.Helper;
using CaliphWeb.Helper;
using CaliphWeb.Models.API;
using CaliphWeb.Services;
using CaliphWeb.Services.Helper;
using CaliphWeb.ViewModel;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.Cookies;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CaliphWeb.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly ICaliphAPIHelper _caliphAPIHelper;

        public AccountController(IUserService userService, ICaliphAPIHelper caliphAPIHelper)
        {
            this._userService = userService;
            this._caliphAPIHelper = caliphAPIHelper;
        }
        // GET: Account
        public ActionResult Login()
        {
            return View(new LoginViewModel());
        }

        public ActionResult ChangePassword()
        {
            return View(new LoginViewModel());
        }
        [HttpPost]
        public async Task<ActionResult> ChangePasswordAsync(string oPassword, string password)
        {
            var user = UserHelper.GetLoginUserViewModel();

            var login = new LoginViewModel { Username=user.Username };
            var key = "H6&a##5";

           
            login.Password = HashHelper.GetHashMd5(key + oPassword);
            var data = await _userService.GetUserAsync(login);
            if (!data.IsSuccess)
            {
                return Json(data);
            }
            UserRequest userRequest = new UserRequest()
            {
                Username = user.Username,
                PW = HashHelper.GetHashMd5(key + password),
                UpdatedBy = UserHelper.GetLoginUser()
            };

            var response = await _caliphAPIHelper.PostAsync<UserRequest, ResponseData<string>>(userRequest, "/api/v1/system-user/update-pw");
            return Json(response);
        }
        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel login)
        
        {
            if (ModelState.IsValid)
            { //checking model state
                var key = "H6&a##5";
                login.Password = HashHelper.GetHashMd5(key + login.Password);
                var data = await _userService.GetUserAsync(login);
                if (data.IsSuccess)
                {

                    int timeout = 30;
                    var ticket = new FormsAuthenticationTicket(login.Username, false, timeout);
                    string encrypted = FormsAuthentication.Encrypt(ticket);
                    var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                    cookie.Expires = DateTime.Now.AddMinutes(timeout);
                    cookie.Secure = false;
                    cookie.HttpOnly = true;

                    Response.Cookies.Set(cookie);
                    Session["user"] = data.Data;
                    return RedirectToAction("Index", "Home");

                }

                ModelState.AddModelError("", data.StatusMsg);
                return View(login);


            }
            return View();
        }


        public ActionResult LoginV2()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session["user"] = null;
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
            return View();
        }
    }
}