using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace BrowserStackIntegration
{
    public class WeatherPage : HomePage
    {
        public WeatherPage(string profile, string device) : base(profile, device){}

        //Android
        public async Task AndroidWeatherPageIsPresent()
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

        //TODO: Create a WeatherPageScreenConfigRequest() method for Android and iOS

        //iOS
        public async Task IOSWeatherPageIsPresent()
        {
            await IOSHomePageIsPresent();

            for (int i = 0; ; i++)
            {
                await SwipeRightToLeftOnIOS();

                if (i >= 5) Assert.Fail("The Weather Page is not present.");
                try
                {
                    if (IsiOSElementPresent("page||weather-wrapper||||"))
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

    }
}
