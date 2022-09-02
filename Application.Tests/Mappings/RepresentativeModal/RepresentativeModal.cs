using OpenQA.Selenium;

namespace Application.Tests.Mappings.RepresentativeModal
{
    public class RepresentativeModal
    {
        public IWebDriver _driver { get; }
        public IWebElement RepresentativeName => _driver.FindElement(By.Id("repName"));
        public IWebElement RepresentativeLastName => _driver.FindElement(By.Id("repLastName"));
        public IWebElement RepresentativePhone => _driver.FindElement(By.Id("repPhone"));
        public IWebElement RepresentativeEmail => _driver.FindElement(By.Id("repEmail"));
        public IWebElement AddRepresentative => _driver.FindElement(By.Id("addRep"));

        public RepresentativeModal(IWebDriver driver)
        {
            _driver = driver;
        }
    }
}
