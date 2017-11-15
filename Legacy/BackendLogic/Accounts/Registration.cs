using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Text.RegularExpressions;

namespace Logic
{
    public class Registration
    {
        bool _registeredSuccessfully = false;
        static string _usersTextFilePath = @"..\..\..\BackendLogic\Accounts\users.txt";

        public bool RegisteredSuccessfully { get => _registeredSuccessfully; }

        public Registration(string username, string email, string password, string gender)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (match.Success)
            {
                WriteToFile(PrepareStringToWrite(username, email, password, gender));
            }
            else
            {
                _registeredSuccessfully = false;
            }
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
