using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using BrowserStackIntegration;

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
    public class WhenOnTheAndroidHomePage : BrowserStackIntegrationImplementation
    {
        public WhenOnTheAndroidHomePage(string profile, string device) : base(profile, device) { }

        //[Test]
        public async Task TheBannerAdIsPresent()
        {
            var bannerAdElement = androidDriver.FindElements(By.ClassName("	android.webkit.WebView"));

            for (int second = 0; ; second++)
            {
                if (second >= 15) Assert.Fail("The banner ad is not present");
                try
                {
                    Assert.IsTrue(bannerAdElement.Any()); break;
                }
                catch (Exception ex)
                {
                    string message = $"The banner ad is not present. {ex}";
                    Debug.WriteLine(message);
                    //Debug.ReadLine();
                    Console.WriteLine(message);
                }
                Thread.Sleep(TimeSpan.FromSeconds(3));

            }

        }
    }
}
