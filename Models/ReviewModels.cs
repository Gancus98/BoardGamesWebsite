using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoardGame.Models
{
    public class ReviewModels
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Photo { get; set; }
        public string Contents { get; set; }
        public DateTime DateOfPublication { get; set; }
        
        public virtual BoardGameModels BoardGame { get; set; }

        public virtual ICollection<CommentModels> Comments { get; set; }

        public virtual UserModels Author { get; set; }

    }
}