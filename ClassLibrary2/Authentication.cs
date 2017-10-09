using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace Logic
{
    public class Authentication
    {
        readonly bool _authenticated = false;
        string _username;
        string _email;
        string _gender;
        string _password;
        static string _usersTextFilePath = @"..\..\..\Shop\users.txt";
        public bool Authenticated => _authenticated;
        public string Username { get => _username; }

        public Authentication(string username, string password)
        {
            _authenticated = Authenticate(username,password);
        }

        private bool Authenticate(string username, string password)
        {
            string[] readLines = File.ReadAllLines(_usersTextFilePath);
            var totalUsers = readLines.Length;

                for (int i = 0; i < totalUsers; i++)
                {
                    string[] separated = readLines[i].Split(';');

                var user = separated[0];
                var pass = separated[1];

                    if (user == username && pass == password)
                    {
                        _username = username;
                        _password = password;
                        _email = separated[2];
                        _gender = separated[3];
                        return true;

                    }
               
                }
            return false;
        }
    }
}
