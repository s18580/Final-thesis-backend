namespace Application.Functions.Customer.Commands.CreatePersonCustomerCommand
{
    public class PersonDTO
    {
        public string CompanyName { get; set; }
        public string NIP { get; set; }
        public string Regon { get; set; }
        public string CompanyPhoneNumber { get; set; }
        public string CompanyEmailAddress { get; set; }
        public int? IdWorker { get; set; }
    }
}
