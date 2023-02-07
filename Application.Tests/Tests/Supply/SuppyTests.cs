using Application.Tests.Mappings.LoginPage;
using Application.Tests.Mappings.NavBar;
using Application.Tests.Mappings.SupplyForm;
using Application.Tests.TestData;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Application.Tests.Tests.Supply
{
    [TestClass]
    public class SuppyTests : TestMasterPage
    {
        [TestMethod, TestCategory("Supply")]
        public void AddSupply()
        {
            var userData = UsersTestData.GetAdminAccount();
            var supplyData = SupplyTestData.GetSupply();

            LoginActions.InitPage(_driver);
            LoginActions.Login(userData.Email, userData.Password);

            NavBarActions.InitPage(_driver);
            NavBarActions.GoToAddSupplyPage();

            SupplyActions.InitPage(_driver);
            SupplyActions.PopulateSupplyDetails(supplyData.Price, supplyData.Quantity, supplyData.Description, supplyData.SupplyDate);

            SupplyActions.AddSupply();

            Assert.IsTrue(NavBarActions.CheckToastMessage("Dostawa została dodana."));
        }
    }
}
