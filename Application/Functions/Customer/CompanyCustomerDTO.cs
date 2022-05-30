using Domain.Models;

namespace Application.Functions.Customer
{
    public class CompanyCustomerDTO
    {
        public int IdCustomer { get; set; }
        public string CompanyName { get; set; }
        public string NIP { get; set; }
        public string Regon { get; set; }
        public string CompanyPhoneNumber { get; set; }
        public string CompanyEmailAddress { get; set; }
        public int? IdWorker { get; set; }

        public Worker Worker { get; set; }
        public ICollection<Domain.Models.Address> Addresses { get; set; }
        public ICollection<Domain.Models.Representative> Representatives { get; set; }
    }
}
