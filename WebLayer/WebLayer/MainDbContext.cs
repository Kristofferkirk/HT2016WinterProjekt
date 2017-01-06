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
            : base("name=DefaultConnection")
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<MainDbContext>(null);
            base.OnModelCreating(modelBuilder);
        }
    
        public DbSet<Users> Users { get; set; }
        public DbSet<Profile> Profile { get; set; }
        public DbSet<Friends> Friends { get; set; }
        public DbSet<FriendRequests> Requests { get; set; }
        
    }
}