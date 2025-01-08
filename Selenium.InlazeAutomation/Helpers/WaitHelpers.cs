using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.InlazeAutomation.Helpers
{
    public class WaitHelpers
    {
        protected static IWebDriver _driver;
        protected static WebDriverWait _wait;

        public WaitHelpers(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(60));
        }

        public static void Initialize(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(60));
        }

        /// <summary>
        /// Espera a que un elemento sea visible en el DOM durante un tiempo determinado.
        /// Intenta localizar el elemento usando la función proporcionada y verifica si está visible.
        /// Si el elemento no se encuentra visible en el tiempo especificado, lanza una excepción TimeoutException.
        /// </summary>
        /// <param name="getElementFunc">Función que devuelve el elemento a localizar.</param>
        /// <param name="timeoutInSeconds">Tiempo máximo de espera en segundos antes de lanzar una excepción (por defecto 60 segundos).</param>
        /// <returns>Devuelve el elemento localizado y visible en el DOM.</returns>
        /// <exception cref="TimeoutException">Se lanza si el elemento no se hace visible dentro del tiempo especificado.</exception>
        public static IWebElement WaitForElementToBeVisible(Func<IWebElement> getElementFunc, int timeoutInSeconds = 60)
        {
            IWebElement element = null;
            Stopwatch stopwatch = Stopwatch.StartNew();

            while (stopwatch.Elapsed.TotalSeconds < timeoutInSeconds)
            {
                try
                {
                    element = getElementFunc();
                    if (element.Displayed)
                    {
                        return element;
                    }
                }
                catch (NoSuchElementException) { }
                catch (StaleElementReferenceException) { }
                Thread.Sleep(500);
            }
            throw new TimeoutException($"The element was not visible after wait time");
        }

        /// <summary>
        /// Espera a que un botón se vuelva clickeable y luego intenta hacer clic en él.
        /// El método realiza varios intentos hasta que el botón sea clickeable o se alcance el límite de intentos.
        /// </summary>
        /// <param name="buttonName">El elemento del botón en el que se intenta hacer clic.</param>
        /// <remarks>
        /// Si después de varios intentos el botón no es clickeable, se muestra un mensaje en la consola indicando el fallo.
        /// </remarks>
        public static void WaitForButtonToBeClickable(IWebElement buttonName)
        {
            int maxAttempts = 30;
            int realAttempt = 0;

            while (realAttempt < maxAttempts)
            {
                try
                {
                    IWebElement button = buttonName;
                    if (button.Enabled && button.Displayed)
                    {
                        button.Click();
                        break;
                    }
                }
                catch (NoSuchElementException) { }
                catch (ElementNotInteractableException) { }
                Thread.Sleep(TimeSpan.FromSeconds(100));
                realAttempt++;
            }

            if (realAttempt == maxAttempts)
            {
                Console.WriteLine("El botón no se hizo cliclkeable después de varios intentos.");
            }
        }
    }
}
