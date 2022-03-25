namespace Domain.Models
{
    public class Supplier
    {
        public int IdSupplier { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }

        public ICollection<Representative> Representatives { get; set; }
        public ICollection<Address> Addresses { get; set; }
    }
}
