using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.InlazeAutomation.Pages
{
    public class SignInPage : BasePage
    {
        public SignInPage(IWebDriver driver) : base(driver)
        {
        }

        private By EmailInput => By.Id("email");
        private By PasswordInput => By.XPath("//input[@class='input input-bordered join-item w-full' and @id='password']");
        private By SignUpText => By.CssSelector(".font-bold.text-primary");
        private By SignUpButton => By.CssSelector("button[type='submit']");
        private By AlertMessage => By.XPath("//app-toast[not(contains(@class, 'opacity-0') or contains(@class, 'hidden'))]//div[@role='alert']\r\n");
        private By FormTitle => By.CssSelector(".text-4xl.font-extrabold.mb-4");

        public void ClickSignUpText()
        {
            ClickElement(SignUpText);
        }

        public string GetAlertMessage()
        {
            return GetElementText(AlertMessage);
        }

        public void LoginMethod(string email, string password)
        {
            EnterText(EmailInput, email);
            EnterText(PasswordInput, password);
            ClickElement(SignUpButton);
        }
        public string GetFormTitle()
        {
            return GetElementText(FormTitle);
        }

    }
}
