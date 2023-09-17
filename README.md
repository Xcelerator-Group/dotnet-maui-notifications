# .NET Maui Notifications
I have done a lot of searching on the internet to find a solution for using the latest .NET Maui and handling push notifications from Azure Notification Hub but there has been nothing quite comprehensive enough to follow.  After a bit of trial and error I have gotten to this code base which works!

## Notes
* It is using .NET 7.
* It is only doing Android notifications through Firebase for the moment.  Planning to add iOS.
* I used the Firebase console to [download google-services.json](https://firebase.google.com/docs/android/setup)
* I have only run it on a Pixel 5 emulator.
* I decided to include the [Plugin.LocalNotification](https://github.com/thudugala/Plugin.LocalNotification) package for local notifications as I was having no luck trying to use NotificationCompat (see https://github.com/xamarin/AndroidX/issues/71) as is shown in the [Microsoft Tutorial](https://learn.microsoft.com/en-us/azure/notification-hubs/xamarin-notification-hubs-push-notifications-android-gcm).
* I have only tested a test message from the Azure Notification Hub that goes to everyone so there is no targeting yet.
* I also included some Azure DevOps pipelines I have started in case you are looking for them.

## To Use
In order to use this you will need to make some modifications for your use as listed below:
* Update the app id `com.companyname.yourappid` to your correct id wherever this string is.
* Update the content in google-services.json based on your configuration.  **NOTE:** Ensure your app id matches the package_name in this file.
* Replace the CONNECTION_STRING and HUB_NAME in the MainActivity class with your settings.

At this point you should be able to build and run on an Android emulator and send a test message from the Azure Notification Hub.

## Contributions
I am happy to take PRs regarding this if anyone has more to add.  I will probably not address any issues unless there is an accompanying PR as this was intended to just show how to do notifications and nothing else.

## References
Some links I have visited during this that may be useful if you are having any problems or may explain why some things are the way they are:
* https://stackoverflow.com/questions/75574429/net-maui-permission-request-must-be-invoked-on-main-thread
* https://github.com/dotnet/maui/issues/14486
* https://stackoverflow.com/questions/56779992/error-deserializing-google-services-json-file
* https://github.com/xamarin/AndroidX/issues/742
