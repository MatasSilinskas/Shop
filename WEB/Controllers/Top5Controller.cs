using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEB.Interfaces;
using WEB.Top5Logic;

namespace WEB.Controllers
{
    public class Top5Controller : Controller
    {
        private readonly IUserAccountDbContext _context;
        public Top5Controller(IUserAccountDbContext context)
        {
            _context = context;
        }
        // GET: Top5
        public ActionResult Top5()
        {
            var items = new Top5(Convert.ToInt32(Session["UserID"]), _context);
            ViewBag.Warning = items.Warning;

            if (items.Recommendation.Key != null)
            {
                ViewBag.Shop = items.Recommendation.Key;
            }
            else
            {
                ViewBag.Shop = "";
            }

            ViewBag.Price = items.Recommendation.Value;
            return View(items.Items);
        }
    }
}