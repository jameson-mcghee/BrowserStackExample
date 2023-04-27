using NUnit.Framework;
using System.Threading.Tasks;
using BrowserStackIntegration;
using System.Linq;
using System;
using System.Diagnostics;
using System.Threading;

namespace MobileAppTests
{
    [TestFixture("parallel", "iphone-7")]
    [TestFixture("parallel", "iphone-8")]
    [TestFixture("parallel", "iphone-8-plus")]
    [TestFixture("parallel", "iphone-se")]
    [TestFixture("parallel", "iphone-xs")]
    [TestFixture("parallel", "iphone-xsmax")]
    [TestFixture("parallel", "ipad-pro")] //Tablet
    [TestFixture("parallel", "ipad-5th")] //Tablet
    [Parallelizable(ParallelScope.Fixtures)]
    public class IOSWhenLaunchingTheApp : DayPartingScreen
    {
        public IOSWhenLaunchingTheApp(string profile, string device) : base(profile, device) { }

        [Test]
        public async Task TheUserCanAccessTheDayPartingScreen()
        {
            await IOSUserCanAccessTheDayPartingScreen();
            Assert.IsTrue(iosDriver.FindElementByName
                ("Good Morning Sponsored By non-module|-4|ad|advertisementModule|0|manually placed in splash-screen|").Displayed);

        }

        [Test]
        public async Task TheDayPartingBannerIsGenerated()
        {
            await IOSDayPartingBannerIsGenerated();

            string sponsoredByElement = iosDriver.FindElementByName("Sponsored By non-module|-4|ad|advertisementModule|0|manually placed in splash-screen|").Text;
            string dayPartingBannerElement = iosDriver.FindElementByName("Good {*} Sponsored By non-module|-4|ad|advertisementModule|0|manually placed in splash-screen|").Text;

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
                ApproveiOSAlerts();
                if (i >= 40) Assert.Fail("The Day Parting Screen Ad is not present.");
                try
                {
                    if (IsiOSElementPresent("non-module|-4|ad|advertisementModule|0|manually placed in splash-screen|"))
                        break;
                }
                catch (Exception ex)
                {
                    string message = $"The Day Parting Screen Ad is not present. {ex}";
                    Debug.WriteLine(message);

                    Console.WriteLine(message);
                }
                Thread.Sleep(TimeSpan.FromMilliseconds(250));
            }
        }


    }
}
