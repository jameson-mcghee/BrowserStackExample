using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace BrowserStackIntegration
{
    public class TopicAlertsAndNotificationsPage : NotificationSettingsPage
    {
        public TopicAlertsAndNotificationsPage(string profile, string device) : base(profile, device) { }

        public async Task DeviceSystemSettingsLink()
        {
            //TODO: Add steps to click the 'System Settings' link
        }

        public async Task FavoritedTopicsNotificationSettings()
        {
            //TODO: Add steps to toggle 'Favorited Topics' notifications
        }

        public async Task AllTopicsNotificationSettings()
        {
            //TODO: Add steps to toggle 'All Topics' notifications
        }
    }
}
