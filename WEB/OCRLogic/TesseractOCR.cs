using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using Tesseract;
using System.Collections;
using System.IO;
using System.Diagnostics;
using System.Threading.Tasks;

namespace WEB.OCRLogic
{
    public class TesseractOCR
    {

        static TesseractOCR _ocr;

        private TesseractOCR() { }

        public string DoRecognitionAsync(Bitmap image)
        {
            string text = String.Empty;
            try
            {
                using (var engine = new TesseractEngine(@"C:\Users\kasparas\Desktop\Universiteto projektai\Shop\WEB\OCRLogic\tessdata", "eng", EngineMode.Default))
                {
                    using (MemoryStream mem = new MemoryStream())
                    {
                        image.Save(mem, System.Drawing.Imaging.ImageFormat.Bmp);
                        using (var img = PixConverter.ToPix((Bitmap)Image.FromStream(mem)))
                        {
                            using (var page = engine.Process(img, PageSegMode.SingleBlock))
                            {

                                using (var iterator = page.GetIterator())
                                {
                                    iterator.Begin();
                                    do
                                    {
                                        do
                                        {

                                            do
                                            {

                                                if (iterator.IsAtBeginningOf(PageIteratorLevel.TextLine))
                                                {
                                                    text += iterator.GetText(PageIteratorLevel.Word);
                                                }


                                            } while (iterator.Next(PageIteratorLevel.Word, PageIteratorLevel.Block));
                                        } while (iterator.Next(PageIteratorLevel.TextLine, PageIteratorLevel.Word));
                                    } while (iterator.Next(PageIteratorLevel.Para, PageIteratorLevel.TextLine));
                                }
                            }

                        }
                    }
                    return text;
                }
          

            }
            catch (Exception e)
            {
                return text;
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