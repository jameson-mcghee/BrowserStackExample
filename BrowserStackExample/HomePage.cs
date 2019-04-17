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
    public class HomePage : GlobalMethods
    {
        public HomePage(string profile, string device) : base(profile, device){}


        //ANDROID
        public async Task HomePageIsPresent()
        {

            for (int i = 0;  ; i++)
            {
                if (i >= 45) Assert.Fail("The Home page is not present.");
                try
                {
                    if (IsAndroidElementPresent("component-home-pageWrapper-contentList"))
                    break;
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

        public static async Task<dynamic> HomePageScreenConfigRequest(string url)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.Timeout = new TimeSpan(0, 0, 0, 0, 20000);
                    var postBody = new List<KeyValuePair<string, string>>();
                    postBody.Add(new KeyValuePair<string, string>("siteId", "51"));
                    postBody.Add(new KeyValuePair<string, string>("deviceId", "12345"));
                    postBody.Add(new KeyValuePair<string, string>("applicationId", "67890"));
                    postBody.Add(new KeyValuePair<string, string>("pageConfigId", "a355d696-faff-4544-9dde-510e966f700e"));
                    var request = new HttpRequestMessage(HttpMethod.Post, url) { Content = new FormUrlEncodedContent(postBody) };
                    //var request = new RestRequest(Method.POST);
                    //request.AddXmlBody("siteId", "51");
                    //request.AddXmlBody("deviceId", "12345");
                    //request.AddXmlBody("applicationId", "67890");
                    //request.AddXmlBody("pageConfigId", "a355d696-faff-4544-9dde-510e966f700e");
                    var response = await httpClient.SendAsync(request);
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
            foreach (dynamic item in navigation)
            {
                dynamic pageName = item.name;
                dynamic pageConfigID = item.pageConfigId;

                if (string.IsNullOrEmpty(pageName?.ToString()))
                {
                    throw new Exception("No Page Name in the API response.");
                }
                if (string.IsNullOrEmpty(pageConfigID?.ToString()))
                {
                    throw new Exception("No Page Config ID in the API response.");
                }

                Console.WriteLine(pageName);
                Console.WriteLine(pageConfigID);

            }
        }



        public async Task GetHomePageScreenConfig()
        {
            //await GetPageConfigID();
            // Get the response.
            dynamic responseScreenConfig = await HomePageScreenConfigRequest
                ("https://api-stage.tegna-tv.com/mobile/configuration-ro/getScreenConfig?subscription-key=fdd842925eb6445f85adb84b30d22838");

            if (responseScreenConfig.Count == 0)
            {
                throw new Exception("No Screen Config information in the API response.");
            }

        }

            public async Task ModuleHomePageAdsArePresent()
        {
            await HomePageIsPresent();

            dynamic screenConfig = null; //do your getScreenConfig call to the API

            Assert.IsTrue(screenConfig?.metadata?.count != null);
            int screenConfigCount = int.Parse(screenConfig?.metadata?.count?.ToString());

            for (int i = 0; ; i++)
            {
                ScrollDown();

                if (i >= 120) Assert.Fail("The Home Page module ads are not present.");
                try
                {
                    ReadOnlyCollection<AndroidElement> adlistHomePage = androidDriver.FindElementsByAccessibilityId("module|3|advertisementModule|ad|||");
                    int adList = adlistHomePage.Count();

                    var bottomPageElement = androidDriver.FindElementByAccessibilityId("");
                    Assert.IsTrue(bottomPageElement.Displayed);
                    Assert.IsTrue(screenConfigCount == adList);
                    break;
                }
                catch (Exception ex)
                {
                    string message = $"The Home Page module ads are not present. {ex}";
                    Debug.WriteLine(message);
                    //Debug.ReadLine();
                    Console.WriteLine(message);
                }
                Wait(1);
            }
        }



        //IOS



    }
}
