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
using Android.Provider;
using Android.Graphics;

namespace AndroidGUI
{
    [Activity(Label = "ScanActivity")]
    public class ScanActivity : Activity
    { 
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            AlertDialog.Builder builder = new AlertDialog.Builder(this); // change "this" if necc
            builder.SetTitle("Get the cheque picture from:");
            builder.SetPositiveButton("Gallery", GalleryAction);
            builder.SetNegativeButton("Camera", CameraAction);
            var myCustomDialog = builder.Create();
            myCustomDialog.Show();
        }

        private void GalleryAction(object sender, DialogClickEventArgs e)
        {
            var imageIntent = new Intent();
            imageIntent.SetType("image/*");
            imageIntent.SetAction(Intent.ActionGetContent);
            StartActivityForResult(Intent.CreateChooser(imageIntent, "Select a cheque"), 0);
        }

        private void CameraAction(object sender, DialogClickEventArgs e)
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);
            StartActivityForResult(intent, 1);
        }

        /* gets bitmaps of pictures */
        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            Bitmap picture;

            if (requestCode == 0)
            {
                picture = MediaStore.Images.Media.GetBitmap(this.ContentResolver, data.Data);
            }
            if (requestCode == 1)
            {
                picture = (Bitmap) data.Extras.Get("data");
            }

            if (resultCode == Result.Ok)
            {
                GoogleRecognition google = new GoogleRecognition(data.Data.Path, Intent.GetStringExtra("username"));
                if (!google.DoRecognition(new WriteLogic()))
                {
                    AlertDialog.Builder dialog = new AlertDialog.Builder(this);
                    AlertDialog alert = dialog.Create();
                    alert.SetTitle("Title");
                    alert.SetMessage("Scanning failed");
                    alert.SetButton("OK", (c, ev) =>
                    {
                        // Ok button click task  
                    });
                    alert.Show();
                }
                else
                {
                    Toast.MakeText(ApplicationContext, "Scanning was succesful", ToastLength.Long).Show();
                }
            }
        }
    }
}