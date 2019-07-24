using NUnit.Framework;
using System.Threading.Tasks;
using BrowserStackIntegration;

namespace MobileAppTests
{
    //[TestFixture("parallel", "iphone-8")]
    //[TestFixture("parallel", "iphone-8-plus")]
    //[TestFixture("parallel", "iphone-se")]
    [TestFixture("parallel", "iphone-xs")]
    //[TestFixture("parallel", "ipad-pro")] //Tablet
    //[TestFixture("parallel", "ipad-5th")] //Tablet
    [Parallelizable(ParallelScope.Fixtures)]
    public class IOSScreenShots : WatchPage
    {
        public IOSScreenShots(string profile, string device) : base(profile, device) { }

        [Test]
        public async Task CaptureScreenShotsOniOS()
        {
            #region Home Page
            //await IOSHomePageIsPresent();
            Wait(15);
            await IOSCaptureScreenShot();
            #endregion

            #region Weather Page
            for (int i = 0; ; i++)
            {
                await SwipeRightToLeftOnIOS();
                break; //TODO: This 'break' will need to be removed once the React Native issue with finding iOS Elements is resolved.

                //if (i >= 5) Assert.Fail("The Weather Page is not present.");
                //try
                //{
                //    if (IsiOSElementPresent("page||weather-wrapper||||"))
                //        break;
                //}
                //catch (Exception ex)
                //{
                //    string message = $"The Weather Page is not present. {ex}";
                //    Debug.WriteLine(message);
                //    //Debug.ReadLine();
                //    Console.WriteLine(message);
                //}
                //Wait(1);
            }
            Wait(5);
            await IOSCaptureScreenShot();
            #endregion

            #region Watch Page
            for (int i = 0; ; i++)
            {
                await ScrollDownOnIOS();
                Wait(1);
                await SwipeRightToLeftOnIOS();
                break; //TODO: This 'break' will need to be removed once the React Native issue with finding iOS Elements is resolved.

                //    if (i >= 5) Assert.Fail("The Watch Page is not present.");
                //    try
                //    {
                //        if (IsiOSElementPresent("page||watch-wrapper||||"))
                //        {
                //            break;
                //        }
                //    }
                //    catch (Exception ex)
                //    {
                //        string message = $"The Watch Page is not present. {ex}";
                //        Debug.WriteLine(message);
                //        //Debug.ReadLine();
                //        Console.WriteLine(message);
                //    }
            }
            Wait(5);
            await IOSCaptureScreenShot();
            #endregion

            #region Topic Page
            //if (IsiOSElementPresent("button|||hamburger||manually placed on top of screen|"))
            //{
            //    await IOSClickCommand("button|||hamburger||manually placed on top of screen|");
            //}
            //else
            //{
            //    Assert.Fail("The Star Icon (Topic Page) button is not present. ");
            //}

            //for (int i = 0; ; i++)
            //{
            //    if (i >= 2) Assert.Fail("The Topic Page back button is not present. ");
            //    try
            //    {
            //        if (IsiOSElementPresent("button|||back||manually placed on top of screen|"))
            //            break;
            //    }
            //    catch (Exception ex)
            //    {
            //        string message = $"The Topic Page back button is not present. {ex}";
            //        Debug.WriteLine(message);
            //        //Debug.ReadLine();
            //        Console.WriteLine(message);
            //    }
            //    Wait(1);
            //}
            //Wait(5);
            //await IOSCaptureScreenShot();
            #endregion
        }

    }
}
