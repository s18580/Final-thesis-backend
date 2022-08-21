using Application.Functions.DTOs.SearchersDTOs;
using MediatR;

namespace Application.Functions.Order.Queries.GetSearchOrderListQuery
{
    public class GetSearchOrderListQuery : IRequest<List<SearchOrderDTO>>
    {
        public string Name { get; set; }
        public string Identifier { get; set; }
        public string ExpectedDeliveryDate { get; set; }
        public string Status { get; set; }
        public bool IsAuction { get; set; }
    }
}
