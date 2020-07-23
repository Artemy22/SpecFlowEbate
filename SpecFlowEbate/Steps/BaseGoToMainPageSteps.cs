using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowTest
{
    [Binding]
    public class BaseGoToMainPageSteps
    {
        private IWebDriver driver;

        [Given(@"Open Chrome Browser")]
        public void GivenOpenChromeBrowser()
        {
            driver = WebDriverFactory.CreateWebDriver(WebBrowser.Chrome);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://app.test.e-bate.net/login");
            Basic basic = new Basic();
            basic.LoginFlow(driver);
        }
    }
}
