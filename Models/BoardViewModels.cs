using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoardGame.Models
{
    public class BoardViewModels
    {
        public IEnumerable<UserModels> Users { get; set; }
        public IEnumerable<ReviewModels> Reviews { get; set; }
    }
}