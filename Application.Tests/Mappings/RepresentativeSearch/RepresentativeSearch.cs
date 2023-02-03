using OpenQA.Selenium;

namespace Application.Tests.Mappings.RepresentativeSearch
{
    public class RepresentativeSearch
    {
        public IWebDriver _driver { get; }
        public IWebElement Supplier => _driver.FindElement(By.Id("supplier"));
        public IWebElement Customer => _driver.FindElement(By.Id("customer"));
        public IWebElement IsDeactivated => _driver.FindElement(By.Id("isDeactivated"));
        public IWebElement RepresentantName => _driver.FindElement(By.Id("repName"));
        public IWebElement RepresentantLastName => _driver.FindElement(By.Id("repLastName"));
        public IWebElement RepresentantEmail => _driver.FindElement(By.Id("repEmail"));
        public IWebElement RepresentantPhone => _driver.FindElement(By.Id("repPhone"));

        public IWebElement ShowMoreFilters => _driver.FindElement(By.Id("inner-show-more"));
        public IWebElement SearchButton => _driver.FindElement(By.Id("search"));

        public IWebElement ResultsContainer => _driver.FindElement(By.Id("resultCo"));

        public RepresentativeSearch(IWebDriver driver)
        {
            _driver = driver;
        }
    }
}
