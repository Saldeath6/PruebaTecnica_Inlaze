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

        /// <summary>
        /// Constructor de la clase BasePage.
        /// Inicializa el controlador del navegador y configura los ayudantes de espera.
        /// </summary>
        /// <param name="driver">Instancia de IWebDriver para interactuar con el navegador.</param>
        public BasePage(IWebDriver driver)
        {
            _driver = driver;
            WaitHelpers.Initialize(_driver);
        }

        /// <summary>
        /// Encuentra un elemento en la página usando un localizador y espera a que sea visible.
        /// </summary>
        /// <param name="locator">Localizador del elemento (por ejemplo, By.Id, By.CssSelector).</param>
        /// <returns>El elemento encontrado como IWebElement.</returns>
        protected IWebElement FindElement(By locator)
        {
            return WaitHelpers.WaitForElementToBeVisible(() => _driver.FindElement(locator));
        }

        /// <summary>
        /// Ingresa texto en un campo de entrada de texto.
        /// Verifica que el elemento sea visible y habilitado antes de interactuar con él.
        /// </summary>
        /// <param name="locator">Localizador del elemento de entrada de texto.</param>
        /// <param name="text">Texto que se desea ingresar en el campo.</param>
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

        /// <summary>
        /// Hace clic en un elemento de la página.
        /// Espera a que el botón sea clicable antes de realizar la acción.
        /// </summary>
        /// <param name="locator">Localizador del elemento al que se le hará clic.</param>
        protected void ClickElement(By locator)
        {
            var element = FindElement(locator);
            WaitHelpers.WaitForButtonToBeClickable(element);
        }

        /// <summary>
        /// Obtiene el texto de un elemento de la página.
        /// </summary>
        /// <param name="locator">Localizador del elemento del cual se desea obtener el texto.</param>
        /// <returns>El texto del elemento como una cadena.</returns>
        protected string GetElementText(By locator)
        {
            var element = FindElement(locator);
            return element.Text;
        }
    }
}

