using OpenQA.Selenium;
using System.Threading;

namespace Application.Tests.Mappings.UserMenu
{
    public class UserMenuActions
    {
        private static UserMenu UserMenu { get; set; }
        public static void InitPage(IWebDriver driver)
        {
            UserMenu = new UserMenu(driver);
        }

        public static void OpenUserMenu()
        {
            UserMenu.UserMenuPill.Click();
            Thread.Sleep(500);
        }

        public static void Logout()
        {
            UserMenu.Logout.Click();
            Thread.Sleep(500);
        }

        public static void OpenUserModal()
        {
            UserMenu.UserModal.Click();
            Thread.Sleep(500);
        }

        public static void OpenHelpModal()
        {
            UserMenu.Help.Click();
            Thread.Sleep(500);
        }
    }
}
