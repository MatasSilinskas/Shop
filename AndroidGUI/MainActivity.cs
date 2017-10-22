using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using System;

namespace AndroidGUI
{
    [Activity(Label = "AndroidGUI", MainLauncher = true)]
    public class MainActivity : TabActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            
            ActionBar.Hide();

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.StartUp);

            CreateTab(typeof(LoginActivity), "login", "Login");
            CreateTab(typeof(RegisterActivity), "register", "Register");

        }
        private void CreateTab(Type activityType, string tag, string label)
        {
            var intent = new Intent(this, activityType);
            intent.AddFlags(ActivityFlags.NewTask);

            var spec = TabHost.NewTabSpec(tag);
            spec.SetIndicator(label);
            spec.SetContent(intent);

            TabHost.AddTab(spec);
        }
    }
}

