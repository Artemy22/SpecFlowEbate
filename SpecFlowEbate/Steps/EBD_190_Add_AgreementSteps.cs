using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace SpecFlowTest.Steps
{
    [Binding]
    public class EBD_190_Add_AgreementSteps
    {
        private static readonly IWebDriver driver = WebDriverFactory.CreateWebDriver(WebBrowser.Chrome);
        private readonly Basic basic = new Basic();
        private readonly Actions action = new Actions(driver);
        private readonly MainMenuPageObject mainMenuPageObject = new MainMenuPageObject(driver);
        private readonly PackagesScreenPageObject packagesScreenPageObject = new PackagesScreenPageObject(driver);
        private readonly PriceManagmentDropDownPageObject priceManagmentDropDownPageObject = new PriceManagmentDropDownPageObject(driver);
        private readonly PackageEditorScreenPageObject packageEditorScreenPageObject = new PackageEditorScreenPageObject(driver);
        private readonly AddAgreementPopupPageObject addAgreementPopupPageObject = new AddAgreementPopupPageObject(driver);

        string description;

        [Given(@"Open chrome")]
        public void GivenOpenChrome()
        {
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://app.test.e-bate.net/login");
        }

        [Given(@"Open Package")]
        public void GivenOpenPackage()
        {
            basic.LoginFlow(driver);
            mainMenuPageObject.ClickPricingManagementHeader();
            priceManagmentDropDownPageObject.ClickPackages();
            packagesScreenPageObject.WaitUntillLoaded();
            packagesScreenPageObject.ClickSearchInput();
            action.SendKeys("owasp test AND 1=1").Perform();
            Thread.Sleep(1500);
            packagesScreenPageObject.SelectFirstRow();
            packagesScreenPageObject.ClickActionViewButton();
            Thread.Sleep(1500);
            if (packageEditorScreenPageObject.IfCriteriaPopupAppeared())
            {
                packageEditorScreenPageObject.ClickNoButtonAddCriteria();
            }
            else Thread.Sleep(100);
            packageEditorScreenPageObject.ClickTabsAgreements();
            Thread.Sleep(100);
            packageEditorScreenPageObject.ClickTabsAgreementsAddNewBtn();           

        }

        [Given(@"Add agreement to the package")]
        public void GivenAddAgreementToThePackage()
        {
            Thread.Sleep(1000);
            Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            description = "Agreement by SeleniumWithoutRebate. Timestamp: " + unixTimestamp;
            addAgreementPopupPageObject.SetBudget().SetTarget().SetStartDate().SetEndDate().SetDescription(description);
        }

        [When(@"Save the Agreement")]
        public void WhenSaveTheAgreement()
        {
            addAgreementPopupPageObject.ClickSaveButton();
            if(addAgreementPopupPageObject.IsWarningAppeared() != false)
            {
                addAgreementPopupPageObject.WarningPopupClickYes();
            }            
        }

        [Then(@"An added agreement is presented in the grid")]
        public void ThenAnAddedAgreementIsPresentedInTheGrid()
        {
            packageEditorScreenPageObject.FindDescriptionUsingSearchInput(description);
            Thread.Sleep(500);
            Assert.IsTrue(packageEditorScreenPageObject.IsFirstRowAppeared());

        }

        [Then(@"chrome is closed")]
        public void ThenChromeIsClosed()
        {
            driver.Close();
        }

    }
}
