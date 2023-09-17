using Plugin.LocalNotification;
using Plugin.LocalNotification.EventArgs;

namespace DotNetMAUINotifications
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Local Notification tap event listener
            LocalNotificationCenter.Current.NotificationActionTapped += OnNotificationActionTapped;

            MainPage = new AppShell();
        }

        private void OnNotificationActionTapped(NotificationEventArgs e)
        {
            if (e.Request is null)
            {
                return;
            }

            System.Diagnostics.Debug.WriteLine(e);
        }
    }
}