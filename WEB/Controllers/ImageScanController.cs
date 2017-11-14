using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEB.Models;

namespace WEB.Controllers
{
    public class ImageScanController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase postedImage)
        {
            if (postedImage != null && postedImage.ContentLength > 0)
            {
               
                return View();
            }
            else
            {
                return View();
            }
        }
    }
}