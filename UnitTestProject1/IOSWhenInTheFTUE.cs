using NUnit.Framework;
using System.Threading.Tasks;
using BrowserStackIntegration;
using System;
using System.Diagnostics;
using OpenQA.Selenium.Appium.MultiTouch;

namespace MobileAppTests
{
    //[TestFixture("parallel", "iphone-8")]
    //[TestFixture("parallel", "iphone-8-plus")]
    //[TestFixture("parallel", "iphone-se")]
    [TestFixture("parallel", "iphone-xs")]
    //[TestFixture("parallel", "ipad-pro")]
    //[TestFixture("parallel", "ipad-5th")]
    [Parallelizable(ParallelScope.Fixtures)]
    public class IOSWhenInTheFTUE : FirstTimeUserExperience
    {
        public IOSWhenInTheFTUE(string profile, string device) : base(profile, device) { }

        //[Test]
        public async Task TheFTUEModuleIsPresent()
        {
            await IOSUserCanAccessTheDayPartingScreen();
            for (int i = 0; ; i++)
            {
                if (i >= 10) Assert.Fail("FTUE is not being displayed.");
                try
                {
                    if (IsiOSElementPresent("page||ftue||||"))
                    {
                        break;
                    }
                }
                catch (Exception ex)
                {
                    string message = $"FTUE is not being displayed. {ex}";
                    Debug.WriteLine(message);
                    //Debug.ReadLine();
                    Console.WriteLine(message);
                }
                Wait(1);
            }
        }

        [Test]
        public async Task TheUserCanNavigateTheFTUEUsingTheButtons()
        {
            await IOSUsersCanAccessTheFTUEHomePage();
            await IOSClickFTUENextButton();
            await IOSUsersCanAccessTheFTUETopicFollowPage();
            await IOSClickFTUENextButton();
            await IOSUsersCanAccessTheFTUELocationPage();
            await IOSClickFTUENextButton();
            await IOSClickFTUEPreviousButton();
            await IOSUsersCanAccessTheFTUELocationPage();
            await IOSClickFTUENextButton();
            await IOSClickFTUEGetStartedButton();
        }

        [Test]
        public async Task TheUserCanNavigateTheFTUEBySwiping()
        {
            await IOSUsersCanAccessTheFTUEHomePage();
            await SwipeRightToLeftOnIOS();
            await IOSUsersCanAccessTheFTUETopicFollowPage();
            await SwipeRightToLeftOnIOS();
            await IOSUsersCanAccessTheFTUELocationPage();
            await SwipeRightToLeftOnIOS();
            await IOSUsersCanAccessTheFTUETopicFollowPage();
            await IOSClickFTUECloseButton();
        }

        //[Test]
        public async Task TheUserCanAddALocationInTheFTUE()
        {
            await IOSUsersCanAccessTheFTUEHomePage();
            await IOSClickFTUENextButton();
            await IOSUsersCanAccessTheFTUETopicFollowPage();
            await IOSClickFTUENextButton();
            await IOSUsersCanAccessTheFTUELocationPage();
            await IOSTypeTextCommand("input||non-module|ftue-location|||", "Oak Ridge");

            //TODO: Confirm if this will work on iOS
            var textFieldLocation = iosDriver.FindElementByAccessibilityId("input||non-module|ftue-location|||").Location;
            var textFieldSize = iosDriver.FindElementByAccessibilityId("input||non-module|ftue-location|||").Size;
            int textFieldSizeWidth = textFieldSize.Width;
            int textFieldSizeHeight = textFieldSize.Height;
            int textFieldYCoord = textFieldLocation.Y;
            int textFieldXCoord = textFieldLocation.X;

            TouchAction action = new TouchAction(androidDriver);
            action.Press((textFieldXCoord + textFieldSizeWidth) * 0.5, (textFieldYCoord - textFieldSizeHeight) - 10)
            .Wait(500)
            .Release()
            .Perform();

            await IOSClickFTUENextButton();
            await IOSClickFTUEGetStartedButton();
        }
    }
}
