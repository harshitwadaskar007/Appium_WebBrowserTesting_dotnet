using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace AppiumAndroidStudioProject.Drivers
{
    public class AppiumDriver
    {
        public AppiumDriver driver { get; set; }
        public AndroidDriver<AndroidElement> AndroidDriver { get; set; }
        //public IOSDriver<IOSElement> IOSDriver { get; set; }
        private ScenarioContext current;
        public string _downloadFolder = @"%USERPROFILE%\Downloads\";
        private TimeSpan INIT_TIMEOUT_SEC = TimeSpan.FromSeconds(180);
        private TimeSpan IMPLICIT_TIMEOUT_SEC = TimeSpan.FromSeconds(10);
        public AppiumDriver<AppiumWebElement> Driver { get; set; }

        public AppiumDriver(ScenarioContext current)
        {
            this.current = current;
        }
        public void  InitializeAppium()
        {
            

            //var driverOptions = new AppiumOptions();
            //driverOptions.AddAdditionalCapability(MobileCapabilityType.DeviceName, "XL_API_28");
            //driverOptions.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Android");
            //driverOptions.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, "9.0");
            //driverOptions.AddAdditionalCapability(MobileCapabilityType.App, "tb://...");
            //driverOptions.AddAdditionalCapability("key", Environment.GetEnvironmentVariable("TB_KEY"));
            //driverOptions.AddAdditionalCapability("secret", Environment.GetEnvironmentVariable("TB_SECRET"));

            var driverOptions = new AppiumOptions();
            driverOptions.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Android");
            driverOptions.AddAdditionalCapability(MobileCapabilityType.DeviceName, "XL_API_28");
            driverOptions.AddAdditionalCapability(MobileCapabilityType.BrowserName, "Browser");
            driverOptions.AddAdditionalCapability("chromedriverExecutable", @"C:\Users\harshit.wadaskar\Desktop\Driver");

            //https://stage2.covid-status.service.nhsx.nhs.uk

            //return new AndroidDriver<AppiumWebElement>(new Uri("http://localhost:4723/wd/hi/hub"), driverOptions);
            //return new AndroidDriver<AppiumWebElement>(new Uri("http://127.0.0.1:4723/wd/hub"), driverOptions);
            var driver = new AndroidDriver<AppiumWebElement>(new Uri("http://127.0.0.1:4723/wd/hub"), driverOptions);

            driver.Navigate().GoToUrl("https://stage2.covid-status.service.nhsx.nhs.uk");
        }
    }
}
