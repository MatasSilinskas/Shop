using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace WEB.OCRLogic
{
    interface IRecognize
    {
        Task<string> DoRecognitionAsync(Bitmap image);
    }
}
