using NUnit.Framework;
using System.Threading.Tasks;
using BrowserStackIntegration;
using System.Collections.Generic;

namespace GoogleAnalyticsTests
{
    public class WhenTestingGoogleAnalyticsCalls : GoogleAnalytics
    {
        [Test]
        public async Task NetworkLogTrialRun()
        {
            await GetNetworkLogs(1);
        }
    }
}