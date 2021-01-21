using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoardGame.Models
{
    public class UserModels
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<ReviewModels> Reviews { get; set; }
        public virtual ICollection<CommentModels> Comments { get; set; }
        public virtual ICollection<PlayerModels> Players { get; set; } // one player can take part in many games
        public virtual ICollection<AdvertisementModels> Advertisements { get; set; }

        public virtual ICollection<MessageModels> MessagesSent { get; set; }
        public virtual ICollection<MessageModels> MessagesReceive { get; set; }

        public virtual ICollection<FriendModels> Observations { get; set; }
        public virtual ICollection<FriendModels> Followers { get; set; }

        public string FullName
        {
            get { return Name + " " + Surname; }
        }

    }
}