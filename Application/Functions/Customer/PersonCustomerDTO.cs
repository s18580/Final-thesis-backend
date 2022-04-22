using Domain.Models;

namespace Application.Functions.Customer
{
    public class PersonCustomerDTO
    {
        public int IdCustomer { get; set; }
        public string CompanyName { get; set; }
        public string CompanyPhoneNumber { get; set; }
        public string CompanyEmailAddress { get; set; }
        public int? IdWorker { get; set; }

        public Worker Worker { get; set; }
        public ICollection<Domain.Models.Address> Addresses { get; set; }
        public ICollection<Domain.Models.Representative> Representatives { get; set; }
    }
}
