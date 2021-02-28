using EWSApplication.BussinessLayers;
using EWSApplication.DataLayers.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EWSApplication.Controllers
{
    public class PostController : Controller
    {
        // GET: Post
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(StructurePost data , ObjFile file)
        {
            
            return RedirectToAction("Index");
        }
    }
}