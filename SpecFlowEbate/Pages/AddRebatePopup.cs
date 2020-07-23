using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using System.Threading;

namespace SpecFlowTest
{
    class AddRebatePopup
    {
        private readonly IWebDriver _webDriver;

        public readonly By CalculationTypeDropDown = By.Id("calculationType");
        public readonly By CalculateAgainstDropDown = By.Id("priceTypeId");
        public readonly By InternalDescriptionInput = By.Id("internalDescription");
        public readonly By CategoryDropDown = By.Id("rebateCategory");
        public readonly By Budget = By.XPath("/html/body/app-home/div/div/div[2]/app-agreement/app-agreement-detail/section[2]/div/div/div/div[2]/div[2]/kendo-tabstrip/div/app-agreement-rebates/app-agreement-detail-rebate-dialog/kendo-dialog/div[2]/div/form/div/div/div[8]/div[1]/div/kendo-numerictextbox/span");
        public readonly By Target = By.XPath("/html/body/app-home/div/div/div[2]/app-agreement/app-agreement-detail/section[2]/div/div/div/div[2]/div[2]/kendo-tabstrip/div/app-agreement-rebates/app-agreement-detail-rebate-dialog/kendo-dialog/div[2]/div/form/div/div/div[8]/div[2]/div/kendo-numerictextbox/span");
        public readonly By PaymentFrequencyDropDown = By.Id("paymentFrequency");
        public readonly By CurrencyDropDown = By.XPath("/html/body/app-home/div/div/div[2]/app-agreement/app-agreement-detail/section[2]/div/div/div/div[2]/div[2]/kendo-tabstrip/div/app-agreement-rebates/app-agreement-detail-rebate-dialog/kendo-dialog/div[2]/div/form/div/div/div[10]/div[2]/div/kendo-dropdownlist");
        public readonly By SaveButton = By.Id("save");
        public readonly By CancelButton = By.Id("cancel");
        public readonly By TitleOfOpenedPopup = By.Id("kendo-dialog-title-145552");
        public readonly By SecondRatesPopupUnitOfMeasureDropDown = By.Id("ddlUOM");
        public readonly By SecondRatesPopupRateInputPercentage = By.Id("numRateValue");
        public readonly By SecondRatesPopupEffectiveFromInput = By.Id("dtEffectiveFrom");
        public readonly By SecondRatesPopupRemoveRateButton = By.Id("btnRemoveRate");
        public readonly By SecondRatesPopupAddRateButton = By.Id("btnAddRate");
        public readonly By SecondRatesPopupRateInputPercentage2 = By.Id("numRatePercentage");
        public readonly By SecondRatesPopupScaleInput = By.Id("numScale");
        public readonly By SecondRatesPopupRateInputPercentage3 = By.Id("numValue");
        public readonly By SecondRatesPopupGrowthPercentageInput = By.Id("numScale");
        public readonly By SecondRatesPopupTierPercentageInput = By.Id("numScale");
        public readonly By SecondRatesPopupRebateInput = By.Id("numValue");
        public readonly By CompanyInputInactive = By.Id("companyName");
        readonly Random rnd = new Random();


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

        public AddRebatePopup(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public AddRebatePopup SetBudget()
        {
            Actions actions = new Actions(_webDriver);
            _webDriver.FindElement(Budget).Click();
            actions.SendKeys("1" + Keys.Enter).Perform();
            return new AddRebatePopup(_webDriver);
        }
        public AddRebatePopup SetDescription(string description)
        {
            Actions actions = new Actions(_webDriver);
            _webDriver.FindElement(InternalDescriptionInput).Click();
            actions.SendKeys(description).Perform();
            return new AddRebatePopup(_webDriver);
        }

        public AddRebatePopup SetTarget()
        {
            Actions actions = new Actions(_webDriver);
            _webDriver.FindElement(Target).Click();
            actions.SendKeys("1" + Keys.Enter).Perform();
            return new AddRebatePopup(_webDriver);
        }

        public AddRebatePopup ClickSaveButton()
        {
            _webDriver.FindElement(SaveButton).Click();
            return new AddRebatePopup(_webDriver);
        }
        public AddRebatePopup ClickCancelButton()
        {
            _webDriver.FindElement(CancelButton).Click();
            return new AddRebatePopup(_webDriver);
        }

        public bool IsWarningAppeared()
        {
            try
            {
                return _webDriver.FindElement(TitleOfOpenedPopup).Displayed;
            }
            catch
            {
                return false;
            }
        }

        public AddRebatePopup ChooseCalculationTypeStandardValuePerUnit()
        {
            Actions actions = new Actions(_webDriver);
            _webDriver.FindElement(CalculationTypeDropDown).Click();
            _webDriver.FindElement(By.XPath("//ul/li[text() = 'Standard Value per Unit']")).Click(); // add rates popup appeared - SecondRatesPopupRateInputPercentage
            return new AddRebatePopup(_webDriver);
        }
        public AddRebatePopup ChooseCalculationTypeStandardPercOfTurnover()
        {
            Actions actions = new Actions(_webDriver);
            Waiter(15, CompanyInputInactive);
            _webDriver.FindElement(CalculationTypeDropDown).Click();
            _webDriver.FindElement(By.XPath("//ul/li[text() = 'Standard % of Turnover']")).Click(); // add rates popup appeared - SecondRatesPopupRateInputPercentage2
            return new AddRebatePopup(_webDriver);
        }
        public AddRebatePopup ChooseCalculationTypeTieredPercOfTurnoverRetro()
        {
            Actions actions = new Actions(_webDriver);
            _webDriver.FindElement(CalculationTypeDropDown).Click();
            _webDriver.FindElement(By.XPath("//ul/li[text() = 'Tiered % of Turnover (Retro)']")).Click(); // add rates popup appeared - SecondRatesPopupRateInputPercentage3
            return new AddRebatePopup(_webDriver);
        }
        public AddRebatePopup ChooseCalculationTypeTieredValuePerUnitRetro()
        {
            Actions actions = new Actions(_webDriver);
            _webDriver.FindElement(CalculationTypeDropDown).Click();
            _webDriver.FindElement(By.XPath("//ul/li[text() = 'Tiered Value per Unit (Retro)']")).Click(); // add rates popup appeared - SecondRatesPopupRateInputPercentage3
            return new AddRebatePopup(_webDriver);
        }
        public AddRebatePopup ChooseCalculationTypeGrowthPercOfTurnover()
        {
            Actions actions = new Actions(_webDriver);
            _webDriver.FindElement(CalculationTypeDropDown).Click();
            _webDriver.FindElement(By.XPath("//ul/li[text() = 'Growth (% of Turnover)']")).Click(); // add rates popup appeared - SecondRatesPopupGrowthPercentageInput
            return new AddRebatePopup(_webDriver);
        }
        public AddRebatePopup ChooseCalculationTypeGrowthValuePerUnit()
        {
            Actions actions = new Actions(_webDriver);
            _webDriver.FindElement(CalculationTypeDropDown).Click();
            _webDriver.FindElement(By.XPath("//ul/li[text() = 'Growth (Value per Unit)']")).Click(); // add rates popup appeared - done
            return new AddRebatePopup(_webDriver);
        }
        public AddRebatePopup ChooseCalculationTypeProductLevelPerc()
        {
            Actions actions = new Actions(_webDriver);
            _webDriver.FindElement(CalculationTypeDropDown).Click();
            _webDriver.FindElement(By.XPath("//ul/li[text() = 'Product Level (%)']")).Click();  // without popup
            return new AddRebatePopup(_webDriver);
        }
        public AddRebatePopup ChooseCalculationTypeTieredPercOfTurnoverNonRetro()
        {
            Actions actions = new Actions(_webDriver);
            _webDriver.FindElement(CalculationTypeDropDown).Click();
            _webDriver.FindElement(By.XPath("//ul/li[text() = 'Tiered % of Turnover (Non Retro)']")).Click();  // add rates popup appeared - done 
            return new AddRebatePopup(_webDriver);
        }
        public AddRebatePopup ChooseCalculationTypeTieredValuePerUnitNonRetro()
        {
            Actions actions = new Actions(_webDriver);
            _webDriver.FindElement(CalculationTypeDropDown).Click();
            _webDriver.FindElement(By.XPath("//ul/li[text() = 'Tiered Value per Unit (Non Retro)']")).Click();  // add rates popup appeared - done 
            return new AddRebatePopup(_webDriver);
        }
        public AddRebatePopup ChooseCalculationTypeProductLevelFOC()
        {
            Actions actions = new Actions(_webDriver);
            _webDriver.FindElement(CalculationTypeDropDown).Click();
            _webDriver.FindElement(By.XPath("//ul/li[text() = 'Product Level FOC']")).Click();  // without popup
            return new AddRebatePopup(_webDriver);
        }
        public AddRebatePopup ChooseCalculationTypeProductLevelValue()
        {
            _webDriver.FindElement(CalculationTypeDropDown).Click();
            Thread.Sleep(500);
            _webDriver.FindElement(By.XPath("//ul/li[text() = 'Product Level Value']")).Click();  // without popup
            return new AddRebatePopup(_webDriver);
        }
        public AddRebatePopup ChooseCalculationTypeProductLevelFOCTiered()
        {
            Actions actions = new Actions(_webDriver);
            _webDriver.FindElement(CalculationTypeDropDown).Click();
            _webDriver.FindElement(By.XPath("//ul/li[text() = 'Product Level FOC Tiered']")).Click();  // without popup
            return new AddRebatePopup(_webDriver);
        }
        public AddRebatePopup ChooseCalculationTypeBuyGetCheapestFree()
        {
            Actions actions = new Actions(_webDriver);
            _webDriver.FindElement(CalculationTypeDropDown).Click();
            _webDriver.FindElement(By.XPath("//ul/li[text() = 'Buy Get Cheapest Free']")).Click();  // without popup
            return new AddRebatePopup(_webDriver);
        }
        public AddRebatePopup ChooseCalculationTypeBuyXGetYFree()
        {
            Actions actions = new Actions(_webDriver);
            _webDriver.FindElement(CalculationTypeDropDown).Click();
            _webDriver.FindElement(By.XPath("//ul/li[text() = 'Buy X Get Y Free']")).Click();  // without popup
            return new AddRebatePopup(_webDriver);
        }
        public AddRebatePopup ChooseCalculationTypeTieredOneOffRebate()
        {
            _webDriver.FindElement(CalculationTypeDropDown).Click();
            Thread.Sleep(500);
            _webDriver.FindElement(By.XPath("//ul/li[text() = 'Tiered one-off Rebate']")).Click();
            return new AddRebatePopup(_webDriver);
        }
        public AddRebatePopup ChooseCalculationTypeFee()
        {
            Actions actions = new Actions(_webDriver);
            _webDriver.FindElement(CalculationTypeDropDown).Click();
            _webDriver.FindElement(By.XPath("//ul/li[text() = 'Fee']")).Click();  // add rates popup appeared - done 
            return new AddRebatePopup(_webDriver);
        }

        public void ChooseCalculationType(RebateTypes name)
        {
            switch (name)
            {
                case RebateTypes.StandardValuePerUnit:
                    ChooseCalculationTypeStandardValuePerUnit();
                    break;
                case RebateTypes.StandardPercOfTurnover:
                    ChooseCalculationTypeStandardPercOfTurnover();
                    break;
                case RebateTypes.TieredPercOfTurnoverRetro:
                    ChooseCalculationTypeTieredPercOfTurnoverRetro();
                    break;
                case RebateTypes.TieredValuePerUnitRetro:
                    ChooseCalculationTypeTieredValuePerUnitRetro();
                    break;
                case RebateTypes.GrowthPercOfTurnover:
                    ChooseCalculationTypeGrowthPercOfTurnover();
                    break;
                case RebateTypes.GrowthValuePerUnit:
                    ChooseCalculationTypeGrowthValuePerUnit();
                    break;
                case RebateTypes.ProductLevelPerc:
                    ChooseCalculationTypeProductLevelPerc();
                    break;
                case RebateTypes.TieredPercOfTurnoverNonRetro:
                    ChooseCalculationTypeTieredPercOfTurnoverNonRetro();
                    break;
                case RebateTypes.TieredValuePerUnitNonRetro:
                    ChooseCalculationTypeTieredValuePerUnitNonRetro();
                    break;
                case RebateTypes.ProductLevelFOC:
                    ChooseCalculationTypeProductLevelFOC();
                    break;
                case RebateTypes.ProductLevelValue:
                    ChooseCalculationTypeProductLevelValue();
                    break;
                case RebateTypes.ProductLevelFOCTiered:
                    ChooseCalculationTypeProductLevelFOCTiered();
                    break;
                case RebateTypes.BuyGetCheapestFree:
                    ChooseCalculationTypeBuyGetCheapestFree();
                    break;
                case RebateTypes.BuyXGetYFree:
                    ChooseCalculationTypeBuyXGetYFree();
                    break;
                case RebateTypes.Fee:
                    ChooseCalculationTypeFee();
                    break;
                case RebateTypes.TieredOneOffRebate:
                    ChooseCalculationTypeTieredOneOffRebate();
                    break;
            }
        }

        public enum RebateTypes
        {
            StandardValuePerUnit,
            StandardPercOfTurnover,
            TieredPercOfTurnoverRetro,
            TieredValuePerUnitRetro,
            GrowthPercOfTurnover,
            GrowthValuePerUnit,
            ProductLevelPerc,
            TieredPercOfTurnoverNonRetro,
            TieredValuePerUnitNonRetro,
            ProductLevelFOC,
            ProductLevelValue,
            ProductLevelFOCTiered,
            BuyGetCheapestFree,
            BuyXGetYFree,
            Fee,
            TieredOneOffRebate
        }



        public AddRebatePopup ChooseCalculateAgainstInvoicePrice()
        {
            _webDriver.FindElement(CalculateAgainstDropDown).Click();
            Thread.Sleep(500);
            string invoicePrice = "//ul/li[text() = 'Invoice price']";
            Waiter(15, By.XPath(invoicePrice));
            _webDriver.FindElement(By.XPath(invoicePrice)).Click();
            return new AddRebatePopup(_webDriver);
        }

        public AddRebatePopup ChooseCalculateAgainstNettPrice()
        {
            Actions actions = new Actions(_webDriver);
            _webDriver.FindElement(CalculateAgainstDropDown).Click();
            _webDriver.FindElement(By.XPath("//ul/li[text() = 'Nett Price']")).Click();
            return new AddRebatePopup(_webDriver);
        }
        public AddRebatePopup ChooseCategory()
        {
            Actions actions = new Actions(_webDriver);
            _webDriver.FindElement(CategoryDropDown).Click();
            _webDriver.FindElement(By.XPath("//ul/li[text() = 'QA_Category']")).Click();
            return new AddRebatePopup(_webDriver);
        }

        public AddRebatePopup ChoosePaymentFrequencyAnnual()
        {
            Actions actions = new Actions(_webDriver);
            _webDriver.FindElement(PaymentFrequencyDropDown).Click();
            _webDriver.FindElement(By.XPath("//ul/li[text() = 'Annual']")).Click();
            return new AddRebatePopup(_webDriver);
        }
        public AddRebatePopup ChoosePaymentFrequencyQuarterly()
        {
            Actions actions = new Actions(_webDriver);
            _webDriver.FindElement(PaymentFrequencyDropDown).Click();
            _webDriver.FindElement(By.XPath("//ul/li[text() = 'Quarterly']")).Click();
            return new AddRebatePopup(_webDriver);
        }

        public AddRebatePopup ChoosePaymentFrequencyBiAnnual()
        {
            Actions actions = new Actions(_webDriver);
            _webDriver.FindElement(PaymentFrequencyDropDown).Click();
            _webDriver.FindElement(By.XPath("//ul/li[text() = 'Bi-Annual']")).Click();
            return new AddRebatePopup(_webDriver);
        }

        public AddRebatePopup ChoosePaymentFrequencyCampaign()
        {
            Actions actions = new Actions(_webDriver);
            _webDriver.FindElement(PaymentFrequencyDropDown).Click();
            _webDriver.FindElement(By.XPath("//ul/li[text() = 'Campaign']")).Click();
            return new AddRebatePopup(_webDriver);
        }
        public AddRebatePopup ChoosePaymentMultiYear()
        {
            Actions actions = new Actions(_webDriver);
            _webDriver.FindElement(PaymentFrequencyDropDown).Click();
            _webDriver.FindElement(By.XPath("//ul/li[text() = 'Multi-Year']")).Click();
            return new AddRebatePopup(_webDriver);
        }

        public AddRebatePopup ChoosePaymentFrequencyOngoing()
        {
            Actions actions = new Actions(_webDriver);
            _webDriver.FindElement(PaymentFrequencyDropDown).Click();
            _webDriver.FindElement(By.XPath("//ul/li[text() = 'Ongoing']")).Click();
            return new AddRebatePopup(_webDriver);
        }
        public AddRebatePopup ChooseCurrencyPoundSterling()
        {
            Actions actions = new Actions(_webDriver);
            _webDriver.FindElement(CurrencyDropDown).Click();
            _webDriver.FindElement(By.XPath("//ul/li[text() = 'Pound Sterling']")).Click();
            return new AddRebatePopup(_webDriver);
        }

        public AddRebatePopup ChooseUOMItem()
        {
            Actions actions = new Actions(_webDriver);
            _webDriver.FindElement(SecondRatesPopupUnitOfMeasureDropDown).Click();
            _webDriver.FindElement(By.XPath("//ul/li[text() = 'Item']")).Click();
            return new AddRebatePopup(_webDriver);
        }
        public AddRebatePopup ChooseUOMTonne()
        {
            Actions actions = new Actions(_webDriver);
            _webDriver.FindElement(SecondRatesPopupUnitOfMeasureDropDown).Click();
            _webDriver.FindElement(By.XPath("//ul/li[text() = 'Tonne']")).Click();
            return new AddRebatePopup(_webDriver);
        }
        public AddRebatePopup ChooseUOMEach()
        {
            Actions actions = new Actions(_webDriver);
            _webDriver.FindElement(SecondRatesPopupUnitOfMeasureDropDown).Click();
            _webDriver.FindElement(By.XPath("//ul/li[text() = 'Each']")).Click();
            return new AddRebatePopup(_webDriver);
        }
        public AddRebatePopup ChooseUOMMetre()
        {
            Actions actions = new Actions(_webDriver);
            _webDriver.FindElement(SecondRatesPopupUnitOfMeasureDropDown).Click();
            _webDriver.FindElement(By.XPath("//ul/li[text() = 'Metre']")).Click();
            return new AddRebatePopup(_webDriver);
        }
        public AddRebatePopup ChooseUOMMass()
        {
            Actions actions = new Actions(_webDriver);
            _webDriver.FindElement(SecondRatesPopupUnitOfMeasureDropDown).Click();
            _webDriver.FindElement(By.XPath("//ul/li[text() = 'Mass']")).Click();
            return new AddRebatePopup(_webDriver);
        }
        public AddRebatePopup ChooseUOMGram()
        {
            Actions actions = new Actions(_webDriver);
            _webDriver.FindElement(SecondRatesPopupUnitOfMeasureDropDown).Click();
            _webDriver.FindElement(By.XPath("//ul/li[text() = 'Gram']")).Click();
            return new AddRebatePopup(_webDriver);
        }

        public AddRebatePopup AddRatesPopupSetPercentage()
        {
            Actions actions = new Actions(_webDriver);
            _webDriver.FindElement(SecondRatesPopupRateInputPercentage2).Click();
            int int0to99 = rnd.Next(1, 99);
            actions.SendKeys($"{int0to99}").Perform();
            return new AddRebatePopup(_webDriver);
        }

        public AddRebatePopup AddRatesPopupSetTierAndRebateValues()
        {
            Actions actions = new Actions(_webDriver);
            int int0to99 = rnd.Next(1, 99);
            Waiter(10, SecondRatesPopupTierPercentageInput);
            _webDriver.FindElement(SecondRatesPopupTierPercentageInput).Click();
            actions.SendKeys($"{int0to99}").Perform();
            _webDriver.FindElement(SecondRatesPopupRebateInput).Click();
            actions.SendKeys($"{int0to99}").Perform();
            return new AddRebatePopup(_webDriver);
        }
    }
}
