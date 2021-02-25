namespace EWSApplication.Entities.DBContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Post")]
    public partial class Post
    {
        [StringLength(10)]
        public string postid { get; set; }

        [StringLength(100)]
        public string title { get; set; }

        public bool? anonymous { get; set; }

        [StringLength(10)]
        public string tagid { get; set; }

        [StringLength(10)]
        public string userid { get; set; }

        public string content { get; set; }
    }
}
