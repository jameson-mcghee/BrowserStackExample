using NUnit.Framework;
using BrowserStackIntegration;
using System.Threading.Tasks;
using System;
using System.Diagnostics;

namespace MobileAppTests
{
    //[TestFixture("parallel", "pixel")]
    //[TestFixture("parallel", "pixel-2")]
    //[TestFixture("parallel", "pixel-3")]
    //[TestFixture("parallel", "galaxy-s7")]
    //[TestFixture("parallel", "galaxy-s8")]
    [TestFixture("parallel", "galaxy-s9")]
    //[TestFixture("parallel", "galaxy-note8")]
    //[TestFixture("parallel", "galaxy-note9")]
    ////[TestFixture("parallel", "galaxy-tabs4")] //tablet
    [Parallelizable(ParallelScope.Fixtures)]
    public class AndroidWhenUsingTheNavigationPanel : WatchPage
    {
        public AndroidWhenUsingTheNavigationPanel(string profile, string device) : base(profile, device) { }

        [Test]
        public async Task TheUserIsAbleToNavigateToTheWeatherPage()
        {
            await AndroidHomePageIsPresent();
            Assert.IsTrue(IsAndroidElementPresent("component||navigation-bar||||"), "Navigation Bar is not present on the page. ");
            if (IsAndroidElementPresent("button|0||weather||manually placed at bottom of screen|"))
            {
                await AndroidClickCommand("button|0||weather||manually placed at bottom of screen|");
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
                    if (IsAndroidElementPresent("page||weather-wrapper||||"))
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
            await AndroidHomePageIsPresent();
            Assert.IsTrue(IsAndroidElementPresent("component||navigation-bar||||"), "Navigation Bar is not present on the page. ");
            if (IsAndroidElementPresent("button|0||watch||manually placed at bottom of screen|"))
            {
                await AndroidClickCommand("button|0||watch||manually placed at bottom of screen|");
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
                    if (IsAndroidElementPresent("page||watch-wrapper||||"))
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
            await AndroidWeatherPageIsPresent();
            Assert.IsTrue(IsAndroidElementPresent("component||navigation-bar||||"), "Navigation Bar is not present on the page. ");
            if (IsAndroidElementPresent("button|0||home||manually placed at bottom of screen|"))
            {
                await AndroidClickCommand("button|0||home||manually placed at bottom of screen|");
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
                    if (IsAndroidElementPresent("page||home-wrapper||||"))
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
