using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.WebAPI.OCRModule
{
    public interface IRecongnize
    {
        bool DoRecognition(WriteLogic writer);
        double ReturnAccuracy();
    }
}
