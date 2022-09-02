using OpenQA.Selenium;

namespace Application.Tests.Mappings.AddressModal
{
    public class AddressActions
    {
        private static AddressModal AddressModal { get; set; }
        public static void InitPage(IWebDriver driver)
        {
            AddressModal = new AddressModal(driver);
        }

        public static void PopulateAddressDetails(string name, string country, string city, string street, string streetNumber, string apartmantNumber, string postCode)
        {
            AddressModal.Name.SendKeys(name);
            AddressModal.Country.SendKeys(country);
            AddressModal.City.SendKeys(city);
            AddressModal.PostCode.SendKeys(postCode);
            AddressModal.Street.SendKeys(street);
            AddressModal.StreetNumber.SendKeys(streetNumber);
            AddressModal.Apartment.SendKeys(apartmantNumber);
        }

        public static void AddAddress()
        {
            AddressModal.AddAddress.Click();
        }
    }
}
