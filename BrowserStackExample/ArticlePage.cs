using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace BrowserStackIntegration
{
    public class ArticlePage : SettingsPage
    {
        public ArticlePage(string profile, string device) : base(profile, device) { }

        #region ANDROID
        public async Task AndroidArticlePageIsPresent()
        {
            await AndroidHomePageIsPresent();
            if (IsAndroidElementPresent("module|first"))
            {
                await AndroidClickCommand("module|first");
            }
            else
            {
                Assert.Fail("The element for the first article on the Home Page cannot be found.");
            }

            for (int i = 0; ; i++)
            {
                if (i >= 10) Assert.Fail("The Article Page is not present.");
                try
                {
                    if (IsAndroidElementPresent("page||article-page-wrapper||||"))
                    {
                        break;
                    }
                }
                catch (Exception ex)
                {
                    string message = $"The Article Page is not present.{Environment.NewLine}{ex}";
                    Debug.WriteLine(message);
                    Console.WriteLine(message);
                }
                await Wait(1);
            }
        }

        //TODO: Create an ArticlePageScreenConfigRequest() method for Android and iOS
        #endregion

        #region iOS
        public async Task IOSArticlePageIsPresent()
        {
            await IOSHomePageIsPresent();
            if (IsiOSElementPresent("module|first"))
            {
                await IOSClickCommand("module|first");
            }
            else
            {
                Assert.Fail("The element for the first article on the Home Page cannot be found.");
            }

            for (int i = 0; ; i++)
            {
                if (i >= 10) Assert.Fail("The Article Page is not present.");
                try
                {
                    if (IsiOSElementPresent("page||article-page-wrapper||||"))
                    {
                        break;
                    }
                }
                catch (Exception ex)
                {
                    string message = $"The Article Page is not present. {ex}";
                    Debug.WriteLine(message);
                    Console.WriteLine(message);
                }
                await Wait(1);
            }
        }
        #endregion
    }
}
