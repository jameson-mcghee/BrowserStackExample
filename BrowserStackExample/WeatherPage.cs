using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace BrowserStackIntegration
{
    public class WeatherPage : HomePage
    {
        public WeatherPage(string profile, string device) : base(profile, device){}

        public static async Task<dynamic> GetWeatherPageScreenConfig()
        {
            int adCount = 0;
            dynamic responseScreenConfig = await GetScreenConfigRequestByPageName("weather");

            Assert.IsNotNull(responseScreenConfig, "No screen config information in the API response. ");

            dynamic pageConfigList = responseScreenConfig.modules;

            foreach (dynamic item in pageConfigList)
            {
                if (item.name?.ToString() == "advertisementModule")
                {
                    adCount++;
                }
            }
            Assert.IsNotNull(adCount, "Advertisement Module count in the screen config is null. ");
            Console.WriteLine($"Number of ad modules in the Weather Page screen config: {adCount}{Environment.NewLine}");
            return adCount;
        }

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
                await Wait(1);
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
                await Wait(1);
            }
        }

    }
}
