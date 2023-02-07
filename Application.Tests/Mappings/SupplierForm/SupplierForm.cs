using OpenQA.Selenium;

namespace Application.Tests.Mappings.SupplierForm
{
    public class SupplierForm
    {
        public IWebDriver _driver { get; }
        public IWebElement Name => _driver.FindElement(By.Id("supplierName"));
        public IWebElement Email => _driver.FindElement(By.Id("supplierEmail"));
        public IWebElement Phone => _driver.FindElement(By.Id("supplierPhone"));
        public IWebElement Description => _driver.FindElement(By.Id("supplierDesc"));

        public IWebElement AddAddressButton => _driver.FindElement(By.Id("addAddress"));
        public IWebElement AddRepresentativeButton => _driver.FindElement(By.Id("addRepresentative"));
        public IWebElement AddSupplierButton => _driver.FindElement(By.Id("addSupplier"));

        public SupplierForm(IWebDriver driver)
        {
            _driver = driver;
        }
    }
}
