using System;

using Android.App;
using Android.Content.PM;
using Android.OS;
using Plugin.FirebasePushNotification;
using Android.Content;

using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter;

namespace ChupeLupe.Droid
{
    [Activity(Label = "ChupeLupe", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
            FirebasePushNotificationManager.ProcessIntent(this, Intent);

            Microsoft.AppCenter.AppCenter.Start("c85c73c5-c73d-4870-8dca-9bd1cb8edab8", typeof(Analytics), typeof(Crashes));
            }

        protected override void OnNewIntent(Intent intent)
        {
            base.OnNewIntent(intent);
            FirebasePushNotificationManager.ProcessIntent(this, intent);

            CrossFirebasePushNotification.Current.Subscribe(new string[] { "all" });
            var token = CrossFirebasePushNotification.Current.Token;
            Console.WriteLine(token);
        }
    }
}