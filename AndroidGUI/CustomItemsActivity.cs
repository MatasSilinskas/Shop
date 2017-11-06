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
using Android.Graphics;

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
            Button esitimate = FindViewById<Button>(Resource.Id.estimate);
            Button gmap = FindViewById<Button>(Resource.Id.gmap);
            EditText editText = FindViewById<EditText>(Resource.Id.add_item_text);

            List<string> items = new List<string>();
            ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, items);
            customItems.Adapter = adapter;

            addItem.Click += delegate
            {
                adapter.Add(editText.Text);
                editText.Text = "";
            };

            //just an example
            //susieti su logikos klase
            esitimate.Click += delegate
            {
                AlertDialog.Builder dialog = new AlertDialog.Builder(this);
                AlertDialog alert = dialog.Create();

                alert.SetTitle("Estimation results");
                alert.SetMessage("It is recommended that you shop in Maxima.");
                alert.SetButton("Got it!", (c, ev) =>
                {
                     
                });
                alert.Show();
            };

            gmap.Click += delegate
            {
                var gmapActivity = new Intent(this, typeof(Map));
                StartActivity(gmapActivity);
            };

            
        }
    }
}