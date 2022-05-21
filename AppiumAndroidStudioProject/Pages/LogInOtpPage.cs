using AppiumAndroidStudioProject.Utils.Browser;
using OpenQA.Selenium;

namespace NHSx.Mobile.Framework.Pages.Browser
{
    public class LogInOtpPage
    {
        private IWebDriver _driver;

        public LogInOtpPage(IWebDriver driver) => _driver = driver;

        private By Menu => By.XPath("//*[@id='toggle-menu']");
        private IWebElement SecurityCode => _driver.FindElement(By.XPath("//input[@id='otp-input']"));

        private By OTP => By.XPath("//input[@id='otp-input']");
        public IWebElement ProveYourIdentity => _driver.FindElement(By.XPath("//h1[@id='grace-period-active-user-header']"));
        public IWebElement SkipBtnToProveIdentity => _driver.FindElement(By.XPath("//button[@class='nhsuk-button nhsuk-button--secondary undefined']"));

        public void EnterOTP(string PasswordValue)
        {
            SecurityCode.SendKeys(PasswordValue);
        }

        public void WaiUntilMinuDiaplayed()
        {
            //Menu.WaitForElementToBeVisible(_driver, Settings.WAIT_TIME);
        }

        public void WaiUntilOTPFieldDiaplayed()
        {
            OTP.WaitForElementToBeVisible(_driver, 15);
        }

        public void SkipProveYourIdentity()
        {
            if (ProveYourIdentity.Displayed == true)
            {
                SkipBtnToProveIdentity.Click();
            }
        }
    }
}