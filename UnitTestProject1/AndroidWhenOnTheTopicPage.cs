using NUnit.Framework;
using BrowserStackIntegration;
using System.Threading.Tasks;
using System;
using System.Diagnostics;

namespace TopicPageTests
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
    public class AndroidWhenOnTheTopicPage : HomePage
    {
        public AndroidWhenOnTheTopicPage(string profile, string device) : base(profile, device) { }

        [Test]
        public async Task TheUserIsAbleToNavigateToTheTopicPage()
        {
            await AndroidHomePageIsPresent();
            
            if (IsAndroidElementPresent("button|||hamburger||manually placed on top of screen|"))
            {
                await AndroidClickCommand("button|||hamburger||manually placed on top of screen|");
            }
            else
            {
                Assert.Fail("The Star Icon (Topic Page) button is not present. ");
            }

            for (int i = 0; ; i++)
            {
                if (i >= 2) Assert.Fail("The Topic Page back button is not present. ");
                try
                {
                    if (IsAndroidElementPresent("button|||back||manually placed on top of screen|"))
                        break;
                }
                catch (Exception ex)
                {
                    string message = $"The Topic Page back button is not present. {ex}";
                    Debug.WriteLine(message);
                    //Debug.ReadLine();
                    Console.WriteLine(message);
                }
                Wait(1);
            }
        }



    }
}
