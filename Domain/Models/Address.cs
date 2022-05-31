namespace Domain.Models
{
    public class Address
    {
        public int IdAddress { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostCode { get; set; }
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }
        public string ApartmentNumber { get; set; }
        public int? IdSupplier { get; set; }
        public int? IdCustomer { get; set; }

        public Customer Customer { get; set; }
        public Supplier Supplier { get; set; }
        public ICollection<DeliveriesAddresses> DeliveriesAddresses { get; set; }
    }
}
