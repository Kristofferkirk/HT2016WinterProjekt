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
        public string TimeStamp { get; set; }
        public string ApproveFlag { get; set; }
        public string RejectFlag { get; set; }
        public string BlockFlag { get; set; }
        public string SpamFlag { get; set; }
    }
}