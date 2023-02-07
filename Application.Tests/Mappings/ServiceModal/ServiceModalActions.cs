using OpenQA.Selenium;
using System.Collections.Generic;
using System.Threading;

namespace Application.Tests.Mappings.ServiceModal
{
    public class ServiceModalActions
    {
        private static ServiceModal ServiceModal { get; set; }
        public static void InitPage(IWebDriver driver)
        {
            ServiceModal = new ServiceModal(driver);
        }

        public static void AddService()
        {
            ServiceModal.AddServiceButton.Click();
            Thread.Sleep(500);
        }

        public static void PopulateServiceModal(string name, double price)
        {
            ServiceModal.ServicesDropdown.Click();
            IReadOnlyList<IWebElement> services = ServiceModal.DropdownElements;
            if (services.Count != 0)
            {
                services[0].Click();
            }

            ServiceModal.ServicePrice.Clear();
            ServiceModal.ServicePrice.SendKeys(price.ToString().Replace(',', '.'));
        }
    }
}
