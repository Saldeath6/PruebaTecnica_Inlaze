using Selenium.InlazeAutomation.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// En este caso de prueba se valida que se permita cerrar sesión.
/// </summary>

namespace Selenium.InlazeAutomation.Tests
{
    [TestClass]
    public class LogOutTest : BaseTest
    {
        private SignInPage _signInPage;
        private SignUpPage _signUpPage;
        private PanelPage _panelPage;

        [TestMethod]
        [DataRow("chrome", 0, "Registrar Usuario")]
        [DataRow("firefox", 0, "Registrar Usuario")]
        public void LogOut_TC01(string browser, int rowData, string scenary)
        {
            //Arrange
            TestCleanup();
            InitializeDriver(browser);

            _signInPage = new SignInPage(_driver);
            _signUpPage = new SignUpPage(_driver);
            _panelPage = new PanelPage(_driver);

            var excelFilePath = "..\\..\\..\\Data\\Data.xlsm";
            var sheetName = "LogOut_TC01";
            var excelData = ReadExcelData(excelFilePath, sheetName);

            var HomeUrl = excelData.Rows[rowData]["HomeUrl"].ToString();
            var Email = excelData.Rows[rowData]["Email"].ToString();
            var Password = excelData.Rows[rowData]["Password"].ToString();
            var ExpectedText = excelData.Rows[rowData]["ExpectedText"].ToString();

            // Act
            _driver.Navigate().GoToUrl(HomeUrl);
            _signInPage.LoginMethod(Email, Password);
            _panelPage.ClickOnAvatarButton();
            _panelPage.ClickOnLogOutButton();

            // Assert
            string ActualText = _signInPage.GetFormTitle();
            Assert.IsTrue(ActualText.Contains(ExpectedText), $"El texto esperado: '{ExpectedText}', no se encontró dentro del mensaje capturado: '{ActualText}'");
        }
    }
}