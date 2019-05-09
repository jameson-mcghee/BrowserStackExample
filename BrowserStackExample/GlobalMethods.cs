using OpenQA.Selenium;
using OpenQA.Selenium.Appium.MultiTouch;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BrowserStackIntegration
{
    public class GlobalMethods : GoogleAnalytics
    {
        public GlobalMethods(string profile, string device) : base(profile, device){}

        //IOS ONLY
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

        //Gestures
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

            TouchAction action = new TouchAction(iosDriver);
            action.Press(screenWidth * 0.8, screenHeight * 0.5)
            .Wait(1000)
            .MoveTo(screenWidth * 0.2, screenHeight * 0.5)
            .Release()
            .Perform();
            Wait(1);
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
            Wait(1);
        }


        //ANDROID ONLY
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

        //Gestures
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

            TouchAction action = new TouchAction(androidDriver);
            action.Press(screenWidth * 0.8, screenHeight * 0.5)
            .Wait(1000)
            .MoveTo(screenWidth * 0.2, screenHeight * 0.5)
            .Release()
            .Perform();
            Wait(1);
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
            Wait(1);
        }

        //In-Test Commands
        public void Wait(int waitTime)
        {
            Thread.Sleep(TimeSpan.FromSeconds(waitTime));
        }



    }
}
