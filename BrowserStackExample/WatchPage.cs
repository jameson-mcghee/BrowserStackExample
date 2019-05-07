using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

            SwipeRightToLeftOnAndroid();
            if (IsAndroidElementPresent("page||watch-page-wrapper||||"))
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail("The Watch Page is not present.");
            }
        }

        //iOS
        public async Task IOSWatchPageIsPresent()
        {
            await IOSWeatherPageIsPresent();

            SwipeRightToLeftOnIOS();
            if (IsiOSElementPresent("page||watch-page-wrapper||||"))
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail("The Watch Page is not present.");
            }
        }
    }
}
