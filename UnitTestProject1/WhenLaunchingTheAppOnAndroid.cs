using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BrowserStackIntegration;
using System.Text;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;
using System.Collections.Generic;
using System.Diagnostics;

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
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task TheUserCanAccessTheHomePage()
#pragma warning restore CS1998
        {
            var mainClassElement = androidDriver.FindElements(By.ClassName("android.widget.FrameLayout"));

            for (int second = 0; ; second++)
            {
                if (second >= 15) Assert.Fail("timeout");
                try
                {
                    Assert.IsTrue(mainClassElement.Any()); break;
                }
                catch (Exception ex)
                {
                    string message = $"App is not launching. {ex}";
                    //Log.Error(message);
                    Debug.WriteLine(message); //this line will output to the debug console, what you usually see when debugging in th "Output" window in the bottom of visual studio
                    //Debug.ReadLine(); //this will keep your program from automatically closing. Not 100% sure this will work in the debugger though. You can also just put a break point at the closing brace of the catch block
                    Console.WriteLine(message); //this line will output to the console window if the program has one
                }
                Thread.Sleep(TimeSpan.FromSeconds(3));
            }
            

          }
    }
}
