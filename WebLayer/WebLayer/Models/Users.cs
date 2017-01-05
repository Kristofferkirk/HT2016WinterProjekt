using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebLayer.Models
{
    public class Users
    {
        [Key]
        public int UId { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string Name { get; set; }

        public string City { get; set; }
        public string Country { get; set; }
        public int Age { get; set; }
        public bool Searchable { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        



    }
   
}