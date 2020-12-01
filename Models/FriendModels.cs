using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoardGame.Models
{
    public class FriendModels
    {
        public int ID { get; set; }
        public DateTime StartDate { get; set; }

        public virtual UserModels MyObservations { get; set; }
        public virtual UserModels MyFollowers { get; set; }
    }
}