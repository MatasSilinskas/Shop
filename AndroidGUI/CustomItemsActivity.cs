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
    [Activity(Label = "CustomItemsActivity")]
    public class CustomItemsActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.CustomItems);

            ListView customItems = FindViewById<ListView>(Resource.Id.custom_items);
            Button addItem = FindViewById<Button>(Resource.Id.add_item_button);
            EditText editText = FindViewById<EditText>(Resource.Id.add_item_text);

            List<string> items = new List<string>();
            ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, items);
            customItems.Adapter = adapter;

            addItem.Click += delegate
            {
                adapter.Add(editText.Text);
                editText.Text = "";
            };
        }
    }
}