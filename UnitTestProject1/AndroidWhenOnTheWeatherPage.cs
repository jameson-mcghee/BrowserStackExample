using NUnit.Framework;
using BrowserStackIntegration;
using System.Threading.Tasks;
using System;
using System.Diagnostics;

namespace WeatherPageTests
{
    [TestFixture("parallel", "pixel")]
    [TestFixture("parallel", "pixel-2")]
    [TestFixture("parallel", "pixel-3")]
    //[TestFixture("parallel", "nexus-9")]
    [TestFixture("parallel", "galaxy-s8")]
    [TestFixture("parallel", "galaxy-s9")]
    [TestFixture("parallel", "galaxy-note8")]
    [TestFixture("parallel", "galaxy-note9")]
    [TestFixture("parallel", "galaxy-tabs3")] //tablet
    [TestFixture("parallel", "galaxy-tabs4")] //tablet
    [TestFixture("parallel", "galaxy-tabs5e")] //tablet
    [Parallelizable(ParallelScope.Fixtures)]
    public class AndroidWhenOnTheWeatherPage : WeatherPage
    {
        public AndroidWhenOnTheWeatherPage(string profile, string device) : base(profile, device) { }

        [Test]
        public async Task TheWeatherPageIsPresent()
        {
            await AndroidHomePageIsPresent();

            for (int i = 0; ; i++)
            {
                await SwipeRightToLeftOnAndroid();

                if (i >= 5) Assert.Fail("The Weather Page is not present.");
                try
                {
                    if (IsAndroidElementPresent("page||weather-wrapper||||"))
                        break;
                }
                catch (Exception ex)
                {
                    string message = $"The Weather Page is not present. {ex}";
                    Debug.WriteLine(message);
                    //Debug.ReadLine();
                    Console.WriteLine(message);
                }
                Wait(1);
            }

        }

        [Test]
        public async Task TheWeatherPageBannerAdIsPresent()
        {
            await AndroidWeatherPageIsPresent();
            for (int i = 0; ; i++)
            {
                if (i >= 10) Assert.Fail("The Weather Page banner ad is not present.");
                try
                {
                    if (IsAndroidElementPresent("ad|-3|non-module|advertisementModule|0|manually placed in page-wrapper|"))
                        break;
                }
                catch (Exception ex)
                {
                    string message = $"The Weather Page banner ad is not present. {ex}";
                    Debug.WriteLine(message);
                    //Debug.ReadLine();
                    Console.WriteLine(message);
                }
                Wait(1);
            }
        }

        [Test]
        public async Task ConfirmAdModulesArePresentAndCount()
        {
            await AndroidWeatherPageIsPresent();

            int adModuleCount = 0;

            for (int i = 0; ; i++)
            {
                if (i >= 90) Assert.Fail("Could not find the last element on the Weather Page prior to time out.");
                try
                {
                    await ScrollDownOnAndroid();

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
                    string message = $"Could not find the last element on the Weather Page. {ex}";
                    Debug.WriteLine(message);
                    //Debug.ReadLine();
                    Console.WriteLine(message);
                }
                Wait(1);
            }

            Console.Write("Number of ad modules on the Weather Page: " + adModuleCount);
        }

        //TODO: Weather Page: Compare the screenConfig modules from the AndroidWeatherPageScreenConfigRequest() method to those on the Weather Page

    }
}
