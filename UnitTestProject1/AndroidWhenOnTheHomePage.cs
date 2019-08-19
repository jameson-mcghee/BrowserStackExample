using NUnit.Framework;
using BrowserStackIntegration;
using System.Threading.Tasks;
using System;
using System.Diagnostics;

namespace HomePageTests
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
    public class AndroidWhenOnTheHomePage : HomePage
    {
        public AndroidWhenOnTheHomePage(string profile, string device) : base(profile, device) { }

        //const string URL1 = "GAURL1";
        //const string URL2 = "GAURL2";
        //const string URL3 = "GAURL3";
        //const string URL4 = "GAURL4";

        //[Test]
        public async Task TheHomePageIsPresent()
        {
            for (int i = 0; ; i++)
            {
                if (i >= 20) Assert.Fail("The Home page is not present.");
                try
                {
                    if (IsAndroidElementPresent("page||home-wrapper||||"))
                    {
                        break;
                    }
                    if (IsAndroidElementPresent("page||ftue||||"))
                    {
                        await AndroidClickFTUECloseButton();
                    }
                }
                catch (Exception ex)
                {
                    string message = $"The Home page is not present. {ex}";
                    Debug.WriteLine(message);
                    Console.WriteLine(message);
                }
                await Wait(1);
            }
        }

        [Test]
        public async Task TheHomePageBannerAdIsPresent()
        {
            await AndroidHomePageIsPresent();
            for (int i = 0; ; i++)
            {
                if (i >= 10) Assert.Fail("The Home Page banner ad is not present.");
                try
                {
                    if(IsAndroidElementPresent("ad|-3|non-module|advertisementModule|0|manually placed in page-wrapper|"))
                        break;
                }
                catch (Exception ex)
                {
                    string message = $"The Home Page banner ad is not present. {ex}";
                    Debug.WriteLine(message);
                    Console.WriteLine(message);
                }
                await Wait(1);
            }
        }

        [Test]
        public async Task ConfirmAdModulesArePresentAndCount()
        {
            int adModuleCount = 0;

            await AndroidHomePageIsPresent();
            await Wait(5);
            for (int i = 0; ; i++)
            {
                if (i >= 260) Assert.Fail("Could not find the last element on the Home Page prior to time out.");
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
                    string message = $"Could not find the last element on the Home Page. {ex}";
                    Debug.WriteLine(message);
                    Console.WriteLine(message);
                }
            }
            Console.Write($"Number of ad modules on the Home Page: {adModuleCount}{Environment.NewLine}");
            dynamic pageAdCount = await GetHomePageScreenConfig();
            Assert.GreaterOrEqual(adModuleCount, pageAdCount, 
                $"The screen config ad module count '{pageAdCount}' is greater than the number of ad modules found on the page '{adModuleCount}'.");
        }

        //[Test]
        public async Task TheGoogleAnalyticsCallsAreCorrect()
        {
            await AndroidHomePageIsPresent();
            //await GetNetworkLogs(1);
            //TODO: Figure out how to pass the network logs from the GetNetworkLogs() method into this method
            //TODO: Stub out the comparison of the network logs to URL1-4
            //var doesUrlExist = failingUrl.Contains(URL1);
            //doesUrlExist.Should().BeTrue();
        }

        //TODO: Home Page: Compare the screenConfig modules from the Home Page Screen Config to those on the Home Page


    }
}
