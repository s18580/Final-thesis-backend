using Application.Functions.DTOs.SearchersDTOs;
using MediatR;

namespace Application.Functions.Supply.Queries.GetSearchSupplyQuery
{
    public class GetSearchSupplyQuery : IRequest<List<SearchSupplyDTO>>
    {
        public string SupplyDate { get; set; }
        public string SupplyItemTypeName { get; set; }
        public string RepresentativeName { get; set; }
        public string SupplierName { get; set; }
        public bool IsReceived { get; set; }
    }
}
