using System;
using System.Collections.ObjectModel;
using System.Globalization;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace AppiumAndroidStudioProject.Utils.Browser
{
    public static class AppElementExtensions
    {

        public static bool IsDisplayed(this IWebElement element)
        {
            try
            {
                return element.Displayed;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static bool IsDisplayed(this By element, IWebDriver driver)
        {
            element.WaitForElementToBeVisible(driver);
            return driver.FindElement(element).Displayed;
        }
        /// <summary>
        /// Extension Method for Enabled
        /// </summary>
        /// <param name="element"></param>
        /// <returns> bool </returns>
        public static bool IsEnabled(this IWebElement element)
        {
            return element.Enabled;
        }

        /// <summary>
        ///  Extension Method for SENDKEYS
        /// </summary>
        /// <param name="element"></param>
        /// <param name="value"></param>
        public static void SetInput(this IWebElement element, string value)
        {
            try
            {
                if (!string.IsNullOrEmpty(value))
                {
                    element.Clear();
                    element.SendKeys((value));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception Occured: {ex.Message}");
                throw;
            }
        }

        public static void SetInput(this By element, IWebDriver driver, string value)
        {
            try
            {
                if (!string.IsNullOrEmpty(value))
                {
                    driver.FindElement(element).Clear();
                    driver.FindElement(element).SendKeys((value));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception Occured: {ex.Message}");
                throw;
            }
        }


        /// <summary>
        ///  Extension Method for CLICK
        /// </summary>
        /// <param name="element"></param>
        public static void ClickOnElement(this IWebElement element)
        {
            try
            {
                element.Click();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception Occured: {ex.Message}");
                throw;
            }

        }

        public static void ClickOnElement(this By element, IWebDriver driver)
        {
            try
            {
                element.WaitForElementToBeVisible(driver);
                driver.FindElement(element).Click();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception Occured: {ex.Message}");
                throw;
            }

        }

        public static IWebElement GetLinkWebElement(this string linkName, IWebDriver driver)
        {
            try
            {
                return driver.FindElement(By.LinkText(linkName));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception Occured: {ex.Message}");
                throw;
            }

        }
        public static By GetLinkBy(this string linkName, IWebDriver driver)
        {
            try
            {
                return By.PartialLinkText(linkName);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception Occured: {ex.Message}");
                throw;
            }

        }

        public static string GetText(this IWebElement element)
        {
            try
            {
                return element.Text;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception Occured: {ex.Message}");
                throw;

            }

        }
        public static string GetText(this By element, IWebDriver driver)
        {
            try
            {
                element.WaitForElementToBeVisible(driver);
                return driver.FindElement(element).Text;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception Occured: {ex.Message}");
                throw;

            }

        }


        /// <summary>
        ///  Extenstion method to move the cursor to an element using Actions method
        /// </summary>
        /// <param name="element"></param>
        /// <param name="browserBase"></param>
        public static void MoveToElementByAction(this IWebElement element, IWebDriver Driver)
        {
            var action = new Actions(Driver);
            action.MoveToElement(element).Click().Build().Perform();
        }

        public static void ScrollByCoOrdinates(this IWebDriver driver, int x, int y)
        {
            var ts = new TouchAction((IPerformsTouchActions)driver);
            try
            {
                ts.Press(207, 710).MoveTo(x, y).Release().Perform();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static bool WaitForElementToBeVisible(this By byElement, IWebDriver Driver, int waitTimeInSec = 2000)
        {
            bool isVisible = false;
            try
            {
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(waitTimeInSec));
                wait.Until(ExpectedConditions.ElementIsVisible(byElement));
                if (Driver.FindElement(byElement).Displayed)
                {
                    isVisible = true;
                }
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine($"Exception Occured on Page Load : {ex.Message}");
                throw;
            }
            return isVisible;
        }

        public static void ClickAppElement(this IWebElement element)
        {
            try
            {
                element.ClickOnElement();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception Occured: {ex.Message}");
                throw;
            }

        }

        public static string GetPopUpWindowTitle(this string PageName, IWebDriver driver)
        {
            string BaseWindow = driver.CurrentWindowHandle;

            ReadOnlyCollection<string> windowHandles = driver.WindowHandles;
            string popupHandle = "";

            foreach (string handle in windowHandles)
            {
                if (handle != BaseWindow)
                {
                    popupHandle = handle; break;
                }
            }

            driver.SwitchTo().Window(popupHandle);
            string NewWindow = driver.CurrentWindowHandle;
            Console.WriteLine(driver.Title);
            return PageName = driver.Title;
        }

        ///// <summary>
        ///// To click on element with given timeout
        ///// </summary>
        ///// <param name="by"></param>
        ///// <param name="localtimeout"></param>
        //public static void ClickWithTimeOut(this By byElement, LocalTimeout localtimeout, IWebDriver driver)
        //{
        //    bool IsClicked = false;
        //    int timeout = 1;
        //    Exception exception;
        //    do
        //    {
        //        IsClicked = AppElementExtensions.TryClick(byElement, out exception, driver);
        //        if (!IsClicked)
        //        {
        //            System.Threading.Thread.Sleep(1000);
        //            timeout++;
        //        }
        //    } while (!IsClicked && (timeout < (int)localtimeout));
        //    if (!IsClicked)
        //    {
        //        throw exception;
        //    }
        //}

        private static bool TryClick(this By byElement, out Exception exception, IWebDriver driver)
        {
            exception = null;
            try
            {
                driver.FindElement(byElement).Click();
                return true;
            }
            catch (Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool TimeDifferenceInHours(this string startDate, String expiryDate, int hours)
        {
            CultureInfo provider = new CultureInfo("en-GB");

            DateTime start_Date = DateTime.Parse(startDate, provider, DateTimeStyles.AdjustToUniversal);
            DateTime expiry_Date = DateTime.Parse(expiryDate.Substring(0, 12), provider, DateTimeStyles.AdjustToUniversal);
            TimeSpan ts = expiry_Date - start_Date;
            double hrs = ts.TotalHours;
            if (ts.TotalHours <= hours)
                return true;
            else
                return false;

        }

        public static bool WaitForElementToBeEnabled(By byElement, IWebDriver Driver, int waitTimeInSec = 30)
        {
            bool isEnable = false;
            try
            {
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(waitTimeInSec));
                wait.Until(ExpectedConditions.ElementToBeClickable(byElement));
                if (Driver.FindElement(byElement).Enabled)
                {
                    isEnable = true;
                }
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine($"Exception Occured on Page Load : {ex.Message}");
                throw;
            }
            return isEnable;
        }


    }
}