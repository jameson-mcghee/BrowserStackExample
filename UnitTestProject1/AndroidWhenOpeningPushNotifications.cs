using NUnit.Framework;
using BrowserStackIntegration;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using System.Net.Http;
using System;
using System.Diagnostics;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using System.Drawing.Imaging;
using OpenQA.Selenium.Appium.MultiTouch;
using System.Collections;
using System.Collections.Generic;

namespace MobileAppTests
{
    //[TestFixture("parallel", "pixel")]
    //[TestFixture("parallel", "pixel-2")]
    [TestFixture("parallel", "pixel-3")]
    //[TestFixture("parallel", "galaxy-s7")] //App or one of the otherApps cannot be run on version 6.0.
    //[TestFixture("parallel", "galaxy-s8")]
    //[TestFixture("parallel", "galaxy-s9")]
    //[TestFixture("parallel", "galaxy-note8")]
    //[TestFixture("parallel", "galaxy-note9")]
    //[TestFixture("parallel", "galaxy-note4")]
    ////[TestFixture("parallel", "galaxy-s6")] //App or one of the otherApps cannot be run on version 5.0.
    ////[TestFixture("parallel", "nexus-9")] //tablet
    ////[TestFixture("parallel", "galaxy-tabs4")] //tablet
    [Parallelizable(ParallelScope.Fixtures)]
    public class AndroidWhenOpeningPushNotifications : WatchPage
    {
        public AndroidWhenOpeningPushNotifications(string profile, string device) : base(profile, device) { }

        [Test]
        public async Task ToAFront()
        {
            await AndroidUsersCanAccessTheFTUE();
            await AndroidClickFTUECloseButton();
            for (int i = 0; ; i++)
            {
                if (i >= 2) Assert.Fail("The Home Page did is not present after closing the FTUE.");
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

            await OpenAndroidNotificationGrid();

            for (int i = 0; ; i++)
            {
                if (i >= 30) Assert.Fail("The Front push notification was not received.");
                try
                {
                    //TODO: Do I need an element ID for this?
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
        }

        [Test]
        public async Task ToATopicPage()
        {
            await AndroidUsersCanAccessTheFTUE();
            await AndroidCloseApp();
            if (IsAndroidElementPresent("page||ftue||||"))
            {
                Assert.Fail("App did not close.");
            }
            else
            {
                dynamic response = await SendToNativeAppAlertQueueTopicPage
                ("https://api-stage.tegna-tv.com/mobile/configuration-rw/SendToNativeAppAlertQueue/?subscription-key=fdd842925eb6445f85adb84b30d22838");
                Console.Write(response);
            }
            await OpenAndroidNotificationGrid();
            Wait(30);
        }

        [Test]
        public async Task ToAWebView()
        {
            await AndroidUsersCanAccessTheFTUE();
            await AndroidCloseApp();
            if (IsAndroidElementPresent("page||ftue||||"))
            {
                Assert.Fail("App did not close.");
            }
            else
            {
                dynamic response = await SendToNativeAppAlertQueueWebView
                ("https://api-stage.tegna-tv.com/mobile/configuration-rw/SendToNativeAppAlertQueue/?subscription-key=fdd842925eb6445f85adb84b30d22838");
                Console.Write(response);
            }
            await OpenAndroidNotificationGrid();
            Wait(30);
        }

        [Test]
        public async Task ToAContentPage()
        {
            await AndroidUsersCanAccessTheFTUE();
            await AndroidCloseApp();
            if (IsAndroidElementPresent("page||ftue||||"))
            {
                Assert.Fail("App did not close.");
            }
            else
            {
                dynamic response = await SendToNativeAppAlertQueueContent
                ("https://api-stage.tegna-tv.com/mobile/configuration-rw/SendToNativeAppAlertQueue/?subscription-key=fdd842925eb6445f85adb84b30d22838");
                Console.Write(response);
            }
            await OpenAndroidNotificationGrid();
            Wait(30);
        }
    }
}
