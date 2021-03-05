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
    public class ManagerController : Controller
    {
        // GET: Manager
        public ActionResult Index()
        {
            List<StructureAccountToRender> obj = SystemBLL.System_GetListInfoAccount();
            return View(obj);
        }
        
        public ActionResult Tag()
        {
            List<Tag> obj = ManagerBLL.Manager_GetListTag();
            return View(obj);
        }

        public ActionResult Download()
        {
            List<ObjFile> data = ManagerBLL.Manager_GetAllFileToDownload();
            return View(data);
        }
        public FileResult Download(string filePath)
        {
            string fileName = Path.GetFileName(filePath);
            byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }

    }
}