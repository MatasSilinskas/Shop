using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using WEB.Models;
using WEB.OCRLogic;
using WEB.Interfaces;
using System.Drawing;
using System.Linq.Expressions;

namespace WEB.Controllers
{
    public class ImageScanController : Controller
    {
        private readonly IUserAccountDbContext _context;

        public ImageScanController(IUserAccountDbContext context)
        {
            _context = context;
        }

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
                Bitmap image;
                using (Stream inputStream = postedImage.InputStream)
                {
                    MemoryStream memoryStream = inputStream as MemoryStream;
                    if (memoryStream == null)
                    {
                        memoryStream = new MemoryStream();
                        inputStream.CopyTo(memoryStream);
                    }

                    image = new Bitmap(memoryStream);
                }
                if (ImagePreprocessing.GetProcessor().IsValidSize(image))
                {
                    string scannedResult = GoogleOCR.GetGoogleOCR().DoRecognition(image);
                    ReceiptCreator.GetReceiptCreator(_context).PutReceipt(scannedResult, Convert.ToInt32(Session["UserID"]));
                    return View("Index", (object)scannedResult);
                } 
                else
                {
                    Bitmap fixedImage = ImagePreprocessing.GetProcessor().resizeImage(image, 400, 200);
                    string scannedResult = GoogleOCR.GetGoogleOCR().DoRecognition(fixedImage);
                    ReceiptCreator.GetReceiptCreator(_context).PutReceipt(scannedResult, Convert.ToInt32(Session["UserID"]));
                    return View("Index", (object)scannedResult);
                }
            }
            else
            {
                return View();
            }
        }

        public ActionResult ValidatedAnswer(string input)
        {
            Parser.GetParserObject().OCRFired += OCRFireHandle.OCRFiredHandler;
            Parser.GetParserObject().CreateProductsFromString(input, Convert.ToString(Session["Username"]));
            return RedirectToAction("Index");
        }
    }
}