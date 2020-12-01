using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoardGame.Models
{
    public class CommentModels
    {
        public int ID { get; set; }
        public string Contents { get; set; }

        public int AuthorUserId { get; set; }
       
        
        public virtual UserModels Author { get; set; }
     
        public virtual ReviewModels Review { get; set; }
    }
}