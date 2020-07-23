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
    class PackageEditorScreenPageObject
    {
        private IWebDriver _webDriver;

        public readonly By _BreadCrumbsHomeBtn = By.XPath("//*[@id=\"linkHome\"]");
        public readonly By _BreadCrumbPackageBtn = By.XPath("//*[@id=\"linkPackage\"]");
        public readonly By _editPackageBtn = By.XPath("/html/body/app-home/div/div/div[2]/app-package/app-package-detail/section[2]/div/div/div/div[1]/div/button");
        public readonly By _tabsAgreements = By.XPath("/html/body/app-home/div/div/div[2]/app-package/app-package-detail/section[2]/div/div/div/div[2]/div[2]/kendo-tabstrip/ul/li[1]/span");
        public readonly By _tabsCriteria = By.XPath("/html/body/app-home/div/div/div[2]/app-package/app-package-detail/section[2]/div/div/div/div[2]/div[2]/kendo-tabstrip/ul/li[2]/span");
        public readonly By _tabsDocuments = By.XPath("/html/body/app-home/div/div/div[2]/app-package/app-package-detail/section[2]/div/div/div/div[2]/div[2]/kendo-tabstrip/ul/li[3]/span");
        public readonly By _tabsNotes = By.XPath("/html/body/app-home/div/div/div[2]/app-package/app-package-detail/section[2]/div/div/div/div[2]/div[2]/kendo-tabstrip/ul/li[4]/span");
        public readonly By _tabsAudit = By.XPath("/html/body/app-home/div/div/div[2]/app-package/app-package-detail/section[2]/div/div/div/div[2]/div[2]/kendo-tabstrip/ul/li[5]/span");
        public readonly By _tabsAgreementsSearchInput = By.XPath("//*[@id=\"filterText\"]");
        public readonly By _tabsAgreementsAddNewBtnIfNoAgreementsExists = By.XPath("/html/body/app-home/div/div/div[2]/app-package/app-package-detail/section[2]/div/div/div/div[2]/div[2]/kendo-tabstrip/div/app-package-agreement/div[1]/button");
        public readonly By _tabsAgreementsAddNewBtnIfAlreadyExistAnyAgreements = By.XPath("/html/body/app-home/div/div/div[2]/app-package/app-package-detail/section[2]/div/div/div/div[2]/div[2]/kendo-tabstrip/div/app-package-agreement/div/div[1]/button");


        public readonly By _tabsAgreementsChooseFirstRow = By.XPath("//*[@id=\"gridAgreement\"]/div/div[2]/kendo-grid/div/kendo-grid-list/div/div[1]/table/tbody/tr[1]/td[2]/label");
        public readonly By _tabsAgreementsOrderById = By.XPath("//*[@id=\"gridAgreement\"]/div/div[2]/kendo-grid/div/div/div/table/thead/tr/th[3]/a");
        public readonly By _tabsAgreementsOpenRebatesDropDownOfFirstRow = By.XPath("//*[@id=\"gridAgreement\"]/div/div[2]/kendo-grid/div/kendo-grid-list/div/div[1]/table/tbody/tr[1]/td[1]/a");
        public readonly By _tabsAgreementsRebatesDropDownOfFirstRowChooseFirstRebate = By.XPath("//*[@id=\"gridAgreement\"]/div/div[2]/kendo-grid/div/kendo-grid-list/div/div[1]/table/tbody/tr[2]/td[2]/kendo-grid/div/kendo-grid-list/div/div[1]/table/tbody/tr[1]/td[1]/label");
        public readonly By _tabsAgreementsActionEdit = By.XPath("//*[@id=\"gridAgreement\"]/div/div[2]/div/div[2]");
        public readonly By _tabsAgreementsActionView = By.XPath("//*[@id=\"gridAgreement\"]/div/div[2]/div/div[3]");
        public readonly By _tabsAgreementsActionCopy = By.XPath("//*[@id=\"gridAgreement\"]/div/div[2]/div/div[4]");
        public readonly By _tabsAgreementsActionDelete = By.XPath("//*[@id=\"gridAgreement\"]/div/div[2]/div/div[5]");
        public readonly By _tabsCriteriaCompany = By.XPath("//*[@id=\"k - tabstrip - tabpanel - 1\"]/app-criteria-component/div/div/div/div[2]/app-criteria-item/kendo-treeview/ul/li[1]/div/span");
        public readonly By _tabsCriteriaProduct = By.XPath("//*[@id=\"k - tabstrip - tabpanel - 1\"]/app-criteria-component/div/div/div/div[2]/app-criteria-item/kendo-treeview/ul/li[2]/div/span");
        public readonly By _tabsCriteriaPrject = By.XPath("//*[@id=\"k - tabstrip - tabpanel - 1\"]/app-criteria-component/div/div/div/div[2]/app-criteria-item/kendo-treeview/ul/li[3]/div/span");
        public readonly By _tabsCriteriaAddNewBtnPlusSign = By.XPath("//*[@id=\"btnNew\"]");
        public readonly By _tabsCriteriaDeleteBtn = By.XPath("//*[@id=\"btnDelete\"]");
        public readonly By _tabsDocumentsGenerateTradeAgreementBtn = By.XPath("//*[@id=\"gridAgreementFiles\"]/div/div[2]/div/div[2]");
        public readonly By _tabsDocumentsUploadtNewDocumentBtn = By.XPath("//*[@id=\"gridFilesDocuments\"]/div/div[2]/div/div[3]");
        public readonly By _tabsDocumentsDeleteDocumentBtn = By.XPath("//*[@id=\"action32\"]");
        public readonly By _tabsDocumentsAddDocumentPopupChooseFileButton = By.Id("txtFile");
        public readonly By _tabsDocumentsAddDocumentPopupDescriptionInput = By.Id("txtDescription");
        public readonly By _tabsDocumentsAddDocumentPopupUploadButton = By.Id("save");
        public readonly By _tabsDocumentsCheckIfDocumentAdded = By.XPath("/html/body/app-home/div/div/div[2]/app-package/app-package-detail/section[2]/div/div/div/div[2]/div[2]/kendo-tabstrip/div/app-settlement-documents-overview/div/base-grid/div/div[2]/kendo-grid/div/kendo-grid-list/div/div[1]/table/tbody/tr/td[5]");
        public readonly By _tabsDocumentsOrderByDescription = By.XPath("//*[@id=\"gridFilesDocuments\"]/div/div[2]/kendo-grid/div/div/div/table/thead/tr/th[5]");


        public readonly By _tabsNotesAddNewNoteBtn = By.XPath("//*[@id=\"action0\"]");
        public readonly By _clickNoButtonAddCriteriaPopup = By.XPath("/html/body/app-home/div/div/div[2]/app-package/app-package-detail/kendo-dialog/div[2]/kendo-dialog-actions/button[2]");
        public readonly By _startDate = By.XPath("/html/body/app-home/div/div/div[2]/app-package/app-package-detail/section[2]/div/div/div/div[2]/div[1]/div[2]/div[2]/div[1]/div/kendo-datepicker/span/kendo-dateinput/span/input");
        public readonly By _endDate = By.XPath("/html/body/app-home/div/div/div[2]/app-package/app-package-detail/section[2]/div/div/div/div[2]/div[1]/div[2]/div[2]/div[2]/div/kendo-datepicker/span/kendo-dateinput/span/input");
        public readonly By _firstRowAgreementTab = By.XPath("//*[@id=\"gridAgreement\"]/div/div[2]/kendo-grid/div/kendo-grid-list/div/div[1]/table/tbody/tr/td[5]");
        public readonly By FirstRowDescription = By.XPath("/html/body/app-home/div/div/div[2]/app-package/app-package-detail/section[2]/div/div/div/div[2]/div[2]/kendo-tabstrip/div/app-package-agreement/div/div[2]/base-grid/div/div[2]/kendo-grid/div/kendo-grid-list/div/div[1]/table/tbody/tr/td[5]");
        public readonly By IsPopupCriteriaAppeared = By.XPath("/html/body/app-home/div/div/div[2]/app-package/app-package-detail/kendo-dialog/div[2]");


        private PackageEditorScreenPageObject Waiter(int seconds, By element)
        {
            var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(seconds));
            try
            {
                wait.Until(d => d.FindElements(element).FirstOrDefault());
                return new PackageEditorScreenPageObject(_webDriver);
            }
            catch
            {
                var neededElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
                return new PackageEditorScreenPageObject(_webDriver);
            }
        }

        public PackageEditorScreenPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public PackageEditorScreenPageObject ClickBreadCrumbsHomeBtn()
        {
            _webDriver.FindElement(_BreadCrumbsHomeBtn).Click();
            return new PackageEditorScreenPageObject(_webDriver);
        }
        public PackageEditorScreenPageObject ClickBreadCrumbPackageBtn()
        {
            _webDriver.FindElement(_BreadCrumbPackageBtn).Click();
            return new PackageEditorScreenPageObject(_webDriver);
        }
        public PackageEditorScreenPageObject ClickEditPackageBtn()
        {
            _webDriver.FindElement(_editPackageBtn).Click();
            return new PackageEditorScreenPageObject(_webDriver);
        }
        public PackageEditorScreenPageObject ClickTabsAgreements()
        {
           _webDriver.FindElement(_tabsAgreements).Click();
           return new PackageEditorScreenPageObject(_webDriver);
        }
        public PackageEditorScreenPageObject ClickTabsAgreementsSearchInput()
        {
            _webDriver.FindElement(_tabsAgreementsSearchInput).Click();
            return new PackageEditorScreenPageObject(_webDriver);
        }
        public PackageEditorScreenPageObject ClickTabsAgreementsAddNewBtn()
        {
            try
            {
                _webDriver.FindElement(_tabsAgreementsAddNewBtnIfNoAgreementsExists).Click();
            }
            catch
            {
                _webDriver.FindElement(_tabsAgreementsAddNewBtnIfAlreadyExistAnyAgreements).Click();
            }
            return new PackageEditorScreenPageObject(_webDriver);
        }
        public PackageEditorScreenPageObject ClickTabsAgreementsChooseFirstRow()
        {
            _webDriver.FindElement(_tabsAgreementsChooseFirstRow).Click();
            return new PackageEditorScreenPageObject(_webDriver);
        }
        public PackageEditorScreenPageObject ClickTabsAgreementsOrderById()
        {
            _webDriver.FindElement(_tabsAgreementsOrderById).Click();
            return new PackageEditorScreenPageObject(_webDriver);
        }
        public PackageEditorScreenPageObject ClickTabsAgreementsOpenRebatesDropDownOfFirstRow()
        {
            _webDriver.FindElement(_tabsAgreementsOpenRebatesDropDownOfFirstRow).Click();
            return new PackageEditorScreenPageObject(_webDriver);
        }
        public PackageEditorScreenPageObject ClickTabsAgreementsRebatesDropDownOfFirstRowChooseFirstRebate()
        {
            _webDriver.FindElement(_tabsAgreementsRebatesDropDownOfFirstRowChooseFirstRebate).Click();
            return new PackageEditorScreenPageObject(_webDriver);
        }
        public PackageEditorScreenPageObject ClickTabsAgreementsActionEdit()
        {
            _webDriver.FindElement(_tabsAgreementsActionEdit).Click();
            return new PackageEditorScreenPageObject(_webDriver);
        }
        public PackageEditorScreenPageObject ClickTabsAgreementsActionView()
        {
            _webDriver.FindElement(_tabsAgreementsActionView).Click();
            return new PackageEditorScreenPageObject(_webDriver);
        }
        public PackageEditorScreenPageObject ClickTabsAgreementsActionCopy()
        {
            _webDriver.FindElement(_tabsAgreementsActionCopy).Click();
            return new PackageEditorScreenPageObject(_webDriver);
        }
        public PackageEditorScreenPageObject ClickTabsAgreementsActionDelete()
        {
            _webDriver.FindElement(_tabsAgreementsActionDelete).Click();
            return new PackageEditorScreenPageObject(_webDriver);
        }
        public PackageEditorScreenPageObject ClickTabsCriteria()
        {
            _webDriver.FindElement(_tabsCriteria).Click();
            return new PackageEditorScreenPageObject(_webDriver);
        }
        public PackageEditorScreenPageObject ClickTabsCriteriaCompany()
        {
            _webDriver.FindElement(_tabsCriteriaCompany).Click();
            return new PackageEditorScreenPageObject(_webDriver);
        }
        public PackageEditorScreenPageObject ClickTabsCriteriaProduct()
        {
            _webDriver.FindElement(_tabsCriteriaProduct).Click();
            return new PackageEditorScreenPageObject(_webDriver);
        }
        public PackageEditorScreenPageObject ClickTabsCriteriaPrject()
        {
            _webDriver.FindElement(_tabsCriteriaPrject).Click();
            return new PackageEditorScreenPageObject(_webDriver);
        }
        public PackageEditorScreenPageObject ClickTabsCriteriaAddNewBtnPlusSign()
        {
            _webDriver.FindElement(_tabsCriteriaAddNewBtnPlusSign).Click();
            return new PackageEditorScreenPageObject(_webDriver);
        }
        public PackageEditorScreenPageObject ClickTabsCriteriaDeleteBtn()
        {
            _webDriver.FindElement(_tabsCriteriaDeleteBtn).Click();
            return new PackageEditorScreenPageObject(_webDriver);
        }
        public PackageEditorScreenPageObject ClickTabsDocuments()
        {
            _webDriver.FindElement(_tabsDocuments).Click();
            return new PackageEditorScreenPageObject(_webDriver);
        }
        public PackageEditorScreenPageObject ClickTabsDocumentsGenerateTradeAgreementBtns()
        {
            _webDriver.FindElement(_tabsDocumentsGenerateTradeAgreementBtn).Click();
            return new PackageEditorScreenPageObject(_webDriver);
        }
        public PackageEditorScreenPageObject ClickTabsDocumentsUploadtNewDocumentBtn()
        {
            _webDriver.FindElement(_tabsDocumentsUploadtNewDocumentBtn).Click();
            return new PackageEditorScreenPageObject(_webDriver);
        }
        public PackageEditorScreenPageObject ClickTabsDocumentsDeleteDocumentBtn()
        {
            _webDriver.FindElement(_tabsDocumentsDeleteDocumentBtn).Click();
            return new PackageEditorScreenPageObject(_webDriver);
        }
        public PackageEditorScreenPageObject ClickTabsNotes()
        {
            _webDriver.FindElement(_tabsNotes).Click();
            return new PackageEditorScreenPageObject(_webDriver);
        }
        public PackageEditorScreenPageObject ClickTabsAudit()
        {
            _webDriver.FindElement(_tabsAudit).Click();
            return new PackageEditorScreenPageObject(_webDriver);
        }
        public PackageEditorScreenPageObject ClickTabsNotesAddNewNoteBtn()
        {
            _webDriver.FindElement(_tabsNotesAddNewNoteBtn).Click();
            return new PackageEditorScreenPageObject(_webDriver);
        }

        public PackageEditorScreenPageObject ClickNoButtonAddCriteria()
        {
            _webDriver.FindElement(_clickNoButtonAddCriteriaPopup).Click();
            return new PackageEditorScreenPageObject(_webDriver);
        }

        public bool IfCriteriaPopupAppeared()
        {
            try
            {
                return _webDriver.FindElement(IsPopupCriteriaAppeared).Displayed;
            }
            catch (NoSuchElementException e)
            {
                return false;
            }
        }

        public bool IsFirstRowAppeared()
        {
            if (_webDriver.FindElement(_firstRowAgreementTab).Displayed == true)
            {
                return true;
            }
            else return false;
        }

        public bool IsPackageScreenOpened()
        {
            if (_webDriver.FindElement(_editPackageBtn).Displayed)
            {
                return true;
            }
            else return false;
        }

        public string GetStartDateOfParentPackage()
        {
            string startDateBefore = _webDriver.FindElement(_startDate).GetAttribute("aria-valuetext");
            var startDateAfter = startDateBefore;
            startDateAfter = new string((from c in startDateAfter
                                         where char.IsWhiteSpace(c) || char.IsLetterOrDigit(c)
                                         select c
                   ).ToArray());
            return startDateAfter;
        }
        public string GetEndDateOfParentPackage()
        {
            string endDateBefore = _webDriver.FindElement(_endDate).GetAttribute("aria-valuetext");
            var endDateAfter = endDateBefore;
            endDateAfter = new string((from c in endDateAfter
                                       where char.IsWhiteSpace(c) || char.IsLetterOrDigit(c)
                                       select c
                   ).ToArray());
            return endDateAfter;
        }

        public PackageEditorScreenPageObject FindDescriptionUsingSearchInput(string description)
        {
            Actions actions = new Actions(_webDriver);
            _webDriver.FindElement(_tabsAgreementsSearchInput).Click();
            actions.SendKeys(description).Perform();
            return new PackageEditorScreenPageObject(_webDriver);
        }

        public PackageEditorScreenPageObject ChooseDocumentFile()
        {            
            IWebElement fileInput = _webDriver.FindElement(_tabsDocumentsAddDocumentPopupChooseFileButton);
            fileInput.SendKeys("C:/Users/ovly/Downloads/docForTestDoNotDelete.pdf");
            return new PackageEditorScreenPageObject(_webDriver);
        }
        public string AddDocumentPopupSetDescription(string description)
        {
            Actions actions = new Actions(_webDriver);
            _webDriver.FindElement(_tabsDocumentsAddDocumentPopupDescriptionInput).Click();
            Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            string result = description + $" {unixTimestamp}";
            actions.SendKeys(result).Perform();
            return result;
        }
        public PackageEditorScreenPageObject AddDocumentPopupClickUploadButton()
        {
            _webDriver.FindElement(_tabsDocumentsAddDocumentPopupUploadButton).Click();
            return new PackageEditorScreenPageObject(_webDriver);
        }

        public string IfDocumentAdded()
        {
            Waiter(10, _tabsDocumentsCheckIfDocumentAdded);
            _webDriver.FindElement(_tabsDocumentsOrderByDescription).Click();
            Thread.Sleep(1000);
            Waiter(10, _tabsDocumentsCheckIfDocumentAdded);
            _webDriver.FindElement(_tabsDocumentsOrderByDescription).Click();
            Thread.Sleep(1000);
            Waiter(10, _tabsDocumentsCheckIfDocumentAdded);
            string actualResult = _webDriver.FindElement(_tabsDocumentsCheckIfDocumentAdded).Text;
            return actualResult;
        }
    }
}
