using Application.Tests.Helpers.CalendarDatePicker;
using OpenQA.Selenium;
using System;
using System.Threading;

namespace Application.Tests.Mappings.ValuationSearch
{
    public class ValuationSearchActions
    {
        private static ValuationSearch ValuationSearch { get; set; }
        public static void InitPage(IWebDriver driver)
        {
            ValuationSearch = new ValuationSearch(driver);
        }

        public static void OpenMoreFilters()
        {
            ValuationSearch.ShowMoreFilters.Click();
            Thread.Sleep(500);
        }

        public static void PopulateFilters(DateTime creationDate, string name, string paper, string color, string author, string service, string bindingType, string orderItemType, string order)
        {
            ValuationSearch.ValuationName.SendKeys(name);
            ValuationSearch.Paper.SendKeys(paper);
            ValuationSearch.Color.SendKeys(color);

            CalendarDatePickerActions.SetDate(ValuationSearch._driver, ValuationSearch.CreationDate, creationDate);

            ValuationSearch.Author.SendKeys(author);
            ValuationSearch.Service.SendKeys(service);
            ValuationSearch.BindingType.SendKeys(bindingType);
            ValuationSearch.OrderItemType.SendKeys(orderItemType);
            ValuationSearch.Order.SendKeys(order);
        }

        public static void SearchForResults()
        {
            ValuationSearch.SearchButton.Click();
            Thread.Sleep(2000);
        }

        public static bool CheckIfResultsAppeared()
        {
            return ValuationSearch.ResultsContainer.Displayed;
        }

        public static void SelectValuation()
        {
            ValuationSearch.FirstValuationRecord.Click();
            Thread.Sleep(2000);
        }
    }
}
