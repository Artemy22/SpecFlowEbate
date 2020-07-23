using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace SpecFlowTest.Steps
{
    [Binding]
    public class EBD_215_Delete_PackageSteps
    {
        private IWebDriver driver;

        [Given(@"Open Chrome br\.")]
        public void GivenOpenChromeBr_()
        {
            driver = WebDriverFactory.CreateWebDriver(WebBrowser.Chrome);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://app.test.e-bate.net/login");
        }
        
        [Given(@"Navigate to Pricing Management > Packages\.")]
        public void GivenNavigateToPricingManagementPackages_()
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
        
        [Given(@"Pick package witch you want to delete")]
        public void GivenPickPackageWitchYouWantToDelete()
        {
            PackagesScreenPageObject packagesScreenPageObject = new PackagesScreenPageObject(driver);
            packagesScreenPageObject.ClickSearchInput();
            Actions action = new Actions(driver);
            action.SendKeys("owasp test").Perform();
            Thread.Sleep(2000);
            packagesScreenPageObject.ClickOrderById().ClickOrderById().SelectFirstRow();
        }
        
        [Given(@"Click the button delete")]
        public void GivenClickTheButtonDelete()
        {
            PackagesScreenPageObject packagesScreenPageObject = new PackagesScreenPageObject(driver);
            string expectedResult = packagesScreenPageObject.GetPackageIdFirstRow();
            packagesScreenPageObject.DeleteFlow();
            Thread.Sleep(1000);
            string actualResult = packagesScreenPageObject.GetPackageIdFirstRow();
            Assert.IsFalse(expectedResult == actualResult);
            driver.Close();
        }
    }
}
