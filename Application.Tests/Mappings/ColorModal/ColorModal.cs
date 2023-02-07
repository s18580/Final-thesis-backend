using OpenQA.Selenium;

namespace Application.Tests.Mappings.ColorModal
{
    public class ColorModal
    {
        public IWebDriver _driver { get; }
        public IWebElement ColorName => _driver.FindElement(By.Id("colorName"));

        public IWebElement AddColorButton => _driver.FindElement(By.Id("addNewColor"));

        public ColorModal(IWebDriver driver)
        {
            _driver = driver;
        }
    }
}
