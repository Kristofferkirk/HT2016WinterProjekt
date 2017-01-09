using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebLayer.Models
{
    public class Message
    {
        /// under construction
        [Key]
        [Required]
        public int MessageID { get; set; }
        public int UserID { get; set; }
        public int PostUserID { get; set; }
        public string PostMessage { get; set; }
        public string DateSent { get; set; }
    }
}