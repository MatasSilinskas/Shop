using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WEB.Models
{
    public class UserAccountDbContext : DbContext
    {
        public DbSet<UserAccount> userAccount { get; set; }
        public DbSet<PurchasedItem> purchasedItem { get; set; }
        public DbSet<Top5> top5Items { get; set; }
        public DbSet<Top5Item> top5Item { get; set; }
        public DbSet<ShopFromList> shopFromList { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<UserAccountDbContext>(null);
            base.OnModelCreating(modelBuilder);
        }
    }
}