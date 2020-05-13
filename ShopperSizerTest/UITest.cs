using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ShopperSizerTest
{
    [TestClass]
    public class UITest
    {
        private static readonly string DriverDirectory = "E:\\drivers for selenium";
        private static IWebDriver _driver;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            _driver = new ChromeDriver(DriverDirectory);

        }

        [ClassCleanup]
        public static void TearDown()
        {
            _driver.Dispose();
        }

        [TestMethod]
        public void TestMethod1()
        {
            string expected = "200";

            _driver.Navigate().GoToUrl("http://localhost:3000/chartview.htm");
            Assert.AreEqual("Chart View - Shopper Sizer",_driver.Title);

            IWebElement inputElement1 = _driver.FindElement(By.Id("valueInput"));
            inputElement1.SendKeys(expected);

            IWebElement buttonElement = _driver.FindElement(By.Id("saveButton"));
            buttonElement.Click();

            Thread.Sleep(3000);

            IWebElement outputElement = _driver.FindElement(By.Id("liveNumber"));
            int Livenumber = int.Parse(outputElement.Text);

            IWebElement outputElement2 = _driver.FindElement(By.Id("remaining"));
            int Remaining = int.Parse(outputElement2.Text);

            int result = Livenumber + Remaining;

            Assert.AreEqual(int.Parse(expected),result);
        }
    }
}
