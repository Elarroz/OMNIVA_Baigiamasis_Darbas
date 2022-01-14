using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSC_automation_projet.Page_folder;
using VSC_automation_projet.Tools;

namespace VSC_automation_projet.Test_folder
{
    internal class TestBase
    {
        protected static IWebDriver Driver;

        public static OMNIVA_Login_Page oMNIVA_Login_Page;
        public static OMNIVA_Parcel_Tracking_Page oMNIVA_Parcel_Tracking_Page;
        public static OMNIVA_Pricing_Page oMNIVA_Pricing_Page;

        [OneTimeSetUp]
        public static void Setup()
        {
            //Driver = CustomDriver.GetChromeDriver();

            oMNIVA_Login_Page = new OMNIVA_Login_Page(Driver);
            oMNIVA_Parcel_Tracking_Page = new OMNIVA_Parcel_Tracking_Page(Driver);
            oMNIVA_Pricing_Page = new OMNIVA_Pricing_Page(Driver);
        }


        [OneTimeTearDown]
        public static void OneTimeTearDown()
        {
            Driver.Quit();
        }

        [TearDown]
        public static void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                MyScreenshots.TakeScreenshot(Driver);
            }
        }
    }
}
