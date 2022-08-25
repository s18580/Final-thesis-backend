using MediatR;

namespace Application.Functions.Order.Queries.GetOrdersListByRepresentativeQuery
{
    public class GetOrdersListByRepresentativeQuery : IRequest<List<Domain.Models.Order>>
    {
        public int Id { get; set; }
    }
}
