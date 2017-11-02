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
                SwitchActivity(typeof(TopFiveActivity));
            };
            itemsByDate.Click += delegate
            {
                SwitchActivity(typeof(ItemsByDateActivity));
            };
            scan.Click += delegate
            {
                SwitchActivity(typeof(ScanActivity));
            };
            customItems.Click += delegate
            {
                SwitchActivity(typeof(CustomItemsActivity));
            };
        }
        public void SwitchActivity(Type window)
        {
            var activity = new Intent(this, window);
            activity.PutExtra("username", _username);
            StartActivity(activity);
        }
    }
}