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
    class AgreementEditorPage
    {
        private readonly IWebDriver _webDriver;

        public readonly By BreadCrumbsHomeBtn = By.Id("linkHome");
        public readonly By BreadCrumbAgreementBtn = By.Id("linkAgreement");
        public readonly By TableHead = By.XPath("/html/body/app-home/div/div/div[2]/app-agreement/app-agreement-detail/section[2]/div/div/div/div[2]/div[2]/kendo-tabstrip/ul");
        public readonly By EditAgreementBtn = By.XPath("/html/body/app-home/div/div/div[2]/app-agreement/app-agreement-detail/section[2]/div/div/div/div[1]/div/button[2]");
        public readonly By TabsRebate = By.XPath("/html/body/app-home/div/div/div[2]/app-agreement/app-agreement-detail/section[2]/div/div/div/div[2]/div[2]/kendo-tabstrip/ul/li[1]");
        public readonly By TabsCriteria = By.XPath("//ul/li[text() = 'Criteria']");
        public readonly By TabsEventBasedIncentives = By.XPath("//ul/li[text() = 'Event-Based Incentives']");
        public readonly By TabsDocuments = By.XPath("/html/body/app-home/div/div/div[2]/app-agreement/app-agreement-detail/section[2]/div/div/div/div[2]/div[2]/kendo-tabstrip/ul/li[4]");
        public readonly By TabsNotes = By.XPath("//ul/li[text() = 'Notes']");
        public readonly By TabsAudit = By.XPath("//ul/li[text() = 'Audit']");
        public readonly By TabsRebateSearchInput = By.Id("filterText");
        public readonly By TabsRebateFirstRowDescription = By.XPath("//*[@id=\"gridAgreementRebates\"]/div/div[2]/kendo-grid/div/kendo-grid-list/div/div[1]/table/tbody/tr[1]/td[4]");
        public readonly By TabsRebateAddNewBtnIfNoOnesExisted = By.XPath("/html/body/app-home/div/div/div[2]/app-agreement/app-agreement-detail/section[2]/div/div/div/div[2]/div[2]/kendo-tabstrip/div/app-agreement-rebates/div[1]/button");
        public readonly By TabsRebateAddNewBtnIfAlreadyExistedOnes = By.XPath("/html/body/app-home/div/div/div[2]/app-agreement/app-agreement-detail/section[2]/div/div/div/div[2]/div[2]/kendo-tabstrip/div/app-agreement-rebates/div/base-grid/div/div[2]/div/div[2]/button/span/i");
        public readonly By TabsRebateFirstRowCheckBox = By.XPath("//*[@id=\"gridAgreementRebates\"]/div/div[2]/kendo-grid/div/kendo-grid-list/div/div[1]/table/tbody/tr/td[2]/label");
        public readonly By TabsRebateOrderById = By.XPath("/html/body/app-home/div/div/div[2]/app-agreement/app-agreement-detail/section[2]/div/div/div/div[2]/div[2]/kendo-tabstrip/div/app-agreement-rebates/div/base-grid/div/div[2]/kendo-grid/div/div/div/table/thead/tr/th[3]/a");
        public readonly By TabsRebateActionDelete = By.Id("action96");
        public readonly By TabsRebateActionView = By.Id("action32");
        public readonly By TabsRebateActionRequest = By.Id("/html/body/app-home/div/div/div[2]/app-agreement/app-agreement-detail/section[2]/div/div/div/div[2]/div[2]/kendo-tabstrip/div/app-agreement-rebates/div/base-grid/div/div[2]/div/div[5]/button/span/i");
        public readonly By TabsCriteriaCompany = By.XPath("//*[@id=\"k - tabstrip - tabpanel - 1\"]/app-criteria-component/div/div/div/div[2]/app-criteria-item/kendo-treeview/ul/li[1]");
        public readonly By TabsCriteriaProduct = By.XPath("//*[@id=\"k - tabstrip - tabpanel - 1\"]/app-criteria-component/div/div/div/div[2]/app-criteria-item/kendo-treeview/ul/li[2]");
        public readonly By TabsCriteriaProject = By.XPath("//*[@id=\"k - tabstrip - tabpanel - 1\"]/app-criteria-component/div/div/div/div[2]/app-criteria-item/kendo-treeview/ul/li[3]");
        public readonly By TabsCriteriaAddNewBtnPlusSign = By.Id("btnNew");
        public readonly By TabsCriteriaDeleteBtn = By.Id("btnDelete");
        public readonly By TabsEventBasedIncentivesAddNewFirstOne = By.XPath("//*[@id=\"k - tabstrip - tabpanel - 2\"]/app-agreement-incentives/div[1]/button");
        public readonly By TabsEventBasedIncentivesAddNewSecondOrMore = By.Id("action0");
        public readonly By TabsEventBasedIncentivesDeleteButton = By.Id("//*[@id=\"action96\"]/span/i");
        public readonly By TabsEventBasedIncentivesViewButton = By.Id("//*[@id=\"gridAgreementRebates\"]/div/div[2]/div/div[4]");
        public readonly By TabsEventBasedIncentivesRequestButton = By.Id("//*[@id=\"gridAgreementRebates\"]/div/div[2]/div/div[5]");
        public readonly By TabsDocumentsUploadtNewBtn = By.XPath("//*[@id=\"gridFilesDocuments\"]/div/div[2]/div/div[3]");
        public readonly By TabsDocumentsDeleteBtn = By.XPath("//*[@id=\"gridFilesDocuments\"]/div/div[2]/div/div[2]");
        public readonly By TabsDocumentsAddDocumentPopupChooseFileButton = By.Id("txtFile");
        public readonly By TabsDocumentsAddDocumentPopupDescriptionInput = By.Id("txtDescription");
        public readonly By TabsDocumentsAddDocumentPopupUploadButton = By.Id("save");
        public readonly By TabsDocumentsCheckIfDocumentAdded = By.XPath("/html/body/app-home/div/div/div[2]/app-package/app-package-detail/section[2]/div/div/div/div[2]/div[2]/kendo-tabstrip/div/app-settlement-documents-overview/div/base-grid/div/div[2]/kendo-grid/div/kendo-grid-list/div/div[1]/table/tbody/tr/td[5]");
        public readonly By TabsDocumentsOrderByDescription = By.XPath("//*[@id=\"gridFilesDocuments\"]/div/div[2]/kendo-grid/div/div/div/table/thead/tr/th[5]");


        public readonly By TabsNotesAddNewNoteBtn = By.XPath("//*[@id=\"gridDealNotes\"]/div/div[2]/div/div[2]");

        private AddRebatePopup Waiter(int seconds, By element)
        {
            var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(seconds));
            try
            {
                wait.Until(d => d.FindElements(element).FirstOrDefault());
                return new AddRebatePopup(_webDriver);
            }
            catch
            {
                var neededElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
                return new AddRebatePopup(_webDriver);
            }
        }

        public AgreementEditorPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public AgreementEditorPage ClickBreadCrumbsHomeBtn()
        {
            _webDriver.FindElement(BreadCrumbsHomeBtn).Click();
            return new AgreementEditorPage(_webDriver);
        }
        public AgreementEditorPage ClickBreadCrumbAgreementBtn()
        {
            _webDriver.FindElement(BreadCrumbAgreementBtn).Click();
            return new AgreementEditorPage(_webDriver);
        }
        public AgreementEditorPage ClickEditAgreementBtn()
        {
            _webDriver.FindElement(EditAgreementBtn).Click();
            return new AgreementEditorPage(_webDriver);
        }
        public AgreementEditorPage ClickTabsRebate()
        {
            _webDriver.FindElement(TableHead).Click();
            _webDriver.FindElement(TabsRebate).Click();
            return new AgreementEditorPage(_webDriver);
        }
        public AgreementEditorPage ClickTabsRebateSearchInput()
        {
            _webDriver.FindElement(TabsRebateSearchInput).Click();
            return new AgreementEditorPage(_webDriver);
        }
        public AgreementEditorPage ClickTabsRebateAddNewBtn()
        {
            try
            {
                _webDriver.FindElement(TabsEventBasedIncentivesAddNewSecondOrMore).Click();
            }
            catch
            {
                _webDriver.FindElement(TabsEventBasedIncentivesAddNewFirstOne).Click();
            }
            return new AgreementEditorPage(_webDriver);
        }
        public AgreementEditorPage ClickTabsRebateChooseFirstRow()
        {
            _webDriver.FindElement(TabsRebateFirstRowCheckBox).Click();
            return new AgreementEditorPage(_webDriver);
        }
        public AgreementEditorPage ClickTabsRebateOrderById()
        {
            _webDriver.FindElement(TabsRebateOrderById).Click();
            return new AgreementEditorPage(_webDriver);
        }

        public AgreementEditorPage ClickTabsRebateActionView()
        {
            _webDriver.FindElement(TabsRebateActionView).Click();
            return new AgreementEditorPage(_webDriver);
        }

        public AgreementEditorPage ClickTabsRebateActionDelete()
        {
            _webDriver.FindElement(TabsRebateActionDelete).Click();
            return new AgreementEditorPage(_webDriver);
        }

        public AgreementEditorPage ClickTabsCriteria()
        {
            _webDriver.FindElement(TabsCriteria).Click();
            return new AgreementEditorPage(_webDriver);
        }

        public AgreementEditorPage ClickTabsCriteriaCompany()
        {
            _webDriver.FindElement(TabsCriteriaCompany).Click();
            return new AgreementEditorPage(_webDriver);
        }

        public AgreementEditorPage ClickTabsCriteriaProduct()
        {
            _webDriver.FindElement(TabsCriteriaProduct).Click();
            return new AgreementEditorPage(_webDriver);
        }

        public AgreementEditorPage ClickTabsCriteriaPrject()
        {
            _webDriver.FindElement(TabsCriteriaProject).Click();
            return new AgreementEditorPage(_webDriver);
        }

        public AgreementEditorPage ClickTabsCriteriaAddNewBtnPlusSign()
        {
            _webDriver.FindElement(TabsCriteriaAddNewBtnPlusSign).Click();
            return new AgreementEditorPage(_webDriver);
        }

        public AgreementEditorPage ClickTabsCriteriaDeleteBtn()
        {
            _webDriver.FindElement(TabsCriteriaDeleteBtn).Click();
            return new AgreementEditorPage(_webDriver);
        }

        public AgreementEditorPage ClickTabsDocuments()
        {
            Thread.Sleep(1000);
            _webDriver.FindElement(TabsDocuments).Click();
            return new AgreementEditorPage(_webDriver);
        }

        public AgreementEditorPage ClickTabsDocumentsUploadtNewDocumentBtn()
        {
            Thread.Sleep(1000);
            _webDriver.FindElement(TabsDocumentsUploadtNewBtn).Click();
            return new AgreementEditorPage(_webDriver);
        }

        public AgreementEditorPage ClickTabsDocumentsDeleteDocumentBtn()
        {
            _webDriver.FindElement(TabsDocumentsDeleteBtn).Click();
            return new AgreementEditorPage(_webDriver);
        }

        public AgreementEditorPage ClickTabsNotes()
        {
            _webDriver.FindElement(TabsNotes).Click();
            return new AgreementEditorPage(_webDriver);
        }

        public AgreementEditorPage ClickTabsAudit()
        {
            _webDriver.FindElement(TabsAudit).Click();
            return new AgreementEditorPage(_webDriver);
        }
        public AgreementEditorPage ClickTabsNotesAddNewNoteBtn()
        {
            _webDriver.FindElement(TabsNotesAddNewNoteBtn).Click();
            return new AgreementEditorPage(_webDriver);
        }

        public bool IsFirstRowAppeared()
        {
            if (_webDriver.FindElement(TabsRebateFirstRowCheckBox).Displayed == true)
            {
                return true;
            }
            else return false;
        }

        public bool IsRebateScreenOpened()
        {
            if (_webDriver.FindElement(TabsRebate).Displayed)
            {
                return true;
            }
            else return false;
        }

        public AgreementEditorPage FindDescriptionUsingSearchInput(string description)
        {
            Actions actions = new Actions(_webDriver);
            _webDriver.FindElement(TabsRebateSearchInput).Click();
            actions.SendKeys(description).Perform();
            return new AgreementEditorPage(_webDriver);
        }

        public RebateEditorPage ChooseAndGoIntoAddedRebate()
        {
            IsFirstRowAppeared();
            _webDriver.FindElement(TabsRebateOrderById).Click();
            IsFirstRowAppeared();
            Thread.Sleep(1000);
            _webDriver.FindElement(TabsRebateOrderById).Click();
            Thread.Sleep(2000);
            ClickTabsRebateChooseFirstRow();
            _webDriver.FindElement(TabsRebateActionView).Click();
            return new RebateEditorPage(_webDriver);

        }

        public bool CheckIfRebateAdded(string expectedResult)
        {
            Waiter(10, TabsRebateFirstRowCheckBox);
            _webDriver.FindElement(TabsRebateOrderById).Click();
            IsFirstRowAppeared();
            Thread.Sleep(1000);
            _webDriver.FindElement(TabsRebateOrderById).Click();
            Thread.Sleep(2000);
            _webDriver.FindElement(TabsRebateFirstRowCheckBox).Click();
            string actualResult = _webDriver.FindElement(TabsRebateFirstRowDescription).Text;
            Assert.AreEqual(expectedResult, actualResult);
            return true;
        }

        public string GetDescription()
        {
            return _webDriver.FindElement(TabsRebateFirstRowDescription).Text;
        }

        public AgreementEditorPage ChooseDocumentFile()
        {
            IWebElement fileInput = _webDriver.FindElement(TabsDocumentsAddDocumentPopupChooseFileButton);
            fileInput.SendKeys("D:/Downloads/Trade Agreement Package 198_2020-37-21_09-37-37");
            return new AgreementEditorPage(_webDriver);
        }
        public string AddDocumentPopupSetDescription(string description)
        {
            Actions actions = new Actions(_webDriver);
            _webDriver.FindElement(TabsDocumentsAddDocumentPopupDescriptionInput).Click();
            Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            string result = description + $" {unixTimestamp}";
            actions.SendKeys(result).Perform();
            return result;
        }
        public AgreementEditorPage AddDocumentPopupClickUploadButton()
        {
            _webDriver.FindElement(TabsDocumentsAddDocumentPopupUploadButton).Click();
            return new AgreementEditorPage(_webDriver);
        }

        public string IfDocumentAdded()
        {
            Waiter(10, TabsDocumentsCheckIfDocumentAdded);
            _webDriver.FindElement(TabsRebateFirstRowDescription).Click();
            Thread.Sleep(1000);
            Waiter(10, TabsDocumentsCheckIfDocumentAdded);
            _webDriver.FindElement(TabsDocumentsOrderByDescription).Click();
            Thread.Sleep(1000);
            Waiter(10, TabsDocumentsCheckIfDocumentAdded);
            string actualResult = _webDriver.FindElement(TabsDocumentsCheckIfDocumentAdded).Text;
            return actualResult;
        }
    }
}