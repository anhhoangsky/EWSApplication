using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using EWSApplication.BussinessLayers;
namespace EWSApplication.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        
        public ActionResult Index(string mode = "top_new")
        {
            // xử lí mode render
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(string userName, string password)
        {
                var userInfo = SystemBLL.System_Login(userName, password);
            if (userInfo == null)
            {
                ModelState.AddModelError("", "Login Failed!");
                return View();
            }
            FormsAuthentication.SetAuthCookie("isLogin", false);
            return RedirectToAction("Index", "Home");

        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login", "Home");
        }
    }
}