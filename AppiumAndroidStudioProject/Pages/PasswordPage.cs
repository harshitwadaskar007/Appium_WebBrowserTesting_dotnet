using AppiumAndroidStudioProject.Utils.Browser;
using OpenQA.Selenium;

namespace NHSx.Mobile.Framework.Pages.Browser
{
    public class PasswordPage
    {
        private IWebDriver _driver;

        public PasswordPage(IWebDriver driver) => _driver = driver;

        private IWebElement Password => _driver.FindElement(By.XPath("//input[@id='password-input']"));
        private By ByPassword => By.XPath("//input[@id='password-input']");

        private By GoBack => By.XPath("//*[@label='Go back']");

        public void EnterPassword(string PasswordValue)
        {
            Password.SendKeys(PasswordValue);
        }
        public void WaitUntilPasswordDisplayed()
        {
            ByPassword.WaitForElementToBeVisible(_driver, 15);
        }
    }
}