using Application.Tests.Mappings.LoginPage;
using Application.Tests.Mappings.NavBar;
using Application.Tests.Mappings.RepresentativeSearch;
using Application.Tests.TestData;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Application.Tests.Tests.Representative
{
    [TestClass]
    public class RepresentativeSearchTests : TestMasterPage
    {
        [TestMethod, TestCategory("RepresentativeSearch"), TestCategory("Search")]
        public void SearchForAllRepresentatives()
        {
            var userData = UsersTestData.GetAdminAccount();

            LoginActions.InitPage(_driver);
            LoginActions.Login(userData.Email, userData.Password);

            NavBarActions.InitPage(_driver);
            NavBarActions.GoToSearchRepresentativePage();

            RepresentativeSearchActions.InitPage(_driver);
            RepresentativeSearchActions.SearchForResults();

            Assert.IsTrue(RepresentativeSearchActions.CheckIfResultsAppeared());
        }
    }
}
