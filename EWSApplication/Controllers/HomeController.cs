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
                    RedirectToAction("Index", "Home");
                }
                else
                {
                    return View();
                }

            }
            else
            {
                RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}