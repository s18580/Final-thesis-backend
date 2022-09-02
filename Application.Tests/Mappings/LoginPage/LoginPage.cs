using OpenQA.Selenium;

namespace Application.Tests.Mappings.LoginPage
{
    public class LoginPage
    {
        public IWebDriver _driver { get; }
        public IWebElement UserName => _driver.FindElement(By.Id("username"));
        public IWebElement Password => _driver.FindElement(By.Id("password"));
        public IWebElement LoginButton => _driver.FindElement(By.Id("login"));

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }
    }
}
