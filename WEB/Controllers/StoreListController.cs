using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private DataForPagedTable getData;
        public StoreListController(IUserAccountDbContext context)
        {
            _context = context;
            getData = new DataForPagedTable(_context);
        }
        public ActionResult OpenNew()
        {
            TempData["Data"] = null;
            return RedirectToAction("StoreList");
        }

        public ActionResult StoreList()
        {
            if (TempData["Data"] != null)
            {
                getData = TempData["Data"] as DataForPagedTable;
            }
            else
            {
                getData.Reset(Convert.ToInt32(Session["UserID"]));
                ChecksInDatabase(getData.ProductList);
            }
            PurchaseList purchaseList = getData.GetCurrentPage();
            ViewBag.MaxPage = getData.MaxPage;
            ViewBag.Page = getData.CurrentPage;
            TempData["Data"] = getData;
            return View(purchaseList);
        }

        [HttpPost]
        public ActionResult StoreList(PurchaseList purchaseList)
        {
            getData = TempData["Data"] as DataForPagedTable;
            getData.PutChecks(purchaseList.listOfProducts);
            var selectedProducts = getData.ProductList.Where(x => x.IsChecked == true).ToList<PurchasedItem>();
            if (selectedProducts.Count == 0)
            {
                ViewBag.rezult = "You haven`t selected any items!";
            }
            else
            {
                List<string> list = new List<string>();
                foreach (var item in selectedProducts)
                {
                    if (!list.Contains(item.ItemName))
                    {
                        list.Add(item.ItemName);
                    }

                }
                FromList fromList = new FromList(_context, list, DateTime.Now.AddMonths(-1));
                ViewBag.rezult = fromList.ReturnInfo<string>() + " Final price for your selected items is: " + fromList.ReturnInfo<double>().ToString();
                ViewBag.Shop = fromList.ReturnInfo<string>();
            }
            return View("StoreList");
        }

        [HttpPost]
        public ActionResult Search(PurchaseList purchaseList)
        {
            ChecksInDatabase(purchaseList.listOfProducts);
            getData.Search(Convert.ToInt32(Session["UserID"]), Request["Search"].ToString());
            TempData["Data"] = getData;
            return RedirectToAction("StoreList");
        }

        [HttpPost]
        public ActionResult NextPage(PurchaseList purchaseList)
        {
            GetPage(purchaseList, 1);
            return RedirectToAction("StoreList");
        }

        [HttpPost]
        public ActionResult PreviousPage(PurchaseList purchaseList)
        {
            GetPage(purchaseList, -1);
            return RedirectToAction("StoreList");
        }

        private void GetPage(PurchaseList purchaseList, int pageCount)
        {
            ChecksInDatabase(purchaseList.listOfProducts);
            if (TempData["Data"] != null)
            {
                getData = TempData["Data"] as DataForPagedTable;
            }
            getData.PutChecks(purchaseList.listOfProducts);
            getData.CurrentPage += pageCount;
            TempData["Data"] = getData;
        }

        private void ChecksInDatabase(List<PurchasedItem> purchaseList)
        {
            if (purchaseList != null)
            {
                foreach (var item in purchaseList)
                {
                    if (item.IsChecked)
                    {
                        _context.purchasedItem.Where(x => x.PurchasedItemId == item.PurchasedItemId).Single().IsChecked = true;
                    }
                    else
                    {
                        _context.purchasedItem.Where(x => x.PurchasedItemId == item.PurchasedItemId).Single().IsChecked = false;
                    }
                }
                _context.SaveChanges();
            }
        }
    }
}