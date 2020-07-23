using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace SpecFlowTest.Steps
{
    [Binding]
    public class EBD_214_Edit_PackageSteps
    {
        private IWebDriver driver;
        string descrExpected;

        [Given(@"Chrome browser is opened")]
        public void GivenChromeBrowserIsOpened()
        {
            driver = WebDriverFactory.CreateWebDriver(WebBrowser.Chrome);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://app.test.e-bate.net/login");

        }
        
        [Given(@"I Navigate to Pricing Management > Packages")]
        public void GivenINavigateToPricingManagementPackages()
        {
            Basic basic = new Basic();
            basic.LoginFlow(driver);
            MainMenuPageObject mainMenuPageObject = new MainMenuPageObject(driver);
            mainMenuPageObject.ClickPricingManagementHeader();
            PriceManagmentDropDownPageObject priceManagmentDropDownPageObject = new PriceManagmentDropDownPageObject(driver);
            priceManagmentDropDownPageObject.ClickPackages();
            PackagesScreenPageObject packagesScreenPageObject = new PackagesScreenPageObject(driver);
            packagesScreenPageObject.CheckPackagesLoaded();

        }

        [When(@"I pick a package to change and click the EDIT button")]
        public void WhenIPickAPackageToChangeAndClickTheEDITButton()
        {
            PackagesScreenPageObject packagesScreenPageObject = new PackagesScreenPageObject(driver);
            packagesScreenPageObject.ClickSearchInput();
            Actions action = new Actions(driver);
            action.SendKeys("1592576148").Perform();
            Thread.Sleep(1000);
            packagesScreenPageObject.SelectFirstRow();
        }

        [Then(@"Modify package popup appears")]
        public void ThenModifyPackagePopupAppears()
        {
            PackagesScreenPageObject packagesScreenPageObject = new PackagesScreenPageObject(driver);
            packagesScreenPageObject.ClickActionEditButton();            
        }

        [Then(@"I change e\.g\. a description value")]
        public void ThenIChangeE_G_ADescriptionValue()
        {
            ModifyPackagePopupPageObject modifyPackagePopupPageObject = new ModifyPackagePopupPageObject(driver);
            descrExpected = modifyPackagePopupPageObject.ChangeDescription();
        }

        [When(@"I click save button")]
        public void WhenIClickSaveButton()
        {        
            ModifyPackagePopupPageObject modifyPackagePopupPageObject = new ModifyPackagePopupPageObject(driver);           
            modifyPackagePopupPageObject.ClickSaveButton();
            Thread.Sleep(1000);
            
        }

        [Then(@"Changes saved successfully")]
        public void ThenChangesSavedSuccessfully()
        {
            var actualResult = driver.FindElement(By.XPath("//*[@id=\"gridPackageOverview\"]/div/div[2]/kendo-grid/div/kendo-grid-list/div/div[1]/table/tbody/tr[1]/td[6]")).Text;
            Assert.AreEqual(descrExpected, actualResult);
            driver.Close();
        }

    }
}
