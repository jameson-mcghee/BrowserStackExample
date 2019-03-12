using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BrowserStackIntegration;

namespace MobileAppTests
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
    public class WhenOnTheAndroidHomePage : BrowserStackIntegrationImplementation
    {
        public WhenOnTheAndroidHomePage(string profile, string device) : base(profile, device) { }

        //[Test]
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task TheUserCanAccessTheHomePage()
#pragma warning restore CS1998
        {
            var mainClassElement = androidDriver.FindElements(By.ClassName("android.widget.FrameLayout"));
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
