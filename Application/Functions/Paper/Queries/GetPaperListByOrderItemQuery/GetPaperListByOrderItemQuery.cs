using MediatR;

namespace Application.Functions.Paper.Queries.GetPaperListByOrderItemQuery
{
    public class GetPaperListByOrderItemQuery : IRequest<GetPaperListByOrderItemResponse>
    {
        public int IdOrderItem { get; set; }
    }
}
