using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserStackIntegration
{
    public class NotificationSettingsPage : SettingsPage
    {
        public NotificationSettingsPage(string profile, string device) : base(profile, device) { }

        public async Task DeviceSystemSettingsLink()
        {
            //TODO: Add steps to click the 'System Settings' link
        }

       public async Task TopicsTopicAlertsAndNotifications()
        {
            //TODO: Add steps to click the 'Topic Alerts and Notifications' link
        }

        public async Task WeatherChangeLocation()
        {
            //TODO: Add steps to click the 'Change Location' link
        }
    }
}
