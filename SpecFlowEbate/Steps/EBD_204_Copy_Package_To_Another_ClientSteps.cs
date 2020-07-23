using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace SpecFlowTest.Steps
{
    [Binding]
    public class EBD_204_Copy_Package_To_Another_ClientSteps
    {

        private static readonly IWebDriver driver = WebDriverFactory.CreateWebDriver(WebBrowser.Chrome);
        private readonly Basic basic = new Basic();
        private readonly Actions actions = new Actions(driver);
        private readonly MainMenuPageObject mainMenuPageObject = new MainMenuPageObject(driver);
        private readonly PriceManagmentDropDownPageObject priceManagmentDropDownPageObject = new PriceManagmentDropDownPageObject(driver);
        private readonly AgreementsScreenPageObject agreementsScreenPageObject = new AgreementsScreenPageObject(driver);
        private readonly AddRebatePopup addRebatePopup = new AddRebatePopup(driver);
        private readonly AddPackagePopupPageObject addPackagePopupPageObject = new AddPackagePopupPageObject(driver);
        private readonly AgreementEditorPage agreementEditorPage = new AgreementEditorPage(driver);
        private readonly PackagesScreenPageObject packagesScreenPageObject = new PackagesScreenPageObject(driver);
        private readonly PackageEditorScreenPageObject packageEditorScreenPageObject = new PackageEditorScreenPageObject(driver);
        string expectedResult;

        [Given(@"Chrome opened")]
        public void GivenChromeOpened()
        {
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://app.test.e-bate.net/login");
        }

        [When(@"I navigate to Pricing Management > Packages")]
        public void WhenINavigateToPricingManagementPackages()
        {
            basic.LoginFlow(driver);
            mainMenuPageObject.ClickPricingManagementHeader();
            priceManagmentDropDownPageObject.ClickPackages();
            packagesScreenPageObject.WaitUntillLoaded();
            packagesScreenPageObject.ClickSearchInput();
            actions.SendKeys("owasp test").Perform();
            packagesScreenPageObject.CheckPackagesLoaded();
            Thread.Sleep(1500);
        }

        [When(@"I pick test package for copying")]
        public void WhenIPickTestPackageForCopying()
        {
            packagesScreenPageObject.ClickOrderById();
            Thread.Sleep(1500);
            packagesScreenPageObject.SelectFirstRow();
        }

        [When(@"Copy popup is opened")]
        public void WhenCopyPopupIsOpened()
        {
            Assert.IsTrue(addPackagePopupPageObject.WaitUntillCopyPopupOpened());
        }


        [When(@"I Click on COPY button")]
        public void WhenIClickOnCOPYButton()
        {
            packagesScreenPageObject.ClickActionCopyButton();
        }

        [When(@"I enter all required data and click on COPY button")]
        public void WhenIEnterAllRequiredDataAndClickOnCOPYButton()
        {
            addPackagePopupPageObject.SetAccountTypeInvoiceAccount().SetInvoiceAccountCompany();
            addPackagePopupPageObject.SetStartDateForCopiedPackage();
            expectedResult = addPackagePopupPageObject.getDescription();
            addPackagePopupPageObject.ClickSaveBtn();
        }

        [Then(@"Copied package is presented in grid")]
        public void ThenCopiedPackageIsPresentedInGrid()
        {
            Assert.AreEqual(packagesScreenPageObject.IfSuccessfullPopupAppearedAfterCopying(), packagesScreenPageObject.CheckIfPackageCopied(expectedResult));
            driver.Close();            
        }
    }
}
