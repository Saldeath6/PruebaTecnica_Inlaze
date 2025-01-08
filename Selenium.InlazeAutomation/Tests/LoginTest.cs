using Selenium.InlazeAutomation.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// En este caso de prueba se valida que al iniciar sesión, la web muestre el nombre de usuario correspondiente.
/// </summary>

namespace Selenium.InlazeAutomation.Tests
{
    [TestClass]
    public class LoginTest : BaseTest
    {
        private SignInPage _signInPage;
        private SignUpPage _signUpPage;
        private PanelPage _panelPage;

        [TestMethod]
        [DataRow("chrome", 0, "Registrar Usuario")]
        [DataRow("firefox", 0, "Registrar Usuario")]
        public void LoginTest_TC01(string browser, int rowData, string scenary)
        {
            // Arrange
            TestCleanup();
            InitializeDriver(browser);

            _signInPage = new SignInPage(_driver);
            _signUpPage = new SignUpPage(_driver);
            _panelPage = new PanelPage(_driver);            

            var excelFilePath = "..\\..\\..\\Data\\Data.xlsm";
            var sheetName = "LoginTest_TC01";
            var excelData = ReadExcelData(excelFilePath, sheetName);

            var HomeUrl = excelData.Rows[rowData]["HomeUrl"].ToString();
            var Email = excelData.Rows[rowData]["Email"].ToString();
            var Password = excelData.Rows[rowData]["Password"].ToString();
            var ExpectedText = excelData.Rows[rowData]["ExpectedText"].ToString();

            // Act
            _driver.Navigate().GoToUrl(HomeUrl);

            // Iniciar sesión
            _signInPage.LoginMethod(Email, Password);

            // Assert
            string ActualText = _panelPage.GetTextUserName();
            Assert.IsTrue(ActualText.Contains(ExpectedText),
                $"El nombre capturado no coincide con el nombre esperado del usuario, se esperaba:'{ExpectedText}', el nombre capturado fue:'{ActualText}'");


        }
    }
}
