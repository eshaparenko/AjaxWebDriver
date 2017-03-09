using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AjaxWebDriver
{
    [TestFixture]
    public class Class1
    {
        IWebDriver driver;
        void UseChrome()
        {
            var options = new ChromeOptions();
            options.AddArgument("start-maximized");
            driver = new ChromeDriver(options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);
        }

        [SetUp]
        public void SetUp()
        {
            UseChrome();
            //Dictionary<string, bool> capabilitiesMap = new Dictionary<string, bool> { { "takeScreenshot", true } };

            //DesiredCapabilities capabilities = DesiredCapabilities.Chrome();
            //capabilities.SetCapability(ChromeOptions.Capability, options);
            //driver = new RemoteWebDriver(capabilities);
            //driver.Manage().Window.Maximize();
        }
        [TearDown]
        public void AfterTest()
        {
            driver.Close();
        }
        [Test]
        //[Ignore("Ignore a test")]
        public void testAjax()
        {
            driver.Url = "https://www.w3schools.com/xml/ajax_intro.asp";

            string originalText = driver.FindElement(By.CssSelector("div#demo>h2")).Text;

            driver.FindElement(By.CssSelector("div#demo>button")).Click();

            bool isReady = WaitTool.WaitForJqueryProcessing(driver, 15);
            if (isReady)
            {
                string afterAJAX_Call_Text = driver.FindElement(By.CssSelector("div#demo>h1")).Text;
                Console.WriteLine("Before " + originalText);
                Assert.False(originalText.Equals(afterAJAX_Call_Text, StringComparison.OrdinalIgnoreCase));
                Console.WriteLine("After " + afterAJAX_Call_Text);
            }
            else
            {
                Assert.Fail("Verify Failed: AJAX XMLHttpRequest is not ready");
            }
        }
            [Test]
        public void testActions()
        {
            driver.Url = "http://book.theautomatedtester.co.uk/";

            IWebElement chapter1Link = driver.FindElement(By.LinkText("Chapter1"));
            chapter1Link.Click();

            //memoField.Click();
            IWebElement memoField = driver.FindElement(By.Id("html5div"));
            Actions builder = new Actions(driver);
            builder.Click(memoField).Perform();

            memoField.SendKeys(Keys.Control+"a");
            memoField.SendKeys(Keys.Control + "c");

            IWebElement homePageLink = driver.FindElement(By.LinkText("Home Page"));
            homePageLink.Click();

            IWebElement editBox = driver.FindElement(By.Id("q"));
            //editBox.Click();
            Actions builder1 = new Actions(driver);
            builder1.MoveByOffset(editBox.Location.X, editBox.Location.Y)
                .Click().Perform();
            //editBox.Click();

            editBox.SendKeys(Keys.Control+"v");

        }
        [Test]
        public void SwitchWindowTest()
        {
            driver.Url = "http://book.theautomatedtester.co.uk/";

            IWebElement chapter1Link = driver.FindElement(By.LinkText("Chapter1"));
            chapter1Link.Click();

            IWebElement anotherWindowLink = driver.FindElement(By.Id("multiplewindow"));

            string window1 = driver.CurrentWindowHandle;
            Console.WriteLine(window1);

            anotherWindowLink.Click();

            WaitTool.WaitForElementPresent(driver, By.Id("closepopup"), 5);
            string window2 = driver.WindowHandles[1];
            driver.SwitchTo().Window(window2);

            IWebElement anotherWindowClose = driver.FindElement(By.Id("closepopup"));
            anotherWindowClose.Click();

            driver.SwitchTo().Window(window1);
            IWebElement homePageLink = driver.FindElement(By.LinkText("Home Page"));
            homePageLink.Click();

        }




    }
}
