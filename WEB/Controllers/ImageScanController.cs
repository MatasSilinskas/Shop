using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using WEB.Models;
using WEB.OCRLogic;
using System.Linq.Expressions;

namespace WEB.Controllers
{
    public class ImageScanController : Controller
    {
        public ActionResult TestAjax()
        {
            
            if (!OCRFireHandle.IsOldUpdate(DateTime.Now) && OCRFireHandle.TimesFired > 0)
            {
                return Json(OCRFireHandle.GetList, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Index(string dummy)
        {
            if (dummy != null)
            {
                return View(dummy);
            }
            else
            {
                return View();
            }
        }


        [HttpPost]
        public ActionResult Index(HttpPostedFileBase postedImage)
        {
            if (postedImage != null && postedImage.ContentLength > 0)
            {
                byte[] image;
                using (Stream inputStream = postedImage.InputStream)
                {
                    MemoryStream memoryStream = inputStream as MemoryStream;
                    if (memoryStream == null)
                    {
                        memoryStream = new MemoryStream();
                        inputStream.CopyTo(memoryStream);
                    }
                    image = memoryStream.ToArray();
                }
 
                return View("Index", (object)GoogleOCR.GetGoogleOCR().DoRecognition(image));
            }
            else
            {
                return View();
            }
        }

        public ActionResult ValidatedAnswer(string input)
        {
            Parser.GetParserObject().OCRFired += OCRFireHandle.OCRFiredHandler;
            Parser.GetParserObject().CreateProductsFromString(input, Convert.ToInt32(HttpContext.Session["UserID"]));
            return RedirectToAction("Index");
        }
    }
}