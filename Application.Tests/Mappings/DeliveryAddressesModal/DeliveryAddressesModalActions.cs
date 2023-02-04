using OpenQA.Selenium;
using System.Collections.Generic;

namespace Application.Tests.Mappings.DeliveryAddressesModal
{
    public class DeliveryAddressesModalActions
    {
        private static DeliveryAddressesModal DeliveryAddressesModal { get; set; }
        public static void InitPage(IWebDriver driver)
        {
            DeliveryAddressesModal = new DeliveryAddressesModal(driver);
        }

        public static void AddDeliveryAddress()
        {
            DeliveryAddressesModal.AddAddressButton.Click();
        }

        public static void PopulateDeliveryAddressesModal(string address)
        {
            DeliveryAddressesModal.AddressesDropdown.Click();
            IReadOnlyList<IWebElement> addresses = DeliveryAddressesModal.DropdownElements;
            if (addresses.Count != 0)
            {
                addresses[0].Click();
            }
        }
    }
}
