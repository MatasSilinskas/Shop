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
        public UserAccountDbContext() { }
        public DbSet<UserAccount> userAccount { get; set; }
        public DbSet<PurchasedItem> purchasedItem { get; set; }
        public DbSet<Top5Item> top5Item { get; set; }
        public DbSet<Shop> shop { get; set; }
        public DbSet<Discounts> discounts { get; set; }
        public DbSet<Receipt> receipt { get; set; }
        public DbSet<ForgotPassword> ForgotPasswords { get; set; }
        public DbSet<Spending> spendings { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<UserAccountDbContext>(null);
            modelBuilder.Entity<UserAccount>().ToTable("dbo.UserAccounts");
            modelBuilder.Entity<PurchasedItem>().ToTable("dbo.PurchasedItems");
            modelBuilder.Entity<Receipt>().ToTable("dbo.Receipts");
            modelBuilder.Entity<Shop>().ToTable("dbo.Shops");
            modelBuilder.Entity<Spending>().ToTable("dbo.Spendings");
            base.OnModelCreating(modelBuilder);
        }        
    }
}