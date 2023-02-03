namespace Application.Tests.TestData
{
    public class AddressTestData
    {
        public static AddressData GetAddress()
        {
            return new AddressData("Biuro", "Polska", "Warszawa", "00‑117", "Chmielna", "37", "");
        }
    }

    public struct AddressData
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }
        public string ApartmentNumber { get; set; }

        public AddressData(string name, string country, string city, string postCode, string streetName, string streetNumber, string apartmentNumber)
        {
            Name = name;
            Country = country;
            City = city;
            PostCode = postCode;
            StreetName = streetName;
            StreetNumber = streetNumber;
            ApartmentNumber = apartmentNumber;
        }
    }
}
