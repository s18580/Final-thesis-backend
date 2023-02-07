using OpenQA.Selenium;

namespace Application.Tests.Mappings.AddressModal
{
    public class AddressModal
    {
        public IWebDriver _driver { get; }
        public IWebElement Name => _driver.FindElement(By.Id("addressName"));
        public IWebElement Country => _driver.FindElement(By.Id("addressCountry"));
        public IWebElement City => _driver.FindElement(By.Id("addressCity"));
        public IWebElement PostCode => _driver.FindElement(By.Id("addressPostCode"));
        public IWebElement Street => _driver.FindElement(By.Id("addressStreet"));
        public IWebElement StreetNumber => _driver.FindElement(By.Id("addressStreetNumber"));
        public IWebElement Apartment => _driver.FindElement(By.Id("addressApartment"));
        public IWebElement AddAddress => _driver.FindElement(By.XPath("//button[@id='addAdd']"));

        public AddressModal(IWebDriver driver)
        {
            _driver = driver;
        }
    }
}
