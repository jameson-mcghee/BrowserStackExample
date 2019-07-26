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
    public class IOSWhenOnTheTopicPage : HomePage
    {
        public IOSWhenOnTheTopicPage(string profile, string device) : base(profile, device) { }

        //[Test]
        public async Task TheUserIsAbleToNavigateToTheTopicPage()
        {
            await IOSHomePageIsPresent();

            if (IsiOSElementPresent("button|||hamburger||manually placed on top of screen|"))
            {
                await IOSClickCommand("button|||hamburger||manually placed on top of screen|");
            }
            else
            {
                Assert.Fail("The Hamburger Icon (Topic Page) button is not present. ");
            }

            for (int i = 0; ; i++)
            {
                if (i >= 2) Assert.Fail("The Topic Page back button is not present. ");
                try
                {
                    if (IsiOSElementPresent("button|||back||manually placed on top of screen|"))
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
