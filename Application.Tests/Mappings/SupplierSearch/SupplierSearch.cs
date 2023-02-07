using OpenQA.Selenium;

namespace Application.Tests.Mappings.SupplierSearch
{
    public class SupplierSearch
    {
        public IWebDriver _driver { get; }
        public IWebElement SupplierName => _driver.FindElement(By.Id("supplierName"));
        public IWebElement SupplierEmail => _driver.FindElement(By.Id("supplierEmail"));
        public IWebElement SupplierPhone => _driver.FindElement(By.Id("supplierPhone"));
        public IWebElement RepresentantName => _driver.FindElement(By.Id("repName"));
        public IWebElement RepresentantLastName => _driver.FindElement(By.Id("repLastName"));
        public IWebElement AddressName => _driver.FindElement(By.Id("addressName"));
        public IWebElement Street => _driver.FindElement(By.Id("addressStreet"));
        public IWebElement City => _driver.FindElement(By.Id("addressCity"));
        public IWebElement Description => _driver.FindElement(By.Id("supplierDescription"));

        public IWebElement ShowMoreFilters => _driver.FindElement(By.Id("inner-show-more"));
        public IWebElement SearchButton => _driver.FindElement(By.Id("search"));

        public IWebElement ResultsContainer => _driver.FindElement(By.Id("resultCo"));

        public SupplierSearch(IWebDriver driver)
        {
            _driver = driver;
        }
    }
}
