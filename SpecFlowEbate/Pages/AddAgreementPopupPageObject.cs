using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecFlowTest
{
    class AddAgreementPopupPageObject
    {
        private IWebDriver _webDriver;

        public readonly By _startDate = By.XPath("//*[@id=\"periodStart\"]");
        public readonly By _endDate = By.XPath("//*[@id=\"periodEnd\"]");
        public readonly By _budget = By.XPath("/html/body/app-home/div/div/div[2]/app-package/app-package-detail/section[2]/div/div/div/div[2]/div[2]/kendo-tabstrip/div/app-package-agreement/app-package-detail-agreement-dialog/kendo-dialog/div[2]/div/form/div/div/div[6]/div[1]/div/kendo-numerictextbox/span/input");
        public readonly By _target = By.XPath("/html/body/app-home/div/div/div[2]/app-package/app-package-detail/section[2]/div/div/div/div[2]/div[2]/kendo-tabstrip/div/app-package-agreement/app-package-detail-agreement-dialog/kendo-dialog/div[2]/div/form/div/div/div[6]/div[2]/div/kendo-numerictextbox/span/input");
        public readonly By _description = By.XPath("/html/body/app-home/div/div/div[2]/app-package/app-package-detail/section[2]/div/div/div/div[2]/div[2]/kendo-tabstrip/div/app-package-agreement/app-package-detail-agreement-dialog/kendo-dialog/div[2]/div/form/div/div/div[7]/div/div/input");
        public readonly By _saveButton = By.XPath("//*[@id=\"save\"]");
        public readonly By _cancelButton = By.XPath("//*[@id=\"cancel\"]");
        public readonly By _comments = By.XPath("//*[@id=\"comments\"]");
        public readonly By SameDateWarningYesButton = By.XPath("/html/body/app-validation-dialog/kendo-dialog/div[2]/kendo-dialog-actions/button[1]");
        public readonly By SameDateWarningNoButton = By.XPath("/html/body/app-validation-dialog/kendo-dialog/div[2]/kendo-dialog-actions/button[2]");


        public AddAgreementPopupPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public AddAgreementPopupPageObject SetBudget()
        {
            Actions actions = new Actions(_webDriver);
            _webDriver.FindElement(_budget).Click();
            actions.SendKeys("1" + Keys.Enter).Perform();
            return new AddAgreementPopupPageObject(_webDriver);
        }
        public AddAgreementPopupPageObject SetTarget()
        {
            Actions actions = new Actions(_webDriver);
            _webDriver.FindElement(_target).Click();
            actions.SendKeys("1" + Keys.Enter).Perform();
            return new AddAgreementPopupPageObject(_webDriver);
        }
        public AddAgreementPopupPageObject ClickSaveButton()
        {
            _webDriver.FindElement(_saveButton).Click();
            return new AddAgreementPopupPageObject(_webDriver);
        }
        public AddAgreementPopupPageObject ClickCancelButton()
        {
            _webDriver.FindElement(_cancelButton).Click();
            return new AddAgreementPopupPageObject(_webDriver);
        }

        public AddAgreementPopupPageObject SetStartDate()
        {
            Actions actions = new Actions(_webDriver);
            PackageEditorScreenPageObject packageEditorScreenPageObject = new PackageEditorScreenPageObject(_webDriver);
            _webDriver.FindElement(_startDate).Click();
            actions.SendKeys(Keys.Home + packageEditorScreenPageObject.GetStartDateOfParentPackage()).Perform();
            return new AddAgreementPopupPageObject(_webDriver);
        }

        public AddAgreementPopupPageObject SetEndDate()
        {
            Actions actions = new Actions(_webDriver);
            PackageEditorScreenPageObject packageEditorScreenPageObject = new PackageEditorScreenPageObject(_webDriver);
            _webDriver.FindElement(_endDate).Click();
            actions.SendKeys(Keys.Home + packageEditorScreenPageObject.GetEndDateOfParentPackage()).Perform();
            return new AddAgreementPopupPageObject(_webDriver);
        }
        public AddAgreementPopupPageObject SetDescription(string description)
        {
            Actions actions = new Actions(_webDriver);

            _webDriver.FindElement(_description).Click();
            actions.SendKeys(description).Perform();
            return new AddAgreementPopupPageObject(_webDriver);
        }
        public AddAgreementPopupPageObject WarningPopupClickYes()
        {
            _webDriver.FindElement(SameDateWarningYesButton).Click();
            return new AddAgreementPopupPageObject(_webDriver);
        }

        public bool IsWarningAppeared()
        {
            try
            {
                return _webDriver.FindElement(SameDateWarningYesButton).Displayed;
            }
            catch (NoSuchElementException e)
            {
                return false;
            }            
        }
    }
}




