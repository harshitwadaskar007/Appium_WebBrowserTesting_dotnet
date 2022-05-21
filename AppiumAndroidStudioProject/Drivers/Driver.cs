using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppiumAndroidStudioProject.Drivers
{
    public class Driver
    {
        public IWebDriver driver { get; set; }
        public AndroidDriver<AndroidElement> AndroidDriver { get; set; }
        //public IOSDriver<IOSElement> IOSDriver { get; set; }

        public string _downloadFolder = @"%USERPROFILE%\Downloads\";
        private TimeSpan INIT_TIMEOUT_SEC = TimeSpan.FromSeconds(180);
        private TimeSpan IMPLICIT_TIMEOUT_SEC = TimeSpan.FromSeconds(10);
        public AppiumDriver<AppiumWebElement> drivers { get; set; }

        public AndroidDriver<AppiumWebElement> InitializeAppium()
        {
            var driverOptions = new AppiumOptions();
            driverOptions.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Android");
            driverOptions.AddAdditionalCapability(MobileCapabilityType.DeviceName, "Pixel XL API 28");
            driverOptions.AddAdditionalCapability(MobileCapabilityType.App, "Chrome");
            //driverOptions.AddAdditionalCapability(MobileCapabilityType.chr, "Android");

            Uri url = new Uri("https://stage2.covid-status.service.nhsx.nhs.uk");
            driver = new AndroidDriver<AndroidElement>(url, driverOptions, INIT_TIMEOUT_SEC);


            return new AndroidDriver<AppiumWebElement>(new Uri("http://localhost:4723/wd/hi/hub"), driverOptions);

        }
    }
}
