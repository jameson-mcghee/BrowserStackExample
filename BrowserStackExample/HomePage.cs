using OpenQA.Selenium.Appium;
using System;
using System.Collections.Generic;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Support.PageObjects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using BrowserStackIntegration;

namespace BrowserStackIntegration
{
    public class HomePage
    {
        

        public HomePage()
        {
            //
        }


        public IList <IWebElement> InPageAds (IWebDriver driver)
        {
            try
            {
                IList<IWebElement> adlistHomePage = driver.FindElements(By.Name("module|3|advertisementModule|ad|||")); //     driver.androidDriver.FindElementsByName("//*"));
                return adlistHomePage;
            }
            catch (Exception e)
            {
                driver.Close();
                throw new Exception("Can't find it. " + " " + e);
            }
        }

        private By ByAccessibilityId(string v)
        {
            throw new NotImplementedException();
        }
    }
}
