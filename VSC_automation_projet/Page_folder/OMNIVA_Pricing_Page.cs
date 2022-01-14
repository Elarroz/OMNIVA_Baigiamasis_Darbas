using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSC_automation_projet.Page_folder
{
    internal class OMNIVA_Pricing_Page : BasePage
    {
        private const string PageAddress = "https://mano.omniva.lt/parcel/new";
        
        private IWebElement _ParcelSize => Driver.FindElement(By.CssSelector("#maincontent > div.parcel2 > form > div.parcel2__" +
            "split-wrapper > div:nth-child(1) > div:nth-child(1) > div.radio2 > label:nth-child(2)"));
        private IWebElement _ExtraFeeCheckBox => Driver.FindElement(By.CssSelector("#maincontent > div.parcel2 > form > div.parcel2__" +
            "split-wrapper > div:nth-child(1) > div.fieldset2.fieldset2--empty > label > div"));
        private IWebElement _FinalPrice => Driver.FindElement(By.CssSelector("#maincontent > div.form-footer2-wrapper " +
            "> div > p"));


        public OMNIVA_Pricing_Page(IWebDriver webdriver) : base(webdriver) { } //konstruktorius
        public OMNIVA_Pricing_Page NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
            {
                Driver.Url = PageAddress;
            }

            return this;
        }

        public void SelectParcelSize()
        {
            _ParcelSize.Click();
        }

        public void CheckTheCheckBox(bool CheckedOrNot)
        {
            if (CheckedOrNot)
            {
                _ExtraFeeCheckBox.Click();
            }
        }

        public void EvaluateFinalPrice(string ExpectedResult)
        {
                Assert.AreEqual(ExpectedResult, _FinalPrice, "Price is incorrect");
            
        }
    }
}
