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
using OpenQA.Selenium.Firefox;

namespace Selenium.InlazeAutomation.Tests
{
    public abstract class BaseTest
    {
        protected IWebDriver _driver;
        protected WebDriverWait _wait;

        /// <summary>
        /// Método de inicialización que se ejecuta antes de cada prueba.
        /// Puede ser sobrescrito por las clases derivadas para agregar configuraciones específicas.
        /// </summary>
        [TestInitialize]
        public virtual void TestInitialize()
        {

        }

        /// <summary>
        /// Método de limpieza que se ejecuta después de cada prueba.
        /// Se asegura de cerrar y liberar los recursos del navegador.
        /// </summary>
        [TestCleanup]
        public void TestCleanup()
        {
            _driver?.Quit();
        }

        /// <summary>
        /// Inicializa el controlador del navegador (WebDriver) según el navegador especificado.
        /// Configura el tiempo de espera explícito y maximiza la ventana del navegador.
        /// </summary>
        /// <param name="browser">Nombre del navegador a utilizar (por ejemplo, "chrome" o "firefox").</param>
        protected void InitializeDriver(string browser)
        {
            switch (browser.ToLower())
            {
                case "chrome":
                    _driver = new ChromeDriver();
                    break;
                case "firefox":
                    _driver = new FirefoxDriver();
                    break;
                default:
                    throw new ArgumentException($"Navegador no soportado: {browser}");
            }

            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(60));
            WaitHelpers.Initialize(_driver);
            _driver.Manage().Window.Maximize();
        }

        /// <summary>
        /// Obtiene el directorio base del proyecto donde se está ejecutando el código.
        /// </summary>
        /// <returns>Ruta del directorio base del proyecto.</returns>
        protected string GetProjectDirectory()
        {
            return AppDomain.CurrentDomain.BaseDirectory;
        }

        /// <summary>
        /// Lee los datos de un archivo Excel y devuelve la información en forma de tabla.
        /// </summary>
        /// <param name="filePath">Ruta completa del archivo Excel.</param>
        /// <param name="sheetName">Nombre de la hoja de cálculo que se desea leer.</param>
        /// <returns>Datos de la hoja de cálculo en formato DataTable.</returns>
        protected DataTable ReadExcelData(string filePath, string sheetName)
        {
            var dataHelpers = new DataHelpers();
            return dataHelpers.ReadExcelData(filePath, sheetName);
        }
    }
}

