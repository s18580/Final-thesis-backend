using OpenQA.Selenium;
using System.Collections.Generic;

namespace Application.Tests.Mappings.OrderForm
{
    public class OrderForm
    {
        public IWebDriver _driver { get; }
        public IWebElement OrderStatusDropdown => _driver.FindElement(By.XPath("//div[@id='orderStatus']"));
        public IWebElement CustomerDropdown => _driver.FindElement(By.XPath("//div[@id='customer']"));
        public IWebElement RepresentativeDropdown => _driver.FindElement(By.XPath("//div[@id='representative']"));
        public IReadOnlyList<IWebElement> DropdownElements => _driver.FindElements(By.XPath("//div[@class='va-dropdown__content-wrapper']//span"));

        public IWebElement IsAuction => _driver.FindElement(By.Id("isAuction"));
        public IWebElement ExpectedDeliveryDate => _driver.FindElement(By.Id("expectedDeliveryDate"));
        public IWebElement OfferValidityDate => _driver.FindElement(By.Id("offerValidityDate"));
        public IWebElement OrderName => _driver.FindElement(By.Id("orderName"));
        public IWebElement Note => _driver.FindElement(By.Id("orderNote"));

        public IWebElement AddAddressButton => _driver.FindElement(By.Id("addAddress"));
        public IWebElement AddWorkerButton => _driver.FindElement(By.Id("addWorker"));
        public IWebElement AddOrderItemButton => _driver.FindElement(By.Id("addOrderItem"));
        public IWebElement AddOrderButton => _driver.FindElement(By.Id("addOrder"));

        public OrderForm(IWebDriver driver)
        {
            _driver = driver;
        }
    }
}
