using OpenQA.Selenium;
using System.Threading;

namespace Application.Tests.Mappings.OrderSearch
{
    public class OrderSearchActions
    {
        private static OrderSearch OrderSearch { get; set; }
        public static void InitPage(IWebDriver driver)
        {
            OrderSearch = new OrderSearch(driver);
        }

        public static void OpenMoreFilters()
        {
            OrderSearch.ShowMoreFilters.Click();
            Thread.Sleep(500);
        }
        public static void PopulateFilters(string orderName, string identifier, string deliveryDate, string orderStatus, string customerRepresentative, string suplierRepresentative, string isAuction, string worker, string orderItemType)
        {
            OrderSearch.OrderName.SendKeys(orderName);
            OrderSearch.Identifier.SendKeys(identifier);
            OrderSearch.DeliveryDate.SendKeys(deliveryDate);
            OrderSearch.OrderStatus.SendKeys(orderStatus);
            OrderSearch.CustomerRepresentant.SendKeys(customerRepresentative);
            OrderSearch.SupplierRepresentant.SendKeys(suplierRepresentative);
            OrderSearch.IsAuction.SendKeys(isAuction);
            OrderSearch.AssignedWorker.SendKeys(worker);
            OrderSearch.OrderItemType.SendKeys(orderItemType);
        }
        public static void SearchForResults()
        {
            OrderSearch.SearchButton.Click();
            Thread.Sleep(2000);
        }

        public static bool CheckIfResultsAppeared()
        {
            return OrderSearch.ResultsContainer.Displayed;
        }
    }
}
