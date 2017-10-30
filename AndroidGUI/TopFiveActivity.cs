﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
//using Logic;

namespace AndroidGUI
{
    [Activity(Label = "MyListActivity")]
    public class TopFiveActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.TopFive);

            ListView list = FindViewById<ListView>(Resource.Id.list);
            TextView text = FindViewById<TextView>(Resource.Id.recommendation);
            /*ItemContainer top5 = (new TopFive(Intent.GetStringExtra("username"))).ObtainData();
            List<string> items = new List<string>();
            foreach(var item in top5)
            {
                items.Add(item.Name);
            }*/

            //just an example
            string[] items = new string[] { "Vegetables", "Fruits", "Flower Buds", "Legumes", "Bulbs" };
            ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, items);
            list.Adapter = adapter;

            text.Text = "It is recommended that you shop in maxima.";

            
        }
    }
}