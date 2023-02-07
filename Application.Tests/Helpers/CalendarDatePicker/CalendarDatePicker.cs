using OpenQA.Selenium;

namespace Application.Tests.Helpers.CalendarDatePicker
{
    public class CalendarDatePicker
    {
        public IWebDriver _driver { get; }
        public IWebElement SectionHeader => _driver.FindElement(By.CssSelector(".va-date-picker-header__text"));

        public IWebElement GetDayElement(int day)
        {
            return _driver.FindElement(By.XPath("//div[@class='va-day-picker']//span[text()='" + day + "']"));
        }
        public IWebElement GetMonthElement(int month)
        {
            return _driver.FindElement(By.XPath("//div[@class='va-month-picker']//div[text()='" + GetMonthShortageName(month) + "']"));
        }
        public IWebElement GetYearElement(int year)
        {
            return _driver.FindElement(By.XPath("//div[@class='va-year-picker']//div[text()='" + year + "']"));
        }

        public CalendarDatePicker(IWebDriver driver)
        {
            _driver = driver;
        }
        
        private string GetMonthShortageName(int month)
        {
            switch (month)
            {
                case 1:
                    return "Jan";
                    break;
                case 2:
                    return "Feb";
                    break;
                case 3:
                    return "Mar";
                    break;
                case 4:
                    return "Apr";
                    break;
                case 5:
                    return "May";
                    break;
                case 6:
                    return "Jun";
                    break;
                case 7:
                    return "Jul";
                    break;
                case 8:
                    return "Aug";
                    break;
                case 9:
                    return "Sep";
                    break;
                case 10:
                    return "Oct";
                    break;
                case 11:
                    return "Nov";
                    break;
                case 12:
                    return "Dec";
                    break;
                default:
                    return "Dec";
                    break;
            }
        }
    }
}
