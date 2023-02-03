using OpenQA.Selenium;

namespace Application.Tests.Mappings.SupplySearch
{
    public class SupplySearch
    {
        public IWebDriver _driver { get; }
        public IWebElement IsReceived => _driver.FindElement(By.Id("supplyReceived"));
        public IWebElement DeliveryDate => _driver.FindElement(By.Id("supplyDate"));
        public IWebElement DeliveryItemType => _driver.FindElement(By.Id("supplyItemType"));
        public IWebElement Supplier => _driver.FindElement(By.Id("supplier"));
        public IWebElement Representative => _driver.FindElement(By.Id("representative"));

        public IWebElement ShowMoreFilters => _driver.FindElement(By.Id("inner-show-more"));
        public IWebElement SearchButton => _driver.FindElement(By.Id("search"));

        public IWebElement ResultsContainer => _driver.FindElement(By.Id("resultCo"));

        public SupplySearch(IWebDriver driver)
        {
            _driver = driver;
        }
    }
}
