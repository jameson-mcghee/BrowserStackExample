using NUnit.Framework;
using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Newtonsoft.Json.Linq;
using System.Reflection;

namespace MobileAppTests
{
    public class BrowserStackcURLCommands
    {
        public static string UserName => Environment.GetEnvironmentVariable("BROWSERSTACK_USERNAME") ??
                           ConfigurationManager.AppSettings.Get("user");
        public static string AccessKey => Environment.GetEnvironmentVariable("BROWSERSTACK_ACCESS_KEY") ??
                        ConfigurationManager.AppSettings.Get("key");

        public static async Task UploadAppFiles(string url, string file, int fileType)
        {
            string userName = Environment.UserName;
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    using (HttpRequestMessage request = new HttpRequestMessage(new HttpMethod("POST"), url))
                    {
                        var base64authorization = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{UserName}:{AccessKey}"));
                        request.Headers.TryAddWithoutValidation("Authorization", $"Basic {base64authorization}");

                        var multipartContent = new MultipartFormDataContent();
                        multipartContent.Add(new ByteArrayContent(File.ReadAllBytes(file)), "file", Path.GetFileName(file));
                        request.Content = multipartContent;

                        var response = await httpClient.SendAsync(request);
                        var responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        //Console.WriteLine(responseString);

                        dynamic apiResponse = JObject.Parse(responseString);
                        var appUrl = apiResponse.app_url.ToString();
                        Console.WriteLine(appUrl);

                        if (File.Exists($@"C:/Users/{userName}/source/repos/BrowserStackExample/BrowserStackExample/bin/Debug/BrowserStackExample.dll") == false)
                        {
                            Assert.Fail("BrowserStackExample.dll file does not exist.");
                        }

                        Configuration configuration = ConfigurationManager.OpenExeConfiguration($@"C:/Users/{userName}/source/repos/BrowserStackExample/BrowserStackExample/bin/Debug/BrowserStackExample.dll");
                        //var test = configuration.GetSection("androidCapabilities/single");
                        if (fileType == 1)
                        {
                            configuration.GetSection("androidCapabilities/single").SectionInformation.SetRawXml($@"<single>
                              <add key=""build"" value=""tegnaandroidmobileapp"" />
                              <add key=""name"" value=""single_test"" />
                              <add key=""browserstack.debug"" value=""true"" />
                              <add key=""app"" value=""{appUrl}"" />
                            </single>");
                            configuration.GetSection("androidCapabilities/parallel").SectionInformation.SetRawXml($@"<parallel>
                              <add key=""build"" value=""tegnaandroidmobileapp"" />
                              <add key=""name"" value=""parallel_test"" />
                              <add key=""browserstack.debug"" value=""true"" />
                              <add key=""app"" value=""{appUrl}"" />
                            </parallel>");
                            configuration.Save(ConfigurationSaveMode.Modified);
                        }
                        if (fileType == 2)
                        {
                            configuration.GetSection("iosCapabilities/single").SectionInformation.SetRawXml($@"<single>
                              <add key=""build"" value=""tegnaiosmobileapp"" />
                              <add key=""name"" value=""single_test"" />
                              <add key=""browserstack.debug"" value=""true"" />
                              <add key=""app"" value=""{appUrl}"" />
                            </single>");
                            configuration.GetSection("iosCapabilities/parallel").SectionInformation.SetRawXml($@"<parallel>
                              <add key=""build"" value=""tegnaiosmobileapp"" />
                              <add key=""name"" value=""parallel_test"" />
                              <add key=""browserstack.debug"" value=""true"" />
                              <add key=""app"" value=""{appUrl}"" />
                            </parallel>");
                            configuration.Save(ConfigurationSaveMode.Modified);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string message = $"PostResponseAsync - Error getting response from {url}.Ex: {ex}";
                Debug.WriteLine(message);
                //Debug.ReadLine();
                Console.WriteLine(message);
                throw;
            }

            File.Copy
                ($@"C:/Users/{userName}/source/repos/BrowserStackExample/BrowserStackExample/bin/Debug/BrowserStackExample.dll",
                $@"C:/Users/{userName}/source/repos/BrowserStackExample/UnitTestProject1/bin/Debug/UnitTestProject1.dll");
        }

        [Test]
        public async Task UploadAndroidApp()
        {
            string userName = Environment.UserName;
            if (Directory.Exists($@"C:/Users/{userName}/Downloads/TempDownloads/") == false)
            {
                Assert.Fail("TempDownloads folder does not exist.");
            }
            string folderWithFiles = $@"C:/Users/{userName}/Downloads/TempDownloads/";
            var filesInFolder = Directory.GetFiles(folderWithFiles);
            if (filesInFolder == null)
            {
                Assert.Fail("There are no files in the TempDownloads folder.");
            }
                        
            foreach (dynamic fileInFolder in filesInFolder)
            {
                string extension = Path.GetExtension(fileInFolder);
                if (extension.Contains(".apk"))
                {
                    int fileType = 1;
                    await UploadAppFiles("https://api-cloud.browserstack.com/app-automate/upload", fileInFolder, fileType);
                }
                if (extension.Contains(".ipa"))
                {
                    int fileType = 2;
                    await UploadAppFiles("https://api-cloud.browserstack.com/app-automate/upload", fileInFolder, fileType);
                }
            }
        }
    }
}
