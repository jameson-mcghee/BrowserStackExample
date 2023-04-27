using System;
using System.Threading.Tasks;
using System.Diagnostics;
using RestSharp;

namespace BrowserStackIntegration
{
    public class PushNotifications : FirstTimeUserExperience
    {
        public PushNotifications(string profile, string device) : base(profile, device) { }
        public string url = "https://api-stage.example-tv.com/mobile/configuration-rw/" +
            "SendToNativeAppAlertQueueTest/?subscription-key=fdd842925eb6445f85adb84b30d22838";

        public static async Task<dynamic> SendToNativeAppAlertQueueFront(string url)
        {
            try
            {
                var client = new RestClient(url);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("undefined", "{\r\n  \"destinationType\": \"front\"," +
                    "\r\n  \"siteId\": \"51\",\r\n  \"front\": \"weather\", \r\n  \"alertGroupsToTarget\": []," +
                    "\r\n  \"alertTitle\": \"Test Alert Destination - Weather Front 1\"," +
                    "\r\n  \"alertText\": \"Test Alert Text - Automation !@#$%^&*()_+`-=[]{}|;':,./<>? " +
                    "abcdefghijklmnopqrstuvwxyz ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890~!@#$%^&*()_+`-=[]{}|;':,./<\"," +
                    "\r\n  \"imageUrl\": \"https://media.wbir.com/assets/stage/WBIR/images/e179b83b-1a74-425a-a912-" +
                    "638883633c55/e179b83b-1a74-425a-a912-638883633c55_360x203.jpg\"," +
                    "\r\n  \"alertDurationInSeconds\": 7200,\r\n  \"alertProminence\": \"withSound\"," +
                    "\r\n  \"sentBy\":\"jmcghee@example.com\",\r\n  \"sentById\": \"12345\"\r\n}", ParameterType.RequestBody);
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
                    "\r\n  \"alertGroupsToTarget\": [ \r\n    \"sports\",\r\n    \"local\"\r\n  ]," +
                    "\r\n  \"alertTitle\": \"Test Alert Dest - Topic Page Local News1\"," +
                    "\r\n  \"alertText\": \"Test Alert Text - Automation !@#$%^&*()_+`-=[]{}|;':,./<>? abcdefghijklmnopqrstuvwxyz " +
                    "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890~!@#$%^&*()_+`-=[]{}|;':,./<\"," +
                    "\r\n  \"imageUrl\": \"https://media.wbir.com/assets/stage/WBIR/images/e179b83b-1a74-425a-a912-" +
                    "638883633c55/e179b83b-1a74-425a-a912-638883633c55_360x203.jpg\"," +
                    "\r\n  \"alertDurationInSeconds\": 3600," +
                    "\r\n  \"alertProminence\": \"withSound\",\r\n  \"sentBy\":\"jmcghee@example.com\"," +
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

        public static async Task<dynamic> SendToNativeAppAlertQueueWebView(string url)
        {
            try
            {
                var client = new RestClient(url);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("undefined", "{\r\n  \"destinationType\": \"webview\",\r\n  \"siteId\": \"51\"," +
                    "\r\n  \"webview\": \"weather alerts webview\",\r\n  \"alertGroupsToTarget\": []," +
                    "\r\n  \"alertTitle\": \"Test Alert Destination - Web View Page 1\"," +
                    "\r\n  \"alertText\": \"Test Alert Text - Automation !@#$%^&*()_+`-=[]{}|;':,./<>? " +
                    "abcdefghijklmnopqrstuvwxyz ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890~!@#$%^&*()_+`-=[]{}|;':,./<\"," +
                    "\r\n  \"imageUrl\": \"https://media.wbir.com/assets/stage/WBIR/images/e179b83b-1a74-425a-a912-" +
                    "638883633c55/e179b83b-1a74-425a-a912-638883633c55_360x203.jpg\"," +
                    "\r\n  \"alertDurationInSeconds\": 7200,\r\n  \"alertProminence\": \"withSound\"," +
                    "\r\n  \"sentBy\":\"jmcghee@example.com\",\r\n  \"sentById\": \"12345\"\r\n}", ParameterType.RequestBody);
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

        public static async Task<dynamic> SendToNativeAppAlertQueueArticle(string url)
        {
            try
            {
                var client = new RestClient(url);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("undefined", "{\r\n    \"destinationType\": \"content\"," +
                    "\r\n    \"siteId\": \"51\",\r\n    \"alertGroupsToTarget\": []," +
                    "\r\n    \"alertTitle\": \"Test Alert Destination - Content Page 12\"," +
                    "\r\n    \"alertText\": \"Test Alert Text - Automation !@#$%^&*()_+`-=[]{}|;':,./<>? " +
                    "abcdefghijklmnopqrstuvwxyz ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890~!@#$%^&*()_+`-=[]{}|;':,./<\"," +
                    "\r\n    \"imageUrl\": \"https://media.wbir.com/assets/stage/WBIR/images/e179b83b-1a74-425a-a912-" +
                    "638883633c55/e179b83b-1a74-425a-a912-638883633c55_360x203.jpg\"," +
                    "\r\n    \"alertDurationInSeconds\": 7200,\r\n    \"alertProminence\": \"withSound\"," +
                    "\r\n    \"contentId\": \"cb682041-1646-41e3-a394-3b85da28e95c\"," +
                    "\r\n    \"contentSiteId\": \"51\",\r\n    \"contentType\": \"text\"," +
                    "\r\n    \"sentBy\": \"jmcghee@example.com\",\r\n    \"sentById\":\"12345\"\r\n}", ParameterType.RequestBody);
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
                request.AddParameter("undefined", "{\r\n  \"destinationType\": \"front\",\r\n  \"siteId\": \"51\"," +
                    "\r\n  \"front\": \"weather\", \r\n  \"alertGroupsToTarget\": [\"entertainment\"]," +
                    "\r\n  \"alertTitle\": \"Entertainment Subs Only Test – Weather 1\"," +
                    "\r\n  \"alertText\": \"Alert Text - Automation !@#$%^&*()_+`-=[]{}|;':,./<>? " +
                    "abcdefghijklmnopqrstuvwxyz ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890~!@#$%^&*()_+`-=[]{}|;':,./<>1234\"," +
                    "\r\n  \"imageUrl\": \"https://media.wbir.com/assets/stage/WBIR/images/e179b83b-1a74-425a-a912-" +
                    "638883633c55/e179b83b-1a74-425a-a912-638883633c55_360x203.jpg\"," +
                    "\r\n  \"alertDurationInSeconds\": 3600,\r\n  \"alertProminence\": \"withSound\"," +
                    "\r\n  \"sentBy\":\"jmcghee@example.com\",\r\n  \"sentById\": \"12345\"\r\n}", ParameterType.RequestBody);
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
                    "\r\n    \"alertTitle\": \"Test Alert Destination - Promo Item Page\"," +
                    "\r\n    \"alertText\": \"Test Alert Text - Automation !@#$%^&*()_+`-=[]{}|;':,./<>? " +
                    "abcdefghijklmnopqrstuvwxyz ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890~!@#$%^&*()_+`-=[]{}|;':,./<\"," +
                    "\r\n    \"imageUrl\": \"https://media.wbir.com/assets/stage/WBIR/images/abeb2040-9e92-4ce3-bf1b-" +
                    "31701db32136/abeb2040-9e92-4ce3-bf1b-31701db32136_750x422.jpg\"," +
                    "\r\n    \"alertDurationInSeconds\": 7200,\r\n    \"alertProminence\": \"withSound\"," +
                    "\r\n    \"contentId\": \"c42089cd-ee13-4b31-b59c-2e19f7b72b63\"," +
                    "\r\n    \"contentSiteId\": \"51\",\r\n    \"contentType\": \"text\"," +
                    "\r\n    \"sentBy\": \"jmcghee@example.com\",\r\n    \"sentById\":\"12345\"\r\n}", ParameterType.RequestBody);
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
                    "\r\n    \"alertTitle\": \"Test Alert Destination - Video Content12\"," +
                    "\r\n    \"alertText\": \"Test Alert Text - Automation !@#$%^&*()_+`-=[]{}|;':,./<>? " +
                    "abcdefghijklmnopqrstuvwxyz ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890~!@#$%^&*()_+`-=[]{}|;':,./<\"," +
                    "\r\n    \"imageUrl\": \"https://media.wbir.com/assets/stage/WBIR/images/17b430cb-180a-4a55-8549-" +
                    "fd52d468b4b7/17b430cb-180a-4a55-8549-fd52d468b4b7_360x203.jpg\"," +
                    "\r\n    \"alertDurationInSeconds\": 7200,\r\n    \"alertProminence\": \"withSound\"," +
                    "\r\n    \"contentId\": \"c5821ce8-a588-4cd5-aade-d1cbb33c44f9\"," +
                    "\r\n    \"contentSiteId\": \"51\",\r\n    \"contentType\": \"video\"," +
                    "\r\n    \"sentBy\": \"jmcghee@example.com\",\r\n    \"sentById\":\"12345\"\r\n}", ParameterType.RequestBody);
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
                    "\r\n    \"alertTitle\": \"Test Alert Destination - Gallery Content\"," +
                    "\r\n    \"alertText\": \"Test Alert Text - Automation !@#$%^&*()_+`-=[]{}|;':,./<>? " +
                    "abcdefghijklmnopqrstuvwxyz ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890~!@#$%^&*()_+`-=[]{}|;':,./<\"," +
                    "\r\n    \"imageUrl\": \"https://media.wbir.com/assets/WBIR/images/54827918/54827918_360x203.jpg\"," +
                    "\r\n    \"alertDurationInSeconds\": 7200,\r\n    \"alertProminence\": \"withSound\"," +
                    "\r\n    \"contentId\": \"54815325\"," +
                    "\r\n    \"contentSiteId\": \"51\",\r\n    \"contentType\": \"text\"," +
                    "\r\n    \"sentBy\": \"jmcghee@example.com\",\r\n    \"sentById\":\"12345\"\r\n}", ParameterType.RequestBody);
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
