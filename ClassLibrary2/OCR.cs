using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using Tesseract;
using System.IO;

namespace Logic
{
    public class OCR
    {
        string _imagePath;
        string _user;
        public OCR(string pathToImage, string username)
        {
            _imagePath = pathToImage;
            _user = username;
        }

        public bool DoRecognition()
        {
            string rezultatas = "";
            string shopName;
            try
            {
                using (var engine = new TesseractEngine("../../../tessdata", "lit", EngineMode.Default))
                {
                    using (var img = Pix.LoadFromFile(_imagePath))
                    {
                        using (var page = engine.Process(img))
                        {
                            using (var iter = page.GetIterator())
                            {

                                using (StreamWriter sw = new StreamWriter(@"../../kasparas.txt", true))
                                {
                                    iter.Begin();
                                    shopName = iter.GetText(PageIteratorLevel.Word);
                                    iter.Next(PageIteratorLevel.Word);
                                }
          
                                do
                                {
                                    
                                    do
                                    {
                                        do
                                        {
                                            rezultatas += shopName + " ";
                                            do
                                            {
                                                rezultatas += iter.GetText(PageIteratorLevel.Word) + " ";
                                            } while (iter.Next(PageIteratorLevel.TextLine, PageIteratorLevel.Word));
                                            rezultatas += Environment.NewLine;
                                        } while (iter.Next(PageIteratorLevel.Para, PageIteratorLevel.TextLine));
                                    } while (iter.Next(PageIteratorLevel.Block, PageIteratorLevel.Para));
                                } while (iter.Next(PageIteratorLevel.Block));
                            }
                            
                        }
                    }
                }
                using (System.IO.StreamWriter file =
          new System.IO.StreamWriter(@"../../" + _user + ".txt", true))
                {
                    file.Write(rezultatas);
                    return true;
                }
            }
            catch (Exception e)
            {
                using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(@"../../" + _user + ".txt", true))
                {
                    file.Write(e.Message);
                    return false;
                }
            }
        }
    }
}
