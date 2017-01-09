using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebLayer.Models
{
    public class Friend
    {
        [Key]
        [Column(Order = 1)]
        public int User1 { get; set; }
        [Key]
        [Column(Order = 2)]
        public int User2 { get; set; }
        public string Name1 { get; set; }
        public string Name2 { get; set; }
    }
}