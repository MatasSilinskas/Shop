using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Http.ModelBinding;
using System.Web.Script.Serialization;
using WEB.Interfaces;
using WEB.Models;

namespace WEB.RegisterLogic
{
    public class Register
    {
        private string _username;
        private string _email;

        private readonly IUserAccountDbContext _context;
        public bool EmailExists { get; set; }
        public bool UsernameExists { get; set; }

        public Register(IUserAccountDbContext context, string username, string email)
        {
            _context = context;
            _username = username;
            _email = email;

            CheckUsername();
            CheckEmail();

        }

        private void CheckUsername()
        {
            if (_context.userAccount.Any(x => x.Username == _username))
            {
                UsernameExists = true;
            }
            else
            {
                UsernameExists = false;
            }
        }

        private void CheckEmail()
        {
            if (_context.userAccount.Any(x => x.Email == _email))
            {
                EmailExists = true;
            }
            else
            {
                EmailExists = false;
            }
        }
    }
}