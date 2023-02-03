using Application.Tests.Mappings.LoginPage;
using Application.Tests.Mappings.NavBar;
using Application.Tests.Mappings.SupplySearch;
using Application.Tests.TestData;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Application.Tests.Tests.Supply
{
    [TestClass]
    public class SupplySearchTests : TestMasterPage
    {
        [TestMethod, TestCategory("SupplySearch"), TestCategory("Search")]
        public void SearchForAllSupplies()
        {
            var userData = UsersTestData.GetAdminAccount();

            LoginActions.InitPage(_driver);
            LoginActions.Login(userData.Email, userData.Password);

            NavBarActions.InitPage(_driver);
            NavBarActions.GoToSearchSupplyPage();

            SupplySearchActions.InitPage(_driver);
            SupplySearchActions.SearchForResults();

            Assert.IsTrue(SupplySearchActions.CheckIfResultsAppeared());
        }
    }
}
