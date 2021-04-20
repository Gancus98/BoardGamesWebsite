using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoardGame.Models
{
    public class BoardGameModels
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Designer { get; set; }
        public string Publisher { get; set; }
        public string NumberOfPlayers { get; set; }
        public int RecommendedAge { get; set; }
        public int GameTime { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        public virtual ICollection<ReviewModels> Reviews { get; set; }

    }
}