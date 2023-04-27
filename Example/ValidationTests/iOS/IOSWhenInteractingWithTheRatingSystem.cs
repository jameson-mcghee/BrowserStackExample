using System;
using System.Diagnostics;
using System.Threading.Tasks;
using BrowserStackIntegration;
using NUnit.Framework;

namespace RatingSystemTesting
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
    public class IOSWhenInteractingWithTheRatingSystem : ArticlePage
    {
        public IOSWhenInteractingWithTheRatingSystem(string profile, string device) : base(profile, device) { }

        [Test]
        public async Task TheUserCanChooseToLeaveAReview()
        {
            for (int i = 0; i < 10; i++)
            {
                await IOSHomePageIsPresent();
                await IOSCloseApp();
                await IOSLaunchApp();
            }
            await IOSArticlePageIsPresent();
            await IOSClickCommand("button|||back||manually placed on top of screen|");
            for (int i = 0; ; i++)
            {
                if (i >= 2) Assert.Fail("The Rating System dialogue box is not present.");
                {
                    try
                    {
                        IsiOSElementPresent("");
                        break;
                    }
                    catch (Exception ex)
                    {
                        string message = $"The Rating System dialogue box is not present.{Environment.NewLine}{ex}";
                        Debug.WriteLine(message);
                        Console.WriteLine(message);
                    }
                    await Wait(1);
                }
            }
            await IOSClickCommand("");
            for (int i = 0; ; i++)
            {
                if (i >= 3) Assert.Fail("The Rating System dialogue box is still present after clicking 'Yes' to leave a Rating/Review.");
                {
                    try
                    {
                        dynamic elementPresent = IsiOSElementPresent("");
                        if (elementPresent = false)
                        {
                            break;
                        }
                    }
                    catch (Exception ex)
                    {
                        string message = $"The Rating System dialogue box is still present after clicking 'Yes'to leave a Rating/Review.{Environment.NewLine}{ex}";
                        Debug.WriteLine(message);
                        Console.WriteLine(message);
                    }
                    await Wait(1);
                }
            }
        }

        [Test]
        public async Task TheUserCanChooseNotToLeaveAReviewOrFeedback()
        {
            for (int i = 0; i < 10; i++)
            {
                await IOSHomePageIsPresent();
                await IOSCloseApp();
                await IOSLaunchApp();
            }
            await IOSArticlePageIsPresent();
            await IOSClickCommand("button|||back||manually placed on top of screen|");
            for (int i = 0; ; i++)
            {
                if (i >= 2) Assert.Fail("The Rating System dialogue box is not present.");
                {
                    try
                    {
                        IsiOSElementPresent("");
                        break;
                    }
                    catch (Exception ex)
                    {
                        string message = $"The Rating System dialogue box is not present.{Environment.NewLine}{ex}";
                        Debug.WriteLine(message);
                        Console.WriteLine(message);
                    }
                    await Wait(1);
                }
            }
            await IOSClickCommand("");
            await IOSClickCommand("");
        }

        [Test]
        public async Task TheUserCanChooseNotToLeaveAReviewButLeaveFeedback()
        {
            for (int i = 0; i < 10; i++)
            {
                await IOSHomePageIsPresent();
                await IOSCloseApp();
                await IOSLaunchApp();
            }
            await IOSArticlePageIsPresent();
            await IOSClickCommand("button|||back||manually placed on top of screen|");
            for (int i = 0; ; i++)
            {
                if (i >= 2) Assert.Fail("The Rating System dialogue box is not present.");
                {
                    try
                    {
                        IsiOSElementPresent("");
                        break;
                    }
                    catch (Exception ex)
                    {
                        string message = $"The Rating System dialogue box is not present.{Environment.NewLine}{ex}";
                        Debug.WriteLine(message);
                        Console.WriteLine(message);
                    }
                    await Wait(1);
                }
            }
            await IOSClickCommand("");
            await IOSClickCommand("");
            for (int i = 0; ; i++)
            {
                if (i >= 3) Assert.Fail("The Rating System dialogue box is still present after clicking 'Yes' for Feedback.");
                {
                    try
                    {
                        dynamic elementPresent = IsiOSElementPresent("");
                        if (elementPresent = false)
                        {
                            break;
                        }
                    }
                    catch (Exception ex)
                    {
                        string message = $"The Rating System dialogue box is still present after clicking 'Yes' for Feedback.{Environment.NewLine}{ex}";
                        Debug.WriteLine(message);
                        Console.WriteLine(message);
                    }
                    await Wait(1);
                }
            }
        }

        [Test]
        public async Task TheUserCanChooseToBeRemindedLater()
        {
            for (int i = 0; i < 10; i++)
            {
                await IOSHomePageIsPresent();
                await IOSCloseApp();
                await IOSLaunchApp();
            }
            await IOSArticlePageIsPresent();
            await IOSClickCommand("button|||back||manually placed on top of screen|");
            for (int i = 0; ; i++)
            {
                if (i >= 2) Assert.Fail("The Rating System dialogue box is not present.");
                {
                    try
                    {
                        IsiOSElementPresent("");
                        break;
                    }
                    catch (Exception ex)
                    {
                        string message = $"The Rating System dialogue box is not present.{Environment.NewLine}{ex}";
                        Debug.WriteLine(message);
                        Console.WriteLine(message);
                    }
                    await Wait(1);
                }
            }
            await IOSClickCommand("");
            for (int i = 0; i < 10; i++)
            {
                await IOSHomePageIsPresent();
                await IOSCloseApp();
                await IOSLaunchApp();
            }
            await IOSArticlePageIsPresent();
            await IOSClickCommand("button|||back||manually placed on top of screen|");
            for (int i = 0; ; i++)
            {
                if (i >= 2) Assert.Fail("The Rating System dialogue box is not present after clicking the Remind Me Later Button.");
                {
                    try
                    {
                        IsiOSElementPresent("");
                        break;
                    }
                    catch (Exception ex)
                    {
                        string message = $"The Rating System dialogue box is not present after clicking the Remind Me Later Button.{Environment.NewLine}{ex}";
                        Debug.WriteLine(message);
                        Console.WriteLine(message);
                    }
                    await Wait(1);
                }
            }
        }
    }
}
