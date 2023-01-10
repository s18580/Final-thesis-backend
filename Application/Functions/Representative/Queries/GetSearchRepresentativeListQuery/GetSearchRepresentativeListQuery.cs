using Application.Functions.DTOs.SearchersDTOs;
using MediatR;

namespace Application.Functions.Representative.Queries.GetSearchRepresentativeListQuery
{
    public class GetSearchRepresentativeListQuery : IRequest<List<SearchRepresentativeDTO>>
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Customer { get; set; }
        public string Supplier { get; set; }
        public bool IsDisabled { get; set; }
    }
}
