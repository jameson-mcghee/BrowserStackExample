using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserStackIntegration
{
    public class ChangeLocationPage : NotificationSettingsPage
    {
        public ChangeLocationPage(string profile, string device) : base(profile, device) { }

        public async Task AddLocation()
        {
            //TODO: Add steps to click the 'Add Location' link
        }

        public async Task DeleteLocation()
        {
            //TODO: Add steps to delete a location
        }

        public async Task ChangeDefaultLocation()
        {
            //TODO: Add steps to change the default location for the app
        }
    }
}
