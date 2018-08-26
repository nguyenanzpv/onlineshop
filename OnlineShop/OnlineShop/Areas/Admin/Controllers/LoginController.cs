using Models;
using OnlineShop.Areas.Admin.Code;
using OnlineShop.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login

        [HttpGet]//co the nhan tu url
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]//khong the nhan tu url
        [ValidateAntiForgeryToken]//sinh token cho request va respone
        public ActionResult Index(LoginModel model)
        {
            //su dung entity login
            //var result = new AccountModel().Login(model.UserName, model.Password);
            //if(result&&ModelState.IsValid)
            //{
            //    SessionHelper.SetSession(new UserSession() {UserName=model.UserName });
            //    return RedirectToAction("Index", "Home");
            //}
            //else
            //{
            //    ModelState.AddModelError("","Tên đăng nhập hoặc mật khẩu không đúng");
            //}
            //return View(model);//truyen du lieu tu control qua view bang viewbag hoac model
            // su dung membership
            if(Membership.ValidateUser(model.UserName,model.Password)&&ModelState.IsValid)
            {
                FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng");
            }
            return View(model);//truyen du lieu tu control qua view bang viewbag hoac model
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }
    }
}