using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Cloud.Vision.V1;
using System.Diagnostics;

namespace Logic
{
    public class GoogleRecognition : IRecongnize
    {
        string _imagePath;
        string _user;

        public GoogleRecognition(string imagePath, string user)
        {
            _imagePath = imagePath;
            _user = user;
        }


        public bool DoRecognition(WriteLogic writer)
        {
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", @"../../Recognition-909184a6878c.json");
            var image = Image.FromFile(_imagePath);
            var client = ImageAnnotatorClient.Create();
            var response = client.DetectText(image);
            string[] container = { };

            try
            {

                foreach (var annotation in response)
                {
                    if (annotation.Description != null && annotation.Description.Length > 15)
                    {
                        container = annotation.Description.Split('\n');
                    }

                }
                int temp = 1;
                string query = "";
                for (int i = container.Length / 2; i < container.Length; i++)
                {

                    query += container[0] + " " + container[temp] + " " + container[i] + Environment.NewLine;
                    temp++;
                }

                writer.Write(_user, query);
                return true;
            }
            catch (Exception)
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
