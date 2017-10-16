using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Logic
{
    public class ReadLogic
    {
        string _path;
        public string[] ReadFile(string path)
        {
            _path = path;
            return File.ReadAllLines(_path);
        }
        
    }
}
