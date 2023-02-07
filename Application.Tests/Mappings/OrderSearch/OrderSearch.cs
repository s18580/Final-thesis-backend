using OpenQA.Selenium;

namespace Application.Tests.Mappings.OrderSearch
{
    public class OrderSearch
    {
        public IWebDriver _driver { get; }
        public IWebElement OrderName => _driver.FindElement(By.Id("orderName"));
        public IWebElement Identifier => _driver.FindElement(By.Id("identifier"));
        public IWebElement DeliveryDate => _driver.FindElement(By.Id("deliveryDate"));
        public IWebElement OrderStatus => _driver.FindElement(By.Id("orderStatus"));
        public IWebElement CustomerRepresentant => _driver.FindElement(By.Id("customerRep"));
        public IWebElement SupplierRepresentant => _driver.FindElement(By.Id("supplierRep"));
        public IWebElement IsAuction => _driver.FindElement(By.Id("isAuction"));
        public IWebElement AssignedWorker => _driver.FindElement(By.Id("worker"));
        public IWebElement OrderItemType => _driver.FindElement(By.Id("orderItemType"));

        public IWebElement ShowMoreFilters => _driver.FindElement(By.Id("inner-show-more"));
        public IWebElement SearchButton => _driver.FindElement(By.Id("search"));

        public IWebElement ResultsContainer => _driver.FindElement(By.Id("resultCo"));

        public OrderSearch(IWebDriver driver)
        {
            _driver = driver;
        }
    }
}
