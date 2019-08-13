using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace BrowserStackIntegration
{
    public class SettingsPage : TopicsPage
    {
        public SettingsPage(string profile, string device) : base(profile, device) { }

        public async Task DeviceSystemSettingsLink()
        {
            //TODO: Add steps to click the 'System Settings' link
            await AndroidClickCommand("Navigate up");
        }

        public async Task AppInfoContactUsLink()
        {
            //TODO: Add steps to click the 'Contact Us' link
        }

        public async Task AppInfoTermsOfServiceLink()
        {
            //TODO: Add steps to click the 'Terms of Service' link
        }

        public async Task AppInfoPrivacyPolicyLink()
        {
            //TODO: Add steps to click the 'Privacy Policy' link
        }

        public async Task AppInfoFCCOPIFLink()
        {
            //TODO: Add steps to click the 'FCC Online Public Inspection File' link
        }

        public async Task AppInfoFeedbackLink()
        {
            //TODO: Add steps to click the 'Feedback' link
        }

        public async Task VideoAutoPlayVideoSetting(string videoSetting)
        {
            if (videoSetting == "enabled")
            {
                //TODO: Insert Enabled setting element id
                await AndroidClickCommand("");
                return;
            }
            if (videoSetting == "wifi")
            {
                //TODO: Insert Wi-Fi Only setting element id
                await  AndroidClickCommand("");
                return;
            }
            if (videoSetting == "disabled")
            {
                //TODO: Insert Disabled setting element id
                await  AndroidClickCommand("");
                return;
            }
            else
            {
                //TODO: Insert Enabled setting element id
                await  AndroidClickCommand("");
                Console.WriteLine("Invalid Auto-Play Video setting selected. Defaulted to 'Enabled'");
                return;
            }
        }

        public async Task NotificationsNotificationSettings()
        {
            //TODO: Add steps to click the 'Notification Settings' link
        }
    }
}
