using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using BrowserStackIntegration;
using OpenQA.Selenium;
using System.Linq;
using System.Text.RegularExpressions;

namespace MobileAppTests
{
    [TestFixture("parallel", "pixel")]
    [TestFixture("parallel", "pixel-2")]
    [TestFixture("parallel", "pixel-3")]
    [TestFixture("parallel", "galaxy-s6")]
    [TestFixture("parallel", "galaxy-s7")]
    [TestFixture("parallel", "galaxy-s8")]
    [TestFixture("parallel", "galaxy-s9")]
    [TestFixture("parallel", "galaxy-note8")]
    [TestFixture("parallel", "galaxy-note9")]
    [TestFixture("parallel", "galaxy-note4")]
    [TestFixture("parallel", "nexus-9")]
    [TestFixture("parallel", "galaxy-tabs4")]
    [Parallelizable(ParallelScope.Fixtures)]
    public class WhenLaunchingTheAppOnAndroid : BrowserStackIntegrationImplementation
    {
        public WhenLaunchingTheAppOnAndroid(string profile, string device) : base(profile, device) { }

        //[Test]
        public async Task TheUserCanAccessTheSplashScreen()
        {

            for (int second = 0; ; second++)
            {
                if (second >= 30) Assert.Fail("Splashscreen is not being displayed.");
                try
                    {
                        var splashScreenElement = androidDriver.FindElementByAccessibilityId("");
                        Assert.IsTrue(splashScreenElement.Displayed, splashScreenElement + "Splashscreen is not being displayed."); break;
                    }
                    catch (Exception ex)
                    {
                        string message = $"Splashscreen is not being displayed. {ex}";
                        Debug.WriteLine(message);
                        //Debug.ReadLine();
                        Console.WriteLine(message);
                    }
            }
        }

        //[Test]
        public async Task TheIntroBannerIsGenerated()
        {

            Thread.Sleep(TimeSpan.FromSeconds(3));
            for (int second = 0; ; second++)
            {
                if (second >= 30) Assert.Fail("Intro Banner and/or 'Sponsored by' messages are not being displayed.");
                try
                    {
                        var introBannerElement = androidDriver.FindElementByAccessibilityId("");
                        var sponsoredByElement = androidDriver.FindElementByAccessibilityId("");

                        Assert.IsTrue(introBannerElement.Displayed, introBannerElement + "Intro Banner is not being displayed.");
                        Assert.IsTrue(sponsoredByElement.Displayed, sponsoredByElement + "'Sponsored By' is not being displayed."); break;
                    }
                    catch (Exception ex)
                    {
                        string message = $"Intro Banner and/or 'Sponsored by' messages are not being displayed. {ex}";
                        Debug.WriteLine(message);
                        //Debug.ReadLine();
                        Console.WriteLine(message);
                    }
            }

            try
            {
                string sponsoredByText = androidDriver.FindElementByAccessibilityId("Sponsored By non-module|-4|ad|advertisementModule|0|manually placed in splash-screen|").Text;
                string introBannerText = androidDriver.FindElementByAccessibilityId("Good Morning Sponsored By non-module|-4|ad|advertisementModule|0|manually placed in splash-screen|").Text;

                Assert.IsTrue(introBannerText.Contains("Good "), introBannerText + "Intro Banner does not contain 'Good ***'.");
                Assert.IsTrue(sponsoredByText.Contains("Sponsored By"), sponsoredByText + "Intro Screen does not contain 'Sponsored By'.");
            }
            catch (Exception ex)
            {
                string message = $"Intro Banner and/or 'Sponsored by' messages are not being displayed. {ex}";
                Debug.WriteLine(message);
                //Debug.ReadLine();
                Console.WriteLine(message);
            }

        }

        //[Test]
        public async Task TheSponsoredByTextIsPresent()
        {
            var sponsoredByElement = androidDriver.FindElementByAccessibilityId("AccessibilityIDHere");
            string sponsoredByText = androidDriver.FindElementByAccessibilityId("AccessibilityIDHere").Text;

            Thread.Sleep(TimeSpan.FromSeconds(3));
            for (int second = 0; ; second++)
            {
                if (second >= 15) Assert.Fail("'Sponsored By' is not being displayed.");
                try
                {
                    Assert.IsTrue(sponsoredByElement.Displayed); break;
                }
                catch (Exception ex)
                {
                    string message = $"'Sponsored By' is not being displayed. {ex}";
                    Debug.WriteLine(message);
                    //Debug.ReadLine();
                    Console.WriteLine(message);
                }
            }
            Assert.IsTrue(sponsoredByText.Contains("Sponsored By"), sponsoredByText + "Intro Screen does not contain 'Sponsored By'.");

        }

        //[Test]
        public async Task TheSplashScreenAdIsPresent()
        {

            for (int second = 0; ; second++)
            {
                if (second >= 30) Assert.Fail("Splashscreen Ad is not being displayed.");
                try
                {
                    var splashScreenAdElement = androidDriver.FindElementByAccessibilityId("non-module|-4|ad|advertisementModule|0|manually placed in splash-screen|");
                    Assert.IsTrue(splashScreenAdElement.Displayed, splashScreenAdElement + "Splashscreen Ad is not being displayed."); break;
                }
                catch (Exception ex)
                {
                    string message = $"Splashscreen Ad is not being displayed. {ex}";
                    Debug.WriteLine(message);
                    //Debug.ReadLine();
                    Console.WriteLine(message);
                }
            }
        }

    }
}
