﻿using System;
using System.Collections;
using System.Collections.Generic;
using GMap.NET.WindowsForms;
using System.Windows.Forms;
using System.Device.Location;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using GMap.NET;
using Logic.ExtensionMethods;

namespace Logic
{
    public class Map
    {
        double _deviceLatitude;
        double _deviceLongitude;
        GeoCoordinateWatcher _watcher;
        GMapControl _gmap;
        ToolStripProgressBar _progressBar;
        ToolStripStatusLabel _progressLabel;
        GMapOverlay _markersOverlay;

        public Map(GMapControl gmap, ToolStripProgressBar progressBar, ToolStripStatusLabel progressLabel)
        {
            _gmap = gmap;
            _progressBar = progressBar;
            _progressLabel = progressLabel;
            _gmap.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            SetDeviceLocation();
        }

        private void SetDeviceLocation()
        {
            _watcher = new GeoCoordinateWatcher();
            _watcher.StatusChanged += Watcher_StatusChanged;
            _watcher.Start();

        }

        private void Watcher_StatusChanged(object sender, GeoPositionStatusChangedEventArgs e)
        {
         if (e.Status == GeoPositionStatus.Ready)
         {
             if (_watcher.Position.Location.IsUnknown)
             {
                    MessageBox.Show("We couldn't detect your Current Location", "Location Error");
             }
             else
             {
                 GeoCoordinate location = _watcher.Position.Location;
                 _deviceLatitude = location.Latitude;
                 _deviceLongitude = location.Longitude;
                 _gmap.Position = new PointLatLng(_deviceLatitude, _deviceLongitude);
                 _markersOverlay = new GMapOverlay("markers");
                 GMapMarker marker = new GMap.NET.WindowsForms.Markers.GMarkerGoogle(_gmap.Position, GMap.NET.WindowsForms.Markers.GMarkerGoogleType.green);
                 marker.ToolTipText = "Your Location";
                 marker.ToolTipMode = MarkerTooltipMode.Always;
                 _markersOverlay.Markers.Add(marker);
                 _gmap.Overlays.Add(_markersOverlay);
                 changeProgressBar();
                }
            }
     } 
        private string RetrieveNearestShop(string shopName, int radius=3000)
        {
            try
            {
                string url = @"https://maps.googleapis.com/maps/api/place/autocomplete/json?input=" + shopName + "&types=establishment&location=" + _deviceLatitude.ToString().Replace(",", ".") + "," + _deviceLongitude.ToString().Replace(",", ".") + "&radius=" + radius + "&strictbounds&language=lt&key=AIzaSyDzVT184zkzF_9v6lDfdV5zIIczRICwOkY";
                WebRequest request = WebRequest.Create(url);

                WebResponse response = request.GetResponse();

                Stream data = response.GetResponseStream();

                StreamReader reader = new StreamReader(data);
                string responseFromServer = reader.ReadToEnd();

                response.Close();

                var jsonResponse = JObject.Parse(responseFromServer);
                var nearestShop = (string)jsonResponse["predictions"][0]["description"];
                return nearestShop;

            } catch(ArgumentOutOfRangeException e)
            {
                MessageBox.Show("Couldn't detect shop within seleced radius", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return "-1";
            }
        }

        public void UpdateMapWithShopSuggestion(string shopName, int radius =3000)
        {
            string _nearest = RetrieveNearestShop(shopName,radius);
            if (_nearest != "-1")
            {
                // First parameter of extension method specifies desired interval for the Newlines insertion
                _gmap.SetPositionByKeywords(_nearest);
                _nearest = _nearest.DivideWithNewlines(18);
                if (_markersOverlay.Markers.Count > 1)
                {
                    _markersOverlay.Markers.RemoveAt(1);
                    _gmap.Overlays.Add(_markersOverlay);
                }
                GMapMarker marker = new GMap.NET.WindowsForms.Markers.GMarkerGoogle(_gmap.Position, GMap.NET.WindowsForms.Markers.GMarkerGoogleType.red);
                marker.ToolTipText = _nearest;
                marker.ToolTipMode = MarkerTooltipMode.Always;
                _markersOverlay.Markers.Add(marker);
                _gmap.Overlays.Add(_markersOverlay);
                var shopLat = _gmap.Position.Lat;
                var shopLng = _gmap.Position.Lng;
                _gmap.Position = new PointLatLng((shopLat + _deviceLatitude) / 2, (shopLng + _deviceLongitude) / 2);
            }
            else
            {
                if (_markersOverlay.Markers.Count > 1)
                {
                     _markersOverlay.Markers.RemoveAt(1);
                    _gmap.Overlays.Add(_markersOverlay);
                }
            }
        }

        private void changeProgressBar()
        {
            _progressBar.Value = 100;
            _progressLabel.Text = "Map Loaded.";
        }
    }
}
