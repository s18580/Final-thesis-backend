using OpenQA.Selenium;

namespace Application.Tests.Mappings.CustomerForm
{
    public class CustomerForm
    {
        public IWebDriver _driver { get; }
        public IWebElement CompanyType => _driver.FindElement(By.XPath("//span[text()='Firma']"));
        public IWebElement PersonType => _driver.FindElement(By.XPath("//span[text()='Osoba prywatna']"));
        public IWebElement CompanyName => _driver.FindElement(By.Id("companyName"));
        public IWebElement CompanyEmail => _driver.FindElement(By.Id("companyEmail"));
        public IWebElement CompanyPhone => _driver.FindElement(By.Id("companyPhone"));
        public IWebElement CompanyNip => _driver.FindElement(By.Id("companyNip"));
        public IWebElement CompanyRegon => _driver.FindElement(By.Id("companyRegon"));
        public IWebElement CustomerName => _driver.FindElement(By.Id("customerName"));
        public IWebElement CustomerLastName => _driver.FindElement(By.Id("customerLastName"));
        public IWebElement CustomerEmail => _driver.FindElement(By.Id("customerEmail"));
        public IWebElement CustomerPhone => _driver.FindElement(By.Id("customerPhone"));

        public IWebElement AddAddressButton => _driver.FindElement(By.Id("addAddress"));
        public IWebElement AddRepresentativeButton => _driver.FindElement(By.Id("addRepresentative"));
        public IWebElement AddCustomerButton => _driver.FindElement(By.Id("addCustomer"));

        public CustomerForm(IWebDriver driver)
        {
            _driver = driver;
        }
    }
}
