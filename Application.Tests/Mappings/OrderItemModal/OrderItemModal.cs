using OpenQA.Selenium;
using System.Collections.Generic;

namespace Application.Tests.Mappings.OrderItemModal
{
    public class OrderItemModal
    {
        public IWebDriver _driver { get; }
        public IWebElement OrderItemTypeDropdown => _driver.FindElement(By.XPath("//div[@id='orderItemTypes']"));
        public IWebElement DeliveryTypeDropdown => _driver.FindElement(By.XPath("//div[@id='deliveryTypes']"));
        public IWebElement BindingTypeDropdown => _driver.FindElement(By.XPath("//div[@id='bindingTypes']"));
        public IReadOnlyList<IWebElement> DropdownElements => _driver.FindElements(By.XPath("//div[@class='va-dropdown__content-wrapper']//span"));

        public IWebElement IsWithCover => _driver.FindElement(By.XPath("//label[@class='va-radio']//span[text()='Z okładką']"));
        public IWebElement IsWithoutCover => _driver.FindElement(By.XPath("//label[@class='va-radio']//span[text()='Bez okładki']"));
        public IWebElement OrderItemName => _driver.FindElement(By.Id("orderItemName"));
        public IWebElement InsideFormat => _driver.FindElement(By.Id("insideFormat"));
        public IWebElement CoverFormat => _driver.FindElement(By.Id("coverFormat"));
        public IWebElement Circulation => _driver.FindElement(By.Id("circulation"));
        public IWebElement Capacity => _driver.FindElement(By.Id("capacity"));
        public IWebElement WantedFinishDate => _driver.FindElement(By.Id("expectedCompletionDate"));
        public IWebElement Note => _driver.FindElement(By.Id("comments"));

        public IWebElement AddCoverServiceButton => _driver.FindElement(By.Id("addCoverService"));
        public IWebElement AddCoverPaperButton => _driver.FindElement(By.Id("addCoverPaper"));
        public IWebElement AddCoverColorButton => _driver.FindElement(By.Id("addCoverColor"));
        public IWebElement AddInsideServiceButton => _driver.FindElement(By.Id("addInsideService"));
        public IWebElement AddInsidePaperButton => _driver.FindElement(By.Id("addInsidePaper"));
        public IWebElement AddInsideColorButton => _driver.FindElement(By.Id("addInsideColor"));
        public IWebElement AddOrderItemButton => _driver.FindElement(By.Id("createOrderItem"));

        public OrderItemModal(IWebDriver driver)
        {
            _driver = driver;
        }
    }
}
