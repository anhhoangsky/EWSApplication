﻿using EWSApplication.DataLayers;
using EWSApplication.DataLayers.Common;
using EWSApplication.Entities.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EWSApplication.BussinessLayers
{
    public class PostBLL
    {
        public static PostDAL pstDAL = new PostDAL();
        public List<Post> Post_GetAllPost()
        {
            return pstDAL.GetAllPost();
        }
        /// <summary>
        /// Chi tiết bài post
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        public Post Post_GetDetailsPost(string postId)
        {
            return pstDAL.GetDetailsPost(postId);
        }
        /// <summary>
        /// lấy top 5 bài post phổ biến
        /// </summary>
        /// <returns></returns>
        public List<Post> Post_GetTopPopularPost()
        {
            return pstDAL.GetTopPopularPost();
        }
        /// <summary>
        /// lấy top 5 bài post nhiều view nhất
        /// </summary>
        /// <returns></returns>
        public List<Post> Post_GetTopViewPost()
        {
            return pstDAL.GetTopViewPost();
        }
        /// <summary>
        /// lấy top bài post lastest
        /// </summary>
        /// <returns></returns>
        public List<Post> Post_GetTopLastPost()
        {
            return pstDAL.GetTopLastPost();
        }

        /// <summary>
        /// Load tất cả comment của bài post
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        public Comment Post_GetListCommentOfPost(string postId)
        {
            return pstDAL.GetListCommentOfPost(postId);
        }
        
        /// <summary>
        /// Tạo mới bài post
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool Post_CreateNewPost(StructurePost data)
        {
            return pstDAL.CreateNewPost(data);
        }
        
    }
}