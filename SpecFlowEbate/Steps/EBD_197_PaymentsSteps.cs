using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowTest;
using TechTalk.SpecFlow;

namespace SpecFlowEbate.Steps
{
    [Binding]
    public class EBD_197_PaymentsSteps
    {
        private static readonly IWebDriver driver = WebDriverFactory.CreateWebDriver(WebBrowser.Chrome);
        private readonly Basic basic = new Basic();
        private readonly MainMenuPageObject mainMenuPageObject = new MainMenuPageObject(driver);
        private readonly FinanceDropDown financeDropDown = new FinanceDropDown(driver);
        Payments payments = new Payments(driver);

        [Given(@"Open Chrome  browser")]
        public void GivenOpenChromeBrowser()
        {
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://app.test.e-bate.net/login");
        }
        
        [Then(@"Navigate to e-bate Payments screen")]
        public void ThenNavigateToE_BatePaymentsScreen()
        {
            basic.LoginFlow(driver);
            mainMenuPageObject.ClickFinanceHeader();
            financeDropDown.ClickPayments();
            Thread.Sleep(1500);            
        }
        
        [Then(@"Enter the Paeyment Description")]
        public void ThenEnterThePaeymentDescription()
        {
            payments.ClickRequestPaymentsButton();
            payments.SetDescriptionForRequestPopup("Specflow request:");
            payments.ClickPopupSaveButton();
        }
        
        [Then(@"Request a payment is done")]
        public void ThenRequestAPaymentIsDone()
        {
            Assert.IsTrue(payments.CheckSuccessGreenPopup());
            driver.Close();
        }
    }
}
