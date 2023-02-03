using OpenQA.Selenium;
using System.Threading;

namespace Application.Tests.Mappings.CustomerSearch
{
    public class CustomerSearchActions
    {
        private static CustomerSearch CustomerSearch { get; set; }
        public static void InitPage(IWebDriver driver)
        {
            CustomerSearch = new CustomerSearch(driver);
        }

        public static void OpenMoreFilters()
        {
            CustomerSearch.ShowMoreFilters.Click();
            Thread.Sleep(500);
        }
        public static void PopulateFilters(string companyName, string companyEmail, string companyPhone, string nip, string regon, string repName, string repLastName, string repPhone, string repEmail, string lider)
        {
            CustomerSearch.CompanyName.SendKeys(companyName);
            CustomerSearch.CompanyEmail.SendKeys(companyEmail);
            CustomerSearch.CompanyPhone.SendKeys(companyPhone);
            CustomerSearch.CompanyNip.SendKeys(nip);
            CustomerSearch.CompanyRegon.SendKeys(regon);
            CustomerSearch.RepresentantName.SendKeys(repName);
            CustomerSearch.RepresentantLastName.SendKeys(repLastName);
            CustomerSearch.RepresentantPhone.SendKeys(repPhone);
            CustomerSearch.RepresentantEmail.SendKeys(repEmail);
            CustomerSearch.WorkerLider.SendKeys(lider);
        }
        public static void SearchForResults()
        {
            CustomerSearch.SearchButton.Click();
            Thread.Sleep(2000);
        }

        public static bool CheckIfResultsAppeared()
        {
            return CustomerSearch.ResultsContainer.Displayed;
        }
    }
}
