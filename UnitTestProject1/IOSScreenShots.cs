using NUnit.Framework;
using System.Threading.Tasks;
using BrowserStackIntegration;
using System;
using System.Diagnostics;
using OpenQA.Selenium.Appium.MultiTouch;

namespace ScreenShotTests
{
    [TestFixture("parallel", "iphone-8-plus")]
    [TestFixture("parallel", "iphone-xsmax")]
    [TestFixture("parallel", "ipad-pro")] //Tablet
    [Parallelizable(ParallelScope.Fixtures)]
    public class IOSScreenShots : WatchPage
    {
        public IOSScreenShots(string profile, string device) : base(profile, device) { }

        [Test]
        public async Task CaptureScreenShotsOniOS()
        {
            #region Home Page

            await Wait(15);
            await ApproveiOSAlerts();
            await IOSCaptureScreenShot(this.device);
            #endregion

            #region Weather Page

            await SwipeRightToLeftOnIOS();
            await Wait(5);
            await IOSCaptureScreenShot(this.device);
            #endregion

            #region Watch Page

            await ScrollDownOnIOS();
            await Wait(1);
            await SwipeRightToLeftOnIOS();
            await SwipeRightToLeftOnIOS();
            await Wait(5);
            await IOSCaptureScreenShot(this.device);
            #endregion

            #region Topic Page

            int screenHeight = iosDriver.Manage().Window.Size.Height;
            int screenWidth = iosDriver.Manage().Window.Size.Width;

            TouchAction action = new TouchAction(iosDriver);
            action.Press(screenWidth * 0.08, screenHeight * 0.06)
            .Wait(500)
            .Release()
            .Perform();

            await Wait(5);
            await IOSCaptureScreenShot(this.device);
            #endregion
        }

    }
}
