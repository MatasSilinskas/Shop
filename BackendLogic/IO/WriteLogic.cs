﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Shop.WebAPI.Data
{
    public class WriteLogic
    {
        public void Write(string _user, string rezultatas)
        {
            using (StreamWriter file = new System.IO.StreamWriter(@"../../../BackendLogic/Accounts/" + _user + ".txt", true))
            {
                file.Write(rezultatas);
            }
        }

        public void Write(string _user, string rezultatas1, string rezultatas2)
        {
            using (StreamWriter file = new System.IO.StreamWriter(@"../../../BackendLogic/Accounts/" + _user + ".txt", true))
            {
                file.Write(rezultatas1);
                using (System.IO.StreamWriter file2 = new System.IO.StreamWriter(@"../../../BackendLogic/Accounts/" + "database.txt", true))
                {
                    file2.Write(rezultatas2);
                }
            }
        }
    }
}
