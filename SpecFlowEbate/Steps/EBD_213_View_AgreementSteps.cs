using NUnit.Framework;
using NUnit.Framework.Constraints;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowTest.Steps
{
    [Binding]
    public class EBD_213_View_AgreementSteps
    {
        private IWebDriver driver;

        [Given(@"Open Crome browser\.")]
        public void GivenOpenCromeBrowser_()
        {
            driver = WebDriverFactory.CreateWebDriver(WebBrowser.Chrome);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://app.test.e-bate.net/login");
        }
        
        [Given(@"Choose an Agreement to look at")]
        public void GivenChooseAnAgreementToLookAt()
        {
            Basic basic = new Basic();
            basic.LoginFlow(driver);
            MainMenuPageObject mainMenuPageObject = new MainMenuPageObject(driver);
            mainMenuPageObject.ClickPricingManagementHeader();
            PriceManagmentDropDownPageObject priceManagmentDropDownPageObject = new PriceManagmentDropDownPageObject(driver);
            priceManagmentDropDownPageObject.ClickAgreements();
            AgreementsScreenPageObject agreementsScreenPageObject = new AgreementsScreenPageObject(driver);
            agreementsScreenPageObject.SelectFirstRow();
        }
        
        [When(@"Open a chosen agreement")]
        public void WhenOpenAChosenAgreement()
        {
            AgreementsScreenPageObject agreementsScreenPageObject = new AgreementsScreenPageObject(driver);
            agreementsScreenPageObject.ClickActionViewButton();
        }

        [When(@"Agreement editor screen is opened")]
        public void ThenAgreementEditorScreenIsOpened()
        {
            AgreementsScreenPageObject agreementsScreenPageObject = new AgreementsScreenPageObject(driver);
            Assert.IsTrue(agreementsScreenPageObject.CheckIfAgreementScreenOpened());
        }

        [Then(@"Chrome closed")]
        public void ThenChromeClosed()
        {
            driver.Close();
        }

    }
}
