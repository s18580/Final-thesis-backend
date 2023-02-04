using Application.Tests.Helpers.CalendarDatePicker;
using Application.Tests.TestData;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Threading;

namespace Application.Tests.Mappings.ValuationForm
{
    public class ValuationFormActions
    {
        private static ValuationForm ValuationForm { get; set; }
        public static void InitPage(IWebDriver driver)
        {
            ValuationForm = new ValuationForm(driver);
        }

        public static void OpenInsideColorModal()
        {
            ValuationForm.AddInsideColor.Click();
            Thread.Sleep(500);
        }
        public static void OpenCoverColorModal()
        {
            ValuationForm.AddCoverColor.Click();
            Thread.Sleep(500);
        }
        public static void OpenInsidePaperModal()
        {
            ValuationForm.AddInsidePaper.Click();
            Thread.Sleep(500);
        }
        public static void OpenCoverPaperModal()
        {
            ValuationForm.AddCoverPaper.Click();
            Thread.Sleep(500);
        }
        public static void OpenInsideServiceModal()
        {
            ValuationForm.AddInsideService.Click();
            Thread.Sleep(500);
        }
        public static void OpenCoverServiceModal()
        {
            ValuationForm.AddCoverService.Click();
            Thread.Sleep(500);
        }
        public static void CalculatePrice()
        {
            ValuationForm.CalcPrice.Click();
            Thread.Sleep(500);
        }
        public static void AddValuation()
        {
            ValuationForm.AddValuation.Click();
            Thread.Sleep(2000);
        }

        public static bool CheckCopyValuation(bool withOrderItem)
        {
            if (withOrderItem)
            {
                ValuationForm.OrdersDropdown.Click();
                IReadOnlyList<IWebElement> orders = ValuationForm.DropdownElements;
                if (orders.Count != 0)
                {
                    orders[0].Click();
                }

                ValuationForm.OrderItemsDropdown.Click();
                IReadOnlyList<IWebElement> orderItems = ValuationForm.DropdownElements;
                if (orderItems.Count != 0)
                {
                    orderItems[0].Click();
                }
            }
            else
            {
                ValuationForm.WithoutOrderItemButton.Click();
            }

            ValuationForm.LoadCopiedDataButton.Click();

            return !string.IsNullOrEmpty(ValuationForm.ValuationName.GetAttribute("value").ToString());
        }

        public static void PopulateValuationForm(bool withOrderItem, bool loadCopiedValuation, ValuationData data)
        {
            if (withOrderItem)
            {
                ValuationForm.OrdersDropdown.Click();
                IReadOnlyList<IWebElement> orders = ValuationForm.DropdownElements;
                if (orders.Count != 0)
                {
                    orders[0].Click();
                }

                ValuationForm.OrderItemsDropdown.Click();
                IReadOnlyList<IWebElement> orderItems = ValuationForm.DropdownElements;
                if (orderItems.Count != 0)
                {
                    orderItems[0].Click();
                }
            }
            else
            {
                ValuationForm.WithoutOrderItemButton.Click();
            }

            if (loadCopiedValuation)
            {
                ValuationForm.LoadCopiedDataButton.Click();
            }
            else
            {
                ValuationForm.LoadBlankFormButton.Click();
            }

            ValuationForm.ValuationName.SendKeys(data.ValuationName);
            ValuationForm.ValuationRecipient.SendKeys(data.ValuationRecipient);
            CalendarDatePickerActions.SetDate(ValuationForm._driver, ValuationForm.OfferValidity, data.OfferValidity);

            ValuationForm.ValuationRecipient.Click();
            ValuationForm.InsideFormat.SendKeys(data.InsideFormat);
            ValuationForm.InsideFormatSheet.SendKeys(data.InsideFormatSheet);
            ValuationForm.InsideCirculation.SendKeys(data.InsideCirculation.ToString());
            ValuationForm.InsideCapacity.SendKeys(data.InsideCapacity.ToString());
            ValuationForm.InsideSheetNumber.SendKeys(data.InsideSheetNumber.ToString());
            ValuationForm.IsnideOther.SendKeys(data.IsnideOther);
            ValuationForm.InsidePlateNumber.SendKeys(data.InsidePlateNumber.ToString());

            if (data.IsWithCover)
            {
                ValuationForm.ShowCoverForm.Click();

                ValuationForm.BindingsDropdown.Click();
                IReadOnlyList<IWebElement> bindings = ValuationForm.DropdownElements;
                if (bindings.Count != 0)
                {
                    bindings[0].Click();
                }

                ValuationForm.CoverFormat.SendKeys(data.CoverFormat);
                ValuationForm.CoverFormatSheet.SendKeys(data.CoverFormatSheet);
                ValuationForm.CoverCirculation.SendKeys(data.CoverCirculation.ToString());
                ValuationForm.CoverSheetNumber.SendKeys(data.CoverSheetNumber.ToString());
                ValuationForm.CoverOther.SendKeys(data.CoverOther);
                ValuationForm.CoverPlateNumber.SendKeys(data.CoverPlateNumber.ToString());
            }

            ValuationForm.MainCirculation.SendKeys(data.MainCirculation.ToString());
        }
    }
}
