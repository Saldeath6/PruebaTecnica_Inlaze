using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.InlazeAutomation.Pages
{
    public class SignUpPage : BasePage
    {
        public SignUpPage(IWebDriver driver) : base(driver)
        {
        }

        private By FullNameInputSelector => By.Id("full-name");
        private By EmailInputSelector => By.Id("email");
        private By PasswordInputSelector => By.XPath("//input[@class='input input-bordered join-item w-full' and @id='password']");
        private By ConfirmPasswordInputSelector => By.XPath("//input[@class='input input-bordered join-item w-full' and @id='confirm-password']");
        private By SignUpButtonSelector => By.CssSelector("button[type='submit']");

        public void EnterFullName(string fullName)
        {
            EnterText(FullNameInputSelector, fullName);
        }

        public void EnterEmail(string email)
        {
            EnterText(EmailInputSelector, email);
        }

        public void EnterPassword(string password)
        {
            EnterText(PasswordInputSelector, password);
        }

        public void EnterConfirmPassword(string confirmPassword)
        {
            EnterText(ConfirmPasswordInputSelector, confirmPassword);
        }

        public void ClickSignUpButton()
        {
            ClickElement(SignUpButtonSelector);
        }
        
    }
}

