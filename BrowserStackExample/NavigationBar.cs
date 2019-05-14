using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.MultiTouch;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace BrowserStackIntegration
{
    public class NavigationBar : GlobalMethods
    {
       public NavigationBar(string profile, string device) : base(profile, device) { }

        //IOS ONLY
        public async Task IOSHomePageNavigationButton()
        {
            for (int i = 0; ; i++)
            {
                if (i >= 2) Assert.Fail("The Home page is not present after navigating to it from the navigation bar. ");
                try
                {
                    if (IsiOSElementPresent("button|0||home||manually placed at bottom of screen|"))
                    {
                        await IOSClickCommand("button|0||home||manually placed at bottom of screen|");
                        break;
                    }
                    else
                    {
                        await ScrollUpOnAndroid();
                    }
                }
                catch (Exception ex)
                {
                    string message = $"The Home page is not present after navigating to it from the navigation bar. {ex}";
                    Debug.WriteLine(message);
                    //Debug.ReadLine();
                    Console.WriteLine(message);
                }
                Wait(1);
            }
        }

        public async Task IOSWeatherPageNavigationButton()
        {
            for (int i = 0; ; i++)
            {
                if (i >= 2) Assert.Fail("The Weather page is not present after navigating to it from the navigation bar. ");
                try
                {
                    if (IsiOSElementPresent("button|0||weather||manually placed at bottom of screen|"))
                    {
                        await IOSClickCommand("button|0||weather||manually placed at bottom of screen|");
                        break;
                    }
                    else
                    {
                        await ScrollUpOnAndroid();
                    }
                }
                catch (Exception ex)
                {
                    string message = $"The Weather page is not present after navigating to it from the navigation bar. {ex}";
                    Debug.WriteLine(message);
                    //Debug.ReadLine();
                    Console.WriteLine(message);
                }
                Wait(1);
            }
        }

        public async Task IOSWatchPageNavigationButton()
        {
            for (int i = 0; ; i++)
            {
                if (i >= 2) Assert.Fail("The Watch page is not present after navigating to it from the navigation bar. ");
                try
                {
                    if (IsiOSElementPresent("button|0||watch||manually placed at bottom of screen|"))
                    {
                        await IOSClickCommand("button|0||watch||manually placed at bottom of screen|");
                        break;
                    }
                    else
                    {
                        await ScrollUpOnAndroid();
                    }
                }
                catch (Exception ex)
                {
                    string message = $"The Watch page is not present after navigating to it from the navigation bar. {ex}";
                    Debug.WriteLine(message);
                    //Debug.ReadLine();
                    Console.WriteLine(message);
                }
                Wait(1);
            }
        }


        //ANDROID ONLY
        public async Task AndroidHomePageNavigationButton()
        {
            for (int i = 0; ; i++)
            {
                if (i >= 2) Assert.Fail("The Home page is not present after navigating to it from the navigation bar. ");
                try
                {
                    if (IsAndroidElementPresent("button|0||home||manually placed at bottom of screen|"))
                    {
                        await AndroidClickCommand("button|0||home||manually placed at bottom of screen|");
                        break;
                    }
                    else
                    {
                        await ScrollUpOnAndroid();
                    }
                }
                catch (Exception ex)
                {
                    string message = $"The Home page is not present after navigating to it from the navigation bar. {ex}";
                    Debug.WriteLine(message);
                    //Debug.ReadLine();
                    Console.WriteLine(message);
                }
                Wait(1);
            }
        }

        public async Task AndroidWeatherPageNavigationButton()
        {
            for (int i = 0; ; i++)
            {
                if (i >= 2) Assert.Fail("The Weather page is not present after navigating to it from the navigation bar. ");
                try
                {
                    if (IsAndroidElementPresent("button|0||weather||manually placed at bottom of screen|"))
                    {
                        await AndroidClickCommand("button|0||weather||manually placed at bottom of screen|");
                        break;
                    }
                    else
                    {
                        await ScrollUpOnAndroid();
                    }
                }
                catch (Exception ex)
                {
                    string message = $"The Weather page is not present after navigating to it from the navigation bar. {ex}";
                    Debug.WriteLine(message);
                    //Debug.ReadLine();
                    Console.WriteLine(message);
                }
                Wait(1);
            }
        }

        public async Task AndroidWatchPageNavigationButton()
        {
            for (int i = 0; ; i++)
            {
                if (i >= 2) Assert.Fail("The Watch page is not present after navigating to it from the navigation bar. ");
                try
                {
                    if (IsAndroidElementPresent("button|0||watch||manually placed at bottom of screen|"))
                    {
                        await AndroidClickCommand("button|0||watch||manually placed at bottom of screen|");
                        break;
                    }
                    else
                    {
                        await ScrollUpOnAndroid();
                    }
                }
                catch (Exception ex)
                {
                    string message = $"The Watch page is not present after navigating to it from the navigation bar. {ex}";
                    Debug.WriteLine(message);
                    //Debug.ReadLine();
                    Console.WriteLine(message);
                }
                Wait(1);
            }
        }
    }
}
