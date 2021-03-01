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
        [AllowAnonymous]
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
        public ActionResult NewComment()
        {
            //gồm nội dung comment và id người gửi + id bài post...
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Create(StructurePost data , ObjFile file)
        {
            
            return RedirectToAction("Index");
        }
    }
}