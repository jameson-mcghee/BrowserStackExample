using NUnit.Framework;
using BrowserStackIntegration;
using System.Threading.Tasks;
using System;
using System.Diagnostics;

namespace MobileAppTests
{
    //[TestFixture("parallel", "iphone-8")]
    //[TestFixture("parallel", "iphone-8-plus")]
    //[TestFixture("parallel", "iphone-se")]
    [TestFixture("parallel", "iphone-xs")]
    //[TestFixture("parallel", "ipad-pro")]
    //[TestFixture("parallel", "ipad-5th")]
    [Parallelizable(ParallelScope.Fixtures)]
    public class IOSWhenUsingTheNavigationPanel : WatchPage
    {
        public IOSWhenUsingTheNavigationPanel(string profile, string device) : base(profile, device) { }

        [Test]
        public async Task TheUserIsAbleToNavigateToTheWeatherPage()
        {
            await IOSHomePageIsPresent();
            Assert.IsTrue(IsiOSElementPresent("component||navigation-bar||||"), "Navigation Bar is not present on the page. ");
            if (IsiOSElementPresent("button|0||weather||manually placed at bottom of screen|"))
            {
                await IOSClickCommand("button|0||weather||manually placed at bottom of screen|");
            }
            else
            {
                Assert.Fail("The Weather Page Navigation button is not present. ");
            }

            for (int i = 0; ; i++)
            {
                if (i >= 2) Assert.Fail("The Weather page is not present after navigating to it from the navigation bar. ");
                try
                {
                    if (IsiOSElementPresent("page||weather-wrapper||||"))
                        break;
                }
                catch (Exception ex)
                {
                    string message = $"The Weather page is not present after navigating to it from the navigation bar. {ex}";
                    Debug.WriteLine(message);
                    //Debug.ReadLine();
                    Console.WriteLine(message);
                }
                Wait(1);
            }
        }

        [Test]
        public async Task TheUserIsAbleToNavigateToTheWatchPage()
        {
            await IOSHomePageIsPresent();
            Assert.IsTrue(IsiOSElementPresent("component||navigation-bar||||"), "Navigation Bar is not present on the page. ");
            if (IsiOSElementPresent("button|0||watch||manually placed at bottom of screen|"))
            {
                await IOSClickCommand("button|0||watch||manually placed at bottom of screen|");
            }
            else
            {
                Assert.Fail("The Watch Page Navigation Button is not present. ");
            }

            for (int i = 0; ; i++)
            {
                if (i >= 2) Assert.Fail("The Watch page is not present after navigating to it from the navigation bar. ");
                try
                {
                    if (IsiOSElementPresent("page||watch-wrapper||||"))
                        break;
                }
                catch (Exception ex)
                {
                    string message = $"The Watch page is not present after navigating to it from the navigation bar. {ex}";
                    Debug.WriteLine(message);
                    //Debug.ReadLine();
                    Console.WriteLine(message);
                }
                Wait(1);
            }
        }

        [Test]
        public async Task TheUserIsAbleToNavigateToTheHomePage()
        {
            await IOSWeatherPageIsPresent();
            Assert.IsTrue(IsiOSElementPresent("component||navigation-bar||||"), "Navigation Bar is not present on the page. ");
            if (IsiOSElementPresent("button|0||home||manually placed at bottom of screen|"))
            {
               await IOSClickCommand("button|0||home||manually placed at bottom of screen|");
            }
            else
            {
                Assert.Fail("The Home Page Navigation Button is not present. ");
            }

            for (int i = 0; ; i++)
            {
                if (i >= 2) Assert.Fail("The Home page is not present after navigating to it from the navigation bar. ");
                try
                {
                    if (IsiOSElementPresent("page||home-wrapper||||"))
                        break;
                }
                catch (Exception ex)
                {
                    string message = $"The Home page is not present after navigating to it from the navigation bar. {ex}";
                    Debug.WriteLine(message);
                    //Debug.ReadLine();
                    Console.WriteLine(message);
                }
                Wait(1);
            }
        }
    }
}
