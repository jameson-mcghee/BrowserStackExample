using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;
using System.Collections.Generic;


namespace BrowserStackMobileAppTests
{
    [TestFixture("parallel", "pixel")]
    [TestFixture("parallel", "pixel-2")]
    [TestFixture("parallel", "pixel-3")]
    [TestFixture("parallel", "galaxy-s6")]
    [TestFixture("parallel", "galaxy-s7")]
    [TestFixture("parallel", "galaxy-s8")]
    [TestFixture("parallel", "galaxy-s9")]
    [TestFixture("parallel", "galaxy-note8")]
    [TestFixture("parallel", "galaxy-note9")]
    [TestFixture("parallel", "galaxy-note4")]
    [TestFixture("parallel", "nexus-9")]
    [TestFixture("parallel", "galaxy-tabs4")]
    [Parallelizable(ParallelScope.Fixtures)]
    public class WhenLaunchingTheAppOnAndroid : BrowserStackIntegration
    {
        public WhenLaunchingTheAppOnAndroid(string profile, string device) : base(profile, device){}

        [Test]
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task TheUserCanAccessTheHomePage()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            var homeElement = androidDriver.FindElements(By.ClassName("android.widget.FrameLayout"));
            Thread.Sleep(TimeSpan.FromSeconds(3));
            Assert.IsTrue(homeElement.Any());
            //var tryme = androidDriver.FindElement(By.CssSelector("android.widget.TextView"));
            ////((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", tryme);

            ////List<IWebElement> anarrayorlist = driver.FindElements(By.CssSelector("android.view.ViewGroup > android.widget.TextView"));
            ////int numberinlist = anarrayorlist.Count;

            ////// Get specific number item
            ////string itemno = anarrayorlist[2].Text;


            //var adElement = androidDriver.FindElements(By.Id("aw0"));
            //Assert.IsTrue(adElement.Any());
        }

    }
}
