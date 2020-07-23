using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SpecFlowTest
{
    class RebateEditorPage
    {
        private readonly IWebDriver _webDriver;    
        readonly Random rnd = new Random();

        public RebateEditorPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public readonly By BreadCrumbsHomeBtn = By.Id("linkHome");
        public readonly By TableHead = By.XPath("/html/body/app-home/div/div/div[2]/app-agreement/app-agreement-detail/section[2]/div/div/div/div[2]/div[2]/kendo-tabstrip/ul");
        public readonly By EditRebateBtn = By.XPath("/html/body/app-home/div/div/div[2]/app-rebate-detail/section[2]/div/div/div/div[1]/div/button[2]");
        public readonly By UpperRequestButton = By.XPath("/html/body/app-home/div/div/div[2]/app-rebate-detail/section[2]/div/div/div/div[1]/div/button[1]");

        public readonly By TabsOverview = By.Id("k - tabstrip - tab - 0");
        public readonly By TabsRates = By.XPath("/html/body/app-home/div/div/div[2]/app-rebate-detail/section[2]/div/div/div/div[2]/div[2]/div/kendo-tabstrip/ul/li[2]/span");
        public readonly By TabsCriteria = By.Id("k - tabstrip - tab - 2");
        public readonly By TabsAllocation = By.Id("k - tabstrip - tab - 3");
        public readonly By TabsQualifications = By.Id("k - tabstrip - tab - 4");

        public readonly By TabsDocuments = By.Id("k - tabstrip - tab - 5");
        public readonly By TabsDocumentsAddNewButton = By.XPath("//*[@id=\"gridFilesDocuments\"]/div/div[2]/div/div[3]");
        public readonly By TabsDocumentsPopupChooseDocument = By.Id("txtFile");
        public readonly By TabsDocumentsSetDescription = By.Id("txtDescription");
        public readonly By TabsDocumentsPopupUploadButton = By.Id("Save");

        public readonly By TabsNotes = By.Id("k - tabstrip - tab - 6");
        public readonly By TabsAudit = By.Id("k - tabstrip - tab - 7");
        public readonly By StartDateInput = By.XPath("//*[@id=\"headingSection\"]/form/div[1]/div[3]/div/kendo-datepicker/span/kendo-dateinput/span");
        public readonly By EndDateInput = By.XPath("//*[@id=\"headingSection\"]/form/div[2]/div[3]/div/kendo-datepicker/span/kendo-dateinput/span");
        public readonly By PaymentCurrencyInput = By.XPath("/html/body/app-home/div/div/div[2]/app-rebate-detail/section[2]/div/div/div/div[2]/div[1]/form/div[2]/div[4]/div/kendo-dropdownlist/span/span[1]");
        public readonly By PaymentFrequencyDropDown = By.XPath("/html/body/app-home/div/div/div[2]/app-rebate-detail/section[2]/div/div/div/div[2]/div[1]/form/div[1]/div[4]/div/kendo-dropdownlist/span");
        public readonly By AccrualType = By.XPath("/html/body/app-home/div/div/div[2]/app-rebate-detail/section[2]/div/div/div/div[2]/div[1]/form/div[1]/div[5]/div/kendo-dropdownlist/span");
        public readonly By DescriptionInput = By.XPath("//*[@id=\"headingSection\"]/form/div[2]/div[2]/div/input");
        public readonly By CategoryDropDown = By.Id("rebateCategory");
        public readonly By PayToDropDown = By.XPath("//*[@id=\"headingSection\"]/form/div[3]/div[4]/div/kendo-dropdownlist");
        public readonly By CalculateAgainstDropDown = By.Id("ddlPriceTypeId");
        public readonly By BudgetInput = By.XPath("//*[@id=\"headingSection\"]/form/div[4]/div[1]/div/kendo-numerictextbox/span");
        public readonly By TargetInput = By.XPath("//*[@id=\"headingSection\"]/form/div[4]/div[2]/div/kendo-numerictextbox/span");
        public readonly By TabsRatesSearchInput = By.Id("gridSearch");

        public readonly By TabsRatesStandartRebateActionDelete = By.Id("action96");
        public readonly By TabsRatesStandartRebateActionView = By.Id("action32");
        public readonly By TabsRatesStandartRebateActionAddNew = By.Id("action0");
        public readonly By TabsRatesStandartRebateRequestButton = By.XPath("/html/body/app-home/div/div/div[2]/app-rebate-detail/section[2]/div/div/div/div[2]/div[2]/div/kendo-tabstrip/div/app-rebate-detail-rates/div[2]/app-rate-grid/base-grid/div/div[2]/div/div[5]/button");
        public readonly By TabsRatesStandartRebateFirstRowCheckBox = By.Id("k-grid8-checkbox0");
        public readonly By TabsRatesStandartRebateOrderById = By.XPath("//*[@id=\"k - tabstrip - tabpanel - 1\"]/app-rebate-detail-rates/div[2]/app-rate-grid/base-grid/div/div[2]/kendo-grid/div/div/div/table/thead/tr/th[3]/a");

        public readonly By TabsRatesProductRebateActionDelete = By.XPath("//*[@id=\"k - tabstrip - tabpanel - 1\"]/app-rebate-detail-rates/div[2]/app-rate-grid/base-grid/div/div[2]/div/div[4]");
        public readonly By TabsRatesProductRebateActionEdit = By.XPath("//*[@id=\"k - tabstrip - tabpanel - 1\"]/app-rebate-detail-rates/div[2]/app-rate-grid/base-grid/div/div[2]/div/div[2]");
        public readonly By TabsRatesProductRebateRequestButton = By.XPath("/html/body/app-home/div/div/div[2]/app-rebate-detail/section[2]/div/div/div/div[2]/div[2]/div/kendo-tabstrip/div/app-rebate-detail-rates/div[2]/app-rate-grid/base-grid/div/div[2]/div/div[5]/button");
        public readonly By TabsRatesProductRebateFirstRowCheckBox = By.Id("k-grid8-checkbox0");
        public readonly By TabsRatesProductRebateOrderById = By.XPath("/html/body/app-home/div/div/div[2]/app-rebate-detail/section[2]/div/div/div/div[2]/div[2]/div/kendo-tabstrip/div/app-rebate-detail-rates/div[2]/app-rate-grid/base-grid/div/div[2]/kendo-grid/div/div/div/table/thead/tr/th[3]/a");
        public readonly By TabsRatesProductRebateProductInput = By.Id("products");
        public readonly By TabsRatesProductRebateEffectiveFromInput = By.XPath("//*[@id=\"dateFrom\"]/span/kendo-dateinput/span");
        public readonly By TabsRatesProductRebateMinQtyInput = By.Id("minQty");
        public readonly By TabsRatesProductRebateValueInput = By.Id("manualValue");
        public readonly By TabsRatesProductRebateAddConfiguredRateIcon = By.Id("addProductLevelButton");
        public readonly By TabsRatesProductRebateExpireRateIcon = By.XPath("//*[@id=\"k - tabstrip - tabpanel - 1\"]/app-rebate-detail-rates/div[2]/app-rate-grid/base-grid/div/div[2]/div/div[3]");
        public readonly By TabsRatesProductRebateFirstRowDescription = By.Id("//*[@id=\"k - tabstrip - tabpanel - 1\"]/app-rebate-detail-rates/div[2]/app-rate-grid/base-grid/div/div[2]/kendo-grid/div/kendo-grid-list/div/div[1]/table/tbody/tr/td[5]");
        public readonly By TabsRatesProductRebateCheckValueFirstRow = By.XPath("/html/body/app-home/div/div/div[2]/app-rebate-detail/section[2]/div/div/div/div[2]/div[2]/div/kendo-tabstrip/div/app-rebate-detail-rates/div[2]/app-rate-grid/base-grid/div/div[2]/kendo-grid/div/kendo-grid-list/div/div[1]/table/tbody/tr[1]/td[9]/div");


        

        public bool Waiter(int seconds, By element)
        {
            var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(seconds));
            try
            {
                wait.Until(d => d.FindElements(element).FirstOrDefault());
                return true;
            }
            catch
            {
                var neededElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
                return true;
            }
        }

        public RebateEditorPage ClickTabsRates()
        {
            Waiter(10, TabsRates);
            Thread.Sleep(1000);
            _webDriver.FindElement(TabsRates).Click();
            return new RebateEditorPage(_webDriver);
        }

        public RebateEditorPage ChooseOneProductFromDropDown()
        {
            Actions actions = new Actions(_webDriver);
            Waiter(10, TabsRatesProductRebateAddConfiguredRateIcon);
            _webDriver.FindElement(TabsRatesProductRebateProductInput).Click();
            actions.SendKeys("Tigi").Perform();
            Thread.Sleep(2500);
            actions.SendKeys(Keys.ArrowDown + Keys.ArrowDown + Keys.Enter).Perform();
            return new RebateEditorPage(_webDriver);
        }

        public RebateEditorPage SetEffectiveFrom()
        {
            Actions actions = new Actions(_webDriver);
            _webDriver.FindElement(TabsRatesProductRebateEffectiveFromInput).Click();
            actions.SendKeys(Keys.Home + "01012001").Perform();
            return new RebateEditorPage(_webDriver);
        }

        public RebateEditorPage SetMinQtyForChosenProduct()
        {
            int int0to999 = rnd.Next(0, 999);
            Actions actions = new Actions(_webDriver);
            _webDriver.FindElement(TabsRatesProductRebateMinQtyInput).Click();
            actions.SendKeys($"{int0to999}").Perform();

            return new RebateEditorPage(_webDriver);
        }

        public string SetValueForChosenProduct()
        {
            Actions actions = new Actions(_webDriver);
            _webDriver.FindElement(TabsRatesProductRebateValueInput).Click();
            Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalMinutes;
            actions.SendKeys($"{unixTimestamp}").Perform();
            string expectedResult = $"{unixTimestamp}";
            return expectedResult;
        }

        public RebateEditorPage ClickBreadCrumbsHomeBtn()
        {
            _webDriver.FindElement(BreadCrumbsHomeBtn).Click();
            return new RebateEditorPage(_webDriver);
        }

        public RebateEditorPage ClickTabsDocuments()
        {
            _webDriver.FindElement(TabsDocuments).Click();
            return new RebateEditorPage(_webDriver);
        }

        public RebateEditorPage ClickTabsNotes()
        {
            _webDriver.FindElement(TabsNotes).Click();
            return new RebateEditorPage(_webDriver);
        }

        public RebateEditorPage ClickTabsAudit()
        {
            _webDriver.FindElement(TabsAudit).Click();
            return new RebateEditorPage(_webDriver);
        }


        public bool IsFirstRowAppeared()
        {
            if (_webDriver.FindElement(TabsRatesProductRebateFirstRowCheckBox).Displayed == true)
            {
                return true;
            }
            else return false;
        }

        public bool IsRebateDetailsScreenOpened()
        {
            if (_webDriver.FindElement(TabsRates).Displayed)
            {
                return true;
            }
            else return false;
        }

        public RebateEditorPage FindDescriptionUsingSearchInput(string description)
        {
            Actions actions = new Actions(_webDriver);
            _webDriver.FindElement(TabsRatesSearchInput).Click();
            actions.SendKeys(description).Perform();
            return new RebateEditorPage(_webDriver);
        }

        public string GetDescription()
        {
            return _webDriver.FindElement(TabsRatesProductRebateFirstRowDescription).Text;
        }

        public void ClickTabsRatesProductRebateAddConfiguredRateIcon()
        {
            Thread.Sleep(500);
            _webDriver.FindElement(TabsRatesProductRebateAddConfiguredRateIcon).Click();
        }

        public void ClickOrderByIdRatesTab() => _webDriver.FindElement(TabsRatesProductRebateOrderById).Click();

        public void DoubleClickOrderByIdRatesTab()
        {
            Thread.Sleep(2000);
            ClickOrderByIdRatesTab();
            Thread.Sleep(2000);
            ClickOrderByIdRatesTab();
            Thread.Sleep(2000);
        }

        public string GetValueForChecking()
        {
            DoubleClickOrderByIdRatesTab();
            Thread.Sleep(5000);
                string valueBefore = _webDriver.FindElement(TabsRatesProductRebateCheckValueFirstRow).Text;
                var actualResult = valueBefore;
                actualResult = new string((from c in actualResult
                                       where char.IsWhiteSpace(c) || char.IsLetterOrDigit(c)
                                         select c
                    ).ToArray());
                return actualResult;
        }

        public RebateEditorPage ChooseDocumentFile()
        {
            IWebElement fileInput = _webDriver.FindElement(TabsDocumentsPopupChooseDocument);
            fileInput.SendKeys("C:/Users/ovly/Downloads/docForTestDoNotDelete.pdf");
            return new RebateEditorPage(_webDriver);
        }

        public string AddDocumentPopupSetDescription(string description)
        {
            Actions actions = new Actions(_webDriver);
            _webDriver.FindElement(TabsDocumentsSetDescription).Click();
            Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            string result = description + $" {unixTimestamp}";
            actions.SendKeys(result).Perform();
            return result;
        }
        public RebateEditorPage AddDocumentPopupClickUploadButton()
        {
            _webDriver.FindElement(TabsDocumentsPopupUploadButton).Click();
            return new RebateEditorPage(_webDriver);
        }

        //public string IfDocumentAdded()
        //{
           // Waiter(10, TabsDocumentsCheckIfDocumentAdded);
           // _webDriver.FindElement(TabsRebateFirstRowDescription).Click();
           // Thread.Sleep(1000);
           // Waiter(10, TabsDocumentsCheckIfDocumentAdded);
           // _webDriver.FindElement(TabsDocumentsOrderByDescription).Click();
            //Thread.Sleep(1000);
            //Waiter(10, TabsDocumentsCheckIfDocumentAdded);
            //string actualResult = _webDriver.FindElement(TabsDocumentsCheckIfDocumentAdded).Text;
           // return actualResult;
        //}

    }
}