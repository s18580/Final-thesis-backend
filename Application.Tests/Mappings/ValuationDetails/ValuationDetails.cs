using OpenQA.Selenium;

namespace Application.Tests.Mappings.ValuationDetails
{
    public class ValuationDetails
    {
        public IWebDriver _driver { get; }
        public IWebElement CopyValuation => _driver.FindElement(By.Id("valuationCopy"));

        public ValuationDetails(IWebDriver driver)
        {
            _driver = driver;
        }
    }
}
