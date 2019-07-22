using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace MobileAppTests
{
    public class StationsWithLiveVideo
    {
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
                //Debug.ReadLine();
                Console.WriteLine(message);
                throw;
            }
        }

        [Test]
        public async Task WhichStationsArePlayingLiveVideo()
        {
            var trueCount = 0;
            Dictionary<string, int> stationIDs = new Dictionary<string, int>()
            {
                {"WBIR", 51}, {"KSDK", 63}, {"WUSA", 65}, {"WTSP", 67}, {"WZZM", 69},
                {"WGRZ", 71}, {"KUSA", 73}, {"KPNX", 75}, {"WTLV", 77}, {"WFMY", 83},
                {"WXIA", 85}, {"KARE", 89}, {"KTHV", 91}, {"WMAZ", 93}, {"WKYC", 95},
                {"WCSH/NCM", 97}, {"WLBZ/NCM", 99}, {"WLTX", 101}, {"KXTV", 103},
                {"KVUE", 269}, {"KENS", 273}, {"WCNC", 275}, {"KTVB", 277}, {"KING", 281},
                {"KGW", 283}, {"KHOU", 285}, {"WFAA", 287}, {"WWL", 289}, {"WVEC", 291},
                {"KREM", 293}, {"WHAS", 417}, {"KAGS", 499}, {"KCEN", 500}, {"KYTX", 501},
                {"KBMT", 502}, {"KIII", 503}, {"KIDY", 504}, {"KFMB", 509}, {"WTOL", 512},
                {"KWES", 513}
            };

            foreach (KeyValuePair<string, int> stationID in stationIDs)
            {
                dynamic response = await GetStationsWithCurrentLiveVideo
                    ("https://api-stage.tegna-tv.com/mobile/content-ro/schedule/getCurrentOrNextLiveStream/" + stationID.Value + "?subscription-key=fdd842925eb6445f85adb84b30d22838");
                if (response.Count == 0)
                {
                    throw new Exception("No information in the 'GetCurrentOrNextLiveVideoStream' API response.");
                }
                if (response.isLiveNow == "true")
                {
                    Console.WriteLine($"Station {stationID.Value} {stationID.Key} - is live now.");
                    trueCount++;
                }
                if (response.isLiveNow == "false")
                {
                    
                }
            }

            if (trueCount == 0)
            {
                Console.WriteLine("No stations are Streaming Live Video right now.");
            }
        }
    }
}
