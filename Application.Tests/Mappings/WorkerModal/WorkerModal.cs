using OpenQA.Selenium;
using System.Collections.Generic;

namespace Application.Tests.Mappings.WorkerModal
{
    public class WorkerModal
    {
        public IWebDriver _driver { get; }
        public IWebElement WorkersDropdown => _driver.FindElement(By.XPath("//div[@id='worker']"));
        public IReadOnlyList<IWebElement> DropdownElements => _driver.FindElements(By.XPath("//div[@class='va-dropdown__content-wrapper']//span"));

        public IWebElement IsLeader => _driver.FindElement(By.Id("isLeader"));

        public IWebElement AddWorkerButton => _driver.FindElement(By.Id("addAssignment"));

        public WorkerModal(IWebDriver driver)
        {
            _driver = driver;
        }
    }
}
