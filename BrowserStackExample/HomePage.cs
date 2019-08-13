using System;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using System.Collections.Generic;
using RestSharp;

namespace BrowserStackIntegration
{
    public class HomePage : PushNotifications
    {
        public HomePage(string profile, string device) : base(profile, device){}


        //ANDROID
        //Obtain the Page Config ID
        public static async Task<dynamic> StationAppConfigRequest(string url)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.Timeout = new TimeSpan(0, 0, 0, 0, 20000);
                    var response = await httpClient.GetAsync(url).ConfigureAwait(false);
                    var responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);                    
                    return JsonConvert.DeserializeObject(responseString);
                }

            }
            catch (Exception ex)
            {
                string message = $"GetResponseAsync - Error getting response from " + url + ".Ex: " + ex;
                Debug.WriteLine(message);
                //Debug.ReadLine();
                Console.WriteLine(message);
                throw;
            }
        }
        
        public static async Task GetPageConfigID()
        {
            dynamic responseStationAppConfig = await StationAppConfigRequest
                ("https://api-stage.tegna-tv.com/mobile/configuration-ro/getStationAppConfig/51/mobile?subscription-key=fdd842925eb6445f85adb84b30d22838");
            //Site ID is provided in this URL

            if (responseStationAppConfig.Count == 0)
            {
                throw new Exception("No Station App Config information in the API response.");
            }

            dynamic navigation = responseStationAppConfig.metadata.navigation;

            List<string> pageConfigIDs = new List<string>();
            List<string> pageNames = new List<string>();

            foreach (dynamic item in navigation)
            {
                string pageName = item.name?.ToString();
                string pageConfigID = item.pageConfigId?.ToString();

                if (string.IsNullOrEmpty(pageName))
                {
                    throw new Exception("No Page Name in the API response.");
                }
                if (string.IsNullOrEmpty(pageConfigID))
                {
                    throw new Exception("No Page Config ID in the API response.");
                }
                pageConfigIDs.Add(pageConfigID);
                pageNames.Add(pageName);
                Console.WriteLine(pageName + ": " + pageConfigID);
            }
            Assert.IsNotNull(pageConfigIDs);
            Assert.IsNotNull(pageNames);
        }

        public static async Task<dynamic> GetHomePageScreenConfig()
        {
            int adCount = 0;
            dynamic responseScreenConfig = await GetScreenConfigRequestByPageName("home");

            Assert.IsNotNull(responseScreenConfig, "No screen config information in the API response. ");

            dynamic pageConfigList = responseScreenConfig.modules;

            foreach (dynamic item in pageConfigList)
            {
                if (item.name?.ToString() == "advertisementModule")
                {
                    adCount++;
                }
            }
            Assert.IsNotNull(adCount, "Advertisement Module count in the screen config is null. ");
            Console.WriteLine($"Number of ad modules in the Home Page screen config: {adCount}{Environment.NewLine}");
            return adCount;
        }

        public async Task AndroidHomePageIsPresent()
        {

            for (int i = 0; ; i++)
            {
                if (i >= 20) Assert.Fail("The Home page is not present.");
                try
                {
                    if (IsAndroidElementPresent("page||home-wrapper||||"))
                    {
                        break;
                    }
                    if (IsAndroidElementPresent("page||ftue||||"))
                    {
                        await AndroidClickFTUECloseButton();
                    }
                }
                catch (Exception ex)
                {
                    string message = $"The Home page is not present. {ex}";
                    Debug.WriteLine(message);
                    //Debug.ReadLine();
                    Console.WriteLine(message);
                }
                await Wait(1);
            }
        }


        //public async Task ModuleHomePageAdsArePresent()
        //{
        //    await HomePageIsPresentOnAndroid();

        //    dynamic screenConfig = null; //do your getScreenConfig call to the API

        //    Assert.IsTrue(screenConfig?.metadata?.count != null);
        //    int screenConfigCount = int.Parse(screenConfig?.metadata?.count?.ToString());

        //    for (int i = 0; ; i++)
        //    {
        //        ScrollDown();

        //        if (i >= 120) Assert.Fail("The Home Page module ads are not present.");
        //        try
        //        {
        //            ReadOnlyCollection<AndroidElement> adlistHomePage = androidDriver.FindElementsByAccessibilityId("module|3|advertisementModule|ad|||");
        //            int adList = adlistHomePage.Count();

        //            var bottomPageElement = androidDriver.FindElementByAccessibilityId("");
        //            Assert.IsTrue(bottomPageElement.Displayed);
        //            Assert.IsTrue(screenConfigCount == adList);
        //            break;
        //        }
        //        catch (Exception ex)
        //        {
        //            string message = $"The Home Page module ads are not present. {ex}";
        //            Debug.WriteLine(message);
        //            //Debug.ReadLine();
        //            Console.WriteLine(message);
        //        }
        //        Wait(1);
        //    }
        //}



        //IOS

        public async Task IOSHomePageIsPresent()
        {
            for (int i = 0; ; i++)
            {
                if (i >= 20) Assert.Fail("The Home page is not present.");
                try
                {
                    if (IsiOSElementPresent("page||home-wrapper||||"))
                    {
                        break;
                    }
                    if (IsiOSElementPresent("page||ftue||||"))
                    {
                        await IOSClickFTUECloseButton();
                    }
                }
                catch (Exception ex)
                {
                    string message = $"The Home page is not present. {ex}";
                    Debug.WriteLine(message);
                    //Debug.ReadLine();
                    Console.WriteLine(message);
                }
                await Wait(1);
            }
        }
    }
}
