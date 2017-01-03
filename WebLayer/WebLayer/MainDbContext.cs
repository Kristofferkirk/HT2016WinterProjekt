using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using WebLayer.Models;



namespace WebLayer
{
    public class MainDbContext : DbContext
    {
        public MainDbContext()
            :base("name=DefaultConnection")
        {

        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Images> Images { get; set; }

        public System.Data.Entity.DbSet<WebLayer.Models.Profiles> Profiles { get; set; }

        public System.Data.Entity.DbSet<WebLayer.Models.Profile> Profiles1 { get; set; }
    }
}