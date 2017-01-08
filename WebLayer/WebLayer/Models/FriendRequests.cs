using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebLayer.Models
{
    public class FriendRequests
    {
        [Key]
        [Required]
        public int FRId { get; set; }
        [Required]
        public int FutureFriendId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public string Message { get; set; }
       
    }
}