using OpenQA.Selenium;
using System.Collections.Generic;
using System.Threading;

namespace Application.Tests.Mappings.SupplyForm
{
    public class SupplyActions
    {
        private static SupplyForm SupplyForm { get; set; }
        public static void InitPage(IWebDriver driver)
        {
            SupplyForm = new SupplyForm(driver);
        }

        public static void OpenAddressModal()
        {
            SupplyForm.AddAddressButton.Click();
            Thread.Sleep(500);
        }

        public static void AddSupply()
        {
            SupplyForm.AddSupplyButton.Click();
            Thread.Sleep(2000);
        }

        public static void PopulateSupplyDetails(double price, int quantity, string description, string supplyDate)
        {
            SupplyForm.OrderDropdown.Click();
            IReadOnlyList<IWebElement> orders = SupplyForm.DropdownElements;
            if (orders.Count != 0)
            {
                orders[0].Click();
            }

            SupplyForm.OrderItemDropdown.Click();
            IReadOnlyList<IWebElement> orderItems = SupplyForm.DropdownElements;
            if (orderItems.Count != 0)
            {
                orderItems[0].Click();
            }

            SupplyForm.Price.SendKeys(price.ToString());
            SupplyForm.Quantity.SendKeys(quantity.ToString());
            SupplyForm.Description.SendKeys(description);

            SupplyForm.jsExecutor.ExecuteScript("document.querySelector(\"[aria-label='Data realizacji dostawy']\").removeAttribute(\"readonly\")");
            SupplyForm.SupplyDate.SendKeys(supplyDate);

            SupplyForm.SupplyItemTypeDropdown.Click();
            IReadOnlyList<IWebElement> supplyItemTypes = SupplyForm.DropdownElements;
            if (supplyItemTypes.Count != 0)
            {
                supplyItemTypes[0].Click();
            }

            SupplyForm.SuppliersDropdown.Click();
            IReadOnlyList<IWebElement> suppliers = SupplyForm.DropdownElements;
            if (suppliers.Count != 0)
            {
                suppliers[0].Click();
            }

            SupplyForm.RepresentativesDropdown.Click();
            IReadOnlyList<IWebElement> representatives = SupplyForm.DropdownElements;
            if (representatives.Count != 0)
            {
                representatives[0].Click();
            }
        }
    }
}
