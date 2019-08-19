using NUnit.Framework;
using BrowserStackIntegration;
using System.Threading.Tasks;
using System;
using System.Diagnostics;

namespace MobileAppTests
{
    [TestFixture("parallel", "iphone-7")]
    [TestFixture("parallel", "iphone-8")]
    [TestFixture("parallel", "iphone-8-plus")]
    [TestFixture("parallel", "iphone-se")]
    [TestFixture("parallel", "iphone-xs")]
    [TestFixture("parallel", "iphone-xsmax")]
    [TestFixture("parallel", "ipad-pro")] //Tablet
    [TestFixture("parallel", "ipad-5th")] //Tablet
    [Parallelizable(ParallelScope.Fixtures)]
    public class IOSWhenOpeningAnArticlePage : ArticlePage
    {
        public IOSWhenOpeningAnArticlePage(string profile, string device) : base(profile, device) { }

        //[Test]
        public async Task TheArticlePageIsPresent()
        {
            await IOSHomePageIsPresent();
            if (IsiOSElementPresent("module|first"))
            {
                await IOSClickCommand("module|first");
            }
            else
            {
                Assert.Fail("The element for the first article on the Home Page cannot be found.");
            }

            for (int i = 0; ; i++)
            {
                if (i >= 10) Assert.Fail("The Article Page is not present.");
                try
                {
                    if (IsiOSElementPresent("page||article-page-wrapper||||"))
                    {
                        break;
                    }
                }
                catch (Exception ex)
                {
                    string message = $"The Article Page is not present. {ex}";
                    Debug.WriteLine(message);

                    Console.WriteLine(message);
                }
                await Wait(1);
            }
        }

        //[Test]
        public async Task TheArticlePageBannerAdIsPresent()
        {
            await IOSArticlePageIsPresent();
            for (int i = 0; ; i++)
            {
                if (i >= 10) Assert.Fail("The Article Page banner ad is not present.");
                try
                {
                    if (IsiOSElementPresent("ad|-3|non-module|advertisementModule|0|manually placed in page-wrapper|"))
                        break;
                }
                catch (Exception ex)
                {
                    string message = $"The Article Page banner ad is not present. {ex}";
                    Debug.WriteLine(message);

                    Console.WriteLine(message);
                }
                await Wait(1);
            }
        }

        //[Test]
        public async Task ConfirmAdModulesArePresentAndCount()
        {
            await IOSArticlePageIsPresent();

            int adModuleCount = 0;

            for (int i = 0; ; i++)
            {
                if (i >= 120) Assert.Fail("Could not find the last element on the Watch Page prior to time out.");
                try
                {
                    await ScrollDownOnAndroid();

                    if (IsiOSElementPresent("module|advertisement"))
                    {
                        adModuleCount++;
                    }
                    if (IsiOSElementPresent("module|last"))
                    {
                        break;
                    }
                }
                catch (Exception ex)
                {
                    string message = $"Could not find the last element on the Watch Page. {ex}";
                    Debug.WriteLine(message);

                    Console.WriteLine(message);
                }
                await Wait(1);
            }

            Console.Write("Number of ad modules on the Watch Page: " + adModuleCount);
        }

        //TODO: Article Page: Compare the screenConfig modules from the IOSArticlePageScreenConfigRequest() method to those on the Article Page

    }
}
