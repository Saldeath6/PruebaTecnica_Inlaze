using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using Selenium.InlazeAutomation.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.InlazeAutomation.Tests
{
    public abstract class BaseTest
    {
        protected IWebDriver _driver;
        protected WebDriverWait _wait;

        [TestInitialize]
        public virtual void TestInitialize()
        {
            _driver = new ChromeDriver();
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(60));
            WaitHelpers.Initialize(_driver);

            // Maximizar pantalla
            _driver.Manage().Window.Maximize();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            //_driver.Quit();
        }

        protected string GetProjectDirectory()
        {
            return AppDomain.CurrentDomain.BaseDirectory;
        }

        protected DataTable ReadExcelData(string filePath, string sheetName)
        {
            var dataHelpers = new DataHelpers();
            return dataHelpers.ReadExcelData(filePath, sheetName);
        }
    }
}
