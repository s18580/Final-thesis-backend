namespace Application.Tests.TestData
{
    public class CustomerTestData
    {
        public static CustomerData GetPrivateCustomer()
        {
            return new CustomerData("Kamil", "Kamilowski", "k.kam@gmail.com", "", "", "", "");
        }

        public static CustomerData GetCompanyCustomer()
        {
            return new CustomerData("", "", "biuro@tko.pl", "221232354", "2222222222", "2222222222", "TKO Sp. z.o.o.");
        }
    }

    public struct CustomerData
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public string NIP { get; set; }
        public string Regon { get; set; }
        public string CompanyEmail { get; set; }
        public string CompanyPhone { get; set; }

        public CustomerData(string name, string lastName, string companyEmail, string companyPhone, string nip, string regon, string companyName)
        {
            Name = name;
            LastName = lastName;
            CompanyPhone = companyPhone;
            CompanyEmail = companyEmail;
            NIP = nip;
            Regon = regon;
            CompanyName = companyName;
        }
    }
}