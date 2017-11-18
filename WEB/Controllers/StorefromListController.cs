using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http.Results;
using System.Web.Mvc;
using WEB.Models;
using WEB.ShopFromAListLogic;

namespace WEB.Controllers
{
    public class StorefromListController : Controller
    {
        List<string> list = new List<string>();
        public ActionResult StoreList()
        {
            PurchaseList purchaseList = new PurchaseList();
            using (UserAccountDbContext db = new UserAccountDbContext())
            {
                purchaseList.listOfProducts = db.purchasedItem.ToList<PurchasedItem>();
            }
            return View(purchaseList);
        }

        [HttpPost]
        public ActionResult StoreList(PurchaseList purchaseList)
        {
            if (purchaseList != null)
            {
                var _selectedProducts = purchaseList.listOfProducts.Where(x => x.IsChecked == true).ToList<PurchasedItem>();
                List<string> list = new List<string>();
                foreach (var item in _selectedProducts)
                {
                    list.Add(item.ItemName);
                }
                FromList fromList = new FromList(list, DateTime.Now.AddMonths(-1));
                ViewBag.rezult = fromList.ReturnStoreName();
                return View("StoreList");
            }
            else
            {
                ViewBag.rezult = "Please some check boxes to add items to your list";
                return View("StoreList");
            }

        }
    }
}
