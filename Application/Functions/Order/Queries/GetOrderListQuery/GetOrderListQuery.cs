using MediatR;

namespace Application.Functions.Order.Queries.GetOrderListQuery
{
    public class GetOrderListQuery : IRequest<List<Domain.Models.Order>>
    {
    }
}
