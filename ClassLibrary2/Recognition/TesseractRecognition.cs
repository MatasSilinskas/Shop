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

    public class TesseractRecognition : IRecongnize
    {
        string _imagePath;
        string _user;
        string _rezultatas = "";
        string _dbrezultatas = "";
        string _shopName;
        public TesseractRecognition(string imagePath, string user)
        {
            _imagePath = imagePath;
            _user = user;
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
                                iter.Begin();
                                _shopName = iter.GetText(PageIteratorLevel.Word);
                                iter.Next(PageIteratorLevel.Word);
                                RecognizeIteration(iter);

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

        public void RecognizeIteration(ResultIterator iter)
        {
            do
            {
                _rezultatas += _shopName + " ";
                _dbrezultatas += _user + " " + _shopName + " ";
                do
                {
                    _rezultatas += iter.GetText(PageIteratorLevel.Word) + " ";
                    _dbrezultatas += iter.GetText(PageIteratorLevel.Word) + " ";
                    if (decimal.TryParse(iter.GetText(PageIteratorLevel.Word), out decimal price))
                    {
                        _rezultatas += iter.GetText(PageIteratorLevel.Word) + " ";
                        _dbrezultatas += iter.GetText(PageIteratorLevel.Word) + " ";

                    }
                } while (iter.Next(PageIteratorLevel.TextLine, PageIteratorLevel.Word));
                _rezultatas += Environment.NewLine;
                _dbrezultatas += DateTime.Today.Date.ToString("d") + Environment.NewLine;
            } while (iter.Next(PageIteratorLevel.Para, PageIteratorLevel.TextLine));
        }
    }
}

