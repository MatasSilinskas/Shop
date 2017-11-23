using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WEB.Models;

namespace WEB.Interfaces
{
    public interface IUserAccountDbContext
    {
        DbSet<UserAccount> userAccount { get; set; }
        DbSet<PurchasedItem> purchasedItem { get; set; }
        DbSet<Top5Item> top5Item { get; set; }
        DbSet<Shop> shop { get; set; }
        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
