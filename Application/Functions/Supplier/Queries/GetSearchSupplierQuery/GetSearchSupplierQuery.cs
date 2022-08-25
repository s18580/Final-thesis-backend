using Application.Functions.DTOs.SearchersDTOs;
using MediatR;

namespace Application.Functions.Supplier.Queries.GetSearchSupplierQuery
{
    public class GetSearchSupplierQuery : IRequest<List<SearchSupplierDTO>>
    {
        public string SupplierName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string AddressName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Description { get; set; }
        public string RepresentativeName { get; set; }
        public string RepresentativeLastName { get; set; }
    }
}
