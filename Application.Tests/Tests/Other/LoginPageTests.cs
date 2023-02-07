using Application.Tests.Mappings.LoginPage;
using Application.Tests.Mappings.NavBar;
using Application.Tests.TestData;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Application.Tests.Tests.Other
{
    [TestClass]
    public class LoginPageTests : TestMasterPage
    {
        [TestMethod, TestCategory("Login")]
        public void LoginCorrectly()
        {
            var userData = UsersTestData.GetAdminAccount();

            LoginActions.InitPage(_driver);
            LoginActions.Login(userData.Email, userData.Password);

            NavBarActions.InitPage(_driver);
            Assert.IsFalse(NavBarActions.CheckToastMessage("Nieprawidłowe dane logowania."));
            Assert.IsFalse(NavBarActions.CheckToastMessage("Błąd logowania."));
        }
    }
}
