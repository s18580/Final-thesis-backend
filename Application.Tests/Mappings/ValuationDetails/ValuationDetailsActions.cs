using OpenQA.Selenium;
using System.Threading;

namespace Application.Tests.Mappings.ValuationDetails
{
    public class ValuationDetailsActions
    {
        private static ValuationDetails ValuationDetails { get; set; }
        public static void InitPage(IWebDriver driver)
        {
            ValuationDetails = new ValuationDetails(driver);
        }

        public static void CopyValuation()
        {
            ValuationDetails.CopyValuation.Click();
            Thread.Sleep(500);
        }
    }
}
