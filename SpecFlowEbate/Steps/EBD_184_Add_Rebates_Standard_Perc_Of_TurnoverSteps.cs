using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SpecFlowTest.Steps
{
    [Binding]
    public class EBD_184_Add_Rebate_Standard_Perc_Of_Turnover_Steps
    {
        private static readonly IWebDriver driver = WebDriverFactory.CreateWebDriver(WebBrowser.Chrome);
        private readonly Basic basic = new Basic();
        private readonly MainMenuPageObject mainMenuPageObject = new MainMenuPageObject(driver);
        private readonly PriceManagmentDropDownPageObject priceManagmentDropDownPageObject = new PriceManagmentDropDownPageObject(driver);
        private readonly AgreementsScreenPageObject agreementsScreenPageObject = new AgreementsScreenPageObject(driver);
        private readonly AddRebatePopup addRebatePopup = new AddRebatePopup(driver);
        private readonly AgreementEditorPage agreementEditorPage = new AgreementEditorPage(driver);
        string expectedResult;

        [Given(@"I open  Chrome")]
        public void GivenIOpenChrome()
        {
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://app.test.e-bate.net/login");
        }

        [Then(@"Navigate  to test agreement")]
        public void ThenNavigateToTestAgreement()
        {
            basic.LoginFlow(driver);
            mainMenuPageObject.ClickPricingManagementHeader();
            priceManagmentDropDownPageObject.ClickAgreements();
            agreementsScreenPageObject.WaitUntillLoaded();
            agreementsScreenPageObject.FindSeleniumAgreementWithRebates();
            agreementsScreenPageObject.SelectFirstRow();
            agreementsScreenPageObject.ClickActionViewButton();
        }

        [Then(@"Click  on ADD  button to add new rebate")]
        public void ThenClickOnADDButtonToAddNewRebate()
        {
            agreementEditorPage.ClickTabsRebate();
            Thread.Sleep(2000);
            agreementEditorPage.ClickTabsRebateAddNewBtn();
            Thread.Sleep(2500);
        }

        [Then(@"I choose  Calculation Type -> Standard % of Turnover")]
        public void ThenIChooseCalculationType_StandardOfTurnover()
        {
            addRebatePopup.ChooseCalculationTypeStandardPercOfTurnover();
        }

        [Then(@"I choose  Calculate Against -> Invoice price")]
        public void ThenIChooseCalculateAgainst_InvoicePrice()
        {
            addRebatePopup.ChooseCalculateAgainstInvoicePrice();
        }

        [Then(@"I  fill out some description")]
        public void ThenIFillOutSomeDescription()
        {
            Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            expectedResult = "Standard % of Turnover + Invoice price. Selenium. Timestamp: " + unixTimestamp;
            addRebatePopup.SetDescription(expectedResult);
        }

        [Then(@"I  Choose Category -> QA_Category")]
        public void ThenIChooseCategory_QA_Category()
        {
            addRebatePopup.ChooseCategory();
        }

        [Then(@"Set  Budget and Target")]
        public void ThenSetBudgetAndTarget()
        {
            addRebatePopup.SetTarget().SetBudget();
        }

        [Then(@"I  choose Payment Frequency -> Ongoing")]
        public void ThenIChoosePaymentFrequency_Ongoing()
        {
            addRebatePopup.ChoosePaymentFrequencyOngoing();
        }

        [Then(@"I  choose Currency -> Pound Sterling")]
        public void ThenIChooseCurrency_PoundSterling()
        {
            addRebatePopup.ChooseCurrencyPoundSterling();
        }

        [When(@"I  click on SAVE button")]
        public void WhenIClickOnSAVEButton()
        {
            addRebatePopup.ClickSaveButton();
        }

        [Then(@"Second  popup is opened and I set Percentage")]
        public void ThenSecondPopupIsOpenedAndISetPercentage()
        {
            addRebatePopup.AddRatesPopupSetPercentage();
        }

        [When(@"I  click on SAVE button one more time")]
        public void WhenIClickOnSAVEButtonOneMoreTime()
        {
            addRebatePopup.ClickSaveButton();
        }

        [Then(@"My  rebate is presented in Grid")]
        public void ThenMyRebateIsPresentedInGrid()
        {
            agreementEditorPage.IsFirstRowAppeared();

            if (agreementEditorPage.CheckIfRebateAdded(expectedResult) == true)
            {
                driver.Close();
                driver.Dispose();
            }
        }
    }
}