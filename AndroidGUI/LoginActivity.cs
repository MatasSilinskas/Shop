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
    [Activity(Label = "Login")]
    public class LoginActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Login);

            Button Login = FindViewById<Button> (Resource.Id.login);

            Login.Click += delegate
            {
                EditText username = FindViewById<EditText>(Resource.Id.login_username);
                EditText password = FindViewById<EditText>(Resource.Id.login_password);
               /* Authentication login = new Authentication(username.Text, password.Text);

                if (login.Authenticated) somethings wrong with file
                {*/
                    var mainActivity = new Intent(this, typeof(OptionsActivity));
                    mainActivity.PutExtra("username", username.Text);
                    StartActivity(mainActivity);
                //}
                //apdoroti nepavykųsi loginą
            };
        }
    }
}