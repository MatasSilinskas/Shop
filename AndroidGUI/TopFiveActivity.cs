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
using Com.MS.Square.Android.Expandabletextview;
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
            ExpandableTextView recommendation = FindViewById<ExpandableTextView>(Resource.Id.expand_text_view);
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
            list.ItemLongClick += (object sender, AdapterView.ItemLongClickEventArgs e) =>
            {
                Toast.MakeText(ApplicationContext, "This item is cheapest at Maxima for the price of 5.99", ToastLength.Long).Show();
            };
            recommendation.Text = "It is recommended that you shop in maxima. NOTE: The displayed information may" +
                "be incorrect because the following items haven`t been bought in these shops:\n" +
                "Juoda Duona -- Maxima\nPienas -- IKI" +
                "Juoda Duona -- Maxima\nPienas -- IKI" +
                "Juoda Duona -- Maxima\nPienas -- IKI" +
                "Juoda Duona -- Maxima\nPienas -- IKI" +
                "Juoda Duona -- Maxima\nPienas -- IKI\n" +
                "Juoda Duona -- Maxima\nPienas -- IKI" +
                "Juoda Duona -- Maxima\nPienas -- IKI" +
                "Juoda Duona -- Maxima\nPienas -- IKI" +
                "Juoda Duona -- Maxima\nPienas -- IKI" +
                "Juoda Duona -- Maxima\nPienas -- IKI\n" +
                "Bananai - Maxima";
        }
    }
}