using NUnit.Framework;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using BrowserStackIntegration;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Appium;

namespace MobileAppTests
{
    //[TestFixture("parallel", "pixel")]
    //[TestFixture("parallel", "pixel-2")]
    //[TestFixture("parallel", "pixel-3")]
    //[TestFixture("parallel", "galaxy-s6")]
    //[TestFixture("parallel", "galaxy-s7")]
    //[TestFixture("parallel", "galaxy-s8")]
    [TestFixture("parallel", "galaxy-s9")]
    //[TestFixture("parallel", "galaxy-note8")]
    //[TestFixture("parallel", "galaxy-note9")]
    //[TestFixture("parallel", "galaxy-note4")]
    //[TestFixture("parallel", "nexus-9")] //tablet
    //[TestFixture("parallel", "galaxy-tabs4")] //tablet
    [Parallelizable(ParallelScope.Fixtures)]
    public class WhenOnTheAndroidHomePage : BrowserStackIntegrationImplementation
    {     
        public WhenOnTheAndroidHomePage(string profile, string device) : base(profile, device) { }

        //[Test]
        public async Task TheHomePageIsPresent()
        {

            for (int second = 0; ; second++)
            {
                if (second >= 70) Assert.Fail("The Home page is not present.");
                try
                {
                    var homePageElement = androidDriver.FindElementByAccessibilityId("component-home-pageWrapper-contentList");

                    Assert.IsTrue(homePageElement.Displayed); break;
                }
                catch (Exception ex)
                {
                    string message = $"The Home page is not present. {ex}";
                    Debug.WriteLine(message);
                    //Debug.ReadLine();
                    Console.WriteLine(message);
                }
            }
            
        }

        //[Test]
        public async Task TheHomePageBannerAdIsPresent()
        {
            await TheHomePageIsPresent();
            for (int second = 0; ; second++)
            {
                if (second >= 20) Assert.Fail("The Home Page banner ad is not present.");
                try
                {
                    var homePageBannerAdElement = androidDriver.FindElementByAccessibilityId("non-module|-3|ad|advertisementModule|0|manually placed in page-wrapper|");

                    Assert.IsTrue(homePageBannerAdElement.Displayed); break;
                }
                catch (Exception ex)
                {
                    string message = $"The Home Page banner ad is not present. {ex}";
                    Debug.WriteLine(message);
                    //Debug.ReadLine();
                    Console.WriteLine(message);
                }
            }
        }

        //Delete this test after comfirming it works
        [Test]
        public async Task HomePageAdsArePresent()
        {
            await TheHomePageIsPresent();

            for (int second = 0; ; second++)
            {

                if (second >= 30) Assert.Fail("The Home Page ads are not present.");
                try
                {
                    IList<IWebElement> homePageAdElements = webDriver.FindElements(By.Name("module|3|advertisementModule|ad|||"));
                    //IReadOnlyCollection <AppiumWebElement> homePageAdElements = androidDriver.FindElementsByAccessibilityId("module|3|advertisementModule|ad|||");
                    ((IJavaScriptExecutor)androidDriver).ExecuteScript("arguments[0].scrollIntoView();", homePageAdElements);
                    Assert.IsTrue(homePageAdElements.Any());
                    break;
                }
                catch (Exception ex)
                {
                    string message = $"The Home Page ads are not present. {ex}";
                    Debug.WriteLine(message);
                    //Debug.ReadLine();
                    Console.WriteLine(message);
                }
            }


        }

        //[Test]
        public async Task TheHomePageAdsArePresent()
        {
            await TheHomePageIsPresent();
            try
            {
                var homePageAdElements = androidDriver.FindElementsByAccessibilityId("module|3|advertisementModule|ad|||");

                Assert.IsTrue(homePageAdElements.Any());
            }
            catch (Exception ex)
            {
                string message = $"The Home Page ads are not present. {ex}";
                Debug.WriteLine(message);
                //Debug.ReadLine();
                Console.WriteLine(message);
            }

            var homePageAdElementsConfirmed = androidDriver.FindElementsByAccessibilityId("module|3|advertisementModule|ad|||");
            dynamic screenConfig = null; //do your getScreenConfig call to the API

            Assert.IsTrue(screenConfig?.metadata?.count != null);

            int screenConfigCount = int.Parse(screenConfig?.metadata?.count?.ToString());
            Assert.IsTrue(screenConfigCount == homePageAdElementsConfirmed.Count);
            
        }

    }
}
