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
    //[TestFixture("parallel", "iphone-8")]
    //[TestFixture("parallel", "iphone-8-plus")]
    //[TestFixture("parallel", "iphone-se")]
    [TestFixture("parallel", "iphone-xs")]
    //[TestFixture("parallel", "ipad-pro")]
    //[TestFixture("parallel", "ipad-5th")]
    [Parallelizable(ParallelScope.Fixtures)]
    public class IOSWhenOnTheRadarScreen : RadarScreen
    {
        public IOSWhenOnTheRadarScreen(string profile, string device) : base(profile, device) { }

        [Test]
        public async Task TheRadarScreenIsPresent()
        {
            await IOSWeatherPageIsPresent();
            if (IsAndroidElementPresent("button|||explore-radars||weather page|"))
            {
                iosDriver.FindElementByAccessibilityId("button|||explore-radars||weather page|").Click();
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
                    if (IsiOSElementPresent("page||radar-viewer||||"))
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
            await IOSRadarScreenIsPresent();
            for (int i = 0; ; i++)
            {
                if (i >= 10) Assert.Fail("The Radar Screen banner ad is not present.");
                try
                {
                    if (IsiOSElementPresent("ad|-2|non-module|advertisementModule|0|manually placed in radar-viewer|"))
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
