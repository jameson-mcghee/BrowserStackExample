using NUnit.Framework;
using BrowserStackIntegration;
using System.Threading.Tasks;
using System;
using System.Diagnostics;

namespace MobileAppTests
{
    [TestFixture("parallel", "iphone-7")]
    [TestFixture("parallel", "iphone-8")]
    [TestFixture("parallel", "iphone-8-plus")]
    [TestFixture("parallel", "iphone-se")]
    [TestFixture("parallel", "iphone-xs")]
    [TestFixture("parallel", "iphone-xsmax")]
    [TestFixture("parallel", "ipad-pro")] //Tablet
    [TestFixture("parallel", "ipad-5th")] //Tablet
    [Parallelizable(ParallelScope.Fixtures)]
    public class IOSWhenOnTheHomePage : HomePage
    {
        public IOSWhenOnTheHomePage(string profile, string device) : base(profile, device) { }


        //[Test]
        public async Task TheHomePageIsPresent()
        {
            for (int i = 0; ; i++)
            {
                if (i >= 20) Assert.Fail("The Home page is not present.");
                try
                {
                    if (IsiOSElementPresent("page||home-wrapper||||"))
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

        //[Test]
        public async Task TheHomePageBannerAdIsPresent()
        {
            await IOSHomePageIsPresent();
            for (int i = 0; ; i++)
            {
                await ApproveiOSAlerts();
                if (i >= 10) Assert.Fail("The Home Page banner ad is not present.");
                try
                {
                    if (IsiOSElementPresent("ad|-3|non-module|advertisementModule|0|manually placed in page-wrapper|"))
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

        //[Test]
        public async Task ConfirmAdModulesArePresentAndCount()
        {
            await IOSHomePageIsPresent();

            int adModuleCount = 0;

            for (int i = 0; ; i++)
            {
                if (i >= 260) Assert.Fail("Could not find the last element on the Home Page prior to time out.");
                try
                {
                    await ScrollDownOnIOS();

                    if (IsiOSElementPresent("module|advertisement"))
                    {
                        adModuleCount++;
                    }
                    if (IsiOSElementPresent("module|last"))
                    {
                        break;
                    }
                }
                catch (Exception ex)
                {
                    string message = $"Could not find the last element on the Home Page. {ex}";
                    Debug.WriteLine(message);
                    //Debug.ReadLine();
                    Console.WriteLine(message);
                }
                Wait(1);
            }

            Console.Write("Number of ad modules on the Home Page: " + adModuleCount);
        }

        //TODO: Home Page: Compare the screenConfig modules from the HomePageScreenConfigRequest() method to those on the Home Page

    }
}
