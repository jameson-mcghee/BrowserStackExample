using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace BrowserStackIntegration
{
    public class InAppNotifications : PushNotifications
    {
        public InAppNotifications(string profile, string device) : base(profile, device) { }


    }
}
