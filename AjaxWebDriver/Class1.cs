using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AjaxWebDriver
{
    [TestFixture]
    public class Class1
    {
        IWebDriver driver;
        [Test]
        public void testAjax()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://www.w3schools.com/xml/ajax_intro.asp";

            string originalText = driver.FindElement(By.CssSelector("div#demo>h2")).Text;

            driver.FindElement(By.CssSelector("div#demo>button")).Click();

            bool isReady = WaitTool.WaitForJqueryProcessing(driver, 15);
            if (isReady)
            {
                string afterAJAX_Call_Text = driver.FindElement(By.CssSelector("div#demo>h1")).Text;
                Console.WriteLine("Before "+ originalText);
                Assert.False(originalText.Equals(afterAJAX_Call_Text, StringComparison.OrdinalIgnoreCase));
                Console.WriteLine("After " + afterAJAX_Call_Text);
            }
            else
            {
                Assert.Fail("Verify Failed: AJAX XMLHttpRequest is not ready");
            }


            
        }
    }
}
