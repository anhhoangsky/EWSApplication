using EWSApplication.BussinessLayers;
using EWSApplication.DataLayers.Common;
using EWSApplication.Entities.DBContext;
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

        [AllowAnonymous]
        public ActionResult Detail(string postId)
        {
            //xử lí dữ liệu post
            // dữ liệu post gồm:......
            //var postData= PostBLL.pstDAL.GetDetailsPost(postId);
            Post postData = new Post();
            return View(postData);
        }

        [HttpPost]
        public ActionResult Create(StructurePost data)
        {
            // demo code 
            foreach (var file in data.files.files)
            {

                if (file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var filePath = Path.Combine(Server.MapPath("~/Files"), fileName);
                    file.SaveAs(filePath);
                }
            }
            PostBLL.Post_CreateNewPost(data);
            return RedirectToAction("Index");
        }
    }
}