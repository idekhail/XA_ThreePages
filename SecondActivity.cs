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
                    List<string> recipients = new List<string>() {user.Email };
                    // List<string> send = mailTo.Text as List<string>;
                    var message = new EmailMessage
                    {
                        Subject = subject.Text,
                        Body = body.Text,
                        To = recipients,
                        //Cc = ccRecipients,
                        //Bcc = bccRecipients
                    };
                    Email.ComposeAsync(message);
                    Toast.MakeText(this, "Email Sent", ToastLength.Long).Show();
                }
                catch (FeatureNotSupportedException ex1)
                {
                    Toast.MakeText(this, "Error1" + ex1.Message, ToastLength.Long).Show();
                }
                catch (Exception ex)
                {
                    Toast.MakeText(this, "Error2" + ex.Message, ToastLength.Long).Show();
                }
            };
            
        }
    }
}
