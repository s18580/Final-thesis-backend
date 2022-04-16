using MediatR;

namespace Application.Functions.Order.Queries.GetOrderQuery
{
    public class GetOrderQuery : IRequest<Domain.Models.Order>
    {
        public int IdOrder { get; set; }
    }
}
