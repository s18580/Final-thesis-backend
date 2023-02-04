using OpenQA.Selenium;
using System.Threading;
using Application.Tests.Helpers.CalendarDatePicker;
using System;
using System.Collections.Generic;

namespace Application.Tests.Mappings.OrderForm
{
    public class OrderFormActions
    {
        private static OrderForm OrderForm { get; set; }
        public static void InitPage(IWebDriver driver)
        {
            OrderForm = new OrderForm(driver);
        }

        public static void OpenOrderItemModal()
        {
            OrderForm.AddOrderItemButton.Click();
            Thread.Sleep(500);
        }

        public static void OpenWorkerModal()
        {
            OrderForm.AddWorkerButton.Click();
            Thread.Sleep(500);
        }

        public static void OpenAddressModal()
        {
            OrderForm.AddAddressButton.Click();
            Thread.Sleep(500);
        }

        public static void AddOrder()
        {
            OrderForm.AddOrderButton.Click();
            Thread.Sleep(2000);
        }

        public static void PopulateOrderDetails(bool isAuction, string orderName, string note, DateTime expectedDeliveryDate, DateTime offerValidityDate, string customer, string representative, string orderStatus)
        {
            if (isAuction) OrderForm.IsAuction.Click();
            CalendarDatePickerActions.SetDate(OrderForm._driver, OrderForm.ExpectedDeliveryDate, expectedDeliveryDate);
            OrderForm.OrderName.SendKeys(orderName);
            CalendarDatePickerActions.SetDate(OrderForm._driver, OrderForm.OfferValidityDate, offerValidityDate);
            OrderForm.Note.SendKeys(note);

            OrderForm.CustomerDropdown.Click();
            IReadOnlyList<IWebElement> customers = OrderForm.DropdownElements;
            if (customers.Count != 0)
            {
                customers[0].Click();
            }

            OrderForm.OrderStatusDropdown.Click();
            IReadOnlyList<IWebElement> representatives = OrderForm.DropdownElements;
            if (representatives.Count != 0)
            {
                representatives[0].Click();
            }

            OrderForm.RepresentativeDropdown.Click();
            IReadOnlyList<IWebElement> statuses = OrderForm.DropdownElements;
            if (statuses.Count != 0)
            {
                statuses[0].Click();
            }
        }
    }
}
