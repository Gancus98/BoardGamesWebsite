using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;


namespace BoardGame.Models
{
    public class MessageModels
    {
        public int ID { get; set; }
        public string Contents { get; set; }
        public bool? IsDeleted { get; set; }

        public UserModels SenderUser { get; set; }

        public UserModels ReceiverUser { get; set; }

        public DateTime PostDate { get; set; }
        public DateTime? ReadDate { get; set; }

    }
      
}