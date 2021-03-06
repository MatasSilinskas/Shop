using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
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
        DbSet<Shop> shop { get; set; }
        DbSet<Receipt> receipt { get; set; }
        DbSet<Discounts> discounts { get; set; }

        DbEntityEntry<TEntity> Entry<TEntity>(
    TEntity entity
) where TEntity : class;
        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
