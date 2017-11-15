using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using Google.Cloud.Vision.V1;

namespace WEB.OCRLogic
{
    public class GoogleOCR : IRecognize
    {
        private static GoogleOCR _detector;
        private GoogleOCR()
        {
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", @"C:\Users\kasparas\Desktop\Universiteto projektai\Shop\WEB\OCRLogic\Recognition-909184a6878c.json");
        }
        public string DoRecognition(byte[] image)
        {
            var imageToScan = Google.Cloud.Vision.V1.Image.FromBytes(image);
            var client = ImageAnnotatorClient.Create();
            ImageContext language = new ImageContext();
            language.LanguageHints.Add("lt");
            var response = client.DetectDocumentText(imageToScan,language).Text;
            return response;

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