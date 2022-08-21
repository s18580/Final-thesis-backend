using Application.Functions.DTOs.SearchersDTOs;
using MediatR;

namespace Application.Functions.Customer.Queries.GetSearchCustomerListQuery
{
    public class GetSearchCustomerListQuery : IRequest<List<SearchCustomerDTO>>
    {
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerEmail { get; set; }
        public string NIP { get; set; }
        public string REGON { get; set; }
        public string RepresentativeName { get; set; }
        public string RepresentativeLastName { get; set; }
        public string RepresentativePhone { get; set; }
        public string RepresentativeEmail { get; set; }
        public string WorkerLeader { get; set; }
    }
}
