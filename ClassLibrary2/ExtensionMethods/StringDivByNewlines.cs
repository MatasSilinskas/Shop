using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.ExtensionMethods
{
    public static class StringDivByNewlines
    {
        public static string DivideWithNewlines(this String str, int interval)
        {
            string _result;
            List<char> _tempCharArray = new List<char>();
            _tempCharArray.AddRange(str);
            for (int i = 0; i < _tempCharArray.Count - interval + 1; i += interval)
            {
                _tempCharArray.Insert(i, '\n');
            }
            _result = string.Join(" ", _tempCharArray.ToArray());
            return _result;
        }
    }
}
