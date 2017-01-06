using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebLayer.Models
{
    public class Friends
    {
        [Key]
        public int FriendId { get; set; }
       
        public int UserId { get; set; }
        public string Name { get; set; }
        public string FriendName { get; set; }
    }
}