using OpenQA.Selenium;
using System.Collections.Generic;

namespace Application.Tests.Mappings.ServiceModal
{
    public class ServiceModal
    {
        public IWebDriver _driver { get; }
        public IWebElement ServicesDropdown => _driver.FindElement(By.Id("servicesDropdown"));
        public IReadOnlyList<IWebElement> DropdownElements => _driver.FindElements(By.XPath("//div[@class='va-dropdown__content-wrapper']//span"));

        public IWebElement ServicePrice => _driver.FindElement(By.Id("servicePrice"));

        public IWebElement AddServiceButton => _driver.FindElement(By.Id("addNewService"));

        public ServiceModal(IWebDriver driver)
        {
            _driver = driver;
        }
    }
}
