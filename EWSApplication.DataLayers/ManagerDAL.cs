using EWSApplication.DataLayers.Common;
using EWSApplication.Entities.DBContext;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EWSApplication.DataLayers
{
    public class ManagerDAL
    {
        EWSDbContext db = new EWSDbContext();
        #region Tags
        /// <summary>
        /// Tao Tag moi
        /// </summary>
        /// <param name="tagName"></param>
        /// <returns></returns>
        public bool CreateNewTag(string tagName)
        {
            try
            {
                var tag = new Tag()
                {
                    tagname = tagName
                };
                db.Tags.Add(tag);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// Xoa tag
        /// </summary>
        /// <param name="tagID"></param>
        /// <returns></returns>
        public bool DeleteTag(string tagID)
        {
            try
            {
                var tag = db.Tags.Where(x => x.tagid == tagID).SingleOrDefault();
                db.Tags.Remove(tag);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        #endregion
        #region download tệp đính kèm
        public List<ObjFile> GetAllFileToDownload()
        {
            List<ObjFile> ObjFiles = new List<ObjFile>();
            var listPath = from s in db.Posts
                           select s.filePath;
            foreach (string strfile in listPath)
            {
                FileInfo fi = new FileInfo(strfile);
                ObjFile obj = new ObjFile();
                obj.File = fi.Name;
                obj.Size = fi.Length;
                obj.Type = GetFileTypeByExtension(fi.Extension);
                ObjFiles.Add(obj);
            }
            return ObjFiles;
        }
        
        private string GetFileTypeByExtension(string fileExtension)
        {
            switch (fileExtension.ToLower())
            {
                case ".docx":
                case ".doc":
                    return "Microsoft Word Document";
                case ".xlsx":
                case ".xls":
                    return "Microsoft Excel Document";
                case ".txt":
                    return "Text Document";
                case ".jpg":
                case ".png":
                    return "Image";
                default:
                    return "Unknown";
            }
        }
        #endregion
        #region phân tích thống kê

        #endregion
    }
}
