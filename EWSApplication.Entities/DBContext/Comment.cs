namespace EWSApplication.Entities.DBContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Comment")]
    public partial class Comment
    {
        [StringLength(10)]
        public string commentid { get; set; }

        public bool anonymous { get; set; }

        public DateTime Date { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        [StringLength(10)]
        public string postid { get; set; }

        [Required]
        [StringLength(10)]
        public string userid { get; set; }
    }
}
