using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace SpecFlowTest.Steps
{
    
    [Binding]
    public class EBD_181_Create_A_PackageSteps
    {
        private IWebDriver driver;
        string description;

        [Given(@"Opened Chrome browser")]
        public void GivenOpenChromeBrowser()
        {            
            driver = WebDriverFactory.CreateWebDriver(WebBrowser.Chrome);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://app.test.e-bate.net/login");
        }

        // our steps definitions
        [Given(@"Navigate to Pricing Management > Packages")]
        public void GivenNavigateToPricingManagementPackages()
        {
            Basic basic = new Basic();
            basic.LoginFlow(driver);
            MainMenuPageObject mainMenuPageObject = new MainMenuPageObject(driver);
            mainMenuPageObject.ClickPricingManagementHeader();
            PriceManagmentDropDownPageObject priceManagmentDropDownPageObject = new PriceManagmentDropDownPageObject(driver);
            priceManagmentDropDownPageObject.ClickPackages();
        }

        [Given(@"Click the Add button")]
        public void GivenClickTheAddButton()
        {
            PackagesScreenPageObject packagesScreenPageObject = new PackagesScreenPageObject(driver);
            packagesScreenPageObject.ClickAddPackageBtn();
        }

        [Given(@"Select a company type Customer")]
        public void GivenSelectACompanyTypeCustomer()
        {
            var addPackagePopup = new AddPackagePopupPageObject(driver);
            addPackagePopup.ClickCustomerType();
        }

        [Given(@"Select an Account Type Invoice")]
        public void GivenSelectAnAccountTypeInvoice()
        {
            var addPackagePopup = new AddPackagePopupPageObject(driver);
            addPackagePopup.SetAccountTypeInvoiceAccount();
        }

        [Given(@"Select the company")]
        public void GivenSelectTheCompany()
        {
            var addPackagePopup = new AddPackagePopupPageObject(driver);
            addPackagePopup.SetInvoiceAccountCompany();
        }

        [Given(@"Complete the remaining fields")]
        public void GivenCompleteTheRemainingFields()
        {
            var addPackagePopup = new AddPackagePopupPageObject(driver);
            addPackagePopup.SetPeriodOngoing();
            addPackagePopup.SetStartDate();
            addPackagePopup.SetEndDate();
            Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            description = "Add Package For Customer Single Company Invoice Account Ongoing. Timestamp: " + unixTimestamp;
            addPackagePopup.SetDescription(description);
            addPackagePopup.SetBudget();
            addPackagePopup.SetTarget();
        }

        [Given(@"Click the Save button")]
        public void GivenClickTheSaveButton()
        {
            var addPackagePopup = new AddPackagePopupPageObject(driver);
            addPackagePopup.ClickSaveBtn();
        }

        [Then(@"Check if a package has been created")]
        public void ThenCheckIfPackageIsCreated()
        {
            Actions actions = new Actions(driver);
            var packagesScreen = new PackagesScreenPageObject(driver);
            packagesScreen.ClickSearchInput();
            actions.SendKeys(description + Keys.Enter).Perform();
            var actualResult = driver.FindElement(By.XPath("//*[@id=\"gridPackageOverview\"]/div/div[2]/kendo-grid/div/kendo-grid-list/div/div[1]/table/tbody/tr[1]/td[6]")).Text;
            Assert.IsNotNull(actualResult);
            driver.Close();
        }
    }
}