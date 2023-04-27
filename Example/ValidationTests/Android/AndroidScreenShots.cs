using NUnit.Framework;
using System.Threading.Tasks;
using BrowserStackIntegration;
using OpenQA.Selenium.Appium.MultiTouch;

namespace ScreenShotTests
{
    [TestFixture("parallel", "pixel-2")]
    [TestFixture("parallel", "galaxy-tabs3")] //tablet
    [Parallelizable(ParallelScope.Fixtures)]
    public class AndroidScreenShots : WatchPage
    {
        public AndroidScreenShots(string profile, string device) : base(profile, device) { }

        [Test]
        public async Task CaptureScreenShotsOnAndroid()
        {
            #region Home Page

            await Wait(60);
            await ScrollUpOnAndroid();
            await AndroidCaptureScreenShotForStore(this.device);
            #endregion

            #region Weather Page

            await SwipeRightToLeftOnAndroid();
            await Wait(5);
            await ScrollUpOnAndroid();
            await AndroidCaptureScreenShotForStore(this.device);
            #endregion

            #region Watch Page

            await ScrollDownOnAndroid();
            await Wait(1);
            await SwipeRightToLeftOnAndroid();
            await SwipeRightToLeftOnAndroid();
            await SwipeRightToLeftOnAndroid();
            await Wait(5);
            await AndroidCaptureScreenShotForStore(this.device);
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
            await AndroidCaptureScreenShotForStore(this.device);
            #endregion
        }
    }
}
