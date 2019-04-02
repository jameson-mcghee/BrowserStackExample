using NUnit.Framework;
using BrowserStackIntegration;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using System.Net.Http;


namespace MobileAppTests
{
    [TestFixture("parallel", "pixel")]
    [TestFixture("parallel", "pixel-2")]
    [TestFixture("parallel", "pixel-3")]
    [TestFixture("parallel", "galaxy-s7")]
    [TestFixture("parallel", "galaxy-s8")]
    [TestFixture("parallel", "galaxy-s9")]
    [TestFixture("parallel", "galaxy-note8")]
    [TestFixture("parallel", "galaxy-note9")]
    [TestFixture("parallel", "galaxy-note4")]
    //[TestFixture("parallel", "galaxy-s6")] //App or one of the otherApps cannot be run on version 5.0.
    //[TestFixture("parallel", "nexus-9")] //tablet
    //[TestFixture("parallel", "galaxy-tabs4")] //tablet
    [Parallelizable(ParallelScope.Fixtures)]
    public class WhenOnTheAndroidHomePage : HomePage
    {     
        public WhenOnTheAndroidHomePage(string profile, string device) : base(profile, device) { }

        const string URL1 = "GAURL1";
        const string URL2 = "GAURL2";
        const string URL3 = "GAURL3";
        const string URL4 = "GAURL4";

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
        //[Test]
        public async Task TheGoogleAnalyticsCallsAreCorrect()
        {
            await HomePageIsPresent();
            await GetNetworkLogs();
            //Figure out how to pass the network logs from the GetNetworkLogs() method into this method
            //Stub out the comparison of the network logs to URL1-4
            //var doesUrlExist = failingUrl.Contains(URL1);
            //doesUrlExist.Should().BeTrue();
        }

    }
}
