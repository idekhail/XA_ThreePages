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
    [Activity(Label = "ShowActivity")]
    public class ShowActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_show);

            var showall = FindViewById<Button>(Resource.Id.showall);
            var showuser = FindViewById<Button>(Resource.Id.showuser);

            var back = FindViewById<Button>(Resource.Id.back);

            var show = FindViewById<TextView>(Resource.Id.show);
            var username = FindViewById<EditText>(Resource.Id.username);


            showuser.Click += delegate
            {

                var sq = new UserOperations();
                var users = sq.GetUsersByUser(username.Text);
              //  var user = sq.GetUser(username.Text);

                string s = "";
                foreach (var user in users)
                {
                    s += user.UId + "    " + user.Username + "   " + user.Password + "\n";
                }

                show.Text = s.ToString();
            };

            showall.Click += delegate
            {
                
                var sq = new UserOperations();
                var users = sq.GetAllUsers();

                string s = "";
                foreach(var user in users)
                {
                    s += user.UId + "    " + user.Username + "   " + user.Password + "\n";
                }

                show.Text = s.ToString();
            };

            back.Click += delegate
            {
                Intent intent = new Intent(this, typeof(MainActivity));
                StartActivity(intent);
            };
        }       
    }
}