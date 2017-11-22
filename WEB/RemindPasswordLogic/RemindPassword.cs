using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using WEB.Interfaces;
using WEB.Models;

namespace WEB.RemindPasswordLogic
{
    public class RemindPassword
    {
        private string _from = "shopengine@outlook.com";
        private string _fromPassword = "shop1234";
        private string _client = "smtp-mail.outlook.com";
        private readonly string _subject = "CSE new password";
        private readonly string _passwordChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        private readonly string _bodyBegin = "Here`s your old username and new auto generated password: \n\n";
        private readonly string _bodyEnd = "\n\nOnce you log in with this generated password, it is recommended" +
            "that you change it in the \"Account Settings\" section ";
        private readonly IUserAccountDbContext _context;
        private int _minPasswordLength = 5;
        private int _maxPasswordLength = 12;

        public bool EmailSent { get; set; } = true;

        public RemindPassword(IUserAccountDbContext context)
        {
            _context = context;
        }

        public void SendNewPassword(string email, string username)
        {
            var password = GeneratePassword();
            Thread send = new Thread(o => SendMail(email, username, password));
            send.Start();
            Thread updatePw = new Thread(o => UpdatePassword(email, password));
            updatePw.Start();

            try
            {
                send.Join();
                updatePw.Join();
            }
            catch
            {
                EmailSent = false;
            }

        }

        private string GeneratePassword()
        {
            Random random = new Random();
            return new string(Enumerable.Repeat(_passwordChars, random.Next(_minPasswordLength, _maxPasswordLength))
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private void SendMail(string email, string username, string password)
        {
            MailMessage message = new MailMessage(_from, email, _subject, _bodyBegin + $"Username: {username}\nPassword: {password}" + _bodyEnd);
            SmtpClient client = new SmtpClient(_client)
            {
                Port = 587,
                Credentials = new NetworkCredential(_from, _fromPassword),
                EnableSsl = true
            };
            client.Send(message);
        }

        private void UpdatePassword(string email, string password)
        {
            var user = _context.userAccount.Single(x => x.Email == email);
            user.Password = password;
            user.ConfirmPassword = password;
            _context.SaveChanges();
        }
    }
}