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
    public class IOSWhenOnTheSettingsScreen : HomePage
    {
        public IOSWhenOnTheSettingsScreen(string profile, string device) : base(profile, device) { }

        //[Test]
        public async Task TheUserIsAbleToNavigateToTheSettingsScreen()
        {
            await IOSHomePageIsPresent();

            if (IsiOSElementPresent("button|||navigate-menu||manually placed on top of screen|"))
            {
                await IOSClickCommand("button|||navigate-menu||manually placed on top of screen|");
            }
            else
            {
                Assert.Fail("The Settings Screen button is not present. ");
            }

            for (int i = 0; ; i++)
            {
                if (i >= 2) Assert.Fail("The Settings Screen back button is not present. ");
                try
                {
                    if (IsiOSElementPresent("button|||back||manually placed on top of screen|"))
                        break;
                }
                catch (Exception ex)
                {
                    string message = $"The Settings Screen back button is not present. {ex}";
                    Debug.WriteLine(message);
                    //Debug.ReadLine();
                    Console.WriteLine(message);
                }
               await Wait(1);
            }
        }



    }
}