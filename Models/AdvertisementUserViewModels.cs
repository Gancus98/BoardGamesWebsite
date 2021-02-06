using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoardGame.Models
{
    public class AdvertisementUserViewModels
    {
        public IEnumerable<UserModels> Users { get; set; }
        public IEnumerable<AdvertisementModels> Reviews { get; set; }
    }
}

