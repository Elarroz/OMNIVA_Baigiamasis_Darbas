using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSC_automation_projet.Page_folder;

namespace VSC_automation_projet.Test_folder
{
    internal class OMNIVA_Login_Test
    {

        [Test]
        public static void UserLogin()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            driver.Url = "https://www.omniva.lt/privatus/nustatymai/prisijungimas";

            OMNIVA_Login_Page page = new OMNIVA_Login_Page(driver); //objektas, kvieciantis page'o klase
           

            string name = "Rasa Pociunaite";
            string password = "nhbCq2y8";
            string logged_user_name = "RASA";

            page.InsertNameToNameInputField(name);
            page.InsertToPasswordInputField(password);
            page.ClickLoginButton();
            page.VerifyIfUserLoginSuccessful(logged_user_name);

            driver.Close();

        }

    }
}
