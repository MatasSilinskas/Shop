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
    [Activity(Label = "MyListActivity")]
    public class MyListActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Top5);

            ListView list = FindViewById<ListView>(Resource.Id.list);
            ItemContainer top5 = (new TopFive(Intent.GetStringExtra("username"))).ObtainData();
            List<string> items = new List<string>();
            foreach(var item in top5)
            {
                items.Add(item.Name);
            }
            //string[] items = new string[] { "Vegetables", "Fruits", "Flower Buds", "Legumes", "Bulbs", "Tubers" };
            ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, items);
            list.Adapter = adapter;

            // Create your application here
        }
    }
}