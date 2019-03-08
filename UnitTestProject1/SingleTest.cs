using System;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;
using System.Linq;
using BrowserStackIntegration;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.UI;

namespace MobileAppTests
{
    //[TestFixture("single", "galaxy-s6")]
    [TestFixture("single", "iphone-8")]
    public class SingleTest : BrowserStackIntegrationImplementation
    {
        ////Android
        //public SingleTest(string profile, string device) : base(profile, device) { }
        //iOS
        public SingleTest(string profile, string device) : base(profile, device) { }

        [Test]
        public void SimpleTest()
        {

            ////Android
            //var viewElements = driver.FindElements(By.Id("android:id/content"));
            //Thread.Sleep(TimeSpan.FromSeconds(3));
            //Assert.IsTrue(viewElements.Any());

            //iOS
            var viewElements = iosDriver.FindElements(By.ClassName("XCUIElementTypeApplication"));
            Thread.Sleep(TimeSpan.FromSeconds(3));
            Assert.IsTrue(viewElements.Any());

            //AndroidElement searchElement = (AndroidElement)new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(MobileBy.AccessibilityId("Weather")));
            //searchElement.Click();
            //Thread.Sleep(TimeSpan.FromSeconds(3));
            //AndroidElement insertTextElement = (AndroidElement)new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(By.Id("org.wikipedia.alpha:id/search_src_text")));
            //insertTextElement.SendKeys("BrowserStack");
            //Thread.Sleep(5000);
            //var exploreRadars =
            //    (AndroidElement)new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(
            //        ExpectedConditions.ElementIsVisible(MobileBy.AccessibilityId("Explore Radars")));

            //Assert.IsNotNull(exploreRadars);
            //ReadOnlyCollection<AndroidElement> allProductsName = driver.FindElements(By.ClassName("android.widget.TextView"));
            //Assert.True(allProductsName.Count > 0);
        }

    }
}
