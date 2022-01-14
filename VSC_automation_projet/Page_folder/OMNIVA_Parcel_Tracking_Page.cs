using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSC_automation_projet.Page_folder
{
    internal class OMNIVA_Parcel_Tracking_Page : BasePage
    {
        private const string PageAddress = "https://www.omniva.lt/privatus/nustatymai/prisijungimas";

        private IWebElement _TrackingNumberInputField => Driver.FindElement(By.Name("barcode"));
        private IWebElement _TrackingNumberSubmitButton => Driver.FindElement(By.CssSelector("#search-barcode > form > " +
                "input[type=submit]:nth-child(3)"));
        private IWebElement _ParcelStatusMessage => Driver.FindElement(By.Id("barcode_search_result")).FindElement(By.TagName("td"));
        private IWebElement _ParcelStatusMessageNotFound => Driver.FindElement(By.CssSelector("#barcode_search_result > b > a"));

        public OMNIVA_Parcel_Tracking_Page(IWebDriver webdriver) : base(webdriver) { } //konstruktorius
        public OMNIVA_Parcel_Tracking_Page NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
            {
                Driver.Url = PageAddress;
            }

            return this;
        }

        public void FillInnTrackingNumberInputField(string ParcelTrackingNumber)
        {
            _TrackingNumberInputField.Clear();
            _TrackingNumberInputField.SendKeys(ParcelTrackingNumber);
        }

        public void ClickTrackingNumberSubmitButton()
        {
            _TrackingNumberSubmitButton.Click();
        }

        public void VerifyResult(string ExpectedResult)
        {
            Assert.AreEqual(ExpectedResult, _ParcelStatusMessage.Text, "Probably the number is wrong");
        }
    }
}
