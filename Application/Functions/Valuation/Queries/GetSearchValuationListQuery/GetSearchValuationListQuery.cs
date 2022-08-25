using Application.Functions.DTOs.SearchersDTOs;
using MediatR;

namespace Application.Functions.Valuation.Queries.GetSearchValuationListQuery
{
    public class GetSearchValuationListQuery : IRequest<List<SearchValuationDTO>>
    {
        public string ValuationName { get; set; }
        public string Author { get; set; }
        public string Paper { get; set; }
        public string Color { get; set; }
        public string ServiceName { get; set; }
        public string BindingType { get; set; }
        public string OrderName { get; set; }
        public string OrderItemType { get; set; }
        public string OrderItem { get; set; }
        public string CreationDate { get; set; }
    }
}
