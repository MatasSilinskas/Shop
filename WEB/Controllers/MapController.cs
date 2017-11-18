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
    }
}