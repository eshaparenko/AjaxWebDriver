using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AjaxWebDriver
{
    class WaitTool
    {
        public static int DEFAULT_WAIT_4_ELEMENT = 7;
        public static int DEFAULT_WAIT_4_PAGE = 12;

        public static IWebElement WaitForElement(IWebDriver driver, By by, int timeOutInSeconds)
        {
            IWebElement element;
            try
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                element = wait.Until(ExpectedConditions.ElementIsVisible(by));
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(DEFAULT_WAIT_4_ELEMENT);
                return element;

            }
            catch (Exception e)
            {

                Console.WriteLine(e.StackTrace);
            }
            return null;
        }
        public static IWebElement WaitForElementPresent(IWebDriver driver, By by, int timeOutInSeconds)
        {
            IWebElement element;
            try
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                element = wait.Until(ExpectedConditions.ElementExists(by));
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(DEFAULT_WAIT_4_PAGE);
                return element;

            }
            catch (Exception e)
            {

                Console.WriteLine(e.StackTrace);
            }
            return null;
        }
        public static bool WaitForJqueryProcessing(IWebDriver driver, int timeOutInSeconds)
        {
            bool jQcondition = false;
            try
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                jQcondition = wait.Until(d=>(bool)(d as IJavaScriptExecutor).ExecuteScript("return $.active == 0"));
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(DEFAULT_WAIT_4_PAGE);

                return jQcondition;

            }
            catch (Exception e)
            {

                Console.WriteLine(e.StackTrace);
            }
            return jQcondition;
        }

    }
}
