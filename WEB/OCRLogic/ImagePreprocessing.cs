using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using Emgu.Util;

namespace WEB.OCRLogic
{
    public class ImagePreprocessing
    {
        static ImagePreprocessing _processor;

        private ImagePreprocessing () { }

        public Bitmap resizeImage(Bitmap image, int maxWidth, int maxHeight)
        {

            int width = image.Width;
            int height = image.Height;


            float ratioX = (float)maxWidth / width;
            float ratioY = (float)maxHeight / height;
            float ratio = Math.Min(ratioX, ratioY);


            int newWidth = (int)(width * ratioX);
            int newHeight = (int)(height * ratioY);


            Bitmap newImage = new Bitmap(newWidth, newHeight);


            using (Graphics graphics = Graphics.FromImage(newImage))
            {
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.DrawImage(image, 0, 0, newWidth, newHeight);
            }

                return image;
        }

        public bool IsValidSize(Bitmap image)
        {
                return  image.Width > 400 && image.Height > 200 ? false : true;
        }

        public Bitmap BinarizeImage (Bitmap image)
        {
            Image<Gray, byte> input = new Image<Gray,byte>(image);
            Image<Gray, byte> output = input.ThresholdAdaptive(new Gray(255), AdaptiveThresholdType.GaussianC, ThresholdType.Binary, 131, new Gray(3));
            String path = HttpContext.Current.Server.MapPath(@"~/OCRLogic/");
            Bitmap finalOutput = output.ToBitmap();
            finalOutput.Save(path + "output.jpg", ImageFormat.Jpeg);
            return finalOutput;
        }

        public static ImagePreprocessing GetProcessor()
        {
            if (_processor == null)
            {
                _processor = new ImagePreprocessing();
                return _processor;
            }
            else
            {
                return _processor;
            }
        }
    }
}