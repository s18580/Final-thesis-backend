using MediatR;

namespace Application.Functions.OrderStatus.Queries.GetOrderStatusQuery
{
    public class GetOrderStatusQuery : IRequest<Domain.Models.DictionaryModels.OrderStatus>
    {
        public int IdOrderStatus { get; set; }
    }
}
