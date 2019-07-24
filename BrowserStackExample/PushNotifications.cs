using System;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace BrowserStackIntegration
{
    public class PushNotifications : FirstTimeUserExperience
    {
        public PushNotifications(string profile, string device) : base(profile, device) { }

        public static async Task<dynamic> SendToNativeAppAlertQueueFront(string url)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.Timeout = new TimeSpan(0, 0, 0, 0, 20000);
                    dynamic newPostBody = new JObject();
                    newPostBody.destinationType = "front";
                    newPostBody.siteId = "51";
                    newPostBody.front = "weather";
                    //List<string> alertGroupsToTarget = new List<string> {"local"};
                    //newPostBody.alertGroupsToTarget = JArray.FromObject(alertGroupsToTarget);
                    newPostBody.alertGroupsToTarget = new JArray();
                    newPostBody.alertTitle = "Alert Destination - Weather Front 123456";
                    newPostBody.alertText = 
                        "Alert Text - 1234567890~!@#$%^&*()_+`-=[]{}|;':,./<>? abcdefghijklmnopqrstuvwxyz ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890~!@#$%^&*()_+`-=[]{}|;':,./<>1234";
                    newPostBody.imageUrl = "https://url-goes-here.com";
                    List<string> alertDurationInSeconds = new List<string> {"3600"};
                    newPostBody.alertDurationInSeconds = JArray.FromObject(alertDurationInSeconds);
                    newPostBody.alertProminence = "withSound";
                    newPostBody.sentBy = "jmcghee@tegna.com";
                    newPostBody.sentById = "12345";
                                        
                    var content = new StringContent(JsonConvert.SerializeObject(newPostBody), Encoding.UTF8, "application/json");
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

        public static async Task<dynamic> SendToNativeAppAlertQueueTopicPage(string url)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.Timeout = new TimeSpan(0, 0, 0, 0, 20000);

                    dynamic newPostBody = new JObject();
                    newPostBody.destinationType = "topicPage";
                    newPostBody.siteId = "51";

                    dynamic topicPageClassification = new JObject();
                    topicPageClassification.section = "news";
                    topicPageClassification.topic = "";
                    topicPageClassification.subtopic = "";

                    newPostBody.topicPageClassification = topicPageClassification;

                    List<string> alertGroupsToTarget = new List<string> { "sports", "local" };
                    newPostBody.alertGroupsToTarget = JArray.FromObject(alertGroupsToTarget);
                    //newPostBody.alertGroupsToTarget = new JArray();
                    newPostBody.alertTitle = "Alert Destination - 'News' Topic Page123";
                    newPostBody.alertText =
                        "Alert Text - 1234567890~!@#$%^&*()_+`-=[]{}|;':,./<>? abcdefghijklmnopqrstuvwxyz ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890~!@#$%^&*()_+`-=[]{}|;':,./<>1234";
                    newPostBody.imageUrl = "https://url-goes-here.com";

                    List<string> alertDurationInSeconds = new List<string> { "3600" };
                    newPostBody.alertDurationInSeconds = JArray.FromObject(alertDurationInSeconds);
                    newPostBody.alertProminence = "withoutSound";
                    newPostBody.sentBy = "jmcghee@tegna.com";
                    newPostBody.sentById = "12345";

                    var content = new StringContent(JsonConvert.SerializeObject(newPostBody), Encoding.UTF8, "application/json");
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

        public static async Task<dynamic> SendToNativeAppAlertQueueWebView(string url)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.Timeout = new TimeSpan(0, 0, 0, 0, 20000);

                    dynamic newPostBody = new JObject();
                    newPostBody.destinationType = "webview";
                    newPostBody.siteId = "51";
                    newPostBody.webview = "weather alerts webview";
                    //List<string> alertGroupsToTarget = new List<string> { "sports", "local" };
                    //newPostBody.alertGroupsToTarget = JArray.FromObject(alertGroupsToTarget);
                    newPostBody.alertGroupsToTarget = new JArray();
                    newPostBody.alertTitle = "Alert Destination - WebView 1234567890 A";
                    newPostBody.alertText =
                        "Alert Text - 1234567890~!@#$%^&*()_+`-=[]{}|;':,./<>? abcdefghijklmnopqrstuvwxyz ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890~!@#$%^&*()_+`-=[]{}|;':,./<>1234";
                    newPostBody.imageUrl = "https://url-goes-here.com";

                    List<string> alertDurationInSeconds = new List<string> { "3600" };
                    newPostBody.alertDurationInSeconds = JArray.FromObject(alertDurationInSeconds);
                    newPostBody.alertProminence = "withSound";
                    newPostBody.sentBy = "jmcghee@tegna.com";
                    newPostBody.sentById = "12345";

                    var content = new StringContent(JsonConvert.SerializeObject(newPostBody), Encoding.UTF8, "application/json");
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

        public static async Task<dynamic> SendToNativeAppAlertQueueContent(string url)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.Timeout = new TimeSpan(0, 0, 0, 0, 20000);

                    dynamic newPostBody = new JObject();
                    newPostBody.destinationType = "content";
                    newPostBody.siteId = "51";
                    //List<string> alertGroupsToTarget = new List<string> { "sports", "local" };
                    //newPostBody.alertGroupsToTarget = JArray.FromObject(alertGroupsToTarget);
                    newPostBody.alertGroupsToTarget = new JArray();
                    newPostBody.alertTitle = "Alert Destination - Content Page 1234567";
                    newPostBody.alertText =
                        "Alert Text - 1234567890~!@#$%^&*()_+`-=[]{}|;':,./<>? abcdefghijklmnopqrstuvwxyz ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890~!@#$%^&*()_+`-=[]{}|;':,./<>1234";
                    newPostBody.imageUrl =
                        "https://media.wbir.com/assets/stage/WBIR/images/e179b83b-1a74-425a-a912-638883633c55/e179b83b-1a74-425a-a912-638883633c55_360x203.jpg";

                    List<string> alertDurationInSeconds = new List<string> { "7200" };
                    newPostBody.alertDurationInSeconds = JArray.FromObject(alertDurationInSeconds);
                    newPostBody.alertProminence = "withSound";
                    newPostBody.contentId = "c3c9dd9d-9bcd-4945-b25f-792321f7abd8";
                    newPostBody.contentSiteId = "51";
                    newPostBody.contentType = "text";
                    newPostBody.sentBy = "jmcghee@tegna.com";
                    newPostBody.sentById = "12345";

                    var content = new StringContent(JsonConvert.SerializeObject(newPostBody), Encoding.UTF8, "application/json");
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
        
        public static async Task<dynamic> SendToNativeAppAlertSpecificSubscribers(string url)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.Timeout = new TimeSpan(0, 0, 0, 0, 20000);
                    dynamic newPostBody = new JObject();
                    newPostBody.destinationType = "front";
                    newPostBody.siteId = "51";
                    newPostBody.front = "weather";
                    List<string> alertGroupsToTarget = new List<string> {"entertainment"};
                    newPostBody.alertGroupsToTarget = JArray.FromObject(alertGroupsToTarget);
                    //newPostBody.alertGroupsToTarget = new JArray();
                    newPostBody.alertTitle = "Entertainment Subscribers Only - Weather";
                    newPostBody.alertText =
                        "Alert Text - 1234567890~!@#$%^&*()_+`-=[]{}|;':,./<>? abcdefghijklmnopqrstuvwxyz ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890~!@#$%^&*()_+`-=[]{}|;':,./<>1234";
                    newPostBody.imageUrl = "https://url-goes-here.com";
                    List<string> alertDurationInSeconds = new List<string> { "3600" };
                    newPostBody.alertDurationInSeconds = JArray.FromObject(alertDurationInSeconds);
                    newPostBody.alertProminence = "withSound";
                    newPostBody.sentBy = "jmcghee@tegna.com";
                    newPostBody.sentById = "12345";

                    var content = new StringContent(JsonConvert.SerializeObject(newPostBody), Encoding.UTF8, "application/json");
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
    }
}
