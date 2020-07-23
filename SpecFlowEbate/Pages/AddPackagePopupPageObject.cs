using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using System.Threading;

namespace SpecFlowTest
{
    class AddPackagePopupPageObject
    {
        
        private IWebDriver _webDriver;
        readonly Random rnd = new Random();
        private string expectedResult;


        public readonly By _CustomerType = By.XPath("/html/body/app-home/div/div/div[2]/app-package/app-package/app-package-dialog/kendo-dialog/div[2]/div/form/div/div/app-company-selection/form/div[1]/div/div/div/fieldset/label[1]");
        public readonly By _SupplierType = By.XPath("/html/body/app-home/div/div/div[2]/app-package/app-package/app-package-dialog/kendo-dialog/div[2]/div/form/div/div/app-company-selection/form/div[1]/div/div/div/fieldset/label[2]");
        public readonly By _DistributorType = By.XPath("/html/body/app-home/div/div/div[2]/app-package/app-package/app-package-dialog/kendo-dialog/div[2]/div/form/div/div/app-company-selection/form/div[1]/div/div/div/fieldset/label[3]");
        public readonly By _ChannelType = By.XPath("/html/body/app-home/div/div/div[2]/app-package/app-package/app-package-dialog/kendo-dialog/div[2]/div/form/div/div/app-company-selection/form/div[1]/div/div/div/fieldset/label[4]");
        public readonly By _SingleCompany = By.XPath("/html/body/app-home/div/div/div[2]/app-package/app-package/app-package-dialog/kendo-dialog/div[2]/div/form/div/div/app-company-selection/form/div[2]/div/div/fieldset/div[1]/label[1]]");
        public readonly By _SingleCompanyAccountTypeDropDown = By.XPath("//*[@id=\"companySelectionAccountType\"]");
        public readonly By _AllCompanies = By.XPath("/html/body/app-home/div/div/div[2]/app-package/app-package/app-package-dialog/kendo-dialog/div[2]/div/form/div/div/app-company-selection/form/div[2]/div/div/fieldset/div[1]/label[2]");
        public readonly By _periodInput = By.XPath("//*[@id=\"period\"]");
        public readonly By _startDate = By.XPath("//*[@id=\"periodStart\"]/span");
        public readonly By _endDate = By.XPath("//*[@id=\"periodEnd\"]/span");
        public readonly By _description = By.Id("description");
        public readonly By _budget = By.XPath("/html/body/app-home/div/div/div[2]/app-package/app-package/app-package-dialog/kendo-dialog/div[2]/div/form/div/div/div[4]/div[1]/div/kendo-numerictextbox/span");
        public readonly By _target = By.XPath("/html/body/app-home/div/div/div[2]/app-package/app-package/app-package-dialog/kendo-dialog/div[2]/div/form/div/div/div[4]/div[2]/div/kendo-numerictextbox/span");
        public readonly By _comments = By.XPath("//*[@id=\"comments\"]");
        public readonly By _saveBtn = By.XPath("/html/body/app-home/div/div/div[2]/app-package/app-package/app-package-dialog/kendo-dialog/div[2]/kendo-dialog-actions/button[1]");
        public readonly By _cancelBtn = By.XPath("/html/body/app-home/div/div/div[2]/app-package/app-package/app-package-dialog/kendo-dialog/div[2]/kendo-dialog-actions/button[2]");
        public readonly By _accountTypeDropDown = By.XPath("//*[@id=\"companySelectionAccountType\"]");
        public readonly By _companyNameDropDown = By.XPath("//*[@id=\"companiesSearch\"]/span/kendo-searchbar");
        public readonly By _setChosenCompany = By.XPath("//*[@id=\"csButtons\"]/button[1]");
        public readonly By _actualResult = By.XPath("//*[@id=\"gridPackageOverview\"]/div/div[2]/kendo-grid/div/kendo-grid-list/div/div[1]/table/tbody/tr[1]/td[6]");


        public AddPackagePopupPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public AddPackagePopupPageObject ClickCustomerType()
        {
            _webDriver.FindElement(_CustomerType).Click();
            return new AddPackagePopupPageObject(_webDriver);
        }
        public AddPackagePopupPageObject ClickSupplierType()
        {
            _webDriver.FindElement(_SupplierType).Click();
            return new AddPackagePopupPageObject(_webDriver);
        }
        public AddPackagePopupPageObject ClickDistributorType()
        {
            _webDriver.FindElement(_DistributorType).Click();
            return new AddPackagePopupPageObject(_webDriver);
        }
        public AddPackagePopupPageObject ClickChannelType()
        {
            _webDriver.FindElement(_ChannelType).Click();
            return new AddPackagePopupPageObject(_webDriver);
        }
        public AddPackagePopupPageObject ClickCompanySelection()
        {
            _webDriver.FindElement(_SingleCompany).Click();
            return new AddPackagePopupPageObject(_webDriver);
        }
        public AddPackagePopupPageObject ClickSingleCompanyAccountTypeDropDown()
        {
            _webDriver.FindElement(_SingleCompanyAccountTypeDropDown).Click();
            return new AddPackagePopupPageObject(_webDriver);
        }
        public AddPackagePopupPageObject ClickAllCompanies()
        {
            _webDriver.FindElement(_AllCompanies).Click();
            return new AddPackagePopupPageObject(_webDriver);
        }
        
        public AddPackagePopupPageObject SetPeriodAnnual()
        {
            Actions actions = new Actions(_webDriver);
            _webDriver.FindElement(_periodInput).Click();
            _webDriver.FindElement(By.XPath("//ul/li[text() = 'Annual']")).Click();
            return new AddPackagePopupPageObject(_webDriver);
        }
        public AddPackagePopupPageObject SetPeriodQuarterly()
        {
            Actions actions = new Actions(_webDriver);
            _webDriver.FindElement(_periodInput).Click();
            _webDriver.FindElement(By.XPath("//ul/li[text() = 'Quarterly']")).Click();
            return new AddPackagePopupPageObject(_webDriver);
        }
        public AddPackagePopupPageObject SetPeriodBiAnnual()
        {
            Actions actions = new Actions(_webDriver);
            _webDriver.FindElement(_periodInput).Click();
            _webDriver.FindElement(By.XPath("//ul/li[text() = 'Bi-Annual']")).Click();
            return new AddPackagePopupPageObject(_webDriver);
        }
        public AddPackagePopupPageObject SetPeriodCampaign()
        {
            Actions actions = new Actions(_webDriver);
            _webDriver.FindElement(_periodInput).Click();
            _webDriver.FindElement(By.XPath("//ul/li[text() = 'Campaign']")).Click();
            return new AddPackagePopupPageObject(_webDriver);
        }
        public AddPackagePopupPageObject SetPeriodMultiYear()
        {
            Actions actions = new Actions(_webDriver);
            _webDriver.FindElement(_periodInput).Click();
            _webDriver.FindElement(By.XPath("//ul/li[text() = 'Multi-Year']")).Click();
            return new AddPackagePopupPageObject(_webDriver);
        }
        public AddPackagePopupPageObject SetPeriodOngoing()
        {
            Actions actions = new Actions(_webDriver);
            _webDriver.FindElement(_periodInput).Click();
            _webDriver.FindElement(By.XPath("//ul/li[text() = 'Ongoing']")).Click();
            return new AddPackagePopupPageObject(_webDriver);
        }

        public string StartDateGenerator()
        {
            int int0to9 = rnd.Next(0, 9);
            string startDate = "0101200" + int0to9;
            return startDate;
        }

        public string EndDateGenerator()
        {
            int intFirst = rnd.Next(1, 9);
            int intSecond = rnd.Next(0, 9);
            string endDate = "010120" + intFirst + intSecond;
            return endDate;
        }

        public AddPackagePopupPageObject SetStartDate()
        {
            Actions actions = new Actions(_webDriver);
            _webDriver.FindElement(_startDate).Click();
            actions.SendKeys(Keys.Home).Perform();
            actions.SendKeys(StartDateGenerator()).Perform();
            return new AddPackagePopupPageObject(_webDriver);
        }
        public AddPackagePopupPageObject SetEndDate()
        {
            Actions actions = new Actions(_webDriver);
            _webDriver.FindElement(_endDate).Click();
            actions.SendKeys(Keys.Home).Perform();
            actions.SendKeys(EndDateGenerator()).Perform();
            return new AddPackagePopupPageObject(_webDriver);
        }
        public AddPackagePopupPageObject SetDescription(string description)
        {
            Actions actions = new Actions(_webDriver);
            _webDriver.FindElement(_description).Click();
            actions.SendKeys(description).Perform();
            return new AddPackagePopupPageObject(_webDriver);
        }
        public AddPackagePopupPageObject SetBudget()
        {
            Actions actions = new Actions(_webDriver);
            _webDriver.FindElement(_budget).Click();
            actions.SendKeys("1").Perform();
            return new AddPackagePopupPageObject(_webDriver);
        }
        public AddPackagePopupPageObject SetTarget()
        {
            Actions actions = new Actions(_webDriver);
            _webDriver.FindElement(_target).Click();
            actions.SendKeys("1").Perform();
            return new AddPackagePopupPageObject(_webDriver);
        }
        public AddPackagePopupPageObject ClickComments()
        {
            _webDriver.FindElement(_comments).Click();
            return new AddPackagePopupPageObject(_webDriver);
        }
        public AddPackagePopupPageObject ClickSaveBtn()
        {
            _webDriver.FindElement(_saveBtn).Click();
            return new AddPackagePopupPageObject(_webDriver);
        }
        public AddPackagePopupPageObject ClickCancelBtn()
        {
            _webDriver.FindElement(_cancelBtn).Click();
            return new AddPackagePopupPageObject(_webDriver);
        }

        public AddPackagePopupPageObject SetAccountTypeTradingGroup()
        {
            Actions actions = new Actions(_webDriver);
            _webDriver.FindElement(_accountTypeDropDown).Click();
            _webDriver.FindElement(By.XPath("//ul/li[text() = 'Trading Group']")).Click();
            return new AddPackagePopupPageObject(_webDriver);
        }
        public AddPackagePopupPageObject SetAccountTypeParentAccount()
        {
            Actions actions = new Actions(_webDriver);
            _webDriver.FindElement(_accountTypeDropDown).Click();
            _webDriver.FindElement(By.XPath("//ul/li[text() = 'Parent Account']")).Click();
            return new AddPackagePopupPageObject(_webDriver);
        }
        public AddPackagePopupPageObject SetAccountTypeInvoiceAccount()
        {
            Actions actions = new Actions(_webDriver);
            _webDriver.FindElement(_accountTypeDropDown).Click();
            _webDriver.FindElement(By.XPath("//ul/li[text() = 'Invoice Account']")).Click();
            return new AddPackagePopupPageObject(_webDriver);
        }
        public AddPackagePopupPageObject SetAccountTypeDeliveryAccount()
        {
            Actions actions = new Actions(_webDriver);
            _webDriver.FindElement(_accountTypeDropDown).Click();
            _webDriver.FindElement(By.XPath("//ul/li[text() = 'Delivery Account']")).Click();
            return new AddPackagePopupPageObject(_webDriver);
        }
        public AddPackagePopupPageObject SetAccountTypeDistributor()
        {
            Actions actions = new Actions(_webDriver);
            _webDriver.FindElement(_accountTypeDropDown).Click();
            _webDriver.FindElement(By.XPath("//ul/li[text() = 'Distributor']")).Click();
            return new AddPackagePopupPageObject(_webDriver);
        }
        public AddPackagePopupPageObject SetAccountTypeLandlord()
        {
            Actions actions = new Actions(_webDriver);
            _webDriver.FindElement(_accountTypeDropDown).Click();
            _webDriver.FindElement(By.XPath("//ul/li[text() = 'Landlord']")).Click();
            return new AddPackagePopupPageObject(_webDriver);
        }
        
        public AddPackagePopupPageObject SetAccountTypeMerchantDistribution()
        {
            Actions actions = new Actions(_webDriver);
            _webDriver.FindElement(_accountTypeDropDown).Click();
            _webDriver.FindElement(By.XPath("//ul/li[text() = 'Merchant Distribution']")).Click();
            return new AddPackagePopupPageObject(_webDriver);
        }
        
        public AddPackagePopupPageObject SetAccountTypeManufacturer()
        {
            Actions actions = new Actions(_webDriver);
            _webDriver.FindElement(_accountTypeDropDown).Click();
            _webDriver.FindElement(By.XPath("//ul/li[text() = 'Manufacturer']")).Click();
            return new AddPackagePopupPageObject(_webDriver);
        }
        
        public AddPackagePopupPageObject SetAccountTypeContractor()
        {
            Actions actions = new Actions(_webDriver);
            _webDriver.FindElement(_accountTypeDropDown).Click();
            _webDriver.FindElement(By.XPath("//ul/li[text() = 'Contractor']")).Click();
            return new AddPackagePopupPageObject(_webDriver);
        }

        public AddPackagePopupPageObject SetTradingGroupCompany()
        {
            Actions actions = new Actions(_webDriver);
            _webDriver.FindElement(_companyNameDropDown).Click();
            actions.SendKeys("qa").Perform();
            _webDriver.FindElement(By.XPath("//ul/li[text() = '(NGBGB000004) qa_trad#3']")).Click();
            _webDriver.FindElement(_setChosenCompany).Click();
            return new AddPackagePopupPageObject(_webDriver);
        }

        public AddPackagePopupPageObject SetParentAccountCompany()
        {
            Actions actions = new Actions(_webDriver);
            _webDriver.FindElement(_companyNameDropDown).Click();
            actions.SendKeys("pa").Perform();
            _webDriver.FindElement(By.XPath("//ul/li[text() = '(NGBUK000010) Parent Account type']")).Click();
            _webDriver.FindElement(_setChosenCompany).Click();
            return new AddPackagePopupPageObject(_webDriver);
        }
        public AddPackagePopupPageObject SetInvoiceAccountCompany()
        {
            Actions actions = new Actions(_webDriver);
            _webDriver.FindElement(_companyNameDropDown).Click();
            actions.SendKeys("art").Perform();
            _webDriver.FindElement(By.XPath("//ul/li[text() = '(NGBUnited Kingdom000014) Artem Inc.']")).Click();
            _webDriver.FindElement(_setChosenCompany).Click();
            return new AddPackagePopupPageObject(_webDriver);
        }

        public AddPackagePopupPageObject SetInvoiceAccountRandomCompany()
        {
            Actions actions = new Actions(_webDriver);
            _webDriver.FindElement(_companyNameDropDown).Click();
            actions.SendKeys(Keys.Space + Keys.Space).Perform();
            Thread.Sleep(1000);
            int intFirst = rnd.Next(1, 20);
            
            //TO DO

            for (int i = 0; i <= intFirst; i++)
            {
                actions.SendKeys(Keys.ArrowDown).Perform();
            }
            actions.SendKeys(Keys.Enter).Perform();
            _webDriver.FindElement(_setChosenCompany).Click();
            return new AddPackagePopupPageObject(_webDriver);
        }

        public AddPackagePopupPageObject SetDeliveryAccountCompany()
        {
            Actions actions = new Actions(_webDriver);
            _webDriver.FindElement(_companyNameDropDown).Click();
            actions.SendKeys("del").Perform();
            _webDriver.FindElement(By.XPath("//ul/li[text() = '(NGBUnited Kingdom000011) Delivery Account']")).Click();
            _webDriver.FindElement(_setChosenCompany).Click();
            return new AddPackagePopupPageObject(_webDriver);
        }
        public AddPackagePopupPageObject SetDistributorCompany()
        {
            Actions actions = new Actions(_webDriver);
            _webDriver.FindElement(_companyNameDropDown).Click();
            actions.SendKeys("dis").Perform();
            _webDriver.FindElement(By.XPath("//ul/li[text() = '(NGBUnited Kingdom000015) Distributor']")).Click();
            _webDriver.FindElement(_setChosenCompany).Click();
            return new AddPackagePopupPageObject(_webDriver);
        }
        public AddPackagePopupPageObject SetLandlordCompany()
        {
            Actions actions = new Actions(_webDriver);
            _webDriver.FindElement(_companyNameDropDown).Click();
            actions.SendKeys("land").Perform();
            _webDriver.FindElement(By.XPath("//ul/li[text() = '(NGBUnited Kingdom000016) Landlord']")).Click();
            _webDriver.FindElement(_setChosenCompany).Click();
            return new AddPackagePopupPageObject(_webDriver);
        }
        public AddPackagePopupPageObject SetMerchantDistributionCompany()
        {
            Actions actions = new Actions(_webDriver);
            _webDriver.FindElement(_companyNameDropDown).Click();
            actions.SendKeys("merch").Perform();
            _webDriver.FindElement(By.XPath("//ul/li[text() = '(NGBUnited Kingdom000017) Merchant Distribution']")).Click();
            _webDriver.FindElement(_setChosenCompany).Click();
            return new AddPackagePopupPageObject(_webDriver);
        }
        public AddPackagePopupPageObject SetManufacturerCompany()
        {
            Actions actions = new Actions(_webDriver);
            _webDriver.FindElement(_companyNameDropDown).Click();
            actions.SendKeys("man").Perform();
            _webDriver.FindElement(By.XPath("//ul/li[text() = '(NGBUnited Kingdom000018) Manufacturer']")).Click();
            _webDriver.FindElement(_setChosenCompany).Click();
            return new AddPackagePopupPageObject(_webDriver);
        }
        public AddPackagePopupPageObject SetContractorCompany()
        {
            Actions actions = new Actions(_webDriver);
            _webDriver.FindElement(_companyNameDropDown).Click();
            actions.SendKeys("cont").Perform();
            _webDriver.FindElement(By.XPath("//ul/li[text() = '(NGBUnited Kingdom000019) Contractor']")).Click();
            _webDriver.FindElement(_setChosenCompany).Click();
            return new AddPackagePopupPageObject(_webDriver);
        }

        public AddPackagePopupPageObject getActualResult()
        {
            _webDriver.FindElement(_actualResult);
            return new AddPackagePopupPageObject(_webDriver);
        }

        public bool WaitUntillCopyPopupOpened()
        {
            var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            try
            {
                wait.Until(d => d.FindElements(By.XPath("/html/body/app-home/div/div/div[2]/app-package/app-package/app-package-dialog/kendo-dialog/div[2]")).FirstOrDefault());
                return true;
            }
            catch { return false; }
        }

        public string getDescription()
        {
            expectedResult = _webDriver.FindElement(_description).GetAttribute("value");
            return expectedResult;
        }
        public AddPackagePopupPageObject SetStartDateForCopiedPackage()
        {
            Actions actions = new Actions(_webDriver);           
            _webDriver.FindElement(_startDate).Click();
            int intFirst = rnd.Next(0, 2);
            int intSecond = rnd.Next(2, 9);

            actions.SendKeys("20" + intFirst + intSecond).Perform();

            //string startDateBefore = _webDriver.FindElement(_startDate).GetAttribute("aria-valuetext");
            //var startDateAfter = startDateBefore;
            //startDateAfter = new string((from c in startDateAfter
            //                             where char.IsWhiteSpace(c) || char.IsLetterOrDigit(c)
            //                             select c
            //       ).ToArray());
            //int startydDateInt = int.Parse(startDateAfter);
            //return startydDateInt+1;
            return new AddPackagePopupPageObject(_webDriver);
        }

    }
}
