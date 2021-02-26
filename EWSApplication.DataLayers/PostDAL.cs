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
            return pst;
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
    }
}
