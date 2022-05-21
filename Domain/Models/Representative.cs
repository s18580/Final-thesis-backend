namespace Domain.Models
{
    public class Representative
    {
        public int IdRepresentative { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public int? IdSupplier { get; set; }
        public int? IdCustomer { get; set; }

        public Customer Customer { get; set; }
        public Supplier Supplier { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Supply> Supplies { get; set; }
    }
}
