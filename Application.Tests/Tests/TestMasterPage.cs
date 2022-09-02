using Application.Tests.Setup;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Application.Tests.Tests
{
    public class TestMasterPage
    {
        public IWebDriver _driver { get; }

        public TestMasterPage()
        {
            _driver = new ChromeDriver(Constants.ChromeDriverPath);
            _driver.Manage().Window.Maximize();
        }

        [TestInitialize]
        public void Init()
        {
            _driver.Navigate().GoToUrl(Constants.StartURL);
        }

        [TestCleanup]
        public void ClenUp()
        {
            _driver.Dispose();
        }
    }
}
