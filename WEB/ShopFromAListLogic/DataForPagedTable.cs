using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using WEB.Interfaces;
using WEB.Models;
using MoreLinq;

namespace WEB.ShopFromAListLogic
{
    public class DataForPagedTable
    {
        private readonly IUserAccountDbContext _context;
        public int MaxPage { get; set; }
        public int CurrentPage { get; set; } = 0;
        public const int PageSize = 5;
        public List<PurchasedItem> ProductList { get; set; }

        public DataForPagedTable(IUserAccountDbContext context)
        {
            _context = context;
        }
        public void Search(int id, string filter)
        {
            ProductList = _context.purchasedItem
                .Where(x => x.UserId == id && (x.ItemName.ToUpper().Contains(filter.ToUpper()) || filter == ""))
                .OrderBy(x => x.ItemName)
                .GroupBy(x => x.ItemName)
                .AsEnumerable()
                .Select(grp => grp.MaxBy(x => x.Date))
                .ToList<PurchasedItem>();

            CountMaxPage();
        }

        public PurchaseList GetCurrentPage()
        {
            PurchaseList list = new PurchaseList
            {
                listOfProducts = ProductList
                    .Skip(CurrentPage * PageSize)
                    .Take(PageSize)
                    .ToList<PurchasedItem>()
            };

            return list;
        }
        public void Reset(int id)
        {
            ProductList = _context.purchasedItem
                .Where(x => x.UserId == id)
                .OrderBy(x => x.ItemName)
                .GroupBy(x => x.ItemName)
                .AsEnumerable()
                .Select(grp => grp.MaxBy(x => x.Date))
                .ToList();

            ProductList.ForEach(x => x.IsChecked = false);
            CountMaxPage();

        }
        
        private void CountMaxPage()
        {
            var count = ProductList.Count();
            MaxPage = (count / PageSize) - (count % PageSize == 0 ? 1 : 0);
        }

        public void PutChecks(List<PurchasedItem> purchaseList)
        {
            if (purchaseList != null)
            {
                foreach (var item in purchaseList)
                {
                    if (item.IsChecked)
                    {
                        ProductList.Where(x => x.ItemName == item.ItemName).FirstOrDefault().IsChecked = true;
                    }
                    else
                    {
                        ProductList.Where(x => x.ItemName == item.ItemName).FirstOrDefault().IsChecked = false;
                    }
                }
            }
        }
    }
}