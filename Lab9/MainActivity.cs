using Android.App;
using Android.Widget;
using Android.OS;

namespace Lab9
{
    [Activity(Label = "Lab9", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            string EMail = "";
            string Password = "";
            string Device = Android.Provider.Settings.Secure.GetString(
                ContentResolver, Android.Provider.Settings.Secure.AndroidId);

            var UserNameResTextView = FindViewById<TextView>(Resource.Id.UserNameResTextView);
            var StatusResTextView = FindViewById<TextView>(Resource.Id.StatusResTextView);
            var TokenResTextView = FindViewById<TextView>(Resource.Id.TokenResTextView);

            Validate();

            async void Validate()
            {
                var ServiceClient = new SALLab09.ServiceClient();
                var SvcResult = await ServiceClient.ValidateAsync(EMail, Password, Device);

                UserNameResTextView.Text = SvcResult.Fullname;
                StatusResTextView.Text = SvcResult.Status.ToString();
                TokenResTextView.Text = SvcResult.Token;
            }
        }
    }
}

