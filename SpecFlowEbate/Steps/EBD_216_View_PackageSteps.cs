using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace SpecFlowTest
{
    [Binding]
    public class EBD_216_View_PackageSteps
    {
        private IWebDriver driver;
                
        //private readonly IWebDriver driver;

        [Given(@"Open Chrome browser")]
        public void GivenOpenChromeBrowser()
        {
            driver = WebDriverFactory.CreateWebDriver(WebBrowser.Chrome);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://app.test.e-bate.net/login");
        }
        
        [Then(@"Navigate to Pricing Management > Packages")]
        public void ThenNavigateToPricingManagementPackages()
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
        
        [Then(@"Pick package witch you want to view  and click the button eye")]
        public void ThenPickPackageWitchYouWantToViewAndClickTheButtonEye()
        {
            PackagesScreenPageObject packagesScreenPageObject = new PackagesScreenPageObject(driver);
            packagesScreenPageObject.ClickSearchInput();
            Actions action = new Actions(driver);
            action.SendKeys("1592576148").Perform();
            Thread.Sleep(2000);
            packagesScreenPageObject.SelectFirstRow();
            packagesScreenPageObject.ClickActionViewButton();
        }
        
        [Then(@"Received Package Details screen")]
        public void ThenReceivedPackageDetailsScreen()
        {
            PackageEditorScreenPageObject packageEditorScreenPageObject = new PackageEditorScreenPageObject(driver);
            Assert.IsTrue(packageEditorScreenPageObject.IsPackageScreenOpened());
            driver.Close();
        }
    }
}
