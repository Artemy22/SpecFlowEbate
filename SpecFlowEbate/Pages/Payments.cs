using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using System.Threading;

namespace SpecFlowTest
{
    class Payments
    {
        public IWebDriver WebDriver { get; }
        public Payments(IWebDriver webDriver)
        {
            WebDriver = webDriver;
        }
        public IWebElement _filtersProductTypeDropDown => WebDriver.FindElement(By.Id("structure0"));
        public IWebElement _filtersSalesRepDropDown => WebDriver.FindElement(By.Id("structure1"));
        public IWebElement _filtersAccountCountryDropDown => WebDriver.FindElement(By.Id("structure2"));
        public IWebElement _filtersPaymentFrequencyDropDown => WebDriver.FindElement(By.Id("paymentFrequency"));
        public IWebElement _filtersRebateTypeDropDown => WebDriver.FindElement(By.Id("rebateType"));
        public IWebElement _filtersPayToCompanyNameDropDown => WebDriver.FindElement(By.Id("payTo"));
        public IWebElement _filtersRebateCategoryyNameDropDown => WebDriver.FindElement(By.Id("rebateCategory"));
        public IWebElement _filtersStartDate => WebDriver.FindElement(By.Id("startDate"));
        public IWebElement _filtersEndDate => WebDriver.FindElement(By.Id("endDate"));
        public IWebElement _filterApply => WebDriver.FindElement(By.Id("paymentFiltersApply"));
        public IWebElement _requestPaymentButton => WebDriver.FindElement(By.Id("button-process"));
        public IWebElement _loaderSpin => WebDriver.FindElement(By.XPath("/html/body/loading-spinner/div/img"));
        public IWebElement _firstRowCheckBox => WebDriver.FindElement(By.XPath("/html/body/app-home/div/div/div[2]/app-payment-overview/payment-grid/div[1]/div/kendo-grid/div/kendo-grid-list/div/div[1]/table/tbody/tr/td[2]/label"));
        public IWebElement _requestPopupDescription => WebDriver.FindElement(By.Id("requestDescription"));
        public IWebElement _requestPopupSaveButton => WebDriver.FindElement(By.Id("save"));
        public IWebElement _forWaiter => WebDriver.FindElement(By.XPath("/html/body/app-home/div/div/div[2]/app-payment-overview/payment-grid/div[1]/div/div/div"));

        public readonly By _firstRowDueValue = By.XPath("/html/body/app-home/div/div/div[2]/app-payment-overview/payment-grid/div[1]/div/kendo-grid/div/kendo-grid-list/div/div[1]/table/tbody/tr[1]/td[7]/div");

        public readonly By _firstRowExpandIcon = By.XPath("/html/body/app-home/div/div/div[2]/app-payment-overview/payment-grid/div[1]/div/kendo-grid/div/kendo-grid-list/div/div[1]/table/tbody/tr/td[1]");
        
        public readonly By _greenSuccessPopup = By.XPath("/html/toast-container/div/div/div[3]/span");
        /*
         * /html/toast-container/div/div/div[3]/span
         * 
         */


        public void Waiter()
        {
            try
            {
                if (_loaderSpin.Displayed)
                {
                    var wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(120));
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(_firstRowExpandIcon));
                }
            }
            catch {}
        }

        public string SetDescriptionForRequestPopup(string description)
        {
            Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            string result = description + $" {unixTimestamp}";
            _requestPopupDescription.SendKeys(result);
            return result;
        }

        public void ClickApplyFilter() => _filterApply.Click();
        public void ClickExpandFirstRowIcon() => WebDriver.FindElement(_firstRowExpandIcon).Click();

        public Payments ClickRequestPaymentsButton() 
        {
                Thread.Sleep(1500);
                var wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(120));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_firstRowDueValue));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(_firstRowExpandIcon));
                Thread.Sleep(2000);
            if (WebDriver.FindElement(_firstRowDueValue).Displayed)
            {
                _requestPaymentButton.Click();
            }
            return new Payments(WebDriver);   
        }
        public bool CheckSuccessGreenPopup()
        {
            try
            {
                var wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(120));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_greenSuccessPopup));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(_greenSuccessPopup));
                return true;
            }
            catch { return false; }
        }
        public void ClickPopupSaveButton() => _requestPopupSaveButton.Click();

    }
}
