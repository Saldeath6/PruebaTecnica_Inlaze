using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Selenium.InlazeAutomation.Pages;
using Selenium.InlazeAutomation.Helpers;

namespace Selenium.InlazeAutomation.Tests
{
    [TestClass]
    public class RegisterUserPageTests : BaseTest
    {
        private LoginPage _loginPage;
        private RegisterPage _registerPage;

        [TestMethod]
        [DataRow(0, "Registrar Usuario")]
        public void RegisterUser_TC01(int rowData, string scenary)
        {
            // Arrange
            _loginPage = new LoginPage(_driver);
            _registerPage = new RegisterPage(_driver);

            var excelFilePath = "..\\..\\..\\Data\\Data.xlsm";
            var sheetName = "RegisterUser_TC01";
            var excelData = ReadExcelData(excelFilePath, sheetName);

            var HomeUrl = excelData.Rows[rowData]["HomeUrl"].ToString();
            var FullName = excelData.Rows[rowData]["FullName"].ToString();
            var Email = excelData.Rows[rowData]["Email"].ToString();
            var Password = excelData.Rows[rowData]["Password"].ToString();
            var ExpectedText = excelData.Rows[rowData]["ExpectedText"].ToString();

            // Act

            // Acceder a la página de inicio de sesión
            _driver.Navigate().GoToUrl(HomeUrl);

            // Click en el texto Sign up para acceder al registro
            _loginPage.ClickSignUpText();

            // Completar formulario de registro
            _registerPage.EnterFullName(FullName);
            _registerPage.EnterEmail(Email);
            _registerPage.EnterPassword(Password);
            _registerPage.EnterConfirmPassword(Password);
            _registerPage.ClickSignUpButton();

            // Assert

            // Capturar texto de la alerta
            string ActualText = _loginPage.GetAlertMessage();

            // Verificar que el texto obtenido contenga el texto esperado
            Assert.IsTrue(ActualText.Contains(ExpectedText), $"El texto esperado: '{ExpectedText}', no se encontró dentro del mensaje capturado: '{ActualText}'");
        }
    }
}