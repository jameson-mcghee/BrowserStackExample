using NUnit.Framework;
using RestSharp;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace NonMobileAppTests
{
    public class SevereWeatherAlertTesting
    {
        public string weatherAlertUrl = "https://api-stage.tegna-tv.com/mobile/configuration-rw/" +
            "sendToTestWeatherAlertQueueAsync?subscription-key=dbaa32ce879e43a6a24d18b55ef5279c";

        [Test]
        public async Task SevereWeatherAlertTest()
        {
            await SendToTestWeatherAlertQueueAsync(weatherAlertUrl);
        }
        [Test]
        public async Task SevereWeatherAlertExpirationTest()
        {
            await SendToTestWeatherAlertQueueAsyncExpire(weatherAlertUrl);
        }

        public async Task<dynamic> SendToTestWeatherAlertQueueAsync(string url)
        {
            Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;

            try
            {
                var client = new RestClient(url);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("undefined", "{\n        \"Id\": null,\n        \"CountyFips\": \"53063\"," +
                    "\n        \"StateAbbr\": \"WA\",\n        \"AlertType\": \"Air Quality Alert\"," +
                    "\n        \"StartTime\": \"8/9/2019 5:08:00 PM\",\n        \"EndTime\": \"8/23/2019 5:08:00 PM\"," +
                    "\n        \"Headline\": \"Air Quality Alert\",\n        \"Bulletin\": \"WAC019-043-051-063-065-101715- " +
                    "Ferry-Lincoln-Pend Oreille-Spokane-Stevens- Including the cities of Republic, Inchelium, Keller, Curlew,  " +
                    "Danville, Laurier, Davenport, Odessa, Wilbur, Reardan, Sprague,  Newport, Metaline Falls, Ione, Cusick, " +
                    "Diamond Lake, Spokane,  Airway Heights, Medical Lake, Cheney, Rockford, Liberty Lake,  Deer Park, Colville, " +
                    "Chewelah, Kettle Falls, Springdale,  and Northport 1002 AM PDT Fri Aug 9 2019" +
                    "\\n\\nAn Air Quality Alert has been issued by the following agencies:\\n\\nWashington Department of Ecology " +
                    "in Spokane Spokane Tribe Kalispel Indian Community Colville Confederated Tribes Spokane Regional Clean Air Agency" +
                    "\\n\\nWashington Counties within the Air Quality  Alert Include:\\n\\nFerry  Lincoln Pend Oreille Spokane Stevens" +
                    "\\n\\nAir quality will vary from unhealthy to moderate and good  across portions of Northeast Washington due to " +
                    "smoke from regional  and local fires. Cooler and wetter weather over the weekend is expected to allow improvement. " +
                    "\\n\\nChildren, the elderly, and individuals with respiratory illnesses  are most at risk of serious health effects. " +
                    "If you experience  respiratory distress, you should speak with your physician.\\n\\nFor additional information on " +
                    "wildland fire smoke impacting  Washington visit the Washington smoke blog at  http://wasmoke.blogspot.com and for current " +
                    "Washington air quality  levels, visit https://fortress.wa.gov/ecy/enviwa/ or airnow.gov. You  may also contact your local " +
                    "air quality agency.\\n\\n\\n\\n\\n\\n \",\n        \"Url\": null,\n        \"Category\": \"\",\n        \"Urgency\": \"\"," +
                    "\n        \"Severity\": null,\n        \"Certainty\": \"\",\n        \"GeographicName\": \"Spokane\"," +
                    "\n        \"StateName\": \"Washington\",\n        \"CountyName\": \"Spokane\",\n        \"Title\": \"Spokane County, Washington\"," +
                    "\n        \"DateAdded\": \"8/9/2019 5:08:55 PM\",\n        \"CityId\": null,\n        \"Locations\": [\n            {" +
                    "\n                \"Latitude\": 35.9606,\n                \"Longitude\": -83.9207\n            }" +
                    "\n        ],\n        \"key\": \"TestSpokane_WA_Air Quality Alert_" + unixTimestamp + "\"\n    }", ParameterType.RequestBody);
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

        public async Task<dynamic> SendToTestWeatherAlertQueueAsyncExpire(string url)
        {
            Int32 unixTimestamp = (Int32)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
            DateTime dt = DateTime.Now;
            string expireTime = dt.AddHours(3).AddSeconds(30).ToString("G");

            try
            {
                var client = new RestClient(url);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("undefined", "{\n        \"Id\": null,\n        \"CountyFips\": \"53063\"," +
                    "\n        \"StateAbbr\": \"WA\",\n        \"AlertType\": \"Air Quality Alert\"," +
                    "\n        \"StartTime\": \"8/9/2019 5:08:00 PM\",\n        \"EndTime\": \"" + expireTime + "\"," +
                    "\n        \"Headline\": \"Air Quality Alert\",\n        \"Bulletin\": \"WAC019-043-051-063-065-101715- " +
                    "Ferry-Lincoln-Pend Oreille-Spokane-Stevens- Including the cities of Republic, Inchelium, Keller, Curlew,  " +
                    "Danville, Laurier, Davenport, Odessa, Wilbur, Reardan, Sprague,  Newport, Metaline Falls, Ione, Cusick, " +
                    "Diamond Lake, Spokane,  Airway Heights, Medical Lake, Cheney, Rockford, Liberty Lake,  Deer Park, Colville, " +
                    "Chewelah, Kettle Falls, Springdale,  and Northport 1002 AM PDT Fri Aug 9 2019" +
                    "\\n\\nAn Air Quality Alert has been issued by the following agencies:\\n\\nWashington Department of Ecology " +
                    "in Spokane Spokane Tribe Kalispel Indian Community Colville Confederated Tribes Spokane Regional Clean Air Agency" +
                    "\\n\\nWashington Counties within the Air Quality  Alert Include:\\n\\nFerry  Lincoln Pend Oreille Spokane Stevens" +
                    "\\n\\nAir quality will vary from unhealthy to moderate and good  across portions of Northeast Washington due to " +
                    "smoke from regional  and local fires. Cooler and wetter weather over the weekend is expected to allow improvement. " +
                    "\\n\\nChildren, the elderly, and individuals with respiratory illnesses  are most at risk of serious health effects. " +
                    "If you experience  respiratory distress, you should speak with your physician.\\n\\nFor additional information on " +
                    "wildland fire smoke impacting  Washington visit the Washington smoke blog at  http://wasmoke.blogspot.com and for current " +
                    "Washington air quality  levels, visit https://fortress.wa.gov/ecy/enviwa/ or airnow.gov. You  may also contact your local " +
                    "air quality agency.\\n\\n\\n\\n\\n\\n \",\n        \"Url\": null,\n        \"Category\": \"\",\n        \"Urgency\": \"\"," +
                    "\n        \"Severity\": null,\n        \"Certainty\": \"\",\n        \"GeographicName\": \"Spokane\"," +
                    "\n        \"StateName\": \"Washington\",\n        \"CountyName\": \"Spokane\",\n        \"Title\": \"Spokane County, Washington\"," +
                    "\n        \"DateAdded\": \"8/9/2019 5:08:55 PM\",\n        \"CityId\": null,\n        \"Locations\": [\n            {" +
                    "\n                \"Latitude\": 35.9606,\n                \"Longitude\": -83.9207\n            }" +
                    "\n        ],\n        \"key\": \"TestSpokane_WA_Air Quality Alert_" + unixTimestamp + "\"\n    }", ParameterType.RequestBody);
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
    }
}
