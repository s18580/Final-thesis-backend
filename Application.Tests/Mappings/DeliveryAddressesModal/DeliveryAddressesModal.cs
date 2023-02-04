using OpenQA.Selenium;
using System.Collections.Generic;

namespace Application.Tests.Mappings.DeliveryAddressesModal
{
    public class DeliveryAddressesModal
    {
        public IWebDriver _driver { get; }
        public IWebElement AddressesDropdown => _driver.FindElement(By.XPath("//div[@id='address']"));
        public IReadOnlyList<IWebElement> DropdownElements => _driver.FindElements(By.XPath("//div[@class='va-dropdown__content-wrapper']//span"));

        public IWebElement AddAddressButton => _driver.FindElement(By.Id("addDeliveryAddress"));

        public DeliveryAddressesModal(IWebDriver driver)
        {
            _driver = driver;
        }
    }
}
