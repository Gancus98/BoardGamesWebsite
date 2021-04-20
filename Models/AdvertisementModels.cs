using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoardGame.Models
{
    public class AdvertisementModels
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public string City { get; set; }
        public string Description { get; set; }
        public int MaxPlayer { get; set; }
        public bool IsActive { get; set; }

        public virtual UserModels Author { get; set; } 
        
        public virtual BoardGameModels BoardGame { get; set; }

        public virtual ICollection<PlayerModels> Players { get; set; }



    }
}