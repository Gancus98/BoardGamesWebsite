using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoardGame.Models
{
    public class MessageFriendViewModels
    {
        public IEnumerable<FriendModels> Friends { get; set; }
        public IEnumerable<MessageModels> Messages { get; set; }
    }
}