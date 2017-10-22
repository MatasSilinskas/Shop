using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Logic;

namespace AndroidGUI
{
    [Activity(Label = "RegisterActivity")]
    public class RegisterActivity : Activity
    {
        private EditText _username;
        private EditText _password;
        private EditText _email;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Register);

            Button register = FindViewById<Button>(Resource.Id.register);
            _email = FindViewById<EditText>(Resource.Id.register_email);
            _username = FindViewById<EditText>(Resource.Id.register_username);
            _password = FindViewById<EditText>(Resource.Id.register_password);
            RadioButton male = FindViewById<RadioButton>(Resource.Id.radioMale);
            RadioButton female = FindViewById<RadioButton>(Resource.Id.radioFemale);

            register.Click += delegate
            {
                if (male.Checked)
                {
                    RegisterPerson("Male");
                }
                else if (female.Checked)
                {
                    RegisterPerson("Female");
                }
                else
                {
                    Toast.MakeText(ApplicationContext, "Please select gender", ToastLength.Long).Show();
                }
            };
        }

        private void RegisterPerson(string gender)
        {
            Registration register = new Registration(_username.Text, _email.Text, _password.Text, gender);
            if (register.RegisteredSuccessfully)
            {
                Toast.MakeText(ApplicationContext, "Registration was succesful!", ToastLength.Long).Show();
                StartActivity(new Intent(this, typeof(LoginActivity)));
            }
            else
            {
                Toast.MakeText(ApplicationContext, "Registration failed", ToastLength.Long).Show();
            }
        }
    }
}

