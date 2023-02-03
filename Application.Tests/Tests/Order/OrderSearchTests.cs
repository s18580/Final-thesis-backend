using Application.Tests.Mappings.LoginPage;
using Application.Tests.Mappings.NavBar;
using Application.Tests.Mappings.OrderSearch;
using Application.Tests.TestData;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Application.Tests.Tests.Order
{
    [TestClass]
    public class OrderSearchTests : TestMasterPage
    {
        [TestMethod, TestCategory("OrderSearch"), TestCategory("Search")]
        public void SearchForAllOrders()
        {
            var userData = UsersTestData.GetAdminAccount();

            LoginActions.InitPage(_driver);
            LoginActions.Login(userData.Email, userData.Password);

            NavBarActions.InitPage(_driver);
            NavBarActions.GoToSearchOrderPage();

            OrderSearchActions.InitPage(_driver);
            OrderSearchActions.SearchForResults();

            Assert.IsTrue(OrderSearchActions.CheckIfResultsAppeared());
        }
    }
}
