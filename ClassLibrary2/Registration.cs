using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

namespace Logic
{
    public class Registration
    {
        bool _registeredSuccessfully = false;
        static string _usersTextFilePath = @"..\..\users.txt";

        public bool RegisteredSuccessfully { get => _registeredSuccessfully; }

        public Registration(string username, string email, string password, string gender)
        {
            WriteToFile(PrepareStringToWrite(username,email,password,gender));
        }

        public Registration()
        {

        }

        private bool CheckIfUsernameExists(string username)
        {
            string[] readLines = File.ReadAllLines(_usersTextFilePath);
            var totalUsers = readLines.Length;
            for (int i = 0; i < totalUsers; i++)
            {
                var user = readLines[i].Split(';')[0];
                if (user == username)
                {
                    return true;
                }
            }
            return false;
        }

        private string PrepareStringToWrite(string username, string email, string password, string gender)
        {
            string stringToWrite = "";
            if (!CheckIfUsernameExists(username))
            {
               stringToWrite = username + ";" + password + ";" + email + ";" + gender;
            }
            return stringToWrite;
        }

        private void WriteToFile(string stringToWrite)
        {
            if (stringToWrite != "")
            {
                using (StreamWriter file =
                        new StreamWriter(_usersTextFilePath, true))
                {

                        file.WriteLine(stringToWrite);
                        _registeredSuccessfully = true;
                }
            }
        }
    }
}
