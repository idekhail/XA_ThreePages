using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Xamarin.Essentials;

namespace XA1_ThreePages
{
    [Activity(Label = "ThirdActivity")]
    public class ThirdActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_third);

            var username = FindViewById<TextView>(Resource.Id.username);
            var password = FindViewById<TextView>(Resource.Id.password);
            var mobile = FindViewById<TextView>(Resource.Id.mobile);
            var email = FindViewById<TextView>(Resource.Id.email);
            var latitude = FindViewById<TextView>(Resource.Id.latitude);
            var longitude = FindViewById<TextView>(Resource.Id.longitude);

            var close = FindViewById<Button>(Resource.Id.close);
            var update = FindViewById<Button>(Resource.Id.update);
            var logout = FindViewById<Button>(Resource.Id.logout);
            var location = FindViewById<Button>(Resource.Id.location);
            var call = FindViewById<Button>(Resource.Id.call);
            var mailme = FindViewById<Button>(Resource.Id.mailme);

            string id = Intent.GetStringExtra("UId");
            var sq = new UserOperations();
            var user = sq.GetUserById(Convert.ToInt32(id));

            username.Text = user.Username;
            password.Text = user.Password;
            mobile.Text = user.Mobile;
            email.Text = user.Email;
            latitude.Text = user.Latitude + "";
            longitude.Text = user.Longitude + "";

            update.Click += delegate
            {
                Intent i = new Intent(this, typeof(UpdateActivity));
                i.PutExtra("UId", user.UId+"");
                StartActivity(i);
            };
            mailme.Click += delegate
            {
                Intent i = new Intent(this, typeof(SecondActivity));
                i.PutExtra("UId", user.UId + "");
                StartActivity(i);
            };
            logout.Click += delegate
            {
                Intent i = new Intent(this, typeof(MainActivity));
                StartActivity(i);
            };

            close.Click += delegate
            {
                System.Environment.Exit(0);
            };
          

            // Call Me
            call.Click += delegate
            {
                var url = Android.Net.Uri.Parse("tel:" + user.Mobile);
                var i = new Intent(Intent.ActionDial, url);
                StartActivity(i);

            };
            //Open Web
            location.Click += delegate
            {
                var latitude = user.Latitude;
                var longitude = user.Longitude;
                var url = Android.Net.Uri.Parse("geo:" + latitude + "," + longitude);
                var i = new Intent(Intent.ActionView, url);
                StartActivity(i);
            };

        }

      
    }
}