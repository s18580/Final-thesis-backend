using OpenQA.Selenium;

namespace Application.Tests.Mappings.CustomerSearch
{
    public class CustomerSearch
    {
        public IWebDriver _driver { get; }
        public IWebElement CompanyName => _driver.FindElement(By.Id("companyName"));
        public IWebElement CompanyEmail => _driver.FindElement(By.Id("companyEmail"));
        public IWebElement CompanyPhone => _driver.FindElement(By.Id("companyPhone"));
        public IWebElement CompanyNip => _driver.FindElement(By.Id("companyNip"));
        public IWebElement CompanyRegon => _driver.FindElement(By.Id("companyRegon"));
        public IWebElement RepresentantName => _driver.FindElement(By.Id("repName"));
        public IWebElement RepresentantLastName => _driver.FindElement(By.Id("repLastName"));
        public IWebElement RepresentantEmail => _driver.FindElement(By.Id("repEmail"));
        public IWebElement RepresentantPhone => _driver.FindElement(By.Id("repPhone"));
        public IWebElement WorkerLider => _driver.FindElement(By.Id("workerLider"));

        public IWebElement ShowMoreFilters => _driver.FindElement(By.Id("inner-show-more"));
        public IWebElement SearchButton => _driver.FindElement(By.Id("search"));

        public IWebElement ResultsContainer => _driver.FindElement(By.Id("resultCo"));

        public CustomerSearch(IWebDriver driver)
        {
            _driver = driver;
        }
    }
}
