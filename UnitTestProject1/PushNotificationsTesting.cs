using NUnit.Framework;
using RestSharp;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace NonMobileAppTests
{
    public class PushNotificationsTesting
    {
        public string url = "https://api-stage.tegna-tv.com/mobile/configuration-rw/" +
            "SendToNativeAppAlertQueueTest/?subscription-key=fdd842925eb6445f85adb84b30d22838";

        [Test]
        public async Task FrontAlert()
        {
            await SendToNativeAppAlertQueueFront(url);
        }
        [Test]
        public async Task ArticleAlert()
        {
            await SendToNativeAppAlertQueueArticle(url);
        }
        [Test]
        public async Task PromoItemAlert()
        {
            await SendToNativeAppAlertQueuePromoItem(url);
        }
        [Test]
        public async Task VideoContentAlert()
        {
            await SendToNativeAppAlertQueueVideoContent(url);
        }
        [Test]
        public async Task TopicPageAlert()
        {
            await SendToNativeAppAlertQueueTopicPage(url);
        }
        [Test]
        public async Task SpecificSubscribersAlert()
        {
            await SendToNativeAppAlertQueueSpecificSubscribers(url);
        }
        [Test]
        public async Task WebViewAlert()
        {
            await SendToNativeAppAlertQueueWebView(url);
        }
        
        //[Test]  //This is not a valid alert at present
        public async Task GalleryContentAlert()
        {
            await SendToNativeAppAlertQueueGalleryContent(url);
        }

        public static async Task<dynamic> SendToNativeAppAlertQueueFront(string url)
        {
            try
            {
                var client = new RestClient(url);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("undefined", "{\r\n  \"destinationType\": \"front\"," +
                    "\r\n  \"siteId\": \"51\",\r\n  \"front\": \"weather\", \r\n  \"alertGroupsToTarget\": []," +
                    "\r\n  \"alertTitle\": \"Test Alert - Destination: Weather Front1\"," +
                    "\r\n  \"alertText\": \"Test Alert Text - Automation !@#$%^&*()_+`-=[]{}|;':,./<>? " +
                    "abcdefghijklmnopqrstuvwxyz ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890~!@#$%^&*()_+`-=[]{}|;':,./<\"," +
                    "\r\n  \"imageUrl\": \"https://s3.amazonaws.com/tgna-assets/WTSP/images/c5b41202-24b7-46d2-81fb-" +
                    "2b9fd67e3399/c5b41202-24b7-46d2-81fb-2b9fd67e3399_540x304.png\"," +
                    "\r\n  \"alertDurationInSeconds\": 7200,\r\n  \"alertProminence\": \"withSound\"," +
                    "\r\n  \"sentBy\":\"jmcghee@tegna.com\",\r\n  \"sentById\": \"12345\"\r\n}", ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                return response;
            }
            catch (Exception ex)
            {
                string message = $@"PostResponseAsync - Error getting response from {url}.Ex:{Environment.NewLine}{ex}";
                Debug.WriteLine(message);
                Console.WriteLine(message);
                throw;
            }
        }

        public static async Task<dynamic> SendToNativeAppAlertQueueTopicPage(string url)
        {
            try
            {
                var client = new RestClient(url);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("undefined", "{\r\n  \"destinationType\": \"topicPage\"," +
                    "\r\n  \"siteId\": \"51\",\r\n  \"topicPageClassification\": { \r\n    \"section\": \"news\"," +
                    "\r\n    \"subsection\": \"local\",\r\n    \"topic\": \"\",\r\n    \"subtopic\": \"\"\r\n  }," +
                    "\r\n  \"alertGroupsToTarget\": [],\r\n  \"alertTitle\": \"Test Alert - Dest: Topic Page Local News\"," +
                    "\r\n  \"alertText\": \"Test Alert Text - Automation !@#$%^&*()_+`-=[]{}|;':,./<>? abcdefghijklmnopqrstuvwxyz " +
                    "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890~!@#$%^&*()_+`-=[]{}|;':,./<\"," +
                    "\r\n  \"imageUrl\": \"https://s3.amazonaws.com/tgna-assets/stage/WBIR/images/f3b211ee-18c7-4c92-a8a1-02e8ed56b211" +
                    "/f3b211ee-18c7-4c92-a8a1-02e8ed56b211_540x304.jpg\"," +
                    "\r\n  \"alertDurationInSeconds\": 3600," +
                    "\r\n  \"alertProminence\": \"withSound\",\r\n  \"sentBy\":\"jmcghee@tegna.com\"," +
                    "\r\n  \"sentById\": \"12345\"\r\n}\r\n", ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                return response;
            }
            catch (Exception ex)
            {
                string message = $@"PostResponseAsync - Error getting response from {url}.Ex:{Environment.NewLine}{ex}";
                Debug.WriteLine(message);
                Console.WriteLine(message);
                throw;
            }
        }
                
        public static async Task<dynamic> SendToNativeAppAlertQueueArticle(string url)
        {
            try
            {
                var client = new RestClient(url);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("undefined", "{\r\n    \"destinationType\": \"content\"," +
                    "\r\n    \"siteId\": \"51\",\r\n    \"alertGroupsToTarget\": []," +
                    "\r\n    \"alertTitle\": \"Test Alert - Destination: Content Page 1\"," +
                    "\r\n    \"alertText\": \"Test Alert Text - Automation !@#$%^&*()_+`-=[]{}|;':,./<>? " +
                    "abcdefghijklmnopqrstuvwxyz ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890~!@#$%^&*()_+`-=[]{}|;':,./<\"," +
                    "\r\n    \"imageUrl\": \"https://media.wbir.com/assets/stage/WLTX/images/06acaec3-de76-41c2-" +
                    "9cd6-da479c90e1f7/06acaec3-de76-41c2-9cd6-da479c90e1f7_750x422.jpg\"," +
                    "\r\n    \"alertDurationInSeconds\": 7200,\r\n    \"alertProminence\": \"withSound\"," +
                    "\r\n    \"contentId\": \"cb682041-1646-41e3-a394-3b85da28e95c\"," +
                    "\r\n    \"contentSiteId\": \"51\",\r\n    \"contentType\": \"text\"," +
                    "\r\n    \"sentBy\": \"jmcghee@tegna.com\",\r\n    \"sentById\":\"12345\"\r\n}", ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                return response;
            }
            catch (Exception ex)
            {
                string message = $"PostResponseAsync - Error getting response from {url}.Ex:{Environment.NewLine}{ex}";
                Debug.WriteLine(message);
                Console.WriteLine(message);
                throw;
            }
        }

        public static async Task<dynamic> SendToNativeAppAlertQueueSpecificSubscribers(string url)
        {
            try
            {
                var client = new RestClient(url);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("undefined", "{\r\n  \"destinationType\": \"topicPage\",\r\n  \"siteId\": \"51\"," +
                    "\r\n  \"topicPageClassification\": { \r\n    \"section\": \"money\",\r\n    \"subsection\": \"\"," +
                    "\r\n    \"topic\": \"\",\r\n    \"subtopic\": \"\"\r\n  }, \r\n  \"alertGroupsToTarget\": [\"money\"]," +
                    "\r\n  \"alertTitle\": \"Test Alert – Money Subscribers Only12345\"," +
                    "\r\n  \"alertText\": \"Alert Text - Automation !@#$%^&*()_+`-=[]{}|;':,./<>? " +
                    "abcdefghijklmnopqrstuvwxyz ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890~!@#$%^&*()_+`-=[]{}|;':,./<>1234\"," +
                    "\r\n  \"imageUrl\": \"https://s3.amazonaws.com/tgna-assets/WHAS/images/86d5937a-a5c5-40e1-922b-" +
                    "f7c24e29ef6d/86d5937a-a5c5-40e1-922b-f7c24e29ef6d_540x304.jpg\"," +
                    "\r\n  \"alertDurationInSeconds\": 3600,\r\n  \"alertProminence\": \"withSound\"," +
                    "\r\n  \"sentBy\":\"jmcghee@tegna.com\",\r\n  \"sentById\": \"12345\"\r\n}", ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                return response;
            }
            catch (Exception ex)
            {
                string message = $"PostResponseAsync - Error getting response from {url}.Ex:{Environment.NewLine}{ex}";
                Debug.WriteLine(message);
                Console.WriteLine(message);
                throw;
            }
        }

        public static async Task<dynamic> SendToNativeAppAlertQueuePromoItem(string url)
        {
            try
            {
                var client = new RestClient(url);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("undefined", "{\r\n    \"destinationType\": \"content\"," +
                    "\r\n    \"siteId\": \"51\",\r\n    \"alertGroupsToTarget\": []," +
                    "\r\n    \"alertTitle\": \"Test Alert - Destination: PromoItem Page\"," +
                    "\r\n    \"alertText\": \"Test Alert Text - Automation !@#$%^&*()_+`-=[]{}|;':,./<>? " +
                    "abcdefghijklmnopqrstuvwxyz ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890~!@#$%^&*()_+`-=[]{}|;':,./<\"," +
                    "\r\n    \"imageUrl\": \"https://s3.amazonaws.com/tgna-assets/stage/WBIR/images/" +
                    "cafc4fe3-c0c9-48cf-91e0-2dc1848cc3ad/cafc4fe3-c0c9-48cf-91e0-2dc1848cc3ad.jpg\"," +
                    "\r\n    \"alertDurationInSeconds\": 7200,\r\n    \"alertProminence\": \"withSound\"," +
                    "\r\n    \"contentId\": \"55f2d51e-33ed-4827-863a-2cd7b3663713\"," +
                    "\r\n    \"contentSiteId\": \"51\",\r\n    \"contentType\": \"promoitem\"," +
                    "\r\n    \"sentBy\": \"jmcghee@tegna.com\",\r\n    \"sentById\":\"12345\"\r\n}", ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                return response;
            }
            catch (Exception ex)
            {
                string message = $"PostResponseAsync - Error getting response from {url}.Ex:{Environment.NewLine}{ex}";
                Debug.WriteLine(message);
                Console.WriteLine(message);
                throw;
            }
        }

        public static async Task<dynamic> SendToNativeAppAlertQueueVideoContent(string url)
        {
            try
            {
                var client = new RestClient(url);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("undefined", "{\r\n    \"destinationType\": \"content\"," +
                    "\r\n    \"siteId\": \"51\",\r\n    \"alertGroupsToTarget\": []," +
                    "\r\n    \"alertTitle\": \"Test Alert - Destination: Video Content1\"," +
                    "\r\n    \"alertText\": \"Test Alert Text - Automation !@#$%^&*()_+`-=[]{}|;':,./<>? " +
                    "abcdefghijklmnopqrstuvwxyz ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890~!@#$%^&*()_+`-=[]{}|;':,./<\"," +
                    "\r\n    \"imageUrl\": \"https://media.wbir.com/assets/stage/WBIR/images/17b430cb-180a-4a55-8549-" +
                    "fd52d468b4b7/17b430cb-180a-4a55-8549-fd52d468b4b7_360x203.jpg\"," +
                    "\r\n    \"alertDurationInSeconds\": 7200,\r\n    \"alertProminence\": \"withSound\"," +
                    "\r\n    \"contentId\": \"c5821ce8-a588-4cd5-aade-d1cbb33c44f9\"," +
                    "\r\n    \"contentSiteId\": \"51\",\r\n    \"contentType\": \"video\"," +
                    "\r\n    \"sentBy\": \"jmcghee@tegna.com\",\r\n    \"sentById\":\"12345\"\r\n}", ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                return response;
            }
            catch (Exception ex)
            {
                string message = $"PostResponseAsync - Error getting response from {url}.Ex:{Environment.NewLine}{ex}";
                Debug.WriteLine(message);
                Console.WriteLine(message);
                throw;
            }
        }

        public static async Task<dynamic> SendToNativeAppAlertQueueWebView(string url)
        {
            try
            {
                var client = new RestClient(url);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("undefined", "{\r\n  \"destinationType\": \"webview\",\r\n  \"siteId\": \"51\"," +
                    "\r\n  \"webview\": \"weather alerts webview\",\r\n  \"alertGroupsToTarget\": []," +
                    "\r\n  \"alertTitle\": \"Test Alert - Destination: Web View Page1\"," +
                    "\r\n  \"alertText\": \"Test Alert Text - Automation !@#$%^&*()_+`-=[]{}|;':,./<>? " +
                    "abcdefghijklmnopqrstuvwxyz ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890~!@#$%^&*()_+`-=[]{}|;':,./<\"," +
                    "\r\n  \"imageUrl\": \"https://media.wbir.com/assets/stage/WBIR/images/e179b83b-1a74-425a-a912-" +
                    "638883633c55/e179b83b-1a74-425a-a912-638883633c55_360x203.jpg\"," +
                    "\r\n  \"alertDurationInSeconds\": 7200,\r\n  \"alertProminence\": \"withSound\"," +
                    "\r\n  \"sentBy\":\"jmcghee@tegna.com\",\r\n  \"sentById\": \"12345\"\r\n}", ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                return response;
            }
            catch (Exception ex)
            {
                string message = $"PostResponseAsync - Error getting response from {url}.Ex:{Environment.NewLine}{ex}";
                Debug.WriteLine(message);
                Console.WriteLine(message);
                throw;
            }
        }

        public static async Task<dynamic> SendToNativeAppAlertQueueGalleryContent(string url)
        {
            try
            {
                var client = new RestClient(url);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("undefined", "{\r\n    \"destinationType\": \"content\"," +
                    "\r\n    \"siteId\": \"51\",\r\n    \"alertGroupsToTarget\": []," +
                    "\r\n    \"alertTitle\": \"Test Alert - Destination: Gallery Page12\"," +
                    "\r\n    \"alertText\": \"Test Alert Text - Automation !@#$%^&*()_+`-=[]{}|;':,./<>? " +
                    "abcdefghijklmnopqrstuvwxyz ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890~!@#$%^&*()_+`-=[]{}|;':,./<\"," +
                    "\r\n    \"imageUrl\": \"https://media.wbir.com/assets/WBIR/images/54827918/54827918_360x203.jpg\"," +
                    "\r\n    \"alertDurationInSeconds\": 7200,\r\n    \"alertProminence\": \"withSound\"," +
                    "\r\n    \"contentId\": \"54815325\"," +
                    "\r\n    \"contentSiteId\": \"51\",\r\n    \"contentType\": \"gallery\"," +
                    "\r\n    \"sentBy\": \"jmcghee@tegna.com\",\r\n    \"sentById\":\"12345\"\r\n}", ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                return response;
            }
            catch (Exception ex)
            {
                string message = $"PostResponseAsync - Error getting response from {url}.Ex:{Environment.NewLine}{ex}";
                Debug.WriteLine(message);
                Console.WriteLine(message);
                throw;
            }
        }
    }
}
