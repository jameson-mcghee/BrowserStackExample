using System;
using System.Diagnostics;
using System.Threading.Tasks;
using BrowserStackIntegration;
using NUnit.Framework;

namespace RatingSystemTesting
{
    [TestFixture("parallel", "pixel")]
    [TestFixture("parallel", "pixel-2")]
    [TestFixture("parallel", "pixel-3")]
    [TestFixture("parallel", "nexus-9")]
    [TestFixture("parallel", "galaxy-s8")]
    [TestFixture("parallel", "galaxy-s9")]
    [TestFixture("parallel", "galaxy-note8")]
    [TestFixture("parallel", "galaxy-note9")]
    [TestFixture("parallel", "galaxy-tabs3")] //tablet
    [TestFixture("parallel", "galaxy-tabs4")] //tablet
    [TestFixture("parallel", "galaxy-tabs5e")] //tablet
    [Parallelizable(ParallelScope.Fixtures)]
    public class AndroidWhenInteractingWithTheRatingSystem : ArticlePage
    {
        public AndroidWhenInteractingWithTheRatingSystem(string profile, string device) : base(profile, device){}

        [Test]
        public async Task TheUserCanChooseToLeaveAReview()
        {
            for (int i = 0; i < 10; i++)
            {
                await AndroidHomePageIsPresent();
                await AndroidCloseApp();
                await AndroidLaunchApp();
            }
            await AndroidArticlePageIsPresent();
            await AndroidClickCommand("button|||back||manually placed on top of screen|");
            for (int i = 0; ; i++)
            {
                if (i >= 2) Assert.Fail("The Rating System dialogue box is not present.");
                {
                    try
                    {
                        IsAndroidElementPresent("");
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
            await AndroidClickCommand("");
            for (int i = 0; ; i++)
            {
                if (i >= 3) Assert.Fail("The Rating System dialogue box is still present after clicking 'Yes' to leave a Rating/Review.");
                {
                    try
                    {
                        dynamic elementPresent = IsAndroidElementPresent("");
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
                await AndroidHomePageIsPresent();
                await AndroidCloseApp();
                await AndroidLaunchApp();
            }
            await AndroidArticlePageIsPresent();
            await AndroidClickCommand("button|||back||manually placed on top of screen|");
            for (int i = 0; ; i++)
            {
                if (i >= 2) Assert.Fail("The Rating System dialogue box is not present.");
                {
                    try
                    {
                        IsAndroidElementPresent("");
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
            await AndroidClickCommand("");
            await AndroidClickCommand("");
        }

        [Test]
        public async Task TheUserCanChooseNotToLeaveAReviewButLeaveFeedback()
        {
            for (int i = 0; i < 10; i++)
            {
                await AndroidHomePageIsPresent();
                await AndroidCloseApp();
                await AndroidLaunchApp();
            }
            await AndroidArticlePageIsPresent();
            await AndroidClickCommand("button|||back||manually placed on top of screen|");
            for (int i = 0; ; i++)
            {
                if (i >= 2) Assert.Fail("The Rating System dialogue box is not present.");
                {
                    try
                    {
                        IsAndroidElementPresent("");
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
            await AndroidClickCommand("");
            await AndroidClickCommand("");
            for (int i = 0; ; i++)
            {
                if (i >= 3) Assert.Fail("The Rating System dialogue box is still present after clicking 'Yes' for Feedback.");
                {
                    try
                    {
                        dynamic elementPresent = IsAndroidElementPresent("");
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
                await AndroidHomePageIsPresent();
                await AndroidCloseApp();
                await AndroidLaunchApp();
            }
            await AndroidArticlePageIsPresent();
            await AndroidClickCommand("button|||back||manually placed on top of screen|");
            for (int i = 0; ; i++)
            {
                if (i >= 2) Assert.Fail("The Rating System dialogue box is not present.");
                {
                    try
                    {
                        IsAndroidElementPresent("");
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
            await AndroidClickCommand("");
            for (int i = 0; i < 10; i++)
            {
                await AndroidHomePageIsPresent();
                await AndroidCloseApp();
                await AndroidLaunchApp();
            }
            await AndroidArticlePageIsPresent();
            await AndroidClickCommand("button|||back||manually placed on top of screen|");
            for (int i = 0; ; i++)
            {
                if (i >= 2) Assert.Fail("The Rating System dialogue box is not present after clicking the Remind Me Later Button.");
                {
                    try
                    {
                        IsAndroidElementPresent("");
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
