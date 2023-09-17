using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Plugin.LocalNotification;
using WindowsAzure.Messaging.NotificationHubs;

namespace DotNetMAUINotifications
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        // DefaultListenSharedAccessSignature
        const string CONNECTION_STRING = "TODO: Replace";
        // name
        const string HUB_NAME = "TODO: Replace";
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Listen for push notifications
            NotificationHub.SetListener(new NotificationListener());

            // Start the SDK
            NotificationHub.Start(this.Application, HUB_NAME, CONNECTION_STRING);
        }
    }

    public partial class NotificationListener : Java.Lang.Object, INotificationListener
    {
        async void INotificationListener.OnPushNotificationReceived(Context context, INotificationMessage message)
        {
            //Push Notification arrived - print out the keys/values
            var data = message.Data;
            if (data != null)
            {
                foreach (var entity in data)
                {
                    Android.Util.Log.Debug("AZURE-NOTIFICATION-HUBS", "Key: {0}, Value: {1}", entity.Key, entity.Value);
                }
                if (await LocalNotificationCenter.Current.AreNotificationsEnabled() == false)
                {
                    await MainThread.InvokeOnMainThreadAsync(async () =>
                    {
                        await LocalNotificationCenter.Current.RequestNotificationPermission();
                    });
                }

                var notification = new NotificationRequest
                {
                    NotificationId = 100,
                    Title = "Test",
                    Description = "Test Description",
                    ReturningData = "Dummy data", // Returning data when tapped on notification.
                    Schedule =
                    {
                        NotifyTime = DateTime.Now.AddSeconds(5) // Used for Scheduling local notification, if not specified notification will show immediately.
                    }
                };
                await LocalNotificationCenter.Current.Show(notification);
            }
        }
    }
}