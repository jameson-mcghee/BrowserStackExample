using NUnit.Framework;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Configuration;
using Newtonsoft.Json.Linq;
using RestSharp;

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
            Directory.CreateDirectory($@"C:/Users/{userName}/Downloads/TempDownloads/");
            string folderWithFiles = $@"C:/Users/{userName}/Downloads/TempDownloads/";
            var filesInFolder = Directory.GetFiles(folderWithFiles);
            if (filesInFolder == null)
            {
                Assert.Pass("There are no files in the TempDownloads folder.");
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
                if (extension.Contains(".apk") == false && extension.Contains(".ipa") == false)
                {
                    Console.Write($@"File is not an Android or iOS application file.{Environment.NewLine}{fileInFolder}{Environment.NewLine}");
                }
            }
        }

        public static async Task UploadAppFiles(string url, string file, int fileType)
        {
            var appUrl = "";

            try
            {
                var client = new RestClient(url);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", "Basic amFtZXNvbm1jZ2hlZTI6UXN4VjNyS3p5ZmZldFlCOGpocHg=");
                request.AddHeader("Content-Type", "multipart/form-data");
                request.AddFile("file", file);
                IRestResponse response = client.Execute(request);
                var responseString = response.Content;
                dynamic apiResponse = JObject.Parse(responseString);
                appUrl = apiResponse.app_url.ToString();
                Console.WriteLine(appUrl);
            }
            catch (Exception ex)
            {
                string message = $"PostResponseAsync - Error getting response from {url}.Ex: {ex}";
                Debug.WriteLine(message);
                Console.WriteLine(message);
                throw;
            }

            await BackupDLLFiles();
            await UpdateAppConfigFiles(file, fileType, appUrl);
        }

        public static async Task UpdateAppConfigFiles(string file, int fileType, string appUrl)
        {
            #region Variables
            string userName = Environment.UserName;
            string fileName = file.Remove(0, 53);
            string stationID = fileName.Remove(fileName.Length - 4);
            string browserStackExampleDLL = $@"C:/Users/{userName}/source/repos/BrowserStackExample/BrowserStackExample/bin/Debug/BrowserStackExample.dll";
            string unitTestProject1DLL = $@"C:/Users/{userName}/source/repos/BrowserStackExample/UnitTestProject1/bin/Debug/UnitTestProject1.dll";
            string appConfigBrowserStackIntegration = $@"C:\Users\{userName}\source\repos\BrowserStackExample\BrowserStackExample\app";
            string appConfigMobileAppTests = $@"C:\Users\{userName}\source\repos\BrowserStackExample\UnitTestProject1\app";
            string uploadedAppKeys = $@"C:\Users\{userName}\Documents\UploadedAppKeys.txt";
            string androidStationFile = $@"C:\Users\{userName}\Documents\Android StationID.txt";
            string iosStationFile = $@"C:\Users\{userName}\Documents\Apple StationID.txt";

            #endregion

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
                    File.WriteAllText(androidStationFile, $@"Station Info: {stationID}");
                }
                if (fileType == 2)
                {
                    File.AppendAllText(uploadedAppKeys, $@"iOS App : {fileName} : {appUrl} : {DateTime.Now:yyyy-MM-dd_hh-mm-ss}{Environment.NewLine}");
                    File.WriteAllText(iosStationFile, $@"Station Info: {stationID}");
                }

                #region XML Strings
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
                #endregion

                #region BrowserStackExample dll Configuration
                Configuration configuration1 = ConfigurationManager.OpenExeConfiguration(browserStackExampleDLL);
                if (fileType == 1)
                {
                    configuration1.GetSection("androidCapabilities/single").SectionInformation.SetRawXml(androidSingle);
                    configuration1.GetSection("androidCapabilities/parallel").SectionInformation.SetRawXml(androidParallel);
                    configuration1.Save(ConfigurationSaveMode.Modified);
                }
                if (fileType == 2)
                {
                    configuration1.GetSection("iosCapabilities/single").SectionInformation.SetRawXml(iosSingle);
                    configuration1.GetSection("iosCapabilities/parallel").SectionInformation.SetRawXml(iosParallel);
                    configuration1.Save(ConfigurationSaveMode.Modified);
                }
                #endregion

                #region UnitTestProject1 dll Configuration
                Configuration configuration2 = ConfigurationManager.OpenExeConfiguration(unitTestProject1DLL);
                if (fileType == 1)
                {
                    configuration2.GetSection("androidCapabilities/single").SectionInformation.SetRawXml(androidSingle);
                    configuration2.GetSection("androidCapabilities/parallel").SectionInformation.SetRawXml(androidParallel);
                    configuration2.Save(ConfigurationSaveMode.Modified);
                }
                if (fileType == 2)
                {
                    configuration2.GetSection("iosCapabilities/single").SectionInformation.SetRawXml(iosSingle);
                    configuration2.GetSection("iosCapabilities/parallel").SectionInformation.SetRawXml(iosParallel);
                    configuration2.Save(ConfigurationSaveMode.Modified);
                }
                #endregion

                #region app.config BrowserStackIntegration Configuration
                //Configuration configuration3 = ConfigurationManager.OpenExeConfiguration(appConfigBrowserStackIntegration);
                //if (fileType == 1)
                //{
                //    configuration3.GetSection("androidCapabilities/single").SectionInformation.SetRawXml(androidSingle);
                //    configuration3.GetSection("androidCapabilities/parallel").SectionInformation.SetRawXml(androidParallel);
                //    configuration3.Save(ConfigurationSaveMode.Modified);
                //}
                //if (fileType == 2)
                //{
                //    configuration3.GetSection("iosCapabilities/single").SectionInformation.SetRawXml(iosSingle);
                //    configuration3.GetSection("iosCapabilities/parallel").SectionInformation.SetRawXml(iosParallel);
                //    configuration3.Save(ConfigurationSaveMode.Modified);
                //}
                #endregion

                #region app.config MobileAppTests Configuration
                //Configuration configuration4 = ConfigurationManager.OpenExeConfiguration(appConfigMobileAppTests);
                //if (fileType == 1)
                //{
                //    configuration4.GetSection("androidCapabilities/single").SectionInformation.SetRawXml(androidSingle);
                //    configuration4.GetSection("androidCapabilities/parallel").SectionInformation.SetRawXml(androidParallel);
                //    configuration4.Save(ConfigurationSaveMode.Modified);
                //}
                //if (fileType == 2)
                //{
                //    configuration4.GetSection("iosCapabilities/single").SectionInformation.SetRawXml(iosSingle);
                //    configuration4.GetSection("iosCapabilities/parallel").SectionInformation.SetRawXml(iosParallel);
                //    configuration4.Save(ConfigurationSaveMode.Modified);
                //}
                #endregion
            }
            catch (Exception ex)
            {
                string message = $"App.Config update failed: {ex}";
                Debug.WriteLine(message);
                Console.WriteLine(message);
                throw;
            }
        }

        public static async Task BackupDLLFiles()
        {
            #region Variables
            string userName = Environment.UserName;
            string browserStackExampleDLL = $@"C:/Users/{userName}/source/repos/BrowserStackExample/BrowserStackExample/bin/Debug/BrowserStackExample.dll.config";
            string browserStackExampleBackupDLL = $@"C:/Users/{userName}/source/repos/BrowserStackExample/BrowserStackExample/bin/Debug/BrowserStackExampleBackup.dll.config";
            string unitTestProject1DLL = $@"C:/Users/{userName}/source/repos/BrowserStackExample/UnitTestProject1/bin/Debug/UnitTestProject1.dll.config";
            string unitTestProject1BackupDLL = $@"C:/Users/{userName}/source/repos/BrowserStackExample/UnitTestProject1/bin/Debug/UnitTestProject1Backup.dll.config";
            string appConfigBrowserStackIntegration = $@"C:\Users\{userName}\source\repos\BrowserStackExample\BrowserStackExample\app.config";
            string appConfigBrowserStackIntegrationBackup = $@"C:\Users\{userName}\source\repos\BrowserStackExample\BrowserStackExample\appBackup.config";
            string appConfigMobileAppTests = $@"C:\Users\{userName}\source\repos\BrowserStackExample\UnitTestProject1\app.config";
            string appConfigMobileAppTestsBackup = $@"C:\Users\{userName}\source\repos\BrowserStackExample\UnitTestProject1\appBackup.config";
            #endregion

            #region BrowserStackExample Backup
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
            #endregion

            #region UnitTestProject1 Backup
            if (File.Exists(unitTestProject1DLL) == false)
            {
                Assert.Fail("UnitTestProject1.dll.config file does not exist.");
            }
            if (File.Exists(unitTestProject1BackupDLL) == false)
            {
                File.Copy(unitTestProject1DLL, unitTestProject1BackupDLL);
            }
            if (File.Exists(unitTestProject1BackupDLL))
            {
                File.Delete(unitTestProject1BackupDLL);
                File.Copy(unitTestProject1DLL, unitTestProject1BackupDLL);
            }
            #endregion

            #region app.config BrowserStackIntegration Backup
            if (File.Exists(appConfigBrowserStackIntegration) == false)
            {
                Assert.Fail("app.config file for the BrowserStackIntegration project does not exist.");
            }
            if (File.Exists(appConfigBrowserStackIntegrationBackup) == false)
            {
                File.Copy(appConfigBrowserStackIntegration, appConfigBrowserStackIntegrationBackup);
            }
            if (File.Exists(appConfigBrowserStackIntegrationBackup))
            {
                File.Delete(appConfigBrowserStackIntegrationBackup);
                File.Copy(appConfigBrowserStackIntegration, appConfigBrowserStackIntegrationBackup);
            }
            #endregion

            #region app.config MobileAppTests Backup
            if (File.Exists(appConfigMobileAppTests) == false)
            {
                Assert.Fail("app.config file for the MobileAppTests project does not exist.");
            }
            if (File.Exists(appConfigMobileAppTestsBackup) == false)
            {
                File.Copy(appConfigMobileAppTests, appConfigMobileAppTestsBackup);
            }
            if (File.Exists(appConfigMobileAppTestsBackup))
            {
                File.Delete(appConfigMobileAppTestsBackup);
                File.Copy(appConfigMobileAppTests, appConfigMobileAppTestsBackup);
            }
            #endregion
        }
    }
}
