using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WEB.Interfaces;

namespace WEB.Models
{
    public class UserAccountDbContext : DbContext, IUserAccountDbContext
    {
        public DbSet<UserAccount> userAccount { get; set; }
        public DbSet<PurchasedItem> purchasedItem { get; set; }
        public DbSet<Top5Item> top5Item { get; set; }
        public DbSet<Shop> shop { get; set; }
        public DbSet<Receipt> receipt { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<UserAccountDbContext>(null);
            base.OnModelCreating(modelBuilder);
        }

        public System.Data.Entity.DbSet<WEB.Models.ForgotPassword> ForgotPasswords { get; set; }
    }
}