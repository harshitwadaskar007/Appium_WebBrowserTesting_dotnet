using OpenQA.Selenium;
using System;
using System.Threading;

namespace AppiumAndroidStudioProject.Utils
{
    public class DriverBrowserExtensions
    {
        private IWebDriver _driver;
        //private TimeSpan INIT_TIMEOUT_SEC = TimeSpan.FromSeconds(180);
        private int IMPLICIT_TIMEOUT_MilliSEC = 1000;

        public DriverBrowserExtensions(IWebDriver driver) => _driver = driver;

        public string GetTitle()
        {
            try
            {
                return _driver.Title;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception Occured: {ex.Message}");
                return null;
            }
        }

        public void SwitchTab(int index)
        {
            var newTab = _driver.WindowHandles[index];
            _driver.SwitchTo().Window(newTab);
        }

        public void WaitSync()
        {
            Thread.Sleep(IMPLICIT_TIMEOUT_MilliSEC);
        }

    }
}
