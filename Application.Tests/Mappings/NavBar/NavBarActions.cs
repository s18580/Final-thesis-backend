using OpenQA.Selenium;

namespace Application.Tests.Mappings.NavBar
{
    public class NavBarActions
    {
        private static NavBar NavBar { get; set; }
        private static IWebDriver _driver { get; set; }

        public static void InitPage(IWebDriver driver)
        {
            _driver = driver;
            NavBar = new NavBar(driver);
        }

        public static void GoToHomePage()
        {
            NavBar.HomePage.Click();
        }
        public static void GoToManageAccountsPage()
        {
            if (NavBar.ManageAccounts.Displayed)
            {
                NavBar.ManageAccounts.Click();
            }
            else
            {
                NavBar.ManageAccountsSection.Click();
                NavBar.ManageAccounts.Click();
            }
        }
        public static void GoToAddAccountPage()
        {
            if (NavBar.AddAccount.Displayed)
            {
                NavBar.AddAccount.Click();
            }
            else
            {
                NavBar.ManageAccountsSection.Click();
                NavBar.AddAccount.Click();
            }
        }
        public static void GoToConstantsPage()
        {
            NavBar.Constants.Click();
        }
        public static void GoToAddOrderPage()
        {
            if (NavBar.AddOrder.Displayed)
            {
                NavBar.AddOrder.Click();
            }
            else
            {
                NavBar.OrdersSection.Click();
                NavBar.AddOrder.Click();
            }
        }
        public static void GoToSearchOrderPage()
        {
            if (NavBar.SearchOrder.Displayed)
            {
                NavBar.SearchOrder.Click();
            }
            else
            {
                NavBar.OrdersSection.Click();
                NavBar.SearchOrder.Click();
            }
        }
        public static void GoToOrdersOnGoingPage()
        {
            if (NavBar.OnGoingOrders.Displayed)
            {
                NavBar.OnGoingOrders.Click();
            }
            else
            {
                NavBar.OrdersSection.Click();
                NavBar.OnGoingOrders.Click();
            }

        }
        public static void GoToAddCustomerPage()
        {
            if (NavBar.AddCustomer.Displayed)
            {
                NavBar.AddCustomer.Click();
            }
            else
            {
                NavBar.CustomersSection.Click();
                NavBar.AddCustomer.Click();
            }
        }
        public static void GoToSearchCustomerPage()
        {
            if (NavBar.SearchCustomer.Displayed)
            {
                NavBar.SearchCustomer.Click();
            }
            else
            {
                NavBar.CustomersSection.Click();
                NavBar.SearchCustomer.Click();
            }
        }
        public static void GoToAddSupplierPage()
        {
            if (NavBar.AddSupplier.Displayed)
            {
                NavBar.AddSupplier.Click();
            }
            else
            {
                NavBar.SupplierAndSuppliersSection.Click();
                NavBar.AddSupplier.Click();
            }
        }
        public static void GoToSearchSupplierPage()
        {
            if (NavBar.SearchSupplier.Displayed)
            {
                NavBar.SearchSupplier.Click();
            }
            else
            {
                NavBar.SupplierAndSuppliersSection.Click();
                NavBar.SearchSupplier.Click();
            }
        }
        public static void GoToAddSupplyPage()
        {
            if (NavBar.AddSupply.Displayed)
            {
                NavBar.AddSupply.Click();
            }
            else
            {
                NavBar.SupplierAndSuppliersSection.Click();
                NavBar.AddSupply.Click();
            }
        }
        public static void GoToSearchSupplyPage()
        {
            if (NavBar.SearchSupply.Displayed)
            {
                NavBar.SearchSupply.Click();
            }
            else
            {
                NavBar.SupplierAndSuppliersSection.Click();
                NavBar.SearchSupply.Click();
            }
        }
        public static void GoToAddValuationPage()
        {
            if (NavBar.AddValuation.Displayed)
            {
                NavBar.AddValuation.Click();
            }
            else
            {
                NavBar.ValuationsSection.Click();
                NavBar.AddValuation.Click();
            }
        }
        public static void GoToSearchValuationPage()
        {
            if (NavBar.SearchValuation.Displayed)
            {
                NavBar.SearchValuation.Click();
            }
            else
            {
                NavBar.ValuationsSection.Click();
                NavBar.SearchValuation.Click();
            }
        }
        public static void GoToSearchWorkersPage()
        {
            if (NavBar.SearchWorkers.Displayed)
            {
                NavBar.SearchWorkers.Click();
            }
            else
            {
                NavBar.WorkersSection.Click();
                NavBar.SearchWorkers.Click();
            }
        }
        public static void GoToSearchRepresentativePage()
        {
            NavBar.SearchRepresentatives.Click();
        }
    }
}
