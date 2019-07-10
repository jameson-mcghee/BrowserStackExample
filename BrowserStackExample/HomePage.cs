using System;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Diagnostics;
using OpenQA.Selenium.Appium.Android;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
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
        
        public async Task GetPageConfigID()
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

        public static async Task<dynamic> HomePageScreenConfigRequest(string url)
        {
            
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.Timeout = new TimeSpan(0, 0, 0, 0, 20000);
                    //TODO: Home Page: Come up with a way to pass the pageConfigId from the GetPageConfigID() method
                    var postBody = new Dictionary<string, string>
                    {
                        { "siteId", "51"},
                        { "deviceId", "12345" },
                        { "applicationId", "67890" },
                        { "pageConfigId", "23cf3231-ec01-48df-b6c6-9dcd4fd336e8" }
                    };
                    var content = new StringContent(JsonConvert.SerializeObject(postBody), Encoding.UTF8, "application/json");
                    var response = await httpClient.PostAsync(url, content);
                    var responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    return JsonConvert.DeserializeObject(responseString);
                }

            }
            catch (Exception ex)
            {
                string message = $"PostResponseAsync - Error getting response from " + url + ".Ex: " + ex;
                Debug.WriteLine(message);
                //Debug.ReadLine();
                Console.WriteLine(message);
                throw;
            }
            
        }

        public async Task GetHomePageScreenConfig()
        {
            dynamic responseScreenConfig = await HomePageScreenConfigRequest
                ("https://api-stage.tegna-tv.com/mobile/configuration-ro/getScreenConfig?subscription-key=fdd842925eb6445f85adb84b30d22838");

            Assert.IsNotNull(responseScreenConfig, "No screen config information in the API response. ");

            dynamic pageConfigList = responseScreenConfig.modules;

            int adCount = 0;
            foreach (dynamic item in pageConfigList)
            {
                if (item.name?.ToString() == "advertisementModule")
                {
                    adCount++;
                }
            }
            Assert.IsNotNull(adCount, "Advertisement Module count in the screen config is null. ");
            Console.WriteLine("The screen config ad module count is: " + adCount);
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
                Wait(1);
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
                Wait(1);
            }
        }
    }
}
