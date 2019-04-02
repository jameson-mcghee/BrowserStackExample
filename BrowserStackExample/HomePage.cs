using System;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Diagnostics;
using OpenQA.Selenium.Appium.Android;
using System.Collections.ObjectModel;

namespace BrowserStackIntegration
{
    public class HomePage : GlobalMethods
    {
        public HomePage(string profile, string device) : base(profile, device){}

        //ANDROID
        public async Task HomePageIsPresent()
        {

            for (int i = 0;  ; i++)
            {
                if (i >= 45) Assert.Fail("The Home page is not present.");
                try
                {
                    var homePageElement = androidDriver.FindElementByAccessibilityId("component-home-pageWrapper-contentList");
                    break;
                }
                catch (Exception ex)
                {
                    string message = $"The Home page is not present. {ex}";
                    Debug.WriteLine(message);
                    //Debug.ReadLine();
                    Console.WriteLine(message);
                }
                Wait(1);
            }
        }

        public async Task HomePageBannerAdIsPresent()
        {
            await HomePageIsPresent();
            for (int i = 0; ; i++)
            {
                if (i >= 20) Assert.Fail("The Home Page banner ad is not present.");
                try
                {
                    var homePageBannerAdElement = androidDriver.FindElementByAccessibilityId("non-module|-3|ad|advertisementModule|0|manually placed in page-wrapper|");
                    break;
                }
                catch (Exception ex)
                {
                    string message = $"The Home Page banner ad is not present. {ex}";
                    Debug.WriteLine(message);
                    //Debug.ReadLine();
                    Console.WriteLine(message);
                }
                Wait(1);
            }
        }

        public async Task ModuleHomePageAdsArePresent()
        {
            await HomePageIsPresent();

            dynamic screenConfig = null; //do your getScreenConfig call to the API

            Assert.IsTrue(screenConfig?.metadata?.count != null);
            int screenConfigCount = int.Parse(screenConfig?.metadata?.count?.ToString());

            for (int i = 0; ; i++)
            {
                ScrollDown();

                if (i >= 120) Assert.Fail("The Home Page module ads are not present.");
                try
                {
                    ReadOnlyCollection<AndroidElement> adlistHomePage = androidDriver.FindElementsByAccessibilityId("module|3|advertisementModule|ad|||");
                    int adList = adlistHomePage.Count();

                    var bottomPageElement = androidDriver.FindElementByAccessibilityId("");
                    Assert.IsTrue(bottomPageElement.Displayed);
                    Assert.IsTrue(screenConfigCount == adList);
                    break;
                }
                catch (Exception ex)
                {
                    string message = $"The Home Page module ads are not present. {ex}";
                    Debug.WriteLine(message);
                    //Debug.ReadLine();
                    Console.WriteLine(message);
                }
                Wait(1);
            }
        }



        //IOS



    }
}
