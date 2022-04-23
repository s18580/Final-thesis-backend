using MediatR;

namespace Application.Functions.Color.Queries.GetColorListByOrderItemQuery
{
    public class GetColorListByOrderItemQuery : IRequest<GetColorListByOrderItemResponse>
    {
        public int IdOrderItem { get; set; }
    }
}
