using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using BrowserStackIntegration;
using System.Linq;
using System.Text.RegularExpressions;
using OpenQA.Selenium;

namespace MobileAppTests
{
    //[TestFixture("parallel", "iphone-7")] //Device is running iOS v10
    //[TestFixture("parallel", "iphone-7-plus")] //Device is running iOS v10
    [TestFixture("parallel", "iphone-8")]
    [TestFixture("parallel", "iphone-8-plus")]
    [TestFixture("parallel", "iphone-se")]
    [TestFixture("parallel", "iphone-xs")]
    [TestFixture("parallel", "ipad-pro")]
    [TestFixture("parallel", "ipad-5th")]
    [Parallelizable(ParallelScope.Fixtures)]
    public class WhenLaunchingTheAppOniOS : BrowserStackIntegrationImplementation
    {
        public WhenLaunchingTheAppOniOS(string profile, string device) : base(profile, device) { }

        [Test]
        public async Task TheUserCanAccessTheSplashScreen()
        {
            var splashScreenElement = iosDriver.FindElementByName("Good Morning Sponsored By non-module|-4|ad|advertisementModule|0|manually placed in splash-screen|");
            
            await ApproveiOSAlerts();

            Thread.Sleep(TimeSpan.FromSeconds(3));
            for (int second = 0; ; second++)
            {
                if (second >= 20)
                try
                {
                    Assert.IsTrue(splashScreenElement.Displayed, splashScreenElement + "Intro Banner is not being displayed."); break;
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
            var introBannerElement = iosDriver.FindElementByAccessibilityId("Good Morning Sponsored By non-module|-4|ad|advertisementModule|0|manually placed in splash-screen|");
            var sponsoredByElement = iosDriver.FindElementByAccessibilityId("Sponsored By non-module|-4|ad|advertisementModule|0|manually placed in splash-screen|");
            string sponsoredByText = iosDriver.FindElementByAccessibilityId("Sponsored By non-module|-4|ad|advertisementModule|0|manually placed in splash-screen|").Text;
            string introBannerText = iosDriver.FindElementByAccessibilityId("Good Morning Sponsored By non-module|-4|ad|advertisementModule|0|manually placed in splash-screen|").Text;

            ApproveiOSAlerts();

            Thread.Sleep(TimeSpan.FromSeconds(3));
            for (int second = 0; ; second++)
            {
                if (second >= 20)
                try
                {
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
            Assert.IsTrue(introBannerText.Contains("Good "), introBannerText + "Intro Banner does not contain 'Good ***'.");
            Assert.IsTrue(sponsoredByText.Contains("Sponsored By"), sponsoredByText + "Intro Screen does not contain 'Sponsored By'.");

        }

        //[Test]
        public async Task TheSponsoredByTextIsPresent()
        {
            var sponsoredByElement = iosDriver.FindElementByAccessibilityId("non-module|-4|ad|advertisementModule|0|manually placed in splash-screen|");
            string sponsoredByText = iosDriver.FindElementByAccessibilityId("non-module|-4|ad|advertisementModule|0|manually placed in splash-screen|").Text;

            await ApproveiOSAlerts();

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
        public async Task TheIntroScreenAdIsPresent()
        {
            var bannerAdElement = androidDriver.FindElementByName("non-module|-4|ad|advertisementModule|0|manually placed in splash-screen|");

            await ApproveiOSAlerts();
            for (int second = 0; ; second++)
            {
                if (second >= 20) Assert.Fail("Introscreen Ad not present.");
                try
                {
                    Assert.IsTrue(bannerAdElement.Displayed); break;
                }
                catch (Exception ex)
                {
                    string message = $"Introscreen Ad not present. {ex}";
                    Debug.WriteLine(message);
                    //Debug.ReadLine();
                    Console.WriteLine(message);
                }
            }

        }


    }
}
