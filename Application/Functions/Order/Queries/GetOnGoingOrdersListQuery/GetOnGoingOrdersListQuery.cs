using MediatR;

namespace Application.Functions.Order.Queries.GetOnGoingOrdersListQuery
{
    public class GetOnGoingOrdersListQuery : IRequest<List<TableOnGoingOrdersDTO>>
    {
    }
}
