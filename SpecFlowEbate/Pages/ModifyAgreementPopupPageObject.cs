using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SpecFlowTest
{
    class ModifyAgreementPopupPageObject
    {
        private IWebDriver _webDriver;

        public readonly By _startDate = By.XPath("/html/body/app-home/div/div/div[2]/app-agreement/app-agreement/app-agreement-dialog/kendo-dialog/div[2]/div/form/div/div/div[4]/div[1]/div/kendo-datepicker/span/kendo-dateinput/span/input");
        public readonly By _endDate = By.XPath("/html/body/app-home/div/div/div[2]/app-agreement/app-agreement/app-agreement-dialog/kendo-dialog/div[2]/div/form/div/div/div[4]/div[2]/div/kendo-datepicker/span/kendo-dateinput/span/input");
        public readonly By _descriptionInput = By.XPath("/html/body/app-home/div/div/div[2]/app-agreement/app-agreement/app-agreement-dialog/kendo-dialog/div[2]/div/form/div/div/div[6]/div/div/input");
        public readonly By _budgetInput = By.XPath("/html/body/app-home/div/div/div[2]/app-agreement/app-agreement/app-agreement-dialog/kendo-dialog/div[2]/div/form/div/div/div[5]/div[1]/div/kendo-numerictextbox/span/input");
        public readonly By _targetInput = By.XPath("/html/body/app-home/div/div/div[2]/app-agreement/app-agreement/app-agreement-dialog/kendo-dialog/div[2]/div/form/div/div/div[5]/div[2]/div/kendo-numerictextbox/span/input");
        public readonly By _commentsInput = By.XPath("/html/body/app-home/div/div/div[2]/app-agreement/app-agreement/app-agreement-dialog/kendo-dialog/div[2]/div/form/div/div/div[7]/div/div/input");
        public readonly By _saveBtn = By.Id("save");
        public readonly By _cancelBtn = By.Id("cancel");
        public readonly By ModifyPopupTitle = By.XPath("//*[@id=\"kendo - dialog - title - 340709\"]/div[1]");

        

        public ModifyAgreementPopupPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public string GetDescription()
        {            
            string getDerscr = _webDriver.FindElement(_descriptionInput).GetAttribute("value");
            return getDerscr;
        }

        public ModifyAgreementPopupPageObject SetNewStartDate(string newStartDate)
        {
            Actions actions = new Actions(_webDriver);
            _webDriver.FindElement(_startDate).Click();
            actions.SendKeys(Keys.Home).Perform();
            actions.SendKeys(newStartDate).Perform();
            return new ModifyAgreementPopupPageObject(_webDriver);
        }

        public ModifyAgreementPopupPageObject SetNewEndDate(string newEndDate)
        {
            Actions actions = new Actions(_webDriver);
            _webDriver.FindElement(_endDate).Click();
            actions.SendKeys(Keys.Home).Perform();
            actions.SendKeys(newEndDate).Perform();
            return new ModifyAgreementPopupPageObject(_webDriver);
        }

        public ModifyAgreementPopupPageObject SetDescription(string description)
        {
            Actions actions = new Actions(_webDriver);
            _webDriver.FindElement(_descriptionInput).Click();
            actions.SendKeys(description).Perform();
            return new ModifyAgreementPopupPageObject(_webDriver);
        }

        public ModifyAgreementPopupPageObject SetBudget(string budget)
        {
            Actions actions = new Actions(_webDriver);
            _webDriver.FindElement(_budgetInput).Click();
            actions.SendKeys(budget + Keys.Enter).Perform();
            return new ModifyAgreementPopupPageObject(_webDriver);
        }

        public ModifyAgreementPopupPageObject SetTarget(string target)
        {
            Actions actions = new Actions(_webDriver); 
            _webDriver.FindElement(_targetInput).Click();
            actions.SendKeys(target + Keys.Enter).Perform();
            return new ModifyAgreementPopupPageObject(_webDriver);
        }

        public ModifyAgreementPopupPageObject ClickSaveButton()
        {
            _webDriver.FindElement(_saveBtn).Click();
            return new ModifyAgreementPopupPageObject(_webDriver);
        }

        public ModifyAgreementPopupPageObject ClickCancelButton()
        {
            _webDriver.FindElement(_cancelBtn).Click();
            return new ModifyAgreementPopupPageObject(_webDriver);
        }

        public string ChangeDescription()
        {
            _webDriver.FindElement(_descriptionInput).Click();
            Actions actions = new Actions(_webDriver);
            Thread.Sleep(1000);
            actions.SendKeys(Keys.End + " Changed").Perform();
            string getDerscrChanged = _webDriver.FindElement(_descriptionInput).GetAttribute("value");
            return getDerscrChanged;
        }    
        
        public bool IsModifyPopupOpened()
        {
            var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(3));
            wait.Until(d => d.FindElements(By.XPath("/html/body/app-home/div/div/div[2]/app-agreement/app-agreement/app-agreement-dialog/kendo-dialog/div[2]"))).FirstOrDefault();
            if (_webDriver.FindElement(By.XPath("/html/body/app-home/div/div/div[2]/app-agreement/app-agreement/app-agreement-dialog/kendo-dialog/div[2]")).Displayed)
            {
                return true;
            }
            else return false;
        }
    }
}