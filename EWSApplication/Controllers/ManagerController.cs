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
    public class ManagerController : Controller
    {
        // GET: Manager
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