﻿using EWSApplication.DataLayers;
using EWSApplication.DataLayers.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EWSApplication.BussinessLayers
{
    public class ManagerBLL
    {
        private static ManagerDAL ManagerDAL = new ManagerDAL();
        public bool Manager_CreateNewTag(string tagName)
        {
            return ManagerDAL.CreateNewTag(tagName);
        }
        public bool Manager_DeleteTag(string tagID)
        {
            return ManagerDAL.DeleteTag(tagID);
        }
        public static List<ObjFile> Manager_GetAllFileToDownload()
        {
            return ManagerDAL.GetAllFileToDownload();
        }
    }
}
