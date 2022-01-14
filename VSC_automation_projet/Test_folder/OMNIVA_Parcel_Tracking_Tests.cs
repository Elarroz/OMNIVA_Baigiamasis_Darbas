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
    internal class OMNIVA_Parcel_Tracking_Tests
    {

        private static IWebDriver _driver;

        [OneTimeSetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.Manage().Window.Maximize();
            _driver.Url = "https://www.omniva.lt/privatus/nustatymai/prisijungimas";
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            _driver.Close();
        }

        [TestCase("CE7140204312EE", "Siunta atsiimta/ pristatyta gavėjui", TestName = "ParcelTrackingCorrectNumber")]
        [TestCase("CE7140204312E", "Siunta atsiimta/ pristatyta gavėjui", TestName = "ParcelTrackingWrongNumber")]

        public static void ParcelTracking(string TrackingNumber, string ExpectedResult)
        {
            OMNIVA_Parcel_Tracking_Page page = new OMNIVA_Parcel_Tracking_Page(_driver); //objektas, kvieciantis page'o klase

            page.FillInnTrackingNumberInputField(TrackingNumber);
            page.ClickTrackingNumberSubmitButton();
            page.VerifyResult(ExpectedResult);
        }
    }
}
