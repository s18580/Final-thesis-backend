using MediatR;

namespace Application.Functions.Order.Queries.GetOrderListByDeliveryDateQuery
{
    public class GetOrderListByDeliveryDateQuery : IRequest<List<Domain.Models.Order>>
    {
    }
}
