using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using Tesseract;
using System.IO;
using System.Globalization;

namespace Logic
{

    public class OCR : IRecongnize
    {
        string _imagePath;
        string _user;
        string _rezultatas = "";
        string _dbrezultatas = "";
        string _shopName;
        public OCR(string pathToImage, string username)
        {
            _imagePath = pathToImage;
            _user = username;
        }

        public bool DoRecognition(WriteLogic writer)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
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
                                    _shopName = iter.GetText(PageIteratorLevel.Word);
                                    iter.Next(PageIteratorLevel.Word);
                                }
          
                                do
                                {
                                    
                                    do
                                    {
                                        do
                                        {
                                            _rezultatas += _shopName + " ";
                                            _dbrezultatas += _user + "/" + _shopName + "/";
                                            do
                                            {
                                                decimal price = 0; ;
                                                _rezultatas += iter.GetText(PageIteratorLevel.Word) + " ";
                                                if(decimal.TryParse(iter.GetText(PageIteratorLevel.Word), out price))
                                                {
                                                    _dbrezultatas = _dbrezultatas.TrimEnd();
                                                    _dbrezultatas += "/" + iter.GetText(PageIteratorLevel.Word) + "/";
                                                }
                                                else _dbrezultatas += iter.GetText(PageIteratorLevel.Word) + " ";

                                            } while (iter.Next(PageIteratorLevel.TextLine, PageIteratorLevel.Word));
                                            _rezultatas += Environment.NewLine;
                                            _dbrezultatas += Environment.NewLine;
                                        } while (iter.Next(PageIteratorLevel.Para, PageIteratorLevel.TextLine));
                                    } while (iter.Next(PageIteratorLevel.Block, PageIteratorLevel.Para));
                                } while (iter.Next(PageIteratorLevel.Block));
                            }
                            
                        }
                    }
                }
                writer.Write(_user, _rezultatas, _dbrezultatas);
                return true;
            }
            catch (Exception e)
            {
                writer.Write(_user, e.Message);
                return false;
            }
        }

        public double ReturnAccuracy()
        {
            // To be implemented
            throw new NotImplementedException();
        }
    }
}

