using Dynamitey.DynamicObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace SpecFlowTest.Steps
{
    [Binding]
    public class EBD_192_Add_DocumentsSteps
    {
        private static readonly IWebDriver driver = WebDriverFactory.CreateWebDriver(WebBrowser.Chrome);
        private readonly Basic basic = new Basic();
        private readonly MainMenuPageObject mainMenuPageObject = new MainMenuPageObject(driver);
        private readonly PriceManagmentDropDownPageObject priceManagmentDropDownPageObject = new PriceManagmentDropDownPageObject(driver);
        private readonly AgreementsScreenPageObject agreementsScreenPageObject = new AgreementsScreenPageObject(driver);
        private readonly AddRebatePopup addRebatePopup = new AddRebatePopup(driver);
        private readonly AgreementEditorPage agreementEditorPage = new AgreementEditorPage(driver);
        private readonly PackagesScreenPageObject packagesScreenPageObject = new PackagesScreenPageObject(driver);
        private readonly PackageEditorScreenPageObject packageEditorScreenPageObject = new PackageEditorScreenPageObject(driver);
        string expectedResult;


        [Given(@"Chrome is opened")]
        public void GivenChromeIsOpened()
        {
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://app.test.e-bate.net/login");
        }
        
        [Given(@"Navigate to Packages")]
        public void GivenNavigateToPackages()
        {
            basic.LoginFlow(driver);
            mainMenuPageObject.ClickPricingManagementHeader();
            priceManagmentDropDownPageObject.ClickPackages();
            packagesScreenPageObject.CheckPackagesLoaded();
        }
        
        [Given(@"Navigate to agreements")]
        public void GivenNavigateToAgreements()
        {
            basic.LoginFlow(driver);
            mainMenuPageObject.ClickPricingManagementHeader();
            priceManagmentDropDownPageObject.ClickAgreements();
        }
        
        [Given(@"Navigate to rebate")]
        public void GivenNavigateToRebate()
        {
            basic.LoginFlow(driver);
            mainMenuPageObject.ClickPricingManagementHeader();
            priceManagmentDropDownPageObject.ClickAgreements();
            agreementsScreenPageObject.WaitUntillLoaded();
            agreementsScreenPageObject.FindSeleniumAgreementWithRebates();
            agreementsScreenPageObject.SelectFirstRow();
            agreementsScreenPageObject.ClickActionViewButton();
        }
        
        [Then(@"Choose a Package")]
        public void ThenChooseAPackage()
        {
            packagesScreenPageObject.ClickSearchInput();
            Actions action = new Actions(driver);
            action.SendKeys("1592576148").Perform();
            Thread.Sleep(2000);
            
        }
        
        [Then(@"Add a document to chosen package")]
        public void ThenAddADocumentToChosenPackage()
        {
            packageEditorScreenPageObject.ClickTabsDocuments();
            packageEditorScreenPageObject.ClickTabsDocumentsUploadtNewDocumentBtn();
            packageEditorScreenPageObject.ChooseDocumentFile();
            expectedResult = packageEditorScreenPageObject.AddDocumentPopupSetDescription("Add document to package");
            packageEditorScreenPageObject.AddDocumentPopupClickUploadButton();
        }
        
        [Then(@"Choose a agreement")]
        public void ThenChooseAAgreement()
        {
            agreementsScreenPageObject.FindSeleniumAgreement();
            agreementsScreenPageObject.SelectFirstRow();
            packagesScreenPageObject.ClickActionViewButton();
            agreementEditorPage.ClickTabsDocuments();

        }
        
        [Then(@"Add a document to chosen agreement")]
        public void ThenAddADocumentToChosenAgreement()
        {
            agreementEditorPage.ClickTabsDocumentsUploadtNewDocumentBtn();
            agreementEditorPage.ChooseDocumentFile();
            agreementEditorPage.AddDocumentPopupSetDescription("add test document to chosen agreement");
            agreementEditorPage.ClickTabsDocumentsUploadtNewDocumentBtn();
        }
        
        [Then(@"Choose a rebate")]
        public void ThenChooseARebate()
        {

            //TO DO
        }
        
        [Then(@"Add a document to chosen rebate")]
        public void ThenAddADocumentToChosenRebate()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"Check if it is added to package")]
        public void ThenCheckIfItIsAddedToPackage()
        {
            Assert.AreEqual(packageEditorScreenPageObject.IfDocumentAdded(), expectedResult);
            driver.Close();
        }

        [Then(@"Check if it is added to agreement")]
        public void ThenCheckIfItIsAddedToAgreement()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"Check if it is added to rebate")]
        public void ThenCheckIfItIsAddedToRebate()
        {
            ScenarioContext.Current.Pending();
        }

    }
}
