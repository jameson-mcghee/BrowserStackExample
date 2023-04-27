using NUnit.Framework;
using System.Threading.Tasks;
using BrowserStackIntegration;
using System.Linq;
using System.Diagnostics;
using System;
using System.Threading;

namespace DayPartingScreenTests
{
    [TestFixture("parallel", "pixel")]
    [TestFixture("parallel", "pixel-2")]
    [TestFixture("parallel", "pixel-3")]
    [TestFixture("parallel", "nexus-9")]
    [TestFixture("parallel", "galaxy-s8")]
    [TestFixture("parallel", "galaxy-s9")]
    [TestFixture("parallel", "galaxy-note8")]
    [TestFixture("parallel", "galaxy-note9")]
    [TestFixture("parallel", "galaxy-tabs3")] //tablet
    [TestFixture("parallel", "galaxy-tabs4")] //tablet
    [TestFixture("parallel", "galaxy-tabs5e")] //tablet
    [Parallelizable(ParallelScope.Fixtures)]
    public class AndroidWhenLaunchingTheApp : DayPartingScreen
    {
        public AndroidWhenLaunchingTheApp(string profile, string device) : base(profile, device) { }

        [Test]
        public async Task TheUserCanAccessTheDayPartingScreen()
        {
            for (int i = 0; ; i++)
            {
                if (i >= 15) Assert.Fail("Day Parting Screen is not being displayed.");
                try
                {
                    if (IsAndroidElementPresent("page||splash-screen-wrapper||||"))
                    break;
                }
                catch (Exception ex)
                {
                    string message = $"Day Parting Screen is not being displayed. {ex}";
                    Debug.WriteLine(message);
                    Console.WriteLine(message);
                }
               await Wait(1);
            }

        }

        [Test]
        public async Task TheDayPartingBannerIsGenerated()
        {
            await AndroidDayPartingBannerIsGenerated();

            string sponsoredByElement = androidDriver.FindElementByAccessibilityId("non-module|-4|ad|advertisementModule|0|manually placed in splash-screen|").Text;
            string dayPartingBannerElement = androidDriver.FindElementByAccessibilityId("non-module|-4|ad|advertisementModule|0|manually placed in splash-screen|").Text;

            Assert.IsTrue(sponsoredByElement.Any());
            Assert.IsTrue(dayPartingBannerElement.Any());
            Assert.IsTrue(dayPartingBannerElement.Contains("Good "), dayPartingBannerElement + "Day Parting Banner does not contain 'Good ***'.");
            Assert.IsTrue(sponsoredByElement.Contains("Sponsored By"), sponsoredByElement + "'Sponsored by' message does not contain 'Sponsored By'.");
        }

        [Test]
        public async Task TheDayPartingScreenAdIsPresent()
        {
            for (int i = 0; ; i++)
            {
                if (i >= 10) Assert.Fail("The Day Parting Screen Ad is not present.");
                try
                {
                    if (IsAndroidElementPresent("ad|-4|non-module|advertisementModule|0|manually placed in splash-screen|"))
                        break;
                }
                catch (Exception ex)
                {
                    string message = $"The Day Parting Screen Ad is not present. {ex}";
                    Debug.WriteLine(message);
                    Console.WriteLine(message);
                }
               await Wait(1);
            }
        }

        [Test]
        public async Task TheGoogleAnalyticsCallsArePresent()
        {
            await TheDayPartingScreenAdIsPresent();
            await GetNetworkLogs(1);

        }
    }
}
