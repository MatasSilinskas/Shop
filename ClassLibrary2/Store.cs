using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Store
    {
        string _name;
        enum Ratings {low, med, high};
        int[] _ratingArray = new int [3];
        public Store (string name)
        {
            _name = name;
        }
        public double Rate (string rating)
        {
            Ratings ratings = new Ratings();
            for (int i = 0; i < 3; i++)
            {
                if (rating.Equals(Ratings.GetName(typeof(Ratings), i).ToString()))//&&(ratingArray[i]!=null))
                {
                    _ratingArray[i]++;
                }
               
                /*else if ((rating.Equals(Ratings.GetName(typeof(Ratings), i).ToString())) && (ratingArray[i] == null))
                {
                    ratingArray[i] = 1;
                }
                else if ((!rating.Equals(Ratings.GetName(typeof(Ratings), i).ToString())) && (ratingArray[i] == null))
                {
                    ratingArray[i] = 0;
                }*/
            }
            double low = (int)Ratings.low;
            double med = (int)Ratings.med;
            double high = (int)Ratings.high;
            return ((low * _ratingArray[0]) + (med * _ratingArray[1]) + (high * _ratingArray[2]))/3;


        }
    }
}
