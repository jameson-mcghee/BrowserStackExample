using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace BrowserStackIntegration
{
    public class DayPartingScreen : GoogleAnalytics
    {
        public DayPartingScreen(string profile, string device) : base(profile, device){}

        //ANDROID
        public async Task AndroidUserCanAccessTheDayPartingScreen()
        {
            for (int i = 0; ; i++)
            {
                if (i >= 15) Assert.Fail("Intro Banner is not being displayed.");
                    try
                    {
                        var dayPartingScreenElement = androidDriver.FindElementByAccessibilityId("non-module|-4|ad|advertisementModule|0|manually placed in splash-screen|");
                        return;
                    }
                    catch (Exception ex)
                    {
                        string message = $"Splashscreen is not being displayed. {ex}";
                        Debug.WriteLine(message);
                        //Debug.ReadLine();
                        Console.WriteLine(message);
                    }
                Wait(1);
            }
        }
        public async Task AndroidDayPartingBannerIsGenerated()
        {
            await AndroidUserCanAccessTheDayPartingScreen();
            for (int i = 0; ; i++)
            {
                if (i >= 15) Assert.Fail("Day Parting Banner and/or 'Sponsored by' messages are not being displayed.");
                try
                {
                    var dayPartingBannerElement = androidDriver.FindElementByAccessibilityId("non-module|-4|ad|advertisementModule|0|manually placed in splash-screen|");
                    var sponsoredByElement = androidDriver.FindElementByAccessibilityId("non-module|-4|ad|advertisementModule|0|manually placed in splash-screen|");
                    return;
                }
                catch (Exception ex)
                {
                        string message = $"Day Parting Banner and/or 'Sponsored by' messages are not being displayed. {ex}";
                        Debug.WriteLine(message);
                        //Debug.ReadLine();
                        Console.WriteLine(message);
                }
                Wait(1);
            }
        }
        public async Task AndroidDayPartingScreenAdIsPresent()
        {
            //await AndroidUserCanAccessTheDayPartingScreen();
            for (int i = 0; ; i++)
            {
                if (i >= 25) Assert.Fail("The Day Parting Screen Ad is not present.");
                try
                {
                    var dayPartingAdElement = androidDriver.FindElementByAccessibilityId("non-module|-4|ad|advertisementModule|0|manually placed in splash-screen|");
                    return;
                }
                catch (Exception ex)
                {
                    string message = $"The Day Parting Screen Ad is not present. {ex}";
                    Debug.WriteLine(message);
                    //Debug.ReadLine();
                    Console.WriteLine(message);
                }
                Wait(1);
            }
        }



        //IOS
        public async Task IOSUserCanAccessTheDayPartingScreen()
        {
            await ApproveiOSAlerts();

            for (int i = 0; ; i++)
            {
                if (i >= 15) Assert.Fail("Intro Banner is not being displayed.");
                try
                {
                    var dayPartingScreenElement = iosDriver.FindElementByName("Good Morning Sponsored By non-module|-4|ad|advertisementModule|0|manually placed in splash-screen|");
                    return;
                }
                catch (Exception ex)
                {
                    string message = $"Splashscreen is not being displayed. {ex}";
                    Debug.WriteLine(message);
                    //Debug.ReadLine();
                    Console.WriteLine(message);
                }
                Wait(1);
            }
        }
        public async Task IOSDayPartingBannerIsGenerated()
        {
            await ApproveiOSAlerts();
            //await IOSUserCanAccessTheDayPartingScreen();
            for (int i = 0; ; i++)
            {
                if (i >= 15) Assert.Fail("Day Parting Banner and/or 'Sponsored by' messages are not being displayed.");
                try
                {
                    var dayPartingBannerElement = iosDriver.FindElementByName("Good Morning Sponsored By non-module|-4|ad|advertisementModule|0|manually placed in splash-screen|");
                    var sponsoredByElement = iosDriver.FindElementByName("Sponsored By non-module|-4|ad|advertisementModule|0|manually placed in splash-screen|");
                    return;
                }
                catch (Exception ex)
                {
                    string message = $"Day Parting Banner and/or 'Sponsored by' messages are not being displayed. {ex}";
                    Debug.WriteLine(message);
                    //Debug.ReadLine();
                    Console.WriteLine(message);
                }
                Wait(1);
            }
        }
        public async Task IOSDayPartingScreenAdIsPresent()
        {
            await ApproveiOSAlerts();
            //await IOSUserCanAccessTheDayPartingScreen();
            for (int i = 0; ; i++)
            {
                if (i >= 15) Assert.Fail("The Day Parting Screen Ad is not present.");
                try
                {
                    var dayPartingAdElement = iosDriver.FindElementByName("non-module|-4|ad|advertisementModule|0|manually placed in splash-screen|");
                    return;
                }
                catch (Exception ex)
                {
                    string message = $"The Day Parting Screen Ad is not present. {ex}";
                    Debug.WriteLine(message);
                    //Debug.ReadLine();
                    Console.WriteLine(message);
                }
                Wait(1);
            }
        }

    }
}
