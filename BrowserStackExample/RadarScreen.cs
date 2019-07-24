using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace BrowserStackIntegration
{
    public class RadarScreen : WeatherPage
    {
        public RadarScreen(string profile, string device) : base(profile, device) { }

        //Android
        public async Task AndroidRadarScreenIsPresent()
        {
            await AndroidWeatherPageIsPresent();
            if (IsAndroidElementPresent("button|||explore-radars||weather page|"))
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
                    //Debug.ReadLine();
                    Console.WriteLine(message);
                }
                Wait(1);
            }
        }

        //iOS
        public async Task IOSRadarScreenIsPresent()
        {
            await IOSWeatherPageIsPresent();
            if (IsiOSElementPresent("button|||explore-radars||weather page|"))
            {
                await IOSClickCommand("button|||explore-radars||weather page|");
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
    }
}
