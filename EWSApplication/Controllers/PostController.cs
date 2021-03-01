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
        public ActionResult Create(StructurePost data , ObjFile doc)
        {
            var filePath = "";
            foreach (var file in doc.files)
            {

                if (file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    filePath = Path.Combine(Server.MapPath("~/Files"), fileName);
                    file.SaveAs(filePath);
                }
            }
            if(data.anonymous != null)
            {
                data.anonymous = true;
            }
            else
            {
                data.anonymous = false;
            }
            PostBLL.Post_CreateNewPost(data, filePath);
            return RedirectToAction("Index","Home");
        }
    }
}