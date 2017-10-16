using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public struct Split
    {
        string _line;
        string[] _splitUpLine;
        public string[] SplitLine(string line)
        {
            string[] _data = new string[5];
            _line = line;
            _splitUpLine = line.Split(' ');
            _data[0] = _splitUpLine[0];
            _data[1] = _splitUpLine[1];
            int i = 2;
            while (i < _splitUpLine.Length - 2)
            {
                _data[2] +=" " + _splitUpLine[i];
                i++;
            }
            _data[2] = _data[2].TrimStart(' ');
            _data[3] = _splitUpLine[i];
            _data[4] = _splitUpLine[i + 1];
            return _data;

        }
    }
}
