using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace BrowserStackIntegration
{
    public class WatchPage : WeatherPage
    {
        public WatchPage(string profile, string device) : base(profile, device){}

        public static async Task<dynamic> GetWatchPageScreenConfig()
        {
            int adCount = 0;
            dynamic responseScreenConfig = await GetScreenConfigRequestByPageName("watch");

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
            Console.WriteLine($"Number of ad modules in the Watch Page screen config: {adCount}{Environment.NewLine}");
            return adCount;
        }

        //Android
        public async Task AndroidWatchPageIsPresent()
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



        //iOS
        public async Task IOSWatchPageIsPresent()
        {
            await IOSWeatherPageIsPresent();

            for (int i = 0; ; i++)
            {
                await ScrollDownOnIOS();
                await Wait(1);
                await SwipeRightToLeftOnIOS();

                if (i >= 5) Assert.Fail("The Watch Page is not present.");
                try
                {
                    if (IsiOSElementPresent("page||watch-wrapper||||"))
                    {
                        break;
                    }
                }
                catch (Exception ex)
                {
                    string message = $"The Watch Page is not present. {ex}";
                    Debug.WriteLine(message);
                    //Debug.ReadLine();
                    Console.WriteLine(message);
                }

            }
        }

    }
}
