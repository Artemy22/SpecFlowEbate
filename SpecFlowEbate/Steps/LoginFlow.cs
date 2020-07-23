
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowTest.Steps
{
    [Binding]
    public sealed class LoginFlow
    {
        private IWebDriver driver;
        LoginTabPageObject loginTabPageObject = null;


        // our steps definitions
        [Given(@"Open e-bate")]
        public void GivenINavigateToLoginScreen()
        {
            driver = WebDriverFactory.CreateWebDriver(WebBrowser.Chrome);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://app.test.e-bate.net/login");
            loginTabPageObject = new LoginTabPageObject(driver);
        }        

        [Given(@"Login to e-bate")]
        public void GivenIEnterCredentialsAndClickOnSaveBtn()
        {
            var creds = new Credentials();
            loginTabPageObject.Login(creds.Email, creds.Password);
            loginTabPageObject.ClickSaveBtn();

        }

        [Given(@"I choose FirstTenant and click Save btn")]
        public void GivenIChooseFirstTenantAndClickSaveBtn()
        {
            loginTabPageObject.ClickTenant();
            loginTabPageObject.ClickSaveBtnTenant();
        }

        [Given(@"I choose second tenant")]
        public void GivenIChooseSecondTenant()
        {
            loginTabPageObject.ChooseSecondTenant();
            loginTabPageObject.ClickSaveBtnTenant();
        }


        [Then(@"Log out of e-bate")]
        public void ThenIShouldSeeUserSDrop_DownFromTheUpperRight()
        {
            Assert.IsTrue(loginTabPageObject.IsUserDropDownExist());
            driver.Close();
        }
        
    }
}
