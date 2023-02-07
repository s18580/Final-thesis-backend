using OpenQA.Selenium;

namespace Application.Tests.Mappings.WorkerSearch
{
    public class WorkerSearch
    {
        public IWebDriver _driver { get; }
        public IWebElement Name => _driver.FindElement(By.Id("workerName"));
        public IWebElement LastName => _driver.FindElement(By.Id("workerLastName"));
        public IWebElement Worksite => _driver.FindElement(By.Id("worksite"));

        public IWebElement SearchButton => _driver.FindElement(By.Id("search"));

        public IWebElement ResultsContainer => _driver.FindElement(By.Id("resultCo"));

        public WorkerSearch(IWebDriver driver)
        {
            _driver = driver;
        }
    }
}
