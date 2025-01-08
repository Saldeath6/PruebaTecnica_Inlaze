using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Selenium.InlazeAutomation.Helpers;

namespace Selenium.InlazeAutomation.Pages
{
    public abstract class BasePage
    {
        protected IWebDriver _driver;

        public BasePage(IWebDriver driver)
        {
            _driver = driver;
            WaitHelpers.Initialize(_driver);
        }

        // Encuentra un elemento usando un localizador y espera a que sea visible
        protected IWebElement FindElement(By locator)
        {
            return WaitHelpers.WaitForElementToBeVisible(() => _driver.FindElement(locator));
        }

        // Métodos genéricos para interactuar con elementos
        protected void EnterText(By locator, string text)
        {
            var element = FindElement(locator);

            if (element.Displayed && element.Enabled)
            {
                element.Click();
                element.Clear();
                element.SendKeys(text);
            }
            
        }

        // Método para hacer click en un elemento
        protected void ClickElement(By locator)
        {
            var element = FindElement(locator);
            WaitHelpers.WaitForButtonToBeClickable(element);
        }

        // Método para obtener el texto de un elemento
        protected string GetElementText(By locator)
        {
            var element = FindElement(locator);
            return element.Text;
        }

    }
}
