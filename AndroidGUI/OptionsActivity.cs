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

namespace AndroidGUI
{
    [Activity(Label = "OptionsActivity")]
    public class OptionsActivity : Activity
    {
        string _username;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Options);
            _username = Intent.GetStringExtra("username");

            Button top5 = FindViewById<Button>(Resource.Id.top_five);
            Button itemsByDate = FindViewById<Button>(Resource.Id.items_by_date);
            top5.Click += delegate
            {
                var Top5Activity = new Intent(this, typeof(MyListActivity));
                Top5Activity.PutExtra("username", _username);
                StartActivity(Top5Activity);
            };
            itemsByDate.Click += delegate
            {
                var ItemsByDate = new Intent(this, typeof(ItemsByDateActivity));
                ItemsByDate.PutExtra("username", _username);
                StartActivity(ItemsByDate);
            };
            
        }
    }
}