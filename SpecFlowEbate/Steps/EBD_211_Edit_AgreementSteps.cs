using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace SpecFlowTest.Steps
{
    [Binding]
    public class EBD_211_Edit_AgreementSteps
    {
        private static readonly IWebDriver driver = WebDriverFactory.CreateWebDriver(WebBrowser.Chrome);
        private readonly Basic basic = new Basic();
        private readonly MainMenuPageObject mainMenuPageObject = new MainMenuPageObject(driver);
        private readonly PriceManagmentDropDownPageObject priceManagmentDropDownPageObject = new PriceManagmentDropDownPageObject(driver);
        private readonly AgreementsScreenPageObject agreementsScreenPageObject = new AgreementsScreenPageObject(driver);
        private readonly ModifyAgreementPopupPageObject modifyAgreementPopupPageObject = new ModifyAgreementPopupPageObject(driver);

        string descrExpected;


        [Given(@"Chrome browser opened")]
        public void GivenChromeBrowserOpened()
        {
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://app.test.e-bate.net/login");
        }

        [Then(@"Navigate to Agreements page")]
        public void ThenNavigateToAgreementsPage()
        {
            basic.LoginFlow(driver);
            mainMenuPageObject.ClickPricingManagementHeader();
            priceManagmentDropDownPageObject.ClickAgreements();
            agreementsScreenPageObject.WaitUntillLoaded();
        
        }

        [Then(@"Choose your Agreement")]
        public void ThenChooseYourAgreement()
        {
            agreementsScreenPageObject.FindSeleniumAgreement();
            agreementsScreenPageObject.SelectFirstRow();
        }

        [Then(@"Click Edit button")]
        public void ThenClickEditButton()
        {
            agreementsScreenPageObject.ClickActionEditButton();
        } 

        [Then(@"Edit popup is opened")]
        public void ThenEditPopupIsOpened()
        {
            Assert.IsTrue(modifyAgreementPopupPageObject.IsModifyPopupOpened());
        }

        [Then(@"Change e\.g\. a description value")]
        public void ThenChangeE_G_ADescriptionValue()
        {
           descrExpected = modifyAgreementPopupPageObject.ChangeDescription();
        }

        [Then(@"Click Save button")]
        public void ThenClickSaveButton()
        {
            modifyAgreementPopupPageObject.ClickSaveButton();
        }

        [Then(@"An agreement with changed values is saved and correctly shown\.")]
        public void ThenAnAgreementWithChangedValuesIsSavedAndCorrectlyShown_()
        {
            Thread.Sleep(1000);
            var actualResult = driver.FindElement(By.XPath("/html/body/app-home/div/div/div[2]/app-agreement/app-agreement/section[2]/div/base-grid/div/div[2]/kendo-grid/div/kendo-grid-list/div/div[1]/table/tbody/tr[1]/td[5]")).Text;
            Assert.AreEqual(descrExpected, actualResult);
            driver.Close();
        }
    }
}
