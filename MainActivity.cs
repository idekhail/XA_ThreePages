using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;

namespace XA1_ThreePages
{
    [Activity(Label = "@string/app_name")]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource

            SetContentView(Resource.Layout.activity_main);
            var username = FindViewById<EditText>(Resource.Id.username);
            var password = FindViewById<EditText>(Resource.Id.password);
            var login = FindViewById<Button>(Resource.Id.login);
            var clear = FindViewById<Button>(Resource.Id.clear);
            var close = FindViewById<Button>(Resource.Id.close);
            var create = FindViewById<Button>(Resource.Id.create);
            var showpage = FindViewById<Button>(Resource.Id.showpage);

            login.Click += delegate
            {
                if (!string.IsNullOrEmpty(username.Text) && !string.IsNullOrEmpty(password.Text))
                {
                    var sq = new UserOperations();
                    var user = sq.GetUser(username.Text, password.Text);
                    if (user != null)
                    {
                        Intent i = new Intent(this, typeof(ThirdActivity));
                        i.PutExtra("UId", user.UId.ToString());
                        StartActivity(i);
                    }
                    else
                        Toast.MakeText(this, "Username or Password is not Found", ToastLength.Long).Show();
                }
                else
                    Toast.MakeText(this, "user not phound!!!!", ToastLength.Long).Show();
            };
            
            clear.Click += delegate
            {
                username.Text = "";
                password.Text = "";
            };
            close.Click += delegate
            {
                System.Environment.Exit(0);
            };
            create.Click += delegate
            {
                var i = new Intent(this, typeof(CreateUserActivity));
                StartActivity(i);
            };

            showpage.Click += delegate
            {
                var i = new Intent(this, typeof(ShowActivity));
                StartActivity(i);
            };

        }       
    }
}