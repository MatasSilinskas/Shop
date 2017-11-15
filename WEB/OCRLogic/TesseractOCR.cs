using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using Tesseract;
using System.IO;

namespace WEB.OCRLogic
{
    public class TesseractOCR : IRecognize
    {

        static TesseractOCR _ocr;

        private TesseractOCR() { }

        public string DoRecognition(byte[] image)
        {
 
            try
            {
                using (var engine = new TesseractEngine(@"C:\Users\kasparas\Desktop\Universiteto projektai\Shop\WEB\OCRLogic\tessdata", "lit", EngineMode.Default))
                {
                    using (var img = PixConverter.ToPix((Bitmap)Image.FromStream(new MemoryStream(image))))
                    {
                        using (var page = engine.Process(img))
                        {
                            return page.GetText();
                        }
                    }
                }

            }
            catch (Exception e)
            {
                return "-1";
            }
        }

        public static TesseractOCR GetOCRObject()
        {
            if (_ocr == null)
            {
                _ocr = new TesseractOCR();
                return _ocr;
            }
            else
            {
                return _ocr;
            }
        }

    }
}