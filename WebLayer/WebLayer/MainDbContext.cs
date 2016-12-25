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
    }
}