using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using Selenium.InlazeAutomation.Pages;
using Selenium.InlazeAutomation.Helpers;

/// <summary>
/// En este caso de prueba se valida que se registre exitosamente un usuario.
/// </summary>

namespace Selenium.InlazeAutomation.Tests
{
    [TestClass]
    public class RegisterUserPageTest : BaseTest
    {
        private SignInPage _signInPage;
        private SignUpPage _signUpPage;

        [TestMethod]
        [DataRow("chrome", 0, "Registrar Usuario")]
        [DataRow("firefox", 0, "Registrar Usuario")]
        public void RegisterUser_TC01(string browser, int rowData, string scenary)
        {
            // Arrange
            TestCleanup();
            InitializeDriver(browser);

            _signInPage = new SignInPage(_driver);
            _signUpPage = new SignUpPage(_driver);

            var excelFilePath = "..\\..\\..\\Data\\Data.xlsm";
            var sheetName = "RegisterUser_TC01";
            var excelData = ReadExcelData(excelFilePath, sheetName);

            var HomeUrl = excelData.Rows[rowData]["HomeUrl"].ToString();
            var FullName = excelData.Rows[rowData]["FullName"].ToString();
            var Email = excelData.Rows[rowData]["Email"].ToString();
            var Password = excelData.Rows[rowData]["Password"].ToString();
            var ExpectedText = excelData.Rows[rowData]["ExpectedText"].ToString();

            // Act
            _driver.Navigate().GoToUrl(HomeUrl);

            _signInPage.ClickSignUpText();
            _signUpPage.EnterFullName(FullName);
            _signUpPage.EnterEmail(Email);
            _signUpPage.EnterPassword(Password);
            _signUpPage.EnterConfirmPassword(Password);
            _signUpPage.ClickSignUpButton();

            // Assert
            string ActualText = _signInPage.GetAlertMessage();
            Assert.IsTrue(ActualText.Contains(ExpectedText),
                $"El texto esperado: '{ExpectedText}', no se encontró dentro del mensaje capturado: '{ActualText}'");
        }
    }
}

