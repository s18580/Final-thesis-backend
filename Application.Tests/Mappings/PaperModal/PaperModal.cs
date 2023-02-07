using OpenQA.Selenium;
using System.Collections.Generic;

namespace Application.Tests.Mappings.PaperModal
{
    public class PaperModal
    {
        public IWebDriver _driver { get; }
        public IWebElement FiberDirectionDropdown => _driver.FindElement(By.Id("fibers"));
        public IReadOnlyList<IWebElement> DropdownElements => _driver.FindElements(By.XPath("//div[@class='va-dropdown__content-wrapper']//span"));

        public IWebElement PaperName => _driver.FindElement(By.Id("paperName"));
        public IWebElement PaperType => _driver.FindElement(By.Id("paperKind"));
        public IWebElement PaperFormat => _driver.FindElement(By.Id("sheetFormat"));
        public IWebElement PaperOpacity => _driver.FindElement(By.Id("paperOpacity"));
        public IWebElement PaperQuantity => _driver.FindElement(By.Id("paperQuantity"));
        public IWebElement PricePerKilo => _driver.FindElement(By.Id("pricePerKilogram"));

        public IWebElement AddPaperButton => _driver.FindElement(By.Id("addNewPaper"));

        public PaperModal(IWebDriver driver)
        {
            _driver = driver;
        }
    }
}
