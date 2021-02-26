using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EWSApplication.Entities.DBContext;
namespace EWSApplication.DataLayers
{
    public class PostDAL
    {
        EWSDbContext db = new EWSDbContext();
        /// <summary>
        /// lấy danh sách tất cả bài post để hiển thị trên Home
        /// </summary>
        /// <returns></returns>
        public List<Post> GetAllPost()
        {
            List<Post> lst = new List<Post>();
            lst = db.Posts.ToList();
            return lst;
        }
        /// <summary>
        /// Chi tiết bài post
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        public Post GetDetailsPost(string postId)
        {
            Post pst = new Post();
            pst = db.Posts.Where(x => x.postid == postId).SingleOrDefault();
            UpdateViewPost(postId);
            return pst;
        }
        /// <summary>
        /// lấy top 5 bài post phổ biến
        /// </summary>
        /// <returns></returns>
        public List<Post> GetTopPopularPost()
        {
            List<Post> lst = new List<Post>();
            lst = db.Posts.OrderByDescending(x => x.like).Take(5).ToList();
            return lst;
        }
        /// <summary>
        /// lấy top 5 bài post nhiều view nhất
        /// </summary>
        /// <returns></returns>
        public List<Post> GetTopViewPost()
        {
            List<Post> lst = new List<Post>();
            lst = db.Posts.OrderByDescending(x => x.view).Take(5).ToList();
            return lst;
        }
        /// <summary>
        /// lấy top bài post lastest
        /// </summary>
        /// <returns></returns>
        public List<Post> GetTopLastPost()
        {
            DateTime date = DateTime.Now;
            // creating object of TimeSpan 
            TimeSpan ts = new TimeSpan(10, 0, 0, 0);

            // getting ShortTime from  
            // subtracting DateTime and TimeSpan 
            // using Subtract() method; 
            DateTime dateFrom = date.Subtract(ts);
            List<Post> lst = new List<Post>();
            lst = db.Posts.Where(t => t.datetimepost > dateFrom && t.datetimepost < DateTime.Now).ToList();
            return lst;
        }

        /// <summary>
        /// Load tất cả comment của bài post
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        public Comment GetListCommentOfPost(string postId)
        {
            Comment cmt = new Comment();
            cmt = db.Comments.Where(x => x.postid == postId).SingleOrDefault();
            return cmt;
        }
        /// <summary>
        /// tăng view cho bài post
        /// </summary>
        /// <param name="postId"></param>
        public void UpdateViewPost(string postId)
        {
            var pst = db.Posts.Where(x => x.postid == postId).SingleOrDefault();
            pst.view = pst.view+1;
            db.SaveChanges();
        }
    }
}
