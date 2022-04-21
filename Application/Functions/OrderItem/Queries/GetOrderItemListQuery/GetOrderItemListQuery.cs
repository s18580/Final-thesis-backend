using MediatR;

namespace Application.Functions.OrderItem.Queries.GetOrderItemListQuery
{
    public class GetOrderItemListQuery : IRequest<List<Domain.Models.OrderItem>>
    {
    }
}
