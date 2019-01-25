using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Linq;
using System.Threading;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;

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
    [Parallelizable(ParallelScope.Fixtures)]
    public class WhenLaunchingTheApp : BrowserStackIntegration
    {
        public WhenLaunchingTheApp(string profile, string device) : base(profile, device){}

        [Test]
        public void TheUserCanAccessTheHomePage()
        {
            var viewElements = driver.FindElements(By.ClassName("android.widget.FrameLayout"));
            Thread.Sleep(TimeSpan.FromSeconds(3));
            Assert.IsTrue(viewElements.Any());
        }

    }
}
