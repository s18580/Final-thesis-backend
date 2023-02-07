using OpenQA.Selenium;
using System.Threading;

namespace Application.Tests.Mappings.SupplierSearch
{
    public class SupplierSearchActions
    {
        private static SupplierSearch SupplierSearch { get; set; }
        public static void InitPage(IWebDriver driver)
        {
            SupplierSearch = new SupplierSearch(driver);
        }

        public static void OpenMoreFilters()
        {
            SupplierSearch.ShowMoreFilters.Click();
            Thread.Sleep(500);
        }
        public static void PopulateFilters(string supplierName, string supplierEmail, string supplierPhone, string addressName, string description, string repName, string repLastName, string city, string street)
        {
            SupplierSearch.SupplierName.SendKeys(supplierName);
            SupplierSearch.SupplierEmail.SendKeys(supplierEmail);
            SupplierSearch.SupplierPhone.SendKeys(supplierPhone);
            SupplierSearch.AddressName.SendKeys(addressName);
            SupplierSearch.Street.SendKeys(street);
            SupplierSearch.RepresentantName.SendKeys(repName);
            SupplierSearch.RepresentantLastName.SendKeys(repLastName);
            SupplierSearch.City.SendKeys(city);
            SupplierSearch.Description.SendKeys(description);
        }
        public static void SearchForResults()
        {
            SupplierSearch.SearchButton.Click();
            Thread.Sleep(2000);
        }

        public static bool CheckIfResultsAppeared()
        {
            return SupplierSearch.ResultsContainer.Displayed;
        }
    }
}
