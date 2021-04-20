using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoardGame.Models
{
    public class PlayerModels
    {
        public int ID { get; set; }
        public bool IsConfirmed { get; set; }

     
        public virtual AdvertisementModels Advertisement { get; set; }

        public virtual UserModels Player { get; set; }

    }
}