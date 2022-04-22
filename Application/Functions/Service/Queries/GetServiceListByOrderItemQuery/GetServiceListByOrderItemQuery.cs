using MediatR;

namespace Application.Functions.Service.Queries.GetServiceListByOrderItemQuery
{
    public class GetServiceListByOrderItemQuery : IRequest<GetServiceListByOrderItemResponse>
    {
        public int IdOrderItem { get; set; }
    }
}
