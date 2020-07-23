using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using System.Threading;

namespace SpecFlowTest
{
    class FinanceDropDown
    {
        public IWebDriver WebDriver { get; }

        public FinanceDropDown(IWebDriver webDriver)
        {
            WebDriver = webDriver;
        }

        public IWebElement _acrruals => WebDriver.FindElement(By.Id("acrruals"));
        public IWebElement _payments => WebDriver.FindElement(By.Id("payments"));
        public IWebElement _adjustment => WebDriver.FindElement(By.Id("adjustment"));
        public IWebElement _approveFocClaims => WebDriver.FindElement(By.Id("approveFocClaims"));
        public IWebElement _claimsPaymentsStatus => WebDriver.FindElement(By.Id("claimsPaymentsStatus"));
        public IWebElement _oldImportData => WebDriver.FindElement(By.Id("importData"));
        public IWebElement _newImportData => WebDriver.FindElement(By.Id("//*[@id=\"financeDropdown\"]/li[7]"));

        public void ClickAccruals() => _acrruals.Click();
        public void ClickPayments() => _payments.Click();
        public void ClickAdjustment() => _adjustment.Click();
        public void ClickApproveFocClaims() => _approveFocClaims.Click();
        public void ClickClaimsPaymentsStatus() => _claimsPaymentsStatus.Click();
        public void ClickOldImportData() => _oldImportData.Click();
        public void ClickNewImportData() => _newImportData.Click();
    }
}
