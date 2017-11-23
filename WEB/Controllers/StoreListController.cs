using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEB.Interfaces;
using WEB.Models;
using WEB.ShopFromAListLogic;

namespace WEB.Controllers
{
    public class StoreListController : Controller
    {
        private readonly IUserAccountDbContext _context;
        public StoreListController(IUserAccountDbContext context)
        {
            _context = context;
        }
        // GET: StoreList
        public ActionResult StoreList()
        {
            PurchaseList purchaseList = new PurchaseList();
            purchaseList.listOfProducts = _context.purchasedItem.ToList<PurchasedItem>();
            return View(purchaseList);
        }

        [HttpPost]
        public ActionResult StoreList(PurchaseList purchaseList)
        {
            try
            {
                var _selectedProducts = purchaseList.listOfProducts.Where(x => x.IsChecked == true).ToList<PurchasedItem>();
                List<string> list = new List<string>();
                foreach (var item in _selectedProducts)
                {
                    if (!list.Contains(item.ItemName))
                    {
                        list.Add(item.ItemName);
                    }

                }
                FromList fromList = new FromList(_context, list, DateTime.Now.AddMonths(-1));
                ViewBag.rezult = fromList.ReturnInfo<string>() + " Final price for your selected items is: " + fromList.ReturnInfo<double>().ToString();
                ViewBag.Shop = fromList.ReturnInfo<string>();
                return View("StoreList");
            }
            catch
            {
                ViewBag.rezult = "Please some check boxes to add items to your list";
                return View("StoreList");
            }

        }
    }
}