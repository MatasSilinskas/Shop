using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEB.Classification;
using WEB.Interfaces;
using WEB.Models;

namespace WEB.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly IUserAccountDbContext _context;
        public StatisticsController(IUserAccountDbContext context)
        {
            _context = context;
        }
        // GET: Statistics
        public ActionResult Statistics()
        {
            MainCategory mainCategory = new MainCategory(_context);
            mainCategory.Train();
            mainCategory.CategorizeAll();
            ViewBag.Categories = mainCategory.Categories;

            NutritionValue nutrition = new NutritionValue(_context);
            nutrition.Train();
            nutrition.CategorizeAll();
            nutrition.CategorizeAllByCategories();
            ViewBag.Nutrition = nutrition.Categories;

            HealthCheck healthCheck = new HealthCheck(_context);
            healthCheck.Train();
            healthCheck.CategorizeAll();
            healthCheck.CategorizeAllByCategories();

            var id = Convert.ToInt32(Session["UserID"]);
            var items = _context.purchasedItem.Where(x => x.UserId == id).ToList();

            return View(items);
        }
    }
}