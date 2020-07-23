using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowTest.Steps
{
    [Binding]
    public class EBD_212_Delete_AgreementSteps
    {
        private static readonly IWebDriver driver = WebDriverFactory.CreateWebDriver(WebBrowser.Chrome);
        private readonly Basic basic = new Basic();
        private readonly MainMenuPageObject mainMenuPageObject = new MainMenuPageObject(driver);
        private readonly PriceManagmentDropDownPageObject priceManagmentDropDownPageObject = new PriceManagmentDropDownPageObject(driver);
        private readonly AgreementsScreenPageObject agreementsScreenPageObject = new AgreementsScreenPageObject(driver);
        private readonly ModifyAgreementPopupPageObject modifyAgreementPopupPageObject = new ModifyAgreementPopupPageObject(driver);
        string Expectedresult;


        [Given(@"Chrome is opened\.")]
        public void GivenChromeIsOpened_()
        {
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://app.test.e-bate.net/login");
        }
        
        [Given(@"Navigate to Pricing Management > Agreements\.")]
        public void GivenNavigateToPricingManagementAgreements_()
        {
            basic.LoginFlow(driver);
            mainMenuPageObject.ClickPricingManagementHeader();
            priceManagmentDropDownPageObject.ClickAgreements();
        }
        
        [Given(@"Pick agreement wich you want to delete")]
        public void GivenPickAgreementWitchYouWantToDelete()
        {
            agreementsScreenPageObject.WaitUntillLoaded();
            agreementsScreenPageObject.FindSeleniumAgreement();
            Expectedresult = agreementsScreenPageObject.SelectFirstRow();
        }
        
        [When(@"Click the button delete it")]
        public void GivenClickTheButtonDeleteIt()
        {           
            agreementsScreenPageObject.DeleteFlow();
        }

        [Then(@"Chosen agreement is deleted and driver closed")]
        public void ThenChosenAgreementIsDeletedAndDriverClosed()
        {
            
            string actualResult = agreementsScreenPageObject.GetAgreementDescriptionFirstRow();
            Assert.IsFalse(Expectedresult == actualResult);
            driver.Close();
        }

    }
}
