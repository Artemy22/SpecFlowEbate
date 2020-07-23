using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SpecFlowTest
{
    class LoginTenantTabPageObject
    {
        private IWebDriver _webDriver;

        
        public readonly By _tenantDropDown = By.XPath("//*[@id=\"ddlTenant\"]");
        public readonly By _saveButton = By.XPath("//*[@id=\"save\"]");

        public bool Waiter(int seconds, By element)
        {
            var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(seconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
            return true;
        }
        public LoginTenantTabPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public LoginTenantTabPageObject ChooseFirstTenant()
        {
            Thread.Sleep(1000);
            _webDriver.FindElement(_tenantDropDown).Click();
            _webDriver.FindElement(_saveButton).Click();

            return new LoginTenantTabPageObject(_webDriver);

        }

    }
}




