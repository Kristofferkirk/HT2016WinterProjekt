using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebLayer.Models
{
    public class Profile
    {
        [Key]
        [Required]
        public int Pid { get; set; }
        [Required]
        public int UserId { get; set; }
        
    }
}