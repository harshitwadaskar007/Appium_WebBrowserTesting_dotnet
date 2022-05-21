using AppiumAndroidStudioProject.Utils.Browser;
using OpenQA.Selenium;
using System.Threading;

namespace NHSx.Mobile.Framework.Pages.Browser
{
    public class HomePage
    {
        private IWebDriver driver;

        public HomePage(IWebDriver driver) => this.driver = driver;

        public IWebElement HeaderTitle => driver.FindElement(By.CssSelector(".nhsuk-heading-xl"));
        public By Header => By.CssSelector(".nhsuk-heading-xl");
        public IWebElement LoginErrorHeaderTitle => driver.FindElement(By.CssSelector("h1#NhsLoginError-heading-one"));
        public IWebElement linkBacktologin => driver.FindElement(By.CssSelector("a#NhsLoginError-button"));
        public IWebElement agreeAndContinueButton => driver.FindElement(By.XPath("//button[text()=' Agree and continue ']"));
        //public string GetHeaderTitle()
        //{
        //    Header.WaitForElementToBeVisible(driver, Settings.WAIT_TIME);
        //    return HeaderTitle.GetText();
        //}

        //public string GetLoginErrorHeaderTitle()
        //{
        //    Header.WaitForElementToBeVisible(driver, Settings.WAIT_TIME);
        //    return LoginErrorHeaderTitle.GetText();
        //}

        public void ClickBacktoLoginlink()
        {
            linkBacktologin.Click();
        }

        public void agreeAndContinue()
        {
            Thread.Sleep(6000);
            try {
                if (agreeAndContinueButton.IsDisplayed())
                {
                    agreeAndContinueButton.Click();
                }
            }
            catch { }
            
            
        }

    }
}
