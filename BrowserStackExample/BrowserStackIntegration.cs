using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using BrowserStack;
using Castle.Core.Internal;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Remote;

namespace BrowserStackMobileAppTests
{
    public class BrowserStackIntegration
    {
        protected IOSDriver<IOSElement> iosDriver;
        protected AndroidDriver<AndroidElement> androidDriver;
        protected string profile;
        protected string device;
        private Local browserStackLocal;

        public BrowserStackIntegration(string profile, string device)
        {
            this.profile = profile;
            this.device = device;
        }

        [SetUp]
        public void Init()
        {
            NameValueCollection caps = ConfigurationManager.GetSection("capabilities/"+profile) as NameValueCollection;
            NameValueCollection devices = ConfigurationManager.GetSection("environments/"+device) as NameValueCollection;

            DesiredCapabilities capability = new DesiredCapabilities();

            Array.ForEach(caps.AllKeys, key => capability.SetCapability(key, caps[key]));
            Array.ForEach(devices.AllKeys, key => capability.SetCapability(key, devices[key]));

            var userName = Environment.GetEnvironmentVariable("BROWSERSTACK_USERNAME") ??
                           ConfigurationManager.AppSettings.Get("user");
            var accessKey = Environment.GetEnvironmentVariable("BROWSERSTACK_ACCESS_KEY") ??
                            ConfigurationManager.AppSettings.Get("key");

            capability.SetCapability("browserstack.user", userName);
            capability.SetCapability("browserstack.key", accessKey);

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
            //androidDriver = new AndroidDriver<AndroidElement>(new Uri("http://" + ConfigurationManager.AppSettings.Get("server") + "/wd/hub/"), capability);
            iosDriver = new IOSDriver<IOSElement>(new Uri("http://" + ConfigurationManager.AppSettings.Get("server") + "/wd/hub/"), capability);
        }

        [TearDown]
        public void CleanUp()
        {
            //androidDriver.Quit();
            iosDriver.Quit();
            if (browserStackLocal != null)
            {
                browserStackLocal.stop();
            }
        }
    }
}
