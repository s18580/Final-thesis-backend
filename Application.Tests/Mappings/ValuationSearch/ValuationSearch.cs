using OpenQA.Selenium;

namespace Application.Tests.Mappings.ValuationSearch
{
    public class ValuationSearch
    {
        public IWebDriver _driver { get; }
        public IWebElement ValuationName => _driver.FindElement(By.Id("valuationName"));
        public IWebElement Author => _driver.FindElement(By.Id("author"));
        public IWebElement CreationDate => _driver.FindElement(By.Id("creationDate"));
        public IWebElement Paper => _driver.FindElement(By.Id("valuationPaper"));
        public IWebElement Color => _driver.FindElement(By.Id("valuationColor"));
        public IWebElement Service => _driver.FindElement(By.Id("valuationService"));
        public IWebElement BindingType => _driver.FindElement(By.Id("bindingType"));
        public IWebElement OrderItemType => _driver.FindElement(By.Id("orderItemType"));
        public IWebElement Order => _driver.FindElement(By.Id("order"));
        public IWebElement FirstValuationRecord => _driver.FindElement(By.XPath("//tbody[@class='va-data-table__table-tbody']/tr[1]//button//i[text()='visibility']"));

        public IWebElement ShowMoreFilters => _driver.FindElement(By.Id("inner-show-more"));
        public IWebElement SearchButton => _driver.FindElement(By.Id("search"));

        public IWebElement ResultsContainer => _driver.FindElement(By.Id("resultCo"));

        public ValuationSearch(IWebDriver driver)
        {
            _driver = driver;
        }
    }
}
