using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Threading.Tasks;


namespace BrowserStackIntegration
{
    public class FirstTimeUserExperience : DayPartingScreen
    {
        public FirstTimeUserExperience(string profile, string device) : base(profile, device) { }

        //ANDROID
        public async Task AndroidUsersCanAccessTheFTUE()
        {
            await AndroidUserCanAccessTheDayPartingScreen();
            for (int i = 0; ; i++)
            {
                if (i >= 5) Assert.Fail("FTUE is not being displayed.");
                try
                {
                    if (IsAndroidElementPresent("page||ftue||||"))
                    {
                        return;
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

        public async Task AndroidUsersCanAccessTheFTUEHomePage()
        {
            await AndroidUsersCanAccessTheFTUE();
            for (int i = 0; ; i++)
            {
                if (i >= 3) Assert.Fail("FTUE Home page is not being displayed.");
                try
                {
                    if (IsAndroidElementPresent("component||non-module|ftue-home|||"))
                    {
                        return;
                    }
                }
                catch (Exception ex)
                {
                    string message = $"FTUE Home page is not being displayed. {ex}";
                    Debug.WriteLine(message);
                    //Debug.ReadLine();
                    Console.WriteLine(message);
                }
                Wait(1);
            }
        }

        public async Task AndroidUsersCanAccessTheFTUETopicFollowPage()
        {
            for (int i = 0; ; i++)
            {
                if (i >= 3) Assert.Fail("FTUE Topic Follow page is not being displayed.");
                try
                {
                    if (IsAndroidElementPresent("component||non-module|ftue-topicFollow|||"))
                    {
                        return;
                    }
                }
                catch (Exception ex)
                {
                    string message = $"FTUE Topic Follow page is not being displayed. {ex}";
                    Debug.WriteLine(message);
                    //Debug.ReadLine();
                    Console.WriteLine(message);
                }
                Wait(1);
            }
        }

        public async Task AndroidUsersCanAccessTheFTUETopicPickerPage()
        {
            for (int i = 0; ; i++)
            {
                if (i >= 3) Assert.Fail("FTUE Topic Picker page is not being displayed.");
                try
                {
                    if (IsAndroidElementPresent("component||non-module|ftue-topicPicker|||"))
                    {
                        return;
                    }
                }
                catch (Exception ex)
                {
                    string message = $"FTUE Topic Picker page is not being displayed. {ex}";
                    Debug.WriteLine(message);
                    //Debug.ReadLine();
                    Console.WriteLine(message);
                }
                Wait(1);
            }
        }

        public async Task AndroidUsersCanAccessTheFTUELocationPage()
        {
            for (int i = 0; ; i++)
            {
                if (i >= 3) Assert.Fail("FTUE Location page is not being displayed.");
                try
                {
                    if (IsAndroidElementPresent("component||non-module|ftue-location|||"))
                    {
                        if (IsAndroidElementPresent("input||non-module|ftue-location|||"))
                        {
                            return;
                        }
                        else
                        {
                            Assert.Fail("The 'Add Location' input field is not present on the FTUE Location Page.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    string message = $"FTUE Location page is not being displayed. {ex}";
                    Debug.WriteLine(message);
                    //Debug.ReadLine();
                    Console.WriteLine(message);
                }
                Wait(1);
            }
        }

        public async Task AndroidClickFTUEGetStartedButton()
        {
            for (int i = 0; ; i++)
            {
                if (i >= 3) Assert.Fail("FTUE Get Started Button is not being displayed.");
                try
                {
                    if (IsAndroidElementPresent("component||non-module|ftue-end|||"))
                    {
                        await AndroidClickCommand("component||non-module|ftue-end|||");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    string message = $"FTUE Get Started Button is not being displayed. {ex}";
                    Debug.WriteLine(message);
                    //Debug.ReadLine();
                    Console.WriteLine(message);
                }
                Wait(1);
            }
        }

        public async Task AndroidClickFTUENextButton()
        {
            for (int i = 0; ; i++)
            {
                if (i >= 3) Assert.Fail("FTUE Next Button is not being displayed.");
                try
                {
                    if (IsAndroidElementPresent("button||ftue-next||||"))
                    {
                        await AndroidClickCommand("button||ftue-next||||");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    string message = $"FTUE Next Button is not being displayed. {ex}";
                    Debug.WriteLine(message);
                    //Debug.ReadLine();
                    Console.WriteLine(message);
                }
                Wait(1);
            }
        }

        public async Task AndroidClickFTUEPreviousButton()
        {
            for (int i = 0; ; i++)
            {
                if (i >= 3) Assert.Fail("FTUE Previous Button is not being displayed.");
                try
                {
                    if (IsAndroidElementPresent("button||ftue-previous||||"))
                    {
                        await AndroidClickCommand("button||ftue-previous||||");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    string message = $"FTUE Previous Button is not being displayed. {ex}";
                    Debug.WriteLine(message);
                    //Debug.ReadLine();
                    Console.WriteLine(message);
                }
                Wait(1);
            }
        }

        public async Task AndroidClickFTUECloseButton()
        {
            for (int i = 0; ; i++)
            {
                if (i >= 3) Assert.Fail("FTUE Close Button is not being displayed.");
                try
                {
                    if (IsAndroidElementPresent("button||ftue-close||||"))
                    {
                        await AndroidClickCommand("button||ftue-close||||");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    string message = $"FTUE Close Button is not being displayed. {ex}";
                    Debug.WriteLine(message);
                    //Debug.ReadLine();
                    Console.WriteLine(message);
                }
                Wait(1);
            }
        }

        //iOS
        public async Task IOSUsersCanAccessTheFTUE()
        {
            await IOSUserCanAccessTheDayPartingScreen();
            for (int i = 0; ; i++)
            {
                if (i >= 5) Assert.Fail("FTUE is not being displayed.");
                try
                {
                    if (IsiOSElementPresent("page||ftue||||"))
                    {
                        return;
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

        public async Task IOSUsersCanAccessTheFTUEHomePage()
        {
            for (int i = 0; ; i++)
            {
                if (i >= 3) Assert.Fail("FTUE Home page is not being displayed.");
                try
                {
                    if (IsiOSElementPresent("component||non-module|ftue-home|||"))
                    {
                        return;
                    }
                }
                catch (Exception ex)
                {
                    string message = $"FTUE Home page is not being displayed. {ex}";
                    Debug.WriteLine(message);
                    //Debug.ReadLine();
                    Console.WriteLine(message);
                }
                Wait(1);
            }
        }

        public async Task IOSUsersCanAccessTheFTUETopicFollowPage()
        {
            for (int i = 0; ; i++)
            {
                if (i >= 3) Assert.Fail("FTUE Topic Follow page is not being displayed.");
                try
                {
                    if (IsiOSElementPresent("component||non-module|ftue-topicFollow|||"))
                    {
                        return;
                    }
                }
                catch (Exception ex)
                {
                    string message = $"FTUE Topic Follow page is not being displayed. {ex}";
                    Debug.WriteLine(message);
                    //Debug.ReadLine();
                    Console.WriteLine(message);
                }
                Wait(1);
            }
        }

        public async Task IOSUsersCanAccessTheFTUETopicPickerPage()
        {
            for (int i = 0; ; i++)
            {
                if (i >= 3) Assert.Fail("FTUE Topic Picker page is not being displayed.");
                try
                {
                    if (IsiOSElementPresent("component||non-module|ftue-topicPicker|||"))
                    {
                        return;
                    }
                }
                catch (Exception ex)
                {
                    string message = $"FTUE Topic Picker page is not being displayed. {ex}";
                    Debug.WriteLine(message);
                    //Debug.ReadLine();
                    Console.WriteLine(message);
                }
                Wait(1);
            }
        }

        public async Task IOSUsersCanAccessTheFTUELocationPage()
        {
            for (int i = 0; ; i++)
            {
                await ApproveiOSAlerts();
                if (i >= 3) Assert.Fail("FTUE Location page is not being displayed.");
                try
                {
                    if (IsiOSElementPresent("component||non-module|ftue-location|||"))
                    {
                        return;
                    }
                }
                catch (Exception ex)
                {
                    string message = $"FTUE Location page is not being displayed. {ex}";
                    Debug.WriteLine(message);
                    //Debug.ReadLine();
                    Console.WriteLine(message);
                }
                Wait(1);
            }
        }

        public async Task IOSClickFTUEGetStartedButton()
        {
            for (int i = 0; ; i++)
            {
                if (i >= 3) Assert.Fail("FTUE Get Started Button is not being displayed.");
                try
                {
                    if (IsiOSElementPresent("component||non-module|ftue-end|||"))
                    {
                        await IOSClickCommand("component||non-module|ftue-end|||");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    string message = $"FTUE Get Started Button is not being displayed. {ex}";
                    Debug.WriteLine(message);
                    //Debug.ReadLine();
                    Console.WriteLine(message);
                }
                Wait(1);
            }
        }

        public async Task IOSClickFTUENextButton()
        {
            for (int i = 0; ; i++)
            {
                if (i >= 3) Assert.Fail("FTUE Next Button is not being displayed.");
                try
                {
                    if (IsiOSElementPresent("button||ftue-next||||"))
                    {
                        await IOSClickCommand("button||ftue-next||||");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    string message = $"FTUE Next Button is not being displayed. {ex}";
                    Debug.WriteLine(message);
                    //Debug.ReadLine();
                    Console.WriteLine(message);
                }
                Wait(1);
            }
        }

        public async Task IOSClickFTUEPreviousButton()
        {
            for (int i = 0; ; i++)
            {
                if (i >= 3) Assert.Fail("FTUE Previous Button is not being displayed.");
                try
                {
                    if (IsiOSElementPresent("button||ftue-previous||||"))
                    {
                        await IOSClickCommand("button||ftue-previous||||");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    string message = $"FTUE Previous Button is not being displayed. {ex}";
                    Debug.WriteLine(message);
                    //Debug.ReadLine();
                    Console.WriteLine(message);
                }
                Wait(1);
            }
        }

        public async Task IOSClickFTUECloseButton()
        {
            for (int i = 0; ; i++)
            {
                if (i >= 3) Assert.Fail("FTUE Close Button is not being displayed.");
                try
                {
                    if (IsiOSElementPresent("button||ftue-close||||"))
                    {
                        await IOSClickCommand("button||ftue-close||||");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    string message = $"FTUE Close Button is not being displayed. {ex}";
                    Debug.WriteLine(message);
                    //Debug.ReadLine();
                    Console.WriteLine(message);
                }
                Wait(1);
            }
        }
    }
}
