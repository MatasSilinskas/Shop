using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.Diagnostics;
using Google.Cloud.Vision.V1;
using Newtonsoft.Json.Linq;
using System.Configuration;
using System.IO;
using System.Drawing.Imaging;

namespace WEB.OCRLogic
{
    public class GoogleOCR : IRecognize
    {
        private static GoogleOCR _detector;

        private GoogleOCR()
        {
           
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", ConfigurationManager.AppSettings["GoogleToken"]);
        }

            public string DoRecognition(Bitmap image)
            {
            using (MemoryStream memory = new MemoryStream())
            {
                ImageConverter converter = new ImageConverter();
                byte[] convImage = (byte[])converter.ConvertTo(image, typeof(byte[]));
                string scannedText = String.Empty;
                var imageToScan = Google.Cloud.Vision.V1.Image.FromBytes(convImage);
                var client = ImageAnnotatorClient.Create();

                ImageContext language = new ImageContext();
                language.LanguageHints.Add("lt");
                var response = client.DetectDocumentText(imageToScan, language);

                foreach (var page in response.Pages)
                {
                    foreach (var block in page.Blocks)
                    {
                        foreach (var para in block.Paragraphs)
                        {

                            foreach (var word in para.Words)
                            {
                                string wordResult = String.Empty;
                                string pattern = String.Empty;
                                JObject json = JObject.Parse(word.ToString());

                                for (var i = 0; i < word.Symbols.Count; i++)
                                {

                                    wordResult += json["symbols"][i]["text"];

                                    if (json["symbols"][i]["property"]["detectedBreak"] != null)
                                    {

                                        wordResult += " ";

                                    }

                                    if (json["symbols"][i]["text"].ToString() == "A")
                                    {
                                        if (json["symbols"][i].Next == null && json["symbols"][i].Previous == null)
                                        {
                                            wordResult += "\n";
                                        }
                                    }
                                }
                                scannedText += wordResult;
                            }

                        }
                    }
                }
                return scannedText;
                }
            }

            public static GoogleOCR GetGoogleOCR()
            {
                if (_detector == null)
                {
                    _detector = new GoogleOCR();
                    return _detector;
                }
                return _detector;
            }
    }
}