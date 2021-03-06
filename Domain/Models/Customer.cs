namespace Domain.Models
{
    public class Customer
    {
        public int IdCustomer { get; set; }
        public string CompanyName { get; set; }
        public string NIP { get; set; }
        public string Regon { get; set; }
        public string CompanyPhoneNumber { get; set; }
        public string CompanyEmailAddress { get; set; }
        public int? IdWorker { get; set; }

        public Worker Worker { get; set; }
        public ICollection<Address> Addresses { get; set; }
        public ICollection<Representative> Representatives { get; set; }
    }
}
