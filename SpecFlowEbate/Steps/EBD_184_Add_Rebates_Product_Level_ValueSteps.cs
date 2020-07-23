using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace SpecFlowTest.Steps
{
    [Binding]
    public class EBD_184_Add_Rebates_Product_Level_ValueSteps
    {

        private static readonly IWebDriver driver = WebDriverFactory.CreateWebDriver(WebBrowser.Chrome);
        private readonly Basic basic = new Basic();
        private readonly MainMenuPageObject mainMenuPageObject = new MainMenuPageObject(driver);
        private readonly PriceManagmentDropDownPageObject priceManagmentDropDownPageObject = new PriceManagmentDropDownPageObject(driver);
        private readonly AgreementsScreenPageObject agreementsScreenPageObject = new AgreementsScreenPageObject(driver);
        private readonly AddRebatePopup addRebatePopup = new AddRebatePopup(driver);
        private readonly AgreementEditorPage agreementEditorPage = new AgreementEditorPage(driver);
        private readonly RebateEditorPage rebateEditorPage = new RebateEditorPage(driver);
        private string expectedResult;

        [Given(@"I open Chrome br")]
        public void GivenIOpenChromeBr()
        {
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://app.test.e-bate.net/login");
        }
        
        [Then(@"I Navigate to test agreement")]
        public void ThenINavigateToTestAgreement()
        {
            basic.LoginFlow(driver);
            mainMenuPageObject.ClickPricingManagementHeader();
            priceManagmentDropDownPageObject.ClickAgreements();
            agreementsScreenPageObject.WaitUntillLoaded();
            agreementsScreenPageObject.FindSeleniumAgreementWithRebates();
            agreementsScreenPageObject.SelectFirstRow();
            agreementsScreenPageObject.ClickActionViewButton();
        }

        [Then(@"I Click on ADD  button to add new rebate")]
        public void ThenIClickOnADDButtonToAddNewRebate()
        {
            agreementEditorPage.ClickTabsRebate();
            Thread.Sleep(2000);
            agreementEditorPage.ClickTabsRebateAddNewBtn();
            Thread.Sleep(2500);
        }
        
        [Then(@"I choose Calculation Type -> Product Level Value")]
        public void ThenIChooseCalculationType_ProductLevelValue()
        {
            addRebatePopup.ChooseCalculationTypeProductLevelValue();
        }

        [Then(@"I choose Calculate Against ->  Invoice price")]
        public void ThenIChooseCalculateAgainst_InvoicePrice()
        {
            addRebatePopup.ChooseCalculateAgainstInvoicePrice();
        }

        [Then(@"I fill out some  description")]
        public void ThenIFillOutSomeDescription()
        {
            Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            expectedResult = "Product Level Value + Invoice price. Selenium. Timestamp: " + unixTimestamp;
            addRebatePopup.SetDescription(expectedResult);
        }
        
        [Then(@"I Choose Category ->  QA_Category")]
        public void ThenIChooseCategory_QA_Category()
        {
            addRebatePopup.ChooseCategory();
        }

        [Then(@"Set Budget  and Target")]
        public void ThenSetBudgetAndTarget()
        {
            addRebatePopup.SetTarget();
            addRebatePopup.SetBudget();
        }
        
        [Then(@"I choose Payment  Frequency -> Ongoing")]
        public void ThenIChoosePaymentFrequency_Ongoing()
        {
            addRebatePopup.ChoosePaymentFrequencyOngoing();
        }

        [Then(@"I choose Currency  -> Pound Sterling")]
        public void ThenIChooseCurrency_PoundSterling()
        {
            addRebatePopup.ChooseCurrencyPoundSterling();
        }

        [Then(@"I click  on SAVE button")]
        public void ThenIClickOnSAVEButton()
        {
            addRebatePopup.ClickSaveButton();
        }

        [Then(@"I choose the rebate and open it")]
        public void ThenIChooseTheRebateAndOpenIt()
        {

            agreementEditorPage.ChooseAndGoIntoAddedRebate();
        }
        
        [Then(@"Click on Rates tab")]
        public void ThenClickOnRatesTab()
        {
            rebateEditorPage.ClickTabsRates();
        }
        
        [Then(@"Choose product from appropiate dropdown")]
        public void ThenChooseProductFromAppropiateDropdown()
        {
            rebateEditorPage.ChooseOneProductFromDropDown();
        }
        
        [Then(@"Set Effective From date")]
        public void ThenSetEffectiveFromDate()
        {
            rebateEditorPage.SetEffectiveFrom();
        }
        
        [Then(@"Set Min Qty")]
        public void ThenSetMinQty()
        {
            rebateEditorPage.SetMinQtyForChosenProduct();
        }
        
        [Then(@"Set Value")]
        public void ThenSetValue()
        {
             expectedResult = rebateEditorPage.SetValueForChosenProduct();
        }
        
        [Then(@"I click on ADD configured rate button")]
        public void ThenIClickOnADDConfiguredRateButton()
        {
            rebateEditorPage.ClickTabsRatesProductRebateAddConfiguredRateIcon();
        }
        
        [Then(@"My rate is presented in grid")]
        public void ThenMyRateIsPresentedInGrid()
        {
            Assert.AreEqual(expectedResult, rebateEditorPage.GetValueForChecking());
            driver.Close();
        }
    }
}
