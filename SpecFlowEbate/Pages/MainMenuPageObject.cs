using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecFlowTest
{
    class MainMenuPageObject
    {
        public IWebDriver WebDriver { get; }

        public MainMenuPageObject(IWebDriver webDriver)
        {
            WebDriver = webDriver;
        }
        
        public IWebElement MainLogo => WebDriver.FindElement(By.Id("menuLogo"));
        public IWebElement MeinentanceHeader => WebDriver.FindElement(By.XPath("//*[@id=\"maintenance\"]"));
        public IWebElement PricingManagementHeader => WebDriver.FindElement(By.XPath("//*[@id=\"pricingManagement\"]"));
        public IWebElement FinanceHeader => WebDriver.FindElement(By.XPath("//*[@id=\"finance\"]"));
        public IWebElement ReportingHeader => WebDriver.FindElement(By.XPath("//*[@id=\"reporting\"]"));
        public IWebElement Version => WebDriver.FindElement(By.XPath("//*[@id=\"version\"]"));
        public IWebElement Notifications => WebDriver.FindElement(By.XPath("//*[@id=\"notifications\"]"));
        public IWebElement Help => WebDriver.FindElement(By.XPath("//*[@id=\"help\"]"));
        public IWebElement UserMenu => WebDriver.FindElement(By.XPath("//*[@id=\"userMenu\"]"));
        public IWebElement SignOutButton => WebDriver.FindElement(By.XPath("//*[@id=\"userDropdown\"]/li[3]/div[1]"));

        public void ClickMainLogo() => MainLogo.Click();
        public void ClickMeinentanceHeader() => MeinentanceHeader.Click();
        public void ClickPricingManagementHeader() => PricingManagementHeader.Click();
        public void ClickFinanceHeader() => FinanceHeader.Click();
        public void ClickReportingHeader() => ReportingHeader.Click();
        public void ClickVersion() => Version.Click();
        public void ClickNotifications() => Notifications.Click();
        public void ClickHelp() => Help.Click();
        public void ClickUserMenu() => UserMenu.Click();
        public void ClickSignOutButton() => SignOutButton.Click();

    }
}
