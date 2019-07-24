using NUnit.Framework;
using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Newtonsoft.Json.Linq;

namespace NonMobileAppTests
{
    public class UploadAppFilesAndUpdateConfig
    {
        public static string UserName => Environment.GetEnvironmentVariable("BROWSERSTACK_USERNAME") ??
                           ConfigurationManager.AppSettings.Get("user");
        public static string AccessKey => Environment.GetEnvironmentVariable("BROWSERSTACK_ACCESS_KEY") ??
                        ConfigurationManager.AppSettings.Get("key");

        [Test]
        public async Task UploadAppFiles()
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

        public static async Task UploadAppFiles(string url, string file, int fileType)
        {
            var appUrl = "";

            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    using (HttpRequestMessage request = new HttpRequestMessage(new HttpMethod("POST"), url))
                    {
                        var base64authorization = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{UserName}:{AccessKey}"));
                        request.Headers.TryAddWithoutValidation("Authorization", $"Basic {base64authorization}");

                        //TODO: Delete this section if the other code below works
                        //var multipartContent = new MultipartFormDataContent();
                        //multipartContent.Add(new ByteArrayContent(File.ReadAllBytes(file)), "file", Path.GetFileName(file));
                        var multipartContent = new MultipartFormDataContent
                        {
                            { new ByteArrayContent(File.ReadAllBytes(file)), "file", Path.GetFileName(file) }
                        };
                        request.Content = multipartContent;

                        var response = await httpClient.SendAsync(request);
                        var responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                        dynamic apiResponse = JObject.Parse(responseString);
                        appUrl = apiResponse.app_url.ToString();
                        Console.WriteLine(appUrl);
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

            await UpdateAppConfigFiles(file, fileType, appUrl);
            await CopyOrReplaceDLLFiles();
        }

        public static async Task UpdateAppConfigFiles(string file, int fileType, string appUrl)
        {
            string userName = Environment.UserName;
            string fileName = file.Remove(0, 41);
            string browserStackExampleDLL = $@"C:/Users/{userName}/source/repos/BrowserStackExample/BrowserStackExample/bin/Debug/BrowserStackExample.dll";
            string unitTestProject1DLL = $@"C:/Users/{userName}/source/repos/BrowserStackExample/UnitTestProject1/bin/Debug/UnitTestProject1.dll";
            string uploadedAppKeys = $@"C:\Users\{userName}\Documents\UploadedAppKeys.txt";

            try
            {
                if (File.Exists(browserStackExampleDLL) == false)
                {
                    Assert.Fail("BrowserStackExample.dll.config file does not exist.");
                }
                if (File.Exists(unitTestProject1DLL) == false)
                {
                    Assert.Fail("UnitTestProject1.dll.config file does not exist.");
                }

                if (fileType == 1)
                {
                    File.AppendAllText(uploadedAppKeys, $@"Android App : {fileName} : {appUrl} : {DateTime.Now:yyyy-MM-dd_hh-mm-ss}{Environment.NewLine}");
                }
                if (fileType == 2)
                {
                    File.AppendAllText(uploadedAppKeys, $@"iOS App : {fileName} : {appUrl} : {DateTime.Now:yyyy-MM-dd_hh-mm-ss}{Environment.NewLine}");
                }

                string androidSingle = $@"<single>
                              <add key=""build"" value=""tegnaandroidmobileapp"" />
                              <add key=""name"" value=""single_test"" />
                              <add key=""browserstack.debug"" value=""true"" />
                              <add key=""app"" value=""{appUrl}"" />
                            </single>";
                string androidParallel = $@"<parallel>
                              <add key=""build"" value=""tegnaandroidmobileapp"" />
                              <add key=""name"" value=""parallel_test"" />
                              <add key=""browserstack.debug"" value=""true"" />
                              <add key=""app"" value=""{appUrl}"" />
                            </parallel>";
                string iosSingle = $@"<single>
                              <add key=""build"" value=""tegnaiosmobileapp"" />
                              <add key=""name"" value=""single_test"" />
                              <add key=""browserstack.debug"" value=""true"" />
                              <add key=""app"" value=""{appUrl}"" />
                            </single>";
                string iosParallel = $@"<parallel>
                              <add key=""build"" value=""tegnaiosmobileapp"" />
                              <add key=""name"" value=""parallel_test"" />
                              <add key=""browserstack.debug"" value=""true"" />
                              <add key=""app"" value=""{appUrl}"" />
                            </parallel>";

                Configuration configuration = ConfigurationManager.OpenExeConfiguration(browserStackExampleDLL);
                if (fileType == 1)
                {
                    configuration.GetSection("androidCapabilities/single").SectionInformation.SetRawXml(androidSingle);
                    configuration.GetSection("androidCapabilities/parallel").SectionInformation.SetRawXml(androidParallel);
                    configuration.Save(ConfigurationSaveMode.Modified);
                }
                if (fileType == 2)
                {
                    configuration.GetSection("iosCapabilities/single").SectionInformation.SetRawXml(iosSingle);
                    configuration.GetSection("iosCapabilities/parallel").SectionInformation.SetRawXml(iosParallel);
                    configuration.Save(ConfigurationSaveMode.Modified);
                }

                Configuration config = ConfigurationManager.OpenExeConfiguration(unitTestProject1DLL);
                if (fileType == 1)
                {
                    config.GetSection("androidCapabilities/single").SectionInformation.SetRawXml(androidSingle);
                    config.GetSection("androidCapabilities/parallel").SectionInformation.SetRawXml(androidParallel);
                    config.Save(ConfigurationSaveMode.Modified);
                }
                if (fileType == 2)
                {
                    config.GetSection("iosCapabilities/single").SectionInformation.SetRawXml(iosSingle);
                    config.GetSection("iosCapabilities/parallel").SectionInformation.SetRawXml(iosParallel);
                    config.Save(ConfigurationSaveMode.Modified);
                }
            }
            catch (Exception ex)
            {
                string message = $"App.Config update failed: {ex}";
                Debug.WriteLine(message);
                //Debug.ReadLine();
                Console.WriteLine(message);
                throw;
            }
        }

        public static async Task CopyOrReplaceDLLFiles()
        {
            string userName = Environment.UserName;
            string browserStackExampleDLL = $@"C:/Users/{userName}/source/repos/BrowserStackExample/BrowserStackExample/bin/Debug/BrowserStackExample.dll.config";
            string browserStackExampleBackupDLL = $@"C:/Users/{userName}/source/repos/BrowserStackExample/BrowserStackExample/bin/Debug/BrowserStackExampleBackup.dll.config";
            string unitTestProject1DLL = $@"C:/Users/{userName}/source/repos/BrowserStackExample/UnitTestProject1/bin/Debug/UnitTestProject1.dll.config";
            string unitTestProject1BackupDLL = $@"C:/Users/{userName}/source/repos/BrowserStackExample/UnitTestProject1/bin/Debug/UnitTestProject1Backup.dll.config";

            if (File.Exists(browserStackExampleDLL) == false)
            {
                Assert.Fail("BrowserStackExample.dll.config file does not exist.");
            }
            if (File.Exists(browserStackExampleBackupDLL) == false)
            {
                File.Copy(browserStackExampleDLL, browserStackExampleBackupDLL);
            }
            if (File.Exists(browserStackExampleBackupDLL))
            {
                File.Delete(browserStackExampleBackupDLL);
                File.Copy(browserStackExampleDLL, browserStackExampleBackupDLL);
            }

            if (File.Exists(unitTestProject1DLL) == false)
            {
                Assert.Fail("UnitTestProject1.dll.config file does not exist.");
            }
            if (File.Exists(unitTestProject1DLL) == false)
            {
                File.Copy(unitTestProject1DLL, unitTestProject1BackupDLL);
            }
            if (File.Exists(unitTestProject1DLL))
            {
                File.Delete(unitTestProject1BackupDLL);
                File.Copy(unitTestProject1DLL, unitTestProject1BackupDLL);
            }
        }
    }
}
