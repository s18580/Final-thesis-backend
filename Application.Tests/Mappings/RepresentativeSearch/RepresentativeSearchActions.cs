using OpenQA.Selenium;
using System.Threading;

namespace Application.Tests.Mappings.RepresentativeSearch
{
    public class RepresentativeSearchActions
    {
        private static RepresentativeSearch RepresentativeSearch { get; set; }
        public static void InitPage(IWebDriver driver)
        {
            RepresentativeSearch = new RepresentativeSearch(driver);
        }

        public static void OpenMoreFilters()
        {
            RepresentativeSearch.ShowMoreFilters.Click();
            Thread.Sleep(500);
        }
        public static void PopulateFilters(string supplier, string customer, string isDeactivated, string repPhone, string repEmail, string repName, string repLastName)
        {
            RepresentativeSearch.Supplier.SendKeys(supplier);
            RepresentativeSearch.Customer.SendKeys(customer);
            RepresentativeSearch.IsDeactivated.SendKeys(isDeactivated);
            RepresentativeSearch.RepresentantName.SendKeys(repName);
            RepresentativeSearch.RepresentantLastName.SendKeys(repLastName);
            RepresentativeSearch.RepresentantEmail.SendKeys(repEmail);
            RepresentativeSearch.RepresentantPhone.SendKeys(repPhone);
        }
        public static void SearchForResults()
        {
            RepresentativeSearch.SearchButton.Click();
            Thread.Sleep(2000);
        }

        public static bool CheckIfResultsAppeared()
        {
            return RepresentativeSearch.ResultsContainer.Displayed;
        }
    }
}
