using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.IO;
using System.Configuration;

namespace BrowserStackIntegration
{
    public class GoogleAnalytics : GlobalMethods
    {
        public GoogleAnalytics(string profile, string device) : base(profile, device){}


        public async Task GetNetworkData()
        {
            var userName = Environment.GetEnvironmentVariable("BROWSERSTACK_USERNAME") ??
                           ConfigurationManager.AppSettings.Get("user");
            var accessKey = Environment.GetEnvironmentVariable("BROWSERSTACK_ACCESS_KEY") ??
                            ConfigurationManager.AppSettings.Get("key");

            var client = new HttpClient();
            
            // Create the HttpContent for the form to be posted.
            var requestContent = new FormUrlEncodedContent(new[] 
                {new KeyValuePair<string, string> ("user", userName),
                new KeyValuePair<string, string>("key", accessKey)}); //Is this were the Auth information (i.e. userName and accessKey) is provided? Not sure if I did this right.
            
            // Get the response.
            HttpResponseMessage response = await client.PostAsync
                ("https://api.browserstack.com/app-automate/builds/0085f3aa4b2d24d533398891ebf5b05f97fe8286/sessions/" + "<SESSIONIDGOESHERE>" + "/networklogs", 
                requestContent); //Figure out how to insert session ID into the url dynamically

            // Get the response content.
            HttpContent responseContent = response.Content;

            // Get the stream of the content.
            using (var reader = new StreamReader(await responseContent.ReadAsStreamAsync()))
            {
                // Write the output.
                Console.WriteLine(await reader.ReadToEndAsync());
            }

        }

        public async Task ParseNetworkFile()
        {

            await GetNetworkData();

            //parse through the network data looking for the

        }

        //public async Task CompareNetworkFiles()
        //{

        //}
    }
}
