using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB.OCRLogic
{
    public class OCRFireHandle
    {
        private static List<string> _list = new List<string>();
        public static List<string> GetList { get => _list; }

        private static DateTime _updated = new System.DateTime(1996, 6, 3, 22, 15, 0);

        private static int timesFired = 0;

        public static int TimesFired { get => timesFired;  }

        public static void OCRFiredHandler(object sender, OCRFiredEventArgs e)
        {

            _list.Add(e.UserName);
            _list.Add(e.TotalItems);
            _updated = DateTime.Now;
            timesFired++;

        }

        public static bool IsOldUpdate(DateTime time)
        {
            System.TimeSpan dif = time.Subtract(_updated);
            if (dif.Seconds > 2)
            {
                return true;
            }
            else
            {
                if (_updated.Subtract(time).Seconds > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}