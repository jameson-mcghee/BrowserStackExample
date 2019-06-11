using NUnit.Framework;
using BrowserStackIntegration;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using System.Net.Http;
using System;
using System.Diagnostics;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace MobileAppTests
{
    //[TestFixture("parallel", "pixel")]
    //[TestFixture("parallel", "pixel-2")]
    //[TestFixture("parallel", "pixel-3")]
    //[TestFixture("parallel", "galaxy-s7")]
    //[TestFixture("parallel", "galaxy-s8")]
    [TestFixture("parallel", "galaxy-s9")]
    //[TestFixture("parallel", "galaxy-note8")]
    //[TestFixture("parallel", "galaxy-note9")]
    //[TestFixture("parallel", "galaxy-note4")]
    ////[TestFixture("parallel", "galaxy-s6")] //App or one of the otherApps cannot be run on version 5.0.
    ////[TestFixture("parallel", "nexus-9")] //tablet
    ////[TestFixture("parallel", "galaxy-tabs4")] //tablet
    [Parallelizable(ParallelScope.Fixtures)]
    public class AndroidWhenInTheFTUE : FirstTimeUserExperience
    {
        public AndroidWhenInTheFTUE(string profile, string device) : base(profile, device) { }

        //[Test]
        public async Task TheFTUEModuleIsPresent()
        {
            await AndroidUserCanAccessTheDayPartingScreen();
            for (int i = 0; ; i++)
            {
                if (i >= 10) Assert.Fail("FTUE is not being displayed.");
                try
                {
                    if (IsAndroidElementPresent("page||ftue||||"))
                    {
                        break;
                    }
                }
                catch (Exception ex)
                {
                    string message = $"FTUE is not being displayed. {ex}";
                    Debug.WriteLine(message);
                    //Debug.ReadLine();
                    Console.WriteLine(message);
                }
                Wait(1);
            }
        }

        [Test]
        public async Task TheUserCanNavigateTheFTUEUsingTheButtons()
        {
            await AndroidUsersCanAccessTheFTUE();
            await AndroidUsersCanAccessTheFTUEHomePage();
            await AndroidClickFTUENextButton();
            await AndroidUsersCanAccessTheFTUETopicFollowPage();
            await AndroidClickFTUENextButton();
            await AndroidUsersCanAccessTheFTUETopicPickerPage();
            await AndroidClickFTUENextButton();
            await AndroidUsersCanAccessTheFTUELocationPage();
            await AndroidClickFTUENextButton();
            await AndroidClickFTUEGetStartedButton();
        }

        [Test]
        public async Task TheUserCanNavigateTheFTUEBySwiping()
        {
            await AndroidUsersCanAccessTheFTUE();
            await AndroidUsersCanAccessTheFTUEHomePage();
            await SwipeRightToLeftOnAndroid();
            await AndroidClickFTUENextButton();
            await AndroidUsersCanAccessTheFTUETopicFollowPage();
            await SwipeRightToLeftOnAndroid();
            await AndroidUsersCanAccessTheFTUETopicPickerPage();
            await SwipeRightToLeftOnAndroid();
            await AndroidUsersCanAccessTheFTUELocationPage();
            await AndroidClickFTUEPreviousButton();
            await AndroidUsersCanAccessTheFTUETopicPickerPage();
            await AndroidClickFTUECloseButton();
        }

        //[Test]

    }
}
