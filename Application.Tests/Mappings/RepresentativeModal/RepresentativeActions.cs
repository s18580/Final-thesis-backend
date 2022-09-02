using OpenQA.Selenium;

namespace Application.Tests.Mappings.RepresentativeModal
{
    public class RepresentativeActions
    {
        private static RepresentativeModal RepresentativeModal { get; set; }
        public static void InitPage(IWebDriver driver)
        {
            RepresentativeModal = new RepresentativeModal(driver);
        }

        public static void PopulateRepresentativeDetails(string name, string lastName, string phone, string email)
        {
            RepresentativeModal.RepresentativeName.SendKeys(name);
            RepresentativeModal.RepresentativeLastName.SendKeys(lastName);
            RepresentativeModal.RepresentativeEmail.SendKeys(email);
            RepresentativeModal.RepresentativePhone.SendKeys(phone);
        }

        public static void AddRepresentative()
        {
            RepresentativeModal.AddRepresentative.Click();
        }
    }
}
