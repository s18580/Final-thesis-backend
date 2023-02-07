using Application.Tests.Mappings.LoginPage;
using Application.Tests.Mappings.NavBar;
using Application.Tests.Mappings.SupplierSearch;
using Application.Tests.TestData;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Application.Tests.Tests.Supplier
{
    [TestClass]
    public class SupplierSearchTests : TestMasterPage
    {
        [TestMethod, TestCategory("SupplierSearch"), TestCategory("Search")]
        public void SearchForAllSuppliers()
        {
            var userData = UsersTestData.GetAdminAccount();

            LoginActions.InitPage(_driver);
            LoginActions.Login(userData.Email, userData.Password);

            NavBarActions.InitPage(_driver);
            NavBarActions.GoToSearchSupplierPage();

            SupplierSearchActions.InitPage(_driver);
            SupplierSearchActions.SearchForResults();

            Assert.IsTrue(SupplierSearchActions.CheckIfResultsAppeared());
        }
    }
}
