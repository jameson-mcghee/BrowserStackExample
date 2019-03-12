using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BrowserStackIntegration;
using OpenQA.Selenium.Remote;
using System.Collections.Generic;

namespace MobileAppTests
{
    //[TestFixture("parallel", "iphone-7")] //Device is running iOS v10
    //[TestFixture("parallel", "iphone-7-plus")] //Device is running iOS v10
    [TestFixture("parallel", "iphone-8")]
    [TestFixture("parallel", "iphone-8-plus")]
    [TestFixture("parallel", "iphone-se")]
    [TestFixture("parallel", "iphone-xs")]
    [TestFixture("parallel", "ipad-pro")]
    [TestFixture("parallel", "ipad-5th")]
    [Parallelizable(ParallelScope.Fixtures)]
    public class WhenLaunchingTheAppOniOS : BrowserStackIntegrationImplementation
    {
        public WhenLaunchingTheAppOniOS(string profile, string device) : base(profile, device) { }

        [Test]
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task TheUserCanAccessTheHomePage()
#pragma warning restore CS1998
        {
            var mainClassElement = iosDriver.FindElements(By.ClassName("XCUIElementTypeApplication"));
            for (int second = 0; ; second++)
            {
                if (second >= 15) Assert.Fail("timeout");
                try
                {
                    Assert.IsTrue(mainClassElement.Any()); break;
                }
                catch (Exception)
                {
                }
                Thread.Sleep(TimeSpan.FromSeconds(3));
            }
        }


    }
}
