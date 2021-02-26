using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EWSApplication.BussinessLayers;
namespace EWSApplication.Controllers
{
    
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
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
            //if (Session["isLogin"] != null)
            //{
            //    return RedirectToAction("Index", "Home");
            //}
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
            if(Session["isLogin"] == null)
            {
                var userInfo = SystemBLL.System_Login(userName, password);
                if(userInfo != null )
                {
                    Session["isLogin"] = userInfo;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View();
                }

            }            
            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login", "Home");
        }
    }
}