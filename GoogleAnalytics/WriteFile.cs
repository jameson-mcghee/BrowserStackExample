using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using BrowserStackIntegration;
using System.Net;

namespace GoogleAnalytics
{
    class WriteFile : GlobalMethods
    {
        public WriteFile(string profile, string device) : base(profile, device){}
        
        public static async void Main(string[] args)
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
                ("https://api.browserstack.com/app-automate/builds/0085f3aa4b2d24d533398891ebf5b05f97fe8286/sessions/" + "f55283eea62618a652a037e1b275f4fab69007a3" + "/networklogs",
                requestContent); //Figure out how to insert session ID into the url dynamically

            // Get the response content.
            HttpContent responseContent = response.Content;

            // Get the stream of the content.
            using (var reader = new StreamReader(await responseContent.ReadAsStreamAsync()))
            {
                try
                {
                    //Pass the filepath and filename to the StreamWriter Constructor
                    StreamWriter sw = new StreamWriter("C:\\Users\\JMcghee\\source\\repos\\BrowserStackExample\\BSNetworkFiles\\Test.txt");

                    // Write the output.
                    sw.WriteLine(await reader.ReadToEndAsync());

                    //Close the file
                    sw.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
                finally
                {
                    Console.WriteLine("Executing finally block.");
                }
            }
        }
    }
}
