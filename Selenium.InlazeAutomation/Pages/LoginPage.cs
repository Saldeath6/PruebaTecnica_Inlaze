using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.InlazeAutomation.Pages
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        private By EmailInput => By.Id("email");
        private By PasswordInput => By.Id("password");
        private By SignUpText => By.CssSelector(".font-bold.text-primary");
        private By AlertMessage => By.XPath("//app-toast[not(contains(@class, 'opacity-0') or contains(@class, 'hidden'))]//div[@role='alert']\r\n");

        public void ClickSignUpText()
        {
            ClickElement(SignUpText);
        }

        public string GetAlertMessage()
        {
            return GetElementText(AlertMessage);
        }
    }
}
