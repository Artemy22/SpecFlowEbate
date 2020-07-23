using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace SpecFlowTest
{
    class AgreementsScreenPageObject
    {
        private readonly IWebDriver _webDriver;

        public readonly By _breadcrumbsHomeBtn = By.XPath("//*[@id=\"linkHome\"]");
        public readonly By _orderById = By.XPath("//*[@id=\"gridAgreement\"]/div/div[2]/kendo-grid/div/div/div/table/thead/tr/th[3]");
        public readonly By _firstRow = By.XPath("//*[@id=\"gridAgreement\"]/div/div[2]/kendo-grid/div/kendo-grid-list/div/div[1]/table/tbody/tr[1]/td[2]/label");
        public readonly By _actionEditButton = By.XPath("//*[@id=\"gridAgreement\"]/div/div[2]/div/div[2]");
        public readonly By _actionViewButton = By.XPath("//*[@id=\"gridAgreement\"]/div/div[2]/div/div[3]");
        public readonly By _actionCopyButton = By.XPath("//*[@id=\"gridAgreement\"]/div/div[2]/div/div[4]");
        public readonly By _actionDeleteButton = By.XPath("//*[@id=\"gridAgreement\"]/div/div[2]/div/div[5]");
        public readonly By _searchInput = By.XPath("//*[@id=\"gridAgreement\"]/div/div[1]/div");
        public readonly By _descriptionFirstRow = By.XPath("//*[@id=\"gridAgreement\"]/div/div[2]/kendo-grid/div/kendo-grid-list/div/div[1]/table/tbody/tr[19]/td[5]/text()");
        public readonly By GetFirstRowDescription = By.XPath("/html/body/app-home/div/div/div[2]/app-agreement/app-agreement/section[2]/div/base-grid/div/div[2]/kendo-grid/div/kendo-grid-list/div/div[1]/table/tbody/tr[1]/td[5]");
        public readonly By _deleteYesButton = By.XPath("//*[@id=\"gridAgreement\"]/app-action-dialog/kendo-dialog/div[2]/kendo-dialog-actions/button[1]");
        public readonly By _deleteNoButton = By.XPath("//*[@id=\"gridAgreement\"]/app-action-dialog/kendo-dialog/div[2]/kendo-dialog-actions/button[2]");
        public readonly By _gridLabel = By.XPath("/html/body/app-home/div/div/div[2]/app-agreement/app-agreement-detail/section[2]/div/div/div/div[1]/h3");
        public readonly By FirstRow = By.XPath("/html/body/app-home/div/div/div[2]/app-agreement/app-agreement/section[2]/div/base-grid/div/div[2]/kendo-grid/div/kendo-grid-list/div/div[1]/table/tbody/tr[1]");
        

        public AgreementsScreenPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public AddAgreementPopupPageObject ClickBreadcrumbsHomeBtn()
        {
            _webDriver.FindElement(_breadcrumbsHomeBtn).Click();
            return new AddAgreementPopupPageObject(_webDriver);
        }
        public AddAgreementPopupPageObject ClickOrderById()
        {
            Thread.Sleep(1000);
            var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(15));
            wait.Until(d => d.FindElements(By.XPath("//*[@id=\"gridAgreement\"]/div/div[2]/kendo-grid/div/kendo-grid-list/div/div[1]/table/tbody/tr[1]")).FirstOrDefault());
            _webDriver.FindElement(_orderById).Click();
            return new AddAgreementPopupPageObject(_webDriver);
        }
        public string SelectFirstRow()
        {
            /*
             * wait until implementation
             */            
            var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.FindElements(By.XPath("/html/body/app-home/div/div/div[2]/app-agreement/app-agreement/section[2]/div/base-grid/div/div[2]/kendo-grid/div/kendo-grid-list/div/div[1]/table/tbody/tr[1]/td[5]")).FirstOrDefault());
            _webDriver.FindElement(_firstRow).Click();
            string description = _webDriver.FindElement(By.XPath("/html/body/app-home/div/div/div[2]/app-agreement/app-agreement/section[2]/div/base-grid/div/div[2]/kendo-grid/div/kendo-grid-list/div/div[1]/table/tbody/tr[1]/td[5]")).Text;
            return description;
        }
        public AddAgreementPopupPageObject ClickActionEditButton()
        {
            var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.FindElements(By.XPath("//*[@id=\"gridAgreement\"]/div/div[2]/kendo-grid/div/kendo-grid-list/div/div[1]/table/tbody/tr[1]")).FirstOrDefault());
            _webDriver.FindElement(_actionEditButton).Click();
            return new AddAgreementPopupPageObject(_webDriver);
        }
        public AddAgreementPopupPageObject ClickActionViewButton()
        {
            _webDriver.FindElement(_actionViewButton).Click();
            return new AddAgreementPopupPageObject(_webDriver);
        }
        public AddAgreementPopupPageObject ClickActionCopyButton()
        {
            _webDriver.FindElement(_actionCopyButton).Click();
            return new AddAgreementPopupPageObject(_webDriver);
        }
        public AddAgreementPopupPageObject ClickActionDeleteButton()
        {
            _webDriver.FindElement(_actionDeleteButton).Click();
            return new AddAgreementPopupPageObject(_webDriver);
        }
        public AddAgreementPopupPageObject ClickSearchInput()
        {
            _webDriver.FindElement(_searchInput).Click();
            return new AddAgreementPopupPageObject(_webDriver);
        }
        public bool CheckIfAgreementScreenOpened()
        {
            WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            wait.Until(c => c.FindElement(_gridLabel));
            if (_webDriver.FindElement(_gridLabel).Displayed == true)
            {
                return true;
            } else return false;

        }

        public string GetAgreementDescriptionFirstRow()
        {
            Thread.Sleep(1000);
            return _webDriver.FindElement(GetFirstRowDescription).Text;
        }

        public AddAgreementPopupPageObject DeleteFlow()
        {            
            _webDriver.FindElement(_actionDeleteButton).Click();
            Thread.Sleep(1000);
            _webDriver.FindElement(_deleteYesButton).Click();
            return new AddAgreementPopupPageObject(_webDriver);
        }

        public AddAgreementPopupPageObject FindSeleniumAgreement()
        {            
            _webDriver.FindElement(_searchInput).Click();
            Actions actions = new Actions(_webDriver);
            actions.SendKeys("SeleniumWithoutRebate").Perform();
            Thread.Sleep(2000);
            return new AddAgreementPopupPageObject(_webDriver);
        }
        public AddAgreementPopupPageObject FindSeleniumAgreementWithRebates()
        {
            _webDriver.FindElement(_searchInput).Click();
            Actions actions = new Actions(_webDriver);
            actions.SendKeys("1593002954").Perform();
            Thread.Sleep(2000);
            return new AddAgreementPopupPageObject(_webDriver);
        }

        public AddAgreementPopupPageObject WaitUntillLoaded()
        {
            var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.FindElements(By.XPath("/html/body/app-home/div/div/div[2]/app-agreement/app-agreement/section[2]/div/base-grid/div/div[2]/kendo-grid/div/kendo-grid-list/div/div[1]/table/tbody/tr[1]/td[5]"))).FirstOrDefault();
            return new AddAgreementPopupPageObject(_webDriver);
        }
    }
}




