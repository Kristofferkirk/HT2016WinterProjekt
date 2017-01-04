using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebLayer.Models
{
    public class Images
    {
       [Key]
       public int Iid { get; set; }

       public int ImageSize { get; set; }
       public String FileName { get; set; }
       public byte[] ImageData { get; set; }
      
    }
}