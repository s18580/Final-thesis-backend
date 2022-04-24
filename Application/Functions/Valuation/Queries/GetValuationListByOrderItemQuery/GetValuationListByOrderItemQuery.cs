using MediatR;

namespace Application.Functions.Valuation.Queries.GetValuationListByOrderItemQuery
{
    public class GetValuationListByOrderItemQuery : IRequest<GetValuationListByOrderItemResponse>
    {
        public int IdOrderItem { get; set; }
    }
}
