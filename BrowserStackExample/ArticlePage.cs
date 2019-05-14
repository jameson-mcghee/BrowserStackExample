using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserStackIntegration
{
    public class ArticlePage : HomePage
    {
        public ArticlePage(string profile, string device) : base(profile, device) { }

        //Android
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
                    string message = $"The Article Page is not present. {ex}";
                    Debug.WriteLine(message);
                    //Debug.ReadLine();
                    Console.WriteLine(message);
                }
                Wait(1);
            }
        }

        //iOS
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
                    //Debug.ReadLine();
                    Console.WriteLine(message);
                }
                Wait(1);
            }
        }

    }
}
