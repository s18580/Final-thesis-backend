using Application.Tests.Mappings.LoginPage;
using Application.Tests.Mappings.NavBar;
using Application.Tests.Mappings.WorkerSearch;
using Application.Tests.TestData;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Application.Tests.Tests.Worker
{
    [TestClass]
    public class WorkerSearchTests : TestMasterPage
    {
        [TestMethod, TestCategory("WorkerSearch"), TestCategory("Search")]
        public void SearchForAllWorkers()
        {
            var userData = UsersTestData.GetAdminAccount();

            LoginActions.InitPage(_driver);
            LoginActions.Login(userData.Email, userData.Password);

            NavBarActions.InitPage(_driver);
            NavBarActions.GoToSearchWorkersPage();

            WorkerSearchActions.InitPage(_driver);
            WorkerSearchActions.SearchForResults();

            Assert.IsTrue(WorkerSearchActions.CheckIfResultsAppeared());
        }
    }
}
