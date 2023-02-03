using Application.Tests.Mappings.LoginPage;
using Application.Tests.Mappings.NavBar;
using Application.Tests.Mappings.UserMenu;
using Application.Tests.TestData;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Application.Tests.Tests.Other
{
    [TestClass]
    public class UserMenuTests : TestMasterPage
    {
        [TestMethod, TestCategory("Logout")]
        public void LogoutCorrectly()
        {
            var userData = UsersTestData.GetAdminAccount();

            LoginActions.InitPage(_driver);
            LoginActions.Login(userData.Email, userData.Password);

            UserMenuActions.InitPage(_driver);
            UserMenuActions.OpenUserMenu();
            UserMenuActions.Logout();

            NavBarActions.InitPage(_driver);
            Assert.IsTrue(NavBarActions.CheckToastMessage("Wylogowano pomyślnie."));
        }
    }
}
