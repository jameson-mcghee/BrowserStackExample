using System;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;
using System.Linq;
using BrowserStackIntegration;
using System.Threading.Tasks;

namespace MobileAppTests
{
    [TestFixture("single", "galaxy-s9")]
    //[TestFixture("single", "iphone-8")]
    public class SingleTest : GlobalMethods
    {

        public SingleTest(string profile, string device) : base(profile, device) { }

        [Test]
        public void SimpleTestAndroid()
        {
            var viewElements = androidDriver.FindElements(By.Id("android:id/content"));
            Thread.Sleep(TimeSpan.FromSeconds(3));
            Assert.IsTrue(viewElements.Any());
                        
        }
        //[Test]
        public async Task SimpleTestIOS()
        {
            var viewElements = iosDriver.FindElements(By.ClassName("XCUIElementTypeApplication"));
            await ApproveiOSAlerts();
            Thread.Sleep(TimeSpan.FromSeconds(3));
            Assert.IsTrue(viewElements.Any());
        }

    }
}
