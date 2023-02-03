using Application.Tests.Mappings.CustomerSearch;
using Application.Tests.Mappings.LoginPage;
using Application.Tests.Mappings.NavBar;
using Application.Tests.TestData;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Application.Tests.Tests.Customer
{
    [TestClass]
    public class CustomerSearchTests : TestMasterPage
    {
        [TestMethod, TestCategory("CustomerSearch")]
        public void SearchForAllCustomers()
        {
            var userData = UsersTestData.GetAdminAccount();

            LoginActions.InitPage(_driver);
            LoginActions.Login(userData.Email, userData.Password);

            NavBarActions.InitPage(_driver);
            NavBarActions.GoToSearchCustomerPage();

            CustomerSearchActions.InitPage(_driver);
            CustomerSearchActions.SearchForResults();

            Assert.IsTrue(CustomerSearchActions.CheckIfResultsAppeared());
        }
    }
}
