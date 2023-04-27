using Newtonsoft.Json;
using RestSharp;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using BrowserStackIntegration;

namespace BrowserStackExample
{
    public class GetScreenandPageConfigs : GlobalMethods
    {
        public GetScreenandPageConfigs(string profile, string device) : base(profile, device){}

        public static async Task<dynamic> GetPageConfigRequest(int siteId)
        {
            string pageConfigUrl = 
                "https://api-stage.example-tv.com/mobile/configuration-ro/getStationAppConfig/" + siteId + "/mobile?subscription-key=fdd842925eb6445f85adb84b30d22838";

            try
            {
                var client = new RestClient(pageConfigUrl);
                var request = new RestRequest(Method.GET);
                IRestResponse response = client.Execute(request);
                var responseString = response.Content;
                return JsonConvert.DeserializeObject(responseString);
            }
            catch (Exception ex)
            {
                string message = $"PostResponseAsync - Error getting response from {pageConfigUrl}.Ex: {Environment.NewLine}{ex}";
                Debug.WriteLine(message);
                Console.WriteLine(message);
                throw;
            }

        }

        public static async Task<dynamic> GetScreenConfigRequestByPageName(string pageName)
        {
            string screenConfigByNameUrl = 
                "https://api-stage.example-tv.com/mobile/configuration-rw/getScreenConfigByName?subscription-key=fdd842925eb6445f85adb84b30d22838";

            try
            {
                var client = new RestClient(screenConfigByNameUrl);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("undefined", "{\n    \"siteId\": \"51\"," +
                    "\n    \"deviceId\": \"12345\",\n    \"applicationId\": \"67890\"," +
                    "\n    \"pageName\": \"" + pageName + "\"\n}", ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                var responseString = response.Content;
                return JsonConvert.DeserializeObject(responseString);
            }
            catch (Exception ex)
            {
                string message = $"PostResponseAsync - Error getting response from {screenConfigByNameUrl}.Ex: {Environment.NewLine}{ex}";
                Debug.WriteLine(message);
                Console.WriteLine(message);
                throw;
            }

        }

        public static async Task<dynamic> GetScreenConfigRequestByPageConfigID(string pageConfid)
        {
            string screenConfigByPageConfigIDUrl = 
                "https://api-stage.example-tv.com/mobile/configuration-ro/getScreenConfig?subscription-key=fdd842925eb6445f85adb84b30d22838";

            try
            {
                var client = new RestClient(screenConfigByPageConfigIDUrl);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("undefined", "{\n    \"siteId\": \"51\"," +
                    "\n    \"deviceId\": \"12345\",\n    \"applicationId\": \"67890\"," +
                    "\n    \"pageConfigId\": \"" + pageConfid + "\"\n}", ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                var responseString = response.Content;
                return JsonConvert.DeserializeObject(responseString);
            }
            catch (Exception ex)
            {
                string message = $"PostResponseAsync - Error getting response from {screenConfigByPageConfigIDUrl}.Ex: {Environment.NewLine}{ex}";
                Debug.WriteLine(message);
                Console.WriteLine(message);
                throw;
            }
        }
    }
}
