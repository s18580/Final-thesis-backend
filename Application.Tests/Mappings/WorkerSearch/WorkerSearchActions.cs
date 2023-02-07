using OpenQA.Selenium;
using System.Threading;

namespace Application.Tests.Mappings.WorkerSearch
{
    public class WorkerSearchActions
    {
        private static WorkerSearch WorkerSearch { get; set; }
        public static void InitPage(IWebDriver driver)
        {
            WorkerSearch = new WorkerSearch(driver);
        }


        public static void PopulateFilters(string name, string lastName, string worksite)
        {
            WorkerSearch.Name.SendKeys(name);
            WorkerSearch.LastName.SendKeys(lastName);
            WorkerSearch.Worksite.SendKeys(worksite);
        }
        public static void SearchForResults()
        {
            WorkerSearch.SearchButton.Click();
            Thread.Sleep(2000);
        }

        public static bool CheckIfResultsAppeared()
        {
            return WorkerSearch.ResultsContainer.Displayed;
        }
    }
}
