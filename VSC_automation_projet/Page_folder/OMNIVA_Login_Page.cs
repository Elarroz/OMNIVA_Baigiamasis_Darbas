using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSC_automation_projet.Page_folder
{
    internal class OMNIVA_Login_Page : BasePage
    {
        private const string PageAddress = "https://www.omniva.lt/privatus/nustatymai/prisijungimas";

        private IWebElement _NameInputField => Driver.FindElement(By.Name("login_name"));
        private IWebElement _PasswordInputField => Driver.FindElement(By.Name("login_password"));
        private IWebElement _LoginButton => Driver.FindElement(By.CssSelector("#content > div.ajax_content > div > " +
                "div.column.no_top_padding > div > form > dl:nth-child(2) > dd > input[type=submit]"));
        private IWebElement _LoggedUserName => Driver.FindElement(By.CssSelector("#content > div.container-header." +
            "dark_transparent.row > div.column.col_21 > a.login-btn > span"));

        public OMNIVA_Login_Page(IWebDriver webdriver) : base(webdriver) { } //konstruktorius
        public OMNIVA_Login_Page NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
            {
                Driver.Url = PageAddress;
            }

            return this;
        }

        public void InsertNameToNameInputField(string text)
        {
            _NameInputField.Clear();
            _NameInputField.SendKeys(text);
        }

        public void InsertToPasswordInputField(string text)
        {
            _PasswordInputField.Clear();
            _PasswordInputField.SendKeys(text);
        }

        public void ClickLoginButton()
        {
            _LoginButton.Click();
        }

        public void VerifyIfUserLoginSuccessful(string ExpectedResult)
        {
            Assert.AreEqual($"{ExpectedResult}", _LoggedUserName.Text, "OOps, not logged in");
        }
    }
}
