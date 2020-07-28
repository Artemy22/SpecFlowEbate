using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using System.Threading;
using System.Collections.Generic;
using System.Text;

namespace SpecFlowEbate.Pages
{
    class CalcEngineStatusPage
    {
        public IWebDriver WebDriver { get; }

        public CalcEngineStatusPage(IWebDriver webDriver)
        {
            WebDriver = webDriver;
        }

        public IWebElement _refreshButton => WebDriver.FindElement(By.XPath("/html/body/app-home/div/div/div[2]/app-calculation-main/section[2]/div/div/div/div[2]/div/div/div/div[1]/div/button"));
        public readonly By _expectedResult = By.XPath("/html/body/app-home/div/div/div[2]/app-calculation-main/section[2]/div/div/div/div[2]/div/div/div/div[2]/kendo-grid/div/kendo-grid-list/div/div[1]/table/tbody/tr[1]/td[4]");
        
        public void ClickRefreshButton() => _refreshButton.Click();

        public bool CheckIfStatusFinished()
        {
            do
            {
                ClickRefreshButton();
            } while (WebDriver.FindElement(_expectedResult).Text != "Finished Without Errors");

            if (WebDriver.FindElement(_expectedResult).Text == "Finished Without Errors")
            {
                return true;
            }
            else return false;            
        }
    }
}
