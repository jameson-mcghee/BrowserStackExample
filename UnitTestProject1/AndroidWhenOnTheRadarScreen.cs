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
    public class AndroidWhenOnTheRadarScreen : RadarScreen
    {
        public AndroidWhenOnTheRadarScreen(string profile, string device) : base(profile, device) { }

        [Test]
        public async Task TheRadarScreenIsPresent()
        {
            await AndroidWeatherPageIsPresent();
            if(IsAndroidElementPresent("button|||explore-radars||weather page|"))
            {
                androidDriver.FindElementByAccessibilityId("button|||explore-radars||weather page|").Click();
            }
            else
            {
                Assert.Fail("Explore Radars button is not present.");
            }

            for (int i = 0; ; i++)
            {

                if (i >= 5) Assert.Fail("The Radar Screen is not present.");
                try
                {
                    if (IsAndroidElementPresent("page||radar-viewer||||"))
                        break;
                }
                catch (Exception ex)
                {
                    string message = $"The Radar Screen is not present. {ex}";
                    Debug.WriteLine(message);
                    //Debug.ReadLine();
                    Console.WriteLine(message);
                }
                Wait(1);
            }
        }

        [Test]
        public async Task TheRadarScreenBannerAdIsPresent()
        {
            await AndroidRadarScreenIsPresent();
            for (int i = 0; ; i++)
            {
                if (i >= 10) Assert.Fail("The Radar Screen banner ad is not present.");
                try
                {
                    if (IsAndroidElementPresent("ad|-2|non-module|advertisementModule|0|manually placed in radar-viewer|"))
                        break;
                }
                catch (Exception ex)
                {
                    string message = $"The Radar Screen banner ad is not present. {ex}";
                    Debug.WriteLine(message);
                    //Debug.ReadLine();
                    Console.WriteLine(message);
                }
                Wait(1);
            }
        }
    }
}
