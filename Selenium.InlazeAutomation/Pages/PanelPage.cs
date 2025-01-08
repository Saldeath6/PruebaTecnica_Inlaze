using OpenQA.Selenium;
using Selenium.InlazeAutomation.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.InlazeAutomation.Pages
{
    public class PanelPage : BasePage
    {
        public PanelPage(IWebDriver driver) : base(driver)
        {
        }

        private By UserNameText => By.CssSelector("h2[class='font-bold']");
        private By AvatarButton => By.CssSelector(".btn.btn-ghost.btn-circle.avatar");
        private By LogOutButton => By.XPath("//ul[@class='menu menu-sm dropdown-content mt-3 z-[1] p-2 shadow bg-base-100 rounded-box w-52']//a[text()='Logout']");

        public string GetTextUserName()
        {
            return GetElementText(UserNameText);
        }

        public void ClickOnAvatarButton()
        {
            ClickElement(AvatarButton);
        }

        public void ClickOnLogOutButton()
        {
            ClickElement(LogOutButton);
        }
    }
}
