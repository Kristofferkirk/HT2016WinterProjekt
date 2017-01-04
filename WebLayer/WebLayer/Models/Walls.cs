using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebLayer.Models
{
    public class Walls
    {
        [Key]
        public int Mid { get; set; }
        public string Message { get; set; }
    }
}