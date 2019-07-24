using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace BrowserStackIntegration
{
    public class AddALocationPage : ChangeLocationPage
    {
        public AddALocationPage(string profile, string device) : base(profile, device) { }

        public async Task AddANewLocation()
        {
            //TODO: Add steps to add a new location
        }
    }
}
