using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace NonMobileAppTests
{
    public class StationsWithLiveVideo
    {
        [Test]
        public async Task WhichStationsArePlayingLiveVideoOnStaging()
        {
            var trueCount = 0;
            Dictionary<string, int> stationIDs = new Dictionary<string, int>()
            {
                {"WBIR", 51}, {"KSDK", 63}, {"WUSA", 65}, {"WTSP", 67}, {"WZZM", 69},
                {"WGRZ", 71}, /*{"KUSA", 73},*/ {"KPNX", 75}, {"WTLV", 77}, {"WFMY", 83},
                {"WXIA", 85}, {"KARE", 89}, {"KTHV", 91}, {"WMAZ", 93}, {"WKYC", 95},
                {"WCSH/NCM", 97}, {"NCM", 97}, {"WLTX", 101}, {"KXTV", 103},
                {"KVUE", 269}, {"KENS", 273}, {"WCNC", 275}, {"KTVB", 277}, {"KING", 281},
                {"KGW", 283}, {"KHOU", 285}, {"WFAA", 287}, {"WWL", 289}, {"WVEC", 291},
                {"KREM", 293}, {"WHAS", 417}, /*{"KAGS", 499},*/ {"KCEN", 500}, {"KYTX", 501},
                {"KBMT", 502}, {"KIII", 503}, {"KIDY", 504}, {"KFMB", 509}, {"WTOL", 512},
                {"KWES", 513}
                //Per Chelsea: "kags and kusa are on the new scheduler
                //which has a stage environment
                //and they don't have any schedules in stage
                //Compared to all the other sites, which are on the OLD scheduler, which doesn't have a stage environment, so it points at prod"
            };
            
            foreach (KeyValuePair<string, int> stationID in stationIDs)
            {
                dynamic response = await GetStationsWithCurrentLiveVideo
                    ("https://api-stage.tegna-tv.com/mobile/content-ro/schedule/getCurrentOrNextLiveStream/" + 
                    stationID.Value + "?subscription-key=fdd842925eb6445f85adb84b30d22838");

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
                    //
                }
            }
            if (trueCount == 0)
            {
                Console.WriteLine("No stations are Streaming Live Video right now.");
            }

            foreach (KeyValuePair<string, int> stationID in stationIDs)
            {
                dynamic response = await GetStationsWithCurrentLiveVideo
                    ("https://api-stage.tegna-tv.com/mobile/content-ro/schedule/getCurrentOrNextLiveStream/" +
                    stationID.Value + "?subscription-key=fdd842925eb6445f85adb84b30d22838");
                await StationsWithNoLiveNext(response, stationID.Key);
            }
            
        }

        [Test]
        public async Task StationsArePlayingLiveVideoOnProd()
        {
            Dictionary<string, int> stationIDs = new Dictionary<string, int>()
            {
                {"WBIR", 51}, {"KSDK", 63}, {"WUSA", 65}, {"WTSP", 67}, {"WZZM", 69},
                {"WGRZ", 71}, {"KUSA", 73}, {"KPNX", 75}, {"WTLV", 77}, {"WFMY", 83},
                {"WXIA", 85}, {"KARE", 89}, {"KTHV", 91}, {"WMAZ", 93}, {"WKYC", 95},
                {"WCSH/NCM", 97}, {"NCM", 97}, {"WLTX", 101}, {"KXTV", 103},
                {"KVUE", 269}, {"KENS", 273}, {"WCNC", 275}, {"KTVB", 277}, {"KING", 281},
                {"KGW", 283}, {"KHOU", 285}, {"WFAA", 287}, {"WWL", 289}, {"WVEC", 291},
                {"KREM", 293}, {"WHAS", 417}, {"KAGS", 499}, {"KCEN", 500}, {"KYTX", 501},
                {"KBMT", 502}, {"KIII", 503}, {"KIDY", 504}, {"KFMB", 509}, {"WTOL", 512},
                {"KWES", 513}
            };
                        
            foreach (KeyValuePair<string, int> stationID in stationIDs)
            {
                dynamic response = await GetStationsWithCurrentLiveVideo
                    ("https://api-mgmt.tegnadigital.com/mobile/content-ro/schedule/getCurrentOrNextLiveStream/" +
                    stationID.Value + "?subscription-key=fdd842925eb6445f85adb84b30d22838");
                await StationsWithNoLiveNext(response, stationID.Key);
            }

        }

        public static async Task<dynamic> GetStationsWithCurrentLiveVideo(string url)
        {
            try
            {
                var client = new RestClient(url);
                var request = new RestRequest(Method.GET);
                IRestResponse response = client.Execute(request);
                var responseString = response.Content;
                return JsonConvert.DeserializeObject(responseString);
            }
            catch (Exception ex)
            {
                string message = $"GetResponseAsync - Error getting response from {url}.Ex: {ex}";
                Debug.WriteLine(message);
                Console.WriteLine(message);
                throw;
            }
        }

        public async Task StationsWithNoLiveNext(dynamic response, string stationID)
        {
            try
            {
                Assert.IsNotNull(response.liveNext);
                Assert.IsFalse(response.liveNext.ToString() == "[]");
            }
            catch (AssertionException ex)
            {
                string message = $@"{Environment.NewLine}The station '{stationID}' is not live and has no Live Next data.{Environment.NewLine}{ex}{Environment.NewLine}";
                Console.WriteLine(message);
            }
        }
    }
}
