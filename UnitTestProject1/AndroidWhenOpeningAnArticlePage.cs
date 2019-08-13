using NUnit.Framework;
using BrowserStackIntegration;
using System.Threading.Tasks;
using System;
using System.Diagnostics;

namespace ArticlePageTests
{
    [TestFixture("parallel", "pixel")]
    [TestFixture("parallel", "pixel-2")]
    [TestFixture("parallel", "pixel-3")]
    //[TestFixture("parallel", "nexus-9")]
    [TestFixture("parallel", "galaxy-s8")]
    [TestFixture("parallel", "galaxy-s9")]
    [TestFixture("parallel", "galaxy-note8")]
    [TestFixture("parallel", "galaxy-note9")]
    //[TestFixture("parallel", "galaxy-tabs3")] //tablet
    [TestFixture("parallel", "galaxy-tabs4")] //tablet
    [TestFixture("parallel", "galaxy-tabs5e")] //tablet
    [Parallelizable(ParallelScope.Fixtures)]
    public class AndroidWhenOpeningAnArticlePage : ArticlePage
    {
        public AndroidWhenOpeningAnArticlePage(string profile, string device) : base(profile, device) { }

        [Test]
        public async Task TheArticlePageIsPresent()
        {
            await AndroidHomePageIsPresent();
            if(IsAndroidElementPresent("module|first"))
            {
                await AndroidClickCommand("module|first");
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
                    if (IsAndroidElementPresent("page||article-page-wrapper||||"))
                    {
                        break;
                    }
                }
                catch (Exception ex)
                {
                    string message = $"The Article Page is not present. {ex}";
                    Debug.WriteLine(message);
                    //Debug.ReadLine();
                    Console.WriteLine(message);
                }
               await Wait(1);
            }
        }

        [Test]
        public async Task TheArticlePageBannerAdIsPresent()
        {
            await AndroidArticlePageIsPresent();
            for (int i = 0; ; i++)
            {
                if (i >= 10) Assert.Fail("The Article Page banner ad is not present.");
                try
                {
                    if (IsAndroidElementPresent("ad|-3|non-module|advertisementModule|0|manually placed in page-wrapper|"))
                        break;
                }
                catch (Exception ex)
                {
                    string message = $"The Article Page banner ad is not present. {ex}";
                    Debug.WriteLine(message);
                    //Debug.ReadLine();
                    Console.WriteLine(message);
                }
               await Wait(1);
            }
        }

        [Test]
        public async Task ConfirmAdModulesArePresentAndCount()
        {
            await AndroidArticlePageIsPresent();

            int adModuleCount = 0;

            for (int i = 0; ; i++)
            {
                if (i >= 120) Assert.Fail("Could not find the last element on the Watch Page prior to time out.");
                try
                {
                    await ScrollDownOnAndroid();

                    if (IsAndroidElementPresent("module|advertisement"))
                    {
                        adModuleCount++;
                    }
                    if (IsAndroidElementPresent("module|last"))
                    {
                        break;
                    }
                }
                catch (Exception ex)
                {
                    string message = $"Could not find the last element on the Watch Page. {ex}";
                    Debug.WriteLine(message);
                    //Debug.ReadLine();
                    Console.WriteLine(message);
                }
               await Wait(1);
            }

            Console.Write("Number of ad modules on the Watch Page: " + adModuleCount);
        }

        //TODO: Article Page: Compare the screenConfig modules from the AndroidArticlePageScreenConfigRequest() method to those on the Article Page

    }
}
