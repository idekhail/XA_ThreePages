using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XA1_ThreePages
{
    [Activity(Label = "SecondActivity")]
    public class SecondActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_second);           

            var website = FindViewById<EditText>(Resource.Id.website);
            var mobile = FindViewById<EditText>(Resource.Id.mobile);

            var call = FindViewById<Button>(Resource.Id.call);
            var map = FindViewById<Button>(Resource.Id.map);
            var web = FindViewById<Button>(Resource.Id.web);
            var clear = FindViewById<Button>(Resource.Id.clear);
            var next = FindViewById<ImageButton>(Resource.Id.next);
            
            string username = Intent.GetStringExtra("username");
            
            next.Click += delegate
            {
                Intent intent = new Intent(this, typeof(ThirdActivity));
                intent.PutExtra("username", username);
                StartActivity(intent);
            };

            // Call Me
            call.Click += delegate
            {
                var url = Android.Net.Uri.Parse("tel:" + mobile.Text);
                var i = new Intent(Intent.ActionDial, url);
                StartActivity(i);

            };
            //Open Web
            web.Click += delegate
            {
                var url = Android.Net.Uri.Parse(website.Text);
                var i = new Intent(Intent.ActionView, url);
                StartActivity(i);
            };

            map.Click += delegate
            {
                var latitude = website.Text;
                var longitude = mobile.Text;
                //  ( "geo:27.477474,43.67554")
                var url = Android.Net.Uri.Parse("geo:" + latitude + "," + longitude);
                var i = new Intent(Intent.ActionView, url);
                StartActivity(i);
            };
           
        }
    }
}