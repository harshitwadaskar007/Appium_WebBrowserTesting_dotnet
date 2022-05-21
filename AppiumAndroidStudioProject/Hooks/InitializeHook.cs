using System;
using System.Threading;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using AppiumAndroidStudioProject.Drivers;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium;
using AppiumAndroidStudioProject.Utils.Browser;
using NHSx.Mobile.Framework.Pages.Browser;

namespace AppiumAndroidStudioProject.Hooks
{
    [Binding]
    public class InitializeHook
    {
        private readonly ScenarioContext _scenarioContext;
        //AppiumDriver _driver;
        private IWebDriver _driver;
        private EnterEmailPage _enterEmailPage;
        private PasswordPage _passwordPage;
        private LogInOtpPage _logInOTP;
        private HomePage _homePage;
        public InitializeHook(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public void Initialeze()
        {
            AppiumDriver appiumDriver = new AppiumDriver(ScenarioContext.Current);
            //var driver = appiumDriver.InitializeAppium();
            var driverOptions = new AppiumOptions();
            driverOptions.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Android");
            driverOptions.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, "9");
            driverOptions.AddAdditionalCapability(MobileCapabilityType.DeviceName, "emulator-5554");
            driverOptions.AddAdditionalCapability(MobileCapabilityType.BrowserName, "Chrome");
            driverOptions.AddAdditionalCapability("chromedriverExecutableDir", @"C:\Users\harshit.wadaskar\Desktop\Driver");
            var driver = new AndroidDriver<AppiumWebElement>(new Uri("http://127.0.0.1:4723/wd/hub"), driverOptions);
            driver.Navigate().GoToUrl("https://stage2.covid-status.service.nhsx.nhs.uk");
            _enterEmailPage = new EnterEmailPage(driver);
            _passwordPage = new PasswordPage(driver);
            _logInOTP = new LogInOtpPage(driver);
            _homePage = new HomePage(driver);

            ContinueButton.ClickOnElement(driver);
            //ClickContinueButton();
            _enterEmailPage.EnterEmailAddress("ncnhsaos+1200@gmail.com");
            _enterEmailPage.ClickOnContinueButton();
            //Additional Continue Button
            _enterEmailPage.ScrollByCoordinates();
            _enterEmailPage.ClickOnContinueButton();
            _enterEmailPage.WaitUntilPasswordDisplayed();
            _passwordPage.EnterPassword("Status$12");
            _enterEmailPage.ClickOnContinueButton();
            _logInOTP.WaiUntilOTPFieldDiaplayed();
            _logInOTP.EnterOTP("190696");
            _enterEmailPage.ClickOnContinueButton();
            _homePage.agreeAndContinue();
            try
            {
                

            }
            catch (Exception e)
            {

            };
        }

        public By ContinueButton => By.CssSelector(".nhsuk-login-button.undefined");

        public void ClickContinueButton()
        {
            ContinueButton.ClickOnElement(_driver);
        }

    }
}
