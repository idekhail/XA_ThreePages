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

            var showall = FindViewById<Button>(Resource.Id.showall);
            var back = FindViewById<Button>(Resource.Id.back);

            var show = FindViewById<TextView>(Resource.Id.show);

            var sq = new UserOperations();
            var users = sq.GetAllUsers();

            string s = "";
            foreach(var user in users)
            {
                s =+ user.UId + "    " + user.Username + "   " + user.Password + "/n";
            }

            show.Text = s;
        }
    }
}
