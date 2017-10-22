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
            Button scan = FindViewById<Button>(Resource.Id.scan_button);
            Button customItems = FindViewById<Button>(Resource.Id.custom_items);

            top5.Click += delegate
            {
                var Top5Activity = new Intent(this, typeof(TopFiveActivity));
                Top5Activity.PutExtra("username", _username);
                StartActivity(Top5Activity);
            };

            itemsByDate.Click += delegate
            {
                var ItemsByDate = new Intent(this, typeof(ItemsByDateActivity));
                ItemsByDate.PutExtra("username", _username);
                StartActivity(ItemsByDate);
            };

            scan.Click += delegate
            {
                var scanActivity = new Intent(this, typeof(ScanActivity));
                scanActivity.PutExtra("username", _username);
                StartActivity(scanActivity);
            };
            customItems.Click += delegate
            {
                var scanActivity = new Intent(this, typeof(CustomItemsActivity));
                scanActivity.PutExtra("username", _username);
                StartActivity(scanActivity);
            };

        }    
    }
}