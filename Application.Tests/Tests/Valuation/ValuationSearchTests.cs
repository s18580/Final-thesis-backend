using Application.Tests.Mappings.LoginPage;
using Application.Tests.Mappings.NavBar;
using Application.Tests.Mappings.ValuationSearch;
using Application.Tests.TestData;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Application.Tests.Tests.Valuation
{
    [TestClass]
    public class ValuationSearchTests : TestMasterPage
    {
        [TestMethod, TestCategory("Valuation"), TestCategory("Search")]
        public void SearchForAllValuations()
        {
            var userData = UsersTestData.GetAdminAccount();

            LoginActions.InitPage(_driver);
            LoginActions.Login(userData.Email, userData.Password);

            NavBarActions.InitPage(_driver);
            NavBarActions.GoToSearchOrderPage();

            ValuationSearchActions.InitPage(_driver);
            ValuationSearchActions.SearchForResults();

            Assert.IsTrue(ValuationSearchActions.CheckIfResultsAppeared());
        }
    }
}
