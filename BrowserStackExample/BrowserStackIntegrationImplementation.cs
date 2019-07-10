using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Threading.Tasks;
using BrowserStack;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Remote;

namespace BrowserStackIntegration
{
    public class BrowserStackIntegrationImplementation
    {
        public IOSDriver<IOSElement> iosDriver;
        public AndroidDriver<AndroidElement> androidDriver;
        protected string profile;
        protected string device;
        private Local browserStackLocal;
        public IWebDriver webDriver;

        public BrowserStackIntegrationImplementation(string profile, string device)
        {
            this.profile = profile;
            this.device = device;
        }

        [SetUp]
        public void Init()
        {
            var androidCapabilities = GetAppCapabilities("androidCapabilities", "androidEnvironments");
            if (androidCapabilities != null)
                androidDriver = new AndroidDriver<AndroidElement>(new Uri("http://" + ConfigurationManager.AppSettings.Get("server") + "/wd/hub/"), androidCapabilities);

            var iosCapabilities = GetAppCapabilities("iosCapabilities", "iosEnvironments");
            if (iosCapabilities != null)
                iosDriver = new IOSDriver<IOSElement>(new Uri("http://" + ConfigurationManager.AppSettings.Get("server") + "/wd/hub/"), iosCapabilities, TimeSpan.FromSeconds(90));
        }
                
        public DesiredCapabilities GetAppCapabilities(string capabilitiesSectionName, string environmentsSectionName)
        {
            NameValueCollection capabilities = ConfigurationManager.GetSection($"{capabilitiesSectionName}/{profile}") as NameValueCollection;
            NameValueCollection environments = ConfigurationManager.GetSection($"{environmentsSectionName}/{device}") as NameValueCollection;

            if (environments == null) return null;

            DesiredCapabilities capability = new DesiredCapabilities();

            Array.ForEach(capabilities.AllKeys, key => capability.SetCapability(key, capabilities[key]));
            Array.ForEach(environments.AllKeys, key => capability.SetCapability(key, environments[key]));

            var userName = Environment.GetEnvironmentVariable("BROWSERSTACK_USERNAME") ??
                           ConfigurationManager.AppSettings.Get("user");
            var accessKey = Environment.GetEnvironmentVariable("BROWSERSTACK_ACCESS_KEY") ??
                            ConfigurationManager.AppSettings.Get("key");

            capability.SetCapability("browserstack.user", userName);
            capability.SetCapability("browserstack.key", accessKey);
            capability.SetCapability("autoGrantPermissions", true);
            capability.SetCapability("autoAcceptAlerts", true);
            capability.SetCapability("browserstack.networkLogs", true);
            capability.SetCapability("browserstack.seleniumLogs", true);
            capability.SetCapability("browserstack.deviceLogs", true);
            capability.SetCapability("browserstack.appiumLogs", true);
            capability.SetCapability("waitForQuiescence", false);
            //capability.SetCapability("browserstack.resignApp", false);

            var appId = Environment.GetEnvironmentVariable("BROWSERSTACK_APP_ID");
            if (appId != null)
                capability.SetCapability("app", appId);

            if (capability.GetCapability("browserstack.local") != null &&
                capability.GetCapability("browserstack.local").ToString() == "true")
            {
                browserStackLocal = new Local();
                var bsLocalArgs = new List<KeyValuePair<string, string>>
                    {new KeyValuePair<string, string>("key", accessKey)};
                browserStackLocal.start(bsLocalArgs);
            }

            return capability;
        }

        [TearDown]
        public void CleanUp()
        {
            if (androidDriver != null)
                androidDriver.Quit();
            if (iosDriver != null)
                iosDriver.Quit();
            if (browserStackLocal != null)
            {
                browserStackLocal.stop();
            }
        }
    }
}
