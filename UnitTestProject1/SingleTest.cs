using System;
using NUnit.Framework;
using BrowserStackIntegration;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MobileAppTests
{
    //[TestFixture("single", "galaxy-s9")]
    [TestFixture("single", "galaxy-tabs4")] //tablet
    //[TestFixture("single", "iphone-8")]

    public class SingleTest : LiveVideo
    {
        public SingleTest(string profile, string device) : base(profile, device) { }

        //[Test]
        public async Task SimpleTestAndroid()
        {
            await AndroidHomePageIsPresent();
            await AndroidBackButton();
        }

        //[Test]
        public async Task SimpleTestIOS()
        {
            await IOSUsersCanAccessTheFTUE();
        }

        //[Test]
        public async Task AndroidPushNotificationPresentTest()
        {
            await AndroidUsersCanAccessTheFTUE();
            await AndroidCaptureScreenShot(this.device);
            await AndroidClickFTUECloseButton();
            for (int i = 0; ; i++)
            {
                if (i >= 2) Assert.Fail("The Home Page is not present after closing the FTUE.");
                try
                {
                    if (IsAndroidElementPresent("page||home-wrapper||||"))
                    {
                        await AndroidCaptureScreenShot(this.device);
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
                await AndroidCaptureScreenShot(this.device);
                dynamic response = await SendToNativeAppAlertQueueFront
                ("https://api-stage.tegna-tv.com/mobile/configuration-rw/SendToNativeAppAlertQueue/?subscription-key=fdd842925eb6445f85adb84b30d22838");
                Console.Write(response);
            }
            await OpenAndroidNotificationPane();
            Wait(30);
        }

        //[Test]
        public async Task SendNotificationTest()
        {
            dynamic response = await SendToNativeAppAlertQueueFront
                ("https://api-stage.tegna-tv.com/mobile/configuration-rw/SendToNativeAppAlertQueue/?subscription-key=fdd842925eb6445f85adb84b30d22838");
            Console.Write(response);
        }

    }
}
