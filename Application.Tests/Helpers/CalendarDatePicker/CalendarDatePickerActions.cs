using OpenQA.Selenium;
using System;

namespace Application.Tests.Helpers.CalendarDatePicker
{
    public class CalendarDatePickerActions
    {
        public static void SetDate(IWebDriver driver, IWebElement datePicker, DateTime date)
        {
            SetDateInPicker(driver, datePicker, date);
        }

        public static void SetDate(IWebDriver driver, IWebElement datePicker, string date)
        {
            SetDateInPicker(driver, datePicker, DateTime.Parse(date));
        }

        private static void SetDateInPicker(IWebDriver driver, IWebElement datePicker, DateTime dateToSet)
        {
            var CalendarDatePicker = new CalendarDatePicker(driver);
            var currentDate = DateTime.Now;

            datePicker.Click();

            if (currentDate.Year != dateToSet.Year)
            {
                CalendarDatePicker.SectionHeader.Click();
                CalendarDatePicker.SectionHeader.Click();

                CalendarDatePicker.GetYearElement(dateToSet.Year).Click();
                CalendarDatePicker.GetMonthElement(dateToSet.Month).Click();
                CalendarDatePicker.GetDayElement(dateToSet.Day).Click();
            }
            else if (currentDate.Month != dateToSet.Month)
            {
                CalendarDatePicker.SectionHeader.Click();

                CalendarDatePicker.GetMonthElement(dateToSet.Month).Click();
                CalendarDatePicker.GetDayElement(dateToSet.Day).Click();
            }
            else
            {
                CalendarDatePicker.GetDayElement(dateToSet.Day).Click();
            }
        }
    }
}
