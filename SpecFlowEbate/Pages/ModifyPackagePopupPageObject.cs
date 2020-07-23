using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SpecFlowTest
{
    class ModifyPackagePopupPageObject
    {
        private IWebDriver _webDriver;

        public readonly By _periodDropDown = By.XPath("//*[@id=\"period\"]");
        public readonly By _startDate = By.XPath("//*[@id=\"periodStart\"]");
        public readonly By _endDate = By.XPath("//*[@id=\"periodEnd\"]");
        public readonly By _descriptionInput = By.XPath("//*[@id=\"description\"]");
        public readonly By _budgetInput = By.XPath("/html/body/app-home/div/div/div[2]/app-package/app-package/app-package-dialog/kendo-dialog/div[2]/div/form/div/div/div[4]/div[1]/div/kendo-numerictextbox");
        public readonly By _targetInput = By.XPath("/html/body/app-home/div/div/div[2]/app-package/app-package/app-package-dialog/kendo-dialog/div[2]/div/form/div/div/div[4]/div[2]/div/kendo-numerictextbox");
        public readonly By _commentsInput = By.XPath("//*[@id=\"comments\"]");
        public readonly By _saveBtn = By.XPath("/html/body/app-home/div/div/div[2]/app-package/app-package/app-package-dialog/kendo-dialog/div[2]/kendo-dialog-actions/button[1]");
        public readonly By _cancelBtn = By.XPath("/html/body/app-home/div/div/div[2]/app-package/app-package/app-package-dialog/kendo-dialog/div[2]/kendo-dialog-actions/button[2]");

        public ModifyPackagePopupPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public string GetDescription()
        {            
            string getDerscr = _webDriver.FindElement(_descriptionInput).GetAttribute("value");
            return getDerscr;
        }

        public ModifyPackagePopupPageObject SetNewStartDate(string newStartDate)
        {
            Actions actions = new Actions(_webDriver);
            _webDriver.FindElement(_startDate).Click();
            actions.SendKeys(Keys.Home).Perform();
            actions.SendKeys(newStartDate).Perform();
            return new ModifyPackagePopupPageObject(_webDriver);
        }
        public ModifyPackagePopupPageObject SetNewEndDate(string newEndDate)
        {
            Actions actions = new Actions(_webDriver);
            _webDriver.FindElement(_endDate).Click();
            actions.SendKeys(Keys.Home).Perform();
            actions.SendKeys(newEndDate).Perform();
            return new ModifyPackagePopupPageObject(_webDriver);
        }
        public ModifyPackagePopupPageObject SetDescription(string description)
        {
            Actions actions = new Actions(_webDriver);
            _webDriver.FindElement(_descriptionInput).Click();
            actions.SendKeys(description).Perform();
            return new ModifyPackagePopupPageObject(_webDriver);
        }
        public ModifyPackagePopupPageObject SetBudget(string budget)
        {
            Actions actions = new Actions(_webDriver);
            _webDriver.FindElement(_budgetInput).Click();
            actions.SendKeys(budget + Keys.Enter).Perform();
            return new ModifyPackagePopupPageObject(_webDriver);
        }
        public ModifyPackagePopupPageObject SetTarget(string target)
        {
            Actions actions = new Actions(_webDriver); 
            _webDriver.FindElement(_targetInput).Click();
            actions.SendKeys(target + Keys.Enter).Perform();
            return new ModifyPackagePopupPageObject(_webDriver);
        }
        public ModifyPackagePopupPageObject ClickSaveButton()
        {
            _webDriver.FindElement(_saveBtn).Click();
            return new ModifyPackagePopupPageObject(_webDriver);
        }
        public ModifyPackagePopupPageObject ClickCancelButton()
        {
            _webDriver.FindElement(_cancelBtn).Click();
            return new ModifyPackagePopupPageObject(_webDriver);
        }
        public string ChangeDescription()
        {
            _webDriver.FindElement(_descriptionInput).Click();
            Actions actions = new Actions(_webDriver);
            Thread.Sleep(300);
            actions.SendKeys(Keys.End + " Changed").Perform();
            string getDerscrChanged = _webDriver.FindElement(_descriptionInput).GetAttribute("value");
            return getDerscrChanged;
        }        
    }
}