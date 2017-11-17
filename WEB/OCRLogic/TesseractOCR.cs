using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using Tesseract;
using System.Collections;
using System.IO;
using System.Diagnostics;

namespace WEB.OCRLogic
{
    public class TesseractOCR : IRecognize
    {

        static TesseractOCR _ocr;

        private TesseractOCR() { }

        public string DoRecognition(byte[] image)
        {
            string text = "";
            try
            {
                using (var engine = new TesseractEngine(@"C:\Users\kasparas\Desktop\Universiteto projektai\Shop\WEB\OCRLogic\tessdata", "eng", EngineMode.Default))
                {
                    using (var img = PixConverter.ToPix((Bitmap)Image.FromStream(new MemoryStream(image))))
                    {
                        using (var page = engine.Process(img,PageSegMode.SingleBlock))
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