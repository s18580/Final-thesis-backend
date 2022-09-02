using OpenQA.Selenium;
using System.Threading;

namespace Application.Tests.Mappings.NavBar
{
    public class NavBarActions
    {
        private static NavBar NavBar { get; set; }

        public static void InitPage(IWebDriver driver)
        {
            NavBar = new NavBar(driver);
        }

        public static bool CheckToastMessage(string message)
        {
            return NavBar.ToastMessage.Text == message;
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
                Thread.Sleep(500);
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
                Thread.Sleep(500);
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
                Thread.Sleep(500);
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
                Thread.Sleep(500);
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
                Thread.Sleep(500);
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
                Thread.Sleep(500);
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
                Thread.Sleep(500);
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
                Thread.Sleep(500);
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
                Thread.Sleep(500);
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
                Thread.Sleep(500);
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
                Thread.Sleep(500);
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
                Thread.Sleep(500);
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
                Thread.Sleep(500);
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
                Thread.Sleep(500);
                NavBar.SearchWorkers.Click();
            }
        }
        public static void GoToSearchRepresentativePage()
        {
            NavBar.SearchRepresentatives.Click();
        }
    }
}
