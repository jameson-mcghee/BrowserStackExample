using System;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Diagnostics;
using OpenQA.Selenium.Appium.Android;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using RestSharp;
using Newtonsoft.Json.Linq;

namespace BrowserStackIntegration
{
    public class InAppNotifications : PushNotifications
    {
        public InAppNotifications(string profile, string device) : base(profile, device) { }


    }
}
