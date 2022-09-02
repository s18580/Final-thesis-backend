using OpenQA.Selenium;
using System.Threading;

namespace Application.Tests.Mappings.LoginPage
{
    public class LoginActions
    {
        private static LoginPage LoginPage { get; set; }

        public static void InitPage(IWebDriver driver)
        {
            LoginPage = new LoginPage(driver);
        }

        public static void Login(string userName, string password)
        {
            LoginPage.UserName.SendKeys(userName);
            LoginPage.Password.SendKeys(password);
            LoginPage.LoginButton.Click();
            Thread.Sleep(2000);
        }
    }
}
