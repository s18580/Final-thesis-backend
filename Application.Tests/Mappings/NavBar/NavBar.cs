using OpenQA.Selenium;

namespace Application.Tests.Mappings.NavBar
{
    public class NavBar
    {
        public IWebDriver _driver { get; }
        public IWebElement HomePage => _driver.FindElement(By.Id("home"));
        public IWebElement ManageAccountsSection => _driver.FindElement(By.Id("manageAccountsSection"));
        public IWebElement ManageAccounts => _driver.FindElement(By.Name("manageAccounts"));
        public IWebElement AddAccount => _driver.FindElement(By.Name("addAccount"));
        public IWebElement Constants => _driver.FindElement(By.Id("programConstants"));
        public IWebElement OrdersSection => _driver.FindElement(By.Id("ordersSection"));
        public IWebElement AddOrder => _driver.FindElement(By.Name("addOrder"));
        public IWebElement SearchOrder => _driver.FindElement(By.Name("searchOrder"));
        public IWebElement OnGoingOrders => _driver.FindElement(By.Name("onGoingOrders"));
        public IWebElement CustomersSection => _driver.FindElement(By.Id("customersSection"));
        public IWebElement AddCustomer => _driver.FindElement(By.Name("addCustomer"));
        public IWebElement SearchCustomer => _driver.FindElement(By.Name("searchCustomer"));
        public IWebElement SupplierAndSuppliersSection => _driver.FindElement(By.Id("suppiersAndSupplySection"));
        public IWebElement AddSupplier => _driver.FindElement(By.Name("addSupplier"));
        public IWebElement SearchSupplier => _driver.FindElement(By.Name("searchSupplier"));
        public IWebElement AddSupply => _driver.FindElement(By.Name("addSupply"));
        public IWebElement SearchSupply => _driver.FindElement(By.Name("searchSupply"));
        public IWebElement ValuationsSection => _driver.FindElement(By.Id("valuationsSection"));
        public IWebElement AddValuation => _driver.FindElement(By.Name("addValuation"));
        public IWebElement SearchValuation => _driver.FindElement(By.Name("searchValuation"));
        public IWebElement WorkersSection => _driver.FindElement(By.Id("workersSection"));
        public IWebElement SearchWorkers => _driver.FindElement(By.Name("searchWorker"));
        public IWebElement SearchRepresentatives => _driver.FindElement(By.Name("searchRepresentative"));

        public NavBar(IWebDriver driver)
        {
            _driver = driver;
        }
    }
}
