using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SpecFlowTest
{
    class PackagesScreenPageObject
    {
        private IWebDriver _webDriver;

        public readonly By _breadcrumbsHomeBtn = By.XPath("/html/body/app-home/div/div/div[2]/app-package/app-package/section[1]/ol/li[1]");
        public readonly By _addPackageBtn = By.XPath("//*[@id=\"addPackage\"]");
        public readonly By _orderById = By.XPath("//*[@id=\"gridPackageOverview\"]/div/div[2]/kendo-grid/div/div/div/table/thead/tr/th[3]/a");
        public readonly By _firstRow = By.XPath("//*[@id=\"gridPackageOverview\"]/div/div[2]/kendo-grid/div/kendo-grid-list/div/div[1]/table/tbody/tr[1]/td[2]/label");
        public readonly By _actionEditButton = By.XPath("//*[@id=\"gridPackageOverview\"]/div/div[2]/div/div[2]");
        public readonly By _actionViewButton = By.XPath("/html/body/app-home/div/div/div[2]/app-agreement/app-agreement/section[2]/div/base-grid/div/div[2]/div/div[3]/button");
        public readonly By _actionCopyButton = By.XPath("//*[@id=\"gridPackageOverview\"]/div/div[2]/div/div[4]");
        public readonly By _actionDeleteButton = By.XPath("//*[@id=\"gridPackageOverview\"]/div/div[2]/div/div[5]");
        public readonly By _searchInput = By.XPath("//*[@id=\"filterText\"]");
        public readonly By _descriptionFirstRow = By.XPath("//*[@id=\"gridPackageOverview\"]/div/div[2]/kendo-grid/div/kendo-grid-list/div/div[1]/table/tbody/tr[1]/td[6]");
        public readonly By _getIdOfFirstRowPackage = By.XPath("//*[@id=\"gridPackageOverview\"]/div/div[2]/kendo-grid/div/kendo-grid-list/div/div[1]/table/tbody/tr[1]/td[3]");
        public readonly By _deleteYesButton = By.XPath("//*[@id=\"gridPackageOverview\"]/app-action-dialog/kendo-dialog/div[2]/kendo-dialog-actions/button[1]");
        public readonly By _deleteNoButton = By.XPath("//*[@id=\"gridPackageOverview\"]/app-action-dialog/kendo-dialog/div[2]/kendo-dialog-actions/button[2]");


        /*
         *  successfull copy popup /html/toast-container/div/div/div[3]/span
         *  validation error popup while copying /html/body/app-validation-dialog/kendo-dialog/div[2]
        */

        public bool IsFirstRowAppeared()
        {
            if (_webDriver.FindElement(_descriptionFirstRow).Displayed == true)
            {
                return true;
            }
            else return false;
        }

        private PackagesScreenPageObject Waiter(int seconds, By element)
        {
            var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(seconds));
            try
            {
                wait.Until(d => d.FindElements(element).FirstOrDefault());
                return new PackagesScreenPageObject(_webDriver);
            }
            catch
            {
                var neededElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
                return new PackagesScreenPageObject(_webDriver);
            }
        }

        public bool IfSuccessfullPopupAppearedAfterCopying()
        {
            var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            try
            {
                wait.Until(d => d.FindElements(By.XPath("/html/toast-container/div/div/div[3]/span")).FirstOrDefault());
                return true;
            }
            catch { return false; }
        }

        public PackagesScreenPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public PackagesScreenPageObject ClickBreadcrumbsHomeBtn()
        {
            _webDriver.FindElement(_breadcrumbsHomeBtn).Click();
            return new PackagesScreenPageObject(_webDriver);
        }
        public PackagesScreenPageObject ClickAddPackageBtn()
        {
            _webDriver.FindElement(_addPackageBtn).Click();
            return new PackagesScreenPageObject(_webDriver);
        }

        public PackagesScreenPageObject ClickOrderById()
        {
            Thread.Sleep(1500);
            var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.FindElements(By.XPath("//*[@id=\"gridPackageOverview\"]/div/div[2]/kendo-grid/div/kendo-grid-list/div/div[1]/table/tbody/tr[1]/td[2]/label")).FirstOrDefault());
            Thread.Sleep(1000);
            _webDriver.FindElement(_orderById).Click();
            return new PackagesScreenPageObject(_webDriver);
        }

        public PackagesScreenPageObject SelectFirstRow()
        {
            /*
             * wait until implementation
             */
            Thread.Sleep(1000);
            var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.FindElements(By.XPath("//*[@id=\"gridPackageOverview\"]/div/div[2]/kendo-grid/div/kendo-grid-list/div/div[1]/table/tbody/tr[1]/td[2]/label")).FirstOrDefault());
            _webDriver.FindElement(_firstRow).Click();
            return new PackagesScreenPageObject(_webDriver);
        }
        public PackagesScreenPageObject ClickActionEditButton()
        {
            var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.FindElements(By.XPath("//*[@id=\"gridPackageOverview\"]/div/div[2]/kendo-grid/div/kendo-grid-list/div/div[1]/table/tbody/tr[1]/td[2]/label")).FirstOrDefault());
            _webDriver.FindElement(_actionEditButton).Click();
            return new PackagesScreenPageObject(_webDriver);
        }
        public PackagesScreenPageObject ClickActionViewButton()
        {
            Thread.Sleep(1000);
            _webDriver.FindElement(_actionViewButton).Click();
            return new PackagesScreenPageObject(_webDriver);
        }
        public PackagesScreenPageObject ClickActionCopyButton()
        {
            _webDriver.FindElement(_actionCopyButton).Click();
            return new PackagesScreenPageObject(_webDriver);
        }
        public PackagesScreenPageObject ClickActionDeleteButton()
        {
            _webDriver.FindElement(_actionDeleteButton).Click();
            return new PackagesScreenPageObject(_webDriver);
        }
        public PackagesScreenPageObject ClickSearchInput()
        {
            _webDriver.FindElement(_searchInput).Click();
            return new PackagesScreenPageObject(_webDriver);
        }
        public PackagesScreenPageObject CheckPackagesLoaded()
        {
            WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            wait.Until(c => c.FindElement(_firstRow));
            _webDriver.FindElement(_searchInput).Click();
            return new PackagesScreenPageObject(_webDriver);
        }

        public string GetPackageIdFirstRow()
        {
            return _webDriver.FindElement(_getIdOfFirstRowPackage).Text;
        }

        public PackageEditorScreenPageObject DeleteFlow()
        {
            _webDriver.FindElement(_actionDeleteButton).Click();
            Thread.Sleep(1000);
            _webDriver.FindElement(_deleteYesButton).Click();
            return new PackageEditorScreenPageObject(_webDriver);
        }
        public PackagesScreenPageObject WaitUntillLoaded()
        {
            var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.FindElements(By.XPath("//*[@id=\"gridPackageOverview\"]/div/div[2]/kendo-grid/div/kendo-grid-list/div/div[1]/table/tbody/tr[1]/td[3]")).FirstOrDefault());
            return new PackagesScreenPageObject(_webDriver);
        }

        public bool CheckIfPackageCopied(string expectedResult)
        {
            ClickOrderById();
            Waiter(10, _firstRow);
            string actualResult = _webDriver.FindElement(_descriptionFirstRow).Text;
            Assert.AreEqual(expectedResult, actualResult);
            return true;
        }
    }
}