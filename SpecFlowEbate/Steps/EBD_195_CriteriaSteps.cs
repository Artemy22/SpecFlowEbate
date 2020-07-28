using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SpecFlowEbate.Pages;
using SpecFlowEbate.src.sqltest;
using SpecFlowTest;
using TechTalk.SpecFlow;

namespace SpecFlowEbate.Steps
{
    [Binding]
    public class EBD_195_CriteriaSteps
    {
        private static readonly IWebDriver driver = WebDriverFactory.CreateWebDriver(WebBrowser.Chrome);
        private readonly Basic basic = new Basic();
        private readonly PriceManagmentDropDownPageObject priceManagmentDropDownPageObject = new PriceManagmentDropDownPageObject(driver);
        private readonly PackagesScreenPageObject packagesScreenPageObject = new PackagesScreenPageObject(driver);
        private readonly PackageEditorScreenPageObject packageEditorScreenPageObject = new PackageEditorScreenPageObject(driver);
        private readonly MainMenuPageObject mainMenuPageObject = new MainMenuPageObject(driver);
        private readonly CalcEngineStatusPage calcEngineStatusPage = new CalcEngineStatusPage(driver);
        private readonly SqlInit sqlInit = new SqlInit();
        private string calculatedValueBeforeAddingCriteria;
        private string calculatedValueAfterAddingCriteria;



        [Given(@"Open up the Package Screen")]
        public void GivenOpenUpThePackageScreen()
        {
            calculatedValueBeforeAddingCriteria = sqlInit.SqlConnector("SELECT * FROM [eBate-Test].[dbo].[RebateTransaction] where Id = 2927");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://app.test.e-bate.net/login");
            basic.LoginFlow(driver);
            mainMenuPageObject.ClickPricingManagementHeader();
            priceManagmentDropDownPageObject.ClickPackages();
            packagesScreenPageObject.CheckPackagesLoaded();
            packagesScreenPageObject.ClickSearchInput();
            Actions action = new Actions(driver);
            action.SendKeys("1592576148").Perform();
            Thread.Sleep(2000);
            packagesScreenPageObject.SelectFirstRow();
            packagesScreenPageObject.ClickActionViewButton();
        }
        
        [Then(@"Go the Tab criteria")]
        public void ThenGoTheTabCriteria()
        {
            packageEditorScreenPageObject.ClickTabsCriteria();
        }

        [Then(@"Click on the Add criteria button")]
        public void ThenClickOnTheAddCriteriaButton()
        {
            packageEditorScreenPageObject.ClickTabsCriteriaProduct();
            packageEditorScreenPageObject.ClickTabsCriteriaAddNewBtnPlusSign();
            
        }
        
        [Then(@"Add Criteria")]
        public void ThenAddCriteria()
        {
            packageEditorScreenPageObject.CriteriaPopupChooseProductBrand();
            packageEditorScreenPageObject.CriteriaPopupSetProductBrandDove();
 
        }
        
        [Then(@"Go to the Agreement in the Package check if the same criteria was added on the Agreement")]
        public void ThenGoToTheAgreementInThePackageCheckIfTheSameCriteriaWasAddedOnTheAgreement()
        {
            packageEditorScreenPageObject.ClickTabsAgreements();
            packageEditorScreenPageObject.ClickTabsAgreementsChooseFirstRow();
            packageEditorScreenPageObject.ClickTabsAgreementsActionView();

        }
        
        [Then(@"Click on the rebate within same Package/Agreement check if the same criteria is displayed on the Rebate Criteria Tab")]
        public void ThenClickOnTheRebateWithinSamePackageAgreementCheckIfTheSameCriteriaIsDisplayedOnTheRebateCriteriaTab()
        {
            mainMenuPageObject.ClickPricingManagementHeader();
            priceManagmentDropDownPageObject.ClickCalcEngineStatus();
            calcEngineStatusPage.CheckIfStatusFinished();
            calculatedValueAfterAddingCriteria = sqlInit.SqlConnector("SELECT * FROM [eBate-Test].[dbo].[RebateTransaction] where Id = 2927");
            Assert.AreNotEqual(calculatedValueBeforeAddingCriteria, calculatedValueAfterAddingCriteria);
        }

        [Then(@"On the Rebate Screen deselect one criteria \( for exemple if you have selected four Product Codes deselect one")]
        public void ThenOnTheRebateScreenDeselectOneCriteriaForExempleIfYouHaveSelectedFourProductCodesDeselectOne()
        {
            ScenarioContext.Current.Pending();
        }


        [Then(@"Go to the Rebate tab and check if the Accruals were recalculated according to the deselected criteria")]
        public void ThenGoToTheRebateTabAndCheckIfTheAccrualsWereRecalculatedAccordingToTheDeselectedCriteria()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
