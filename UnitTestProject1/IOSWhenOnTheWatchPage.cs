using NUnit.Framework;
using BrowserStackIntegration;
using System.Threading.Tasks;
using System;
using System.Diagnostics;

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
    public class IOSWhenOnTheWatchPage : WatchPage
    {
        public IOSWhenOnTheWatchPage(string profile, string device) : base(profile, device) { }

        //[Test]
        public async Task TheWatchPageIsPresent()
        {
            await IOSWeatherPageIsPresent();

            for (int i = 0; ; i++)
            {
                await ScrollDownOnIOS();
                Wait(1);
                await SwipeRightToLeftOnIOS();

                if (i >= 5) Assert.Fail("The Watch Page is not present.");
                try
                {
                    if (IsiOSElementPresent("page||watch-wrapper||||"))
                    {
                        break;
                    }
                }
                catch (Exception ex)
                {
                    string message = $"The Watch Page is not present. {ex}";
                    Debug.WriteLine(message);
                    //Debug.ReadLine();
                    Console.WriteLine(message);
                }

            }
        }

        //[Test]
        public async Task TheWatchPageBannerAdIsPresent()
        {
            await IOSWatchPageIsPresent();
            for (int i = 0; ; i++)
            {
                if (i >= 10) Assert.Fail("The Watch Page banner ad is not present.");
                try
                {
                    if (IsiOSElementPresent("ad|-3|non-module|advertisementModule|0|manually placed in page-wrapper|"))
                        break;
                }
                catch (Exception ex)
                {
                    string message = $"The Watch Page banner ad is not present. {ex}";
                    Debug.WriteLine(message);
                    //Debug.ReadLine();
                    Console.WriteLine(message);
                }
                Wait(1);
            }
        }

        //[Test]
        public async Task ConfirmAdModulesArePresentAndCount()
        {
            await IOSWatchPageIsPresent();

            int adModuleCount = 0;

            for (int i = 0; ; i++)
            {
                if (i >= 120) Assert.Fail("Could not find the last element on the Watch Page prior to time out.");
                try
                {
                    await ScrollDownOnIOS();

                    if (IsiOSElementPresent("module|advertisement"))
                    {
                        adModuleCount++;
                    }
                    if (IsiOSElementPresent("module|last"))
                    {
                        break;
                    }
                }
                catch (Exception ex)
                {
                    string message = $"Could not find the last element on the Watch Page. {ex}";
                    Debug.WriteLine(message);
                    //Debug.ReadLine();
                    Console.WriteLine(message);
                }
                Wait(1);
            }

            Console.Write("Number of ad modules on the Watch Page: " + adModuleCount);
        }

        //TODO: Watch Page: Compare the screenConfig modules from the IOSWatchPageScreenConfigRequest() method to those on the Watch Page

    }
}
