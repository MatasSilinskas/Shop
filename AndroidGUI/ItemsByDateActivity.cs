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
    [Activity(Label = "ItemsByDateActivity")]
    public class ItemsByDateActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.ItemsByDate);

            ListView itemsByDate = FindViewById<ListView>(Resource.Id.items_by_date);

            //just an example
            string[] items = new string[] { "Vegetables", "Fruits", "Flower Buds", "Legumes", "Bulbs", "Bread", "Milk" };
            ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, items);
            itemsByDate.Adapter = adapter;
        }
    }
}