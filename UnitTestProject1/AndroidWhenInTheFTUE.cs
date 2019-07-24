using NUnit.Framework;
using BrowserStackIntegration;
using System.Threading.Tasks;
using System;
using System.Diagnostics;
using OpenQA.Selenium.Appium.MultiTouch;

namespace MobileAppTests
{
    [TestFixture("parallel", "pixel")]
    [TestFixture("parallel", "pixel-2")]
    [TestFixture("parallel", "pixel-3")]
    [TestFixture("parallel", "galaxy-s7")]
    [TestFixture("parallel", "galaxy-s8")]
    [TestFixture("parallel", "galaxy-s9")]
    [TestFixture("parallel", "galaxy-note8")]
    [TestFixture("parallel", "galaxy-note9")]
    [TestFixture("parallel", "galaxy-tabs4")] //tablet
    [Parallelizable(ParallelScope.Fixtures)]
    public class AndroidWhenInTheFTUE : FirstTimeUserExperience
    {
        public AndroidWhenInTheFTUE(string profile, string device) : base(profile, device) { }

        //[Test]
        public async Task TheFTUEModuleIsPresent()
        {
            await AndroidUserCanAccessTheDayPartingScreen();
            for (int i = 0; ; i++)
            {
                if (i >= 10) Assert.Fail("FTUE is not being displayed.");
                try
                {
                    if (IsAndroidElementPresent("page||ftue||||"))
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
            await AndroidUsersCanAccessTheFTUEHomePage();
            await AndroidClickFTUENextButton();
            await AndroidUsersCanAccessTheFTUETopicFollowPage();
            await AndroidClickFTUENextButton();
            await AndroidUsersCanAccessTheFTUELocationPage();
            await AndroidClickFTUENextButton();
            await AndroidClickFTUEPreviousButton();
            await AndroidUsersCanAccessTheFTUELocationPage();
            await AndroidClickFTUENextButton();
            await AndroidClickFTUEGetStartedButton();
        }

        [Test]
        public async Task TheUserCanNavigateTheFTUEBySwiping()
        {
            await AndroidUsersCanAccessTheFTUEHomePage();
            await SwipeRightToLeftOnAndroid();
            await AndroidUsersCanAccessTheFTUETopicFollowPage();
            await SwipeRightToLeftOnAndroid();
            await AndroidUsersCanAccessTheFTUELocationPage();
            await SwipeRightToLeftOnIOS();
            await AndroidUsersCanAccessTheFTUETopicFollowPage();
            await AndroidClickFTUECloseButton();
        }

        //[Test]
        public async Task TheUserCanAddALocationInTheFTUE()
        {
            await AndroidUsersCanAccessTheFTUEHomePage();
            await AndroidClickFTUENextButton();
            await AndroidUsersCanAccessTheFTUETopicFollowPage();
            await AndroidClickFTUENextButton();
            await AndroidUsersCanAccessTheFTUELocationPage();
            await AndroidTypeTextCommand("input||non-module|ftue-location|||", "Oak Ridge");

            //TODO: Confirm if this will work on Android
            var textFieldLocation = androidDriver.FindElementByAccessibilityId("input||non-module|ftue-location|||").Location;
            var textFieldSize = androidDriver.FindElementByAccessibilityId("input||non-module|ftue-location|||").Size;
            int textFieldSizeWidth = textFieldSize.Width;
            int textFieldSizeHeight = textFieldSize.Height;
            int textFieldYCoord = textFieldLocation.Y;
            int textFieldXCoord = textFieldLocation.X;

            TouchAction action = new TouchAction(androidDriver);
            action.Press ((textFieldXCoord + textFieldSizeWidth) * 0.5, (textFieldYCoord - textFieldSizeHeight) - 10)
            .Wait(500)
            .Release()
            .Perform();

            await AndroidClickFTUENextButton();
            await AndroidClickFTUEGetStartedButton();
        }
    }
}
