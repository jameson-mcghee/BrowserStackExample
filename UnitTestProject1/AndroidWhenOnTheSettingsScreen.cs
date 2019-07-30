using NUnit.Framework;
using BrowserStackIntegration;
using System.Threading.Tasks;
using System;
using System.Diagnostics;

namespace SettingsPageTests
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
    public class AndroidWhenOnTheSettingsScreen : HomePage
    {
        public AndroidWhenOnTheSettingsScreen(string profile, string device) : base(profile, device) { }

        [Test]
        public async Task TheUserIsAbleToNavigateToTheSettingsScreen()
        {
            await AndroidHomePageIsPresent();

            if (IsAndroidElementPresent("button|||navigate-menu||manually placed on top of screen|"))
            {
                await AndroidClickCommand("button|||navigate-menu||manually placed on top of screen|");
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
                    if (IsAndroidElementPresent("button|||back||manually placed on top of screen|"))
                        break;
                }
                catch (Exception ex)
                {
                    string message = $"The Settings Screen back button is not present. {ex}";
                    Debug.WriteLine(message);
                    //Debug.ReadLine();
                    Console.WriteLine(message);
                }
                Wait(1);
            }
        }

    }
}