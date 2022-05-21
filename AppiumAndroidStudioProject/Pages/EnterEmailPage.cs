//using NHSx.Mobile.Framework.Utils;
using AppiumAndroidStudioProject.Utils.Browser;
using OpenQA.Selenium;


namespace NHSx.Mobile.Framework.Pages.Browser
{
    public class EnterEmailPage
    {
        private IWebDriver _driver;

        public EnterEmailPage(IWebDriver driver) => _driver = driver;

        private IWebElement PageHeaderText => _driver.FindElement(By.XPath("//h1[contains(text(),'Enter your email address')]"));
        private IWebElement EmailAddress => _driver.FindElement(By.XPath("//input[@id='user-email']"));
        private IWebElement ContinueButton => _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]"));
        private By Password => By.XPath("//*[@id='password-input']");
        private By EmailPgHeader => By.XPath("//h1[contains(text(),'Enter your email address')]");
        private By EmailId => By.XPath("//input[@id='user-email']");

        private IWebElement _acceptCookies => _driver.FindElement(By.XPath("//button[@id='nhsuk-cookie-banner__link_accept']"));
        private IWebElement Agreeandcontinuebutton => _driver.FindElement(By.XPath("//button[text()=' Agree and continue ']")); 
        public bool GetEnterEmailPageHeaderText()
        {
            EmailPgHeader.WaitForElementToBeVisible(_driver);
            return PageHeaderText.IsDisplayed();
        }

        public void EnterEmailAddress(string Email)
        {
            EmailId.WaitForElementToBeVisible(_driver);
            EmailAddress.SetInput(Email);
        }

        public void ClickOnContinueButton()
        {
            ContinueButton.Click();
            try
            {
                Agreeandcontinuebutton.ClickOnElement();
            }
            catch(NoSuchElementException)
            {
                System.Console.WriteLine("Agreeandcontinuebutton is not displayed");
            }
            
        }
        public void WaitUntilPasswordDisplayed()
        {
            Password.WaitForElementToBeVisible(_driver, 30);
        }

        public void AcceptCookies()
        {

            if (_acceptCookies.IsDisplayed())
                _acceptCookies.ClickOnElement();
        }

        public void ScrollByCoordinates()
        {
            _driver.ScrollByCoOrdinates(8, -360);
        }
    }
}