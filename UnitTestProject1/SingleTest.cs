using System;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;
using System.Linq;
using BrowserStackIntegration;
using System.Threading.Tasks;
using System.Diagnostics;


namespace MobileAppTests
{
    //[TestFixture("single", "galaxy-s9")]
    [TestFixture("single", "iphone-8")]
    public class SingleTest : GlobalMethods
    {

        public SingleTest(string profile, string device) : base(profile, device) { }

        //[Test]
        public void SimpleTestAndroid()
        {

            for (int i = 0; ; i++)
            {
                if (i >= 15) Assert.Fail("Assert Fail Message.");
                try
                {
                    var viewElements = androidDriver.FindElements(By.ClassName("android.widget.FrameLayout"));
                    Assert.IsTrue(viewElements.Any());
                    break;
                }
                catch (Exception ex)
                {
                    string message = $"Try/Catch Message. {ex}";
                    Debug.WriteLine(message);
                    //Debug.ReadLine();
                    Console.WriteLine(message);
                }
                Wait(1);
            }
            //var viewElements = androidDriver.FindElements(By.Id("android:id/content"));
            //Thread.Sleep(TimeSpan.FromSeconds(3));
            //Assert.IsTrue(viewElements.Any());
                        
        }
        [Test]
        public async Task SimpleTestIOS()
        {
            var viewElements = iosDriver.FindElements(By.ClassName("XCUIElementTypeApplication"));
            await ApproveiOSAlerts();
            Thread.Sleep(TimeSpan.FromSeconds(3));
            Assert.IsTrue(viewElements.Any());
        }

    }
}
