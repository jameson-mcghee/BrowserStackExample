using NUnit.Framework;
using System.Threading.Tasks;
using BrowserStackIntegration;
using System.Diagnostics;
using System;
using OpenQA.Selenium.Appium.MultiTouch;

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

            await Wait(15);

            //TODO: Remove this section once a screenshot Android build is available
            #region FTUE Close Button
            try
            {
                await AndroidClickFTUECloseButton();
            }
            catch (Exception ex)
            {
                string message = $"Could not click the FTUE button:{Environment.NewLine}{ex}";
                Debug.WriteLine(message);
                Console.WriteLine(message);
                throw;
            }
            #endregion

            await Wait(5);
            await AndroidCaptureScreenShot(this.device);
            #endregion

            #region Weather Page

            await SwipeRightToLeftOnAndroid();
            await Wait(5);
            await AndroidCaptureScreenShot(this.device);
            #endregion

            #region Watch Page

            await ScrollDownOnAndroid();
            await Wait(1);
            await SwipeRightToLeftOnAndroid();
            await SwipeRightToLeftOnAndroid();
            await Wait(5);
            await AndroidCaptureScreenShot(this.device);
            #endregion

            #region Topic Page

            int screenHeight = androidDriver.Manage().Window.Size.Height;
            int screenWidth = androidDriver.Manage().Window.Size.Width;

            TouchAction action = new TouchAction(androidDriver);
            action.Press(screenWidth * 0.08, screenHeight * 0.06)
            .Wait(500)
            .Release()
            .Perform();

            await Wait(5);
            await AndroidCaptureScreenShot(this.device);
            #endregion
        }
    }
}
