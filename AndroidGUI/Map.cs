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
using Android.Gms.Maps;
using Android.Gms.Maps.Model;

namespace AndroidGUI
{
    [Activity(Label = "Map")]
    public class Map : Activity, IOnMapReadyCallback
    {
        private GoogleMap GMap;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            // Set our view from the "main" layout resource  
            SetContentView(Resource.Layout.Map);
            SetUpMap();
        }
        private void SetUpMap()
        {
            if (GMap == null)
            {
                FragmentManager.FindFragmentById<MapFragment>(Resource.Id.gmap).GetMapAsync(this);
            }
        }
        public void OnMapReady(GoogleMap googleMap)
        {
            this.GMap = googleMap;
            LatLng latlng = new LatLng(Convert.ToDouble(13.0291), Convert.ToDouble(80.2083));
            CameraUpdate camera = CameraUpdateFactory.NewLatLngZoom(latlng, 15);
            GMap.MoveCamera(camera);
            MarkerOptions options = new MarkerOptions().SetPosition(latlng).SetTitle("Chennai");
            GMap.AddMarker(options);
        }
    }
}