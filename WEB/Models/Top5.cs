using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB.Models
{
    public class Top5
    {
        public int Id { get; set; }
        public string Warning { get; set; }
        public List<Top5Item> Items { get; set; }
        public KeyValuePair<string, double> Recommendation { get; set; }

        public Top5(int id)
        {
            Id = id;
            Items = ObtainData();
            /*if (Items.Count >= 5)
            {*/
                ShopRecommendation(ShopsAndPrices());
            /*}
            else
            {
                Warning = "You haven`t scanned enough items yet. Please try again after scanning cheques with 5 or more distinct items";
                Items = null;
            }*/
        }

        public List<Top5Item> ObtainData()
        {
            using (UserAccountDbContext db = new UserAccountDbContext())
            {
                var items = db.purchasedItem
                    .Where(x => x.UserId == Id)
                    .GroupBy(x => x.ItemName)
                    .Select(group => new
                    {
                        Item = group.Key,
                        Price = group.Min(x => x.Price),
                        AmountOfTimesBought = group.Count(),
                        CheapestAt = group.OrderBy(x => x.Price).FirstOrDefault().ShopName
                    })
                    .OrderByDescending(x => x.AmountOfTimesBought)
                    .Take(5)
                    .ToList()
                    .Select(x => new Top5Item
                    {
                        Item = x.Item,
                        Price = x.Price,
                        AmountOfTimesBought = x.AmountOfTimesBought,
                        CheapestAt = x.CheapestAt
                    })
                    .ToList();

                return items;
            }
        }
        Dictionary<string, Dictionary<string, double>> ShopsAndPrices()
        {
            using (UserAccountDbContext db = new UserAccountDbContext())
            {
                Dictionary<string, Dictionary<string, double>> allShopsAndPrices = new Dictionary<string, Dictionary<string, double>>();
                foreach (var item in Items)
                {
                    var shops = db.purchasedItem
                        .Where(x => x.ItemName == item.Item && x.UserId == Id)
                        .GroupBy(x => new
                        {
                            x.ItemName,
                            x.ShopName
                        })
                        .Select(group => new
                        {
                            Shop = group.Key.ShopName,
                            Price = group.Min(x => x.Price)
                        })
                        .ToDictionary(d => d.Shop, d => d.Price);

                    allShopsAndPrices.Add(item.Item, shops);
                }

                return allShopsAndPrices;
            }
        }

        void ShopRecommendation(Dictionary<string, Dictionary<string, double>> allShopsAndPrices)
        {
            var shops = new Dictionary<string, double>();
            foreach (var shopAndPrice in allShopsAndPrices.Values)
            {
                foreach (var shop in shopAndPrice)
                {
                    if (!shops.ContainsKey(shop.Key))
                    {
                        shops.Add(shop.Key, 0);
                    }
                }
            }

            foreach (var shopAndPrice in allShopsAndPrices.Values.ToList())
            {
                foreach (var shop in shops.Keys.ToList())
                {
                    if (shopAndPrice.ContainsKey(shop))
                    {
                        shops[shop] += shopAndPrice[shop];
                    }
                    else
                    {
                        shops[shop] += shopAndPrice.Average(x => x.Value);
                        Warning = "Note: Some items haven`t been bought in certain shops, so the results may not be accurate.";
                    }
                }
            }

            Recommendation = shops.OrderBy(x => x.Value).FirstOrDefault();
        }
    }
}