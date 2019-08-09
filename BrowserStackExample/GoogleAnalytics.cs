using System;
using System.Threading.Tasks;
using NUnit.Framework;
using Newtonsoft.Json;
using System.Diagnostics;
using RestSharp;
using System.Collections.Generic;

namespace BrowserStackIntegration
{
    public class GoogleAnalytics
    {
        //public List<string> analyticsCalls = new List<string>()
        //{
        //    "v=1","_v=j77","a=1140857310","t=event","_s=2","cd=",
        //    "dl=https%3A%2F%2Ftags.tiqcdn.com%2Futag%2Ftegna%2Fdev-native-app%2Fdev%2Fmobile.html%3Fplatform%3Dandroid%26device_os_version%3D8.0.0%26library_version%3D5.5.2%26timestamp_unix%3D1564624717",
        //    "ul=en-gb","de=windows-1252","dt=Tealium%20Mobile%20Webview","sd=24-bit","sr=360x740","vp=","je=0",
        //    "ec=application","ea=launched","el=organic%20(cold)","an=TegnaNativeApp","av=6.2.3","aiid=com.tgnanativeapps",
        //    "_u=aEBAAAAB~","cid=2111450875.1564624720","tid=UA-91390612-77","_gid=1459223146.1564624720","cd33=android",
        //    "cd44=TegnaNativeApp","cd16=false","cd5=Other","cd8=UA%20-%20Event%20-%20Application%20-%20Launch",
        //    "cd9=https%3A%2F%2Fwww.wbir.com%2FSplashScreen","cd14=Knoxville%2C%20TN","cd17=None","z=280090612"
        //};

        public static async Task<dynamic> GetSessionResponseAsync(string url)
        {
            try
            {
                RestClient httpClient = new RestClient(url);
                var request = new RestRequest(Method.GET);
                request.AddHeader("Authorization", "Basic amFtZXNvbm1jZ2hlZTI6UXN4VjNyS3p5ZmZldFlCOGpocHg=");
                IRestResponse response = httpClient.Execute(request);
                var responseString = response.Content;
                return JsonConvert.DeserializeObject(responseString);
            }
            catch (Exception ex)
            {
                string message = $@"GetResponseAsync - Error getting response from {url}.Ex:{Environment.NewLine}{ex}";
                Debug.WriteLine(message);
                Console.WriteLine(message);
                throw;
            }
        }

        public async Task GetNetworkLogs(int operatingSystem)
        {
            dynamic responseSession = null;
            dynamic responseNetwork = null;

            if (operatingSystem != 1 && operatingSystem != 2)
            {
                Assert.Fail($@"'{operatingSystem}' is not a valid value for this method. Must either be a '1' (Android) or '2' (iOS).");
            }
            if (operatingSystem == 1)
            {
                responseSession = await GetSessionResponseAsync
                ("https://api-cloud.browserstack.com/app-automate/builds/0085f3aa4b2d24d533398891ebf5b05f97fe8286/sessions.json?limit=1");
            }
            if (operatingSystem == 2)
            {
                responseSession = await GetSessionResponseAsync
                ("https://api-cloud.browserstack.com/app-automate/builds/3f32201e01b85b2a04993932bffdc1820840521e/sessions.json?limit=1");
            }
            if (string.IsNullOrEmpty(responseSession.ToString()))
            {
                Assert.Fail("No session information in the API response.");
            }
            Console.Write($@"Response session:{Environment.NewLine}{responseSession}{Environment.NewLine}{Environment.NewLine}");

            dynamic sessionLog = responseSession[0].automation_session;
            dynamic sessionLogId = sessionLog.hashed_id;
            string sessionId = sessionLogId.ToString();
            if (string.IsNullOrEmpty(sessionId))
            {
                Assert.Fail("No Session ID in the API response.");
            }

            if (operatingSystem == 1)
            {
                responseNetwork = await GetSessionResponseAsync
                    ("https://api-cloud.browserstack.com/app-automate/builds/0085f3aa4b2d24d533398891ebf5b05f97fe8286/sessions/" + sessionId + "/networklogs");
            }
            if (operatingSystem == 2)
            {
                responseNetwork = await GetSessionResponseAsync
                    ("https://api-cloud.browserstack.com/app-automate/builds/3f32201e01b85b2a04993932bffdc1820840521e/sessions/" + sessionId + "/networklogs");
            }
            if (string.IsNullOrEmpty(responseNetwork.ToString()))
            {
                Assert.Fail("No Network Log data in the API response.");
            }
            Console.Write($@"Response Network:{Environment.NewLine}{responseNetwork}");

            //foreach (analyticsCall in analyticsCalls)
            //{
            //    await ConfirmVariables(analyticsCalls, responseNetwork);
            //}
        }

        public async Task ConfirmVariables(string analyticsCalls, dynamic responseNetwork)
        {

        }
    }
}
