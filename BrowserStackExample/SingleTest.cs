using System;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.UI;

namespace BrowserStackMobileAppTests
{
    [TestFixture("single", "galaxy-s6")]
    public class SingleTest : BrowserStackIntegration
    {
        public SingleTest(string profile, string device) : base(profile, device){}

        //[Test]
        //public void searchWikipedia()
        //{
        //    var viewElements = driver.FindElements(By.ClassName("android.widget.FrameLayout"));
        //    Thread.Sleep(TimeSpan.FromSeconds(3));
        //    Assert.IsTrue(viewElements.Any());
            
            ////AndroidElement searchElement = (AndroidElement)new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(MobileBy.AccessibilityId("Weather")));
            ////searchElement.Click();
            ////Thread.Sleep(TimeSpan.FromSeconds(3));
            ////AndroidElement insertTextElement = (AndroidElement)new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(By.Id("org.wikipedia.alpha:id/search_src_text")));
            ////insertTextElement.SendKeys("BrowserStack");
            ////Thread.Sleep(5000);
            ////var exploreRadars =
            ////    (AndroidElement) new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(
            ////        ExpectedConditions.ElementIsVisible(MobileBy.AccessibilityId("Explore Radars")));

            ////Assert.IsNotNull(exploreRadars);
            ////ReadOnlyCollection<AndroidElement> allProductsName = driver.FindElements(By.ClassName("android.widget.TextView"));
            ////Assert.True(allProductsName.Count > 0);
        //}

    }
}
