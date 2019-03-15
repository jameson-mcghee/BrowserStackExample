﻿using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BrowserStackIntegration;
using System.Diagnostics;
using System.Text;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;
using System.Collections.Generic;

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
    [TestFixture("parallel", "nexus-9")]
    [TestFixture("parallel", "galaxy-tabs4")]
    [Parallelizable(ParallelScope.Fixtures)]
    public class WhenLaunchingTheAppOnAndroid : BrowserStackIntegrationImplementation
    {
        public WhenLaunchingTheAppOnAndroid(string profile, string device) : base(profile, device) { }

        [Test]
        public async Task TheUserCanAccessTheHomePage()
        {
            // Arrange -> What type of setup do we need to do?
            var mainClassElement = androidDriver.FindElements(By.ClassName("android.widget.FrameLayout"));

            // Act -> What are we testing? Generally call the method or property under test (Method Under Test or MUT)
            for (int second = 0; ; second++)
            {
                if (second >= 15) Assert.Fail("App is not launching.");
                try
                {
                    // Assert -> Did we get what we expect?
                    Assert.IsTrue(mainClassElement.Any()); break;
                }
                catch (Exception ex)
                {
                    string message = $"App is not launching. {ex}"; //Log.Error(message);
                    Debug.WriteLine(message); //this line will output to the debug console, what you usually see when debugging in th "Output" window in the bottom of visual studio
                    //Debug.ReadLine(); //this will keep your program from automatically closing. Not 100% sure this will work in the debugger though. You can also just put a break point at the closing brace of the catch block
                    Console.WriteLine(message); //this line will output to the console window if the program has one
                }
                Thread.Sleep(TimeSpan.FromSeconds(1));
            }
        }

        [Test]
        public async Task TheIntroScreenAdIsPresent()
        {
            //var introScreenAd = androidDriver.FindElements(By.Id("aw0"));

            var test = androidDriver.FindElement(By.a)

            for (int second = 0; ; second++)
            {
                if (second >= 40) Assert.Fail("Introscreen Ad not present");
                try
                {
                    if (IsElementPresent(By.Id("aw0"))); break;
                }
                catch (Exception ex)
                {
                    string message = $"Introscreen Ad not present. {ex}";
                    Debug.WriteLine(message);
                    //Debug.ReadLine();
                    Console.WriteLine(message);
                }
                Thread.Sleep(TimeSpan.FromSeconds(5));
            }
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                androidDriver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
