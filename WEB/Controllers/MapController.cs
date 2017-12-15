using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace WEB.Controllers
{
    public class MapController : Controller
    {
        // GET: Map
        public ActionResult Index(string shop)
        {
            ViewBag.Shop = shop;
            return View();
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