using NUnit.Framework;
using BrowserStackIntegration;
using System.Threading.Tasks;
using System;
using System.Diagnostics;

namespace RadarPageTests
{
    [TestFixture("parallel", "pixel")]
    [TestFixture("parallel", "pixel-2")]
    [TestFixture("parallel", "pixel-3")]
    //[TestFixture("parallel", "nexus-9")]
    [TestFixture("parallel", "galaxy-s8")]
    [TestFixture("parallel", "galaxy-s9")]
    [TestFixture("parallel", "galaxy-note8")]
    [TestFixture("parallel", "galaxy-note9")]
    //[TestFixture("parallel", "galaxy-tabs3")] //tablet
    [TestFixture("parallel", "galaxy-tabs4")] //tablet
    [TestFixture("parallel", "galaxy-tabs5e")] //tablet
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
                await AndroidClickCommand("button|||explore-radars||weather page|");
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
                    Console.WriteLine(message);
                }
               await Wait(1);
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
                    Console.WriteLine(message);
                }
               await Wait(1);
            }
        }
    }
}
