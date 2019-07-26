using NUnit.Framework;
using BrowserStackIntegration;
using System.Threading.Tasks;
using System;
using System.Diagnostics;

namespace MobileAppTests
{
    [TestFixture("parallel", "pixel")]
    [TestFixture("parallel", "pixel-2")]
    [TestFixture("parallel", "pixel-3")]
    //[TestFixture("parallel", "nexus-9")]
    [TestFixture("parallel", "galaxy-s8")]
    [TestFixture("parallel", "galaxy-s9")]
    [TestFixture("parallel", "galaxy-note8")]
    [TestFixture("parallel", "galaxy-note9")]
    [TestFixture("parallel", "galaxy-tabs3")] //tablet
    [TestFixture("parallel", "galaxy-tabs4")] //tablet
    [TestFixture("parallel", "galaxy-tabs5e")] //tablet
    [Parallelizable(ParallelScope.Fixtures)]
    public class AndroidWhenOpeningPushNotifications : WatchPage
    {
        public AndroidWhenOpeningPushNotifications(string profile, string device) : base(profile, device) { }

        //[Test]
        public async Task ToAFront()
        {
            await AndroidUsersCanAccessTheFTUE();
            await AndroidClickFTUECloseButton();
            for (int i = 0; ; i++)
            {
                if (i >= 2) Assert.Fail("The Home Page is not present after closing the FTUE.");
                try
                {
                    if (IsAndroidElementPresent("page||home-wrapper||||"))
                    {
                        await AndroidCloseApp();
                        break;
                    }
                }
                catch (Exception ex)
                {
                    string message = $"Try/Catch Message. {ex}";
                    Debug.WriteLine(message);
                    //Debug.ReadLine();
                    Console.WriteLine(message);
                }
                Wait(1);
            }
            
            if (IsAndroidElementPresent("page||home-wrapper||||"))
            {
                Assert.Fail("App did not close.");
            }
            else
            {
                dynamic response = await SendToNativeAppAlertQueueFront
                ("https://api-stage.tegna-tv.com/mobile/configuration-rw/SendToNativeAppAlertQueue/?subscription-key=fdd842925eb6445f85adb84b30d22838");
                Console.Write(response);
            }

            await OpenAndroidNotificationPane();

            for (int i = 0; ; i++)
            {
                if (i >= 30) Assert.Fail("The Front push notification was not received.");
                try
                {
                    //TODO: Insert Push Notification Element ID
                    if (IsAndroidElementPresent(""))
                    {
                        await AndroidClickCommand("");
                        break;
                    }
                }
                catch (Exception ex)
                {
                    string message = $"Try/Catch Message. {ex}";
                    Debug.WriteLine(message);
                    //Debug.ReadLine();
                    Console.WriteLine(message);
                }
                Wait(1);
            }

            for (int i = 0; ; i++)
            {
                if (i >= 15) Assert.Fail("The Weather Page is not present after opening the Front push notification.");
                try
                {
                    if (IsAndroidElementPresent("page||weather-wrapper||||"))
                        break;
                }
                catch (Exception ex)
                {
                    string message = $"The Weather Page is not present after opening the Front push notification. {ex}";
                    Debug.WriteLine(message);
                    //Debug.ReadLine();
                    Console.WriteLine(message);
                }
                Wait(1);
            }

            if (IsAndroidElementPresent("ad|-3|non-module|advertisementModule|0|manually placed in page-wrapper|"))
            {
                //
            }
            else
            {
                Assert.Fail("The banner ad is not present.");
            }
        }

        //[Test]
        public async Task ToATopicPage()
        {
            await AndroidUsersCanAccessTheFTUE();
            await AndroidClickFTUECloseButton();
            for (int i = 0; ; i++)
            {
                if (i >= 2) Assert.Fail("The Home Page is not present after closing the FTUE.");
                try
                {
                    if (IsAndroidElementPresent("page||home-wrapper||||"))
                    {
                        await AndroidCloseApp();
                        break;
                    }
                }
                catch (Exception ex)
                {
                    string message = $"Try/Catch Message. {ex}";
                    Debug.WriteLine(message);
                    //Debug.ReadLine();
                    Console.WriteLine(message);
                }
                Wait(1);
            }

            if (IsAndroidElementPresent("page||home-wrapper||||"))
            {
                Assert.Fail("App did not close.");
            }
            else
            {
                dynamic response = await SendToNativeAppAlertQueueTopicPage
                ("https://api-stage.tegna-tv.com/mobile/configuration-rw/SendToNativeAppAlertQueue/?subscription-key=fdd842925eb6445f85adb84b30d22838");
                Console.Write(response);
            }

            await OpenAndroidNotificationPane();

            for (int i = 0; ; i++)
            {
                if (i >= 30) Assert.Fail("The Front push notification was not received.");
                try
                {
                    //TODO: Insert Push Notification Element ID
                    if (IsAndroidElementPresent(""))
                    {
                        await AndroidClickCommand("");
                        break;
                    }
                }
                catch (Exception ex)
                {
                    string message = $"Try/Catch Message. {ex}";
                    Debug.WriteLine(message);
                    //Debug.ReadLine();
                    Console.WriteLine(message);
                }
                Wait(1);
            }

            for (int i = 0; ; i++)
            {
                if (i >= 15) Assert.Fail("The app was not opened to a topic page when opened from a push notification.");
                try
                {
                    //TODO: Insert Topic Page element ID
                    if (IsAndroidElementPresent(""))
                    {
                        //TODO: Insert Topic Page Title element ID
                        await AndroidAssertText("", "News", "The title of the topic page is not correct.");
                        break;
                    }
                }
                catch (Exception ex)
                {
                    string message = $"The app was not opened to a topic page when opened from a push notification. {ex}";
                    Debug.WriteLine(message);
                    //Debug.ReadLine();
                    Console.WriteLine(message);
                }
                Wait(1);
            }

            if (IsAndroidElementPresent("ad|-3|non-module|advertisementModule|0|manually placed in page-wrapper|"))
            {
                //
            }
            else
            {
                Assert.Fail("The banner ad is not present.");
            }
        }

        //[Test]
        public async Task ToAWebView()
        {
            await AndroidUsersCanAccessTheFTUE();
            await AndroidClickFTUECloseButton();
            for (int i = 0; ; i++)
            {
                if (i >= 2) Assert.Fail("The Home Page is not present after closing the FTUE.");
                try
                {
                    if (IsAndroidElementPresent("page||home-wrapper||||"))
                    {
                        await AndroidCloseApp();
                        break;
                    }
                }
                catch (Exception ex)
                {
                    string message = $"Try/Catch Message. {ex}";
                    Debug.WriteLine(message);
                    //Debug.ReadLine();
                    Console.WriteLine(message);
                }
                Wait(1);
            }

            if (IsAndroidElementPresent("page||home-wrapper||||"))
            {
                Assert.Fail("App did not close.");
            }
            else
            {
                dynamic response = await SendToNativeAppAlertQueueWebView
                ("https://api-stage.tegna-tv.com/mobile/configuration-rw/SendToNativeAppAlertQueue/?subscription-key=fdd842925eb6445f85adb84b30d22838");
                Console.Write(response);
            }

            await OpenAndroidNotificationPane();

            for (int i = 0; ; i++)
            {
                if (i >= 30) Assert.Fail("The Front push notification was not received.");
                try
                {
                    //TODO: Insert Push Notification Element ID
                    if (IsAndroidElementPresent(""))
                    {
                        await AndroidClickCommand("");
                        break;
                    }
                }
                catch (Exception ex)
                {
                    string message = $"Try/Catch Message. {ex}";
                    Debug.WriteLine(message);
                    //Debug.ReadLine();
                    Console.WriteLine(message);
                }
                Wait(1);
            }

            for (int i = 0; ; i++)
            {
                if (i >= 15) Assert.Fail("The app was not opened to a webview page when opened from a push notification.");
                try
                {
                    //TODO: Insert WebView Page element ID
                    if (IsAndroidElementPresent(""))
                    {
                        //TODO: Is there an assertion I can include here?
                        break;
                    }
                }
                catch (Exception ex)
                {
                    string message = $"The app was not opened to a webview page when opened from a push notification. {ex}";
                    Debug.WriteLine(message);
                    //Debug.ReadLine();
                    Console.WriteLine(message);
                }
                Wait(1);
            }
        }

        //[Test]
        public async Task ToAContentPage()
        {
            await AndroidUsersCanAccessTheFTUE();
            await AndroidClickFTUECloseButton();
            for (int i = 0; ; i++)
            {
                if (i >= 2) Assert.Fail("The Home Page is not present after closing the FTUE.");
                try
                {
                    if (IsAndroidElementPresent("page||home-wrapper||||"))
                    {
                        await AndroidCloseApp();
                        break;
                    }
                }
                catch (Exception ex)
                {
                    string message = $"Try/Catch Message. {ex}";
                    Debug.WriteLine(message);
                    //Debug.ReadLine();
                    Console.WriteLine(message);
                }
                Wait(1);
            }

            if (IsAndroidElementPresent("page||home-wrapper||||"))
            {
                Assert.Fail("App did not close.");
            }
            else
            {
                dynamic response = await SendToNativeAppAlertQueueContent
                ("https://api-stage.tegna-tv.com/mobile/configuration-rw/SendToNativeAppAlertQueue/?subscription-key=fdd842925eb6445f85adb84b30d22838");
                Console.Write(response);
            }

            await OpenAndroidNotificationPane();

            for (int i = 0; ; i++)
            {
                if (i >= 30) Assert.Fail("The Front push notification was not received.");
                try
                {
                    //TODO: Insert Push Notification Element ID
                    if (IsAndroidElementPresent(""))
                    {
                        await AndroidClickCommand("");
                        break;
                    }
                }
                catch (Exception ex)
                {
                    string message = $"Try/Catch Message. {ex}";
                    Debug.WriteLine(message);
                    //Debug.ReadLine();
                    Console.WriteLine(message);
                }
                Wait(1);
            }

            for (int i = 0; ; i++)
            {
                if (i >= 15) Assert.Fail("The app was not opened to a content page when opened from a push notification.");
                try
                {
                    if (IsAndroidElementPresent("page||article-page-wrapper||||"))
                    {
                        //TODO: Insert Content Page Title element ID
                        await AndroidAssertText("", "test story with video", "The title of the content page is not correct.");
                        break;
                    }
                }
                catch (Exception ex)
                {
                    string message = $"The app was not opened to a content page when opened from a push notification. {ex}";
                    Debug.WriteLine(message);
                    //Debug.ReadLine();
                    Console.WriteLine(message);
                }
                Wait(1);
            }

            if (IsAndroidElementPresent("ad|-3|non-module|advertisementModule|0|manually placed in page-wrapper|"))
            {
                //
            }
            else
            {
                Assert.Fail("The banner ad is not present.");
            }
        }

        //[Test]
        public async Task OnlySubscribersReceiveTheNotifications()
        {
            await AndroidUsersCanAccessTheFTUE();
            await AndroidClickFTUECloseButton();
            for (int i = 0; ; i++)
            {
                if (i >= 2) Assert.Fail("The Home Page is not present after closing the FTUE.");
                try
                {
                    if (IsAndroidElementPresent("page||home-wrapper||||"))
                    {
                        await AndroidCloseApp();
                        break;
                    }
                }
                catch (Exception ex)
                {
                    string message = $"Try/Catch Message. {ex}";
                    Debug.WriteLine(message);
                    //Debug.ReadLine();
                    Console.WriteLine(message);
                }
                Wait(1);
            }

            if (IsAndroidElementPresent("page||home-wrapper||||"))
            {
                Assert.Fail("App did not close.");
            }
            else
            {
                dynamic response = await SendToNativeAppAlertSpecificSubscribers
                ("https://api-stage.tegna-tv.com/mobile/configuration-rw/SendToNativeAppAlertQueue/?subscription-key=fdd842925eb6445f85adb84b30d22838");
                Console.Write(response);
            }

            await OpenAndroidNotificationPane();

            for (int i = 0; ; i++)
            {
                if (i >= 30) Assert.Fail("The Front push notification was not received.");
                try
                {
                    //TODO: Insert Push Notification Element ID
                    if (IsAndroidElementPresent(""))
                    {
                        await AndroidClickCommand("");
                        break;
                    }
                }
                catch (Exception ex)
                {
                    string message = $"Try/Catch Message. {ex}";
                    Debug.WriteLine(message);
                    //Debug.ReadLine();
                    Console.WriteLine(message);
                }
                Wait(1);
            }

            for (int i = 0; ; i++)
            {
                if (i >= 15) Assert.Fail("The Weather Page is not present after opening the Front push notification.");
                try
                {
                    if (IsAndroidElementPresent("page||weather-wrapper||||"))
                        break;
                }
                catch (Exception ex)
                {
                    string message = $"The Weather Page is not present after opening the Front push notification. {ex}";
                    Debug.WriteLine(message);
                    //Debug.ReadLine();
                    Console.WriteLine(message);
                }
                Wait(1);
            }

            if (IsAndroidElementPresent("ad|-3|non-module|advertisementModule|0|manually placed in page-wrapper|"))
            {
                //
            }
            else
            {
                Assert.Fail("The banner ad is not present.");
            }
        }
    }
}
