using NUnit.Framework;
using BrowserStackIntegration;
using System.Threading.Tasks;

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
    //[TestFixture("parallel", "nexus-9")] //tablet
    //[TestFixture("parallel", "galaxy-tabs4")] //tablet
    [Parallelizable(ParallelScope.Fixtures)]
    public class WhenOnTheAndroidHomePage : HomePage
    {     
        public WhenOnTheAndroidHomePage(string profile, string device) : base(profile, device) { }

        [Test]
        public async Task TheHomePageIsPresent()
        {
            await HomePageIsPresent();
            Assert.IsTrue(androidDriver.FindElementByAccessibilityId("component-home-pageWrapper-contentList").Displayed);
        }

        [Test]
        public async Task TheHomePageBannerAdIsPresent()
        {
            await HomePageBannerAdIsPresent();
            Assert.IsTrue(androidDriver.FindElementByAccessibilityId
                ("non-module|-3|ad|advertisementModule|0|manually placed in page-wrapper|").Displayed);
        }

        //[Test]
        public async Task TheModuleHomePageAdsArePresent()
        {
            await ModuleHomePageAdsArePresent();
        }

    }
}
