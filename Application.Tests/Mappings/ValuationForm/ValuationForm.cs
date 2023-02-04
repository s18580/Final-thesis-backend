using OpenQA.Selenium;
using System.Collections.Generic;

namespace Application.Tests.Mappings.ValuationForm
{
    public class ValuationForm
    {
        public IWebDriver _driver { get; }

        public IWebElement OrdersDropdown => _driver.FindElement(By.XPath("//div[@id='orders']"));
        public IWebElement OrderItemsDropdown => _driver.FindElement(By.XPath("//div[@id='orderItems']"));
        public IWebElement BindingsDropdown => _driver.FindElement(By.XPath("//div[@id='bindings']"));
        public IReadOnlyList<IWebElement> DropdownElements => _driver.FindElements(By.XPath("//div[@class='va-dropdown__content-wrapper']//span"));

        public IWebElement WithoutOrderItemButton => _driver.FindElement(By.Id("withoutOrderItem"));
        public IWebElement LoadCopiedDataButton => _driver.FindElement(By.Id("loadCopiedData"));
        public IWebElement LoadBlankFormButton => _driver.FindElement(By.Id("loadBlankForm"));

        public IWebElement Author => _driver.FindElement(By.Id("authorName"));
        public IWebElement ValuationName => _driver.FindElement(By.Id("valuationName"));
        public IWebElement ValuationRecipient => _driver.FindElement(By.Id("valuationRecipient"));
        public IWebElement OfferValidity => _driver.FindElement(By.Id("offerValidity"));

        public IWebElement ShowCoverForm => _driver.FindElement(By.Id("showCoverForm"));
        public IWebElement InsideFormat => _driver.FindElement(By.Id("insideFormat"));
        public IWebElement InsideFormatSheet => _driver.FindElement(By.Id("insideFormatSheet"));
        public IWebElement InsideCirculation => _driver.FindElement(By.Id("insideCirculation"));
        public IWebElement InsideCapacity => _driver.FindElement(By.Id("insideCapacity"));
        public IWebElement InsideSheetNumber => _driver.FindElement(By.Id("insideSheetNumber"));
        public IWebElement IsnideOther => _driver.FindElement(By.Id("isnideOther"));
        public IWebElement InsidePlateNumber => _driver.FindElement(By.Id("insidePlateNumber"));

        public IWebElement CoverFormat => _driver.FindElement(By.Id("coverFormat"));
        public IWebElement CoverFormatSheet => _driver.FindElement(By.Id("coverFormatSheet"));
        public IWebElement CoverCirculation => _driver.FindElement(By.Id("coverCirculation"));
        public IWebElement CoverSheetNumber => _driver.FindElement(By.Id("coverSheetNumber"));
        public IWebElement CoverOther => _driver.FindElement(By.Id("coverOther"));
        public IWebElement CoverPlateNumber => _driver.FindElement(By.Id("coverPlateNumber"));

        public IWebElement FinalPrice => _driver.FindElement(By.Id("finalPrice"));
        public IWebElement MainCirculation => _driver.FindElement(By.Id("mainCirculation"));
        public IWebElement UnitPrice => _driver.FindElement(By.Id("unitPrice"));

        public IWebElement CalcPrice => _driver.FindElement(By.Id("calcPrices"));
        public IWebElement AddValuation => _driver.FindElement(By.Id("addValuation"));

        public IWebElement AddInsideColor => _driver.FindElement(By.Id("addInsideColor"));
        public IWebElement AddCoverColor => _driver.FindElement(By.Id("addCoverColor"));
        public IWebElement AddInsidePaper => _driver.FindElement(By.Id("addInsidePaper"));
        public IWebElement AddCoverPaper => _driver.FindElement(By.Id("addCoverPaper"));
        public IWebElement AddInsideService => _driver.FindElement(By.Id("addInsideService"));
        public IWebElement AddCoverService => _driver.FindElement(By.Id("addCoverService"));


        public ValuationForm(IWebDriver driver)
        {
            _driver = driver;
        }
    }
}
