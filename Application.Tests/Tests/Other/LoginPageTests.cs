using Application.Tests.Mappings.LoginPage;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Application.Tests.Tests.Other
{
    [TestClass]
    public class LoginPageTests : TestMasterPage
    {
        [TestMethod, TestCategory("LoginPageRegression")]
        public void LoginCorrectly()
        {
            LoginActions.InitPage(_driver);
            LoginActions.Login("admin@gmail.com", "admin");
            Assert.AreEqual("final-thesis-ui", _driver.Title);
        }
    }
}
