using OpenQA.Selenium;
using System.Threading;
using Application.Tests.Helpers.CalendarDatePicker;
using System;
using System.Collections.Generic;

namespace Application.Tests.Mappings.OrderItemModal
{
    public class OrderItemModalActions
    {
        private static OrderItemModal OrderItemModal { get; set; }
        public static void InitPage(IWebDriver driver)
        {
            OrderItemModal = new OrderItemModal(driver);
        }

        public static void OpenCoverColor()
        {
            OrderItemModal.AddCoverColorButton.Click();
            Thread.Sleep(500);
        }
        public static void OpenCoverPaper()
        {
            OrderItemModal.AddCoverPaperButton.Click();
            Thread.Sleep(500);
        }
        public static void OpenCoverService()
        {
            OrderItemModal.AddCoverServiceButton.Click();
            Thread.Sleep(500);
        }
        public static void OpenInsideColor()
        {
            OrderItemModal.AddInsideColorButton.Click();
            Thread.Sleep(500);
        }
        public static void OpenInsidePaper()
        {
            OrderItemModal.AddInsidePaperButton.Click();
            Thread.Sleep(500);
        }
        public static void OpenInsideService()
        {
            OrderItemModal.AddInsideServiceButton.Click();
            Thread.Sleep(500);
        }
        public static void AddOrderItem()
        {
            OrderItemModal.AddOrderItemButton.Click();
            Thread.Sleep(500);
        }

        public static void PopulateOrderDetails(bool isWithCover, string orderItemName, string note, DateTime expectedFinishDate, string insideFormat, int circulation, string orderItemType, string deliveryType, string coverFormat, string bindingType, int capacity)
        {
            CalendarDatePickerActions.SetDate(OrderItemModal._driver, OrderItemModal.WantedFinishDate, expectedFinishDate);
            OrderItemModal.OrderItemName.SendKeys(orderItemName);
            OrderItemModal.InsideFormat.SendKeys(insideFormat);
            OrderItemModal.Circulation.Clear();
            OrderItemModal.Circulation.SendKeys(circulation.ToString());
            OrderItemModal.Note.SendKeys(note);

            OrderItemModal.OrderItemTypeDropdown.Click();
            IReadOnlyList<IWebElement> orderitemTypes = OrderItemModal.DropdownElements;
            if (orderitemTypes.Count != 0)
            {
                orderitemTypes[0].Click();
            }

            OrderItemModal.DeliveryTypeDropdown.Click();
            IReadOnlyList<IWebElement> devlieryTypes = OrderItemModal.DropdownElements;
            if (devlieryTypes.Count != 0)
            {
                devlieryTypes[0].Click();
            }

            if (isWithCover)
            {
                OrderItemModal.IsWithCover.Click();
                OrderItemModal.CoverFormat.SendKeys(coverFormat);
                OrderItemModal.Capacity.Clear();
                OrderItemModal.Capacity.SendKeys(capacity.ToString());

                OrderItemModal.BindingTypeDropdown.Click();
                IReadOnlyList<IWebElement> bindingTypes = OrderItemModal.DropdownElements;
                if (bindingTypes.Count != 0)
                {
                    bindingTypes[0].Click();
                }
            }
        }
    }
}
