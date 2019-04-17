using NUnit.Framework;
using BrowserStackIntegration;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using System.Net.Http;
using System;
using System.Diagnostics;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

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
    //[TestFixture("parallel", "galaxy-note4")]
    ////[TestFixture("parallel", "galaxy-s6")] //App or one of the otherApps cannot be run on version 5.0.
    ////[TestFixture("parallel", "nexus-9")] //tablet
    ////[TestFixture("parallel", "galaxy-tabs4")] //tablet
    [Parallelizable(ParallelScope.Fixtures)]
    public class WhenOnTheAndroidHomePage : HomePage
    {     
        public WhenOnTheAndroidHomePage(string profile, string device) : base(profile, device) { }

        const string URL1 = "GAURL1";
        const string URL2 = "GAURL2";
        const string URL3 = "GAURL3";
        const string URL4 = "GAURL4";

        [Test]
        public async Task TheHomePageIsPresent()
        {
            for (int i = 0; ; i++)
            {
                if (i >= 45) Assert.Fail("The Home page is not present.");
                try
                {
                    if (IsAndroidElementPresent("component-home-pageWrapper-contentList"))
                    break;
                }
                catch (Exception ex)
                {
                    string message = $"The Home page is not present. {ex}";
                    Debug.WriteLine(message);
                    //Debug.ReadLine();
                    Console.WriteLine(message);
                }
                Wait(1);
            }
        }

        [Test]
        public async Task TheHomePageBannerAdIsPresent()
        {
            await HomePageIsPresent();
            for (int i = 0; ; i++)
            {
                if (i >= 20) Assert.Fail("The Home Page banner ad is not present.");
                try
                {
                    if(IsAndroidElementPresent("non-module|-3|ad|advertisementModule|0|manually placed in page-wrapper|"))
                    break;
                }
                catch (Exception ex)
                {
                    string message = $"The Home Page banner ad is not present. {ex}";
                    Debug.WriteLine(message);
                    //Debug.ReadLine();
                    Console.WriteLine(message);
                }
                Wait(1);
            }
        }

        //[Test]
        public async Task TheModuleHomePageAdsArePresent()
        {
            await ModuleHomePageAdsArePresent();
        }
        //[Test]
        public async Task TheGoogleAnalyticsCallsAreCorrect()
        {
            await HomePageIsPresent();
            await GetNetworkLogs();
            //Figure out how to pass the network logs from the GetNetworkLogs() method into this method
            //Stub out the comparison of the network logs to URL1-4
            //var doesUrlExist = failingUrl.Contains(URL1);
            //doesUrlExist.Should().BeTrue();
        }

        [Test]
        public async Task GetStationAppConfigTest()
        {
            await GetHomePageScreenConfig();
        }

    }
}
