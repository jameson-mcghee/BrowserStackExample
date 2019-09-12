using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.MultiTouch;
using System;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace BrowserStackIntegration
{
    public class GlobalMethods : BrowserStackIntegrationImplementation
    {
        public GlobalMethods(string profile, string device) : base(profile, device){}

        #region iOS COMMANDS
        
        public bool IsiOSElementPresent(string by)
        {
            try
            {
                iosDriver.FindElementByName(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        public async Task IOSClickCommand(string by)
        {
            iosDriver.FindElementByName(by).Click();
            return;
        }
        public async Task IOSTypeTextCommand(string by, string text)
        {
            iosDriver.FindElementByName(by).Clear();
            iosDriver.FindElementByName(by).SendKeys(text);
            return;
        }
        public async Task IOSAssertText(string by, string text, string message)
        {
            var elementText = iosDriver.FindElementByName(by).Text;
            if (text == elementText)
            {
                return;
            }
            else
            {
                Assert.Fail(message);
            }
        }
        public async Task ApproveiOSAlerts()
        {
            try
            {
                while (true)
                    iosDriver.SwitchTo().Alert().Accept();
            }
            catch (Exception e)
            {
                //no more alerts
            }
        }
        public async Task IOSCaptureScreenShotForStore(string device)
        {
            
            string userName = Environment.UserName;
            string fullStationVersion = File.ReadAllText($@"C:\Users\{userName}\Documents\Apple StationID.txt");
            string stationVersion = fullStationVersion.Remove(0, 14);
            string screenShotDirectory = $"//ETM-DRFS03/Shares/ScreenShots/{stationVersion}/Apple/{device}/";
            Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;

            Directory.CreateDirectory(screenShotDirectory);
            try
            {
                Screenshot image = ((ITakesScreenshot)iosDriver).GetScreenshot();
                image.SaveAsFile($@"//ETM-DRFS03/Shares/ScreenShots/{stationVersion}/Apple/{device}/Screenshot {unixTimestamp}.png", ImageFormat.Png);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Assert.Fail($"Screenshot creation failed with Exception: {ex}");
            }
        }
        public async Task IOSCloseApp()
        {
            iosDriver.CloseApp();
            return;
        }
        public async Task IOSLaunchApp()
        {
            iosDriver.LaunchApp();
            return;
        }


        #endregion

        #region iOS GESTURE COMMANDS

        public async Task ScrollDownOnIOS()
        {
            int screenHeight = iosDriver.Manage().Window.Size.Height;
            int screenWidth = iosDriver.Manage().Window.Size.Width;

            TouchAction action = new TouchAction(iosDriver);
            action.Press(screenWidth * 0.5, screenHeight * 0.8)
            .Wait(1000)
            .MoveTo(screenWidth * 0.5, screenHeight * 0.1)
            .Release()
            .Perform();
        }
        public async Task ScrollUpOnIOS()
        {
            int screenHeight = iosDriver.Manage().Window.Size.Height;
            int screenWidth = iosDriver.Manage().Window.Size.Width;

            TouchAction action = new TouchAction(iosDriver);
            action.Press(screenWidth * 0.5, screenHeight * 0.2)
            .Wait(1000)
            .MoveTo(screenWidth * 0.5, screenHeight * 0.8)
            .Release()
            .Perform();
        }
        public async Task SwipeRightToLeftOnIOS()
        {
            int screenHeight = iosDriver.Manage().Window.Size.Height;
            int screenWidth = iosDriver.Manage().Window.Size.Width;
            Console.WriteLine(screenHeight);
            Console.WriteLine(screenWidth);

            TouchAction action = new TouchAction(iosDriver);
            action.Press(screenWidth * 0.99, screenHeight * 0.2)
            .Wait(1000)
            .MoveTo(screenWidth * 0.01, screenHeight * 0.2)
            .Release()
            .Perform();
            await Wait(1);
        }
        public async Task SwipeLeftToRightOnIOS()
        {
            int screenHeight = iosDriver.Manage().Window.Size.Height;
            int screenWidth = iosDriver.Manage().Window.Size.Width;

            TouchAction action = new TouchAction(iosDriver);
            action.Press(screenWidth * 0.2, screenHeight * 0.5)
            .Wait(1000)
            .MoveTo(screenWidth * 0.8, screenHeight * 0.5)
            .Release()
            .Perform();
            await Wait(1);
        }
        public async Task OpenIOSNotificationPane()
        {
            int screenHeight = iosDriver.Manage().Window.Size.Height;
            int screenWidth = iosDriver.Manage().Window.Size.Width;

            TouchAction action = new TouchAction(iosDriver);
            action.Press(screenWidth * 0.5, screenHeight * 0.01)
            .Wait(1000)
            .MoveTo(screenWidth * 0.5, screenHeight * 0.65)
            .Release()
            .Perform();
            await Wait(1);
            return;
        }

        #endregion
        
        #region ANDROID COMMANDS

        public bool IsAndroidElementPresent(string by)
        {
            try
            {
                androidDriver.FindElementByAccessibilityId(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        public async Task AndroidClickCommand(string by)
        {
            androidDriver.FindElementByAccessibilityId(by).Click();
            return;
        }
        public async Task AndroidBackButton()
        {
            androidDriver.PressKeyCode(AndroidKeyCode.Back);
            return;
        }
        public async Task AndroidTypeTextCommand(string by, string text)
        {
            androidDriver.FindElementByAccessibilityId(by).Clear();
            androidDriver.FindElementByAccessibilityId(by).SendKeys(text);
            return;
        }
        public async Task AndroidAssertText(string by, string text, string message)
        {
            var elementText = androidDriver.FindElementByAccessibilityId(by).Text;
            if (text == elementText)
            {
                return;
            }
            else
            {
                Assert.Fail(message);
            }
        }
        public async Task ApproveAndroidAlerts()
        {
            try
            {
                while (true)
                    androidDriver.SwitchTo().Alert().Accept();
            }
            catch (Exception e)
            {
                //no more alerts
            }
        }
        public async Task AndroidCaptureScreenShotForStore(string device)
        {
            string userName = Environment.UserName;
            string fullStationVersion = File.ReadAllText($@"C:\Users\{userName}\Documents\Android StationID.txt");
            string stationVersion = fullStationVersion.Remove(0, 14);
            string screenShotDirectory = $@"//ETM-DRFS03/Shares/ScreenShots/{stationVersion}/Android/{device}/";
            Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;

            Directory.CreateDirectory(screenShotDirectory);
            try
            {
               Screenshot image = ((ITakesScreenshot)androidDriver).GetScreenshot();
               image.SaveAsFile($@"//ETM-DRFS03/Shares/ScreenShots/{stationVersion}/Android/{device}/Screenshot {unixTimestamp}.png", ImageFormat.Png);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Assert.Fail($"Screenshot creation failed with Exception:{Environment.NewLine}{ex}");
            }
        }
        public async Task AndroidCloseApp()
        {
            androidDriver.CloseApp();
            return;
        }
        public async Task AndroidLaunchApp()
        {
            androidDriver.LaunchApp();
            return;
        }

        #endregion

        #region ANDROID GESTURE COMMANDS

        public async Task ScrollDownOnAndroid()
        {
            int screenHeight = androidDriver.Manage().Window.Size.Height;
            int screenWidth = androidDriver.Manage().Window.Size.Width;

            TouchAction action = new TouchAction(androidDriver);
            action.Press(screenWidth * 0.5, screenHeight * 0.75)
            .Wait(1000)
            .MoveTo(screenWidth * 0.5, screenHeight * 0.1)
            .Release()
            .Perform();
        }
        public async Task ScrollUpOnAndroid()
        {
            int screenHeight = androidDriver.Manage().Window.Size.Height;
            int screenWidth = androidDriver.Manage().Window.Size.Width;

            TouchAction action = new TouchAction(androidDriver);
            action.Press(screenWidth * 0.5, screenHeight * 0.2)
            .Wait(1000)
            .MoveTo(screenWidth * 0.5, screenHeight * 0.85)
            .Release()
            .Perform();
        }
        public async Task SwipeRightToLeftOnAndroid()
        {
            int screenHeight = androidDriver.Manage().Window.Size.Height;
            int screenWidth = androidDriver.Manage().Window.Size.Width;
            Console.WriteLine(screenHeight);
            Console.WriteLine(screenWidth);

            TouchAction action = new TouchAction(androidDriver);
            action.Press(screenWidth * 0.99, screenHeight * 0.2)
            .Wait(1000)
            .MoveTo(screenWidth * 0.01, screenHeight * 0.2)
            .Release()
            .Perform();
            await Wait(1);
        }
        public async Task SwipeLeftToRightOnAndroid()
        {
            int screenHeight = androidDriver.Manage().Window.Size.Height;
            int screenWidth = androidDriver.Manage().Window.Size.Width;

            TouchAction action = new TouchAction(androidDriver);
            action.Press(screenWidth * 0.2, screenHeight * 0.5)
            .Wait(1000)
            .MoveTo(screenWidth * 0.8, screenHeight * 0.5)
            .Release()
            .Perform();
            await Wait(1);
        }
        public async Task OpenAndroidNotificationPane()
        {
            androidDriver.OpenNotifications();
            return;
        }

        #endregion
        
        #region UNIVERSAL COMMANDS

        public async Task Wait(int waitTime)
        {
            Thread.Sleep(TimeSpan.FromSeconds(waitTime));
        }

        #endregion 
    }
}
