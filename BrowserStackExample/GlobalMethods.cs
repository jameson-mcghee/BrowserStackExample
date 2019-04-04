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


        //BOTH OPERATING SYSTEMS

        //Gestures
        public void ScrollDown()
        {
            int screenHeight = androidDriver.Manage().Window.Size.Height;
            int screenWidth = androidDriver.Manage().Window.Size.Width;

            TouchAction action = new TouchAction(androidDriver);
            action.Press(screenWidth * 0.5, screenHeight * 0.5)
            .Wait(1000)
            .MoveTo(screenHeight * 0.1, screenWidth * 0.1)
            .Release()
            .Perform();
        }
        public void ScrollUp()
        {
            int screenHeight = androidDriver.Manage().Window.Size.Height;
            int screenWidth = androidDriver.Manage().Window.Size.Width;

            TouchAction action = new TouchAction(androidDriver);
            action.Press(screenWidth * 0.2, screenHeight * 0.2)
            .Wait(1000)
            .MoveTo(screenHeight * 0.6, screenWidth * 0.6)
            .Release()
            .Perform();
        }
        public void SwipeLeft()
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
        public void SwipeRight()
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
