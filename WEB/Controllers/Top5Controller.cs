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

        protected override void OnAuthorization(System.Web.Mvc.AuthorizationContext filterContext)
        {
            //lets say you set session value to a positive integer
            var LoginType = Convert.ToInt32(filterContext.HttpContext.Session["UserID"]);
            if (LoginType == 0)
            {
                filterContext.HttpContext.Response.Redirect(url: "~/");
            }

            base.OnAuthorization(filterContext);
        }
    }
}