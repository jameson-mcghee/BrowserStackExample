using System;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;
using System.Linq;
using BrowserStackIntegration;
using System.Threading.Tasks;
using System.Diagnostics;


namespace MobileAppTests
{
    //[TestFixture("single", "galaxy-s9")]
    [TestFixture("single", "iphone-8")]

    public class SingleTest : HomePage
    {

        public SingleTest(string profile, string device) : base(profile, device) { }

        //[Test]
        public void SimpleTestAndroid()
        {

            for (int i = 0; ; i++)
            {
                if (i >= 15) Assert.Fail("Assert Fail Message.");
                try
                {
                    var viewElements = androidDriver.FindElements(By.ClassName("android.widget.FrameLayout"));
                    Assert.IsTrue(viewElements.Any());
                    break;
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
            //var viewElements = androidDriver.FindElements(By.Id("android:id/content"));
            //Thread.Sleep(TimeSpan.FromSeconds(3));
            //Assert.IsTrue(viewElements.Any());
                        
        }

        [Test]
        public async Task SimpleTestIOS()
        {
            await IOSUsersCanAccessTheFTUE();
        }

        //[Test]
        public async Task AndroidPushNotificationPresentTest()
        {
            await AndroidUsersCanAccessTheFTUE();
            await AndroidCloseApp();
            if (IsAndroidElementPresent("page||ftue||||"))
            {
                Assert.Fail("App did not close.");
            }
            else
            {
                dynamic response = await SendToNativeAppAlertQueueFront
                ("https://api-stage.tegna-tv.com/mobile/configuration-rw/SendToNativeAppAlertQueue/?subscription-key=fdd842925eb6445f85adb84b30d22838");
                Console.Write(response);
            }
            await OpenAndroidNotificationGrid();
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
