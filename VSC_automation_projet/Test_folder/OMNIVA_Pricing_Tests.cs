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
    internal class OMNIVA_Pricing_Tests
    {

        private static IWebDriver _driver;

        [OneTimeSetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.Manage().Window.Maximize();
            _driver.Url = "https://mano.omniva.lt/parcel/new";
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            _driver.Close();
        }

        [TestCase(false, "2.89€", TestName = "Not checked")]
        [TestCase(true, "4.83€", TestName = "Checked")]

        public static void ParcelTracking(bool CheckedOrNot, string ExpectedResult)
        {
            OMNIVA_Pricing_Page page = new OMNIVA_Pricing_Page(_driver);

            page.SelectParcelSize();
            page.CheckTheCheckBox(CheckedOrNot);
            page.EvaluateFinalPrice(ExpectedResult);
        }
        
       





    }
}

    























