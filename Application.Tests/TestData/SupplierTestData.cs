namespace Application.Tests.TestData
{
    public class SupplierTestData
    {
        public static SupplierData GetSupplier()
        {
            return new SupplierData("Atalo", "biuro@atalo.pl", "221672354", "Taśmy do maszyny CR88234");
        }
    }

    public struct SupplierData
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public SupplierData(string name, string email, string phone, string description)
        {
            Name = name;
            Description = description;
            Email = email;
            Phone = phone;
        }
    }
}
