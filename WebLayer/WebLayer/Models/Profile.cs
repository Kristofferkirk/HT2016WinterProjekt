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
        public string Name { get; set; }
        public int Age { get; set; }
        public string ImagePath { get; set; }
        public string SexOrient { get; set; }
        public string Description { get; set; }
        public string Searchable { get; set; }
        public string City { get; set; }
    }
}