using System;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Net.Http;
using Newtonsoft.Json;

namespace BrowserStackIntegration
{
    public class LiveVideo : WatchPage
    {
        public LiveVideo(string profile, string device) : base(profile, device) { }

        public static async Task<dynamic> GetStationsWithCurrentLiveVideo(string url)
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
                string message = $"GetResponseAsync - Error getting response from {url}.Ex: {ex}";
                Debug.WriteLine(message);
                Console.WriteLine(message);
                throw;
            }
        }
    }
}
