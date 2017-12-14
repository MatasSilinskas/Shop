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
        public DbSet<Shop> shop { get; set; }
        public DbSet<Discounts> discounts { get; set; }
        public DbSet<Receipt> receipt { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<UserAccountDbContext>(null);
            modelBuilder.Entity<UserAccount>().ToTable("dbo.UserAccounts");
            modelBuilder.Entity<PurchasedItem>().ToTable("dbo.PurchasedItems");
            modelBuilder.Entity<Receipt>().ToTable("dbo.Receipts");
            modelBuilder.Entity<Shop>().ToTable("dbo.Shops");
            base.OnModelCreating(modelBuilder);
        }

        public System.Data.Entity.DbSet<WEB.Models.ForgotPassword> ForgotPasswords { get; set; }

        
    }
}