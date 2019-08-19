using NUnit.Framework;
using BrowserStackIntegration;
using System.Threading.Tasks;
using System;
using System.Diagnostics;

namespace WatchPageTests
{
    [TestFixture("parallel", "pixel")]
    //[TestFixture("parallel", "pixel-2")]
    //[TestFixture("parallel", "pixel-3")]
    ////[TestFixture("parallel", "nexus-9")]
    //[TestFixture("parallel", "galaxy-s8")]
    //[TestFixture("parallel", "galaxy-s9")]
    //[TestFixture("parallel", "galaxy-note8")]
    //[TestFixture("parallel", "galaxy-note9")]
    ////[TestFixture("parallel", "galaxy-tabs3")] //tablet
    //[TestFixture("parallel", "galaxy-tabs4")] //tablet
    //[TestFixture("parallel", "galaxy-tabs5e")] //tablet
    [Parallelizable(ParallelScope.Fixtures)]
    public class AndroidWhenOnTheWatchPage : WatchPage
    {
        public AndroidWhenOnTheWatchPage(string profile, string device) : base(profile, device) { }

        //[Test]
        public async Task TheWatchPageIsPresent()
        {
            await AndroidWeatherPageIsPresent();

            for (int i = 0; ; i++)
            {
                await ScrollDownOnAndroid();
               await Wait(1);
                await SwipeRightToLeftOnAndroid();

                if (i >= 5) Assert.Fail("The Watch Page is not present.");
                try
                {
                    if (IsAndroidElementPresent("page||watch-wrapper||||"))
                    {
                        break;
                    }
                }
                catch (Exception ex)
                {
                    string message = $"The Watch Page is not present. {ex}";
                    Debug.WriteLine(message);
                    Console.WriteLine(message);
                }
                
            }
        }

        [Test]
        public async Task TheWatchPageBannerAdIsPresent()
        {
            await AndroidWatchPageIsPresent();
            for (int i = 0; ; i++)
            {
                if (i >= 10) Assert.Fail("The Watch Page banner ad is not present.");
                try
                {
                    if (IsAndroidElementPresent("ad|-3|non-module|advertisementModule|0|manually placed in page-wrapper|"))
                        break;
                }
                catch (Exception ex)
                {
                    string message = $"The Watch Page banner ad is not present. {ex}";
                    Debug.WriteLine(message);
                    Console.WriteLine(message);
                }
               await Wait(1);
            }
        }

        [Test]
        public async Task CompareAdModuleCountOnPageToScreenConfig()
        {
            int adModuleCount = 0;

            await AndroidWatchPageIsPresent();
            await Wait(5);
            for (int i = 0; ; i++)
            {
                if (i >= 260) Assert.Fail("Could not find the last element on the Watch Page prior to time out.");
                try
                {
                    await ScrollDownOnAndroid();
                    await Wait(3);

                    if (IsAndroidElementPresent("module|advertisement"))
                    {
                        adModuleCount++;
                    }
                    if (IsAndroidElementPresent("module|last"))
                    {
                        break;
                    }
                }
                catch (Exception ex)
                {
                    string message = $"Could not find the last element on the Watch Page. {ex}";
                    Debug.WriteLine(message);
                    Console.WriteLine(message);
                }
            }
            Console.Write($"Number of ad modules on the Watch Page: {adModuleCount}{Environment.NewLine}");
            dynamic pageAdCount = await GetWatchPageScreenConfig();
            Assert.GreaterOrEqual(adModuleCount, pageAdCount,
                $"The screen config ad module count '{pageAdCount}' is greater than the number of ad modules found on the page '{adModuleCount}'.");
        }

        //TODO: Watch Page: Compare the screenConfig modules from the AndroidWatchPageScreenConfigRequest() method to those on the Watch Page

    }
}
