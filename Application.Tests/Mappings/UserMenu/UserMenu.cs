using OpenQA.Selenium;


namespace Application.Tests.Mappings.UserMenu
{
    public class UserMenu
    {
        public IWebDriver _driver { get; }
        public IWebElement UserMenuPill => _driver.FindElement(By.Id("userMenu"));
        public IWebElement UserModal => _driver.FindElement(By.Id("userModal"));
        public IWebElement Help => _driver.FindElement(By.Id("help"));
        public IWebElement Logout => _driver.FindElement(By.Id("logout"));

        public UserMenu(IWebDriver driver)
        {
            _driver = driver;
        }
    }
}
