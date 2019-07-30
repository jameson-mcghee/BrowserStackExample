using NUnit.Framework;
using System.Threading.Tasks;
using BrowserStackIntegration;
using System.Diagnostics;
using System;

namespace ScreenShotTests
{
    [TestFixture("parallel", "pixel")]
    [TestFixture("parallel", "galaxy-tabs4")] //tablet
    [Parallelizable(ParallelScope.Fixtures)]
    public class AndroidScreenShots : WatchPage
    {
        public AndroidScreenShots(string profile, string device) : base(profile, device) { }

        [Test]
        public async Task CaptureScreenShotsOnAndroid()
        {
            #region Home Page

            await AndroidHomePageIsPresent();
            await Wait(5);
            await AndroidCaptureScreenShot(this.device);
            #endregion

            #region Weather Page

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
            await Wait(5);
            await AndroidCaptureScreenShot(this.device);
            #endregion

            #region Watch Page

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
            await Wait(5);
            await AndroidCaptureScreenShot(this.device);
            #endregion

            #region Topic Page

            if (IsAndroidElementPresent("button|||hamburger||manually placed on top of screen|"))
            {
                await AndroidClickCommand("button|||hamburger||manually placed on top of screen|");
            }
            else
            {
                Assert.Fail("The Star Icon (Topic Page) button is not present. ");
            }

            for (int i = 0; ; i++)
            {
                if (i >= 2) Assert.Fail("The Topic Page back button is not present. ");
                try
                {
                    if (IsAndroidElementPresent("button|||back||manually placed on top of screen|"))
                        break;
                }
                catch (Exception ex)
                {
                    string message = $"The Topic Page back button is not present. {ex}";
                    Debug.WriteLine(message);
                    //Debug.ReadLine();
                    Console.WriteLine(message);
                }
                Wait(1);
            }
            await Wait(5);
            await AndroidCaptureScreenShot(this.device);
            #endregion
        }
    }
}
