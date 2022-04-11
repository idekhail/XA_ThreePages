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

using Xamarin.Essentials;

namespace XA1_ThreePages
{
    [Activity(Label = "SecondActivity")]
    public class SecondActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_second);           

            var subject = FindViewById<EditText>(Resource.Id.subject);
            var body = FindViewById<EditText>(Resource.Id.body);
            

            var sendemail = FindViewById<Button>(Resource.Id.sendemail);
            var back = FindViewById<Button>(Resource.Id.back);

            string id = Intent.GetStringExtra("UId");
            var sq = new UserOperations();
            var user = sq.GetUserById(Convert.ToInt32(id));

            back.Click += delegate
            {
                Intent intent = new Intent(this, typeof(ThirdActivity));
                intent.PutExtra("UId", user.UId.ToString());
                StartActivity(intent);
            };


            sendemail.Click += delegate
            {
                try
                {
                   // List<string> send = mailTo.Text as List<string>;
                    var message = new EmailMessage
                    {
                        Subject = subject.Text,
                        Body = body.Text,
                        To = (List)user.Email,
                        //Cc = ccRecipients,
                        //Bcc = bccRecipients
                    };
                    Email.ComposeAsync(message);
                }
                catch (FeatureNotSupportedException fbsEx)
                {
                    // Email is not supported on this device
                }
                catch (Exception ex)
                {
                    // Some other exception occurred
                }
            };
            
        }
    }
}