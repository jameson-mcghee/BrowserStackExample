using OpenQA.Selenium;
using OpenQA.Selenium.Appium.MultiTouch;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BrowserStackIntegration
{
    public class GlobalMethods : BrowserStackIntegrationImplementation
    {
        public GlobalMethods(string profile, string device) : base(profile, device){}

        //IOS ONLY
        public bool IsiOSElementPresent(By by)
        {
            try
            {
                iosDriver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        //ANDROID ONLY
        public bool IsAndroidElementPresent(By by)
        {
            try
            {
                androidDriver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }


        //BOTH OPERATING SYSTEMS
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
        public void Wait(int waitTime)
        {
            Thread.Sleep(TimeSpan.FromSeconds(waitTime));
        }



    }
}
