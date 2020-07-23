using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecFlowTest
{
    class PriceManagmentDropDownPageObject
    {
        private IWebDriver _webDriver;

        public readonly By _packages = By.XPath("//*[@id=\"packages\"]");
        public readonly By _agreements = By.XPath("//*[@id=\"agreements\"]");
        public readonly By _approvals = By.XPath("//*[@id=\"approvals\"]");
        public readonly By _calcEngineStatus = By.XPath("//*[@id=\"testHarnessLink\"]");


        public PriceManagmentDropDownPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public PriceManagmentDropDownPageObject ClickPackages()
        {
            _webDriver.FindElement(_packages).Click();
            return new PriceManagmentDropDownPageObject(_webDriver);
        }
        public PriceManagmentDropDownPageObject ClickAgreements()
        {
            _webDriver.FindElement(_agreements).Click();
            return new PriceManagmentDropDownPageObject(_webDriver);
        }
        public PriceManagmentDropDownPageObject ClickApprovals()
        {
            _webDriver.FindElement(_approvals).Click();
            return new PriceManagmentDropDownPageObject(_webDriver);
        }
        public PriceManagmentDropDownPageObject ClickCalcEngineStatus()
        {
            _webDriver.FindElement(_calcEngineStatus).Click();
            return new PriceManagmentDropDownPageObject(_webDriver);
        }
    }
}
