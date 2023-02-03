using OpenQA.Selenium;
using System.Threading;

namespace Application.Tests.Mappings.SupplySearch
{
    public class SupplySearchActions
    {
        private static SupplySearch SupplySearch { get; set; }
        public static void InitPage(IWebDriver driver)
        {
            SupplySearch = new SupplySearch(driver);
        }

        public static void OpenMoreFilters()
        {
            SupplySearch.ShowMoreFilters.Click();
            Thread.Sleep(500);
        }
        public static void PopulateFilters(string representative, string suplier, string deliveryItemType, string deliveryDate, string isReceived)
        {
            SupplySearch.Representative.SendKeys(representative);
            SupplySearch.Supplier.SendKeys(suplier);
            SupplySearch.DeliveryItemType.SendKeys(deliveryItemType);
            SupplySearch.DeliveryDate.SendKeys(deliveryDate);
            SupplySearch.IsReceived.SendKeys(isReceived);
        }
        public static void SearchForResults()
        {
            SupplySearch.SearchButton.Click();
            Thread.Sleep(2000);
        }

        public static bool CheckIfResultsAppeared()
        {
            return SupplySearch.ResultsContainer.Displayed;
        }
    }
}
