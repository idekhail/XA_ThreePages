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
    [Activity(Label = "UpdateActivity")]
    public class UpdateActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_update);
            var username = FindViewById<EditText>(Resource.Id.username);
            var password = FindViewById<EditText>(Resource.Id.password);
            var mobile = FindViewById<EditText>(Resource.Id.mobile);
            var email = FindViewById<EditText>(Resource.Id.email);
            var latitude = FindViewById<EditText>(Resource.Id.latitude);
            var longitude = FindViewById<EditText>(Resource.Id.longitude);
            var cancel = FindViewById<Button>(Resource.Id.cancel);
            var update = FindViewById<Button>(Resource.Id.update);
            var delete = FindViewById<Button>(Resource.Id.delete);
            
            string id = Intent.GetStringExtra("UId");
            var sq = new UserOperations();
            var user = sq.GetUserById(Convert.ToInt32(id));

            username.Text = user.Username;
            password.Text = user.Password;
            mobile.Text = user.Mobile;
            email.Text = user.Email;
            latitude.Text = user.Latitude+"";
            longitude.Text = user.Longitude+"";

            update.Click += delegate
            {
                if (username.Text != "" && password.Text != "")
                {

                    user.Username = username.Text;
                    user.Password = password.Text;
                    user.Mobile = mobile.Text;
                    user.Email = email.Text;
                    user.Latitude = Convert.ToDouble(latitude.Text);
                    user.Longitude = Convert.ToDouble(longitude.Text);
                   
                    var sq = new UserOperations();
                    sq.UpdateUser(user);
                    Intent i = new Intent(this, typeof(ThirdActivity));
                    i.PutExtra("UId", user.UId.ToString());
                    StartActivity(i);
                }
                else
                {
                    Toast.MakeText(this, " UserName or Password is empty", ToastLength.Short).Show();
                }
            };           
            cancel.Click += delegate
            {
                Intent i = new Intent(this, typeof(MainActivity));
                StartActivity(i);
            };
            delete.Click += delegate
            {
                var sq = new UserOperations();
                sq.DeleteUser(user);
                Intent i = new Intent(this, typeof(MainActivity));
                StartActivity(i);
            };

        }
    }
}
