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
        string _rating;
        enum Ratings {low, med, high};
        
        List<int> _ratingArray = new List<int>();
        
                
        public Store (string name, string rating)
        {
            _name = name;
            _rating = rating;
        }
        public double CountAvg (string rating)
        {
            if (rating == "low")
            {
                _ratingArray.Add((int)Ratings.low);
            }
            else if (rating == "med")
            {
                _ratingArray.Add((int)Ratings.med);
            }
            else if (rating == "high")
            {
                _ratingArray.Add((int)Ratings.high);
            }
            return _ratingArray.Average();
        }
       
    }
}
