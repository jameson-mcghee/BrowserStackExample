using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace NonMobileAppTests
{
    public class BrowserStackLocalTesting
    {
        [Test]
        public async Task LocalTesting()
        {
            await BSLocalTesting();
        }

        public async Task BSLocalTesting()
        {
            string userName = Environment.UserName;
            System.Diagnostics.Process.Start($@"C:/Users/{userName}/Downloads/BrowserStackLocal-win32/BrowserStackLocal.exe", "--key QsxV3rKzyffetYB8jhpx");
        }
    }
}
