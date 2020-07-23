using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using System.Threading;

namespace SpecFlowTest
{
    class LoginTabPageObject
    {
        public IWebDriver WebDriver { get; }

        public LoginTabPageObject(IWebDriver webDriver)
        {
            WebDriver = webDriver;
        }

        public IWebElement _emailInput => WebDriver.FindElement(By.XPath("//*[@id=\"email\"]"));
        public IWebElement _passwordInput => WebDriver.FindElement(By.XPath("//*[@id=\"password\"]"));
        public IWebElement _forgotPasswordInput => WebDriver.FindElement(By.XPath("/html/body/app-e-bate-login/div/div/div[2]/form/div[2]/a"));
        public IWebElement _saveButton => WebDriver.FindElement(By.XPath("//*[@id=\"save\"]"));
        public IWebElement _userMenu => WebDriver.FindElement(By.XPath("//*[@id=\"userMenu\"]"));
        public IWebElement _tenantDropDown => WebDriver.FindElement(By.Id("ddlTenant"));
        public IWebElement _saveBtnTenant => WebDriver.FindElement(By.XPath("//*[@id=\"save\"]"));


        //public void ClickEmailInput() => _emailInput.Click();
        public bool Waiter(int seconds, IWebElement element)
        {
            var wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(seconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
            return true;            
        }
        public LoginTabPageObject Login(string email, string password)
        {
            _emailInput.SendKeys(email);
            _passwordInput.SendKeys(password);
            return new LoginTabPageObject(WebDriver);
        }

        public void ClickSaveBtn() => _saveButton.Click();

        public void ClickTenant() {
            Thread.Sleep(1000);
            _tenantDropDown.Click(); 
        }
        public void ClickSaveBtnTenant() => _saveBtnTenant.Click();

        public void ChooseSecondTenant() => _saveBtnTenant.Click(); // only for Demo

        public bool IsUserDropDownExist() => _userMenu.Displayed;
    }
}
