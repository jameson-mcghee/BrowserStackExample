using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace BrowserStackIntegration
{
    public class WatchPage : WeatherPage
    {
        public WatchPage(string profile, string device) : base(profile, device){}

        //Android
        public async Task AndroidWatchPageIsPresent()
        {
            await AndroidWeatherPageIsPresent();

            for (int i = 0; ; i++)
            {
                await ScrollDownOnAndroid();
                Wait(1);
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
                    //Debug.ReadLine();
                    Console.WriteLine(message);
                }

            }
        }

        //TODO: Create WatchPageScreenConfigRequest() method for Android and iOS

        //iOS
        public async Task IOSWatchPageIsPresent()
        {
            await IOSWeatherPageIsPresent();

            for (int i = 0; ; i++)
            {
                await ScrollDownOnIOS();
                Wait(1);
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
