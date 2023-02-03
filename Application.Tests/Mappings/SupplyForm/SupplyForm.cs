using OpenQA.Selenium;
using System.Collections.Generic;

namespace Application.Tests.Mappings.SupplyForm
{
    public class SupplyForm
    {
        public IJavaScriptExecutor jsExecutor => (IJavaScriptExecutor)_driver;
        public IWebDriver _driver { get; }
        public IWebElement OrderDropdown => _driver.FindElement(By.XPath("//div[@id='orders']"));
        public IWebElement OrderItemDropdown => _driver.FindElement(By.XPath("//div[@id='orderItems']"));
        public IWebElement SupplyItemTypeDropdown => _driver.FindElement(By.XPath("//div[@id='supplyItemType']"));
        public IWebElement SuppliersDropdown => _driver.FindElement(By.XPath("//div[@id='supplier']"));
        public IWebElement RepresentativesDropdown => _driver.FindElement(By.XPath("//div[@id='representative']"));
        public IReadOnlyList<IWebElement> DropdownElements => _driver.FindElements(By.XPath("//div[@class='va-dropdown__content-wrapper']//span"));

        public IWebElement Price => _driver.FindElement(By.Id("price"));
        public IWebElement Quantity => _driver.FindElement(By.Id("quantity"));
        public IWebElement SupplyDate => _driver.FindElement(By.CssSelector("[aria-label='Data realizacji dostawy']"));
        public IWebElement Description => _driver.FindElement(By.Id("description"));
        public IWebElement IsReceived => _driver.FindElement(By.Id("isReceived"));

        public IWebElement AddAddressButton => _driver.FindElement(By.Id("addAddress"));
        public IWebElement AddSupplyButton => _driver.FindElement(By.Id("addSupply"));

        public SupplyForm(IWebDriver driver)
        {
            _driver = driver;
        }
    }
}
