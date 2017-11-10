using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Cloud.Vision.V1;
using System.Diagnostics;
using System.Net.Http;

namespace Shop.WebAPI.OCRModule
{
    public class GoogleRecognition : IRecongnize
    {

        public bool DoRecognition(WriteLogic writer)
        {
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", @"../../Recognition-909184a6878c.json");
            var image = Image.FromFile(_imagePath);
            var client = ImageAnnotatorClient.Create();
            var response = client.DetectText(image);
            string[] container = { };
            string query = "";

            try
            {

                foreach (var annotation in response)
                {
                    if (annotation.Description != null)
                    {
                        container = annotation.Description.Split('\n');
                        Debug.WriteLine(annotation.Description);
                    }

                }
               
                writer.Write(_user, query);
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
            throw new NotImplementedException();
        }
    }
}
