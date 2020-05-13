using System;
using System.Collections.Generic;
using System.Text;
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
            _driver.Navigate().GoToUrl("http://localhost:3000/chartview.htm");
            Assert.AreEqual("Chart View",_driver.Title);

            IWebElement inputElement1 = _driver.FindElement(By.Id("test"));
            inputElement1.SendKeys("500");

            IWebElement buttonElement = _driver.FindElement(By.Id("SaveButton"));
            buttonElement.Click();

            IWebElement outputElement = _driver.FindElement(By.Id("LiveNumber"));
            int Livenumber = int.Parse(outputElement.Text);

            IWebElement outputElement2 = _driver.FindElement(By.Id("Remaining"));
            int Remaining = int.Parse(outputElement2.Text);

            int result = Livenumber + Remaining;

            Assert.AreEqual(500,result);
        }
    }
}
