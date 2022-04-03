using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using System;

namespace XA1_ThreePages
{
    [Activity(Label = "CreateUserActivity")]
    public class CreateUserActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_createuser);
            var username = FindViewById<EditText>(Resource.Id.username);
            var password = FindViewById<EditText>(Resource.Id.password);
            var mobile = FindViewById<EditText>(Resource.Id.mobile);
            var email = FindViewById<EditText>(Resource.Id.email);
            var latitude = FindViewById<EditText>(Resource.Id.latitude);
            var longitude = FindViewById<EditText>(Resource.Id.longitude);
            var clear = FindViewById<Button>(Resource.Id.clear);
            var cancel = FindViewById<Button>(Resource.Id.cancel);
            var create = FindViewById<Button>(Resource.Id.create);
            create.Click += delegate
            {
                if (username.Text != "" && password.Text != "")
                {            
                    var user = new UserOperations.Users()
                    {
                        Username = username.Text,
                        Password = password.Text,
                        Mobile = mobile.Text,
                        Email = email.Text,
                        Latitude  = Convert.ToDouble(latitude.Text),
                        Longitude = Convert.ToDouble(longitude.Text)
                    };                        
                    var sq = new UserOperations();
                    sq.InsertUser(user);
                    Intent i = new Intent(this, typeof(MainActivity));
                    StartActivity(i);
                }
                else
                {
                    Toast.MakeText(this, " UserName or Password is empty", ToastLength.Short).Show();
                }
            };
            clear.Click += delegate
            {
                username.Text = "";
                password.Text = "";
                mobile.Text = "";
                email.Text = "";
                latitude.Text = "";
                longitude.Text = "";
            };

            cancel.Click += delegate
            {
                Intent i = new Intent(this, typeof(MainActivity));
                StartActivity(i);
            };
        }
    }
}