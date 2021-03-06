﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using WEB.Models;
using WEB.OCRLogic;
using WEB.Interfaces;
using System.Drawing;
using System.Threading.Tasks;
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

        public ActionResult AjaxRequestReceipt()
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

        public ActionResult Index(string scannedText)
        {
            if (scannedText != null)
            {
                return View(scannedText);
            }
            else
            {
                return View();
            }
        }


        [HttpPost]
        public async Task<ActionResult> Index(HttpPostedFileBase postedImage)
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
                    var scannedResult = await GoogleOCR.GetGoogleOCR().DoRecognitionAsync(image);
                    try
                    {
                        ReceiptCreator.GetReceiptCreator(_context).PutReceipt(scannedResult, Convert.ToInt32(Session["UserID"]));
                        var lastId = _context.receipt.Max(x => x.ReceiptID);
                        var last = _context.receipt.Where(x => x.ReceiptID == lastId).FirstOrDefault();
                        return View("Index", (object)last.Content);

                    }
                    catch (WrongDateException e)
                    {
                        return View("Index", (object)("Couldn't detect date!\nInput: " + e.scannedText));
                    }
                    catch (WrongTimeException e)
                    {
                        return View("Index", (object)("Couldn't detect time!\nInput: " + e.scannedText));
                    }
                    catch (WrongShopException e)
                    {
                        return View("Index", (object)("Couldn't detect shop!\nInput: " + e.scannedText));
                    }
                } 
                else
                {
                    Bitmap fixedImage = ImagePreprocessing.GetProcessor().resizeImage(image, 400, 200);
                    var scannedResult = await GoogleOCR.GetGoogleOCR().DoRecognitionAsync(fixedImage);
                    try
                    {
                        ReceiptCreator.GetReceiptCreator(_context).PutReceipt(scannedResult, Convert.ToInt32(Session["UserID"]));
                        var lastId = _context.receipt.Max(x => x.ReceiptID);
                        var last = _context.receipt.Where(x => x.ReceiptID == lastId).FirstOrDefault();
                        return View("Index", (object)last.Content);

                    }
                    catch (WrongDateException e)
                    {
                        return View("Index", (object)("Couldn't detect date!\nInput: " + e.scannedText));
                    }
                    catch (WrongTimeException e)
                    {
                        return View("Index", (object)("Couldn't detect time!\nInput: " + e.scannedText));
                    }
                    catch (WrongShopException e)
                    {
                        return View("Index", (object)("Couldn't detect shop!\nInput: " + e.scannedText));
                    }
                }
            }
            else
            {
                return View();
            }
        }

        public ActionResult ValidatedAnswer(string input)
        {
            var lastId = _context.receipt.Max(x => x.ReceiptID);
            var last = _context.receipt.Where(x => x.ReceiptID == lastId).FirstOrDefault();
            last.Content = input;
            try
            {
                Parser.GetParserObject().OCRFired += OCRFireHandle.OCRFiredHandler;
                Parser.GetParserObject().CreateProductsFromString(last, Convert.ToString(Session["Username"]));
            } catch (WrongPriceException e)
            {
                return View("Index", (object)("Wrong products format! Input: " + e.Price));
            }
            return RedirectToAction("Index");
        }
    }
}