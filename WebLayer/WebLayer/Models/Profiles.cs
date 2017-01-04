using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebLayer.Models
{
    public class Profiles
    {
        [Key]
        public int UId { get; set; }
        
       
        public string Name { get; set; }

        public string City { get; set; }
        public string Country { get; set; }
        public int Age { get; set; }
        
        public string Description { get; set; }

    }
}