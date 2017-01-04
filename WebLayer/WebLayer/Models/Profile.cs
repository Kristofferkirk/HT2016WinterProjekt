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
        public int PId { get; set; }
        public int UserID { get; set; }
        public int PicID { get; set; }
        public string ImagePath {
            get
            {
                return "~/App_Data/uploads/profile.JPG";
            }
                }
        [Display(Name = "Display profile Image")]
        public bool DisplayItem { get; set; }
    }
}