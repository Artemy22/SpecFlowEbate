using OpenQA.Selenium;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace SpecFlowTest.Steps
{
    [Binding]
    public class EBD_184_Add_Rebates_Tiered_One_OffSteps
    {
        private static readonly IWebDriver driver = WebDriverFactory.CreateWebDriver(WebBrowser.Chrome);
        private readonly Basic basic = new Basic();
        private readonly MainMenuPageObject mainMenuPageObject = new MainMenuPageObject(driver);
        private readonly PriceManagmentDropDownPageObject priceManagmentDropDownPageObject = new PriceManagmentDropDownPageObject(driver);
        private readonly AgreementsScreenPageObject agreementsScreenPageObject = new AgreementsScreenPageObject(driver);
        private readonly AddRebatePopup addRebatePopup = new AddRebatePopup(driver);
        private readonly AgreementEditorPage agreementEditorPage = new AgreementEditorPage(driver);
        string expectedResult;

        [Given(@"I open Chrome brows\.")]
        public void GivenIOpenChromeBrows_()
        {
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://app.test.e-bate.net/login");
        }

        [Then(@"I Navigate to the test agreement")]
        public void ThenINavigateToTheTestAgreement()
        {
            basic.LoginFlow(driver);
            mainMenuPageObject.ClickPricingManagementHeader();
            priceManagmentDropDownPageObject.ClickAgreements();
            agreementsScreenPageObject.WaitUntillLoaded();
            agreementsScreenPageObject.FindSeleniumAgreementWithRebates();
            agreementsScreenPageObject.SelectFirstRow();
            agreementsScreenPageObject.ClickActionViewButton();
        }

        [Then(@"I Click on ADD button to add new rebate")]
        public void ThenIClickOnADDButtonToAddNewRebate()
        {
            agreementEditorPage.ClickTabsRebate();
            Thread.Sleep(2000);
            agreementEditorPage.ClickTabsRebateAddNewBtn();
            Thread.Sleep(2500);
        }

        [Then(@"I choose Calculation Type -> Tiered One-off rebate")]
        public void ThenIChooseCalculationType_TieredOne_OffRebate()
        {
            addRebatePopup.ChooseCalculationTypeTieredOneOffRebate();
        }

        [Then(@"I choose Calculate Against  ->  Invoice price")]
        public void ThenIChooseCalculateAgainst_InvoicePrice()
        {
            addRebatePopup.ChooseCalculateAgainstInvoicePrice();
        }

        [Then(@"I fill out description")]
        public void ThenIFillOutDescription()
        {
            Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            expectedResult = "Tiered one-off rebate + Invoice price. Selenium. Timestamp: " + unixTimestamp;
            addRebatePopup.SetDescription(expectedResult);
        }

        [Then(@"I Choose category -> QA_Category")]
        public void ThenIChooseCategory_QA_Category()
        {
            addRebatePopup.ChooseCategory();
        }

        [Then(@"I Set Budget and Target")]
        public void ThenISetBudgetAndTarget()
        {
            addRebatePopup.SetTarget().SetBudget();
        }

        [Then(@"I choose Payment frequency -> Ongoing")]
        public void ThenIChoosePaymentFrequency_Ongoing()
        {
            addRebatePopup.ChoosePaymentFrequencyOngoing();
        }

        [Then(@"I choose currency -> Pound Sterling")]
        public void ThenIChooseCurrency_PoundSterling()
        {
            addRebatePopup.ChooseCurrencyPoundSterling();
        }

        [When(@"I click SAVE button")]
        public void WhenIClickSAVEButton()
        {
            addRebatePopup.ClickSaveButton();
        }

        [Then(@"Second popup is opened and I set Tier and Rebate value")]
        public void ThenSecondPopupIsOpenedAndISetTierAndRebateValue()
        {
            addRebatePopup.AddRatesPopupSetTierAndRebateValues();
        }

        [When(@"I click on SAVE btn one more time")]
        public void WhenIClickOnSAVEBtnOneMoreTime()
        {
            addRebatePopup.ClickSaveButton();
        }

        [Then(@"My rebate is presented in the Grid")]
        public void ThenMyRebateIsPresentedInTheGrid()
        {
            if (agreementEditorPage.CheckIfRebateAdded(expectedResult) == true)
            {
                driver.Close();
                driver.Dispose();
            }
        }
    }
}
